using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using LogViewer.Model;
using LogViewer.Business;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Collections.ObjectModel;
using System.Linq;
namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EditKeywordCountSettingViewModelTest and is intended
    ///to contain all EditKeywordCountSettingViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EditKeywordCountSettingViewModelTest
    {

        public static PrivateObject target;
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
            target = new PrivateObject(new EditCCSKeywordCountSettingViewModel(null));
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
        ///A test for CreateNewAndSetCandidateDefaultValue
        ///</summary>
        [TestMethod()]
        public void CreateNewAndSetCandidateDefaultValueTest()
        {
            target.Invoke("CreateNewAndSetCandidateDefaultValue");
            KeywordCountItemSetting _itemMemberCandidate = (KeywordCountItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(String.Empty, _itemMemberCandidate.Name);
        }

        /// <summary>
        ///A test for DeleteItemSetting
        ///</summary>
        [TestMethod()]
        public void DeleteItemSettingTest()
        {
            List<KeywordCountItemSetting> itemsToDelete = new List<KeywordCountItemSetting>();
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            itemsToDelete.Add(item);
            ObservableCollection<KeywordCountItemSetting> _itemSettingList = new ObservableCollection<KeywordCountItemSetting>();
            _itemSettingList.Add(item);
            target.SetField("_itemSettingList", _itemSettingList);
            target.Invoke("DeleteItemSetting", new object[] { itemsToDelete.Cast<object>().ToList() });
            Assert.AreEqual(0, ((ObservableCollection<KeywordCountItemSetting>)target.GetField("_itemSettingList")).Count);
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            target.Invoke("Initialize");
        }

        /// <summary>
        ///A test for OnCandidateValueChange
        ///</summary>
        [TestMethod()]
        public void OnCandidateValueChangeTest()
        {
            target.Invoke("OnCandidateValueChange");
        }

        /// <summary>
        ///A test for OverwriteItemSettingCL
        ///</summary>
        [TestMethod()]
        public void OverwriteItemSettingCLTest()
        {
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            ObservableCollection<KeywordCountItemSetting> _itemSettingList = new ObservableCollection<KeywordCountItemSetting>();
            _itemSettingList.Add(item);
            target.SetField("_itemSettingList", _itemSettingList);
            target.SetField("_doubleClickedCandidate", item);
            target.SetField("_itemMemberCandidate", item);
            target.Invoke("OverwriteItemSettingCL");
            ObservableCollection<KeywordCountItemSetting> ItemSettingList = (ObservableCollection<KeywordCountItemSetting>)target.GetField("_itemSettingList");
            Assert.AreEqual(1, ItemSettingList.Count);
        }

        /// <summary>
        ///A test for DoubleClickedCandidate
        ///</summary>
        [TestMethod()]
        public void DoubleClickedCandidateTest()
        {
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            target.SetProperty("DoubleClickedCandidate", item);
            KeywordCountItemSetting actual = (KeywordCountItemSetting)target.GetField("_doubleClickedCandidate");
            Assert.AreEqual(item.Name, actual.Name);
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void ErrorTest()
        {
            string actual = (string)target.GetProperty("Error");
        }

        /// <summary>
        ///A test for IsValidAllInputPropOverwrite
        ///</summary>
        [TestMethod()]
        public void IsValidAllInputPropOverwriteTest()
        {
            Dictionary<string, bool> _inputPropOverwriteChecker = new Dictionary<string,bool>();
            _inputPropOverwriteChecker.Add("Name", false);
            target.SetField("_inputPropOverwriteChecker", _inputPropOverwriteChecker);
            bool actual = (bool)target.GetProperty("IsValidAllInputPropOverwrite");
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ValidateNameTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            target.Name = "test";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ValidateNameIsEmptyTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Name must not be empty", actual);
        }
        [TestMethod()]
        public void ValidateNameItemNotNullTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            ObservableCollection<KeywordCountItemSetting> _itemSettingList = new ObservableCollection<KeywordCountItemSetting>();
            _itemSettingList.Add(item);
            target.ItemSettingList = _itemSettingList;
            target.Name = "test";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Name is duplicate.", actual);
        }
        [TestMethod()]
        public void ValidateNameItemNullTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            ObservableCollection<KeywordCountItemSetting> _itemSettingList = new ObservableCollection<KeywordCountItemSetting>();
            _itemSettingList.Add(item);
            target.ItemSettingList = _itemSettingList;
            target.Name = "test1";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ValidateNameItemNotNullDoubleClickedCandidateNotNullTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            ObservableCollection<KeywordCountItemSetting> _itemSettingList = new ObservableCollection<KeywordCountItemSetting>();
            _itemSettingList.Add(item);
            target.ItemSettingList = _itemSettingList;
            target.DoubleClickedCandidate = item;
            target.Name = "test";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Name is duplicate.", actual);
        }
        [TestMethod()]
        public void ValidateStringValueIsEmptyTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            string propertyName = "StringValue";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("String must not be empty", actual);
        }
        [TestMethod()]
        public void ValidateStringValueItemNotNullTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            ObservableCollection<KeywordCountItemSetting> _itemSettingList = new ObservableCollection<KeywordCountItemSetting>();
            _itemSettingList.Add(item);
            target.ItemSettingList = _itemSettingList;
            target.StringValue = "test";
            string propertyName = "StringValue";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Keyword and Log item are duplicate", actual);
        }
        [TestMethod()]
        public void ValidateStringValueItemNullTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            ObservableCollection<KeywordCountItemSetting> _itemSettingList = new ObservableCollection<KeywordCountItemSetting>();
            _itemSettingList.Add(item);
            target.ItemSettingList = _itemSettingList;
            target.StringValue = "test1";
            string propertyName = "StringValue";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ValidateStringValueItemNotNullDoubleClickedCandidateNotNullTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            KeywordCountItemSetting item = new KeywordCountItemSetting();
            item.Name = "test";
            item.Id = "1";
            item.LogItem = "Content";
            item.StringValue = "test";
            item.Enabled = true;
            ObservableCollection<KeywordCountItemSetting> _itemSettingList = new ObservableCollection<KeywordCountItemSetting>();
            _itemSettingList.Add(item);
            target.ItemSettingList = _itemSettingList;
            target.DoubleClickedCandidate = item;
            target.StringValue = "test";
            string propertyName = "StringValue";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Keyword and Log item are duplicate", actual);
        }
        [TestMethod()]
        public void ValidateLogItemIsEmptyTest()
        {
            EditCCSKeywordCountSettingViewModel target = new EditCCSKeywordCountSettingViewModel(null);
            string propertyName = "LogItem";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        /// <summary>
        ///A test for LogItem
        ///</summary>
        [TestMethod()]
        public void LogItemTest()
        {
            target.SetProperty("LogItem", "Content");
            string actual = (string)target.GetProperty("LogItem");
            Assert.AreSame("Content", actual);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            target.SetProperty("Name", "Test");
            string actual = (string)target.GetProperty("Name");
            Assert.AreSame("Test", actual);
        }

        /// <summary>
        ///A test for OverwriteItemSettingCommand
        ///</summary>
        [TestMethod()]
        public void OverwriteItemSettingCommandTest()
        {
            var actual = target.GetProperty("OverwriteItemSettingCommand");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for StringValue
        ///</summary>
        [TestMethod()]
        public void StringValueTest()
        {
            target.SetProperty("StringValue", "Test");
            string actual = (string)target.GetProperty("StringValue");
            Assert.AreSame("Test", actual);
        }
    }
}
