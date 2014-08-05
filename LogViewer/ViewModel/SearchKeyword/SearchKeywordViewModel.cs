using LogViewer.Model;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using LogViewer.CustomException;
using LogViewer.MVVMHelper;
using System.Windows.Input;
namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for search keyword
    /// </summary>
    public class SearchKeywordViewModel : BaseWindowViewModel
    {
        /// <summary>
        /// Event search CCS log
        /// </summary>
        protected event Func<SearchItem, IList<CCSLogRecord>> OnSearchCCSEvent;
        /// <summary>
        /// Event search CXDI log
        /// </summary>
        protected event Func<SearchItem, IList<CXDILogRecord>> OnSearchCXDIEvent;
        /// <summary>
        /// event show CCS log record
        /// </summary>
        protected event Action<CCSLogRecord> OnShowCCSRecordEvent;
        /// <summary>
        /// event show CXDI log record
        /// </summary>
        protected event Action<CXDILogRecord> OnShowCXDIRecordEvent;
        /// <summary>
        /// CCS result
        /// </summary>
        protected CCSResultSearchKeywordViewModel _ccsResultVM;
        /// <summary>
        /// CXDI result
        /// </summary>
        protected CXDIResultSearchKeywordViewModel _cxdiResultVM;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onSearchCCSEvent">Action search CCS</param>
        /// <param name="onSearchCXDIEvent">Action Search CXDI</param>
        /// <param name="onShowCCSRecordEvent">Action show CCS log record</param>
        /// <param name="onShowCXDIRecordEvent">Action show CXDI log record</param>
        public SearchKeywordViewModel(
            Func<SearchItem, IList<CCSLogRecord>> onSearchCCSEvent,
            Func<SearchItem, IList<CXDILogRecord>> onSearchCXDIEvent,
            Action<CCSLogRecord> onShowCCSRecordEvent,
            Action<CXDILogRecord> onShowCXDIRecordEvent
            )
        {
            //init();
            OnSearchCCSEvent = onSearchCCSEvent;
            OnSearchCXDIEvent = onSearchCXDIEvent;
            OnShowCCSRecordEvent = onShowCCSRecordEvent;
            OnShowCXDIRecordEvent = onShowCXDIRecordEvent;
        }

        protected ObservableCollection<ValueDisplayPair<string, string>> _logKindTargetList;
        /// <summary>
        /// Collect log kind target
        /// </summary>
        public ObservableCollection<ValueDisplayPair<string, string>> LogKindTargetList 
        {
            get
            {
                if (_logKindTargetList == null)
                {
                    _logKindTargetList = new ObservableCollection<ValueDisplayPair<string, string>>();
                }
                return _logKindTargetList;
            }
            set
            {
                _logKindTargetList = value;
                OnPropertyChanged("LogKindTargetList");
            }
        }

        protected string _selectedLogKindTarget;
        /// <summary>
        /// Selected log kind target
        /// </summary>
        public string SelectedLogKindTarget 
        {
            get
            {
                if (string.IsNullOrEmpty(_selectedLogKindTarget))
                {
                    _selectedLogKindTarget = ConfigValue.LogKindTarget.CCS;
                }
                return _selectedLogKindTarget;
            }
            set
            {
                if (value != null)
                {
                    if (!ConfigValue.LogKindTarget.AllLogKindTarget.Contains(value))
                    {
                        throw new DataValueNotSupportedException();
                    }
                    _selectedLogKindTarget = value;
                    if (_selectedLogKindTarget == ConfigValue.LogKindTarget.CCS)
                    {
                        _ccsResultVM.IsShowTab = true;
                        _cxdiResultVM.IsShowTab = false;
                        SelectedSearchResultVM = _ccsResultVM;
                    }
                    else if (_selectedLogKindTarget == ConfigValue.LogKindTarget.CXDI)
                    {
                        _ccsResultVM.IsShowTab = false;
                        _cxdiResultVM.IsShowTab = true;
                        SelectedSearchResultVM = _cxdiResultVM;
                    }
                    else if (_selectedLogKindTarget == ConfigValue.LogKindTarget.CCS_CXDI)
                    {
                        _ccsResultVM.IsShowTab = true;
                        _cxdiResultVM.IsShowTab = true;
                    }
                    OnPropertyChanged("SelectedLogKindTarget");
                }
            }
        }

        protected ObservableCollection<object> searchResultVMList;
        /// <summary>
        /// Collect search result View Model
        /// </summary>
        public ObservableCollection<object> SearchResultVMList
        {
            get
            {
                return searchResultVMList;
            }
            set
            {
                searchResultVMList = value;
                OnPropertyChanged("SearchResultVMList");
            }
        }

        protected object selectedSearchResultVM;
        /// <summary>
        /// Selected search result view model
        /// </summary>
        public object SelectedSearchResultVM
        {
            get
            {
                return selectedSearchResultVM;
            }
            set
            {
                selectedSearchResultVM = value;
                OnPropertyChanged("SelectedSearchResultVM");
            }
        }

        protected string _searchString;
        /// <summary>
        /// String search
        /// </summary>
        public string SearchString
        {
            get
            {
                return _searchString;
            }
            set
            {
                _searchString = value;
                OnPropertyChanged("SearchString");
            }
        }

        protected DelegateCommand searchCommand;
        /// <summary>
        /// Register Search command
        /// </summary>
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new DelegateCommand(Search);
                }
                return searchCommand;
            }
        }
        /// <summary>
        /// Function search in log using search string
        /// </summary>
        protected void Search()
        {
            LoadingDialogViewModel loadingDlg = new LoadingDialogViewModel();
            loadingDlg.ExecuteWhilePopUpLoading(() =>
                {
                    if (SelectedLogKindTarget == ConfigValue.LogKindTarget.CCS_CXDI
                        || SelectedLogKindTarget == ConfigValue.LogKindTarget.CCS)
                    {
                        var ccsSearchItem = new SearchItem { LogItem = _ccsResultVM.SelectedLogItem, StringValue = SearchString };
                        if (OnSearchCCSEvent != null)
                        {
                            var data = OnSearchCCSEvent(ccsSearchItem);
                            _ccsResultVM.LoadData(data);
                        }
                    }
                    if (SelectedLogKindTarget == ConfigValue.LogKindTarget.CCS_CXDI
                        || SelectedLogKindTarget == ConfigValue.LogKindTarget.CXDI)
                    {
                        var cxdiSearchItem = new SearchItem { LogItem = _cxdiResultVM.SelectedLogItem, StringValue = SearchString };
                        if (OnSearchCXDIEvent != null)
                        {
                            var data = OnSearchCXDIEvent(cxdiSearchItem);
                            _cxdiResultVM.LoadData(data);
                        }
                    }
                }, this,null);
        }

        /// <summary>
        /// Initialize child view model
        /// </summary>
        protected virtual void InitChildViewModels()
        {
            _ccsResultVM.OnShowRecordEvent += new Action<CCSLogRecord>(x =>
            {
                if (OnShowCCSRecordEvent != null)
                    OnShowCCSRecordEvent(x);
            });
            _cxdiResultVM.OnShowRecordEvent += new Action<CXDILogRecord>(x =>
            {
                if (OnShowCXDIRecordEvent != null)
                    OnShowCXDIRecordEvent(x);
            });
        }
        /// <summary>
        /// Initialize when open search window
        /// </summary>
        public void init()
        {
            LogKindTargetList.Clear();
            List<ValueDisplayPair<string, string>> targetList = new
                    List<ValueDisplayPair<string, string>>();
            ConfigValue.LogKindTarget.AllLogKindTarget.ForEach((x) =>
            {
                targetList.Add(
                    new ValueDisplayPair<string, string> { Value = x, Display = Util.Utility.Translate(x) });
            });
            LogKindTargetList = new
                    ObservableCollection<ValueDisplayPair<string, string>>(targetList);
            _cxdiResultVM = new CXDIResultSearchKeywordViewModel();
            _cxdiResultVM.Name = Util.Utility.Translate(ConfigValue.LogKindTarget.CXDI);
            _ccsResultVM = new CCSResultSearchKeywordViewModel();
            _ccsResultVM.Name = Util.Utility.Translate(ConfigValue.LogKindTarget.CCS);
            
            SearchResultVMList = new ObservableCollection<object>();
            SearchResultVMList.Add(_cxdiResultVM);
            SearchResultVMList.Add(_ccsResultVM);
            SelectedLogKindTarget = ConfigValue.LogKindTarget.CCS;
            SearchString = "";
            InitChildViewModels();
        }
        /// <summary>
        /// Clear CCS result tab
        /// </summary>
        public void clearCCS()
        {
            //SearchResultVMList.Remove(_ccsResultVM);
            if(_ccsResultVM != null)
                _ccsResultVM.LogResultList = new ObservableCollection<CCSLogRecord>();
            if (_cxdiResultVM == null || _cxdiResultVM.LogResultList == null || _cxdiResultVM.LogResultList.Count == 0)
                SearchString = "";
        }
        /// <summary>
        /// Clear CXDI result tab
        /// </summary>
        public void clearCXDI()
        {
            if(_cxdiResultVM != null)
                _cxdiResultVM.LogResultList = new ObservableCollection<CXDILogRecord>();
            if (_ccsResultVM == null || _ccsResultVM.LogResultList == null || _ccsResultVM.LogResultList.Count == 0)
                SearchString = "";
        }
    }
}