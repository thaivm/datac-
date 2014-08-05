using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Service.FrameworkDialogs.FolderBrowse;
using System.Windows.Forms;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for Open Folder Browser Dialog
    /// </summary>
    class FolderBrowserDialogViewModel : BaseFileFolderManagerViewModel, IFolderBrowserDialog
    {

        #region IFolderBrowserDialog Members
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Selected path
        /// </summary>
        public string SelectedPath { get; set; }
        /// <summary>
        /// Show new folder button
        /// </summary>
        public bool ShowNewFolderButton { get; set; }

        #endregion

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="ownerWindowVM">Parent window</param>
        /// <returns>OK or Cancel</returns>
        public override DialogResult ShowDialog(object ownerWindowVM)
        {
            return _dialogService.ShowFolderBrowserDialog(ownerWindowVM, this);
        }
    }
}
