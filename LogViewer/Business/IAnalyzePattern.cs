using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using System.ComponentModel;
namespace LogViewer.Business
{
    /// <summary>
    /// Interface of Analyze pattern class. All pattern analyze pattern must implement this interface.
    /// </summary>
    /// <typeparam name="T">Type of log records this can be <see cref="CCSLogRecord">CCSLogRecord</see> or <see cref="CXDILogRecord">CXDILogRecord</see>
    /// </typeparam>
    interface IAnalyzePattern<T>
    {
        IList<AnalyzedPatternResultItem<T>> DoAnalyzePattern(IList<T> logRecordList, IList<PatternItemSetting> patternItemSettings, Func<T, string> GetColumnContentValue, BackgroundWorker AnalyzePatternWorker);
    }
}
