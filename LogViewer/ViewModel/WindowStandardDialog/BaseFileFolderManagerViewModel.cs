using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Base class provides common methods for File folder manager
    /// </summary>
    abstract class BaseFileFolderManagerViewModel : BaseWindowStandardDialogViewModel
    {
        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="ownerWindowVM">Parent window</param>
        /// <returns>OK or Cancel</returns>
        public abstract DialogResult ShowDialog(object ownerWindowVM);
    }
}
