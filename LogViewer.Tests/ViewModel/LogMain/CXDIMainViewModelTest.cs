using LogViewer.Business.FileSetting;
using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using System.Collections.Generic;
using LogViewer.MVVMHelper;
using LogViewer.Model;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.IO;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CXDIMainViewModelTest and is intended
    ///to contain all CXDIMainViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CXDIMainViewModelTest
    {

        public static MainViewModel_Accessor targetMainVM;
        public static CXDIMainViewModel_Accessor target;
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
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CXDIMainVM);
            target = new CXDIMainViewModel_Accessor(param0);
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
        ///A test for ClearAllCommandCL
        ///</summary>
        [TestMethod()]
        public void ClearAllCommandCLTest()
        {
            target.ClearAllCommandCL();
            Assert.AreEqual(false, targetMainVM.CXDIMainVM.IsOnNarrowColorFilter);
            Assert.AreEqual(0, targetMainVM.CXDIMainVM.LogAnalyser.PatternAnalyzeBuffer.Count);
        }

        /// <summary>
        ///A test for ClearAnalyzeCommandCL
        ///</summary>
        [TestMethod()]
        public void ClearAnalyzeCommandCLTest()
        {
            target.ClearAnalyzeCommandCL();
            Assert.AreEqual(0, targetMainVM.CXDIMainVM.LogAnalyser.PatternAnalyzeBuffer.Count);
        }

        /// <summary>
        ///A test for DragDropFile
        ///</summary>
        //[TestMethod()]
        //public void DragDropFileTest()
        //{
        //    DataGridDragDropEventArgs args = null; // TODO: Initialize to an appropriate value
        //    target.DragDropFile(args);
        //    //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        /// <summary>
        ///A test for EditFilterSettingCL
        ///</summary>
        [TestMethod()]
        public void EditFilterSettingCLTest()
        {
            target.EditFilterSettingCL();
        }

        /// <summary>
        ///A test for EditKeywordCountSettingCL
        ///</summary>
        [TestMethod()]
        public void EditKeywordCountSettingCLTest()
        {
            target.EditKeywordCountSettingCL();
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EditPatternSettingCL
        ///</summary>
        [TestMethod()]
        public void EditPatternSettingCLTest()
        {
            target.EditPatternSettingCL();
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetDefaultLogItem
        ///</summary>
        [TestMethod()]
        public void GetDefaultLogItemTest()
        {
            string expected = "Message";
            string actual;
            actual = target.GetDefaultLogItem();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetExportFilePath
        ///</summary>
        [TestMethod()]
        public void GetExportFilePathTest()
        {
            string expected = "MemoCXDI"; 
            string actual;
            actual = target.GetExportFilePath();
            Assert.IsTrue(actual.Contains(expected));
        }

        /// <summary>
        ///A test for InitLogItemList
        ///</summary>
        [TestMethod()]
        public void InitLogItemListTest()
        {
            List<ValueDisplayPair<string, string>> actual;
            actual = target.InitLogItemList();
            Assert.AreEqual("Line ", actual[0].Display);
            Assert.AreEqual("Date", actual[1].Display);
            Assert.AreEqual("Time", actual[2].Display);
            Assert.AreEqual("Module", actual[3].Display);
            Assert.AreEqual("Message", actual[4].Display);
            Assert.AreEqual("Comment", actual[5].Display);
        }

        /// <summary>
        ///A test for LoadConfig
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDIFilteringSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCXDIKeywordSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCXDIPatternSetting.xml")]
        public void LoadConfigTest()
        {
            string oldDefaultCXDIFilteringSetting = ConfigValue.DefaultCXDIFilteringSettingFile;
            string DefaultCXDIFilteringSetting = @"DefaultCXDIFilteringSetting.csv";
            ConfigValue.DefaultCXDIFilteringSettingFile = Path.GetFullPath(DefaultCXDIFilteringSetting);

            string oldDefaultCXDIKeywordSetting = ConfigValue.DefaultCXDIKeywordSettingFile;
            string DefaultCXDIKeywordSetting = @"DefaultCXDIKeywordSetting.csv";
            ConfigValue.DefaultCXDIKeywordSettingFile = Path.GetFullPath(DefaultCXDIKeywordSetting);

            string oldDefaultCXDILogSetting = ConfigValue.DefaultCXDILogSettingFile;
            string DefaultCXDILogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCXDILogSettingFile = Path.GetFullPath(DefaultCXDILogSetting);

            string oldDefaultCXDIPatternSetting = ConfigValue.DefaultCXDIPatternSettingFile;
            string DefaultCXDIPatternSetting = @"DefaultCXDIPatternSetting.csv";
            ConfigValue.DefaultCXDIPatternSettingFile = Path.GetFullPath(DefaultCXDIPatternSetting);

            string expected = string.Empty;
            string actual;
            actual = target.LoadConfig();
            Assert.IsNotNull(actual);

            ConfigValue.DefaultCXDIFilteringSettingFile = oldDefaultCXDIFilteringSetting;
            ConfigValue.DefaultCXDIKeywordSettingFile = oldDefaultCXDIKeywordSetting;
            ConfigValue.DefaultCXDILogSettingFile = oldDefaultCXDILogSetting;
            ConfigValue.DefaultCXDIPatternSettingFile = oldDefaultCXDIPatternSetting;
        }

        /// <summary>
        ///A test for LoadFirmware
        ///</summary>
        [TestMethod()]
        public void LoadFirmwareTest()
        {
            target.LoadFirmware();
            Assert.IsTrue(target.AnalyzeAreaVM.FirmwareInfoTabVM.CXDIFirmware == null || (target.AnalyzeAreaVM.FirmwareInfoTabVM.CXDIFirmware.Counter.Count == 0 && target.AnalyzeAreaVM.FirmwareInfoTabVM.CXDIFirmware.Saved.Count == 0));
        }

        ///// <summary>
        /////A test for LoadLogFileCL
        /////</summary>
        //[TestMethod()]
        //public void LoadLogFileCLTest()
        //{
        //    //target.LoadLogFileCL();
        //    //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        ///// <summary>
        /////A test for LoadMemoLogFileCL
        /////</summary>
        //[TestMethod()]
        //public void LoadMemoLogFileCLTest()
        //{
        //    //target.LoadMemoLogFileCL();
        //    //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        ///// <summary>
        /////A test for ShowGraphCommandCL
        /////</summary>
        //[TestMethod()]
        //public void ShowGraphCommandCLTest()
        //{
        //   // target.ShowGraphCommandCL();
        //}

        /// <summary>
        ///A test for StartAllAnalyProcess
        ///</summary>
        [TestMethod()]
        public void StartAllAnalyProcessTest()
        {
            target.StartAllAnalyzeProcess();
            Assert.AreEqual(0, target.AnalyzeAreaVM.CountKeywordTabVM.AnalyzeCountKeywordItems.Count);
        }

        /// <summary>
        ///A test for ValidLogFileExtension
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\Test.xml")]
        public void ValidLogFileExtensionFilePathNotValidTest()
        {
            string fileError = @"Test.xml";
            string FilePath = Path.GetFullPath(fileError);
            bool expected = false;
            bool actual;
            actual = target.ValidLogFileExtension(FilePath);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidLogFileExtension
        ///</summary>
        [TestMethod()]
        public void ValidLogFileExtensionFilePathIsEmptyTest()
        {
            string FilePath = string.Empty;
            bool expected = false;
            bool actual;
            actual = target.ValidLogFileExtension(FilePath);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidLogFileExtension
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParser.log")]
        public void ValidLogFileExtensionFilePathIsValidTest()
        {
            string fileError = @"TestCXDIParser.log";
            string FilePath = Path.GetFullPath(fileError);
            bool expected = true;
            bool actual;
            actual = target.ValidLogFileExtension(FilePath);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for contains
        ///</summary>
        [TestMethod()]
        public void containsTest()
        {
            CXDILogRecord record = new CXDILogRecord();
            record.Message = "test test";
            string key = "test";
            bool expected = true;
            bool actual;
            actual = target.contains(record, key);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AnalyzeAreaVM
        ///</summary>
        [TestMethod()]
        public void AnalyzeAreaVMTest()
        {
            CXDIAnalyzeAreaViewModel actual;
            actual = target.AnalyzeAreaVM;
            Assert.IsNotNull(actual.LogBookmarkTabVM);
            Assert.IsNotNull(actual.FirmwareInfoTabVM);
            Assert.IsNotNull(actual.LogPatternTabVM);
            Assert.IsNotNull(actual.CountKeywordTabVM);
        }

        /// <summary>
        ///A test for LogAnalyser
        ///</summary>
        [TestMethod()]
        public void LogAnalyserTest()
        {
            CXDILogsAnalyser actual;
            actual = target.LogAnalyser;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for OpenFileFilter
        ///</summary>
        [TestMethod()]
        public void OpenFileFilterTest()
        {
            string actual;
            actual = target.OpenFileFilter;
            Assert.IsTrue(actual.Contains("*.log"));
        }

        /// <summary>
        ///A test for OpenMemoFilterFile
        ///</summary>
        [TestMethod()]
        public void OpenMemoFilterFileTest()
        {
            string actual;
            actual = target.OpenMemoFilterFile;
            Assert.IsTrue(actual.Contains("*.xml"));
        }

        /// <summary>
        ///A test for SettingManager
        ///</summary>
        [TestMethod()]
        public void SettingManagerTest()
        {
            CXDISettingManager actual;
            actual = target.SettingManager;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ShowGraphCommand
        ///</summary>
        [TestMethod()]
        public void ShowGraphCommandTest()
        {
            object mainViewVM = null;
            CXDISettingManager settingManager = null;
            Action<string, string> onFollowOtherLogEvent = null;
            CXDIMainViewModel target = new CXDIMainViewModel(mainViewVM, settingManager, onFollowOtherLogEvent, null);
            ICommand actual;
            actual = target.ShowGraphCommand;
        }
    }
}
