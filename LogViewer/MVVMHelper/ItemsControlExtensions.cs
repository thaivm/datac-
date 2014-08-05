using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using Microsoft.Windows.Controls;
using System.Windows.Threading;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class handle event scroll focus to center of grid.
    /// </summary>
    public static class ItemsControlExtensions
    {
        /// <summary>
        /// Scroll to center of data grid
        /// </summary>
        /// <param name="itemsControl">Source collection in data grid</param>
        /// <param name="item">Item to scroll</param>
        public static void ScrollToCenterOfView(this ItemsControl itemsControl, object item)
        {
            // Scroll immediately if possible
            if (!itemsControl.TryScrollToCenterOfView(item))
            {
                // Otherwise wait until everything is loaded, then scroll
                if (itemsControl is DataGrid)
                {
                    try
                    {
                        ((DataGrid)itemsControl).ScrollIntoView(item);
                    }
                    catch
                    {

                    }
                }
                itemsControl.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
                {
                    itemsControl.TryScrollToCenterOfView(item);
                }));
            }
        }
        /// <summary>
        /// Try scroll to center of data grid
        /// </summary>
        /// <param name="itemsControl">Source collection in data grid</param>
        /// <param name="item">Item to scroll</param>
        /// <returns>Return true if can, return false if not</returns>
        private static bool TryScrollToCenterOfView(this ItemsControl itemsControl, object item)
        {
            // Find the container
            var container = itemsControl.ItemContainerGenerator.ContainerFromItem(item) as UIElement;
            if (container == null) return false;

            // Find the ScrollContentPresenter
            ScrollContentPresenter presenter = null;
            for (Visual vis = container; vis != null && vis != itemsControl; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if ((presenter = vis as ScrollContentPresenter) != null)
                    break;
            if (presenter == null) return false;

            // Find the IScrollInfo
            var scrollInfo =
                !presenter.CanContentScroll ? presenter :
                presenter.Content as IScrollInfo ??
                FirstVisualChild(presenter.Content as ItemsPresenter) as IScrollInfo ??
                presenter;

            // Compute the center point of the container relative to the scrollInfo
            Size size = container.RenderSize;
            Point center = container.TransformToAncestor((Visual)scrollInfo).Transform(new Point(size.Width / 2, size.Height / 2));
            center.Y += scrollInfo.VerticalOffset;
            //center.X += scrollInfo.HorizontalOffset;

            // Adjust for logical scrolling
            if (scrollInfo is StackPanel || scrollInfo is VirtualizingStackPanel)
            {
                double logicalCenter = itemsControl.ItemContainerGenerator.IndexFromContainer(container) + 0.5;
                Orientation orientation = scrollInfo is StackPanel ? ((StackPanel)scrollInfo).Orientation : ((VirtualizingStackPanel)scrollInfo).Orientation;
                if (orientation == Orientation.Vertical)
                //    center.X = logicalCenter;
                //else
                    center.Y = logicalCenter;
            }

            // Scroll the center of the container to the center of the view port
            if (scrollInfo.CanVerticallyScroll) scrollInfo.SetVerticalOffset(CenteringOffset(center.Y, scrollInfo.ViewportHeight, scrollInfo.ExtentHeight));
            //if (scrollInfo.CanHorizontallyScroll) scrollInfo.SetHorizontalOffset(CenteringOffset(center.X, scrollInfo.ViewportWidth, scrollInfo.ExtentWidth));
            return true;
        }
        /// <summary>
        /// Get center position of grid
        /// </summary>
        /// <param name="center"></param>
        /// <param name="viewport"></param>
        /// <param name="extent"></param>
        /// <returns>bool value</returns>
        private static double CenteringOffset(double center, double viewport, double extent)
        {
            return Math.Min(extent - viewport, Math.Max(0, center - viewport / 2));
        }
        /// <summary>
        /// Find visual child of Parent object
        /// </summary>
        /// <param name="visual">Parent object</param>
        /// <returns>Dependency object</returns>
        private static DependencyObject FirstVisualChild(Visual visual)
        {
            if (visual == null) return null;
            if (VisualTreeHelper.GetChildrenCount(visual) == 0) return null;
            return VisualTreeHelper.GetChild(visual, 0);
        }
    }
}
