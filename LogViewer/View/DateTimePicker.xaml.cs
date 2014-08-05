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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Globalization;
namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for DateTimePicker.xaml
    /// </summary>
    public partial class DateTimePicker : UserControl
    {
        private const int FormatLengthOfLast = 2;
        private enum Direction : int
        {
            Previous = -1,
            Next = 1
        }


        public DateTimePicker()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            CalDisplay.DisplayDateStart = (DateTime)GetValue(MinimumDateProperty);
            CalDisplay.DisplayDateEnd = (DateTime)GetValue(MaximumDateProperty);
        }


        #region "Properties"

        public Nullable<System.DateTime> SelectedDate
        {
            get { return Convert.ToDateTime(GetValue(SelectedDateProperty)); }

            set { SetValue(SelectedDateProperty, value); }
        }


        public string DateFormat
        {
            get { return Convert.ToString(GetValue(DateFormatProperty)); }

            set { SetValue(DateFormatProperty, value); }
        }

        public System.DateTime MinimumDate
        {
            get { return Convert.ToDateTime(GetValue(MinimumDateProperty)); }
            set { SetValue(MinimumDateProperty, value); }
        }

        public System.DateTime MaximumDate
        {
            get { return Convert.ToDateTime(GetValue(MaximumDateProperty)); }

            set { SetValue(MaximumDateProperty, value); }
        }



        #endregion



        #region "Events"

        public event RoutedEventHandler DateChanged
        {
            add { AddHandler(DateChangedEvent, value); }
            remove { RemoveHandler(DateChangedEvent, value); }


        }

        public static readonly RoutedEvent DateChangedEvent = EventManager.RegisterRoutedEvent("DateChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DateTimePicker));

        public event RoutedEventHandler DateFormatChanged
        {

            add { this.AddHandler(DateFormatChangedEvent, value); }

            remove { this.RemoveHandler(DateFormatChangedEvent, value); }


        }

        public static readonly RoutedEvent DateFormatChangedEvent = EventManager.RegisterRoutedEvent("DateFormatChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DateTimePicker));

        #endregion


        #region "DependencyProperties"

        public static readonly DependencyProperty DateFormatProperty = DependencyProperty.Register("DateFormat", typeof(string), typeof(DateTimePicker), 
            new FrameworkPropertyMetadata("yyyy-MM-dd HH:mm", OnDateFormatChanged), new ValidateValueCallback(ValidateDateFormat));


        public static readonly DependencyProperty MaximumDateProperty = DependencyProperty.Register("MaximumDate", typeof(System.DateTime), typeof(DateTimePicker),
            new FrameworkPropertyMetadata(Convert.ToDateTime("2045-01-01 00:00"), new PropertyChangedCallback(OnInitMaximum), new CoerceValueCallback(CoerceMaxDate)));


        public static readonly DependencyProperty MinimumDateProperty = DependencyProperty.Register("MinimumDate", 
            typeof(System.DateTime), typeof(DateTimePicker),
            new FrameworkPropertyMetadata(Convert.ToDateTime("1900-01-01 00:00"), new PropertyChangedCallback(OnInitMinimum), new CoerceValueCallback(CoerceMinDate)));


        public static readonly DependencyProperty SelectedDateProperty = DependencyProperty.Register("SelectedDate", 
            typeof(Nullable<System.DateTime>), typeof(DateTimePicker), 
            new FrameworkPropertyMetadata(System.DateTime.Now, new PropertyChangedCallback(OnSelectedDateChanged), 
                new CoerceValueCallback(CoerceDate)));



        #endregion




        #region "EventHandlers"



        private void CalDisplay_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PopUpCalendarButton.IsChecked = false;
            var newDate = new System.DateTime(CalDisplay.SelectedDate.Value.Year, CalDisplay.SelectedDate.Value.Month, CalDisplay.SelectedDate.Value.Day, SelectedDate.Value.Hour, SelectedDate.Value.Minute, 0);
            if (newDate < MinimumDate)
                SelectedDate = MinimumDate;
            else if (newDate > MaximumDate)
                SelectedDate = MaximumDate;
            else
                SelectedDate = newDate;

        }



        private void DateDisplay_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selstart = DateDisplay.SelectionStart;
            FocusOnDatePart(selstart);

        }



        private void DateDisplay_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            //while ((!IsDate(DateDisplay.Text) || (DateDisplay.Text < MinimumDate) || (DateDisplay.Text > MaximumDate)) && DateDisplay.CanUndo)
            while ((!IsDate(DateDisplay.Text)) && DateDisplay.CanUndo)
            {
                DateDisplay.Undo();
            }

            if (IsDate(DateDisplay.Text) && SelectedDate != Convert.ToDateTime(DateDisplay.Text))
            {
                var newDate = Convert.ToDateTime(DateDisplay.Text);
                if (newDate < MinimumDate)
                    SelectedDate = MinimumDate;
                else if (newDate > MaximumDate)
                    SelectedDate = MaximumDate;
                else
                    SelectedDate = newDate;
                DateDisplay.Text = SelectedDate.Value.ToString(GetValue(DateFormatProperty).ToString());
            }

        }




        private void DateTimePicker_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            var selstart = DateDisplay.SelectionStart;
            while (!IsDate(DateDisplay.Text))
            {
                DateDisplay.Undo();
            }

            e.Handled = true;
            switch (e.Key)
            {


                case Key.Up:
                    SelectedDate = Increase(selstart, 1);
                    FocusOnDatePart(selstart);
                    break;
                case Key.Down:
                    SelectedDate = Increase(selstart, -1);
                    FocusOnDatePart(selstart);

                    break;
                case Key.Left:
                    selstart = SelectPreviousPosition(selstart);
                    if (selstart > -1)
                    {
                        FocusOnDatePart(selstart);
                    }
                    else
                    {
                        this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    }

                    break;

                case Key.Right:
                case Key.Tab:
                    selstart = SelectNextPosition(selstart);
                    if (selstart > -1)
                    {
                        FocusOnDatePart(selstart);
                    }
                    else
                    {
                        PopUpCalendarButton.Focus();

                    }

                    break;
                default:

                    if (!char.IsDigit(Convert.ToChar(e.KeyboardDevice.ToString())))
                    {
                        if (e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9)
                        {
                            e.Handled = false;
                        }
                    }
                    break;
            }

        }

        private static object CoerceDate(DependencyObject d, object value)
        {
            DateTimePicker dtpicker = (DateTimePicker)d;
            System.DateTime current = Convert.ToDateTime(value);
            if (current < dtpicker.MinimumDate)
            {
                current = dtpicker.MinimumDate;
            }
            if (current > dtpicker.MaximumDate)
            {
                current = dtpicker.MaximumDate;
            }
            return current;
        }


        private static object CoerceMinDate(DependencyObject d, object value)
        {
            DateTimePicker dtpicker = (DateTimePicker)d;
            System.DateTime current = Convert.ToDateTime(value);
            if (current >= dtpicker.MaximumDate)
            {
                DateTime date = new DateTime(current.Year, current.Month, current.Day);
                //throw new ArgumentException("MinimumDate can not be equal to, or more than maximum date");
                return date;
            }
            if (current > dtpicker.SelectedDate)
            {
                dtpicker.SelectedDate = current;
            }
            return current;
        }


        private static object CoerceMaxDate(DependencyObject d, object value)
        {
            DateTimePicker dtpicker = (DateTimePicker)d;
            System.DateTime current = Convert.ToDateTime(value);
            if (current <= dtpicker.MinimumDate)
            {
                DateTime date = new DateTime(current.Year, current.Month, current.Day);
                //throw new ArgumentException(Properties.Resources.MAXIMUM_DATE_EXCEPTION);
                return date;
                
            }
            if (current < dtpicker.SelectedDate)
            {
                dtpicker.SelectedDate = current;
            }
            return current;
        }



        public static void OnDateFormatChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var dtp = (DateTimePicker)obj;
            dtp.DateDisplay.Text = String.Format(null, dtp.SelectedDate, dtp.DateFormat);
        }


        public static void OnSelectedDateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var dtp = (DateTimePicker)obj;

            if ((args.NewValue == null))
            {
                dtp.SelectedDate = (Nullable<System.DateTime>)args.NewValue;

                dtp.DateDisplay.Text = Properties.Resources.DATE_DISPLAY_TEXT;

            }
            else
            {
                //DateTime dt = DateTime.ParseExact((string)args.NewValue, dtp.DateFormat,
                //                  CultureInfo.InvariantCulture);
                dtp.DateDisplay.Text = ((DateTime)args.NewValue).ToString(dtp.DateFormat);
                dtp.CalDisplay.SelectedDate = (Nullable<System.DateTime>)args.NewValue;
                dtp.CalDisplay.DisplayDate = (DateTime)args.NewValue;

            }
        }
        public static void OnInitMinimum(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var dtp = (DateTimePicker)obj;

            if ((args.NewValue != null))
            {
                dtp.CalDisplay.DisplayDateStart = (DateTime)args.NewValue;
            }
        }
        public static void OnInitMaximum(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var dtp = (DateTimePicker)obj;

            if ((args.NewValue != null))
            {
                dtp.CalDisplay.DisplayDateEnd = (DateTime)args.NewValue;
            }
        }
        
        #endregion

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateDateFormat(object par)
        {
            string s = Convert.ToString(par);

            DateTime dt = System.DateTime.Now;
            dt.ToString(s);
            //DateTime.ParseExact(dateString, "ddMMyyyy", CultureInfo.InvariantCulture);
            return IsDate(dt);
        }


        private int SelectNextPosition(int selstart)
        {

            return SelectPosition(selstart, Direction.Next);

        }


        private int SelectPreviousPosition(int selstart)
        {


            return SelectPosition(selstart, Direction.Previous);

        }

        //Selects next or previous date value, depending on the increment value  
        //Alternatively moves focus to previous control or the calender button
        private int SelectPosition(int selstart, Direction direction)
        {

            int retval = 0;

            if ((selstart > 0 || direction == DateTimePicker.Direction.Next) && (selstart < DateFormat.Length - FormatLengthOfLast || direction == DateTimePicker.Direction.Previous))
            {
                char firstchar = Convert.ToChar(DateFormat.Substring(selstart, 1));
                char nextchar = Convert.ToChar(DateFormat.Substring(selstart + (int)direction, 1));
                bool found = false;

                while (((nextchar == firstchar || !char.IsLetter(nextchar)) && (selstart > 1 || direction > 0) && (selstart < DateFormat.Length - 2 || direction == DateTimePicker.Direction.Previous)))
                {
                    selstart += (int)direction;
                    nextchar = Convert.ToChar(DateFormat.Substring(selstart + (int)direction, 1));
                }

                if (selstart > 1)
                    found = true;
                selstart = DateFormat.IndexOf(nextchar);

                if (found)
                {
                    retval = selstart;
                }
            }
            else
            {
                retval = -1;
            }

            return retval;



        }




        private void FocusOnDatePart(int selstart)
        {
            if (selstart > DateFormat.Length - 1)
                selstart = DateFormat.Length - 1;
            char firstchar = Convert.ToChar(DateFormat.Substring(selstart, 1));

            selstart = DateFormat.IndexOf(firstchar);
            int sellength = Math.Abs((selstart - (DateFormat.LastIndexOf(firstchar) + 1)));
            DateDisplay.Focus();
            DateDisplay.Select(selstart, sellength);

        }

        private System.DateTime Increase(int selstart, int value)
        {


            System.DateTime retval = Convert.ToDateTime(DateDisplay.Text);

            try
            {
                switch (DateFormat.Substring(selstart, 1))
                {
                    //case "h":
                    case "H":
                        retval = retval.AddHours(value);
                        break;
                    case "y":
                        retval = retval.AddYears(value);
                        break;
                    case "M":
                        retval = retval.AddMonths(value);
                        break;
                    case "m":
                        retval = retval.AddMinutes(value);
                        break;
                    case "d":
                        retval = retval.AddDays(value);
                        break;
                    //case "s":
                        //retval = retval.AddSeconds(value);

                        //break;
                }
            }
            catch { }

            return retval;
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var selstart = DateDisplay.SelectionStart;
            
            e.Handled = true;
            switch (e.Key)
            {
                case Key.Up:
                    SelectedDate = Increase(selstart, 1);
                    FocusOnDatePart(selstart);
                    break;
                case Key.Down:
                    SelectedDate = Increase(selstart, -1);
                    FocusOnDatePart(selstart);

                    break;
                case Key.Left:
                    selstart = SelectPreviousPosition(selstart);
                    if (selstart > -1)
                    {
                        FocusOnDatePart(selstart);
                    }
                    else
                    {
                        this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    }

                    break;

                case Key.Right:
                case Key.Tab:
                    selstart = SelectNextPosition(selstart);
                    if (selstart > -1)
                    {
                        FocusOnDatePart(selstart);
                    }
                    else
                    {
                        PopUpCalendarButton.Focus();

                    }
                    while (!IsDate(DateDisplay.Text))
                    {
                        DateDisplay.Undo();
                    }
                    DateTime date = Convert.ToDateTime(DateDisplay.Text);
                    if (DateTime.Compare(date, (DateTime)CalDisplay.DisplayDateStart) < 0)
                    {
                        DateDisplay.Undo();
                        return;
                    }
                    if (DateTime.Compare(date, (DateTime)CalDisplay.DisplayDateEnd) > 0)
                    {
                        DateDisplay.Undo();
                        return;
                    }
                    break;
                case Key.Enter:
                    selstart = SelectNextPosition(selstart);
                    if (selstart > -1)
                    {
                        FocusOnDatePart(selstart);
                    }
                    else
                    {
                        PopUpCalendarButton.Focus();

                    }
                    
                    while (!IsDate(DateDisplay.Text))
                    {
                        DateDisplay.Undo();
                    }
                    DateTime date1 = Convert.ToDateTime(DateDisplay.Text);
                    if (DateTime.Compare(date1, (DateTime)CalDisplay.DisplayDateStart) < 0)
                    {
                        DateDisplay.Undo();
                        return;
                    }
                    if (DateTime.Compare(date1, (DateTime)CalDisplay.DisplayDateEnd) > 0)
                    {
                        DateDisplay.Undo();
                        return;
                    }
                    break;
                default:


                    if (e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9)
                    {
                        e.Handled = false;
                    }

                    break;
            }
        }

    }
}
