// File:    CXDIAnalyzeAreaViewModel.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 11:13:14 AM
// Purpose: Definition of Class CXDIAnalyzeAreaViewModel

using System;
using LogViewer.Model;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for CXDI analyze area log
    /// </summary>
    public class CXDIAnalyzeAreaViewModel : BaseLogAnalyzeAreaViewModel<CXDILogRecord>
    {
        protected FirmwareInfoTabViewModel _firmwareInfoTabVM;
        /// <summary>
        /// Get or set firmware tab
        /// </summary>
        public FirmwareInfoTabViewModel FirmwareInfoTabVM
        {
            get
            {
                if (_firmwareInfoTabVM == null)
                {
                    _firmwareInfoTabVM = new FirmwareInfoTabViewModel();
                }
                return _firmwareInfoTabVM;
            }
            set
            {
                _firmwareInfoTabVM = value;
                OnPropertyChanged("FirmwareInfoTabVM");
            }
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="onShowLogRecord">Action show log record</param>
        /// <param name="onShowPatternColoringRecord">Action show pattern coloring</param>
        /// <param name="onStopCountKeyword">Action stop count keyword</param>
        /// <param name="onStopPatternAnalyzed">Action stop pattern analyze</param>
        public CXDIAnalyzeAreaViewModel(Action<CXDILogRecord> onShowLogRecord, Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord, Action onStopCountKeyword, Action onStopPatternAnalyzed)
            : base(onShowLogRecord, onShowPatternColoringRecord, onStopCountKeyword, onStopPatternAnalyzed)
        {
            
            FirmwareInfoTabVM = new FirmwareInfoTabViewModel();
        }
    }
}