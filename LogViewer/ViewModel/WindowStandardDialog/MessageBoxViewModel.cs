using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using LogViewer.Util;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for message box
    /// </summary>
    class MessageBoxViewModel : BaseWindowStandardDialogViewModel
    {
        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Capitan
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// Button value
        /// </summary>
        public MessageBoxButton ButtonValue { get; set; }
        /// <summary>
        /// Image value
        /// </summary>
        public MessageBoxImage ImageValue { get; set; }
        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="ownerWindowVM">Parent window</param>
        /// <returns>Ok or Cancel</returns>
        public virtual MessageBoxResult ShowDialog(object ownerWindowVM)
        {
            return _dialogService.ShowMessageBox(ownerWindowVM, Text, Caption, ButtonValue, ImageValue);
        }
        /// <summary>
        /// Show dialog for delete message
        /// </summary>
        /// <param name="ownerWindowVM">Parent window</param>
        /// <returns>OK or Cancel</returns>
        public virtual MessageBoxResult ShowDialogDelete(object ownerWindowVM)
        {
            return (MessageBoxResult)BetterDialog.ShowDialogDelete(Caption, Text, Text, Properties.Resources.OK, Properties.Resources.Cancel);
        }
    }
}
