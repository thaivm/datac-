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

namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for ExportFileNameDialogView.xaml
    /// </summary>
    public partial class ExportFileNameDialogView : Window
    {
        public ExportFileNameDialogView()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileNameTxt.Focus();
            FileNameTxt.SelectAll();
        }
   
    }
}
