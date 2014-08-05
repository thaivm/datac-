using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service;
using System.Windows.Forms;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Base class provides common method for open new dialog 
    /// </summary>
    public abstract class BaseWindowStandardDialogViewModel
    {
        /// <summary>
        /// Dialog service
        /// </summary>
        protected static IDialogService _dialogService;
        /// <summary>
        /// Default Constructor
        /// </summary>
        static BaseWindowStandardDialogViewModel()
        {
            _dialogService = ServiceLocator.Resolve<IDialogService>();
        }
    }
}
