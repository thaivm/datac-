using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using LogViewer.ViewModel.LogMain.AnalyzeTab.Tab;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CCSAnalyzeAreaViewModelTest and is intended
    ///to contain all CCSAnalyzeAreaViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CCSAnalyzeAreaViewModelTest
    {

        public static MainViewModel_Accessor targetMainVM;
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
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
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
        ///A test for ErrorActionTabVM
        ///</summary>
        [TestMethod()]
        public void ErrorActionTabVMTest()
        {
            PrivateObject target = new PrivateObject(((CCSAnalyzeAreaViewModel)targetMainVM.CCSMainVM.AnalyzeAreaVM));
            ErrorActionTabViewModel actual;
            target.SetFieldOrProperty("ErrorActionTabVM", new ErrorActionTabViewModel(new Action<CCSLogRecord>((record)=>{}), null));
            actual = (ErrorActionTabViewModel)target.GetFieldOrProperty("ErrorActionTabVM");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for UserActionTabVM
        ///</summary>
        [TestMethod()]
        public void UserActionTabVMTest()
        {
            PrivateObject target = new PrivateObject(((CCSAnalyzeAreaViewModel)targetMainVM.CCSMainVM.AnalyzeAreaVM));
            UserActionTabViewModel actual;
            target.SetFieldOrProperty("UserActionTabVM", new UserActionTabViewModel(new Action<CCSLogRecord>((record) => { }), null));
            actual = (UserActionTabViewModel)target.GetFieldOrProperty("UserActionTabVM");
            Assert.IsNotNull(actual);
        }
    }
}
