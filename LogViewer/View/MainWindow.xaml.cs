using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Microsoft.Windows.Controls;
using LogViewer.ViewModel;
using LogViewer.MVVMHelper;
using System.Windows.Threading;
using Path = System.IO.Path;

namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            var mainVM = new MainViewModel();
            DataContext = mainVM;
            mainVM.Init();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void OnDatagridRowMouseDoubleClick(object sender, EventArgs args)
        {
            SetDatagridDoubleClickedRow(sender);
        }

        public void OnCCSPatternDatagridRowMouseDoubleClick(object sender, EventArgs args)
        {
            SetDatagridDoubleClickedRow(sender);
            Dispatcher.BeginInvoke(new Action(() =>
            DataLogCCSDisplay.Items.Refresh()), DispatcherPriority.Loaded);
        }

        public void OnCXDIPatternDatagridRowMouseDoubleClick(object sender, EventArgs args)
        {
            SetDatagridDoubleClickedRow(sender);
            Dispatcher.BeginInvoke(new Action(() =>
            DataLogCXDI.Items.Refresh()), DispatcherPriority.Loaded);
        }

        public void OnDatagridRowMouseDown(Object sender,RoutedEventArgs e)
        {
            var row = sender as DataGridRow;
            DependencyObject tempUIElement = row;
            while (true)
            {
                if (tempUIElement == null)
                    return;
                tempUIElement = VisualTreeHelper.GetParent(tempUIElement);
                if (tempUIElement is DataGrid)
                {
                    break;
                }
            }
            DatagridHelper.SetClickedRow(tempUIElement, row.DataContext);
        }

        public void OnDatagridRecordRowPressEnter(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Enter)
            {
                SetDatagridDoubleClickedRow(sender);
                args.Handled = true;
            }
        }

        private void SetDatagridDoubleClickedRow(object rowObj)
        {
            var row = rowObj as DataGridRow;
            DependencyObject tempUIElement = row;
            while (true)
            {
                if (tempUIElement == null)
                    return;
                tempUIElement = VisualTreeHelper.GetParent(tempUIElement);
                if (tempUIElement is DataGrid)
                {
                    break;
                }
            }
            DatagridHelper.SetDoubleClickedRow(tempUIElement, row.DataContext);
        }

        public void OnDragOverCCS(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null || files.Length <= 0) return;
            var currentLogFileName = Path.GetFileName(files[0]);
            var fileExtension = Path.GetExtension(files[0]);
            if (fileExtension == null ||
                (!fileExtension.Equals(Properties.Resources.TXT) && !fileExtension.Equals(Properties.Resources.XML)))
                return;
            e.Effects = DragDropEffects.All;
            e.Handled = true;
        }

        public void OnDragOverCXDI(object sender, DragEventArgs e)
        {
            //var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //if (files == null || files.Length <= 0) return;
            //var currentLogFileName = Path.GetFileName(files[0]);
            //var fileExtension = Path.GetExtension(files[0]);
            //if (fileExtension == null ||
            //    (!fileExtension.Equals(Properties.Resources.LOG) && !fileExtension.Equals(Properties.Resources.XML)))
            //    return;
            e.Effects = DragDropEffects.All;
            e.Handled = true;
        }

        private void tbtnCXDINarrowFilterNonColor_Checked(object sender, RoutedEventArgs e)
        {
            tbtnCXDINarrowFilterColor.IsChecked = false;
        }

        private void tbtnCXDINarrowFilterColor_Checked(object sender, RoutedEventArgs e)
        {
            tbtnCXDINarrowFilterNonColor.IsChecked = false;
        }

        private void tbtnCCSNarrowFilterNonColor_Checked(object sender, RoutedEventArgs e)
        {
            tbtnCCSNarrowFilterColor.IsChecked = false;
        }

        private void tbtnCCSNarrowFilterColor_Checked(object sender, RoutedEventArgs e)
        {
            tbtnCCSNarrowFilterNonColor.IsChecked = false;
        }

        private void RefreshCCSLogsList(object sender, RoutedEventArgs e)
        {
            DataLogCCSDisplay.Items.Refresh();
        }
        private void RefreshCXDILogsList(object sender, RoutedEventArgs e)
        {
            DataLogCXDI.Items.Refresh();
        }
        private void RefreshAllLogsList(object sender, RoutedEventArgs e)
        {
            DataLogCCSDisplay.Items.Refresh();
            DataLogCXDI.Items.Refresh();
        }

        private void DataLogsDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                var datagrid = sender as DataGrid;
                if (datagrid != null)
                {
                    var selectedIndex = datagrid.SelectedIndex;
                    if (e.Key == Key.Up)
                    {
                        if (selectedIndex > 0)
                        {
                            datagrid.UnselectAll();
                            datagrid.SelectedIndex = selectedIndex - 1;
                            //DatagridHelper.SetRecordToFollow(datagrid, datagrid.SelectedValue);
                            datagrid.CurrentCell = new DataGridCellInfo(datagrid.Items[datagrid.SelectedIndex], datagrid.Columns[datagrid.CurrentColumn.DisplayIndex]);
                            //datagrid.ScrollIntoView(datagrid.SelectedIndex, datagrid.CurrentColumn);
                            DatagridHelper.SetClickedRow(datagrid, datagrid.SelectedValue);
                        }
                    }
                    else if (e.Key == Key.Down)
                    {
                        if (selectedIndex < datagrid.Items.Count - 1)
                        {
                            datagrid.UnselectAll();
                            datagrid.SelectedIndex = selectedIndex + 1;
                            //DatagridHelper.SetRecordToFollow(datagrid, datagrid.SelectedValue);
                            datagrid.CurrentCell = new DataGridCellInfo(datagrid.Items[datagrid.SelectedIndex], datagrid.Columns[datagrid.CurrentColumn.DisplayIndex]);
                            //datagrid.ScrollIntoView(datagrid.SelectedIndex, datagrid.CurrentColumn);
                            DatagridHelper.SetClickedRow(datagrid, datagrid.SelectedValue);
                        }
                    }
                }
                e.Handled = true;
            }
            else
            {
                if (e.Key == Key.Delete)
                {
                    e.Handled = true;
                }
            }
        }

        private void DataLogsDisplay_KeyDelete(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void DataLogCCSDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGrid dataGrid = (DataGrid)sender;
            //if (dataGrid.SelectedValue != null)
            //    dataGrid.ScrollToCenterOfView(dataGrid.SelectedValue);
            //if (DataLogCCSDisplay.SelectedItems.Count > 2000)
            //{
            //    DataLogCCSDisplay.SelectedItems.Clear();
            //    DataLogCCSDisplay.Items.Refresh();
            //}
            //int index = dataGrid.SelectedIndex;
            //var a = "a";
            //a = a + "a";
            
        }

        private void DataLogCCSDisplay_Loaded(object sender, RoutedEventArgs e)
        {
            var dataGrid = (DataGrid)sender;
            var border = (Border)VisualTreeHelper.GetChild(dataGrid, 0);
            var scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
            var grid = (Grid)VisualTreeHelper.GetChild(scrollViewer, 0);
            var button = (Button)VisualTreeHelper.GetChild(grid, 0);
            button.IsEnabled = false;
        }
    }
}
