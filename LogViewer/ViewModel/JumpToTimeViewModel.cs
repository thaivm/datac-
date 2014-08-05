using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using LogViewer.Model;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class presentation for jump to time window
    /// </summary>
    /// <typeparam name="T">T is CCSLogRecord or CXDILogRecord</typeparam>
    class JumpToTimeViewModel<T> : BaseWindowViewModel where T : BaseLogRecord
    {
        /// <summary>
        /// Action OnShowRecordWithDateTimeEvent by date and time
        /// </summary>
        protected event Action<string,string> OnShowRecordWithDateTimeEvent;
        /// <summary>
        /// Get or set Collection ListYear.
        /// </summary>
        protected ObservableCollection<string> _listYear;
        public ObservableCollection<string> ListYear
        {
            get
            {
                return _listYear;
            }
            set
            {
                _listYear = value;
                OnPropertyChanged("ListYear");
            }
        }
        /// <summary>
        /// Get or set Collection ListMonth.
        /// </summary>
        protected ObservableCollection<string> _listMonth;
        public ObservableCollection<string> ListMonth
        {
            get
            {
                return _listMonth;
            }
            set
            {
                _listMonth = value;
                OnPropertyChanged("ListMonth");
            }
        }
        /// <summary>
        /// Get or set Collection ListDay.
        /// </summary>
        protected ObservableCollection<string> _listDay;
        public ObservableCollection<string> ListDay
        {
            get
            {
                return _listDay;
            }
            set
            {
                _listDay = value;
                OnPropertyChanged("ListDay");
            }
        }
        /// <summary>
        /// Get or set Collection ListHour.
        /// </summary>
        protected ObservableCollection<string> _listHour;
        public ObservableCollection<string> ListHour
        {
            get
            {
                return _listHour;
            }
            set
            {
                _listHour = value;
                OnPropertyChanged("ListHour");
            }
        }
        /// <summary>
        /// Get or set Collection ListMinute.
        /// </summary>
        protected ObservableCollection<string> _listMinute;
        public ObservableCollection<string> ListMinute
        {
            get
            {
                return _listMinute;
            }
            set
            {
                _listMinute = value;
                OnPropertyChanged("ListMinute");
            }
        }
        /// <summary>
        /// Get or set Collection ListSecond.
        /// </summary>
        protected ObservableCollection<string> _listSecond;
        public ObservableCollection<string> ListSecond
        {
            get
            {
                return _listSecond;
            }
            set
            {
                _listSecond = value;
                OnPropertyChanged("ListSecond");
            }
        }
        /// <summary>
        /// Get or set property Year.
        /// </summary>
        protected string _year;
        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }
        /// <summary>
        /// Get or set property Month.
        /// </summary>
        protected string _month;
        public string Month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
                OnPropertyChanged("Month");
            }
        }
        /// <summary>
        /// Get or set property Hour.
        /// </summary>
        protected string _day;
        public string Day
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
                OnPropertyChanged("Day");
            }
        }
        /// <summary>
        /// Get or set property Year.
        /// </summary>
        protected string _hour;
        public string Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                _hour = value;
                OnPropertyChanged("Hour");
            }
        }
        /// <summary>
        /// Get or set property Minute.
        /// </summary>
        protected string _minute;
        public string Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = value;
                OnPropertyChanged("Minute");
            }
        }
        /// <summary>
        /// Get or set property Second.
        /// </summary>
        protected string _second;
        public string Second
        {
            get
            {
                return _second;
            }
            set
            {
                _second = value;
                OnPropertyChanged("Second");
            }
        }
        /// <summary>
        /// Get or set property MiliSecond.
        /// </summary>
        protected string _miliSecond;
        public string MiliSecond
        {
            get
            {
                return _miliSecond;
            }
            set
            {
                _miliSecond = value;
                OnPropertyChanged("MiliSecond");
            }
        }
        /// <summary>
        /// Get or set property Message1.
        /// </summary>
        protected string _message1;
        public string Message1
        {
            get
            {
                return _message1;
            }
            set
            {
                _message1 = value;
            }
        }
        /// <summary>
        /// Get or set property Message2.
        /// </summary>
        protected string _message2;
        public string Message2
        {
            get
            {
                return _message2;
            }
            set
            {
                _message2 = value;
            }
        }
        /// <summary>
        /// Date-time begin in log. 
        /// </summary>
        protected DateTime _from;
        /// <summary>
        /// Date-time end in log
        /// </summary>
        protected DateTime _to;
        /// <summary>
        /// Initializes a new instance of the jumpToTimeViewModel class.
        /// </summary>
        /// <param name="onShowRecordWithDateTimeEvent">Event when Click button jump to</param>
        /// <param name="firstLog">First record in log</param>
        /// <param name="lastLog">Last record in log</param>
        public JumpToTimeViewModel(Action<string,string> onShowRecordWithDateTimeEvent,T firstLog, T lastLog)
        {
            _from = Convert.ToDateTime(firstLog.Date + " " + firstLog.Time);
            _to = Convert.ToDateTime(lastLog.Date + " " + lastLog.Time);
            ListYear = new ObservableCollection<string>(LoadYear(_from, _to));
            Year = ListYear.First();
            ListMonth = new ObservableCollection<string>(LoadMonth(_from, _to));
            Month = ListMonth.First();
            ListDay = new ObservableCollection<string>(LoadDay(_from, _to));
            Day = ListDay.First();
            ListHour = new ObservableCollection<string>(LoadHour());
            Hour = ListHour.First();
            ListMinute = new ObservableCollection<string>(LoadMinuterOrSecond());
            Minute = ListMinute.First();
            ListSecond = new ObservableCollection<string>(LoadMinuterOrSecond());
            Second = ListSecond.First();
            Message1 = Properties.Resources.Old + firstLog.Date + " " + firstLog.Time;
            Message2 = Properties.Resources.New + lastLog.Date + " " + lastLog.Time;
            OnShowRecordWithDateTimeEvent = onShowRecordWithDateTimeEvent;
        }
        /// <summary>
        /// Load year from date from and date to
        /// </summary>
        /// <param name="dtFrom">Date-time from</param>
        /// <param name="dtTo">Date-time to</param>
        /// <returns>List string have year</returns>
        protected List<string> LoadYear(DateTime dtFrom, DateTime dtTo)
        {
            List<string> data = new List<string>();
            int YearFrom = dtFrom.Year;
            int YearTo = dtTo.Year;
            for (int i = YearFrom; i <= YearTo; i++)
            {
                data.Add(i.ToString());
            }
            return data;
        }
        /// <summary>
        /// Load month from date from and date to
        /// </summary>
        /// <param name="from">Date-time from</param>
        /// <param name="to">Date-time to</param>
        /// <returns>List string have month</returns>
        protected List<string> LoadMonth(DateTime from, DateTime to)
        {
            List<string> data = new List<string>();
            if (ListYear.Count < 2)
            {
                int MonthFrom = from.Month;
                int MonthTo = to.Month;
                for (int i = MonthFrom; i <= MonthTo; i++)
                {
                    string month = i.ToString();
                    if (month.Length == 1)
                    {
                        //hard code.
                        month = "0" + month;
                    }
                    data.Add(month);
                }
            }
            else
            {
                //hard code
                for (int i = 1; i <= 12; i++)
                {
                    string month = i.ToString();
                    if (month.Length == 1)
                    {
                        month = "0" + month;
                    }
                    data.Add(month);
                }
            }
            return data;
        }
        /// <summary>
        /// Load day from date from and date to
        /// </summary>
        /// <param name="from">Date-time from</param>
        /// <param name="to">Date-time to</param>
        /// <returns>List string have day</returns>
        protected List<string> LoadDay(DateTime from, DateTime to)
        {
            List<string> data = new List<string>();
            //hard code.
            if (ListYear.Count < 2 && ListMonth.Count < 2)
            {
                int DayFrom = from.Day;
                int DayTo = to.Day;
                for (int i = DayFrom; i <= DayTo; i++)
                {
                    string day = i.ToString();
                    if (day.Length == 1)
                    {
                        day = "0" + day;
                    }
                    data.Add(day);
                }
            }
            else
            {
                //hard code
                for (int i = 1; i <= 31; i++)
                {
                    string day = i.ToString();
                    //hard code
                    if (day.Length == 1)
                    {
                        day = "0" + day;
                    }
                    data.Add(day);
                }
            }
            return data;
        }
        /// <summary>
        /// Load hour, hour from 00->23
        /// </summary>
        /// <returns>List string have month</returns>
        protected List<string> LoadHour()
        {
            List<string> data = new List<string>();
            //hard code
            for (int i = 0; i <= 23; i++)
            {
                string hour = i.ToString();
                //hard code
                if (hour.Length == 1)
                {
                    hour = "0" + hour;
                }
                data.Add(hour);
            }
            return data;
        }
        /// <summary>
        /// Load minuter of second, minuter or second from 00->59
        /// </summary>
        /// <returns>List string have Minuter or second</returns>
        protected List<string> LoadMinuterOrSecond()
        {
            List<string> data = new List<string>();
            //hard code
            for (int i = 0; i <= 59; i++)
            {
                string minuterOrSecond = i.ToString();
                if (minuterOrSecond.Length == 1)
                {
                    minuterOrSecond = "0" + minuterOrSecond;
                }
                data.Add(minuterOrSecond);
            }
            return data;
        }
        /// <summary>
        /// Get or set Command of button jump to time.
        /// </summary>
        protected DelegateCommand _jumpToTimeCommand;
        public ICommand JumpToLineCommand
        {
            get
            {
                if (_jumpToTimeCommand == null)
                {
                    _jumpToTimeCommand = new DelegateCommand(JumpToTimeCommandCL, () => IsEnableButton());
                }
                return _jumpToTimeCommand;
            }
        }

        /// <summary>
        /// function check button jum to can execute or not.
        /// </summary>
        /// <returns>Return a bool value. true: can execute, false: cannot execute </returns>
        protected bool IsEnableButton()
        {
            String date = Year + "/" + Month + "/" + Day;
            if (MiliSecond == null || MiliSecond.Trim().Equals(String.Empty))
            {
                date += " " + Hour + ":" + Minute + ":" + Second;
            }
            else
            {
                date += " " + Hour + ":" + Minute + ":" + Second + "." + MiliSecond;
            }
            try
            {
                if (Convert.ToDateTime(date).CompareTo(_from) < 0 || Convert.ToDateTime(date).CompareTo(_to) > 0)
                {
                    return false;
                }
            }
            catch {
                //Catch in case Japanese number
                return false;
            }
            return true;
        }
        /// <summary>
        /// Function callback when click button jump to time.
        /// </summary>
        protected virtual void JumpToTimeCommandCL()
        {
            String Date = Year + "/" + Month + "/" + Day;
            String Time = Hour + ":" + Minute + ":" + Second + "." + MiliSecond;
            OnShowRecordWithDateTimeEvent(Date, Time);
        }
    }
}
