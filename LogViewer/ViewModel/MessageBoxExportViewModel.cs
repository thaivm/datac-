using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Windows.Controls;
namespace LogViewer.ViewModel
{
    /// <summary>
    /// ViewModel of message box export to image, CSV, memo log
    /// </summary>
    class MessageBoxExportViewModel : BaseWindowViewModel
    {
        /// <summary>
        /// Action of event when click button OK
        /// </summary>
        public event Action OnOkEvent;
        /// <summary>
        /// Initializes a new instance of the MessageBoxExportViewModel class.
        /// </summary>
        public MessageBoxExportViewModel()
        {
        }
        /// <summary>
        /// Get and set Directory
        /// </summary>
        public string Directory { get; set; }
        /// <summary>
        /// Get and set FileName
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Get and set Extension
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Get and set Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Get or set Command of button OK.
        /// </summary>
        protected DelegateCommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                if (_okCommand == null)
                {
                    _okCommand = new DelegateCommand(OkCommandCL);
                }
                return _okCommand;
            }
        }
        /// <summary>
        /// unction callback when click button OK
        /// </summary>
        protected virtual void OkCommandCL()
        {
            if (OnOkEvent != null)
            {
                OnOkEvent();
            }
        }
    }
}
