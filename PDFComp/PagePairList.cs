using System;
using System.Collections;
using System.Collections.Generic;
using PdfiumViewer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PDFComp
{
    public class PagePair
    {
        public int Page1 { get; set; }
        public int Page2 { get; set; }
        public List<PdfTextSpan> Span1 { get; set; }
        public List<PdfTextSpan> Span2 { get; set; }
    }

    public class PagePairList : IEnumerable<PagePair>
    {
        List<PagePair> PairList = new List<PagePair>();

        public IEnumerator<PagePair> GetEnumerator()
        {
            return PairList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ClearAll()
        {
            PairList.Clear();
        }

        /// <summary>
        /// Remove all elements that fall within the range of page1 or page2.
        /// </summary>
        /// <param name="x1">startPage1</param>
        /// <param name="x2">endPage1</param>
        /// <param name="y1">startPage2</param>
        /// <param name="y2">endPage2</param>
        public void Clear(int x1, int x2, int y1, int y2)
        {
            PairList.RemoveAll(pair => ((pair.Page1 >= x1) && (pair.Page1 <= x2)) || ((pair.Page2 >= y1) && (pair.Page2 <= y2)));
        }

        public void SetPagePair(int page1, int page2, List<PdfTextSpan> span1, List<PdfTextSpan> span2)
        {
            PagePair existingPair = null; // PagePair is the type of elements in PairList

            // Check if a PagePair with the same Page1 and Page2 already exists
            foreach (var p in PairList)
            {
                if (p.Page1 == page1 && p.Page2 == page2)
                {
                    existingPair = p;
                    break; // Stop once the first match is found
                }
            }

            if (existingPair != null)
            {
                // Update the existing PagePair
                existingPair.Span1 = span1;
                existingPair.Span2 = span2;
            }
            else
            {
                // Create a new PagePair and add it to the list
                var newPair = new PagePair
                {
                    Page1 = page1,
                    Page2 = page2,
                    Span1 = span1,
                    Span2 = span2
                };
                PairList.Add(newPair);
            }
        }

        public PagePair GetPagePair(int page1, int page2)
        {
            foreach (var p in PairList)
            {
                if (p.Page1 == page1 && p.Page2 == page2)
                {
                    return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the first counter page found without strict accuracy.
        /// </summary>
        /// <param name="page1"></param>
        /// <returns></returns>
        public int GetPage1Counter(int page1)
        {
            foreach (var p in PairList)
            {
                if (p.Page1 == page1)
                {
                    return p.Page2;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the first counter page found without strict accuracy.
        /// </summary>
        /// <param name="page2"></param>
        /// <returns></returns>
        public int GetPage2Counter(int page2)
        {
            foreach (var p in PairList)
            {
                if (p.Page2 == page2)
                {
                    return p.Page1;
                }
            }
            return -1;
        }
    }
}