using LogViewer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Windows.Forms;

namespace LogViewer.Tests
{


    /// <summary>
    ///This is a test class for AppTest and is intended
    ///to contain all AppTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AppTest
    {

        public static App_Accessor target;
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            target = new App_Accessor();
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            MessageBoxManager.Unregister();
        }
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //    ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
        //    ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
        //    ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
        //    ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
        //    MessageBoxManager.Unregister();
        //}
        //
        #endregion


        /// <summary> 
        ///A test for Application_Startup - has folder "FileConfig"
        ///</summary>
        [TestMethod]
        [DeploymentItem("LogViewer.exe")]
        public void Application_Startup_FileConfigTest()
        {
            object sender = new object(); ;
            StartupEventArgs e = null;
            target.Application_Startup(sender, e);
        }

        /// <summary>
        ///A test for InitializeComponent - _contentLoaded is true
        ///</summary>
        [TestMethod]
        public void InitializeComponent__contentLoadedTrueTest()
        {
            target._contentLoaded = true;
            target.InitializeComponent();
            Assert.IsTrue(target._contentLoaded);
        }
    }
}
