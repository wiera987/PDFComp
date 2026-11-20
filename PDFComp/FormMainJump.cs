using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace PDFComp
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class DesignerBlockerJump { }

	public partial class FormMain
    {
        // Page pairs include zero-text comparisons and retain the legacy per-page test.
        // Settings and selection changes do not discard existing comparison results.
        // Returns whether a comparison was run. JumpByMode checks that both documents are loaded.
        private bool CompareCurrentIfNeeded()
        {
            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;
            bool compared1 = pagePairList.GetPage1Counter(page1) >= 0;
            bool compared2 = pagePairList.GetPage2Counter(page2) >= 0;
            bool newlyCompared = !compared1 || !compared2;
            if (newlyCompared)
            {
                CompareByMode();
            }
            return newlyCompared;
        }

        private bool HasComparisonMarkers(int page1, int page2)
        {
            // Empty-span pairs consume no text on either side. Skip them when requested,
            // since page markers can belong to another pair at these intermediate steps.
            var pair = pagePairList.GetPagePair(page1, page2);
            if (Properties.Settings.Default.SkipIntermediateBlankPageStops &&
                pair != null && pair.Span1.Count == 0 && pair.Span2.Count == 0)
            {
                return false;
            }

            // For other pairs, preserve the marker-based stop policy, including search markers.
            return pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) ||
                pdfPanel2.pdfViewer.Renderer.HasMarkers(page2);
        }

        /// <summary>
        /// Captures comparison pages, displayed pages and scroll offsets to detect progress.
        /// </summary>
        private (int compared1, int compared2, int page1, int page2, Point offset1, Point offset2) GetJumpPosition()
        {
            // Comparison bounds can select a page other than the displayed page.
            // Include both page numbers and scroll offsets to detect movement and cycles.
            var renderer1 = pdfPanel1.pdfViewer.Renderer;
            var renderer2 = pdfPanel2.pdfViewer.Renderer;
            return (renderer1.ComparisonPage, renderer2.ComparisonPage, renderer1.Page, renderer2.Page,
                renderer1.DisplayRectangle.Location, renderer2.DisplayRectangle.Location);
        }

        private static (bool AdvancePage1, bool AdvancePage2) GetComparisonMove(
            PagePairList pagePairList,
            int page1, int page2, int direction, int page1end, int page2end)
        {
            if (direction != 1 && direction != -1)
            {
                throw new ArgumentOutOfRangeException(nameof(direction));
            }

            bool movingForward = direction > 0;
            bool advancePage1 = movingForward ? page1 < page1end : page1 > 0;
            bool advancePage2 = movingForward ? page2 < page2end : page2 > 0;

            // Try known neighboring page pairs first so the established one-to-many traversal order is preserved.
            if (advancePage2 && pagePairList.GetPagePair(page1, page2 + direction) != null)
            {
                return (false, true);
            }

            if (advancePage1 && pagePairList.GetPagePair(page1 + direction, page2) != null)
            {
                return (true, false);
            }

            if (advancePage1 && advancePage2 && pagePairList.GetPagePair(page1 + direction, page2 + direction) != null)
            {
                return (true, true);
            }

            int currPage1Counter = pagePairList.GetPage1Counter(page1), currPage2Counter = pagePairList.GetPage2Counter(page2);
            int destPage1Counter = pagePairList.GetPage1Counter(page1 + direction);
            int destPage2Counter = pagePairList.GetPage2Counter(page2 + direction);

            // GetPage1Counter returns the paired File2 page.
            // GetPage2Counter returns the paired File1 page.
            //
            // A value of -1 indicates that no PagePair exists and must not
            // prevent page movement.
            if (currPage1Counter >= 0 && currPage2Counter >= 0)
            {
                bool page1AheadOfCounter = movingForward ? page1 > currPage2Counter : page1 < currPage2Counter;
                bool page2AheadOfCounter = movingForward ? page2 > currPage1Counter : page2 < currPage1Counter;
                if (page1AheadOfCounter && page2 != currPage1Counter)
                {
                    advancePage1 = false;
                }
                if (page2AheadOfCounter && page1 != currPage2Counter)
                {
                    advancePage2 = false;
                }
            }

            // Keep File1 on the current page when the destination page in File2
            // still pairs with the current File1 page, so the one-to-many mapping
            // is visited first.
            if (destPage2Counter >= 0 && page1 == destPage2Counter)
            {
                advancePage1 = false;
            }
            // Keep File2 on the current page when the destination page in File1
            // still pairs with the current File2 page, so the one-to-many mapping
            // is visited first.
            if (destPage1Counter >= 0 && page2 == destPage1Counter)
            {
                advancePage2 = false;
            }
            return (advancePage1, advancePage2);
        }

        /// <summary>
        /// Moves through comparisons in either direction until the page or difference stop condition is met.
        /// </summary>
        private void JumpByMode(bool forward)
        {
            if (pdfPanel1.pdfViewer.Document == null || pdfPanel2.pdfViewer.Document == null)
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = Stopwatch.StartNew();
            int direction = forward ? 1 : -1;
            int page1end = pdfPanel1.pdfViewer.Document.PageCount - 1;
            int page2end = pdfPanel2.pdfViewer.Document.PageCount - 1;
            int pageCount1 = 0, pageCount2 = 0;
            // Track visited positions so a cycle cannot keep the search running.
            var visited = new HashSet<(int, int, int, int, Point, Point)>();
            tipJump1.Hide(pdfPanel1);
            tipJump2.Hide(pdfPanel2);

            while (true)
            {
                var before = GetJumpPosition();
                // Stop a forward search when both comparison pages reach the document ends.
                if (forward && before.compared1 >= page1end && before.compared2 >= page2end)
                {
                    break;
                }

                // Stop if the search returns to a previously visited position.
                if (!visited.Add(before))
                {
                    break;
                }

                // Compare if needed, then check whether to stop at the current position.
                bool newlyCompared = CompareCurrentIfNeeded();

                var current = GetJumpPosition();
                bool currentHasDifferences = HasComparisonMarkers(current.compared1, current.compared2);
                bool pageJumpMode = toolStripButtonJumpScopePage.Visible;
                bool stopOnCurrentPage = currentHasDifferences || pageJumpMode;
                // After a new comparison, apply the marker stop policy for the current pair.
                // Page Jump also stops after a new comparison with no differences or text.
                if (newlyCompared && stopOnCurrentPage)
                {
                    break;
                }

                // Choose which side to move using the existing page correspondences.
                var move = GetComparisonMove(pagePairList,
                    current.compared1, current.compared2, direction, page1end, page2end);
                if (move.AdvancePage1)
                {
                    if (forward)
                    {
                        pdfPanel1.NextPage();
                    }
                    else
                    {
                        pdfPanel1.PrevPage();
                    }
                }
                if (move.AdvancePage2)
                {
                    if (forward)
                    {
                        pdfPanel2.NextPage();
                    }
                    else
                    {
                        pdfPanel2.PrevPage();
                    }
                }

                var after = GetJumpPosition();
                // Stop if an endpoint or disabled navigation control prevents movement.
                if (after.Equals(current))
                {
                    break;
                }

                // Count a move only on a side whose displayed page or scroll offset changed.
                if (after.page1 != current.page1 || after.offset1 != current.offset1)
                {
                    pageCount1++;
                }
                if (after.page2 != current.page2 || after.offset2 != current.offset2)
                {
                    pageCount2++;
                }

                // Compare the destination if needed, then check the stop conditions.
                CompareCurrentIfNeeded();
                after = GetJumpPosition();
                bool differencesFound = HasComparisonMarkers(after.compared1, after.compared2);
                // Stop a backward search when both comparison pages reach the document starts.
                bool bothAtFirstPage = after.compared1 == 0 && after.compared2 == 0;
                bool backwardEndpointReached = !forward && bothAtFirstPage;
                bool jumpScopeStopReached = differencesFound || toolStripButtonJumpScopePage.Visible;
                if (jumpScopeStopReached || backwardEndpointReached)
                {
                    break;
                }
            }

            // Update flashing at the final position, then show movement counts and elapsed time.
            stopwatch.Stop();
            var final = GetJumpPosition();
            SetFlashPage(final.compared1, final.compared2);
            ResetBlinkingMarkerTiming(blinkingMarker);
            string destination = forward ? "next" : "prev";
            if (pageCount1 > 1)
            {
                tipJump1.Show($"Jumped {pageCount1} pages to {destination} diff.", pdfPanel1, new Point(100, 64), 2000);
            }
            if (pageCount2 > 1)
            {
                tipJump2.Show($"Jumped {pageCount2} pages to {destination} diff.", pdfPanel2, new Point(100, 64), 2000);
            }
            toolStripLabelResult.Text = string.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);
        }
    }
}
