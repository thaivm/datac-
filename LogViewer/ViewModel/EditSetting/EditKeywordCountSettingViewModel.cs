using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Windows.Controls;
using System.IO;
using LogViewer.Model;
using LogViewer.View;
using System.ComponentModel;
using LogViewer.Business;
using LogViewer.MVVMHelper;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for edit keyword count setting item
    /// </summary>
    public abstract class EditKeywordCountSettingViewModel : BaseEditSettingViewModel<KeywordCountItemSetting>, IDataErrorInfo
    {

        protected Dictionary<string, bool> _inputPropOverwriteChecker;
        /// <summary>
        /// Get or set name
        /// </summary>
        public string Name
        {
            get
            {
                return _itemMemberCandidate.Name;
            }
            set
            {
                _itemMemberCandidate.Name = value;
                OnPropertyChanged("Name");
            }
        }
        /// <summary>
        /// Get or set value of keyword count item
        /// </summary>
        public string StringValue
        {
            get
            {
                return _itemMemberCandidate.StringValue;
            }
            set
            {
                _itemMemberCandidate.StringValue = value;
                OnPropertyChanged("StringValue");
            }
        }
        /// <summary>
        /// Get or set column name of log file
        /// </summary>
        public string LogItem
        {
            get
            {
                return _itemMemberCandidate.LogItem;
            }
            set
            {
                _itemMemberCandidate.LogItem = value;
                OnPropertyChanged("LogItem");
                //refresh the stringValue validation
                OnPropertyChanged("StringValue");
            }
        }
        /// <summary>
        /// Get all log item
        /// </summary>
        public abstract List<ValueDisplayPair<string, string>> AllLogItems { get; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyEvent"><see cref="Action<T>"/></param>
        public EditKeywordCountSettingViewModel(Action<List<KeywordCountItemSetting>> onApplyEvent) : 
            base(onApplyEvent)
        {
            _inputPropOverwriteChecker = new Dictionary<string, bool>();
        }
        /// <summary>
        /// Initialize for after create new object
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            _inputPropOverwriteChecker = new Dictionary<string, bool>();
        }
        /// <summary>
        /// Create keyword count setting item with default value
        /// </summary>
        protected override void CreateNewAndSetCandidateDefaultValue()
        {
            _itemMemberCandidate = new KeywordCountItemSetting();
            Name = StringValue
                = _itemMemberCandidate.Id = String.Empty;
            LogItem = GetDefaultLogItem();
            _itemMemberCandidate.Enabled = true;
        }
        /// <summary>
        /// Delete keyword count setting item
        /// </summary>
        /// <param name="itemsToDelete">List item for deleting</param>
        protected override void DeleteItemSetting(IList<object> itemsToDelete)
        {
            base.DeleteItemSetting(itemsToDelete);
            //Check duplicate after delete
            OnPropertyChanged("StringValue");
            OnPropertyChanged("Name");
        }

        protected KeywordCountItemSetting _doubleClickedCandidate;
        /// <summary>
        /// Get or set <see cref="KeywordCountItemSetting"/> for double click action
        /// </summary>
        public KeywordCountItemSetting DoubleClickedCandidate
        {
            get
            {
                return _doubleClickedCandidate;
            }
            set
            {
                _doubleClickedCandidate = value;
                if (value != null)
                {
                    _itemMemberCandidate = value.Copy();
                    OnCandidateValueChange();
                }
                else
                {
                    CreateNewAndSetCandidateDefaultValue();
                }
            }
        }
        /// <summary>
        /// Get status of validation of all input
        /// </summary>
        public bool IsValidAllInputPropOverwrite
        {
            get
            {
                bool isAllValid = true;
                foreach (KeyValuePair<string, bool> k in _inputPropOverwriteChecker)
                {
                    isAllValid &= k.Value;
                }
                return isAllValid;
            }
        }
        protected DelegateCommand _overwriteItemSettingCommand;
        /// <summary>
        /// Command interface for overwritten setting item
        /// </summary>
        public ICommand OverwriteItemSettingCommand
        {
            get
            {
                if (_overwriteItemSettingCommand == null)
                {
                    _overwriteItemSettingCommand = new DelegateCommand(OverwriteItemSettingCL, () => DoubleClickedCandidate != null && IsValidAllInputPropOverwrite);
                }
                return _overwriteItemSettingCommand;
            }
        }
        /// <summary>
        /// Command for overwritten setting item
        /// </summary>
        protected virtual void OverwriteItemSettingCL()
        {
            ItemSettingList.Remove(DoubleClickedCandidate);
            ItemSettingList.Add(_itemMemberCandidate);
            DoubleClickedCandidate = null;
        }
        /// <summary>
        /// Process when keyword count change value
        /// </summary>
        protected virtual void OnCandidateValueChange()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("StringValue");
            OnPropertyChanged("LogItem");
        }
        /// <summary>
        /// Get default <see cref="LogItem"/>
        /// </summary>
        /// <returns>Name of default <see cref="LogItem"/></returns>
        protected abstract string GetDefaultLogItem();

        #region IDataErrorInfo

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string propertyName]
        {
            get
            {
                bool isCheckerAlreadySet = false;
                bool isOverwriteCheckerAlreadySet = false;
                string errorMessage = String.Empty;
                switch (propertyName)
                {
                    //hard code.
                    case "Name":
                        errorMessage = _itemMemberCandidate["Name"];
                        break;
                    case "StringValue":
                        errorMessage = _itemMemberCandidate["StringValue"];
                        break;
                    case "LogItem":
                        errorMessage = _itemMemberCandidate["LogItem"];
                        break;
                }
                if (String.IsNullOrEmpty(errorMessage))
                {
                    switch (propertyName)
                    {
                        //Check duplicate filter item name
                        case "Name":
                            {
                                var item = ItemSettingList.SingleOrDefault(x => x.Name.Trim().ToLower() == Name.Trim().ToLower());
                                if (item != null)
                                {
                                    //When in overwrite mode
                                    if (_doubleClickedCandidate != null)
                                    {
                                        //the duplicate name is the current item that going to be overwritten: 
                                        //  -Enable Overwrite button
                                        if (item == _doubleClickedCandidate)
                                        {
                                            _inputPropOverwriteChecker[propertyName] = true;
                                            isOverwriteCheckerAlreadySet = true;
                                        }
                                    }
                                    errorMessage = Properties.Resources.DuplicateNameErrorMessage;
                                }
                                break;
                            }
                        case "StringValue":
                            {
                                var item = ItemSettingList.SingleOrDefault(x => x.StringValue.Trim().ToLower() == StringValue.Trim().ToLower() && x.LogItem.ToLower() == LogItem.Trim().ToLower());
                                if (item != null)
                                {
                                    //the duplicate name is the current item that going to be overwritten: 
                                    //  -Enable Overwrite button
                                    if (item == _doubleClickedCandidate)
                                    {
                                        _inputPropOverwriteChecker[propertyName] = true;
                                        isOverwriteCheckerAlreadySet = true;
                                    }
                                    errorMessage = Properties.Resources.DuplicateKeywordWithLogItemErrorMessage;
                                }
                                break;
                            }
                    }
                }

                if (!isCheckerAlreadySet)
                {
                    _inputPropChecker[propertyName] = String.IsNullOrEmpty(errorMessage);
                }
                if (!isOverwriteCheckerAlreadySet)
                {
                    _inputPropOverwriteChecker[propertyName] = String.IsNullOrEmpty(errorMessage);
                }
                //_inputPropChecker[propertyName] = String.IsNullOrEmpty(errorMessage);
                return errorMessage;
            }
        }

        #endregion
    }
}
