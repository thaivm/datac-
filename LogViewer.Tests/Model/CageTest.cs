using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CageTest and is intended
    ///to contain all CageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CageTest
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
        ///A test for IsPattern
        ///</summary>
        [TestMethod()]
        public void IsPatternTest()
        {
            Cage target = new Cage(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsPattern = expected;
            actual = target.IsPattern;
            Assert.AreEqual(expected, actual);
        }
    }
}
