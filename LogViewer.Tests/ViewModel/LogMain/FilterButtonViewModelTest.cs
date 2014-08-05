using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Model;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for FilterButtonViewModelTest and is intended
    ///to contain all FilterButtonViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FilterButtonViewModelTest
    {

        public FilterButtonViewModel_Accessor target;
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
            Action onClickEvent = new Action(() => { }); 
            target = new FilterButtonViewModel_Accessor(new PrivateObject(new FilterButtonViewModel(ConfigValue.DefaultColorFilterItem.Copy(), onClickEvent)));
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
        ///A test for Background
        ///</summary>
        [TestMethod()]
        public void BackgroundTest()
        {
            string actual;
            actual = target.Background;
            Assert.AreEqual(ConfigValue.DefaultColorFilterItem.Background, actual);
        }

        /// <summary>
        ///A test for Enabled
        ///</summary>
        [TestMethod()]
        public void EnabledTest()
        {
            bool expected = false;
            bool actual;
            target.Enabled = expected;
            actual = target.Enabled;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FontStyle
        ///</summary>
        [TestMethod()]
        public void FontStyleTest()
        {
            string actual;
            actual = target.FontStyle;
            Assert.AreEqual(ConfigValue.DefaultColorFilterItem.FontStyle, actual);
        }

        /// <summary>
        ///A test for Foreground
        ///</summary>
        [TestMethod()]
        public void ForegroundTest()
        {
            string actual;
            actual = target.Foreground;
            Assert.AreEqual(ConfigValue.DefaultColorFilterItem.Foreground, actual);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string actual;
            actual = target.Name;
            Assert.AreEqual(ConfigValue.DefaultColorFilterItem.Name, actual);
        }
    }
}
