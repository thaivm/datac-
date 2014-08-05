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
    /// Class provides method for User action tab
    /// </summary>
    public class UserActionTabViewModel : BaseViewModel
    {
        /// <summary>
        /// Action show record
        /// </summary>
        protected event Action<CCSLogRecord> OnShowRecord;
        /// <summary>
        /// Action stop analyze user action
        /// </summary>
        protected Action StopUserAction;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onShowRecord">Action show record</param>
        /// <param name="stopUserAction">Action stop analyze user action</param>
        public UserActionTabViewModel(Action<CCSLogRecord> onShowRecord,Action stopUserAction)
        {
            OnShowRecord = onShowRecord;
            StopUserAction = stopUserAction;
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
        /// <summary>
        /// Set property double clicked record user action
        /// </summary>
        public AnalyzedUserActionItem DoubleClickedRecord
        {
            set
            {
                if (value != null)
                    OnShowRecord(value.Record);
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
        protected ObservableCollection<AnalyzedUserActionItem> _userActionList;
        /// <summary>
        /// Get or set user action result list
        /// </summary>
        public ObservableCollection<AnalyzedUserActionItem> UserActionList
        {
            get
            {
                return _userActionList;
            }
            set
            {
                _userActionList = value;
                OnPropertyChanged("UserActionList");
            }
        }
        protected bool _isShowTabUserAction;
        /// <summary>
        /// Get or set IsShowTabUserAction
        /// </summary>
        public bool IsShowTabUserAction
        {
            get
            {
                return _isShowTabUserAction;
            }
            set
            {
                _isShowTabUserAction = value;
                OnPropertyChanged("IsShowTabUserAction");
            }
        }

        protected DelegateCommand _cancelUserAction;
        /// <summary>
        /// Get or set cancel user action
        /// </summary>
        public ICommand CancelUserAction
        {
            get
            {
                if (_cancelUserAction == null)
                {
                    _cancelUserAction = new DelegateCommand(CancelUserActionCL);
                }
                return _cancelUserAction;
            }
        }
        /// <summary>
        /// Function callback when cancel user action
        /// </summary>
        protected void CancelUserActionCL()
        {
            IsLoadingData = false;
            StopUserAction();
        }
        /// <summary>
        /// Clear data in user action tab
        /// </summary>
        public void ClearData()
        {
            UserActionList = new ObservableCollection<AnalyzedUserActionItem>();
        }
        /// <summary>
        /// Load data to user action tab
        /// </summary>
        /// <param name="data">List user action result </param>
        public virtual void LoadData(IList<AnalyzedUserActionItem> data)
        {
            UserActionList = new
                ObservableCollection<AnalyzedUserActionItem>(data);
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
            var selectedItems = new List<AnalyzedUserActionItem>(SelectedItems.Cast<AnalyzedUserActionItem>());
            var orderSelectedItems = selectedItems.OrderBy(x => x.Date).ThenBy(y => y.Time).ToList();
            foreach (AnalyzedUserActionItem i in orderSelectedItems)
            {
                //builder.Append(i.Line);
                //builder.Append(",");
                builder.Append(i.Date);
                builder.Append(" ");
                builder.Append(i.Time);
                builder.Append(",");
                builder.Append(i.UserAction);
                //if (!i.Line.Equals(((AnalyzedUserActionItem)orderSelectedItems.LastOrDefault()).Line))
                //{
                builder.Append("\r\n");
                //}
            }
            Clipboard.SetText(builder.ToString());
        }
    }
}
