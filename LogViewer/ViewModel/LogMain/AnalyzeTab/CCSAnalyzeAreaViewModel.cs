// File:    CCSAnalyzeAreaViewModel.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 11:03:28 AM
// Purpose: Definition of Class CCSAnalyzeAreaViewModel

using System;
using LogViewer.Model;
using LogViewer.ViewModel.LogMain.AnalyzeTab.Tab;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for CCS analyze area log
    /// </summary>
    public class CCSAnalyzeAreaViewModel : BaseLogAnalyzeAreaViewModel<CCSLogRecord>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="onShowLogRecord">Action show log record</param>
        /// <param name="onShowPatternColoringRecord">Action show pattern coloring</param>
        /// <param name="onStopCountKeyword">Action stop count keyword</param>
        /// <param name="onStopPatternAnalyzed">Action stop pattern analyze</param>
        /// <param name="onStopErrorAction">Action stop error action</param>
        /// <param name="onStopUserAction">Action stop user action</param>
        public CCSAnalyzeAreaViewModel(Action<CCSLogRecord> onShowLogRecord, Action<CCSLogRecord, AnalyzedPatternResultItem<CCSLogRecord>> onShowPatternColoringRecord, Action onStopCountKeyword, Action onStopPatternAnalyzed, Action onStopErrorAction, Action onStopUserAction)
            : base(onShowLogRecord, onShowPatternColoringRecord, onStopCountKeyword, onStopPatternAnalyzed)
        {
            ErrorActionTabVM = new ErrorActionTabViewModel(onShowLogRecord, onStopErrorAction);
            UserActionTabVM = new UserActionTabViewModel(onShowLogRecord, onStopUserAction);
        }
        protected ErrorActionTabViewModel _errorActionTabVM;
        /// <summary>
        /// Get or set error action tab
        /// </summary>
        public ErrorActionTabViewModel ErrorActionTabVM
        {
            get
            {
                return _errorActionTabVM;
            }
            set
            {
                _errorActionTabVM = value;
                OnPropertyChanged("ErrorActionTabVM");
            }
        }

        protected UserActionTabViewModel _userActionTabVM;
        /// <summary>
        /// Get or set user action tab
        /// </summary>
        public UserActionTabViewModel UserActionTabVM
        {
            get
            {
                return _userActionTabVM;
            }
            set
            {
                _userActionTabVM = value;
                OnPropertyChanged("UserActionTabVM");
            }
        }
    }
}