using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class Data Grid Drag Drop Event Args.
    /// </summary>
    public class DataGridDragDropEventArgs : EventArgs
    {
        /// <summary>
        /// The value to match against the input value of Source.
        /// </summary>
        public String Source { get; internal set; }
        /// <summary>
        /// The value to match against the input value of Effects.
        /// </summary>
        public DragDropEffects Effects { get; internal set; }
    }
}
