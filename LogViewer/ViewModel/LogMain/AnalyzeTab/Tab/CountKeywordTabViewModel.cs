// File:    CountKeywordTabViewModel.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 11:04:27 AM
// Purpose: Definition of Class CountKeywordTabViewModel

using System;
using System.Collections.Generic;
using LogViewer.Model;
using System.Collections.ObjectModel;
using LogViewer.MVVMHelper;
using System.Windows.Input;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for Count keyword tab
    /// </summary>
    public class CountKeywordTabViewModel : BaseViewModel
    {
        /// <summary>
        /// Action stop count keyword.
        /// </summary>
        protected Action StopCountKeyword;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="stopCountKeyword">Action stop count keyword.</param>
        public CountKeywordTabViewModel(Action stopCountKeyword)
        {
            _analyzeCountKeywordItems = new ObservableCollection<AnalyzedCountKeywordItem>();
            StopCountKeyword = stopCountKeyword;
        }
        /// <summary>
        /// Load data after analyze to count keyword tab
        /// </summary>
        /// <param name="data">Result count keyword</param>
        public virtual void LoadData(IList<AnalyzedCountKeywordItem> data)
        {
            AnalyzeCountKeywordItems = new ObservableCollection<AnalyzedCountKeywordItem>(data);
        }
        /// <summary>
        /// Get or set IsLoadingData
        /// </summary>
        protected bool _isLoadingData;
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
        /// <summary>
        /// Get or set collection analyze count keyword items
        /// </summary>
        protected ObservableCollection<AnalyzedCountKeywordItem> _analyzeCountKeywordItems;
        public ObservableCollection<AnalyzedCountKeywordItem> AnalyzeCountKeywordItems
        {
            get
            {
                return _analyzeCountKeywordItems;
            }
            set
            {
                _analyzeCountKeywordItems = value;
                OnPropertyChanged("AnalyzeCountKeywordItems");
            }
        }
        /// <summary>
        /// Get or set cancel count keyword command
        /// </summary>
        protected DelegateCommand _cancelCountKeyword;
        public ICommand CancelCountKeyword
        {
            get
            {
                if (_cancelCountKeyword == null)
                {
                    _cancelCountKeyword = new DelegateCommand(CancelCountKeywordCL);
                }
                return _cancelCountKeyword;
            }
        }
        /// <summary>
        /// Function callback when cancel count keyword
        /// </summary>
        protected void CancelCountKeywordCL()
        {
            IsLoadingData = false;
            StopCountKeyword();
        }
        /// <summary>
        /// Get or set property IsShowTabKeyword
        /// </summary>
        protected bool _isShowTabKeyword;
        public bool IsShowTabKeyword
        {
            get
            {
                return _isShowTabKeyword;
            }
            set
            {
                _isShowTabKeyword = value;
                OnPropertyChanged("IsShowTabKeyword");
            }
        }
        /// <summary>
        /// Clear data in count keyword tab
        /// </summary>
        public void ClearData()
        {
            AnalyzeCountKeywordItems = new ObservableCollection<AnalyzedCountKeywordItem>();
        }
    }
}