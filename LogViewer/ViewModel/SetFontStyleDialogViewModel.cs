using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Drawing;
using LogViewer.MVVMHelper;
using System.Collections.ObjectModel;
using LogViewer.Model;
using LogViewer.CustomException;
namespace LogViewer.ViewModel
{
    /// <summary>
    /// ViewModel show select font style dialog
    /// </summary>
    class SetFontStyleDialogViewModel : BaseApplyWindowViewModel<string>
    {
        /// <summary>
        /// Initializes a new instance of the SetFontStyleDialogViewModel class.
        /// </summary>
        /// <param name="onApplyEvent">Action run when click button apply</param>
        /// <param name="defaultValue">default Value when initialize</param>
        public SetFontStyleDialogViewModel(Action<string> onApplyEvent, string defaultValue)
            :base(onApplyEvent)
        {
            AllFontStyle = new ObservableCollection<string>(ConfigValue.FilterSettingFontStyles.AllFontStyle);
            SelectedValue = defaultValue;
        }

        /// <summary>
        /// Get or set AllFontStyle property
        /// </summary>
        protected ObservableCollection<string> _allFontStyle;
        public ObservableCollection<string> AllFontStyle
        {
            get
            {
                return _allFontStyle;
            }
            set
            {
                _allFontStyle = value;
                OnPropertyChanged("AllFontStyle");
            }
        }

        /// <summary>
        /// Get or set SelectedValue
        /// </summary>
        protected string _selectedValue;
        public string SelectedValue
        {
            get
            {
                return _selectedValue;
            }
            set
            {
                if (!ConfigValue.FilterSettingFontStyles.AllFontStyle.Contains(value))
                    throw new DataValueNotSupportedException();
                _selectedValue = value;
                OnPropertyChanged("SelectedValue");
            }
        }
        /// <summary>
        /// Get Data to Apply
        /// </summary>
        /// <returns></returns>
        protected override string GetDataToApply()
        {
            return SelectedValue;
        }
    }
}
