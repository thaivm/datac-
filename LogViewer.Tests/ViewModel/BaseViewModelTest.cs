using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.WindowViewModelMapping;
using System.ComponentModel;

namespace LogViewer.Tests
{


    /// <summary>
    ///This is a test class for BaseViewModelTest and is intended
    ///to contain all BaseViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseViewModelTest
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
        ///A test for OnPropertyChanged - PropertyChanged = null
        ///</summary>
        [TestMethod()]
        public void OnPropertyChanged_NullTest()
        {
            BaseViewModel target = new MainViewModel();
            PrivateObject param = new PrivateObject(target, new PrivateType(typeof(BaseViewModel)));
            param.SetFieldOrProperty("PropertyChanged", null);
            param.Invoke("OnPropertyChanged", "RowForJump");
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for OnPropertyChanged - PropertyChanged != null
        ///</summary>
        [TestMethod()]
        public void OnPropertyChanged_NotNullTest()
        {
            BaseViewModel target = new MainViewModel();
            PrivateObject param = new PrivateObject(target, new PrivateType(typeof(BaseViewModel)));
            param.SetFieldOrProperty("PropertyChanged", new PropertyChangedEventHandler(Pro));
            param.Invoke("OnPropertyChanged", "RowForJump");
            Assert.IsNotNull(target);
        }
        public void Pro (object obj, PropertyChangedEventArgs e){}
    }
}
