using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for LoadingDialogViewModelTest and is intended
    ///to contain all LoadingDialogViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoadingDialogViewModelTest
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {

        }
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
        ///A test for LoadingDialogViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void LoadingDialogViewModelConstructorTest()
        {
            LoadingDialogViewModel target = new LoadingDialogViewModel();
            Assert.AreEqual("Please wait a moment...", target.LoadingText);
            Assert.AreEqual("Loading...", target.LoadingTitle);
        }

        /// <summary>
        ///A test for ExecuteWhilePopUpLoading
        ///</summary>
        //[TestMethod()]
        //public void ExecuteWhilePopUpLoadingTest()
        //{
        //    LoadingDialogViewModel target = new LoadingDialogViewModel(); // TODO: Initialize to an appropriate value
        //    target.ExecuteWhilePopUpLoading(() => { }, targetMainVM, () => { });
        //}

        /// <summary>
        ///A test for LoadingText
        ///</summary>
        [TestMethod()]
        public void LoadingTextTest()
        {
            LoadingDialogViewModel target = new LoadingDialogViewModel(); // TODO: Initialize to an appropriate value
            string expected = "Please wait a moment..."; // TODO: Initialize to an appropriate value
            string actual;
            target.LoadingText = expected;
            actual = target.LoadingText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LoadingTitle
        ///</summary>
        [TestMethod()]
        public void LoadingTitleTest()
        {
            LoadingDialogViewModel target = new LoadingDialogViewModel(); // TODO: Initialize to an appropriate value
            string expected = "Loading..."; // TODO: Initialize to an appropriate value
            string actual;
            target.LoadingTitle = expected;
            actual = target.LoadingTitle;
            Assert.AreEqual(expected, actual);
        }
    }
}
