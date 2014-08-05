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

namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for RegisterPattern.xaml
    /// </summary>
    public partial class PatternManagerView : Window
    {
        public PatternManagerView()
        {
            InitializeComponent();
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
