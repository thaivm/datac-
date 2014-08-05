using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using System.Collections.ObjectModel;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Windows;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for bookmark tab
    /// </summary>
    public class LogBookmarkTabViewModel<T> : BaseViewModel where T : BaseLogRecord
    {
        /// <summary>
        /// Action show record
        /// </summary>
        protected event Action<T> OnShowRecord;
            /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onShowRecord">Action show record</param>
        public LogBookmarkTabViewModel(Action<T> onShowRecord)
        {
            OnShowRecord = onShowRecord;
        }
        /// <summary>
        /// Set property double clicked record bookmark
        /// </summary>
        public T DoubleClickedRecord
        {
            set
            {
                if (value != null)
                    OnShowRecord(value);
            }
        }

        protected ObservableCollection<T> _logRecordList;
        /// <summary>
        /// Get or set list bookmark record
        /// </summary>
        public ObservableCollection<T> LogRecordList
        {
            get
            {
                if (_logRecordList == null)
                {
                    _logRecordList = new ObservableCollection<T>();
                }
                return _logRecordList;
            }
            set
            {
                _logRecordList = value;
                OnPropertyChanged("LogRecordList");
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
        protected bool _isShowTabBookmark;
        /// <summary>
        /// Get or set IsShowTabBookmark
        /// </summary>
        public bool IsShowTabBookmark
        {
            get
            {
                return _isShowTabBookmark;
            }
            set
            {
                _isShowTabBookmark = value;
                OnPropertyChanged("IsShowTabBookmark");
            }
        }
        /// <summary>
        /// Add a bookmark to bookmark list
        /// </summary>
        /// <param name="data"></param>
        public virtual void AddBookmark(T data)
        {
            
            int i = 0;
            foreach (T d in LogRecordList)
            {
                if (d.Line > data.Line)
                {
                    break;
                }
                i++;
            }
            LogRecordList.Insert(i, data);
        }
        /// <summary>
        /// Remove a bookmark in bookmark list
        /// </summary>
        /// <param name="data"></param>
        public virtual void RemoveBookmark(T data)
        {
            LogRecordList.Remove(data);
        }
        /// <summary>
        /// Load data to bookmark tab
        /// </summary>
        /// <param name="data">List user action result </param>
        public virtual void LoadData(IList<T> data)
        {
            LogRecordList = new ObservableCollection<T>(data);
        }
        /// <summary>
        /// Reset bookmark tab
        /// </summary>
        public virtual void ResetBookmark()
        {
            LogRecordList = new ObservableCollection<T>();
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
            if ((SelectedItems.FirstOrDefault() as CCSLogRecord) != null)
            {
                var selectedItems = new List<CCSLogRecord>(SelectedItems.Cast<CCSLogRecord>());
                var orderSelectedItems = selectedItems.OrderBy(x => x.Date).ThenBy(y => y.Time).ToList();
                foreach (CCSLogRecord i in orderSelectedItems)
                {
                    //builder.Append(i.Line);
                    //builder.Append(",");
                    builder.Append(i.Date);
                    builder.Append(" ");
                    builder.Append(i.Time);
                    builder.Append(",");
                    builder.Append(i.Type);
                    builder.Append(",");
                    builder.Append(i.Content);
                    //if (!i.Line.Equals(((CCSLogRecord)SelectedItems.LastOrDefault()).Line))
                    //{
                        builder.Append("\r\n");
                    //}
                }
            }
            if ((SelectedItems.FirstOrDefault() as CXDILogRecord) != null)
            {
                var selectedItems = new List<CXDILogRecord>(SelectedItems.Cast<CXDILogRecord>());
                var orderSelectedItems = selectedItems.OrderBy(x => x.Date).ThenBy(y => y.Time).ToList();
                foreach (CXDILogRecord i in orderSelectedItems)
                {
                    //builder.Append(i.Line);
                    //builder.Append(",");
                    builder.Append(i.Date);
                    builder.Append(" ");
                    builder.Append(i.Time);
                    builder.Append(",");
                    builder.Append(i.Module);
                    builder.Append(",");
                    builder.Append(i.Message);
                    //if (!i.Line.Equals(((CXDILogRecord)SelectedItems.LastOrDefault()).Line))
                    //{
                        builder.Append("\r\n");
                    //}
                }
            }
            Clipboard.SetText(builder.ToString());
        }
    }
}
