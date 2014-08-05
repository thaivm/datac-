using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.ViewModel;
using LogViewer.Business;
using LogViewer.Model;
using LogViewer.MVVMHelper;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseDataGridViewModelTest and is intended
    ///to contain all BaseDataGridViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseDataGridViewModelTest
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
        ///A test for contructor BaseDataGridViewModel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseDataGridViewModelContructorTest()
        { 
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            BaseDataGridViewModel<KeywordModel> target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param = new PrivateObject(target, new PrivateType(typeof(BaseDataGridViewModel<KeywordModel>)));
            Assert.IsNotNull(param.GetFieldOrProperty("_ownerVM"));
        }


        /// <summary>
        ///A test for AddCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void AddCLTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            target.SourceList = new ObservableCollection<KeywordModel>();
            param0.Invoke("AddCL");
            Assert.IsNotNull(target.RowForJump);
        }

        /// <summary>
        ///A test for CanAdd
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanAddTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target, new PrivateType(typeof(BaseDataGridViewModel<KeywordModel>)));
            Assert.AreEqual(param0.Invoke("CanAdd"), true);
        }

        /// <summary>
        ///A test for Delete - SelectedItems.count = 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Delete_SelectedItemsZeroTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel_Accessor target = new PatternItemKeysListDataGridViewModel_Accessor(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            target.SourceList = new ObservableCollection<KeywordModel>();
            var item = new KeywordModel { Index = 1, Value = "Test" };
            target.SourceList.Add(item);
            target.SelectedItems = new List<object>();
            target.Delete(target.SelectedItems);
            Assert.AreEqual(1, target.SourceList.Count);
        }

        /// <summary>
        ///A test for Delete - casted != null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Delete_castedNotNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel_Accessor target = new PatternItemKeysListDataGridViewModel_Accessor(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            target.SourceList = new ObservableCollection<KeywordModel>();
            var item = new KeywordModel { Index = 1, Value = "Test" };
            target.SourceList.Add(item);
            target.SelectedItems = new List<object>();
            target.SelectedItems.Add(item);
            target.Delete(target.SelectedItems);
            Assert.AreEqual(0, target.SourceList.Count);
        }

        /// <summary>
        ///A test for Delete - casted = null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Delete_castedNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            target.SourceList = new ObservableCollection<KeywordModel>();
            var item = new KeywordModel { Index = 1, Value = "Test" };
            target.SourceList.Add(item);
            PrivateObject param0 = new PrivateObject((BaseDataGridViewModel<KeywordModel>)target);
            target.SelectedItems = new List<object>();
            target.SelectedItems.Add(null);
            param0.Invoke("Delete", target.SelectedItems);
            Assert.AreEqual(1, target.SourceList.Count);
        }

        /// <summary>
        ///A test for LoadData - data = null
        ///</summary>
        [TestMethod()]
        public void LoadData_DataZeroTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            target.SourceList = new ObservableCollection<KeywordModel>();
            List<KeywordModel> temp = new List<KeywordModel>();
            target.LoadData(temp);
            Assert.AreEqual(0, target.SourceList.Count);
        }

        /// <summary>
        ///A test for LoadData - copyable != null
        ///</summary>
        [TestMethod()]
        public void LoadData_copyableNotNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            target.SourceList = new ObservableCollection<KeywordModel>();
            var item = new KeywordModel { Index = 1, Value = "Test" };
            target.SourceList.Add(item);
            PrivateObject param0 = new PrivateObject((BaseDataGridViewModel<KeywordModel>)target);
            param0.Invoke("LoadData", target.SourceList);
            Assert.AreEqual(item, target.SourceList[0]);
        }

        /// <summary>
        ///A test for LoadData - copyable = null
        ///</summary>
        [TestMethod()]
        public void LoadData_copyableNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            target.SourceList = new ObservableCollection<KeywordModel>();
            var item = new KeywordModel { };
            target.SourceList.Add(item);
            PrivateObject param0 = new PrivateObject((BaseDataGridViewModel<KeywordModel>)target);
            param0.Invoke("LoadData", target.SourceList);
            Assert.AreEqual(item, target.SourceList[0]);
        }

        /// <summary>
        ///A test for AddCommand - _addCommand is not null
        ///</summary>
        [TestMethod()]
        public void AddCommandIsNotNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            param0.SetField("_addCommand", new DelegateCommand(ApplyCL, () => { return true; }));
            var expected = target.AddCommand;
            Assert.IsNotNull(expected);
        }
        void ApplyCL() { }

        /// <summary>
        ///A test for AddCommand - _addCommand is null
        ///</summary>
        [TestMethod()]
        public void AddCommandIsNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            var expected = target.AddCommand;
            Assert.IsNotNull(expected);
        }

        /// <summary>
        ///A test for DeleteCommand - _deleteCommand is not null
        ///</summary>
        [TestMethod()]
        public void DeleteCommandIsNotNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            param0.SetField("_deleteCommand", new DelegateCommand(DeleteCL, () => target.SelectedItems != null && target.SelectedItems.Count != 0));
            var expected = target.DeleteCommand;
            Assert.IsNotNull(expected);
        }
        void DeleteCL() { }

        /// <summary>
        ///A test for DeleteCommand - _deleteCommand is null
        ///</summary>
        [TestMethod()]
        public void DeleteCommandIsNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            var expected = target.DeleteCommand;
            Assert.IsNotNull(expected);
        }

        /// <summary>
        ///A test for ErrorMessage - not empty
        ///</summary>
        [TestMethod()]
        public void ErrorMessage_NotEmptyTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            string str = "Test";
            target.ErrorMessage = str;
            string expected = target.ErrorMessage;
            Assert.AreEqual(expected, str);
        }

        /// <summary>
        ///A test for ErrorMessage - empty
        ///</summary>
        [TestMethod()]
        public void ErrorMessage_EmptyTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            string str = string.Empty;
            target.ErrorMessage = str;
            string expected = target.ErrorMessage;
            Assert.AreEqual(expected, str);
        }

        /// <summary>
        ///A test for IsDataValid
        ///</summary>
        [TestMethod()]
        public void IsDataValidFalseTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            bool actual = target.IsDataValid;
            Assert.AreEqual(false, actual);
        }

        /// <summary>
        ///A test for IsDataValid
        ///</summary>
        [TestMethod()]
        public void IsDataValidTrueTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            target.SourceList = new ObservableCollection<KeywordModel>();
            target.SourceList.Add(new KeywordModel { Index = 1, Value = "Test" });
            bool actual = target.IsDataValid;
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        ///A test for RowForJump - not null
        ///</summary>
        [TestMethod()]
        public void RowForJump_NotNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            KeywordModel key = new KeywordModel { Index = 1, Value = "Test" };
            target.RowForJump = key;
            KeywordModel expected = target.RowForJump;
            Assert.AreEqual(expected, key);
        }

        /// <summary>
        ///A test for RowForJump - null
        ///</summary>
        [TestMethod()]
        public void RowForJump_NullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            KeywordModel key = null;
            target.RowForJump = key;
            KeywordModel expected = target.RowForJump;
            Assert.AreEqual(expected, key);
        }

        /// <summary>
        ///A test for SelectedItems - not null
        ///</summary>
        [TestMethod()]
        public void SelectedItems_NotNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            List<object> list = new List<object>();
            list.Add("Test");
            target.SelectedItems = list;
            List<object> expected = (List<object>)target.SelectedItems;
            Assert.AreEqual(expected, list);
        }

        /// <summary>
        ///A test for SelectedItems - null
        ///</summary>
        [TestMethod()]
        public void SelectedItems_NullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            List<object> list = null;
            target.SelectedItems = null;
            List<object> expected = (List<object>)target.SelectedItems;
            Assert.AreEqual(expected, list);
        }

        /// <summary>
        ///A test for SourceList - not null
        ///</summary>
        [TestMethod()]
        public void SourceList_NotNullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            ObservableCollection<KeywordModel> key = new ObservableCollection<KeywordModel>();
            key.Add(new KeywordModel { Index = 1, Value = "Test" });
            target.SourceList = key;
            ObservableCollection<KeywordModel> expected = target.SourceList;
            Assert.AreEqual(expected, key);
        }

        /// <summary>
        ///A test for SourceList - null
        ///</summary>
        [TestMethod()]
        public void SourceList_NullTest()
        {
            ObservableCollection<PatternItemSetting> ItemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemKeysListDataGridViewModel target = new PatternItemKeysListDataGridViewModel(
                new PatternItemViewModel(x => ItemSettingList.Add(x)));
            PrivateObject param0 = new PrivateObject(target);
            ObservableCollection<KeywordModel> key = null;
            target.SourceList = key;
            ObservableCollection<KeywordModel> expected = target.SourceList;
            Assert.AreEqual(expected, key);
        }
    }
}
