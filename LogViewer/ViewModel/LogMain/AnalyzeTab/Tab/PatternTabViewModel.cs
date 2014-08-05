using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using System.Collections.ObjectModel;
using LogViewer.MVVMHelper;
using System.Windows.Input;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for pattern analyze tab
    /// </summary>
    public class PatternTabViewModel<T> : BaseViewModel
        where T : BaseLogRecord
    {
        /// <summary>
        /// Action stop analyze pattern
        /// </summary>
        protected Action StopPatternAnalyzed;
        protected event Action<T, AnalyzedPatternResultItem<T>> OnShowRecord;
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="onShowRecord">Action show record</param>
        /// <param name="stopPatternAnalyzed">Action stop analyze pattern</param>
        public PatternTabViewModel(Action<T, AnalyzedPatternResultItem<T>> onShowRecord, Action stopPatternAnalyzed)
        {
            OnShowRecord = onShowRecord;
            StopPatternAnalyzed = stopPatternAnalyzed;
        }

        /// <summary>
        /// Set property DoubleClickedRecord
        /// </summary>
        public T DoubleClickedRecord
        {
            set
            {
                if (value != null)
                    OnShowRecord(value, CurrentPatternItem);
            }
        }
        /// <summary>
        /// Set property DoubleClickedPatternResultItem
        /// </summary>
        public AnalyzedPatternResultItem<T> DoubleClickedPatternResultItem
        {
            set
            {
                CurrentPatternItem = value;
            }
        }

        protected bool _isLoadingData;
        /// <summary>
        /// Get or set IsLoadingData
        /// </summary>
        public bool IsLoadingData
        {
            get
            {
                return _isLoadingData;
            }
            set
            {
                _isLoadingData = value;
                OnPropertyChanged("IsLoadingData");
            }
        }

        protected DelegateCommand _cancelPatternAnalyzed;
        /// <summary>
        /// Get or set CancelPatternAnalyzed command
        /// </summary>
        public ICommand CancelPatternAnalyzed
        {
            get
            {
                if (_cancelPatternAnalyzed == null)
                {
                    _cancelPatternAnalyzed = new DelegateCommand(CancelPatternAnalyzedCL);
                }
                return _cancelPatternAnalyzed;
            }
        }
        /// <summary>
        /// Function when cancel analyze pattern
        /// </summary>
        protected void CancelPatternAnalyzedCL()
        {
            IsLoadingData = false;
            StopPatternAnalyzed();
        }

        protected ObservableCollection<AnalyzedPatternResultItem<T>> _patternRecordList;
        /// <summary>
        /// Get or set pattern analyze result list
        /// </summary>
        public ObservableCollection<AnalyzedPatternResultItem<T>> PatternRecordList
        {
            get
            {
                return _patternRecordList;
            }
            set
            {
                _patternRecordList = value;
                OnPropertyChanged("PatternRecordList");
            }
        }
        protected bool _isShowTabPattern;
        /// <summary>
        /// Get or set IsShowTabPattern
        /// </summary>
        public bool IsShowTabPattern
        {
            get
            {
                return _isShowTabPattern;
            }
            set
            {
                _isShowTabPattern = value;
                OnPropertyChanged("IsShowTabPattern");
            }
        }
        protected AnalyzedPatternResultItem<T> _currentPatternItem;
        /// <summary>
        /// Get or set CurrentPatternItem
        /// </summary>
        public AnalyzedPatternResultItem<T> CurrentPatternItem 
        {
            get
            {
                return _currentPatternItem;
            }
            set
            {
                _currentPatternItem = value;
                OnPropertyChanged("CurrentPatternItem");
            }
        }
        /// <summary>
        /// Clear data in pattern analyze tab
        /// </summary>
        public void ClearData()
        {
            PatternRecordList = new ObservableCollection<AnalyzedPatternResultItem<T>>();
            CurrentPatternItem = new AnalyzedPatternResultItem<T>();
        }
        /// <summary>
        /// Load data to pattern analyze tab
        /// </summary>
        /// <param name="data">List analyze pattern result</param>
        public virtual void LoadData(IList<AnalyzedPatternResultItem<T>> data)
        {
            PatternRecordList = new
                ObservableCollection<AnalyzedPatternResultItem<T>>(data);
        }
    }
}
