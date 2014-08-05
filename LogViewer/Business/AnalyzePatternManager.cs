using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides methods for analyzing pattern.
    /// </summary>
    class AnalyzePatternManager
    {
        /// <summary>
        /// Get instance  of pattern analyzer class. Currently, there a one pattern analyze class: <see cref="AnalyzePattern"/>
        /// </summary>
        /// <typeparam name="T">Generic log record class, that can be <see cref="CCSLogRecord">CCSLogRecord</see> or <see cref="CXDILogRecord">CXDILogRecord</see>
        /// </typeparam>
        /// <returns>Instance of pattern analyzer class. <seealso cref="AnalyzePattern"/></returns>
        public static IAnalyzePattern<T> GetPatternAnalyzeInstance<T>() where T: BaseLogRecord
        {
            return new AnalyzePattern<T>();
        }
    }
}
