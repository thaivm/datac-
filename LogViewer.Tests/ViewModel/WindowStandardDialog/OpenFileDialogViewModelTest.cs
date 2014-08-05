using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.ViewModel;
using System.Windows.Forms;
using LogViewer.Model;
using LogViewer.Service;
using System.Windows;
using System.Collections.Generic;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using Moq;

namespace LogViewer.Tests
{


    /// <summary>
    ///This is a test class for OpenFileDialogViewModelTest and is intended
    ///to contain all OpenFileDialogViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OpenFileDialogViewModelTest
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
        ///A test for OpenFileDialogViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void OpenFileDialogViewModelConstructorTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel
            {
                Filter = ConfigValue.MemoFilterFile
            };
            Assert.AreEqual(target.Filter, ConfigValue.MemoFilterFile);
        }

        /// <summary>
        ///A test for ShowDialog - Click Open button
        ///</summary>
        //[TestMethod()]
        //public void ShowDialog_OpenTest()
        //{
        //    //init value
        //    LogViewer.ViewModel.OpenFileDialogViewModel_Accessor target = new LogViewer.ViewModel.OpenFileDialogViewModel_Accessor { };
        //    DialogService dlg = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(dlg);
        //    target.FileName = "Click Open button";

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //assign value of DialogService -> SaveFileDialogViewModel_Accessor._dialogService
        //    LogViewer.ViewModel.OpenFileDialogViewModel_Accessor._dialogService = dlg;

        //    //result
        //    var result = target.ShowDialog(viewModel);
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //    Assert.IsNotNull(result);
        //}

        /// <summary>
        ///A test for ShowDialog - Click Cancel button
        ///</summary>
        //[TestMethod()]
        //public void ShowDialog_CancelTest()
        //{
        //    //init value
        //    LogViewer.ViewModel.OpenFileDialogViewModel_Accessor target = new LogViewer.ViewModel.OpenFileDialogViewModel_Accessor { };
        //    DialogService dlg = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(dlg);
        //    target.FileName = "Click Cancel button";

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> {el});

        //    //assign value of DialogService -> SaveFileDialogViewModel_Accessor._dialogService
        //    LogViewer.ViewModel.OpenFileDialogViewModel_Accessor._dialogService = dlg;

        //    //result
        //    var result = target.ShowDialog(viewModel);
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //    Assert.AreEqual(DialogResult.Cancel, result);
        //}

        /// <summary>
        ///A test for AddExtension
        ///</summary>
        [TestMethod()]
        public void AddExtensionTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            bool expected = false;
            bool actual;
            target.AddExtension = expected;
            actual = target.AddExtension;
            Assert.AreEqual(expected, actual);
        }

         ///</summary>
        ///A test for CheckFileExists
        ///</summary>
        [TestMethod()]
        public void CheckFileExistsTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            bool expected = false;
            bool actual;
            target.CheckFileExists = expected;
            actual = target.CheckFileExists;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CheckPathExists
        ///</summary>
        [TestMethod()]
        public void CheckPathExistsTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            bool expected = false;
            bool actual;
            target.CheckPathExists = expected;
            actual = target.CheckPathExists;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DefaultExt
        ///</summary>
        [TestMethod()]
        public void DefaultExtTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            string expected = "DefaultExtTest";
            string actual;
            target.DefaultExt = expected;
            actual = target.DefaultExt;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        [TestMethod()]
        public void FileNameTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            string expected = "FileNameTest";
            string actual;
            target.FileName = expected;
            actual = target.FileName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FileNames
        ///</summary>
        [TestMethod()]
        public void FileNamesTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            string[] expected = new string[] { "File Name", "Test" };
            string[] actual;
            target.FileNames = expected;
            actual = target.FileNames;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Filter
        ///</summary>
        [TestMethod()]
        public void FilterTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            string expected = "FilterTest";
            string actual;
            target.Filter = expected;
            actual = target.Filter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InitialDirectory
        ///</summary>
        [TestMethod()]
        public void InitialDirectoryTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            string expected = "InitialDirectoryTest";
            string actual;
            target.InitialDirectory = expected;
            actual = target.InitialDirectory;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Multiselect
        ///</summary>
        [TestMethod()]
        public void MultiselectTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            bool expected = false;
            bool actual;
            target.Multiselect = expected;
            actual = target.Multiselect;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Title
        ///</summary>
        [TestMethod()]
        public void TitleTest()
        {
            LogViewer.ViewModel.OpenFileDialogViewModel target = new LogViewer.ViewModel.OpenFileDialogViewModel { };
            string expected = "TitleTest";
            string actual;
            target.Title = expected;
            actual = target.Title;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShowDialogTest()
        {
            var idlg = new Mock<IDialogService>();
            idlg.Setup(x => x.ShowOpenFileDialog(It.IsAny<object>(), It.IsAny<IOpenFileDialog>())).Returns(DialogResult.OK);
            var target = new LogViewer.ViewModel.OpenFileDialogViewModel();
            PrivateType po = new PrivateType(typeof(BaseWindowStandardDialogViewModel));
            po.SetStaticField("_dialogService", idlg.Object);
            var result = target.ShowDialog(null);
            Assert.AreEqual(DialogResult.OK, result);
        }
    }
}
