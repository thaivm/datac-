using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using System.Windows.Controls;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for LogDisplaySettingViewTest and is intended
    ///to contain all LogDisplaySettingViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogDisplaySettingViewTest
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
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
        }
        //
        #endregion


        /// <summary>
        ///A test for LogDisplaySettingView Constructor
        ///</summary>
        [TestMethod()]
        public void LogDisplaySettingViewConstructorTest()
        {
            LogDisplaySettingView target = new LogDisplaySettingView();
        }

        /// <summary>
        ///A test for DataGrid_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataGrid_KeyDownTest()
        {
            LogDisplaySettingView_Accessor target = new LogDisplaySettingView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, Key.Delete);
            e.RoutedEvent = UIElement.KeyDownEvent;
            target.DataGrid_KeyDown(sender, e);
        }

        /// <summary>
        ///A test for DataGrid_SelectionChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataGrid_SelectionChangedTest()
        {
            LogDisplaySettingView_Accessor target = new LogDisplaySettingView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            SelectionChangedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.DataGrid_SelectionChanged(sender, e);
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            LogDisplaySettingView target = new LogDisplaySettingView(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
        }
    }
}
