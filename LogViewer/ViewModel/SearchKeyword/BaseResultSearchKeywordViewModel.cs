using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using System.Collections.ObjectModel;
using LogViewer.CustomException;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Base class provides common methods for search keyword.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseResultSearchKeywordViewModel<T> : BaseViewModel where T : BaseLogRecord
    {
        /// <summary>
        /// Action show record event
        /// </summary>
        public event Action<T> OnShowRecordEvent;
        /// <summary>
        /// Default Constructor  
        /// </summary>
        public BaseResultSearchKeywordViewModel()
        {
            LogItemList = new ObservableCollection<ValueDisplayPair<string, string>>(InitLogItemList());
            SelectedLogItem = GetDefaultSelectedLogItem();
        }
        /// <summary>
        /// Set double clicked record
        /// </summary>
        public T DoubleClickedRecord
        {
            set
            {
                if (value != null)
                    OnShowRecordEvent(value);
            }
        }
        /// <summary>
        /// Check is CCS log
        /// </summary>
        public abstract bool IsCCS { get; }
        /// <summary>
        /// Check is CXDI log
        /// </summary>
        public abstract bool IsCXDI { get; }

        protected string _name;
        /// <summary>
        /// Get or set name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        protected bool _isShowTab;
        /// <summary>
        /// Get or set IsShowTab
        /// </summary>
        public bool IsShowTab
        {
            get
            {
                return _isShowTab;
            }
            set
            {
                _isShowTab = value;
                OnPropertyChanged("IsShowTab");
            }
        }

        protected ObservableCollection<ValueDisplayPair<string, string>> _logItemList;
        /// <summary>
        /// Get or set LogItemList
        /// </summary>
        public ObservableCollection<ValueDisplayPair<string, string>> LogItemList
        {
            get
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                    {
                        OnPropertyChanged("SelectedLogItem");
                    }), priority: System.Windows.Threading.DispatcherPriority.Render);
                return _logItemList;
            }
            set
            {
                _logItemList = value;
                OnPropertyChanged("LogItemList");
            }
        }

        protected string _selectedLogItem;
        /// <summary>
        /// Get or set SelectedLogItem
        /// </summary>
        public string SelectedLogItem
        {
            get
            {
                return _selectedLogItem;
            }
            set
            {
                if (!IsValidLogField(value))
                {
                    throw new DataValueNotSupportedException();
                }
                _selectedLogItem= value;
                OnPropertyChanged("SelectedLogItem");
            }
        }

        protected ObservableCollection<T> _logResultList;
        /// <summary>
        /// Get or set LogResultList
        /// </summary>
        public ObservableCollection<T> LogResultList
        {
            get
            {
                return _logResultList;
            }
            set
            {
                _logResultList = value;
                ResultCount = value.Count;
                OnPropertyChanged("LogResultList");
            }
        }

        protected int _resultCount;
        /// <summary>
        /// Get or set ResultCount
        /// </summary>
        public int ResultCount
        {
            get
            {
                return _resultCount;
            }
            set
            {
                _resultCount = value;
                OnPropertyChanged("ResultCount");
            }
        }
        /// <summary>
        /// Abstract function Initialize log item list
        /// </summary>
        /// <returns></returns>
        abstract protected List<ValueDisplayPair<string, string>> InitLogItemList();
        /// <summary>
        /// Abstract function get default selectedLogItem
        /// </summary>
        /// <returns></returns>
        abstract protected string GetDefaultSelectedLogItem();
        /// <summary>
        /// Abstract function check log valid
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        abstract protected bool IsValidLogField(string value);
        /// <summary>
        /// Load data to LogResultList
        /// </summary>
        /// <param name="data"></param>
        public virtual void LoadData(IList<T> data)
        {
            LogResultList = new ObservableCollection<T>(data);
        }
    }
}
