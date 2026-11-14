using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PdfiumViewer;

namespace PDFComp
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class DesignerBlockerHistory { }

    public partial class PdfPanel
    {
        // View history (managed per panel on its UI thread):
        // - Record view changes from internal links, user bookmark selections and page input.
        //   Scrolling, page stepping, searches and diff navigation do not append entries.
        // - _viewHistory stores the views; _historyIndex identifies the current entry.
        //   Back/forward traverses the list; a new jump discards the forward entries.
        //   Save the latest reading position into the current entry just before leaving it.
        // - Reuse the scroll offset when display conditions match; otherwise recalculate it
        //   from a PDF anchor and its relative viewport position. Keep current zoom/rotation/fit.
        // - Save bookmark selection to preserve parent/child comparison scopes on the same page.
        // - _restoringHistory suppresses recording and automatic bookmark selection during restore.
        // - Recoverable coordinate failures retain history and disable buttons until a valid refresh.
        //   Only explicit back/forward failures display an error; ordinary navigation still runs.
        // - Keep at most 100 entries besides the current view. Clear on reopen; do not persist.
        private const int ViewHistoryLimit = 100;
        private readonly List<HistoryView> _viewHistory = new List<HistoryView>();
        private int _historyIndex = -1;
        private IPdfDocument _historyDocument;
        private bool _historyLoading;
        private bool _restoringHistory;
        private TreeView _historyBookmarks;
        private HistoryView _bookmarkJump;
        private HistoryView _linkJump;
        private LinkClickEventArgs _historyLinkEvent;
        private HistoryView _lastRestoredView;
        private bool _discardHistoryPageInput;
        private HistoryInputFilter _historyInputFilter;

        /// <summary>
        /// A snapshot of the state needed to restore a view, without copying PDF contents.
        /// </summary>
        private sealed class HistoryView
        {
            // Do not apply this entry to a different Document, even if its file name matches.
            public IPdfDocument Document;
            // Anchor includes the PDF page and coordinates; AnchorPosition is its viewport ratio.
            public PdfPoint Anchor;
            public PointF AnchorPosition;
            // Offset is the scroll position; Layout determines whether it can be reused directly.
            public Point Offset;
            public HistoryLayout Layout;
            // A node reference valid within this Document; null means no bookmark is selected.
            public TreeNode Bookmark;
        }

        /// <summary>
        /// Display conditions used to decide whether a saved scroll offset can be reused.
        /// These values are compared, never restored as viewer settings.
        /// </summary>
        private struct HistoryLayout : IEquatable<HistoryLayout>
        {
            public Size Viewport;
            public Size DisplaySize;
            public double Zoom;
            public PdfViewerZoomMode ZoomMode;
            public PdfRotation Rotation;
            public int Dpi;

            public bool Equals(HistoryLayout other)
            {
                return Viewport == other.Viewport && DisplaySize == other.DisplaySize &&
                    Zoom == other.Zoom && ZoomMode == other.ZoomMode &&
                    Rotation == other.Rotation && Dpi == other.Dpi;
            }
        }

        /// <summary>
        /// Connects the existing buttons and navigation events to view history.
        /// </summary>
        /// <remarks>
        /// Observe the before/after states while retaining PdfiumViewer's existing handlers.
        /// Register mouse filtering only during page input; remove it on exit or disposal.
        /// </remarks>
        private void InitializeViewHistory()
        {
            toolStripButtonHistoryBack.Click += (sender, args) => NavigateHistory(-1);
            toolStripButtonHistoryForward.Click += (sender, args) => NavigateHistory(1);
            toolStripButtonHistoryBack.AccessibleName = "Back in View History";
            toolStripButtonHistoryForward.AccessibleName = "Forward in View History";
            pdfViewer.LinkClick += HistoryLinkClick;
            // Locate the existing control through the WinForms control tree, without
            // depending on private PdfiumViewer fields or replacing its handlers.
            _historyBookmarks = FindBookmarkTree(pdfViewer);
            if (_historyBookmarks != null)
            {
                _historyBookmarks.BeforeSelect += HistoryBookmarkBeforeSelect;
                _historyBookmarks.AfterSelect += HistoryBookmarkAfterSelect;
                _historyBookmarks.AfterExpand += (sender, args) => UpdateHistoryButtons();
                _historyBookmarks.AfterCollapse += (sender, args) => UpdateHistoryButtons();
            }
            pdfViewer.Renderer.SizeChanged += (sender, args) => UpdateHistoryButtons();
            pdfViewer.Renderer.HandleCreated += (sender, args) => UpdateHistoryButtons();
            toolStripTextBoxPageInput.TextBox.Enter += (sender, args) =>
            {
                _discardHistoryPageInput = false;
                if (_historyInputFilter == null)
                {
                    _historyInputFilter = new HistoryInputFilter(this);
                    Application.AddMessageFilter(_historyInputFilter);
                }
            };
            Disposed += (sender, args) =>
            {
                StopHistoryInputFilter();
                _viewHistory.Clear();
                _historyDocument = null;
                _bookmarkJump = _linkJump = _lastRestoredView = null;
                _historyLinkEvent = null;
            };
            UpdateHistoryButtons();
        }

        private static TreeView FindBookmarkTree(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TreeView tree)
                    return tree;
                var nested = FindBookmarkTree(child);
                if (nested != null)
                    return nested;
            }
            return null;
        }

        /// <summary>
        /// Invalidates history and cancels pending recording/input before disposing the old Document.
        /// </summary>
        /// <remarks>
        /// Prevent coordinate capture during loading and stale link callbacks affecting a new PDF.
        /// </remarks>
        private void BeginHistoryDocumentChange()
        {
            _historyLoading = true;
            _historyDocument = null;
            _viewHistory.Clear();
            _historyIndex = -1;
            _bookmarkJump = _linkJump = _lastRestoredView = null;
            _historyLinkEvent = null;
            timerPageData.Enabled = false;
            _pageReading = -1;
            CancelHistoryPageInput();
            UpdateHistoryButtons();
        }

        private void EndHistoryDocumentChange()
        {
            _historyDocument = pdfViewer.Document;
            _historyLoading = false;
            UpdateHistoryButtons();
        }

        /// <summary>
        /// Checks that the tracked Document and viewport are ready for coordinate capture or restore.
        /// </summary>
        private bool CanUseHistory()
        {
            return !IsDisposed && !Disposing && !_historyLoading &&
                _historyDocument != null && ReferenceEquals(_historyDocument, pdfViewer.Document) &&
                _historyDocument.PageCount > 0 && pdfViewer.Renderer.IsHandleCreated &&
                pdfViewer.Renderer.ClientSize.Width > 0 && pdfViewer.Renderer.ClientSize.Height > 0 &&
                FindForm()?.WindowState != FormWindowState.Minimized &&
                !pdfViewer.Renderer.GetOuterBounds(0).IsEmpty;
        }

        private HistoryLayout GetHistoryLayout()
        {
            var renderer = pdfViewer.Renderer;
            return new HistoryLayout
            {
                Viewport = renderer.ClientSize,
                DisplaySize = renderer.DisplayRectangle.Size,
                Zoom = renderer.Zoom,
                ZoomMode = renderer.ZoomMode,
                Rotation = renderer.Rotation,
                Dpi = renderer.DeviceDpi
            };
        }

        /// <summary>
        /// Captures position, display conditions and bookmark selection; returns null if unavailable.
        /// </summary>
        /// <remarks>
        /// Anchor at the viewport center, or the nearest visible page point when it lies in a gap.
        /// Store the anchor's actual projected position as a ratio to account for conversion rounding.
        /// Also retain the raw scroll offset to avoid conversion drift when the layout is unchanged.
        /// </remarks>
        private HistoryView CaptureHistoryView()
        {
            if (!CanUseHistory())
                return null;
            var renderer = pdfViewer.Renderer;
            var layout = GetHistoryLayout();
            var center = new Point(layout.Viewport.Width / 2, layout.Viewport.Height / 2);
            var anchor = renderer.PointToPdf(center);
            if (!anchor.IsValid)
            {
                // Only inspect visible pages. The viewport center may lie in a page
                // gap or beside a narrow page in a document with mixed page sizes.
                double nearestDistance = double.MaxValue;
                var viewport = new Rectangle(Point.Empty, layout.Viewport);
                for (int page = 0; page < _historyDocument.PageCount; page++)
                {
                    var outer = renderer.GetOuterBounds(page);
                    int top = outer.Top + renderer.DisplayRectangle.Top;
                    if (top >= viewport.Bottom || top + outer.Height <= 0)
                        continue;
                    var pageSize = Size.Ceiling(_historyDocument.PageSizes[page]);
                    var pdfBounds = _historyDocument.RectangleToPdf(page,
                        new Rectangle(Point.Empty, pageSize));
                    var visible = Rectangle.Intersect(viewport,
                        renderer.BoundsFromPdf(new PdfRectangle(page, pdfBounds)));
                    if (visible.Width <= 0 || visible.Height <= 0)
                        continue;
                    var candidate = new Point(Math.Max(visible.Left, Math.Min(center.X, visible.Right - 1)),
                        Math.Max(visible.Top, Math.Min(center.Y, visible.Bottom - 1)));
                    var pdfPoint = renderer.PointToPdf(candidate);
                    double distance = (double)(candidate.X - center.X) * (candidate.X - center.X) +
                        (double)(candidate.Y - center.Y) * (candidate.Y - center.Y);
                    if (pdfPoint.IsValid && distance < nearestDistance)
                    {
                        anchor = pdfPoint;
                        nearestDistance = distance;
                    }
                }
            }
            if (!anchor.IsValid)
                return null;
            // Record the actual round-trip point, so coordinate quantization does
            // not shift the viewport when its layout changes.
            var anchorClient = renderer.PointFromPdf(anchor);
            return new HistoryView
            {
                Document = _historyDocument,
                Anchor = anchor,
                AnchorPosition = new PointF((float)anchorClient.X / layout.Viewport.Width,
                    (float)anchorClient.Y / layout.Viewport.Height),
                Offset = renderer.DisplayRectangle.Location,
                Layout = layout,
                Bookmark = _historyBookmarks?.SelectedNode
            };
        }

        /// <summary>
        /// Identifies recoverable viewer/state errors at history coordinate boundaries.
        /// Unexpected programming errors and fatal native errors are not suppressed.
        /// </summary>
        private static bool IsHistoryCoordinateFailure(Exception error)
        {
            return error is ArgumentException || error is InvalidOperationException || error is PdfException;
        }

        /// <summary>
        /// Attempts to capture a usable view without leaking recoverable coordinate errors.
        /// </summary>
        /// <remarks>
        /// Callers decide whether to skip recording, disable buttons or report an explicit
        /// navigation failure. This helper never changes history or displays a dialog.
        /// </remarks>
        private bool TryCaptureHistoryView(out HistoryView view)
        {
            view = null;
            try
            {
                view = CaptureHistoryView();
                return view != null;
            }
            catch (Exception error) when (IsHistoryCoordinateFailure(error))
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates the scroll offset that restores a saved view under current display conditions.
        /// </summary>
        /// <remarks>
        /// Reuse Offset when the layouts match. Otherwise move the PDF anchor from its current
        /// screen position to the saved relative viewport position, and clamp to the scroll range.
        /// Keep the current zoom, rotation and fit settings.
        /// </remarks>
        private Point GetHistoryOffset(HistoryView view, HistoryLayout layout)
        {
            if (view.Layout.Equals(layout))
                return view.Offset;
            var renderer = pdfViewer.Renderer;
            var point = renderer.PointFromPdf(view.Anchor);
            var current = renderer.DisplayRectangle.Location;
            int x = current.X + (int)Math.Round(view.AnchorPosition.X * layout.Viewport.Width) - point.X;
            int y = current.Y + (int)Math.Round(view.AnchorPosition.Y * layout.Viewport.Height) - point.Y;
            return new Point(Math.Max(Math.Min(0, layout.Viewport.Width - layout.DisplaySize.Width), Math.Min(0, x)),
                Math.Max(Math.Min(0, layout.Viewport.Height - layout.DisplaySize.Height), Math.Min(0, y)));
        }

        private static bool NearHistoryOffset(Point first, Point second)
        {
            return Math.Abs((long)first.X - second.X) <= 1 && Math.Abs((long)first.Y - second.Y) <= 1;
        }

        /// <summary>
        /// Checks whether two views have the same Document, bookmark and effective current position.
        /// </summary>
        /// <remarks>
        /// Allow one pixel of rounding error on each axis. Different bookmarks remain distinct
        /// even at the same position, since they can define different comparison scopes.
        /// </remarks>
        private bool SameHistoryView(HistoryView first, HistoryView current)
        {
            return first != null && current != null && ReferenceEquals(first.Document, current.Document) &&
                ReferenceEquals(first.Bookmark, current.Bookmark) &&
                NearHistoryOffset(GetHistoryOffset(first, current.Layout), current.Offset);
        }

        /// <summary>
        /// Finds a distinct view in the given direction (-1: back, 1: forward), or returns -1.
        /// </summary>
        /// <remarks>
        /// Skip entries that currently project to the same view, but retain their PDF coordinates.
        /// Do not delete them here: they may become distinct again after zooming in.
        /// </remarks>
        private int FindHistoryTarget(int direction, HistoryView current)
        {
            if (current == null)
                return -1;
            for (int index = _historyIndex + direction; index >= 0 && index < _viewHistory.Count; index += direction)
            {
                var view = _viewHistory[index];
                if (ReferenceEquals(view.Document, _historyDocument) && !SameHistoryView(view, current))
                    return index;
            }
            return -1;
        }

        /// <summary>
        /// Updates buttons from available distinct destinations, without adding or consuming history.
        /// </summary>
        /// <remarks>
        /// Both capture and destination projection can fail. Disable both buttons without a dialog
        /// and retry on the next display update, retaining the entries and current history cursor.
        /// </remarks>
        private void UpdateHistoryButtons()
        {
            if (_restoringHistory || _bookmarkJump != null)
                return;
            try
            {
                if (_historyIndex < 0 || !TryCaptureHistoryView(out var current))
                {
                    DisableHistoryButtons();
                    return;
                }
                bool canGoBack = FindHistoryTarget(-1, current) >= 0;
                bool canGoForward = FindHistoryTarget(1, current) >= 0;
                toolStripButtonHistoryBack.Enabled = canGoBack;
                toolStripButtonHistoryForward.Enabled = canGoForward;
            }
            catch (Exception error) when (IsHistoryCoordinateFailure(error))
            {
                DisableHistoryButtons();
            }
        }

        private void DisableHistoryButtons()
        {
            toolStripButtonHistoryBack.Enabled = false;
            toolStripButtonHistoryForward.Enabled = false;
        }

        /// <summary>
        /// Updates the departing entry so back/forward can return to the latest reading position.
        /// </summary>
        /// <remarks>
        /// Retain the original PDF anchor if layout, position and bookmark have not changed since
        /// the last restore. Rounding or scroll-limit clamping alone must not overwrite that anchor.
        /// </remarks>
        private void SaveHistoryDeparture(HistoryView current)
        {
            // Preserve the original PDF anchor after a restore in a different
            // layout, unless the user has actually moved or selected a bookmark.
            if (_historyIndex >= 0 && !(_lastRestoredView != null &&
                _lastRestoredView.Layout.Equals(current.Layout) && SameHistoryView(_lastRestoredView, current)))
                _viewHistory[_historyIndex] = current;
            _lastRestoredView = null;
        }

        /// <summary>
        /// Records a completed jump only when its position or bookmark selection has changed.
        /// </summary>
        /// <remarks>
        /// Seed the list with both views on the first jump. Later jumps update the departing entry,
        /// discard forward history and append the destination. A no-op retains forward history.
        /// Keep at most 101 entries including the current view, dropping the oldest excess entries.
        /// Coordinate capture/comparison failures skip recording without clearing valid entries.
        /// </remarks>
        private void RecordHistoryJump(HistoryView before)
        {
            if (before == null || !ReferenceEquals(before.Document, _historyDocument))
                return;
            try
            {
                if (!TryCaptureHistoryView(out var after))
                {
                    DisableHistoryButtons();
                    return;
                }
                if (SameHistoryView(before, after))
                {
                    UpdateHistoryButtons();
                    return;
                }
                if (_historyIndex < 0)
                {
                    _viewHistory.Add(before);
                    _historyIndex = 0;
                }
                else
                    SaveHistoryDeparture(before);
                if (_historyIndex + 1 < _viewHistory.Count)
                    _viewHistory.RemoveRange(_historyIndex + 1, _viewHistory.Count - _historyIndex - 1);
                _viewHistory.Add(after);
                _historyIndex++;
                if (_viewHistory.Count > ViewHistoryLimit + 1)
                {
                    int excess = _viewHistory.Count - ViewHistoryLimit - 1;
                    _viewHistory.RemoveRange(0, excess);
                    _historyIndex -= excess;
                }
                _lastRestoredView = null;
                UpdateHistoryButtons();
            }
            catch (Exception error) when (IsHistoryCoordinateFailure(error))
            {
                DisableHistoryButtons();
            }
        }

        /// <summary>
        /// Wraps synchronous navigation, such as page input, with before/after history capture.
        /// </summary>
        /// <remarks>
        /// Complete any pending link recording first, so history follows the order of user actions.
        /// A failed capture must not block the existing navigation or catch its own exceptions.
        /// </remarks>
        private void NavigateWithHistory(Action navigate)
        {
            CompleteHistoryLinkJump();
            bool captured = TryCaptureHistoryView(out var before);
            navigate();
            if (captured)
                RecordHistoryJump(before);
            else
                DisableHistoryButtons();
        }

        /// <summary>
        /// Captures the current view before the existing internal-link navigation runs.
        /// </summary>
        /// <remarks>
        /// LinkClick precedes the default navigation, so defer recording with BeginInvoke on the
        /// same UI thread. Leave link execution and Handled semantics to the existing handlers.
        /// Check the pending reference to ignore callbacks superseded by a reload or later action.
        /// </remarks>
        private void HistoryLinkClick(object sender, LinkClickEventArgs e)
        {
            if (_restoringHistory || e.Handled || !e.Link.TargetPage.HasValue)
                return;
            CompleteHistoryLinkJump();
            if (!TryCaptureHistoryView(out _linkJump))
            {
                DisableHistoryButtons();
                return;
            }
            _historyLinkEvent = e;
            var pending = _linkJump;
            // Observe the existing default link action; URI launching and Handled
            // semantics remain owned by PdfiumViewer. Ignore stale callbacks.
            BeginInvoke((Action)(() =>
            {
                if (ReferenceEquals(_linkJump, pending) && !IsDisposed)
                    CompleteHistoryLinkJump();
            }));
        }

        /// <summary>
        /// Consumes a pending link capture once and records it unless Handled has cancelled it.
        /// </summary>
        private void CompleteHistoryLinkJump()
        {
            var before = _linkJump;
            bool cancelled = _historyLinkEvent?.Handled == true;
            _linkJump = null;
            _historyLinkEvent = null;
            if (!cancelled)
                RecordHistoryJump(before);
        }

        /// <summary>
        /// Captures the view before a user bookmark selection, excluding automatic selection/restore.
        /// </summary>
        /// <remarks>
        /// Accept only ByMouse/ByKeyboard; page-following selection must not append history.
        /// Defer cleanup if a later handler cancels selection and AfterSelect never arrives.
        /// </remarks>
        private void HistoryBookmarkBeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (_restoringHistory || e.Cancel ||
                (e.Action != TreeViewAction.ByMouse && e.Action != TreeViewAction.ByKeyboard))
                return;
            CompleteHistoryLinkJump();
            if (!TryCaptureHistoryView(out _bookmarkJump))
            {
                DisableHistoryButtons();
                return;
            }
            var pending = _bookmarkJump;
            if (pending != null)
                BeginInvoke((Action)(() =>
                {
                    // A later BeforeSelect subscriber may cancel the selection.
                    if (ReferenceEquals(_bookmarkJump, pending))
                    {
                        _bookmarkJump = null;
                        UpdateHistoryButtons();
                    }
                }));
        }

        /// <summary>
        /// Records the view after bookmark navigation while retaining the user's selected node.
        /// </summary>
        /// <remarks>
        /// Synchronize PdfiumViewer's page-selection cache, then reapply the selected node.
        /// Automatic selection must not substitute a parent/child on the same page and change
        /// the comparison scope. Reapply the scroll offset to undo navigation caused by this sync.
        /// </remarks>
        private void HistoryBookmarkAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_restoringHistory)
                return;
            if (_bookmarkJump == null ||
                (e.Action != TreeViewAction.ByMouse && e.Action != TreeViewAction.ByKeyboard))
            {
                UpdateHistoryButtons();
                return;
            }
            var before = _bookmarkJump;
            _bookmarkJump = null;
            // Update PdfiumViewer's page-selection cache, retaining the user's
            // selected parent/child bookmark even when both begin on one page.
            _restoringHistory = true;
            try
            {
                var offset = pdfViewer.Renderer.DisplayRectangle.Location;
                pdfViewer.SelectBookmarkForPage(pdfViewer.Renderer.Page);
                _historyBookmarks.SelectedNode = e.Node;
                pdfViewer.Renderer.SetDisplayRectLocation(offset);
            }
            catch (Exception error) when (IsHistoryCoordinateFailure(error))
            {
                DisableHistoryButtons();
                return;
            }
            finally { _restoringHistory = false; }
            RecordHistoryJump(before);
        }

        /// <summary>
        /// Restores position and bookmark selection; the caller must set _restoringHistory first.
        /// </summary>
        /// <remarks>
        /// Position the viewport first, synchronize the page-selection cache, then select the saved
        /// bookmark. Selection invokes the existing page jump, so reapply the desired offset last.
        /// This ordering preserves both the within-page position and the parent/child selection.
        /// </remarks>
        private void ApplyHistoryView(HistoryView view)
        {
            var renderer = pdfViewer.Renderer;
            var offset = GetHistoryOffset(view, GetHistoryLayout());
            renderer.SetDisplayRectLocation(offset);
            pdfViewer.SelectBookmarkForPage(renderer.Page);
            if (_historyBookmarks != null)
                _historyBookmarks.SelectedNode = view.Bookmark;
            // Selecting a bookmark invokes the existing page jump. Restore the
            // precise viewport afterwards, with automatic selection suppressed.
            renderer.SetDisplayRectLocation(offset);
            toolStripLabelPage.Text = (renderer.Page + 1).ToString();
        }

        /// <summary>
        /// Runs explicit back/forward navigation and reports a failure once to the user.
        /// </summary>
        private void NavigateHistory(int direction)
        {
            if (!TryNavigateHistory(direction))
                MessageBox.Show(this, "Unable to restore the PDF view.", "PDFComp",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Attempts back/forward navigation, committing the history cursor only after a successful restore.
        /// </summary>
        /// <remarks>
        /// Discard unconfirmed page input before capturing the departure view. Suppress recording
        /// and automatic bookmark selection during restore. On failure, keep the cursor unchanged
        /// and attempt to recover the original view. Traversal does not append a new jump entry.
        /// Protect capture and target calculation as well as restore. Cleanup always clears the
        /// restore flag; a failed operation disables buttons without performing more coordinate work.
        /// Return false for a recoverable failure, or true for success/a harmless no-op.
        /// </remarks>
        private bool TryNavigateHistory(int direction)
        {
            if (_restoringHistory)
                return true;
            HistoryView before = null;
            bool restoreAttempted = false;
            bool failed = false;
            try
            {
                CompleteHistoryLinkJump();
                CancelHistoryPageInput();
                if (!TryCaptureHistoryView(out before))
                {
                    failed = true;
                    return false;
                }
                int target = FindHistoryTarget(direction, before);
                if (target < 0)
                    return true;
                _restoringHistory = true;
                restoreAttempted = true;
                ApplyHistoryView(_viewHistory[target]);
                if (!TryCaptureHistoryView(out var restored))
                    throw new InvalidOperationException("The PDF view is not ready.");
                SaveHistoryDeparture(before);
                _historyIndex = target;
                _lastRestoredView = restored;
                return true;
            }
            catch (Exception error) when (IsHistoryCoordinateFailure(error))
            {
                failed = true;
                if (restoreAttempted && before != null)
                {
                    try
                    {
                        if (ReferenceEquals(before.Document, _historyDocument) &&
                            ReferenceEquals(_historyDocument, pdfViewer.Document))
                            ApplyHistoryView(before);
                    }
                    catch (Exception rollback) when (IsHistoryCoordinateFailure(rollback))
                    {
                        // Rollback is best effort; do not claim that the view was recovered.
                        // Retain history even if the document cannot restore either view.
                    }
                }
                return false;
            }
            finally
            {
                _restoringHistory = false;
                if (failed)
                    DisableHistoryButtons();
                else
                    UpdateHistoryButtons();
            }
        }

        /// <summary>
        /// Closes page input and removes mouse filtering without applying the unconfirmed number.
        /// </summary>
        /// <remarks>
        /// Set the discard flag first because hiding the input can itself raise Leave.
        /// </remarks>
        private void CancelHistoryPageInput()
        {
            _discardHistoryPageInput = true;
            toolStripTextBoxPageInput.Visible = false;
            toolStripLabelPage.Visible = true;
            StopHistoryInputFilter();
            _discardHistoryPageInput = false;
        }

        private void StopHistoryInputFilter()
        {
            if (_historyInputFilter == null)
                return;
            Application.RemoveMessageFilter(_historyInputFilter);
            _historyInputFilter = null;
        }

        /// <summary>
        /// Detects history-button presses before focus moves, only while page input is active.
        /// </summary>
        /// <remarks>
        /// Waiting for Click is too late: Leave may already commit the page number. Set the discard
        /// flag before message dispatch. Consume disabled-button presses to retain the input state.
        /// </remarks>
        private sealed class HistoryInputFilter : IMessageFilter
        {
            private readonly PdfPanel _panel;
            public HistoryInputFilter(PdfPanel panel) { _panel = panel; }

            /// <summary>
            /// Marks input for discard on enabled history buttons; consumes presses on disabled ones.
            /// </summary>
            public bool PreFilterMessage(ref Message message)
            {
                const int LeftButtonDown = 0x0201;
                if (message.Msg != LeftButtonDown ||
                    !(Control.FromHandle(message.HWnd) is ToolStrip strip))
                    return false;
                long coordinates = message.LParam.ToInt64();
                var item = strip.GetItemAt(new Point((short)(coordinates & 0xffff),
                    (short)((coordinates >> 16) & 0xffff)));
                if (item != _panel.toolStripButtonHistoryBack && item != _panel.toolStripButtonHistoryForward)
                    return false;
                if (!item.Enabled)
                    return true;
                // This runs before WM_LBUTTONDOWN moves focus and raises Leave.
                _panel._discardHistoryPageInput = true;
                return false;
            }
        }
    }
}
