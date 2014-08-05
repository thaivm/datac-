using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Interface Log display container
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILogsDisplayContainer<T> where T:BaseLogRecord
    {
        /// <summary>
        /// Dictionary comment of log
        /// </summary>
        Dictionary<T, string> CommentsDict { get; }
        /// <summary>
        /// Add bookmark
        /// </summary>
        /// <param name="data">Base log record</param>
        void AddBookmark(T data);
        /// <summary>
        /// Remove bookmark
        /// </summary>
        /// <param name="data">Base log record</param>
        void RemoveBookmark(T data);
        /// <summary>
        /// Collection bookmark of log
        /// </summary>
        IList<T> BookmarkList { get; }
        /// <summary>
        /// Collection filter setting of log
        /// </summary>
        List<FilterItemSetting> FilterSetting { get; set; }
        /// <summary>
        /// Pattern color of log
        /// </summary>
        PatternColor<T> PatternColor { get; set; }
    }
}
