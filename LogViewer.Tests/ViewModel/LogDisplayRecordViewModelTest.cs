using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for LogDisplayRecordViewModelTest and is intended
    ///to contain all LogDisplayRecordViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogDisplayRecordViewModelTest
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
        ///A test for DisplayKey
        ///</summary>
        [TestMethod()]
        public void DisplayKeyTest()
        {
            LogDisplay logDisplay = new LogDisplay();
            logDisplay.value = true;
            logDisplay.key = "test";
            LogDisplayRecordViewModel target = new LogDisplayRecordViewModel(logDisplay); 
            string expected = string.Empty; 
            string actual;
            target.DisplayKey = expected;
            actual = target.DisplayKey;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            LogDisplay logDisplay = new LogDisplay();
            logDisplay.value = true;
            logDisplay.key = "test";
            LogDisplayRecordViewModel target = new LogDisplayRecordViewModel(logDisplay);
            string expected = string.Empty; 
            string actual;
            target.Key = expected;
            actual = target.Key;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            LogDisplay logDisplay = new LogDisplay();
            logDisplay.value = true;
            logDisplay.key = "test";
            LogDisplayRecordViewModel target = new LogDisplayRecordViewModel(logDisplay);
            bool expected = false; 
            bool actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);            
        }
    }
}
