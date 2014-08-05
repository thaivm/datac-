using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Business.FileSetting;
using System.Windows.Forms;
using LogViewer.Service.FrameworkDialogs;
using System.Collections.Generic;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{


    /// <summary>
    ///This is a test class for SaveFileDialogViewModelTest and is intended
    ///to contain all SaveFileDialogViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SaveFileDialogViewModelTest
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
        ///A test for SaveFileDialogViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void SaveFileDialogViewModelConstructorTest()
        {
            LogViewer.ViewModel.SaveFileDialogViewModel target = new LogViewer.ViewModel.SaveFileDialogViewModel();
        }

        /// <summary>
        ///A test for ShowDialog - return false
        ///</summary>
        //[TestMethod()]
        //public void ShowDialog_FalseTest()
        //{
        //    //init value
        //    LogViewer.ViewModel.SaveFileDialogViewModel_Accessor target = new LogViewer.ViewModel.SaveFileDialogViewModel_Accessor();
        //    DialogService dlg = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(dlg);
        //    target.FileName = "Click Cancel button";

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //assign value of DialogService -> SaveFileDialogViewModel_Accessor._dialogService
        //    LogViewer.ViewModel.SaveFileDialogViewModel_Accessor._dialogService = dlg;

        //    //result
        //    bool result = (bool) target.ShowDialog(viewModel);
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //    Assert.IsFalse(result);
        //}

        /// <summary>
        ///A test for ShowDialog - return true
        ///</summary>
        //[TestMethod()]
        //public void ShowDialog_TrueTest()
        //{
        //    //init value
        //    LogViewer.ViewModel.SaveFileDialogViewModel_Accessor target = new LogViewer.ViewModel.SaveFileDialogViewModel_Accessor();
        //    DialogService dlg = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(dlg);
        //    target.FileName = "Select and click Save button";

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //assign value of DialogService -> SaveFileDialogViewModel_Accessor._dialogService
        //    LogViewer.ViewModel.SaveFileDialogViewModel_Accessor._dialogService = dlg;

        //    //result
        //    bool result = (bool)target.ShowDialog(viewModel);
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //    Assert.IsNotNull(result);
        //}

        /// <summary>
        ///A test for DefaultExt
        ///</summary>
        [TestMethod()]
        public void DefaultExtTest()
        {
            LogViewer.ViewModel.SaveFileDialogViewModel target = new LogViewer.ViewModel.SaveFileDialogViewModel(); // TODO: Initialize to an appropriate value
            string expected = "DefaultExtTest"; // TODO: Initialize to an appropriate value
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
            LogViewer.ViewModel.SaveFileDialogViewModel target = new LogViewer.ViewModel.SaveFileDialogViewModel(); // TODO: Initialize to an appropriate value
            string expected = "FileNameTest"; // TODO: Initialize to an appropriate value
            string actual;
            target.FileName = expected;
            actual = target.FileName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Filter
        ///</summary>
        [TestMethod()]
        public void FilterTest()
        {
            LogViewer.ViewModel.SaveFileDialogViewModel target = new LogViewer.ViewModel.SaveFileDialogViewModel(); // TODO: Initialize to an appropriate value
            string expected = "FilterTest"; // TODO: Initialize to an appropriate value
            string actual;
            target.Filter = expected;
            actual = target.Filter;
            Assert.AreEqual(expected, actual);
        }
    }
}
