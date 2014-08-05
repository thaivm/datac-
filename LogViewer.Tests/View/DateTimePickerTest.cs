using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows;
using System.Windows.Controls;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Windows.Media;

namespace LogViewer.Tests
{

    
    /// <summary>
    ///This is a test class for DateTimePickerTest and is intended
    ///to contain all DateTimePickerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateTimePickerTest
    {

        public class FakePresentationSource : PresentationSource
        {
            protected override CompositionTarget GetCompositionTargetCore()
            {
                return null;
            }

            public override Visual RootVisual { get; set; }

            public override bool IsDisposed { get { return false; } }
        }
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
        }
        //
        #endregion


        /// <summary>
        ///A test for SelectedDate
        ///</summary>
        [TestMethod()]
        public void SelectedDateTest()
        {
            DateTimePicker target = new DateTimePicker();
            Nullable<DateTime> expected = new Nullable<DateTime>(new DateTime(2013, 1, 1));
            Nullable<DateTime> actual;
            target.SelectedDate = expected;
            actual = target.SelectedDate;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for MinimumDate
        ///</summary>
        [TestMethod()]
        public void MinimumDateTest()
        {
            DateTimePicker target = new DateTimePicker();
            DateTime expected = new DateTime(2013, 1, 1);
            DateTime actual;
            target.MinimumDate = new DateTime(2013, 1, 1);
            actual = target.MinimumDate;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for MaximumDate
        ///</summary>
        [TestMethod()]
        public void MaximumDateTest()
        {
            DateTimePicker target = new DateTimePicker();
            DateTime expected = new DateTime(2013, 1, 1);
            DateTime actual;
            target.MaximumDate = new DateTime(2013, 1, 1);
            actual = target.MaximumDate;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DateFormat
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DateFormatTest()
        {
            DateTimePicker target = new DateTimePicker();
            string expected = "2013-10-28 00:00";
            string actual;
            target.DateFormat = expected;
            actual = target.DateFormat;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for ValidateDateFormat
        ///</summary>
        [TestMethod()]
        public void ValidateDateFormatTest()
        {
            object par = "2013-1-1 00:00";
            bool expected = true;
            bool actual;
            actual = DateTimePicker.ValidateDateFormat(par);
            Assert.AreEqual(expected, actual);            
        }
        
        /// <summary>
        ///A test for UserControl_PreviewKeyDown
        ///</summary>
        //Pending
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserControl_PreviewKeyDownTest_up()
        {
            var key = Key.Up;                    // Key to send
            var target = Keyboard.FocusedElement;    // Target element
            var routedEvent = Keyboard.KeyDownEvent; // Event to send
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource() , 0, key);
            e.RoutedEvent = routedEvent;
            target1.UserControl_PreviewKeyDown(sender, e);                        
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserControl_PreviewKeyDownTest_left()
        {
            var key = Key.Left;                    // Key to send
            var target = Keyboard.FocusedElement;    // Target element
            var routedEvent = Keyboard.KeyDownEvent; // Event to send
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key);
            e.RoutedEvent = routedEvent;
            target1.UserControl_PreviewKeyDown(sender, e);
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserControl_PreviewKeyDownTest_down()
        {
            var key = Key.Down;                    // Key to send
            var target = Keyboard.FocusedElement;    // Target element
            var routedEvent = Keyboard.KeyDownEvent; // Event to send
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            target1.DateDisplay.SelectionStart = 1;
            object sender = null;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key);
            e.RoutedEvent = routedEvent;
            target1.UserControl_PreviewKeyDown(sender, e);
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserControl_PreviewKeyDownTest_right()
        {
            var key = Key.Right;                    // Key to send
            var target = Keyboard.FocusedElement;    // Target element
            var routedEvent = Keyboard.KeyDownEvent; // Event to send
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            target1.DateDisplay.SelectionStart = 1;
            object sender = null;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key);
            e.RoutedEvent = routedEvent;
            target1.UserControl_PreviewKeyDown(sender, e);
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserControl_PreviewKeyDownTest_tab()
        {
            var key = Key.Tab;                    // Key to send
            var target = Keyboard.FocusedElement;    // Target element
            var routedEvent = Keyboard.KeyDownEvent; // Event to send
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();            
            object sender = null;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key);
            e.RoutedEvent = routedEvent;
            target1.UserControl_PreviewKeyDown(sender, e);
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserControl_PreviewKeyDownTestD0()
        {
            var key = Key.D0;                    // Key to send
            var target = Keyboard.FocusedElement;    // Target element
            var routedEvent = Keyboard.KeyDownEvent; // Event to send
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key);
            e.RoutedEvent = routedEvent;
            target1.UserControl_PreviewKeyDown(sender, e);
        }

        [TestMethod()]
        public void UserControl_PreviewKeyDownTest_Enter()
        {
            var key = Key.Enter;                    // Key to send
            var target = Keyboard.FocusedElement;    // Target element
            var routedEvent = Keyboard.KeyDownEvent; // Event to send
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key);
            e.RoutedEvent = routedEvent;
            target1.UserControl_PreviewKeyDown(sender, e);
        }
        /// <summary>
        ///A test for System.Windows.Markup.IComponentConnector.Connect
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ConnectTest()
        {
            IComponentConnector target = new DateTimePicker();
            int connectionId = 0;
            object target1 = new object();
            target.Connect(connectionId, target1);
            
        }

        /// <summary>
        ///A test for SelectPreviousPosition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SelectPreviousPositionTest()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 0;
            int expected = -1;
            int actual;
            actual = target.SelectPreviousPosition(selstart);
            Assert.AreEqual(expected, actual);            
        }
        
        /// <summary>
        ///A test for SelectPosition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SelectPositionTest()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 2;
            DateTimePicker_Accessor.Direction direction = DateTimePicker_Accessor.Direction.Previous;
            int expected = 0;
            int actual;
            actual = target.SelectPosition(selstart, direction);
            Assert.AreEqual(expected, actual);            
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SelectPositionTest1()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 10;
            DateTimePicker_Accessor.Direction direction = DateTimePicker_Accessor.Direction.Previous;
            int expected = 8;
            int actual;
            actual = target.SelectPosition(selstart, direction);
            Assert.AreEqual(expected, actual);
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SelectPositionTest2()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 0;
            DateTimePicker_Accessor.Direction direction = DateTimePicker_Accessor.Direction.Previous;
            int expected = -1;
            int actual;
            actual = target.SelectPosition(selstart, direction);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for SelectNextPosition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SelectNextPositionTest()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 0;
            int expected = 5;
            int actual;
            actual = target.SelectNextPosition(selstart);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for OnSelectedDateChanged
        ///</summary>
        [TestMethod()]
        public void OnSelectedDateChangedTest()
        {
            DependencyObject obj = new DateTimePicker();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs();
            DateTimePicker.OnSelectedDateChanged(obj, args);
            
        }

        /// <summary>
        ///A test for OnInitMinimum
        ///</summary>
        [TestMethod()]
        public void OnInitMinimumTest()
        {
            DependencyObject obj = new DateTimePicker();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(DateTimePicker.MinimumDateProperty, new object(), new DateTime());            
            DateTimePicker.OnInitMinimum(obj, args);
           
        }

        /// <summary>
        ///A test for OnInitMaximum
        ///</summary>
        [TestMethod()]
        public void OnInitMaximumTest()
        {
            DependencyObject obj = new DateTimePicker();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(DateTimePicker.MaximumDateProperty, new object(), new DateTime());
            DateTimePicker.OnInitMaximum(obj, args);
            
        }

        /// <summary>
        ///A test for OnDateFormatChanged
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OnDateFormatChangedTest()
        {
            DependencyObject obj = new DateTimePicker();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs();            
            DateTimePicker.OnDateFormatChanged(obj, args);            
        }

        /// <summary>
        ///A test for IsDate
        ///</summary>
        [TestMethod()]
        public void IsDateNormalTest()
        {
            Object obj = "2013-01-01 00:00";
            bool expected = true;
            bool actual;
            actual = DateTimePicker.IsDate(obj);
            Assert.AreEqual(expected, actual);            
        }
        [TestMethod()]
        public void IsDateAbNormalMinDateTest()
        {
            Object obj = "0001-01-01 00:00";
            bool expected = false;
            bool actual;
            actual = DateTimePicker.IsDate(obj);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsDateAbNormalTest()
        {
            Object obj = "2013a-01-01 00:00";
            bool expected = false;
            bool actual;
            actual = DateTimePicker.IsDate(obj);
            Assert.AreEqual(expected, actual);
        } 
        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            DateTimePicker target = new DateTimePicker();
            target.InitializeComponent();
        }

        /// <summary>
        ///A test for Increase
        ///</summary>
        ///        [TestMethod()]
        public void IncreaseCaseAbNormalTest()
        {
            //yyyy-MM-dd HH:mm
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 100;
            int value = 100;
            target.DateDisplay.Text = "2013-01-01 00:00";
            DateTime expected = new DateTime(2013, 1, 1, 0, 0, 0);
            DateTime actual;
            actual = target.Increase(selstart, value);
            Assert.AreEqual(expected.Hour + value, actual.Hour);
        }
        [TestMethod()]
        public void IncreaseCaseHTest()
        {
            //yyyy-MM-dd HH:mm
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 11;
            int value = 1;
            target.DateDisplay.Text = "2013-01-01 00:00";
            DateTime expected = new DateTime(2013, 1, 1, 0, 0, 0);
            DateTime actual;
            actual = target.Increase(selstart, value);
            Assert.AreEqual(expected.Hour + value, actual.Hour);
        }
        [TestMethod()]
        public void IncreaseCaseyTest()
        {
            //yyyy-MM-dd HH:mm
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 0;
            int value = 1;
            target.DateDisplay.Text = "2013-01-01 00:00";
            DateTime expected = new DateTime(2013, 1, 1, 0, 0, 0);
            DateTime actual;
            actual = target.Increase(selstart, value);
            Assert.AreEqual(expected.Year + value, actual.Year);
        }
        [TestMethod()]
        public void IncreaseCaseMTest()
        {
            //yyyy-MM-dd HH:mm
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 6;
            int value = 1;
            target.DateDisplay.Text = "2013-01-01 00:00";
            DateTime expected = new DateTime(2013, 1, 1, 0, 0, 0);
            DateTime actual;
            actual = target.Increase(selstart, value);
            Assert.AreEqual(expected.Month + value, actual.Month);
        }
        [TestMethod()]
        public void IncreaseCasemTest()
        {
            //yyyy-MM-dd HH:mm
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 15;
            int value = 1;
            target.DateDisplay.Text = "2013-01-01 00:00";
            DateTime expected = new DateTime(2013, 1, 1, 0, 0, 0);
            DateTime actual;
            actual = target.Increase(selstart, value);
            Assert.AreEqual(expected.Minute + value, actual.Minute);
        }
        [TestMethod()]
        public void IncreaseCasedTest()
        {
            //yyyy-MM-dd HH:mm
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 9;
            int value = 1;
            target.DateDisplay.Text = "2013-01-01 00:00";
            DateTime expected = new DateTime(2013, 1, 1, 0, 0, 0);
            DateTime actual;
            actual = target.Increase(selstart, value);
            Assert.AreEqual(expected.Day + value, actual.Day);
        }
        /// <summary>
        ///A test for FocusOnDatePart
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void FocusOnDatePartTest()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            int selstart = 17;
            target.FocusOnDatePart(selstart);
            
        }

