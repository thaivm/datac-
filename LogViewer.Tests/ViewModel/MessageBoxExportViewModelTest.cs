using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Windows.Controls;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for MessageBoxExportViewModelTest and is intended
    ///to contain all MessageBoxExportViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MessageBoxExportViewModelTest
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
            if (!ServiceLocator.services.ContainsKey(typeof(IOpenFileDialog)))
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
        ///A test for OkCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void OkCommandCLTest()
        {
            MessageBoxExportViewModel target = new MessageBoxExportViewModel(); // TODO: Initialize to an appropriate value
            target.OnOkEvent += new Action(() =>
                {
                });
            PrivateObject obj = new PrivateObject(target);
            obj.Invoke("OkCommandCL");
            Assert.IsNotNull(obj);
        }

        /// <summary>
        ///A test for Caption
        ///</summary>
        [TestMethod()]
        public void CaptionTest()
        {
            MessageBoxExportViewModel target = new MessageBoxExportViewModel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Caption = expected;
            actual = target.Caption;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Directory
        ///</summary>
        [TestMethod()]
        public void DirectoryTest()
        {
            MessageBoxExportViewModel target = new MessageBoxExportViewModel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Directory = expected;
            actual = target.Directory;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Extension
        ///</summary>
        [TestMethod()]
        public void ExtensionTest()
        {
            MessageBoxExportViewModel target = new MessageBoxExportViewModel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Extension = expected;
            actual = target.Extension;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        [TestMethod()]
        public void FileNameTest()
        {
            MessageBoxExportViewModel target = new MessageBoxExportViewModel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.FileName = expected;
            actual = target.FileName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OkCommand
        ///</summary>
        [TestMethod()]
        public void OkCommandTest()
        {
            MessageBoxExportViewModel target = new MessageBoxExportViewModel(); // TODO: Initialize to an appropriate value
            ICommand actual;
            actual = target.OkCommand;
            Assert.IsNotNull(actual);
        }
    }
}
