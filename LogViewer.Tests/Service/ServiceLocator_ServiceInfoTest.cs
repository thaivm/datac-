using LogViewer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.FolderBrowse;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ServiceLocator_ServiceInfoTest and is intended
    ///to contain all ServiceLocator_ServiceInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServiceLocator_ServiceInfoTest
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
        ///A test for ServiceInfo Constructor - isSingleton true
        ///</summary>
        [TestMethod()]
        public void ServiceLocator_ServiceInfoConstructor_isSingletonTrueTest()
        {
            Type serviceImplementationType = typeof(DialogService); // TODO: Initialize to an appropriate value
            bool isSingleton = true; // TODO: Initialize to an appropriate value
            ServiceLocator.ServiceInfo target = new ServiceLocator.ServiceInfo(serviceImplementationType, isSingleton);
        }

        /// <summary>
        ///A test for ServiceInfo Constructor - isSingleton false
        ///</summary>
        [TestMethod()]
        public void ServiceLocator_ServiceInfoConstructor_isSingletonFalseTest()
        {
            Type serviceImplementationType = typeof(DialogService); // TODO: Initialize to an appropriate value
            bool isSingleton = false; // TODO: Initialize to an appropriate value
            ServiceLocator.ServiceInfo target = new ServiceLocator.ServiceInfo(serviceImplementationType, isSingleton);
        }

        /// <summary>
        ///A test for CreateInstance - !services.ContainsKey(type)
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateInstance_NotContainsKeyTest()
        {
            Type type = typeof(DialogService);
            ServiceLocator_Accessor.ServiceInfo.CreateInstance(type);
        }

        /// <summary>
        ///A test for CreateInstance - services.ContainsKey(type)
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateInstance_ContainsKeyTest()
        {
            Type type = typeof(IDialogService);
            ServiceLocator_Accessor.ServiceInfo.CreateInstance(type);
        }

        /// <summary>
        ///A test for ServiceImplementation - isSingleton = false
        ///</summary>
        [TestMethod()]
        public void ServiceImplementation_isSingletonFalseTest()
        {
            Type serviceImplementationType = typeof(DialogService); // TODO: Initialize to an appropriate value
            bool isSingleton = false; // TODO: Initialize to an appropriate value
            ServiceLocator.ServiceInfo target = new ServiceLocator.ServiceInfo(serviceImplementationType, isSingleton); // TODO: Initialize to an appropriate value
            Assert.IsNotNull(target.ServiceImplementation);
        }

        /// <summary>
        ///A test for ServiceImplementation - isSingleton = false and serviceImplementationType = null
        ///</summary>
        [TestMethod()]
        public void ServiceImplementation_isSingletonTrue_serviceImplementationNullTest()
        {
            Type serviceImplementationType = typeof(DialogService); // TODO: Initialize to an appropriate value
            bool isSingleton = true; // TODO: Initialize to an appropriate value
            ServiceLocator.ServiceInfo target = new ServiceLocator.ServiceInfo(serviceImplementationType, isSingleton); // TODO: Initialize to an appropriate value
            Assert.IsNotNull(target.ServiceImplementation);
        }

        /// <summary>
        ///A test for ServiceImplementation - isSingleton = false and serviceImplementationType != null
        ///</summary>
        [TestMethod()]
        public void ServiceImplementation_isSingletonTrue_serviceImplementationNotNullTest()
        {
            Type serviceImplementationType = typeof(IDialogService); // TODO: Initialize to an appropriate value
            bool isSingleton = true; // TODO: Initialize to an appropriate value
            ServiceLocator_Accessor.ServiceInfo target = new ServiceLocator_Accessor.ServiceInfo(serviceImplementationType, isSingleton);
            target.serviceImplementation = new object();
            Assert.IsNotNull(target.ServiceImplementation);
        }
    }
}
