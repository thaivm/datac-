using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using LogViewer.Model;
using System.Collections.Generic;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.IO;
using System.ComponentModel;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CCSMainViewModelTest and is intended
    ///to contain all CCSMainViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CCSMainViewModelTest
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
        ///A test for AnalyzeErrorAction
        ///</summary>
        [TestMethod()]
        public void AnalyzeErrorActionTestForErrorListIsNull()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            IList<ErrorActionItem> errorActions = null;
            target.AnalyzeErrorAction(errorActions);
            Assert.IsTrue(target.AnalyzeAreaVM.ErrorActionTabVM.ErrorActionList == null || target.AnalyzeAreaVM.ErrorActionTabVM.ErrorActionList.Count == 0);
        }

        /// <summary>
        ///A test for AnalyzeErrorAction
        ///</summary>
        [TestMethod()]
        public void AnalyzeErrorActionTest()
        {

            string text =
@"ErrorLv,030101001,ErrorMessage,ErrorRecipe
ErrorLv,020200017,ErrorMessage,ErrorRecipe
ErrorLv,040600001,ErrorMessage,ErrorRecipe
ErrorLv,030101003,ErrorMessage,ErrorRecipe";

            string filenameUser = string.Format("AnalyzeErrorActionTest{0}.csv", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filenameUser, text);
            string fileFullPath = Path.GetFullPath(filenameUser);

            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            string oldConfigString = ConfigValue.ErrorActionList;
            ConfigValue.ErrorActionList = fileFullPath;
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.SettingManager.ReadErrorActionSetting();
            List<ErrorActionItem> errorActions = new List<ErrorActionItem>(target.SettingManager.ErrorActionSettingList);
            target.AnalyzeErrorAction(errorActions);
            Assert.AreEqual(0, target.AnalyzeAreaVM.ErrorActionTabVM.ErrorActionList.Count);
            ConfigValue.ErrorActionList = oldConfigString;
            File.Delete(fileFullPath);
        }
        /// <summary>
        ///A test for AnalyzeUserAction
        ///</summary>
        [TestMethod()]
        public void AnalyzeUserActionTestUserListIsNull()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0); 
            List<UserActionItem> userActions = null;
            target.AnalyzeUserAction(userActions);
            Assert.IsNull(target.AnalyzeAreaVM.UserActionTabVM.UserActionList);
        }

        /// <summary>
        ///A test for AnalyzeUserAction
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"ActionList\UserActionList.csv")]
        public void AnalyzeUserActionTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            List<UserActionItem> userActions = new List<UserActionItem>(target.SettingManager.UserActionSettingList);
            string oldConfigString = ConfigValue.UserActionList;
            string fileError = @"UserActionList.csv";
            string dir = Path.GetFullPath(fileError);
            ConfigValue.UserActionList = dir;
            target.AnalyzeUserAction(userActions);
            Assert.AreEqual(0, target.AnalyzeAreaVM.UserActionTabVM.UserActionList.Count);
            ConfigValue.UserActionList = oldConfigString;
        }

        /// <summary>
        ///A test for ClearAllCommandCL
        ///</summary>
        [TestMethod()]
        public void ClearAllCommandCLTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.ClearAllCommandCL();
            Assert.AreEqual(false, targetMainVM.CCSMainVM.IsOnNarrowColorFilter);
            Assert.AreEqual(0, targetMainVM.CCSMainVM.LogAnalyser.PatternAnalyzeBuffer.Count);
        }

        /// <summary>
        ///A test for ClearAnalyzeCommandCL
        ///</summary>
        [TestMethod()]
        public void ClearAnalyzeCommandCLTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.ClearAnalyzeCommandCL();
            Assert.AreEqual(0, targetMainVM.CCSMainVM.LogAnalyser.PatternAnalyzeBuffer.Count);
        }

        /// <summary>
        ///A test for ClearWhenLoadFile
        ///</summary>
        [TestMethod()]
        public void ClearWhenLoadFileTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.ClearWhenLoadFile();
            Assert.AreEqual(0, target.AnalyzeAreaVM.UserActionTabVM.UserActionList.Count);
            Assert.AreEqual(0, target.AnalyzeAreaVM.ErrorActionTabVM.ErrorActionList.Count);
        }

        /// <summary>
        ///A test for EditFilterSettingCL
        ///</summary>
        [TestMethod()]
        public void EditFilterSettingCLTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.EditFilterSettingCL();
        }

        /// <summary>
        ///A test for EditKeywordCountSettingCL
        ///</summary>
        [TestMethod()]
        public void EditKeywordCountSettingCLTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.EditKeywordCountSettingCL();
        }

        /// <summary>
        ///A test for EditPatternSettingCL
        ///</summary>
        [TestMethod()]
        public void EditPatternSettingCLTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.EditPatternSettingCL();
        }



        /// <summary>
        ///A test for ErrorActionCommandCL
        ///</summary>
        [TestMethod()]
        public void ErrorActionCommandCL()
        {

            string text =
            @"ErrorLv,030101001,ErrorMessage,ErrorRecipe
ErrorLv,020200017,ErrorMessage,ErrorRecipe
ErrorLv,040600001,ErrorMessage,ErrorRecipe
ErrorLv,030101003,ErrorMessage,ErrorRecipe";

            string filenameUser = string.Format("AnalyzeErrorActionTest{0}.csv", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filenameUser, text);
            string fileFullPath = Path.GetFullPath(filenameUser);

            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            string oldConfigString = ConfigValue.ErrorActionList;
            ConfigValue.ErrorActionList = fileFullPath;
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.ErrorActionCommandCL();
            Assert.AreEqual(0, target.AnalyzeAreaVM.ErrorActionTabVM.ErrorActionList.Count);
            ConfigValue.ErrorActionList = oldConfigString;
            File.Delete(fileFullPath);
        }
        
        /// <summary>
        ///A test for GetDefaultLogItem
        ///</summary>
        [TestMethod()]
        public void GetDefaultLogItemTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            string expected = "Content";
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
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            string expected = "MemoCCS"; 
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
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            List<ValueDisplayPair<string, string>> actual;
            actual = target.InitLogItemList();
            Assert.AreEqual("Line ", actual[0].Display);
            Assert.AreEqual("Date", actual[1].Display);
            Assert.AreEqual("Time", actual[2].Display);
            Assert.AreEqual("Host Name", actual[3].Display);
            Assert.AreEqual("Thread ID", actual[4].Display);
            Assert.AreEqual("Log Type", actual[5].Display);
            Assert.AreEqual("Log Id", actual[6].Display);
            Assert.AreEqual("Content", actual[7].Display);
            Assert.AreEqual("Additional Info", actual[8].Display);
            Assert.AreEqual("Personal Info", actual[9].Display);
            Assert.AreEqual("Class Name", actual[10].Display);
            Assert.AreEqual("Comment", actual[11].Display);
        }

        /// <summary>
        ///A test for LoadConfig
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCCSFilteringSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCCSKeywordSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCCSLogSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCCSPatternSetting.xml")]
        public void LoadConfigTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);

            string oldDefaultCCSFilteringSetting = ConfigValue.DefaultCCSFilteringSettingFile;
            string DefaultCCSFilteringSetting = @"DefaultCCSFilteringSetting.csv";
            ConfigValue.DefaultCCSFilteringSettingFile = Path.GetFullPath(DefaultCCSFilteringSetting);

            string oldDefaultCCSKeywordSetting = ConfigValue.DefaultCCSKeywordSettingFile;
            string DefaultCCSKeywordSetting = @"DefaultCCSKeywordSetting.csv";
            ConfigValue.DefaultCCSKeywordSettingFile = Path.GetFullPath(DefaultCCSKeywordSetting);

            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCCSLogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);

            string oldDefaultCCSPatternSetting = ConfigValue.DefaultCCSPatternSettingFile;
            string DefaultCCSPatternSetting = @"DefaultCCSPatternSetting.csv";
            ConfigValue.DefaultCCSPatternSettingFile = Path.GetFullPath(DefaultCCSPatternSetting);

            string expected = String.Empty;
            string actual;
            actual = target.LoadConfig();
            Assert.AreNotEqual(expected, actual);

            ConfigValue.DefaultCCSFilteringSettingFile = oldDefaultCCSFilteringSetting;
            ConfigValue.DefaultCCSKeywordSettingFile = oldDefaultCCSKeywordSetting;
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;
            ConfigValue.DefaultCCSPatternSettingFile = oldDefaultCCSPatternSetting;
        }

        /// <summary>
        ///A test for StartAllAnalyProcess
        ///</summary>
        [TestMethod()]
        public void StartAllAnalyProcessTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.StartAllAnalyzeProcess();
            Assert.AreEqual(0, target.AnalyzeAreaVM.CountKeywordTabVM.AnalyzeCountKeywordItems.Count);
        }

        /// <summary>
        ///A test for StopAllAnalyProcess
        ///</summary>
        [TestMethod()]
        public void StopAllAnalyProcessTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            target.StopAllAnalyProcess();
            Assert.AreEqual(0, target.AnalyzeAreaVM.CountKeywordTabVM.AnalyzeCountKeywordItems.Count);
        }

        /// <summary>
        ///A test for StopErrorActionWorker
        ///</summary>
        [TestMethod()]
        public void StopErrorActionWorkerTest()
        {
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM);

            target.Invoke("StopErrorActionWorker");
            Assert.AreEqual(null, targetMainVM.CCSMainVM.AnalyzeAreaVM.ErrorActionTabVM.ErrorActionList);
        }

        /// <summary>
        ///A test for StopUserActionWorker
        ///</summary>
        [TestMethod()]
        public void StopUserActionWorkerTest()
        {
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM);
            target.Invoke("StopUserActionWorker");
            Assert.AreEqual(null, targetMainVM.CCSMainVM.AnalyzeAreaVM.UserActionTabVM.UserActionList);
        }

        /// <summary>
        ///A test for UserActionCommandCL
        ///</summary>
        [TestMethod()]
        public void UserActionCommandCLTest()
        {
            string text =
@"1,Workflow : login_Login :,login
2,Workflow : readyForShutdown :,readyShutdown
";

            string filenameUser = string.Format("UserActionCommandCLTest{0}.csv", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filenameUser, text);
            string fileFullPath = Path.GetFullPath(filenameUser);

            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            List<UserActionItem> userActions = new List<UserActionItem>(target.SettingManager.UserActionSettingList);
            string oldConfigString = ConfigValue.UserActionList;
            ConfigValue.UserActionList = fileFullPath;
            target.UserActionCommandCL();
            Assert.AreEqual(0, target.AnalyzeAreaVM.UserActionTabVM.UserActionList.Count);
            ConfigValue.UserActionList = oldConfigString;
            File.Delete(fileFullPath);
        }

        ///// <summary>
        /////A test for UserActionCommandCL
        /////</summary>
        //[TestMethod()]
        //public void UserActionCommandCLExTest()
        //{
        //    PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
        //    List<UserActionItem> userActions = new List<UserActionItem>(target.SettingManager.UserActionSettingList);
        //    string oldConfigString = ConfigValue.UserActionList;
        //    string fileError = @"UserActionListErr.csv";
        //    string dir = Path.GetFullPath(fileError);
        //    ConfigValue.UserActionList = dir;
        //    //target.UserActionCommandCL();
        //    Assert.IsTrue(target.AnalyzeAreaVM.UserActionTabVM.UserActionList == null || target.AnalyzeAreaVM.UserActionTabVM.UserActionList.Count == 0);
        //    ConfigValue.UserActionList = oldConfigString;
        //}

        /// <summary>
        ///A test for ValidLogFileExtension
        ///</summary>
        [TestMethod()]
        public void ValidLogFileExtensionFilePathIsEmptyTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
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
        [DeploymentItem(@"FileConfig\Test.xml")]
        public void ValidLogFileExtensionFilePathNotValidTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
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
        [DeploymentItem(@"FileConfig\TestCCSParser.csv")]
        public void ValidLogFileExtensionFilePathIsValidTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            string fileError = @"TestCCSParser.csv";
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
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            CCSLogRecord record = new CCSLogRecord();
            record.Content = "test test";
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
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            CCSAnalyzeAreaViewModel actual;
            actual = target.AnalyzeAreaVM;
            Assert.IsNotNull(actual.LogBookmarkTabVM);
            Assert.IsNotNull(actual.ErrorActionTabVM);
            Assert.IsNotNull(actual.UserActionTabVM);
            Assert.IsNotNull(actual.LogPatternTabVM);
            Assert.IsNotNull(actual.CountKeywordTabVM);
        }

        /// <summary>
        ///A test for ErrorActionCommand
        ///</summary>
        [TestMethod()]
        public void ErrorActionCommandTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            ICommand actual;
            actual = target.ErrorActionCommand;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for LogAnalyser
        ///</summary>
        [TestMethod()]
        public void LogAnalyserTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            CCSLogsAnalyser actual;
            actual = target.LogAnalyser;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for OpenFileFilter
        ///</summary>
        [TestMethod()]
        public void OpenFileFilterTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            string actual;
            actual = target.OpenFileFilter;
            Assert.IsTrue(actual.Contains("*.txt"));
            Assert.IsTrue(actual.Contains("*.csv"));
        }

        /// <summary>
        ///A test for OpenMemoFilterFile
        ///</summary>
        [TestMethod()]
        public void OpenMemoFilterFileTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
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
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            CCSSettingManager actual;
            actual = target.SettingManager;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for UserActionCommand
        ///</summary>
        [TestMethod()]
        public void UserActionCommandTest()
        {
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSMainViewModel_Accessor target = new CCSMainViewModel_Accessor(param0);
            ICommand actual;
            actual = target.UserActionCommand;
            Assert.IsNotNull(actual);
        }
    }
}
