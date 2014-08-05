using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;
using LogViewer.View;
using System.Windows.Media;
using System.Drawing;
using Microsoft.Windows.Controls;
using LogViewer.Util;
using LogViewer.Model;
using LogViewer.MVVMHelper;
using LogViewer.Service;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for editing filter setting item
    /// </summary>
    public abstract class EditFilterSettingViewModel : BaseEditSettingViewModel<FilterItemSetting>, IDataErrorInfo
    {
        protected Dictionary<string, bool> _inputPropOverwriteChecker;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyFilterEvent"><see cref="Action<T>"/></param>
        public EditFilterSettingViewModel(Action<List<FilterItemSetting>> onApplyFilterEvent)
            : base(onApplyFilterEvent)
        {
            _inputPropOverwriteChecker = new Dictionary<string, bool>();
        }
        /// <summary>
        /// Initialize after creating object
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            _inputPropOverwriteChecker = new Dictionary<string, bool>();
        }
        /// <summary>
        /// Get valid status of all item 
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
        /// Get or set string value for filtering
        /// </summary>
        public string FilterString
        {
            get
            {
                return _itemMemberCandidate.StringValue;
            }
            set
            {
                _itemMemberCandidate.StringValue = value;
                OnPropertyChanged("FilterString");
            }
        }
        /// <summary>
        /// Get or set foreground color
        /// </summary>
        public string Foreground
        {
            get
            {
                return _itemMemberCandidate.Foreground;
            }
            set
            {
                _itemMemberCandidate.Foreground = value;
                OnPropertyChanged("Foreground");
            }
        }
        /// <summary>
        /// Get or set background color
        /// </summary>
        public string Background
        {
            get
            {
                return _itemMemberCandidate.Background;
            }
            set
            {
                _itemMemberCandidate.Background = value;
                OnPropertyChanged("Background");
            }
        }
        /// <summary>
        /// Get or set font style
        /// </summary>
        public string FontStyle
        {
            get
            {
                return _itemMemberCandidate.FontStyle;
            }
            set
            {
                _itemMemberCandidate.FontStyle = value;
                OnPropertyChanged("FontStyle");
            }
        }
        /// <summary>
        /// Get or set column name of log record
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
                //refresh the FilterString validation
                OnPropertyChanged("FilterString");
            }
        }
        /// <summary>
        /// Get all system log items
        /// </summary>
        public abstract List<ValueDisplayPair<string, string>> AllLogItems { get;}



        protected FilterItemSetting _doubleClickedCandidate;
        /// <summary>
        /// Get or set item when user double click on
        /// </summary>
        public FilterItemSetting DoubleClickedCandidate
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

        protected DelegateCommand _editForeGroundCommand;
        /// <summary>
        /// Command interface for editing foreground
        /// </summary>
        public ICommand EditForeGroundCommand
        {
            get
            {
                if (_editForeGroundCommand == null)
                {
                    _editForeGroundCommand = new DelegateCommand(EditForeGroundCL);
                }
                return _editForeGroundCommand;
            }
        }
        /// <summary>
        /// Command for editing ground
        /// </summary>
        protected virtual void EditForeGroundCL()
        {
            var colorString = GetColorStringFromColorPicker(Foreground);
            if (colorString != null)
            {
                Foreground = colorString;
            }
        }

        protected DelegateCommand _editBackGroundCommand;
        /// <summary>
        /// Command interface for editing background
        /// </summary>
        public ICommand EditBackGroundCommand
        {
            get
            {
                if (_editBackGroundCommand == null)
                {
                    _editBackGroundCommand = new DelegateCommand(EditBackGroundCL);
                }
                return _editBackGroundCommand;
            }
        }
        /// <summary>
        /// Command for editing background
        /// </summary>
        protected virtual void EditBackGroundCL()
        {
            var colorString = GetColorStringFromColorPicker(Background);
            if (colorString != null)
            {
                Background = colorString;
            }
        }

        protected DelegateCommand _editFontStyleCommand;
        /// <summary>
        /// Command interface for editing font style
        /// </summary>
        public ICommand EditFontStyleCommand
        {
            get
            {
                if (_editFontStyleCommand == null)
                {
                    _editFontStyleCommand = new DelegateCommand(EditFontStyleCL);
                }
                return _editFontStyleCommand;
            }
        }
        /// <summary>
        /// Command for editing font style
        /// </summary>
        protected virtual void EditFontStyleCL()
        {
            SetFontStyleDialogViewModel dlg = new SetFontStyleDialogViewModel(
                (x => FontStyle = x), FontStyle);
            dlg.ShowDialog(this);
        }

        protected DelegateCommand _overwriteItemSettingCommand;
        /// <summary>
        /// Command interface for overwriting item
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
        /// Command for overwriting item
        /// </summary>
        protected virtual void OverwriteItemSettingCL()
        {
            ItemSettingList.Remove(DoubleClickedCandidate);
            ItemSettingList.Add(_itemMemberCandidate);
            DoubleClickedCandidate = null;
        }
        /// <summary>
        /// Get default log item
        /// </summary>
        /// <returns></returns>
        protected abstract string GetDefaultLogItem();
        /// <summary>
        /// Get color string from color picker
        /// </summary>
        /// <param name="hex">Hexa color string</param>
        /// <returns>Valid hexa string for displaying</returns>
        protected virtual string GetColorStringFromColorPicker(String hex)
        {
            ColorPicker colorPicker = new ColorPicker();
            colorPicker.Color = System.Drawing.ColorTranslator.FromHtml(hex);
            if (colorPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color color = colorPicker.Color;
                StringBuilder strBuild = new StringBuilder();
                strBuild.AppendFormat("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
                return strBuild.ToString();
            }
            colorPicker.Dispose();
            return hex;
        }
        /// <summary>
        /// Create new filter item record and set default value
        /// </summary>
        protected override void CreateNewAndSetCandidateDefaultValue()
        {
            _itemMemberCandidate = new FilterItemSetting();
            Name = String.Empty;
            FilterString = String.Empty;
            LogItem = GetDefaultLogItem();
            Foreground = ConfigValue.DefaultFilterItemForegroundColor;
            Background = ConfigValue.DefaultFilterItemBackgroundColor;
            FontStyle = ConfigValue.DefaultFilterItemFontStyle;
            _itemMemberCandidate.Enabled = true;
            
        }

        /// <summary>
        /// Process for changing value
        /// </summary>
        protected virtual void OnCandidateValueChange()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("FilterString");
            OnPropertyChanged("Foreground");
            OnPropertyChanged("Background");
            OnPropertyChanged("FontStyle");
            OnPropertyChanged("LogItem");
        }
        /// <summary>
        /// Apply filter setting item list
        /// </summary>

        protected override void ApplyCL()
        {
            base.ApplyCL();
            //DoubleClickedCandidate = null;
        }
        /// <summary>
        /// Delete filter item setting
        /// </summary>
        /// <param name="itemsToDelete"></param>
        protected override void DeleteItemSetting(IList<object> itemsToDelete)
        {
            if (itemsToDelete.Contains(DoubleClickedCandidate))
            {
                DoubleClickedCandidate = null;
            }
            base.DeleteItemSetting(itemsToDelete);
            //Check duplicate after delete
            OnPropertyChanged("Name");
            OnPropertyChanged("FilterString");
        }
        /// <summary>
        /// Add new item setting
        /// </summary>
        protected override void AddItemSettingCL()
        {
            FilterItemSetting item = _itemMemberCandidate.Copy();
            item.StringValue = item.StringValue.Trim();
            ItemSettingList.Add(item);
            CreateNewAndSetCandidateDefaultValue();
        }

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
                    case "FilterString":
                        errorMessage = _itemMemberCandidate["StringValue"];
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
                                //When name is duplicated
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
                        case "FilterString":
                            {
                                var item = ItemSettingList.SingleOrDefault(x => x.StringValue.Trim().ToLower() == FilterString.Trim().ToLower() && x.LogItem.ToLower() == LogItem.Trim().ToLower());
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
                if (String.IsNullOrEmpty(errorMessage))
                {
                    //hard code.
                    if (ItemSettingList.Count == 15)
                    {
                        errorMessage = Properties.Resources.MaximumFilterItemErrorMessage;
                        _inputPropOverwriteChecker[propertyName] = true;
                        isOverwriteCheckerAlreadySet = true;
                    }
                }
                if (!isCheckerAlreadySet)
                {
                    _inputPropChecker[propertyName] = String.IsNullOrEmpty(errorMessage);
                }
                if(!isOverwriteCheckerAlreadySet)
                {
                    _inputPropOverwriteChecker[propertyName] = String.IsNullOrEmpty(errorMessage);
                }
                return errorMessage;
            }
        }

        #endregion
    }
}
