using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using LogViewer.Model;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Windows;

namespace LogViewer.ViewModel.LogMain.AnalyzeTab.Tab
{
    /// <summary>
    /// Class provides method for Error action tab
    /// </summary>
    public class ErrorActionTabViewModel : BaseViewModel
    {
        /// <summary>
        /// Action show record
        /// </summary>
        protected event Action<CCSLogRecord> OnShowRecord;
        /// <summary>
        /// Action stop analyze error action
        /// </summary>
        protected Action StopErrorAction;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onShowRecord">Action show record</param>
        /// <param name="stopErrorAction">Action stop analyze error action</param>
        public ErrorActionTabViewModel(Action<CCSLogRecord> onShowRecord, Action stopErrorAction)
        {
            OnShowRecord = onShowRecord;
            StopErrorAction = stopErrorAction;
        }

        /// <summary>
        /// Set property double clicked record error action
        /// </summary>
        public AnalyzedErrorActionItem DoubleClickedRecord
        {
            set
            {
                if (value != null)
                    OnShowRecord(value.Record);
            }
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
        /// Get or set IsShowTabError
        /// </summary>
        protected bool _isShowTabError;
        public bool IsShowTabError
        {
            get
            {
                return _isShowTabError;
            }
            set
            {
                _isShowTabError = value;
                OnPropertyChanged("IsShowTabError");
            }
        }


        protected IList<object> _selectedItems;
        /// <summary>
        /// Get or set SelectedItems
        /// </summary>
        public IList<object> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                OnPropertyChanged("SelectedItems");
            }
        }

        protected DelegateCommand _cancelError;
        /// <summary>
        /// Get or set cancel error action
        /// </summary>
        public ICommand CancelError
        {
            get
            {
                if (_cancelError == null)
                {
                    _cancelError = new DelegateCommand(CancelErrorCL);
                }
                return _cancelError;
            }
        }
        /// <summary>
        /// Function callback when cancel error action
        /// </summary>
        protected void CancelErrorCL()
        {
            IsLoadingData = false;
            StopErrorAction();
        }

        protected ObservableCollection<AnalyzedErrorActionItem> _errorActionList;
        /// <summary>
        /// Get or set error action result list
        /// </summary>
        public ObservableCollection<AnalyzedErrorActionItem> ErrorActionList
        {
            get
            {
                return _errorActionList;
            }
            set
            {
                _errorActionList = value;
                OnPropertyChanged("ErrorActionList");
            }
        }

        /// <summary>
        /// Clear data in error action tab
        /// </summary>
        public void ClearData()
        {
            ErrorActionList = new ObservableCollection<AnalyzedErrorActionItem>();
        }
        /// <summary>
        /// Load data to error action tab
        /// </summary>
        /// <param name="data">List error action result </param>
        public virtual void LoadData(IList<AnalyzedErrorActionItem> data)
        {
            ErrorActionList = new
                ObservableCollection<AnalyzedErrorActionItem>(data);
        }


        protected DelegateCommand _copyCommand;
        /// <summary>
        /// Get or set command for copy menu item
        /// </summary>
        public ICommand CopyCommand
        {
            get
            {
                if (_copyCommand == null)
                {
                    _copyCommand = new DelegateCommand(CopyCommandCL, () => IsEnableCopy());
                }
                return _copyCommand;
            }
        }
        /// <summary>
        /// Check can execute copy
        /// </summary>
        /// <returns></returns>
        protected bool IsEnableCopy()
        {
            if (SelectedItems == null || SelectedItems.Count == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Function callback when click copy menu item
        /// </summary>
        protected void CopyCommandCL()
        {
            StringBuilder builder = new StringBuilder();
            var selectedItems = new List<AnalyzedErrorActionItem>(SelectedItems.Cast<AnalyzedErrorActionItem>());
            var orderSelectedItems = selectedItems.OrderBy(x => x.Date).ThenBy(y => y.Time).ToList();
            foreach (AnalyzedErrorActionItem i in orderSelectedItems)
            {
                //builder.Append(i.Line);
                //builder.Append(",");
                builder.Append(i.Date);
                builder.Append(" ");
                builder.Append(i.Time);
                builder.Append(",");
                builder.Append(i.ErrorCode);
                builder.Append(",");
                builder.Append(i.Message);
                builder.Append(",");
                builder.Append(i.Recipe);
                //if (!i.Line.Equals(((AnalyzedErrorActionItem)orderSelectedItems.LastOrDefault()).Line))
                //{
                builder.Append("\r\n");
                //}
            }
            Clipboard.SetText(builder.ToString());
        }
    }
}
