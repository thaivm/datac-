using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
namespace LogViewer.Util
{
    public class FileUtil
    {
        public static String OpenFile()
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ConfigValue.CsvExtension ;
            //hard code.
            dlg.Filter = "Text documents (.csv)|*.csv";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                return filename;
            }
            return null;
        }
    }
}
