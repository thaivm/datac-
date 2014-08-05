using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for save file dialog
    /// </summary>
    public class SaveFileDialogViewModel : BaseWindowStandardDialogViewModel, ISaveFileDialog
    {
        /// <summary>
        /// File name 
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Default extension
        /// </summary>
        public string DefaultExt { get; set; }
        /// <summary>
        /// Filter 
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="ownerWindowVM">Parent window</param>
        /// <returns>OK or Cancel</returns>
        public virtual bool? ShowDialog(object ownerWindowVM)
        {
            return _dialogService.ShowSaveFileDialog(ownerWindowVM, this);
        }
    }
}
