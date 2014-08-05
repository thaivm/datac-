using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.ViewModel;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SetLogDisplayViewModelTest and is intended
    ///to contain all SetLogDisplayViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SetLogDisplayViewModelTest
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
                ServiceLocator.Register<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
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
        ///A test for SetLogDisplayViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void SetLogDisplayViewModelConstructorTest()
        {
            SetLogDisplayViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for GetDataToApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetDataToApplyTest()
        {
            SetLogDisplayViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            PrivateObject expected = new PrivateObject(target);
            List<LogDisplay> ccsDisplaySettings = targetMainVM.CCSMainVM.SettingManager.DisplaySetting;
            List<LogDisplay> cxdiDisplaySettings = targetMainVM.CXDIMainVM.SettingManager.DisplaySetting;
            target.CCSDisplaySettings.Add(new LogDisplayRecordViewModel(ccsDisplaySettings[0]));
            target.CXDIDisplaySettings.Add(new LogDisplayRecordViewModel(cxdiDisplaySettings[0]));
            var result = expected.Invoke("GetDataToApply");
            Assert.IsInstanceOfType(result, typeof(List<List<LogDisplay>>));
        }

        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        public void LoadDataTest()
        {
            SetLogDisplayViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            List<LogDisplay> ccsDisplaySettings = targetMainVM.CCSMainVM.SettingManager.DisplaySetting; // TODO: Initialize to an appropriate value
            List<LogDisplay> cxdiDisplaySettings = targetMainVM.CXDIMainVM.SettingManager.DisplaySetting; // TODO: Initialize to an appropriate value
            target.LoadData(ccsDisplaySettings, cxdiDisplaySettings);
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CCSDisplaySettings
        ///</summary>
        [TestMethod()]
        public void CCSDisplaySettingsTest()
        {
            SetLogDisplayViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            ObservableCollection<LogDisplayRecordViewModel> expected = null;
            target.CCSDisplaySettings = null;
            ObservableCollection<LogDisplayRecordViewModel> actual;
            actual = target.CCSDisplaySettings;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CXDIDisplaySettings
        ///</summary>
        [TestMethod()]
        public void CXDIDisplaySettingsTest()
        {
            SetLogDisplayViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            ObservableCollection<LogDisplayRecordViewModel> expected = null;
            target.CXDIDisplaySettings = null;
            ObservableCollection<LogDisplayRecordViewModel> actual;
            actual = target.CXDIDisplaySettings;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CanApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanApplyIsTrueTest()
        {
            SetLogDisplayViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            List<LogDisplay> ccsDisplaySettings = targetMainVM.CCSMainVM.SettingManager.DisplaySetting; 
            List<LogDisplay> cxdiDisplaySettings = targetMainVM.CXDIMainVM.SettingManager.DisplaySetting;
            target.CCSDisplaySettings.Add(new LogDisplayRecordViewModel(ccsDisplaySettings[0]));
            target.CXDIDisplaySettings.Add(new LogDisplayRecordViewModel(cxdiDisplaySettings[0]));
            PrivateObject expected = new PrivateObject(target);
            Assert.AreEqual(expected.GetFieldOrProperty("CanApply"), true);
        }

        /// <summary>
        ///A test for CanApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanApplyIsFalseTest()
        {
            SetLogDisplayViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            PrivateObject expected = new PrivateObject(target);
            Assert.AreEqual(expected.GetFieldOrProperty("CanApply"), false);
        }

        /// <summary>
        ///A test for ErrorMessage
        ///</summary>
        [TestMethod()]
        public void ErrorMessageTest()
        {
            SetLogDisplayViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            string expected = string.Empty;
            target.ErrorMessage = string.Empty;
            string actual;
            actual = target.ErrorMessage;
            Assert.AreEqual(expected, actual);
        }
    }
}
