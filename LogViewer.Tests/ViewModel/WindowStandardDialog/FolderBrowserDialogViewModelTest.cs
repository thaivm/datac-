using LogViewer.Service.FrameworkDialogs.FolderBrowse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.ViewModel;
using System.Windows.Forms;
using LogViewer.Service;
using System.Windows;
using System.Collections.Generic;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Service.FrameworkDialogs.OpenFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for FolderBrowserDialogViewModelTest and is intended
    ///to contain all FolderBrowserDialogViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FolderBrowserDialogViewModelTest
    {
        public static LogViewer.ViewModel.FolderBrowserDialogViewModel_Accessor target;

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
            target = new LogViewer.ViewModel.FolderBrowserDialogViewModel_Accessor();
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
        ///A test for FolderBrowserDialogViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void FolderBrowserDialogViewModelConstructorTest()
        {
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            string expected = "Select file"; // TODO: Initialize to an appropriate value
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectedPath
        ///</summary>
        [TestMethod()]
        public void SelectedPathTest()
        {
            string expected = "C:\\Test\\"; // TODO: Initialize to an appropriate value
            string actual;
            target.SelectedPath = expected;
            actual = target.SelectedPath;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ShowNewFolderButton
        ///</summary>
        [TestMethod()]
        public void ShowNewFolderButtonTest()
        {
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ShowNewFolderButton = expected;
            actual = target.ShowNewFolderButton;
            Assert.AreEqual(expected, actual);
        }



        
    }
}
