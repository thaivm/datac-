using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using System.Collections.ObjectModel;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// View model for show SetLogDisplay window
    /// </summary>
    public class SetLogDisplayViewModel : BaseApplyWindowViewModel<List<List<LogDisplay>>>
    {
        /// <summary>
        /// Get or set CCSDisplaySettings
        /// </summary>
        protected ObservableCollection<LogDisplayRecordViewModel> _ccsDisplaySettings;
        public ObservableCollection<LogDisplayRecordViewModel> CCSDisplaySettings
        {
            get
            {
                return _ccsDisplaySettings;
            }
            set
            {
                _ccsDisplaySettings = value;
                OnPropertyChanged("CCSDisplaySettings");
            }
        }

        /// <summary>
        /// Get or set CXDIDisplayLogSettings
        /// </summary>
        protected ObservableCollection<LogDisplayRecordViewModel> _cxdiDisplaySettings;
        public ObservableCollection<LogDisplayRecordViewModel> CXDIDisplaySettings
        {
            get
            {
                return _cxdiDisplaySettings;
            }
            set
            {
                _cxdiDisplaySettings = value;
                OnPropertyChanged("CXDIDisplaySettings");
            }
        }
        /// <summary>
        /// Initializes a new instance of the SetLogDisplayViewModel class.
        /// </summary>
        /// <param name="onApplyLogDisplay">Action run when click button Apply</param>
        public SetLogDisplayViewModel(Action<List<List<LogDisplay>>> onApplyLogDisplay)
            : base(onApplyLogDisplay)
        {
            _ccsDisplaySettings = new ObservableCollection<LogDisplayRecordViewModel>();
            _cxdiDisplaySettings = new ObservableCollection<LogDisplayRecordViewModel>();
        }

        /// <summary>
        /// Load data when show window SetLogDisplay
        /// </summary>
        /// <param name="ccsDisplaySettings">List LogDislay of CCS</param>
        /// <param name="cxdiDisplaySettings">List LogDisplay of CXDI</param>
        public virtual void LoadData(List<LogDisplay> ccsDisplaySettings, List<LogDisplay> cxdiDisplaySettings)
        {
            foreach (var displaySetting in ccsDisplaySettings)
            {
                LogDisplayRecordViewModel logDisplayRecordViewModel = new LogDisplayRecordViewModel(displaySetting);
                CCSDisplaySettings.Add(logDisplayRecordViewModel);
            }
            foreach (var displaySetting in cxdiDisplaySettings)
            {
                LogDisplayRecordViewModel logDisplayRecordViewModel = new LogDisplayRecordViewModel(displaySetting);
                CXDIDisplaySettings.Add(logDisplayRecordViewModel);
            }
        }

        /// <summary>
        /// Get Data to apply
        /// </summary>
        /// <returns></returns>
        protected override List<List<LogDisplay>> GetDataToApply()
        {
            List<List<LogDisplay>> list = new List<List<LogDisplay>>();
            List<LogDisplay> listCCS = new List<LogDisplay>();
            foreach (var logDisplay in CCSDisplaySettings)
            {
                listCCS.Add(new LogDisplay { key = logDisplay.Key, value = logDisplay.Value });
            }
            List<LogDisplay> listCXDI = new List<LogDisplay>();
            foreach (var logDisplay in CXDIDisplaySettings)
            {
                listCXDI.Add(new LogDisplay { key = logDisplay.Key, value = logDisplay.Value });
            }
            list.Add(listCCS);
            list.Add(listCXDI);
            return list;
        }

        /// <summary>
        /// Get or set Error message
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
        /// Check button apply can execute or not
        /// </summary>
        protected override bool CanApply
        {
            get
            {
                var isValidCCSSetting = _ccsDisplaySettings.Where(x => x.Value == true).Count() > 0;
                var isValidCXDISetting = _cxdiDisplaySettings.Where(x => x.Value == true).Count() > 0;
                var result = isValidCCSSetting && isValidCXDISetting;
                if (!result)
                {
                    ErrorMessage = Properties.Resources.SelectLogKindErrorMessage;
                }
                else
                {
                    ErrorMessage = String.Empty;
                }
                return result;
            }
        }
    }
}
