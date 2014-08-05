using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using System.Windows.Forms;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for open file dialog
    /// </summary>
    class OpenFileDialogViewModel : BaseFileFolderManagerViewModel, IOpenFileDialog
    {

        #region IOpenFileDialog Members
        /// <summary>
        /// Add extension
        /// </summary>
        public bool AddExtension { get; set; }
        /// <summary>
        /// Check file exists
        /// </summary>
        public bool CheckFileExists { get; set; }
        /// <summary>
        /// Check path exists
        /// </summary>
        public bool CheckPathExists { get; set; }
        /// <summary>
        /// Default extension
        /// </summary>
        public string DefaultExt { get; set; }
        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Array file name
        /// </summary>
        public string[] FileNames { get; set; }
        /// <summary>
        /// Filter
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// InitialDirectory
        /// </summary>
        public string InitialDirectory { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Multi select
        /// </summary>
        public bool Multiselect { get; set; }

        #endregion
        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="ownerWindowVM">Parent window</param>
        /// <returns>OK or Cancel</returns>
        public override DialogResult ShowDialog(object ownerWindowVM)
        {
            return _dialogService.ShowOpenFileDialog(ownerWindowVM, this);
        }
    }
}
