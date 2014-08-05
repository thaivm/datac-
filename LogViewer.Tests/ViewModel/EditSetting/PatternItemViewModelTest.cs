using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using LogViewer.Model;
using System.Collections.Generic;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for PatternItemViewModelTest and is intended
    ///to contain all PatternItemViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PatternItemViewModelTest
    {

        public static MainViewModel_Accessor targetMainVM;
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
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            target = new PrivateObject(new PatternItemViewModel(new Action<PatternItemSetting>((items)=>{})));
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
        public void GetDataToApplyTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            PatternItemSetting actual = (PatternItemSetting)target.Invoke("GetDataToApply");
            Assert.AreEqual(item.Id, actual.Id);
        }

        [TestMethod()]
        public void GetDataToApplyKeyIsNullOrEmptyTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "" };
            target.Invoke("LoadItem", new object[] { item });
            PatternItemSetting actual = (PatternItemSetting)target.Invoke("GetDataToApply");
            Assert.AreEqual(item.Id, actual.Id);
        }

        /// <summary>
        ///A test for LoadItem
        ///</summary>
        [TestMethod()]
        public void LoadItemKeysIsEmptyTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>();
            target.Invoke("LoadItem", new object[] { item });
            PatternItemKeysListDataGridViewModel KeysListDataGridVM = (PatternItemKeysListDataGridViewModel)target.GetFieldOrProperty("KeysListDataGridVM");
            Assert.AreEqual(item.Keys.Count, KeysListDataGridVM.SourceList.Count);
        }

        [TestMethod()]
        public void LoadItemTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            PatternItemKeysListDataGridViewModel KeysListDataGridVM = (PatternItemKeysListDataGridViewModel)target.GetFieldOrProperty("KeysListDataGridVM");
            Assert.AreEqual(item.Keys.Count, KeysListDataGridVM.SourceList.Count);
        }
        /// <summary>
        ///A test for CanApply
        ///</summary>
        [TestMethod()]
        public void CanApplyInputPropCheckerIsEmptyTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            bool actual = (bool)target.GetFieldOrProperty("CanApply");
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void CanApplyTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            Dictionary<string, bool> _inputPropChecker = new Dictionary<string,bool>();
            _inputPropChecker.Add("Name", false);
            target.SetField("_inputPropChecker", _inputPropChecker);
            bool actual = (bool)target.GetFieldOrProperty("CanApply");
            Assert.IsFalse(actual);
        }
        
        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void ErrorTest()
        {
            string actual = (string)target.GetFieldOrProperty("Error");
        }

        /// <summary>
        ///A test for IsErrorAtTime
        ///</summary>
        [TestMethod()]
        public void IsErrorAtTimeTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            bool expected = false;
            target.SetProperty("IsErrorAtTime", false);
            bool actual = (bool)target.GetProperty("IsErrorAtTime");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ValidateForNameTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            Action<PatternItemSetting> onApplyAction = new Action<PatternItemSetting>((items) => { });
            PatternItemViewModel target = new PatternItemViewModel(onApplyAction);
            target.LoadItem(item);
            string propertyName = "Name"; 
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ValidateForRootKeyTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            Action<PatternItemSetting> onApplyAction = new Action<PatternItemSetting>((items) => { });
            PatternItemViewModel target = new PatternItemViewModel(onApplyAction);
            target.LoadItem(item);
            string propertyName = "RootKeyword";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }

        /// <summary>
        ///A test for KeysListDataGridVM
        ///</summary>
        [TestMethod()]
        public void KeysListDataGridVMTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            PatternItemKeysListDataGridViewModel KeysListDataGridVM = (PatternItemKeysListDataGridViewModel)target.GetFieldOrProperty("KeysListDataGridVM");
            Assert.AreEqual(item.Keys.Count, KeysListDataGridVM.SourceList.Count);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            target.SetProperty("Name", "test");
            string actual = (string)target.GetProperty("Name");
            Assert.AreEqual("test", actual);
        }

        /// <summary>
        ///A test for RootKeyword
        ///</summary>
        [TestMethod()]
        public void RootKeywordTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            target.SetProperty("RootKeyword", "test");
            string actual = (string)target.GetProperty("RootKeyword");
            Assert.AreEqual("test", actual);
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod()]
        public void TimeTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            Action<PatternItemSetting> onApplyAction = new Action<PatternItemSetting>((items) => { });
            PatternItemViewModel target = new PatternItemViewModel(onApplyAction);
            target.LoadItem(item);
            target.Time = 1000;
            ulong actual = target.Time;
            Assert.AreEqual((ulong)1000, actual);

        }

        /// <summary>
        ///A test for TimeUnit
        ///</summary>
        [TestMethod()]
        public void TimeUnitTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            target.SetProperty("TimeUnit", "s");
            string actual = (string)target.GetProperty("TimeUnit");
            Assert.AreEqual("s", actual);
        }

        /// <summary>
        ///A test for TimeUnitList
        ///</summary>
        [TestMethod()]
        public void TimeUnitListTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            Action<PatternItemSetting> onApplyAction = new Action<PatternItemSetting>((items) => { });
            PatternItemViewModel target = new PatternItemViewModel(onApplyAction);
            target.LoadItem(item);
            var actual = target.TimeUnitList;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for Title
        ///</summary>
        [TestMethod()]
        public void TitleTest()
        {
            PatternItemSetting item = new PatternItemSetting();
            item.Enabled = true;
            item.Id = "1";
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "ms";
            item.Keys = new List<string>() { "test" };
            target.Invoke("LoadItem", new object[] { item });
            target.SetProperty("Title", "test");
            string actual = (string)target.GetProperty("Title");
            Assert.AreEqual("test", actual);
        }
    }
}
