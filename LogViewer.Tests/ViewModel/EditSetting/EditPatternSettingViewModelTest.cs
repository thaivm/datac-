using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Linq;
using System.Collections.ObjectModel;
namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EditPatternSettingViewModelTest and is intended
    ///to contain all EditPatternSettingViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EditPatternSettingViewModelTest
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
            target = new PrivateObject(new EditPatternSettingViewModel(null));
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
        ///A test for AddItemSettingCL
        ///</summary>
        [TestMethod()]
        public void AddItemSettingCLTest()
        {
            target.Invoke("AddItemSettingCL");
            PatternItemViewModel _patternItemAddVM = (PatternItemViewModel)target.GetField("_patternItemAddVM");
            Assert.IsTrue(_patternItemAddVM.IsShow);
        }

        [TestMethod()]
        public void AddItemSettingCLIsShowIsTrueTest()
        {
            target.Invoke("AddItemSettingCL");
            target.Invoke("AddItemSettingCL");
            PatternItemViewModel _patternItemAddVM = (PatternItemViewModel)target.GetField("_patternItemAddVM");
            Assert.IsTrue(_patternItemAddVM.IsShow);
        }
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddItemSettingCLEditItemSettingCLIsShowTest()
        {
            List<PatternItemSetting> itemsList = new List<PatternItemSetting>();
            PatternItemSetting item = new PatternItemSetting();
            item.Name = "test";
            item.RootKey = "test";
            item.Time = 100;
            item.TimeUnit = "s";
            item.Keys = new List<string>();
            itemsList.Add(item);
            target.SetField("_selectedItems", itemsList.Cast<object>().ToList());
            target.Invoke("EditItemSettingCL");
            target.Invoke("AddItemSettingCL");
            PatternItemViewModel _patternItemAddVM = (PatternItemViewModel)target.GetField("_patternItemAddVM");
            Assert.IsTrue(_patternItemAddVM.IsShow);
        }
        /// <summary>
        ///A test for CloseDialog
        ///</summary>
        [TestMethod()]
        public void CloseDialogTest()
        {
            Action<List<PatternItemSetting>> onApplyEvent = null;
            EditPatternSettingViewModel target = new EditPatternSettingViewModel(onApplyEvent);
            target.CloseDialog();
            Assert.IsFalse(target.IsShow);
        }

        /// <summary>
        ///A test for CreateNewAndSetCandidateDefaultValue
        ///</summary>
        [TestMethod()]
        public void CreateNewAndSetCandidateDefaultValueTest()
        {
            target.Invoke("CreateNewAndSetCandidateDefaultValue");
            PatternItemSetting item = (PatternItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(String.Empty, item.Name);
        }

        /// <summary>
        ///A test for EditItemSettingCL
        ///</summary>
        [TestMethod()]
        public void EditItemSettingCLSelectedItemsIsEmptyTest()
        {
            target.SetField("_selectedItems", new object[] { new List<object>() });
            target.Invoke("EditItemSettingCL");
            PatternItemViewModel _patternItemEditVM = (PatternItemViewModel)target.GetField("_patternItemEditVM");
            Assert.IsFalse(_patternItemEditVM.IsShow);
        }

        [TestMethod()]
        public void EditItemSettingCLSelectedItemsIsNotEmptyTest()
        {
            List<PatternItemSetting> itemsList = new List<PatternItemSetting>();
            PatternItemSetting item = new PatternItemSetting();
            item.Name = "test";
            item.Keys = new List<string>();
            itemsList.Add(item);
            target.SetField("_selectedItems", itemsList.Cast<object>().ToList());
            target.Invoke("EditItemSettingCL");
            PatternItemViewModel _patternItemEditVM = (PatternItemViewModel)target.GetField("_patternItemEditVM");
            Assert.IsTrue(_patternItemEditVM.IsShow);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void EditItemSettingCLAddItemSettingIsShowTest()
        {
            List<PatternItemSetting> itemsList = new List<PatternItemSetting>();
            PatternItemSetting item = new PatternItemSetting();
            item.Name = "test";
            item.Keys = new List<string>();
            itemsList.Add(item);
            target.SetField("_selectedItems", itemsList.Cast<object>().ToList());
            target.Invoke("AddItemSettingCL");
            target.Invoke("EditItemSettingCL");
            PatternItemViewModel _patternItemEditVM = (PatternItemViewModel)target.GetField("_patternItemEditVM");
            Assert.IsTrue(_patternItemEditVM.IsShow);
        }
        /// <summary>
        ///A test for IsAdd
        ///</summary>
        [TestMethod()]
        public void IsAddTest()
        {
            target.Invoke("AddItemSettingCL");
            bool actual = (bool)target.Invoke("IsAdd");
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        public void IsNotAddTest()
        {
            bool actual = (bool)target.Invoke("IsAdd");
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsEdit
        ///</summary>
        [TestMethod()]
        public void IsEditTest()
        {
            List<PatternItemSetting> itemsList = new List<PatternItemSetting>();
            PatternItemSetting item = new PatternItemSetting();
            item.Name = "test";
            item.Keys = new List<string>();
            itemsList.Add(item);
            target.SetField("_selectedItems", itemsList.Cast<object>().ToList());
            target.Invoke("EditItemSettingCL");
            bool actual = (bool)target.Invoke("IsEdit");
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void IsNotditTest()
        {
            bool actual = (bool)target.Invoke("IsEdit");
            Assert.IsFalse(actual);
        }
        /// <summary>
        ///A test for ValidateData
        ///</summary>
        [TestMethod()]
        public void ValidateDataKeyIsEmptyTest()
        {
            ObservableCollection<PatternItemSetting> _itemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemSetting item = new PatternItemSetting();
            item.Name = "test";
            item.Keys = new List<string>();
            _itemSettingList.Add(item);
            string actual = (string)target.Invoke("ValidateData");
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ValidateUniqueNameTest()
        {
            ObservableCollection<PatternItemSetting> _itemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemSetting item = new PatternItemSetting();
            item.Name = "test";
            item.Keys = new List<string>() { "test", "test"};
            _itemSettingList.Add(item);
            PatternItemSetting item1 = new PatternItemSetting();
            item1.Name = "test";
            item1.Keys = new List<string>() { "test", "test" };
            _itemSettingList.Add(item1);
            target.SetField("_itemSettingList", _itemSettingList);
            string actual = (string)target.Invoke("ValidateData");
            Assert.AreEqual("Name must be unique", actual);
        }
        
        /// <summary>
        ///A test for dialog_Closing
        ///</summary>
        [TestMethod()]
        public void dialog_ClosingTest()
        {
            object sender = null;
            CancelEventArgs e = null;
            target.Invoke("dialog_Closing", new object[] { sender, e });
            PatternItemViewModel _patternItemEditVM = (PatternItemViewModel)target.GetField("_patternItemEditVM");
            Assert.IsFalse(_patternItemEditVM.IsShow);
        }

        /// <summary>
        ///A test for CanApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanApplyTest()
        {
            ObservableCollection<PatternItemSetting> _itemSettingList = new ObservableCollection<PatternItemSetting>();
            PatternItemSetting item = new PatternItemSetting();
            item.Name = "test";
            item.Keys = new List<string>() { "test", "test" };
            _itemSettingList.Add(item);
            PatternItemSetting item1 = new PatternItemSetting();
            item1.Name = "test";
            item1.Keys = new List<string>() { "test", "test" };
            _itemSettingList.Add(item1);
            target.SetField("_itemSettingList", _itemSettingList);
            bool actual = (bool)target.GetProperty("CanApply");
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for EditItemSettingCommand
        ///</summary>
        [TestMethod()]
        public void EditItemSettingCommandTest()
        {
            Action<List<PatternItemSetting>> onApplyEvent = null;
            EditPatternSettingViewModel target = new EditPatternSettingViewModel(onApplyEvent);
            var actual = target.EditItemSettingCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }
    }
}
