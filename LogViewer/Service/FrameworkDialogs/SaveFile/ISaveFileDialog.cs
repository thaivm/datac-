using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Service.FrameworkDialogs.SaveFile
{
    /// <summary>
    /// Interface provides overwrite methods for SaveFileDialog
    /// </summary>
    public interface ISaveFileDialog
    {
        /// <summary>
        /// Get or set file name
        /// </summary>
        string FileName { get; set; }
        /// <summary>
        /// Get or set default file extension
        /// </summary>
        string DefaultExt { get; set; }
        /// <summary>
        /// Get or set filter string
        /// </summary>
        string Filter { get; set; }
    }
}
