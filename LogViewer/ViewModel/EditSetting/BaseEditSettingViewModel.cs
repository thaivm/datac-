using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Base abstract class provides common method for setting parameter item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseEditSettingViewModel<T> : BaseApplyWindowViewModel<List<T>> where T : BaseItemSetting, new() 
    {
        protected T _itemMemberCandidate;
        protected Dictionary<string, bool> _inputPropChecker;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplySettingEvent"><see cref="Action<T>"/></param>
        protected BaseEditSettingViewModel(Action<List<T>> onApplySettingEvent)
            :base(onApplySettingEvent)
        {
            _inputPropChecker = new Dictionary<string, bool>();
            ItemSettingList = new ObservableCollection<T>();
            CreateNewAndSetCandidateDefaultValue();
        }
        /// <summary>
        /// Initialize after creating object
        /// </summary>
        public virtual void Initialize()
        {
            _inputPropChecker = new Dictionary<string, bool>();
            CreateNewAndSetCandidateDefaultValue();
        }
        /// <summary>
        /// Get valid status of all item
        /// </summary>
        public bool IsValidAllInputProp
        {
            get
            {
                bool isAllValid = true;
                foreach (KeyValuePair<string, bool> k in _inputPropChecker)
                {
                    isAllValid &= k.Value;
                }
                return isAllValid;
            }
        }

        protected IList<object> _selectedItems;
        /// <summary>
        /// Get or set for list of items as selected
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

        protected ObservableCollection<T> _itemSettingList;
        /// <summary>
        /// Get or set item setting list
        /// </summary>
        public ObservableCollection<T> ItemSettingList
        {
            get
            {
                return _itemSettingList;
            }
            set
            {
                _itemSettingList = value;
                OnPropertyChanged("ItemSettingList");
            }
        }
        protected string _title;
        /// <summary>
        /// Get or set title
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        protected DelegateCommand _addItemSettingCommand;
        /// <summary>
        /// Command interface for adding item
        /// </summary>
        public ICommand AddItemSettingCommand
        {
            get
            {
                if (_addItemSettingCommand == null)
                {
                    _addItemSettingCommand = new DelegateCommand(AddItemSettingCL, () => IsValidAllInputProp);
                }
                return _addItemSettingCommand;
            }
        }
        /// <summary>
        /// Command for adding item
        /// </summary>
        protected virtual void AddItemSettingCL()
        {
            ItemSettingList.Add(_itemMemberCandidate);
            CreateNewAndSetCandidateDefaultValue();
        }

        protected DelegateCommand _deleteItemSettingCommand;
        /// <summary>
        /// Command inteface for deleting item
        /// </summary>
        public ICommand DeleteItemSettingCommand
        {
            get
            {
                if (_deleteItemSettingCommand == null)
                {
                    _deleteItemSettingCommand = new DelegateCommand(DeleteItemSettingCL,() => SelectedItems != null && SelectedItems.Count != 0);
                }
                return _deleteItemSettingCommand;
            }
        }
        /// <summary>
        /// Command for deleting item
        /// </summary>
        protected virtual void DeleteItemSettingCL()
        {
            MessageBoxViewModel confirm = new MessageBoxViewModel();
            confirm.Caption = Properties.Resources.Confirm;
            confirm.Text = Properties.Resources.MessageConfirm;
            confirm.ButtonValue = System.Windows.MessageBoxButton.OKCancel;
            //System.Windows.MessageBoxResult messageBox = confirm.ShowDialog(this);
            System.Windows.MessageBoxResult messageBox = confirm.ShowDialogDelete(this);
            if (messageBox == System.Windows.MessageBoxResult.OK)
            {
                DeleteItemSetting(SelectedItems);
            }
        }
        /// <summary>
        /// Command for deleting item
        /// </summary>
        /// <param name="itemsToDelete">List of item for deleting</param>
        protected virtual void DeleteItemSetting(IList<object> itemsToDelete)
        {
            var tempList = new List<object>(itemsToDelete);
            foreach (var i in tempList)
            {
                var casted = i as T;
                if (casted != null)
                    ItemSettingList.Remove(casted);
            }
        }
        /// <summary>
        /// Create new item and set default value
        /// </summary>
        protected abstract void CreateNewAndSetCandidateDefaultValue();
        /// <summary>
        /// Get data to apply
        /// </summary>
        /// <returns></returns>
        protected override List<T> GetDataToApply()
        {
            return new List<T>(ItemSettingList);
        }
        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="data">List of item</param>
        public virtual void LoadData(IList<T> data)
        {
            var temp = new List<T>();
            foreach (var i in data)
            {
                var copyable = i as ICopyable<T>;
                if (copyable != null)
                {
                    temp.Add(copyable.Copy());
                }
                else
                {
                    temp.Add(i);
                }
            }
            ItemSettingList = new ObservableCollection<T>(temp);
        }
    }
}
