
using System;
namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of recent file.
    /// </summary>
    public class RecentFileAction
    {
        /// <summary>
        /// File location
        /// </summary>
        public string FilePath;
        /// <summary>
        /// Recent action for CCS
        /// </summary>
        public Action<string> RecentActionLoadCCS;
        /// <summary>
        /// Recent action for CXDI
        /// </summary>
        public Action<string> RecentActionLoadCXDI;
        /// <summary>
        /// Initializes a new instance of the RecentFile class.
        /// </summary>
        public RecentFileAction(string filePath, Action<string> recentActionCCS, Action<string> recentActionLoadCXDI)
        {
            FilePath = filePath;
            RecentActionLoadCCS = recentActionCCS;
            RecentActionLoadCXDI = recentActionLoadCXDI;
        }
    }
}