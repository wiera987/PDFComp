using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PDFComp
{
    internal class ImageProcess
    {
        readonly int FinalColors = 256;             // final number of colors
        readonly int FixedColors = 16;              // Number of colors to use directly from the histogram.
        readonly double auto_reduction_thresh = 30; // PSNR threshold [dB], No color reduction when image quality is poor.
        private Dictionary<UInt32, UInt32> _dict;   // Color histogram

        public ImageProcess()
        {
            _dict = new Dictionary<UInt32, UInt32>();
        }

        public ImageProcess(int finalColors, int fixedColors)
        {
            FinalColors = finalColors;
            FixedColors = fixedColors;
            _dict = new Dictionary<UInt32, UInt32>();
        }

        /// <summary>
        /// Scanning pixels to create a color histogram.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public int CountColors(Bitmap bitmap)
        {
            // Create a new histogram.
            _dict.Clear();

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // Count colors by Dictionary.
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            byte[] pixels = new byte[bmpData.Stride * bitmap.Height];
            Marshal.Copy(ptr, pixels, 0, pixels.Length);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index32bit = y * bmpData.Stride + x * 4;
                    UInt32 bgr = ((UInt32)pixels[index32bit] << 16) | ((UInt32)pixels[index32bit + 1] << 8) | (UInt32)pixels[index32bit + 2];
                    UInt32 colors;

                    if (_dict.TryGetValue(bgr, out colors))
                    {
                        _dict[bgr] = colors+1;
                    }
                    else
                    { 
                        _dict[bgr] = 1;
                    }
                }
            }
            bitmap.UnlockBits(bmpData);
            Console.WriteLine(" Count = {0}", _dict.Count);

            stopwatch.Stop();
            Console.WriteLine("CountColor : {0}s", stopwatch.Elapsed);

            // Print Histgram
            if (false)
            {
                int index = 0;
                foreach (KeyValuePair<UInt32, UInt32> kvp in _dict.OrderByDescending(i => i.Value))
                {
                    Console.WriteLine("{0} {1:X6} = {2}", index, kvp.Key, kvp.Value);
                    index++;
                }
            }

            return _dict.Count;
        }

        /// <summary>
        /// Reduce color to 4 bits each RGB.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="auto"></param>
        public void QuantizeRGB4(Bitmap bitmap, bool auto)
        {
            double psnr = 9999;
            double mse = 0;
            int sq_error = 0;

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // Convert RGB x 4bit
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            byte[] pixels = new byte[bmpData.Stride * bitmap.Height];
            Marshal.Copy(ptr, pixels, 0, pixels.Length);
            for (int y = 0; y < bitmap.Height; y++)
            {
                sq_error = 0;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index32bit = y * bmpData.Stride + x * 4;
                    byte b = pixels[index32bit];
                    byte g = pixels[index32bit + 1];
                    byte r = pixels[index32bit + 2];

                    byte b_high = (byte)(b & 0xf0 | (b >> 4));
                    byte g_high = (byte)(g & 0xf0 | (g >> 4));
                    byte r_high = (byte)(r & 0xf0 | (r >> 4));

                    pixels[index32bit] = b_high;
                    pixels[index32bit + 1] = g_high;
                    pixels[index32bit + 2] = r_high;

                    sq_error += (b - b_high) * (b - b_high)
                              + (g - g_high) * (g - g_high)
                              + (r - r_high) * (r - r_high);
                }
                mse += sq_error / bitmap.Width;
            }
            if (mse > 0)
            {
                psnr = 20 * Math.Log10(255 / Math.Sqrt(mse / bitmap.Height));
            }

            Console.WriteLine(" PSNR = {0:N2}[dB]", psnr);

            if (!auto || (auto && (psnr > auto_reduction_thresh)))
            {
                Marshal.Copy(pixels, 0, ptr, pixels.Length);
            }

            bitmap.UnlockBits(bmpData);

            stopwatch.Stop();
            Console.WriteLine("QuantizeRGB4 : {0}s", stopwatch.Elapsed);
        }


        /// <summary>
        /// Reduce colors using the histogram created by CountColors().
        /// The upper <FixedColors> colors are used in the palette as is.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="auto"></param>
        public void QuantizeRGB4mix(Bitmap bitmap, bool auto)
        {
            double psnr = 9999;
            double mse = 0;
            int sq_error = 0;

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // The current image condition must be known.
            Debug.Assert(_dict.Count > 0);

            // For simplicity, select the top of the histogram as the fixed color.
            List<UInt32> fixedList = new List<UInt32>();
            foreach (KeyValuePair<UInt32, UInt32> kvp in _dict.OrderByDescending(i => i.Value).Take(FixedColors))
            {
                fixedList.Add(kvp.Key);
            }

            // Convert RGB x 4bit
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            byte[] pixels = new byte[bmpData.Stride * bitmap.Height];
            Marshal.Copy(ptr, pixels, 0, pixels.Length);
            for (int y = 0; y < bitmap.Height; y++)
            {
                sq_error = 0;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index32bit = y * bmpData.Stride + x * 4;
                    byte b = pixels[index32bit];
                    byte g = pixels[index32bit + 1];
                    byte r = pixels[index32bit + 2];

                    UInt32 bgr = ((UInt32)b << 16) | ((UInt32)g << 8) | (UInt32)r;
                    if (fixedList.Contains(bgr) == false)
                    {
                        byte b_high = (byte)(b & 0xf0 | (b >> 4));
                        byte g_high = (byte)(g & 0xf0 | (g >> 4));
                        byte r_high = (byte)(r & 0xf0 | (r >> 4));

                        pixels[index32bit] = b_high;
                        pixels[index32bit + 1] = g_high;
                        pixels[index32bit + 2] = r_high;

                        sq_error += (b - b_high) * (b - b_high)
                                  + (g - g_high) * (g - g_high)
                                  + (r - r_high) * (r - r_high);
                    }
                }
                mse += sq_error / bitmap.Width;
            }

            if (mse > 0)
            {
                psnr = 20 * Math.Log10(255 / Math.Sqrt(mse / bitmap.Height));
            }

            Console.WriteLine(" PSNR = {0:N2}[dB]", psnr);

            if (!auto || (auto && (psnr > auto_reduction_thresh)))
            {
                Marshal.Copy(pixels, 0, ptr, pixels.Length);
            }

            bitmap.UnlockBits(bmpData);

            stopwatch.Stop();
            Console.WriteLine("QuantizeRGB4mix : {0}s", stopwatch.Elapsed);
        }

        /// <summary>
        /// When there are <FinalColors> or more colors, replace the color with the fewest pixels with the existing color.
        /// </summary>
        /// <param name="bitmap"></param>
        public void Select256colors(Bitmap bitmap)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // The source image condition must be known.
            Debug.Assert(_dict.Count > 0);

            var rgb_table = new byte[_dict.Count * 4];
            int dindex = 0;
            foreach (KeyValuePair<UInt32, UInt32> kvp in _dict.OrderBy(i => i.Value))
            {
                UInt32 src_col = kvp.Key;
                rgb_table[dindex * 4 + 0] = (byte)(src_col >> 16);
                rgb_table[dindex * 4 + 1] = (byte)(src_col >> 8);
                rgb_table[dindex * 4 + 2] = (byte)(src_col >> 0);
                dindex++;
            }

            // Select the bottoms of the histogram as the converted color.
            int reduceColors = _dict.Count <= FinalColors ? 0 : _dict.Count - FinalColors;
            Dictionary<UInt32, UInt32> convDict = new Dictionary<UInt32, UInt32>();

            for (int index = 0; index < reduceColors; index++)
            {
                byte src_b = rgb_table[index * 4 + 0];
                byte src_g = rgb_table[index * 4 + 1];
                byte src_r = rgb_table[index * 4 + 2];
                UInt32 src = ((UInt32)rgb_table[index * 4 + 0] << 16) | ((UInt32)rgb_table[index * 4 + 1] << 8) | ((UInt32)rgb_table[index * 4 + 2]);

                // Select the closest color to keep.
                int min_dist = int.MaxValue;
                int min_index = 0;
                for (int i = reduceColors; i < _dict.Count; i++)
                {
                    byte b = rgb_table[i * 4 + 0];
                    byte g = rgb_table[i * 4 + 1];
                    byte r = rgb_table[i * 4 + 2];

                    int d = (src_b - b) * (src_b - b) + (src_g - g) * (src_g - g) + (src_r - r) * (src_r - r);

                    if (d < min_dist)
                    {
                        min_dist = d;
                        min_index = i;
                    }
                }

                convDict[src] = ((UInt32)rgb_table[min_index * 4 + 0] << 16) | ((UInt32)rgb_table[min_index * 4 + 1] << 8) | ((UInt32)rgb_table[min_index * 4 + 2]);
            }

            // Print convDict
            if (false)
            {
                int index = 0;
                foreach (KeyValuePair<UInt32, UInt32> kvp in convDict)
                {
                    Console.WriteLine(" cnv{0} {1:X6} = {2:X6}", index, kvp.Key, kvp.Value);
                    index++;
                }
            }


            // Convert 256 colors
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            byte[] pixels = new byte[bmpData.Stride * bitmap.Height];
            Marshal.Copy(ptr, pixels, 0, pixels.Length);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index32bit = y * bmpData.Stride + x * 4;
                    byte b = pixels[index32bit];
                    byte g = pixels[index32bit + 1];
                    byte r = pixels[index32bit + 2];

                    UInt32 bgr = ((UInt32)b << 16) | ((UInt32)g << 8) | (UInt32)r;
                    if (convDict.ContainsKey(bgr) == true)
                    {
                        UInt32 dst_col = convDict[bgr];
                        pixels[index32bit] = (byte)(dst_col >> 16);
                        pixels[index32bit + 1] = (byte)(dst_col >> 8);
                        pixels[index32bit + 2] = (byte)(dst_col >> 0);
                    }
                }
            }

            Marshal.Copy(pixels, 0, ptr, pixels.Length);

            bitmap.UnlockBits(bmpData);

            stopwatch.Stop();
            Console.WriteLine("Select256colors : {0}s", stopwatch.Elapsed);
        }


        /// <summary>
        /// Reduce to 256 colors in one pass.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="auto"></param>
        public void Quantize256(Bitmap bitmap, bool auto)
        {
            double psnr = 9999;
            double mse = 0;
            int sq_error = 0;

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // The source image condition must be known.
            Debug.Assert(_dict.Count > 0);

            if (_dict.Count <= FinalColors) {
                stopwatch.Stop();
                Console.WriteLine("Quantize256 : {0}s", stopwatch.Elapsed);
                return;
            }


            Dictionary<UInt32, UInt32> convDict = new Dictionary<UInt32, UInt32>();
            HashSet<UInt32> fixedList = new HashSet<UInt32>();
            foreach (KeyValuePair<UInt32, UInt32> kvp in _dict.OrderByDescending(i => i.Value))
            {
                UInt32 src_col = kvp.Key;
                UInt32 dst_col = kvp.Key;

                if (fixedList.Count < FixedColors)
                {
                    convDict[src_col] = dst_col;
                    fixedList.Add(dst_col);
                }
                else if (fixedList.Count < FinalColors)
                {
                    byte b = (byte)(src_col >> 16);
                    byte g = (byte)(src_col >> 8);
                    byte r = (byte)(src_col >> 0);

                    byte b_high = (byte)(b & 0xf0 | (b >> 4));
                    byte g_high = (byte)(g & 0xf0 | (g >> 4));
                    byte r_high = (byte)(r & 0xf0 | (r >> 4));

                    dst_col = ((UInt32)b_high << 16) | ((UInt32)g_high << 8) | (UInt32)r_high;
                    convDict[src_col] = dst_col;
                    fixedList.Add(dst_col);
                }
                else
                {
                    byte b = (byte)(src_col >> 16);
                    byte g = (byte)(src_col >> 8);
                    byte r = (byte)(src_col >> 0);

                    byte b_high = (byte)(b & 0xf0 | (b >> 4));
                    byte g_high = (byte)(g & 0xf0 | (g >> 4));
                    byte r_high = (byte)(r & 0xf0 | (r >> 4));

                    dst_col = ((UInt32)b_high << 16) | ((UInt32)g_high << 8) | (UInt32)r_high;

                    if (convDict.ContainsKey(src_col))
                    {
                        // do nothing.
                    }
                    else
                    {
                        // Select the color from fixedList.
                        if (fixedList.Contains(dst_col))
                        {
                            convDict[src_col] = dst_col;
                        }
                        else
                        {
                            // Select the closest color from fixedList.
                            convDict[src_col] = SelectClosestColor(fixedList, b, g, r);
                        }
                    }
                }
            }

            // Print convDict
            if (false)
            {
                int index = 0;
                foreach (UInt32 close_col in fixedList)
                {
                    Console.WriteLine(" fixedList{0} {1:X6}", index, close_col);
                    index++;
                }
            }


            // Convert to 256 colors
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            byte[] pixels = new byte[bmpData.Stride * bitmap.Height];
            Marshal.Copy(ptr, pixels, 0, pixels.Length);
            for (int y = 0; y < bitmap.Height; y++)
            {
                sq_error = 0;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index32bit = y * bmpData.Stride + x * 4;

                    byte b = pixels[index32bit];
                    byte g = pixels[index32bit + 1];
                    byte r = pixels[index32bit + 2];
                    
                    UInt32 bgr = ((UInt32)b << 16) | ((UInt32)g << 8) | (UInt32)r;

                    Debug.Assert(convDict.ContainsKey(bgr));
                    UInt32 dst_col = convDict[bgr];
                    pixels[index32bit] = (byte)(dst_col >> 16);
                    pixels[index32bit + 1] = (byte)(dst_col >> 8);
                    pixels[index32bit + 2] = (byte)(dst_col >> 0);

                    sq_error += (b - pixels[index32bit+0]) * (b - pixels[index32bit+0])
                              + (g - pixels[index32bit+1]) * (g - pixels[index32bit+1])
                              + (r - pixels[index32bit+2]) * (r - pixels[index32bit+2]);
                }
                mse += sq_error / bitmap.Width;
            }
            if (mse > 0)
            {
                psnr = 20 * Math.Log10(255 / Math.Sqrt(mse / bitmap.Height));
            }

            Console.WriteLine(" Count = {0}", fixedList.Count);
            Console.WriteLine(" PSNR = {0:N2}[dB]", psnr);

            if (!auto || (auto && (psnr > auto_reduction_thresh)))
            {
                Marshal.Copy(pixels, 0, ptr, pixels.Length);
            }

            bitmap.UnlockBits(bmpData);

            stopwatch.Stop();
            Console.WriteLine("Quantize256 : {0}s", stopwatch.Elapsed);
        }

        private static uint SelectClosestColor(HashSet<uint> fixedList, byte b, byte g, byte r)
        {
            UInt32 min_color = UInt32.MaxValue;
            int min_dist = int.MaxValue;
            foreach (var close_col in fixedList)
            {
                byte close_b = (byte)(close_col >> 16);
                byte close_g = (byte)(close_col >> 8);
                byte close_r = (byte)(close_col >> 0);

                int d = (b - close_b) * (b - close_b) + (g - close_g) * (g - close_g) + (r - close_r) * (r - close_r);

                if (d < min_dist)
                {
                    min_dist = d;
                    min_color = close_col;
                }
            }

            return min_color;
        }
    }
}
