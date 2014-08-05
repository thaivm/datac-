using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Windows.Input;
using System.Collections.ObjectModel;
using LogViewer.MVVMHelper;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for JumpToTimeViewModelTest and is intended
    ///to contain all JumpToTimeViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JumpToTimeViewModelTest
    {


        private TestContext testContextInstance;
        private static JumpToTimeViewModel_Accessor<CCSLogRecord> target;
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
        ///A test for IsEnableButton
        ///</summary>
        //IsEnableButtonTest Fasle
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableButtonTest_False()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime =DateTime.Parse( "2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime =DateTime.Parse( "2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._from = DateTime.Parse( "2013-01-01 00:00:01.000");
            target.Year = "2010";
            target.Month = "10";
            target.Day = "28";
            target.Hour = "3";
            target.Minute = "20";
            target.Second = "4";
            target.MiliSecond = "5";
            Assert.IsFalse(target.IsEnableButton());
        }

        // IsEnavleButtontest True
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableButtonTest_True()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._from = DateTime.Parse("2013-01-01 00:00:01.000");
            target.Year = "2013";
            target.Month = "01";
            target.Day = "01";
            target.Hour = "00";
            target.Minute = "00";
            target.Second = "01";
            target.MiliSecond = "000";
            Assert.IsTrue(target.IsEnableButton());
        }

        // IsEnavleButtontest has no Milisecond
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableButtonTest_NotMilisecond()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._to = DateTime.Parse("2013-01-01 00:00:01.000");
            target.Year = "2013";
            target.Month = "01";
            target.Day = "01";
            target.Hour = "00";
            target.Minute = "00";
            target.Second = "01";
            target.MiliSecond = null;
            Assert.IsTrue(target.IsEnableButton());
        }

        // IsEnavleButtontest Exception
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableButtonTest_Exception()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._to = DateTime.Parse("2013-01-01 00:00:01.000");
            target.Year = "a";
            target.Month = "01";
            target.Day = "01";
            target.Hour = "00";
            target.Minute = "00";
            target.Second = "01";
            target.MiliSecond = "000";
            Assert.IsFalse(target.IsEnableButton());
        }

        /// <summary>
        ///A test for JumpToTimeCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void JumpToTimeCommandCLTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target.Year = "2010";
            target.Month = "10";
            target.Day = "28";
            target.Hour = "3";
            target.Minute = "20";
            target.Second = "4";
            target.MiliSecond = "5";
            Action<string, string> OnShowRecordWithDateTimeEvent = new Action<string, string>((a, b) => {});
            target.OnShowRecordWithDateTimeEvent += OnShowRecordWithDateTimeEvent;
            target.JumpToTimeCommandCL();
        }

        /// <summary>
        ///A test for LoadDay
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadDayTest()
        {
            DateTime from = new DateTime(2013, 3, 9);
            DateTime to = new DateTime(2013, 3, 11);
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            List<string> actual = target.LoadDay(from, to);
            Assert.AreEqual(3, actual.Count);
        }

        /// <summary>
        ///A test for LoadDay
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadDay_31Test()
        {
            DateTime from = new DateTime(2010, 3, 9);
            DateTime to = new DateTime(2013, 3, 11);
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2010-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            List<string> actual = target.LoadDay(from, to);
            Assert.AreEqual(31, actual.Count);
        }

        /// <summary>
        ///A test for LoadHour
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadHourTest()
        {
            DateTime from = new DateTime(2010, 3, 9);
            DateTime to = new DateTime(2013, 3, 11);
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            List<string> actual = target.LoadHour();
            Assert.AreEqual(24, actual.Count);
        }

        /// <summary>
        ///A test for LoadMinuterOrSecond
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadMinuterOrSecondTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            List<string> actual = target.LoadMinuterOrSecond();
            Assert.AreEqual(60, actual.Count);
        }

        /// <summary>
        ///A test for LoadMonth
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadMonthTest()
        {
            DateTime from = new DateTime(2013, 3, 9);
            DateTime to = new DateTime(2013, 6, 11);
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime =DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            List<string> actual = target.LoadMonth(from, to);
            Assert.AreEqual(4, actual.Count);
        }

        /// <summary>
        ///A test for LoadMonth
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadMonth_12Test()
        {
            DateTime from = new DateTime(2010, 3, 9);
            DateTime to = new DateTime(2013, 6, 11);
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2010-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            List<string> actual = target.LoadMonth(from, to);
            Assert.AreEqual(12, actual.Count);
        }

        /// <summary>
        ///A test for LoadYear
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadYearTest()
        {
            DateTime from = new DateTime(2000, 3, 11);
            DateTime to = new DateTime(2010, 3, 11);
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            //List<string> expect = new List<string>();
            List<string> actual = target.LoadYear(from, to);
            //expect.Add(year);
            Assert.AreEqual(11, actual.Count);
        }

        /// <summary>
        ///A test for Day
        ///</summary>
        [TestMethod()]
        public void Day_GetNullTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._day = null;
            Assert.IsNull(target.Day);
        }

        /// <summary>
        ///A test for Day
        ///</summary>
        [TestMethod()]
        public void Day_GetNotNullTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._day = "2013-01-01";
            Assert.AreEqual(target._day, target.Day);
        }

        /// <summary>
        ///A test for Day
        ///</summary>
        [TestMethod()]
        public void Day_SetNullTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target.Day = null;
            Assert.IsNull(target._day);
        }

        /// <summary>
        ///A test for Day
        ///</summary>
        [TestMethod()]
        public void Day_SetNotNullTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target.Day = "2013-01-01";
            Assert.AreEqual(target._day, target.Day);
        }

        /// <summary>
        ///A test for Hour
        ///</summary>
        [TestMethod()]
        public void Hour_GetNullTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._hour = null;
            Assert.IsNull(target.Hour);
        }

        /// <summary>
        ///A test for Hour
        ///</summary>
        [TestMethod()]
        public void Hour_GetNotNullTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._hour = "00:00:01.000";
            Assert.AreEqual(target._hour, target.Hour);
        }

        /// <summary>
        ///A test for Hour
        ///</summary>
        [TestMethod()]
        public void Hour_SetNullTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target.Hour = null;
            Assert.IsNull(target._hour);
        }

        /// <summary>
        ///A test for Hour
        ///</summary>
        [TestMethod()]
        public void Hour_SetNotNullTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target.Hour = "00:00:01.000";
            Assert.AreEqual(target._hour, target.Hour);
        }

        /// <summary>
        ///A test for JumpToLineCommand
        ///</summary>
        [TestMethod()]
        public void JumpToLineCommandTest_Null()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            Assert.IsNotNull(target.JumpToLineCommand);
        }

        /// <summary>
        ///A test for JumpToLineCommand
        ///</summary>
        [TestMethod()]
        public void JumpToLineCommandTest_NotNull()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime = DateTime.Parse("2013-01-01 00:00:01.000");
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(null, record1, record2);
            target._jumpToTimeCommand = new DelegateCommand(target.JumpToTimeCommandCL, () => target.IsEnableButton());
            Assert.AreEqual(target._jumpToTimeCommand, target.JumpToLineCommand);
        }

        /// <summary>
        ///A test for ListDay
        ///</summary>
        [TestMethod()]
        public void ListDayTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("10");
            target.ListDay = list;
            ObservableCollection<string> actual = target.ListDay;
            Assert.AreEqual(list, actual);
        }

        /// <summary>
        ///A test for ListHour
        ///</summary>
        [TestMethod()]
        public void ListHourTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("10");
            target.ListHour = list;
            ObservableCollection<string> actual = target.ListHour;
            Assert.AreEqual(list, actual);
        }

        /// <summary>
        ///A test for ListMinute
        ///</summary>
        [TestMethod()]
        public void ListMinuteTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("10");
            target.ListMinute = list;
            ObservableCollection<string> actual = target.ListMinute;
            Assert.AreEqual(list, actual);
        }

        /// <summary>
        ///A test for ListMonth
        ///</summary>
        [TestMethod()]
        public void ListMonthTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("10");
            target._listMonth = list;
            ObservableCollection<string> actual = target.ListMonth;
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        ///A test for ListSecond
        ///</summary>
        [TestMethod()]
        public void ListSecondTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("10");
            target.ListSecond = list;
            ObservableCollection<string> actual = target.ListSecond;
            Assert.AreEqual(list, actual);
        }

        /// <summary>
        ///A test for ListYear
        ///</summary>
        [TestMethod()]
        public void ListYearTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("10");
            target.ListYear = list;
            ObservableCollection<string> actual = target.ListYear;
            Assert.AreEqual(list, actual);
        }

        /// <summary>
        ///A test for Message1
        ///</summary>
        [TestMethod()]
        public void Message1Test()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            target.Message1 = "aaa";
            String actual = target.Message1;
            String expect = "aaa";
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        ///A test for Message2
        ///</summary>
        [TestMethod()]
        public void Message2Test()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            target.Message2 = "aaa";
            String actual = target.Message2;
            String expect = "aaa";
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        ///A test for MiliSecond
        ///</summary>
        [TestMethod()]
        public void MiliSecondTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            target.MiliSecond = "10";
            String actual = target.MiliSecond;
            String expect = "10";
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        ///A test for Minute
        ///</summary>
        [TestMethod()]
        public void MinuteTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            target.Minute = "10";
            String actual = target.Minute;
            String expect = "10";
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        ///A test for Month
        ///</summary>
        [TestMethod()]
        public void MonthTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            target.Month = "10";
            String actual = target.Month;
            String expect = "10";
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        ///A test for Second
        ///</summary>
        [TestMethod()]
        public void SecondTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            target._second = "10";
            String actual = target.Second;
            String expect = "10";
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        ///A test for Year
        ///</summary>
        [TestMethod()]
        public void YearTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-01-01 00:00:01.000");
            PrivateObject param0 = new PrivateObject(new JumpToTimeViewModel<CCSLogRecord>(null, record1, record2));
            target = new JumpToTimeViewModel_Accessor<CCSLogRecord>(param0);
            target._year = "2010";
            String actual = target.Year;
            String expect = "2010";
            Assert.AreEqual(expect, actual);
        }
    }
}
