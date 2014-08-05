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
using System.Windows.Shapes;
using LogViewer.ViewModel;
using Microsoft.Windows.Controls;
using LogViewer.MVVMHelper;

namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchKeywordView : Window
    {
        public SearchKeywordView()
        {
            InitializeComponent();
        }
        public void OnDatagridRowMouseDoubleClick(object sender, EventArgs args)
        {
            SetDatagridDoubleClickedRow(sender);
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

        private void DataGrid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }
    }
}