        /// <summary>
        ///A test for DateTimePicker_PreviewKeyDown
        ///</summary>
        ///
        [TestMethod()]
        public void DateTimePicker_PreviewKeyDown_KeyDownTest()
        {
            var key = Key.Down;                   
            var target = Keyboard.FocusedElement;  
            var routedEvent = Keyboard.KeyDownEvent;
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            target1.DateDisplay.SelectionStart = 1;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key) 
            {
                RoutedEvent = UIElement.KeyDownEvent
            };
            
            target1.DateTimePicker_PreviewKeyDown(sender, e);
        }

        [TestMethod()]
        public void DateTimePicker_PreviewKeyDown_KeyUpTest()
        {
            var key = Key.Up;
            var target = Keyboard.FocusedElement;
            var routedEvent = Keyboard.KeyDownEvent;
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            target1.DateDisplay.SelectionStart = 1;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key)
            {
                RoutedEvent = UIElement.KeyUpEvent
            };

            target1.DateTimePicker_PreviewKeyDown(sender, e);
        }


        [TestMethod()]
        public void DateTimePicker_PreviewKeyDown_KeyLeftTest()
        {
            var key = Key.Left;
            var target = Keyboard.FocusedElement;
            var routedEvent = Keyboard.KeyDownEvent;
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            target1.DateDisplay.SelectionStart = 1;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key)
            {
                RoutedEvent = UIElement.KeyDownEvent
            };

            target1.DateTimePicker_PreviewKeyDown(sender, e);
        }

        [TestMethod()]
        public void DateTimePicker_PreviewKeyDown_KeyRightTest()
        {
            var key = Key.Right;
            var target = Keyboard.FocusedElement;
            var routedEvent = Keyboard.KeyDownEvent;
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            target1.DateDisplay.SelectionStart = 1;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key)
            {
                RoutedEvent = UIElement.KeyDownEvent
            };

            target1.DateTimePicker_PreviewKeyDown(sender, e);
        }

        [TestMethod()]
        public void DateTimePicker_PreviewKeyDown_KeyTabTest()
        {
            var key = Key.Tab;
            var target = Keyboard.FocusedElement;
            var routedEvent = Keyboard.KeyDownEvent;
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            target1.DateDisplay.SelectionStart = 1;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key)
            {
                RoutedEvent = UIElement.KeyDownEvent
            };

            target1.DateTimePicker_PreviewKeyDown(sender, e);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void DateTimePicker_PreviewKeyDown_KeyD0Test()
        {
            var key = Key.D0;
            var target = Keyboard.FocusedElement;
            var routedEvent = Keyboard.KeyDownEvent;
            DateTimePicker_Accessor target1 = new DateTimePicker_Accessor();
            object sender = null;
            target1.DateDisplay.SelectionStart = 1;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key)
            {
                RoutedEvent = UIElement.KeyDownEvent
            };

            target1.DateTimePicker_PreviewKeyDown(sender, e);
        }
        /// <summary>
        ///A test for DateDisplay_PreviewMouseUp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DateDisplay_PreviewMouseUpTest()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            object sender = null;
            MouseButtonEventArgs e = null;
            target.DateDisplay.SelectionStart = 1;
            target.DateDisplay_PreviewMouseUp(sender, e);            
        }

        /// <summary>
        ///A test for DateDisplay_LostFocus
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DateDisplay_LostFocusTest()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            object sender = null;
            RoutedEventArgs e = null;            
            target.SelectedDate = new DateTime(2013, 10, 28);
            target.DateDisplay.Text = "2013-01-01";
            target.DateDisplay_LostFocus(sender, e);            
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DateDisplay_LostFocusTest1()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            object sender = null;
            RoutedEventArgs e = null;
            target.SelectedDate = new DateTime(2013, 10, 28);
            target.DateDisplay.Text = "2050-01-01";
            target.DateDisplay_LostFocus(sender, e);
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DateDisplay_LostFocusTest2()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            object sender = null;
            RoutedEventArgs e = null;
            target.SelectedDate = new DateTime(2013, 10, 28);
            target.DateDisplay.Text = "1899-01-01";
            target.DateDisplay_LostFocus(sender, e);
        }
        /// <summary>
        ///A test for CoerceMinDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CoerceMinDateTest()
        {
            DependencyObject d = new DateTimePicker();
            object value = "2013-01-01 00:00";
            object expected = new DateTime(2013, 1, 1, 0, 0, 0);
            object actual;
            actual = DateTimePicker_Accessor.CoerceMinDate(d, value);
            Assert.AreEqual(expected, actual);            
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CoerceMinDateTest1()
        {
            DependencyObject d = new DateTimePicker();
            object value = "2050-01-01 00:00";
            object expected = new DateTime(2050, 1, 1, 0, 0, 0);
            object actual;
            actual = DateTimePicker_Accessor.CoerceMinDate(d, value);
            Assert.AreEqual(expected, actual);
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CoerceMinDateTest2()
        {
            DependencyObject d = new DateTimePicker();
            object value = "2015-01-01 00:00";
            object expected = new DateTime(2015, 1, 1, 0, 0, 0);
            object actual;
            actual = DateTimePicker_Accessor.CoerceMinDate(d, value);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for CoerceMaxDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CoerceMaxDateTest()
        {
            DependencyObject d = new DateTimePicker();
            object value = "1899-01-01 00:00"; ;
            object expected = new DateTime(1899, 1, 1, 0, 0, 0);
            object actual;
            actual = DateTimePicker_Accessor.CoerceMaxDate(d, value);
            Assert.AreEqual(expected, actual);            
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CoerceMaxDateTest1()
        {
            DependencyObject d = new DateTimePicker();
            object value = "2013-01-01 00:00";
            object expected = new DateTime(2013, 1, 1, 0, 0, 0);
            object actual;
            actual = DateTimePicker_Accessor.CoerceMaxDate(d, value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CoerceDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CoerceDateTest()
        {
            DependencyObject d = new DateTimePicker();
            object value = "1899-01-01 00:00"; ;
            object expected = new DateTime(1900, 1, 1, 0, 0, 0);
            object actual;
            actual = DateTimePicker_Accessor.CoerceDate(d, value);
            Assert.AreEqual(expected, actual);            
        }
        //
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CoerceDateTest1()
        {
            DependencyObject d = new DateTimePicker();
            object value = "2050-01-01 00:00"; ;
            object expected = new DateTime(2045, 1, 1, 0, 0, 0);
            object actual;
            actual = DateTimePicker_Accessor.CoerceDate(d, value);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for CalDisplay_SelectedDatesChanged
        ///</summary>
        [TestMethod()]
        public void CalDisplay_SelectedDatesChanged1Test()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            object sender = null;
            SelectionChangedEventArgs e = null;
            target.SelectedDate = new DateTime(2013, 1, 1, 1, 1, 1);
            target.CalDisplay_SelectedDatesChanged(sender, e);            
        }
        //
        [TestMethod()]
        public void CalDisplay_SelectedDatesChangedTest1()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            object sender = null;
            SelectionChangedEventArgs e = null;
            target.SelectedDate = new DateTime(2050, 1, 1, 1, 1, 1);
            target.CalDisplay_SelectedDatesChanged(sender, e);
        }
        //
        [TestMethod()]
        public void CalDisplay_SelectedDatesChangedTest2()
        {
            DateTimePicker_Accessor target = new DateTimePicker_Accessor();
            object sender = null;
            SelectionChangedEventArgs e = null;
            target.SelectedDate = new DateTime(1899, 1, 1, 1, 1, 1);
            target.CalDisplay_SelectedDatesChanged(sender, e);
        }

        /// <summary>
        ///A test for DateTimePicker Constructor
        ///</summary>
        [TestMethod()]
        public void DateTimePickerConstructorTest()
        {
            DateTimePicker target = new DateTimePicker();
            
        }
    }
}
