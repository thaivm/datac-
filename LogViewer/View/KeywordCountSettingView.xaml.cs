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
    /// Interaction logic for RegisterSearchWindow.xaml
    /// </summary>
    public partial class KeywordCountSettingView : Window
    {
        public KeywordCountSettingView()
        {
            InitializeComponent();
        }
        public void OnDatagridRowMouseDoubleClick(object sender, EventArgs args)
        {
            var row = sender as DataGridRow;
            DatagridHelper.SetDoubleClickedRow(dtgEditKeyword, row.DataContext);
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
