using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for setting range parameter for graph
    /// </summary>
    public class SetRangeOfGraphViewModel : BaseApplyWindowViewModel<GraphRangeSetting>
    {
        Dictionary<string, bool> _inputPropChecker;
        GraphRangeSetting _setting;
        /// <summary>
        /// Get or set <see cref="GraphRangeSetting"/>
        /// </summary>
        public GraphRangeSetting Setting
        {
            get
            {
                return _setting;
            }
            set
            {
                _setting = value;
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyEvent"><see cref="Action<T>"/></param>
        public SetRangeOfGraphViewModel(Action<GraphRangeSetting> onApplyEvent)
            : base(onApplyEvent)
        {
            //_setting = defaultValue.Copy();
            //Min = from.ToString("yyyy-MM-dd HH:mm");
            //Max = to.ToString("yyyy-MM-dd HH:mm");
            _inputPropChecker = new Dictionary<string, bool>();
        }
        /// <summary>
        /// Get or set From date
        /// </summary>
        public DateTime From
        {
            get
            {
                return _setting.From;
            }
            set
            {
                _setting.From = value;
                OnPropertyChanged("From");
            }
        }
        /// <summary>
        /// Get or set To date
        /// </summary>
        public DateTime To
        {
            get
            {
                return _setting.To;
            }
            set
            {
                _setting.To = value;
                OnPropertyChanged("To");
            }
        }
        protected String _min;
        /// <summary>
        /// Get or set Min range
        /// </summary>
        public String Min
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
                OnPropertyChanged("Min");
            }
        }
        protected String _max;
        /// <summary>
        /// Get or set Max range
        /// </summary>
        public String Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
                OnPropertyChanged("Max");
            }
        }
        /// <summary>
        /// Get or set From range of the first Y axis
        /// </summary>
        public double FirstYRangeFrom
        {
            get
            {
                return _setting.FirstYRangeFrom;
            }
            set
            {
                _setting.FirstYRangeFrom = value;
                OnPropertyChanged("FirstYRangeFrom");
            }
        }
        /// <summary>
        /// Get or set To range of the first Y axis
        /// </summary>
        public double FirstYRangeTo
        {
            get
            {
                return _setting.FirstYRangeTo;
            }
            set
            {
                _setting.FirstYRangeTo = value;
                OnPropertyChanged("FirstYRangeTo");
            }
        }
        /// <summary>
        /// Get or set From range of the second Y axis
        /// </summary>
        public double SecondYRangeFrom
        {
            get
            {
                return _setting.SecondYRangeFrom;
            }
            set
            {
                _setting.SecondYRangeFrom = value;
                OnPropertyChanged("SecondYRangeFrom");
            }
        }
        /// <summary>
        /// Get or set To range of the second Y axis
        /// </summary>
        public double SecondYRangeTo
        {
            get
            {
                return _setting.SecondYRangeTo;
            }
            set
            {
                _setting.SecondYRangeTo = value;
                OnPropertyChanged("SecondYRangeTo");
            }
        }
        /// <summary>
        /// Get or set error status of From value of the first Y axis
        /// </summary>
        public bool IsErrorAtFirstYRangeFrom
        {
            get
            {
                return !_inputPropChecker["FirstYRangeFrom"];
            }
            set
            {
                _inputPropChecker["FirstYRangeFrom"] = !value;
            }
        }
        /// <summary>
        /// Get or set error status of To value of the first Y axis
        /// </summary>

        public bool IsErrorAtFirstYRangeTo
        {
            get
            {
                return !_inputPropChecker["FirstYRangeTo"];
            }
            set
            {
                _inputPropChecker["FirstYRangeTo"] = !value;
            }
        }

        /// <summary>
        /// Get or set error status of To value of the second Y axis
        /// </summary>
        public bool IsErrorAtSecondYRangeTo
        {
            get
            {
                return !_inputPropChecker["SecondYRangeTo"];
            }
            set
            {
                _inputPropChecker["SecondYRangeTo"] = !value;
            }
        }
        /// <summary>
        /// Get or set error status of From value of the second Y axis
        /// </summary>

        public bool IsErrorAtSecondYRangeFrom
        {
            get
            {
                return !_inputPropChecker["SecondYRangeFrom"];
            }
            set
            {
                _inputPropChecker["SecondYRangeFrom"] = !value;
            }
        }

        protected string _errorMessage;
        /// <summary>
        /// Get or set error message
        /// </summary>
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
        /// Get <see cref="GraphRangeSetting"/>
        /// </summary>
        /// <returns></returns>
        protected override GraphRangeSetting GetDataToApply()
        {
            return _setting;
        }
        /// <summary>
        /// Get valid range status of the first Y axis
        /// </summary>
        protected bool IsValidFirstYRange
        {
            get
            {
                bool val = FirstYRangeFrom < FirstYRangeTo;
                if (!val)
                    ErrorMessage = Properties.Resources.FirstYToGreaterThanFromValueErrorMessage;
                return val;
            }
        }
        /// <summary>
        /// Get valid range status of the second Y axis
        /// </summary>

        protected bool IsValidSecondYRange
        {
            get
            {
                bool val = SecondYRangeFrom < SecondYRangeTo;
                if (!val)
                    ErrorMessage = Properties.Resources.SecondYToGreaterThanFromValueErrorMessage;
                return val;
            }
        }
        /// <summary>
        /// Get valid status of date time
        /// </summary>

        protected bool IsValidDateTime
        {
            get
            {
                bool val = From < To;
                if (!val)
                    ErrorMessage = Properties.Resources.DateTimeToGreaterThanFromValueErrorMessage;
                return val;
            }
        }
        /// <summary>
        /// Get status of can apply
        /// </summary>
        protected override bool CanApply
        {
            get
            {
                ErrorMessage = String.Empty;
                bool isAllValid = true;
                isAllValid &= IsValidFirstYRange && IsValidSecondYRange && IsValidDateTime;
                foreach (KeyValuePair<string, bool> k in _inputPropChecker)
                {
                    isAllValid &= k.Value;
                }
                return isAllValid;
            }
        }
    }
}
