using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.WindowViewModelMapping;
using System.Windows.Documents;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for MoveToTimeTest and is intended
    ///to contain all MoveToTimeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MoveToTimeTest
    {


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
        public void SetUp()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
            }
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for MoveToTime Constructor
        ///</summary>
        [TestMethod()]
        public void MoveToTimeConstructorTest()
        {
            MoveToTime target = new MoveToTime();
        }

        /// <summary>
        ///A test for InitData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitDataTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            target.InitData();
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            MoveToTime target = new MoveToTime(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
        }

        /// <summary>
        ///A test for LoadDay
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadDayTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.LoadDay();
           
        }

        /// <summary>
        ///A test for LoadHour
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadHourTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.LoadHour();
            
        }

        /// <summary>
        ///A test for LoadMinuterOrSecond
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadMinuterOrSecondTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.LoadMinuterOrSecond();
            
        }

        /// <summary>
        ///A test for LoadMonth
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadMonthTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.LoadMonth();
            
        }

        /// <summary>
        ///A test for LoadYear
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LoadYearTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            DateTime dtFrom = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime dtTo = new DateTime(); // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.LoadYear(dtFrom, dtTo);
           
        }

        /// <summary>
        ///A test for MoveToTime_Button_Cancel_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void MoveToTime_Button_Cancel_ClickTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RoutedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.MoveToTime_Button_Cancel_Click(sender, e);
        }

        /// <summary>
        ///A test for MoveToTime_Button_JumpTo_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void MoveToTime_Button_JumpTo_ClickTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RoutedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.MoveToTime_Button_JumpTo_Click(sender, e);
        }

        /// <summary>
        ///A test for TextBoxTextAllowed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void TextBoxTextAllowedTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            string Text2 = "4ố"; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TextBoxTextAllowed(Text2);
          
        }

        /// <summary>
        ///A test for Window_Loaded
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Window_LoadedTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RoutedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.Window_Loaded(sender, e);
        }

        /// <summary>
        ///A test for setLineNumber
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void setLineNumberTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            int Line = 0; // TODO: Initialize to an appropriate value
            target.setLineNumber(Line);
        }

        /// <summary>
        ///A test for textBoxValue_Pasting
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void textBoxValue_PastingTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            DataObject d = new DataObject();
            d.SetData(DataFormats.XamlPackage, "XamlPackage");
            DataObjectPastingEventArgs e = new DataObjectPastingEventArgs(d, true, "XamlPackage");
            target.textBoxValue_Pasting(sender, e);

            DataObject dText = new DataObject();
            dText.SetData(DataFormats.Text, "Text");
            DataObjectPastingEventArgs e1 = new DataObjectPastingEventArgs(dText, true, "Text");
            target.textBoxValue_Pasting(sender, e1);

        }

        /// <summary>
        ///A test for textBoxValue_PreviewTextInput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void textBoxValue_PreviewTextInputTest()
        {
            MoveToTime_Accessor target = new MoveToTime_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            TextCompositionEventArgs e = new TextCompositionEventArgs(Keyboard.PrimaryDevice, new TextComposition(InputManager.Current, Keyboard.FocusedElement, "4Bốn"));   // TODO: Initialize to an appropriate value
            e.RoutedEvent = UIElement.KeyDownEvent;
            
            target.textBoxValue_PreviewTextInput(sender, e);
        }
    }
}
