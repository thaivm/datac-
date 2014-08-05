using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LogViewer.Service
{
    /// <summary>
    /// Interface provides overwrite method for handling on closing of a dialog
    /// </summary>
    interface IClosableDialog
    {
        event Action CloseAction;
        void dialog_Closing(object sender, CancelEventArgs e);
    }
}
