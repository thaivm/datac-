using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Model;
using LogViewer.CustomException;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SetFontStyleDialogViewModelTest and is intended
    ///to contain all SetFontStyleDialogViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SetFontStyleDialogViewModelTest
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
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
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
        ///A test for GetDataToApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetDataToApplyTest()
        {
            string FontStyle = ConfigValue.DefaultFilterItemFontStyle;
            SetFontStyleDialogViewModel target = new SetFontStyleDialogViewModel(
                (x => FontStyle = x), FontStyle);
            target.SelectedValue = "Bold";
            var expeted = target.SelectedValue;
            PrivateObject param0 = new PrivateObject(target);            
            var actual = param0.Invoke("GetDataToApply");
            Assert.AreEqual(expeted, actual);
        }

        /// <summary>
        ///A test for AllFontStyle
        ///</summary>
        [TestMethod()]
        public void AllFontStyleTest()
        {
            string FontStyle = ConfigValue.DefaultFilterItemFontStyle;
            SetFontStyleDialogViewModel target = new SetFontStyleDialogViewModel(
                (x => FontStyle = x), FontStyle); // TODO: Initialize to an appropriate value
            ObservableCollection<string> expected = new ObservableCollection<string>(ConfigValue.FilterSettingFontStyles.AllFontStyle); // TODO: Initialize to an appropriate value
            ObservableCollection<string> actual;
            target.AllFontStyle = expected;
            actual = target.AllFontStyle;
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectedValue
        ///</summary>
        [TestMethod()]
        public void SelectedValueTest()
        {
            string FontStyle = ConfigValue.DefaultFilterItemFontStyle;
            SetFontStyleDialogViewModel target = new SetFontStyleDialogViewModel(
                (x => FontStyle = x), FontStyle); // TODO: Initialize to an appropriate value
            string expected = "Bold";
            string actual;
            target.SelectedValue = expected;
            actual = target.SelectedValue;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectedValue
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(DataValueNotSupportedException))]
        public void SelectedValueIsNullTest()
        {
            string fontStyle = "Bold";
            SetFontStyleDialogViewModel target = new SetFontStyleDialogViewModel(
                 (x => fontStyle = x), fontStyle);
            target.SelectedValue = string.Empty;
        }
    }
}
