using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.ViewModel
{

    /// <summary>
    /// Base class provides common methods for analyze area log.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseLogAnalyzeAreaViewModel<T> : BaseViewModel where T : BaseLogRecord
    {
        /// <summary>
        /// Action show log record
        /// </summary>
        protected event Action<T> OnShowLogRecord;
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="onShowLogRecord">Action show log record</param>
        /// <param name="onShowPatternColoringRecord">Action show pattern coloring</param>
        /// <param name="onStopCountKeyword">Action stop count keyword</param>
        /// <param name="onStopPatternAnalyzed">Action stop analyze pattern</param>
        protected BaseLogAnalyzeAreaViewModel(Action<T> onShowLogRecord, Action<T, AnalyzedPatternResultItem<T>> onShowPatternColoringRecord, Action onStopCountKeyword, Action onStopPatternAnalyzed)
        {
            OnShowLogRecord = onShowLogRecord;
            LogBookmarkTabVM = new LogBookmarkTabViewModel<T>(OnShowLogRecord);
            LogPatternTabVM = new PatternTabViewModel<T>(onShowPatternColoringRecord, onStopPatternAnalyzed);
            CountKeywordTabVM = new CountKeywordTabViewModel(onStopCountKeyword);
        }
        protected CountKeywordTabViewModel _countKeywordTabVM;
        /// <summary>
        /// Get or set count keyword tab
        /// </summary>
        public CountKeywordTabViewModel CountKeywordTabVM 
        { 
            get
            {
                return _countKeywordTabVM;
            }
            set
            {
                _countKeywordTabVM = value;
                OnPropertyChanged("CountKeywordTabVM");
            }
        }


        protected LogBookmarkTabViewModel<T> _logBookmarkTabVM;
        /// <summary>
        /// Get or set bookmark tab
        /// </summary>
        public LogBookmarkTabViewModel<T> LogBookmarkTabVM 
        {
            get
            {
                return _logBookmarkTabVM;
            }
            set
            {
                _logBookmarkTabVM = value;
                OnPropertyChanged("LogBookmarkTabVM");
            }
        }

        protected PatternTabViewModel<T> _logPatternTabVM;
        /// <summary>
        /// Get or set analyzer pattern tab
        /// </summary>
        public PatternTabViewModel<T> LogPatternTabVM
        {
            get
            {
                return _logPatternTabVM;
            }
            set
            {
                _logPatternTabVM = value;
                OnPropertyChanged("LogPatternTabVM");
            }
        }
        /// <summary>
        /// Add a bookmark in bookmark tab
        /// </summary>
        /// <param name="data">Base record</param>
        public virtual void AddBookmark(T data)
        {
            LogBookmarkTabVM.IsShowTabBookmark = true;
            LogBookmarkTabVM.AddBookmark(data);
        }
        /// <summary>
        /// Remove a bookmark in bookmark tab
        /// </summary>
        /// <param name="data">Base record</param>
        public virtual void RemoveBookmark(T data)
        {
            LogBookmarkTabVM.RemoveBookmark(data);
        }
    }
}
