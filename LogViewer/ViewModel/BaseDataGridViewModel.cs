using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Collections.ObjectModel;
using LogViewer.Model;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class for base data grid view model
    /// </summary>
    /// /// <typeparam name="T">The type of ViewModel.
    /// </typeparam>
    public abstract class BaseDataGridViewModel<T> : BaseViewModel where T:class
    {
        /// <summary>
        /// Parent view model of this class.
        /// </summary>
        object _ownerVM;
        /// <summary>
        /// Initializes a new instances of the BaseApplyWindowViewModel class.
        /// </summary>
        /// <param name="ownerVM">Parent view model of this class.</param>
        protected BaseDataGridViewModel(object ownerVM)
        {
            _ownerVM = ownerVM;
        }

        /// <summary>
        /// Get or set Record is selected in grid.
        /// </summary>
        protected T _rowForJump;
        public T RowForJump {
            get
            {
                return _rowForJump;
            }
            set
            {
                _rowForJump = value;
                OnPropertyChanged("RowForJump");
            }
        }

        /// <summary>
        /// Get or set List item is selected in grid.
        /// </summary>
        protected IList<object> _selectedItems;
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

        /// <summary>
        /// Get or set error message for validate.
        /// </summary>
        protected string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        /// <summary>
        /// function check data is valid or not.
        /// </summary>
        public bool IsDataValid
        {
            get
            {
                ErrorMessage = ValidateData();
                return (String.IsNullOrEmpty(ErrorMessage));
            }
        }

        /// <summary>
        /// abstract function validate data.
        /// </summary>
        protected abstract string ValidateData();

        /// <summary>
        /// Get or set list source of grid.
        /// </summary>
        protected ObservableCollection<T> _sourceList;
        public ObservableCollection<T> SourceList
        {
            get
            {
                return _sourceList;
            }
            set
            {
                _sourceList = value;
                OnPropertyChanged("SourceList");
            }
        }

        /// <summary>
        /// Get or set Command of button add
        /// </summary>
        protected DelegateCommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new DelegateCommand(AddCL, CanAdd);
                }
                return _addCommand;
            }
        }

        /// <summary>
        /// Function callback when click button add
        /// </summary>
        protected virtual void AddCL()
        {
            var newItem = CreateNewItem();
            SourceList.Add(newItem);
            RowForJump = newItem;
        }
        /// <summary>
        /// Check can execute button add (enable or disable)
        /// </summary>
        protected virtual bool CanAdd()
        {
            return true;
        }
        /// <summary>
        /// Function callback when click button delete
        /// </summary>
        protected DelegateCommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new DelegateCommand(DeleteCL, () => SelectedItems != null && SelectedItems.Count != 0);
                }
                return _deleteCommand;
            }
        }
        /// <summary>
        /// Function callback when click button delete
        /// </summary>
        protected virtual void DeleteCL()
        {
            MessageBoxViewModel confirm = new MessageBoxViewModel();
            confirm.Caption = Properties.Resources.Confirm;
            confirm.Text = Properties.Resources.MessageConfirm;
            confirm.ButtonValue = System.Windows.MessageBoxButton.OKCancel;
            System.Windows.MessageBoxResult messageBox = confirm.ShowDialogDelete(_ownerVM);
            if (messageBox == System.Windows.MessageBoxResult.OK)
            {
                Delete(SelectedItems);
            }
        }

        /// <summary>
        /// Function delete a list item selected
        /// </summary>
        /// <param name="items">List item selected in grid</param>
        protected virtual void Delete(IList<object> items)
        {
            var tempList = new List<object>(items);
            foreach (var i in tempList)
            {
                var casted = i as T;
                if (casted != null)
                    SourceList.Remove(casted);
            }
        }

        /// <summary>
        /// Function Initializes source for grid.
        /// </summary>
        /// <param name="data">List record binding to grid</param>
        public virtual void LoadData(IEnumerable<T> data)
        {
            List<T> temp = new List<T>();
            foreach (var i in data)
            {
                var copyable = i as ICopyable<T>;
                if (copyable != null)
                    temp.Add(copyable.Copy());
                else
                    temp.Add(i);
            }
            SourceList = new ObservableCollection<T>(temp);
        }

        /// <summary>
        /// Function abstract create a new instances for each type T 
        /// </summary>
        /// <Return>T</Return>
        protected abstract T CreateNewItem();
    }
}
