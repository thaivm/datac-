using LogViewer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ServiceLocatorTest and is intended
    ///to contain all ServiceLocatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServiceLocatorTest
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
        ///A test for Register - has no Singleton
        ///</summary>
        [TestMethod()]
        public void RegisterTest()
        {
            if (ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            }
            ServiceLocator.Register<IDialogService, DialogService>();
        }

        /// <summary>
        ///A test for Register - Singleton = true
        ///</summary>
        [TestMethod()]
        public void Register_isSingletonTrueTest()
        {
            if (ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            }
            ServiceLocator.Register<IDialogService, DialogService>(true);
        }

        /// <summary>
        ///A test for Register - Singleton = false
        ///</summary>
        [TestMethod()]
        public void Register_isSingletonFalseTest()
        {
            if (ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            }
            
            ServiceLocator.Register<IDialogService, DialogService>(false);
            
        }

        /// <summary>
        ///A test for RegisterSingleton
        ///</summary>
        [TestMethod()]
        public void RegisterSingletonTest()
        {
            if (ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            }
            
            ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
            
        }

        /// <summary>
        ///A test for Resolve
        ///</summary>
        [TestMethod()]
        public void ResolveTest()
        {
            Assert.IsNotNull(ServiceLocator.Resolve<IDialogService>());
        }

        /// <summary>
        ///A test for UnRegister
        ///</summary>
        [TestMethod()]
        public void UnRegisterTest()
        {
            ServiceLocator.UnRegister<IDialogService, DialogService>();
        }

        /// <summary>
        ///A test for UnRegister - Singleton = true
        ///</summary>
        [TestMethod()]
        public void UnRegister_isSingletonTrueTest()
        {
            ServiceLocator.UnRegister<IDialogService, DialogService>(true);
        }

        /// <summary>
        ///A test for UnRegister - Singleton = false
        ///</summary>
        [TestMethod()]
        public void UnRegister_isSingletonFalseTest()
        {
            ServiceLocator.UnRegister<IDialogService, DialogService>(false);
        }

        /// <summary>
        ///A test for UnRegisterSingleton
        ///</summary>
        [TestMethod()]
        public void UnRegisterSingletonTest()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
        }
    }
}
