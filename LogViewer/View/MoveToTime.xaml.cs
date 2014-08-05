using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for MoveToTime.xaml
    /// </summary>
    public partial class MoveToTime : Window
    {
        //private MainWindow _parent;
        //DateTime _MaxDate;
        //public DateTime MaxDate
        //{
        //    get
        //    {
        //        return _MaxDate;
        //    }
        //    set
        //    {
        //        _MaxDate = value;
        //    }
        //}
        //DateTime _MinDate;
        //public DateTime MinDate
        //{
        //    get
        //    {
        //        return _MinDate;
        //    }
        //    set
        //    {
        //        _MinDate = value;
        //    }
        //}
        //List<string> _CCSLogKeyNoMiliSecond;

        //public List<string> CCSLogKeyNoMiliSecond
        //{
        //    get
        //    {
        //        return _CCSLogKeyNoMiliSecond;
        //    }
        //    set
        //    {
        //        _CCSLogKeyNoMiliSecond = value;
        //    }
        //}
        //List<string> _CCSLogKeyHasMiliSecond;
        //public List<string> CCSLogKeyHasMiliSecond
        //{
        //    get
        //    {
        //        return _CCSLogKeyHasMiliSecond;
        //    }
        //    set
        //    {
        //        _CCSLogKeyHasMiliSecond = value;
        //    }
        //}
        public MoveToTime()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //InitData();
        }

        private void InitData()
        {
            //MoveToTime_Year_ComboBox.ItemsSource = LoadYear(MinDate, MaxDate);
            //MoveToTime_Year_ComboBox.SelectedIndex = 0;
            //MoveToTime_Month_ComboBox.ItemsSource = LoadMonth();
            //MoveToTime_Month_ComboBox.SelectedIndex = 0;
            //MoveToTime_Day_ComboBox.ItemsSource = LoadDay();
            //MoveToTime_Day_ComboBox.SelectedIndex = 0;
            //MoveToTime_Hour_ComboBox.ItemsSource = LoadHour();
            //MoveToTime_Hour_ComboBox.SelectedIndex = 0;
            //MoveToTime_Minute_ComboBox.ItemsSource = LoadMinuterOrSecond();
            //MoveToTime_Minute_ComboBox.SelectedIndex = 0;
            //MoveToTime_Second_ComboBox.ItemsSource = LoadMinuterOrSecond();
            //MoveToTime_Second_ComboBox.SelectedIndex = 0;
            //string From = _MinDate.ToString("yyyy/MM/dd hh:mm:ss.fff");
            //string To = _MaxDate.ToString("yyyy/MM/dd hh:mm:ss.fff");
            //MoveToTime_Warning1.Content = "Old: " + From;
            //MoveToTime_Warning2.Content = "New: " + To;
        }

        private List<string> LoadYear(DateTime dtFrom, DateTime dtTo)
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

        private List<string> LoadMonth()
        {
            List<string> data = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                string month = i.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
                data.Add(month);
            }
            return data;
        }

        private List<string> LoadDay()
        {
            List<string> data = new List<string>();
            for (int i = 1; i <= 31; i++)
            {
                string day = i.ToString();
                if (day.Length == 1)
                {
                    day = "0" + day;
                }
                data.Add(day);
            }
            return data;
        }

        private List<string> LoadHour()
        {
            List<string> data = new List<string>();
            for (int i = 0; i <= 23; i++)
            {
                string hour = i.ToString();
                if (hour.Length == 1)
                {
                    hour = "0" + hour;
                }
                data.Add(hour);
            }
            return data;
        }

        private List<string> LoadMinuterOrSecond()
        {
            List<string> data = new List<string>();
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
        
        private void textBoxValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextBoxTextAllowed(e.Text);
        }

        private void textBoxValue_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String Text1 = (String)e.DataObject.GetData(typeof(String));
                if (!TextBoxTextAllowed(Text1)) e.CancelCommand();
            }
            else e.CancelCommand();
        }

        private Boolean TextBoxTextAllowed(String Text2)
        {
            return Array.TrueForAll<Char>(Text2.ToCharArray(),
                delegate(Char c) { return Char.IsDigit(c) || Char.IsControl(c); });
        } 
        
        private void MoveToTime_Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MoveToTime_Button_JumpTo_Click(object sender, RoutedEventArgs e)
        {
            //String Millisecond = MoveToTime_Millisecond_TextBox.Text.Trim();
            //string dateTime = "";
            //if (Millisecond.Length == 0)
            //{
            //    DateTime dateTimeSearch = new DateTime(Convert.ToInt32(MoveToTime_Year_ComboBox.SelectedValue),
            //        Convert.ToInt32(MoveToTime_Month_ComboBox.SelectedValue), Convert.ToInt32(MoveToTime_Day_ComboBox.SelectedValue),
            //        Convert.ToInt32(MoveToTime_Hour_ComboBox.SelectedValue), Convert.ToInt32(MoveToTime_Minute_ComboBox.SelectedValue),
            //        Convert.ToInt32(MoveToTime_Second_ComboBox.SelectedValue));
            //    dateTime = dateTimeSearch.ToString("yyyyMMddhhmmss");
            //    if (CCSLogKeyNoMiliSecond.Contains(dateTime))
            //    {
            //        int Num = CCSLogKeyNoMiliSecond.IndexOf(dateTime) + 1;
            //        setLineNumber(Num);
            //        this.Close();
            //    }
            //    else
            //    {
            //        MoveToTime_Warning1.Content = "Do not find the time in log.";
            //        MoveToTime_Warning2.Content = "Please re-input time.";
            //    }
            //}
            //else
            //{
            //    DateTime dateTimeSearch = new DateTime(Convert.ToInt32(MoveToTime_Year_ComboBox.SelectedValue),
            //        Convert.ToInt32(MoveToTime_Month_ComboBox.SelectedValue), Convert.ToInt32(MoveToTime_Day_ComboBox.SelectedValue),
            //        Convert.ToInt32(MoveToTime_Hour_ComboBox.SelectedValue), Convert.ToInt32(MoveToTime_Minute_ComboBox.SelectedValue),
            //        Convert.ToInt32(MoveToTime_Second_ComboBox.SelectedValue), Convert.ToInt32(Millisecond));
            //    dateTime = dateTimeSearch.ToString("yyyyMMddhhmmssfff");
            //    if (CCSLogKeyHasMiliSecond.Contains(dateTime))
            //    {
            //        int Num = CCSLogKeyHasMiliSecond.IndexOf(dateTime) + 1;
            //        setLineNumber(Num);
            //        this.Close();
            //    }
            //    else
            //    {
            //        MoveToTime_Warning1.Content = "Do not find the time in log.";
            //        MoveToTime_Warning2.Content = "Please re-input time.";
            //    }
            //}
            this.Close();
        }
        private void setLineNumber(int Line)
        {
            //_parent = (MainWindow)this.Owner;
            //_parent.SelectRowByIndex(Line);
        }
    }
}
