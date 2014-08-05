using LogViewer.Util;
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
using System.Timers;
using System.Threading;
using System.Windows.Threading;
using Moq;
using Moq.Protected;
using System.Windows.Forms;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EditFilterSettingViewModelTest and is intended
    ///to contain all EditFilterSettingViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EditFilterSettingViewModelTest
    {
        public static PrivateObject target;
        public static Thread t;
        private TestContext testContextInstance;
        public static DispatcherTimer dt;
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
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            
        }
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            //t = new Thread(new ThreadStart(After10Sec));
            //t.Start();
            //dt = new DispatcherTimer();
            //dt.Interval = TimeSpan.FromSeconds(1);
            //dt.Start();
            //dt.Tick += new EventHandler(dt_Tick);
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            target = new PrivateObject(new EditCCSFilterSettingViewModel(null));
        }
        public void dt_Tick(object sender, EventArgs e)
        {
            //Thread.Sleep(100);
            if(App.Current != null)
            {
                for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                {
                    //App.Current.Windows[intCounter].Close();
                }
            }
            foreach (Form a in Application.OpenForms)
            {
                //a.Close();
            }
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //t.Abort();
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
            ObservableCollection<FilterItemSetting> ItemSettingList = (ObservableCollection<FilterItemSetting>)target.GetProperty("ItemSettingList");
            Assert.AreEqual(1, ItemSettingList.Count);
        }

        /// <summary>
        ///A test for ApplyCL
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ApplyCLTest()
        {
            target.Invoke("ApplyCL");
        }

        /// <summary>
        ///A test for CreateNewAndSetCandidateDefaultValue
        ///</summary>
        [TestMethod()]
        public void CreateNewAndSetCandidateDefaultValueTest()
        {
            target.Invoke("CreateNewAndSetCandidateDefaultValue");
            FilterItemSetting _itemMemberCandidate = (FilterItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(String.Empty, _itemMemberCandidate.Name);
        }

        /// <summary>
        ///A test for DeleteItemSetting
        ///</summary>
        [TestMethod()]
        public void DeleteItemSettingTest()
        {
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.Name = "test";
            ItemSettingList.Add(Item);
            List<FilterItemSetting> itemsToDelete = new List<FilterItemSetting>();
            itemsToDelete.Add(Item);
            target.Invoke("LoadData", new object[] { ItemSettingList });
            target.SetProperty("DoubleClickedCandidate", new FilterItemSetting());
            target.Invoke("DeleteItemSetting", new object[] { itemsToDelete.Cast<object>().ToList() });
            ObservableCollection<FilterItemSetting> actual = (ObservableCollection<FilterItemSetting>)target.GetProperty("ItemSettingList");
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod()]
        public void DeleteItemSettingContainDoubleClickedItemTest()
        {
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.Name = "test";
            ItemSettingList.Add(Item);
            List<FilterItemSetting> itemsToDelete = new List<FilterItemSetting>();
            itemsToDelete.Add(Item);
            target.Invoke("LoadData", new object[] { ItemSettingList });
            target.SetProperty("DoubleClickedCandidate", Item);
            target.Invoke("DeleteItemSetting", new object[] { itemsToDelete.Cast<object>().ToList() });
            ObservableCollection<FilterItemSetting> actual = (ObservableCollection<FilterItemSetting>)target.GetProperty("ItemSettingList");
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        ///A test for EditBackGroundCL
        ///</summary>
        [TestMethod]
        public void EditBackGroundCLTest()
        {
            //target.Invoke("EditBackGroundCL");
            //Assert.AreEqual(String.Empty, (string)target.GetProperty("BackGround"));


            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            var ccsf = new Mock<EditCCSFilterSettingViewModel>(null) { CallBase = true, };
            ccsf.Protected().Setup<string>("GetColorStringFromColorPicker", ItExpr.IsAny<string>()).Returns(string.Empty);
            var target = new PrivateObject(ccsf.Object);
            target.Invoke("EditBackGroundCL");
        }




        /// <summary>
        ///A test for EditForeGroundCL
        ///</summary>
        [TestMethod()]
        public void EditForeGroundCLTest()
        {
            //target.Invoke("EditForeGroundCL");
            //Assert.AreEqual(String.Empty, (string)target.GetProperty("ForeGround"));
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            var ccsf = new Mock<EditCCSFilterSettingViewModel>(null) { CallBase = true, };
            ccsf.Protected().Setup<string>("GetColorStringFromColorPicker", ItExpr.IsAny<string>()).Returns(string.Empty);
            var target = new PrivateObject(ccsf.Object);
            target.Invoke("EditForeGroundCL");
        }



        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {            
            target.Invoke("Initialize");
            Dictionary<string, bool> actual = (Dictionary<string, bool>)target.GetField("_inputPropOverwriteChecker");
            Assert.AreEqual(0, actual.Count);
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
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.Name = "test";
            ItemSettingList.Add(Item);
            List<FilterItemSetting> itemsToDelete = new List<FilterItemSetting>();
            itemsToDelete.Add(Item);
            target.Invoke("LoadData", new object[] { ItemSettingList });
            target.SetProperty("DoubleClickedCandidate", Item);
            target.SetField("_itemMemberCandidate", Item);
            target.Invoke("OverwriteItemSettingCL");
            Assert.IsNull(target.GetProperty("DoubleClickedCandidate"));
        }

        /// <summary>
        ///A test for Background
        ///</summary>
        [TestMethod()]
        public void BackgroundTest()
        {
            string expected = "#000000";
            target.SetProperty("Background", "#000000");
            string actual = (string)target.GetProperty("Background");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DoubleClickedCandidate
        ///</summary>
        [TestMethod()]
        public void DoubleClickedCandidateIsNotNullTest()
        {
            FilterItemSetting expected = new FilterItemSetting();
            expected.StringValue = "test";
            target.SetProperty("DoubleClickedCandidate", expected);
            FilterItemSetting actual = (FilterItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(expected.StringValue, actual.StringValue);
        }
        [TestMethod()]
        public void DoubleClickedCandidateIsNullTest()
        {
            target.SetProperty("DoubleClickedCandidate", null);
            FilterItemSetting actual = (FilterItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(String.Empty, actual.StringValue);
        }
        /// <summary>
        ///A test for EditBackGroundCommand
        ///</summary>
        [TestMethod()]
        public void EditBackGroundCommandTest()
        {            
            var actual = target.GetProperty("EditBackGroundCommand");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for EditFontStyleCommand
        ///</summary>
        [TestMethod()]
        public void EditFontStyleCommandTest()
        {
            var actual = target.GetProperty("EditFontStyleCommand");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for EditForeGroundCommand
        ///</summary>
        [TestMethod()]
        public void EditForeGroundCommandTest()
        {
            var actual = target.GetProperty("EditForeGroundCommand");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
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
        ///A test for FilterString
        ///</summary>
        [TestMethod()]
        public void FilterStringTest()
        {
            FilterItemSetting expected = new FilterItemSetting();
            expected.StringValue = "test";
            target.SetProperty("FilterString", expected.StringValue);
            FilterItemSetting actual = (FilterItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(expected.StringValue, actual.StringValue);
        }

        /// <summary>
        ///A test for FontStyle
        ///</summary>
        [TestMethod()]
        public void FontStyleTest()
        {
            FilterItemSetting expected = new FilterItemSetting();
            expected.FontStyle = "test";
            target.SetProperty("FontStyle", expected.FontStyle);
            FilterItemSetting actual = (FilterItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(expected.FontStyle, actual.FontStyle);
        }

        /// <summary>
        ///A test for Foreground
        ///</summary>
        [TestMethod()]
        public void ForegroundTest()
        {
            FilterItemSetting expected = new FilterItemSetting();
            expected.Foreground = "#000000";
            target.SetProperty("FontStyle", expected.Foreground);
            FilterItemSetting actual = (FilterItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(expected.Foreground, actual.Foreground);
        }

        /// <summary>
        ///A test for IsValidAllInputPropOverwrite
        ///</summary>
        [TestMethod()]
        public void IsValidAllInputPropOverwriteTest()
        {
            Dictionary<string, bool> _inputPropOverwriteChecker = new Dictionary<string, bool>();
            _inputPropOverwriteChecker.Add("Name", true);
            target.SetField("_inputPropOverwriteChecker", _inputPropOverwriteChecker);
            bool actual = (bool)target.GetProperty("IsValidAllInputPropOverwrite");
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ValidateNameIsEmptyTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Name must not be empty", actual);
        }
        [TestMethod()]
        public void ValidateNameIsNotEmptyItemIsNullTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            target.Name = "test";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ValidateNameIsNotEmptyItemIsNullLengthItemSettingListIs15Test()
        {
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            for (int i = 1; i <= 15; i++)
            {
                FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
                Item.Name = "test" + i;
                ItemSettingList.Add(Item);
            }
            
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            target.LoadData(ItemSettingList);
            target.Name = "test";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Maximum filter item.", actual);
        }
        [TestMethod()]
        public void ValidateNameIsNotEmptyItemIsNotNullDoubleClickedCandidateIsNullTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.Name = "test";
            ItemSettingList.Add(Item);
            target.LoadData(ItemSettingList);
            target.Name = "test";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Name is duplicate.", actual);
        }
        [TestMethod()]
        public void ValidateNameIsNotEmptyItemIsNotNullDoubleClickedCandidateIsNotNullTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.Name = "test";
            ItemSettingList.Add(Item);
            target.LoadData(ItemSettingList);
            target.DoubleClickedCandidate = Item;
            target.Name = "test";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Name is duplicate.", actual);
        }
        [TestMethod()]
        public void ValidateNameIsNotEmptyItemEqualDoubleClickedCandidateTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.Name = "test";
            Item.Enabled = true;
            Item.Background = "#000000";
            Item.FontStyle = "Normal";
            Item.Foreground = "#000000";
            Item.Id = "1";
            Item.index = 11;
            Item.IsPattern = true;
            Item.listIndex = new List<int>();
            Item.LogItem = "Content";
            //Item.PatternColor = new object();
            Item.StringValue = "test";
            ItemSettingList.Add(Item);
            target.LoadData(ItemSettingList);
            target.DoubleClickedCandidate = Item;
            target.Name = "test";
            string propertyName = "Name";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Name is duplicate.", actual);
        }

        [TestMethod()]
        public void ValidateFilterStringIsEmptyTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            string propertyName = "FilterString";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("String must not be empty", actual);
        }
        [TestMethod()]
        public void ValidateFilterStringIsNotEmptyItemIsNullTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            target.FilterString = "test";
            string propertyName = "FilterString";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ValidateFilterStringIsNotEmptyItemIsNullLengthOfItemSettingListIs15Test()
        {
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            for (int i = 1; i <= 15; i++)
            {
                FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
                Item.Name = "test" + i;
                Item.StringValue = "test" + i;
                Item.LogItem = "Content";
                ItemSettingList.Add(Item);
            }

            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            target.LoadData(ItemSettingList);
            target.FilterString = "test";
            target.LogItem = "Content";
            string propertyName = "FilterString";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Maximum filter item.", actual);
        }
        [TestMethod()]
        public void ValidateFilterStringIsNotEmptyItemIsNotNullDoubleClickedCandidateIsNullTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.StringValue = "test";
            Item.LogItem = "Content";
            ItemSettingList.Add(Item);
            target.LoadData(ItemSettingList);
            target.FilterString = "test";
            target.LogItem = "Content";
            string propertyName = "FilterString";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Keyword and Log item are duplicate", actual);
        }
        [TestMethod()]
        public void ValidateFilterStringIsNotEmptyItemIsNotNullDoubleClickedCandidateIsNotNullTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.StringValue = "test";
            Item.LogItem = "Content";
            ItemSettingList.Add(Item);
            target.LoadData(ItemSettingList);
            target.DoubleClickedCandidate = Item;
            target.FilterString = "test";
            target.LogItem = "Content";
            string propertyName = "FilterString";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Keyword and Log item are duplicate", actual);
        }
        [TestMethod()]
        public void ValidateFilterStringIsNotEmptyItemEqualDoubleClickedCandidateTest()
        {
            EditCCSFilterSettingViewModel target = new EditCCSFilterSettingViewModel(null);
            List<FilterItemSetting> ItemSettingList = new List<FilterItemSetting>();
            FilterItemSetting Item = ConfigValue.DefaultColorFilterItem.Copy();
            Item.StringValue = "test";
            Item.Enabled = true;
            Item.Background = "#000000";
            Item.FontStyle = "Normal";
            Item.Foreground = "#000000";
            Item.Id = "1";
            Item.index = 11;
            Item.IsPattern = true;
            Item.listIndex = new List<int>();
            Item.LogItem = "Content";
            //Item.PatternColor = new object();
            Item.StringValue = "test";
            ItemSettingList.Add(Item);
            target.LoadData(ItemSettingList);
            target.DoubleClickedCandidate = Item;
            target.FilterString = "test";
            string propertyName = "FilterString";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual("Keyword and Log item are duplicate", actual);
        }
        /// <summary>
        ///A test for LogItem
        ///</summary>
        [TestMethod()]
        public void LogItemTest()
        {
            FilterItemSetting expected = new FilterItemSetting();
            expected.LogItem = "test";
            target.SetProperty("LogItem", expected.LogItem);
            FilterItemSetting actual = (FilterItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(expected.LogItem, actual.LogItem);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            FilterItemSetting expected = new FilterItemSetting();
            expected.Name = "test";
            target.SetProperty("Name", expected.Name);
            FilterItemSetting actual = (FilterItemSetting)target.GetField("_itemMemberCandidate");
            Assert.AreEqual(expected.Name, actual.Name);
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
    }
}
