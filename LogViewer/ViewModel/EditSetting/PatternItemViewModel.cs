using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using LogViewer.Model;
using System.Windows.Input;
using Microsoft.Windows.Controls;
using LogViewer.MVVMHelper;
using LogViewer.Util;
using System.ComponentModel;
using LogViewer.Business;
namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for setting pattern item
    /// </summary>
    public class PatternItemViewModel : BaseApplyWindowViewModel<PatternItemSetting>, IDataErrorInfo
    {
        public PatternItemSetting _patternItem;
        protected Dictionary<string, bool> _inputPropChecker;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyAction"><see cref="Action"/></param>
        public PatternItemViewModel(Action<PatternItemSetting> onApplyAction)
            : base(onApplyAction)
        {

        }
        /// <summary>
        /// Load pattern setting item
        /// </summary>
        /// <param name="data"><see cref="PatternItemSetting"/></param>
        public void LoadItem(PatternItemSetting data)
        {
            _patternItem = data.Copy();
            _inputPropChecker = new Dictionary<string, bool>();

            KeysListDataGridVM = new PatternItemKeysListDataGridViewModel(this);

            List<KeywordModel> temp = new List<KeywordModel>();
            foreach (var i in _patternItem.Keys)
            {
                temp.Add(new KeywordModel { Value = i });
            }
            temp = temp.FindAll(x => x.Value != null && !x.Value.Equals(String.Empty));
            KeysListDataGridVM.LoadData(temp);

            //KeysListDataGridVM.SourceList = KeysListDataGridVM.SourceList.Fi
        }
        /// <summary>
        /// Get status of can apply
        /// </summary>

        protected override bool CanApply
        {
            get
            {
                bool isAllValid = true;
                isAllValid &= KeysListDataGridVM.IsDataValid;
                foreach (KeyValuePair<string, bool> k in _inputPropChecker)
                {
                    isAllValid &= k.Value;
                }
                return isAllValid;
            }
        }

        protected PatternItemKeysListDataGridViewModel _keysListDataGridVM;
        /// <summary>
        /// Get or set <see cref="PatternItemKeysListDataGridViewModel"/>
        /// </summary>
        public PatternItemKeysListDataGridViewModel KeysListDataGridVM
        {
            get
            {
                return _keysListDataGridVM;
            }
            set
            {
                _keysListDataGridVM = value;
                OnPropertyChanged("KeysListDataGridVM");
            }
        }
        /// <summary>
        /// Get or set list of <see cref="ValueDisplayPair<string,string>"/>
        /// </summary>
        public IList<ValueDisplayPair<string, string>> TimeUnitList
        {
            get
            {
                var temp = new List<ValueDisplayPair<string, string>>();
                foreach (var i in ConfigValue.TimeUnits.AllTimeUnit)
                {
                    temp.Add(new ValueDisplayPair<string, string>()
                    {
                        Value = i,
                        Display = Utility.Translate(i)
                    });
                }
                return temp;
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
        /// <summary>
        /// Get or set root keyword
        /// </summary>
        public string RootKeyword
        {
            get
            {
                return _patternItem.RootKey;
            }
            set
            {
                _patternItem.RootKey = value;
                OnPropertyChanged("RootKeyword");
            }
        }
        /// <summary>
        /// Get or set time
        /// </summary>
        public ulong Time
        {
            get
            {
                return _patternItem.Time;
            }
            set
            {
                _patternItem.Time = value;
                OnPropertyChanged("Time");
            }
        }
        /// <summary>
        /// Get or set time unit
        /// </summary>
        public string TimeUnit
        {
            get
            {
                return _patternItem.TimeUnit;
            }
            set
            {
                _patternItem.TimeUnit = value;
                OnPropertyChanged("TimeUnit");
            }
        }
        /// <summary>
        /// Get or set name
        /// </summary>
        public string Name
        {
            get
            {
                return _patternItem.Name;
            }
            set
            {
                _patternItem.Name = value;
                OnPropertyChanged("Name");
            }
        }
        /// <summary>
        /// Get or set error status of time
        /// </summary>
        public bool IsErrorAtTime
        {
            get
            {
                return !_inputPropChecker["Time"];
            }
            set
            {
                _inputPropChecker["Time"] = !value;
            }
        }
        /// <summary>
        /// Get or set <see cref="PatternItemSetting"/>
        /// </summary>
        /// <returns><see cref="PatternItemSetting"/></returns>
        protected override PatternItemSetting GetDataToApply()
        {
            _patternItem.Keys.Clear();
            foreach (var i in KeysListDataGridVM.SourceList)
            {
                if (!String.IsNullOrEmpty(i.Value))
                    _patternItem.Keys.Add(i.Value);
            }
            return _patternItem;
        }
        /// <summary>
        /// Get error message
        /// </summary>
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        /// <summary>
        /// Reference to properties as index of array. Use for checking a properties is valid or not.
        /// </summary>
        /// <param name="propertyName">Properties name</param>
        /// <returns>Empty string when a properties is valid data.</returns>
        public string this[string propertyName]
        {
            get
            {
                bool isCheckerAlreadySet = false;
                string errorMessage = String.Empty;
                switch (propertyName)
                {
                    //hard code
                    case "Name":
                        errorMessage = _patternItem["Name"];
                        break;
                    case "RootKeyword":
                        errorMessage = _patternItem["RootKey"];
                        break;
                }
                if (String.IsNullOrEmpty(errorMessage))
                {
                    switch (propertyName)
                    {
                        //Check duplicate filter item name
                        case "Name":
                            {

                                break;
                            }
                    }
                }
                if (!isCheckerAlreadySet)
                {
                    _inputPropChecker[propertyName] = String.IsNullOrEmpty(errorMessage);
                }
                return errorMessage;
            }
        }
    }
}
