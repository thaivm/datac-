using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using LogViewer.Model;
using LogViewer.CustomException;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for RichTextBoxHelperTest and is intended
    ///to contain all RichTextBoxHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RichTextBoxHelperTest
    {


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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for AddItem
        ///</summary>
        [TestMethod()]
        public void AddItemitemExistsisNullTest()
        {
            List<FilterItemSetting> itemSettingSplit = new List<FilterItemSetting>();
            FilterItemSetting item1 = new FilterItemSetting();
            item1.StringValue = "test1";
            item1.index = 1;
            item1.Foreground = "#000000";
            item1.Background = "#000000";
            item1.FontStyle = "Normal";
            itemSettingSplit.Add(item1);
            FilterItemSetting item2 = new FilterItemSetting();
            item2.StringValue = "test2";
            item2.index = 1;
            item2.Foreground = "#000000";
            item2.Background = "#000000";
            item2.FontStyle = "Normal";
            List<FilterItemSetting> actual;
            actual = RichTextBoxHelper_Accessor.AddItem(itemSettingSplit, item2);
            Assert.AreEqual(2, actual.Count);
        }
        [TestMethod()]
        public void AddItemitemExistsIsNotNullTest()
        {
            List<FilterItemSetting> itemSettingSplit = new List<FilterItemSetting>();
            FilterItemSetting item1 = new FilterItemSetting();
            item1.StringValue = "test1";
            item1.index = 1;
            item1.Foreground = "#000000";
            item1.Background = "#000000";
            item1.FontStyle = "Normal";
            itemSettingSplit.Add(item1);
            FilterItemSetting item2 = new FilterItemSetting();
            item2.StringValue = "test2";
            item2.index = 1;
            item2.Foreground = "#000000";
            item2.Background = "#000000";
            item2.FontStyle = "Normal";
            itemSettingSplit.Add(item2);
            List<FilterItemSetting> actual;
            actual = RichTextBoxHelper_Accessor.AddItem(itemSettingSplit, item2);
            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        ///A test for ExtractFilterStringRegular
        ///</summary>
        [TestMethod()]
        public void ExtractFilterStringRegularIsTrueTest()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "\"data test\"";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual("data test", actual[0].StringValue);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularIsTrueTest1()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "\"data\" test\"";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual("data", actual[0].StringValue);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularIsTrueExceptionTest()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "\"[data+\" test\"";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual(0, actual.Count);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularContainSearchOrTest()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "data+test";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual(2, actual.Count);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularContainSearchOrTest1()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "data+test+";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual(2, actual.Count);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularContainSearchOrContainAndSuccessTest()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "data+test case  + ";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test case";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual(3, actual.Count);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularContainSearchOrContainAndSuccessFailureTest()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "data+test case1  + ";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test case";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual(1, actual.Count);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularContainSearchAndSuccessTest()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "data test ";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual(2, actual.Count);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularContainSearchAndSuccessFailureTest()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "data test1 ";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual(0, actual.Count);
        }
        [TestMethod()]
        public void ExtractFilterStringRegularNotContainOrAndTest()
        {
            List<FilterItemSetting> effectiveFilterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.StringValue = "data";
            item.index = 0;
            item.Foreground = "#000000";
            item.Background = "#000000";
            item.FontStyle = "Normal";
            effectiveFilterSettingList.Add(item);
            string value = "123 data test";
            List<FilterItemSetting> actual = RichTextBoxHelper_Accessor.ExtractFilterStringRegular(effectiveFilterSettingList, value);
            Assert.AreEqual(1, actual.Count);
        }
        /// <summary>
        ///A test for FilterColorToRichTextBox
        ///</summary>
        [TestMethod()]
        public void FilterColorToRichTextBoxValueIsNullTest()
        {
            RichTextBox richTextBox = new RichTextBox(); 
            List<FilterItemSetting> filterSettingList = null; 
            string name = string.Empty; 
            bool isPattern = false; 
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxFilterSettingListIsNullTest()
        {
            string value = "test";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = null;
            string name = string.Empty;
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeffectiveFilterSettingListIsEmptyAndListPatternIsEmptyTest()
        {
            string value = "test";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            string name = string.Empty;
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }
        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsEmptyAndListPatternIsEmptyTest()
        {
            string value = "data";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "test data";
            filterSettingList.Add(item);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }
        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsEmptyTest()
        {
            string value = "123 data test 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "test data";
            filterSettingList.Add(item);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsNotEmptyTest()
        {
            string value = "123 data test color filter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "test data";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Content";
            pattern.Enabled = true;
            pattern.StringValue = "color filter";
            pattern.IsPattern = true;
            filterSettingList.Add(pattern);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsNotEmptyTestNameIsNotEqualContentAndMessage()
        {
            string value = "123 data test color filter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Id";
            item.Enabled = true;
            item.StringValue = "test data";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Id";
            pattern.Enabled = true;
            pattern.StringValue = "color filter";
            pattern.IsPattern = true;
            filterSettingList.Add(pattern);
            string name = "Id";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsNotEmptyCanMergeTest()
        {
            string value = "123 data test color filter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "test data color";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Content";
            pattern.Enabled = true;
            pattern.StringValue = "color filter";
            pattern.IsPattern = true;
            filterSettingList.Add(pattern);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsNotEmptyCanMergelastIndexOfIMoreThanIndexJTest()
        {
            string value = "123 data test color filter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "test data color";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Content";
            pattern.Enabled = true;
            pattern.StringValue = "color filter";
            pattern.IsPattern = true;
            filterSettingList.Add(pattern);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsNotEmptyCanMergelastIndexOfIMoreThanIndexJIndexJMoreThanIndexITest()
        {
            string value = "123 data test color filter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "test data color";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Content";
            pattern.Enabled = true;
            pattern.StringValue = "color filter";
            pattern.IsPattern = true;
            filterSettingList.Add(pattern);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsNotEmptyCanMergelastIndexOfJMoreThanlastIndexOfIIndexIMoreThanIndexJTest()
        {
            string value = "123 datatestcolorfilter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "color";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Content";
            pattern.index = 12;
            pattern.Enabled = true;
            pattern.StringValue = "datatestcolor";
            pattern.IsPattern = true;
            filterSettingList.Add(pattern);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsNotEmptyCanMergeIsTrueTest()
        {
            string value = "123 datatestcolorfilter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "datatestcolor";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Content";
            pattern.Enabled = true;
            pattern.StringValue = "datatestcolorfilter";
            filterSettingList.Add(pattern);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeListFilterDisplayIsNotEmptyAndListPatternIsNotEmptyFirstMoreThanSecondTest()
        {
            string value = "123 datatestcolorfilter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "datatestcolor";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Content";
            pattern.Enabled = true;
            pattern.IsPattern = true;
            pattern.index = 8;
            pattern.StringValue = "testcolorfilter";
            filterSettingList.Add(pattern);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }

        [TestMethod()]
        public void FilterColorToRichTextBoxeFonstyleIsNotNullTest()
        {
            string value = "123 datatestcolorfilter 456";
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            richTextBox.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)value);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting item = new FilterItemSetting();
            item.LogItem = "Content";
            item.Enabled = true;
            item.StringValue = "datatestcolor";
            item.FontStyle = "Normal";
            filterSettingList.Add(item);
            FilterItemSetting pattern = new FilterItemSetting();
            pattern.LogItem = "Content";
            pattern.Enabled = true;
            pattern.FontStyle = "Normal";
            pattern.IsPattern = true;
            pattern.index = 8;
            pattern.StringValue = "testcolorfilter";
            filterSettingList.Add(pattern);
            string name = "Content";
            bool isPattern = false;
            RichTextBoxHelper_Accessor.FilterColorToRichTextBox(richTextBox, filterSettingList, name, isPattern);
        }
        /// <summary>
        ///A test for GetDocumentXaml
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetDocumentXamlTest()
        {
            DependencyObject obj = null; 
            string expected = string.Empty; 
            string actual;
            actual = RichTextBoxHelper.GetDocumentXaml(obj);
        }

        /// <summary>
        ///A test for GetFilterToShow
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetFilterToShowTest()
        {
            DependencyObject o = null;
            object actual;
            actual = RichTextBoxHelper.GetFilterToShow(o);
        }

        /// <summary>
        ///A test for GetLineOfContent
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetLineOfContentTest()
        {
            DependencyObject obj = null; 
            string expected = string.Empty; 
            string actual;
            actual = RichTextBoxHelper.GetLineOfContent(obj);
        }

        /// <summary>
        ///A test for GetShowPatternColoring
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetShowPatternColoringTest()
        {
            DependencyObject o = null; 
            object actual;
            actual = RichTextBoxHelper.GetShowPatternColoring(o);
        }

        /// <summary>
        ///A test for MergeColor
        ///</summary>
        [TestMethod()]
        public void MergeColorIndex0Test()
        {
            List<FilterItemSetting> splitFilter = new List<FilterItemSetting>();
            FilterItemSetting WindowStartup = new FilterItemSetting();
            WindowStartup.index = 0;
            WindowStartup.StringValue = "WindowStartup";
            WindowStartup.FontStyle = "Normal";
            WindowStartup.Background = "#000000";
            WindowStartup.Foreground = "#000000";
            FilterItemSetting StartupLocation = new FilterItemSetting();
            StartupLocation.index = 0;
            StartupLocation.StringValue = "WindowStartupLocation";
            StartupLocation.FontStyle = "Normal";
            StartupLocation.Background = "#000000";
            StartupLocation.Foreground = "#000000";
            string value = "WindowStartupLocation";
            List<FilterItemSetting> actual;
            actual = RichTextBoxHelper_Accessor.MergeColor(splitFilter, value, WindowStartup, StartupLocation);
            Assert.AreEqual(2, actual.Count);
        }
        [TestMethod()]
        public void MergeColorTest()
        {
            List<FilterItemSetting> splitFilter = new List<FilterItemSetting>();
            FilterItemSetting WindowStartup = new FilterItemSetting();
            WindowStartup.index = 0;
            WindowStartup.StringValue = "WindowStartup";
            WindowStartup.FontStyle = "Normal";
            WindowStartup.Background = "#000000";
            WindowStartup.Foreground = "#000000";
            FilterItemSetting StartupLocation = new FilterItemSetting();
            StartupLocation.index = 6;
            StartupLocation.StringValue = "StartupLocation";
            StartupLocation.FontStyle = "Normal";
            StartupLocation.Background = "#000000";
            StartupLocation.Foreground = "#000000";
            string value = "WindowStartupLocation"; 
            List<FilterItemSetting> actual;
            actual = RichTextBoxHelper_Accessor.MergeColor(splitFilter, value, WindowStartup, StartupLocation);
            Assert.AreEqual(3, actual.Count);
        }

        [TestMethod()]
        public void MergeColorFirstContainSecondTest()
        {
            List<FilterItemSetting> splitFilter = new List<FilterItemSetting>();
            FilterItemSetting WindowStartup = new FilterItemSetting();
            WindowStartup.index = 0;
            WindowStartup.StringValue = "WindowStartupLocation";
            WindowStartup.FontStyle = "Normal";
            WindowStartup.Background = "#000000";
            WindowStartup.Foreground = "#000000";
            FilterItemSetting StartupLocation = new FilterItemSetting();
            StartupLocation.index = 6;
            StartupLocation.StringValue = "Startup";
            StartupLocation.FontStyle = "Normal";
            StartupLocation.Background = "#000000";
            StartupLocation.Foreground = "#000000";
            string value = "WindowStartupLocation";
            List<FilterItemSetting> actual;
            actual = RichTextBoxHelper_Accessor.MergeColor(splitFilter, value, WindowStartup, StartupLocation);
            Assert.AreEqual(3, actual.Count);
        }
        /// <summary>
        ///A test for OnDocumentXamlPropertyChanged
        ///</summary>
        [TestMethod()]
        public void OnDocumentXamlPropertyChangedfilterSettingListIsNullTest()
        {
            String str = "WindowStartup";
            RichTextBox rtb = new RichTextBox();
            rtb.Name = "Content";
            rtb.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)str);
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(); 
            RichTextBoxHelper_Accessor.OnDocumentXamlPropertyChanged(rtb, args);
        }
        [TestMethod()]
        public void OnDocumentXamlPropertyChangedfilterSettingListIsNotNullpatternColorIsNullTest()
        {
            String str = "WindowStartup";
            RichTextBox rtb = new RichTextBox();
            rtb.Name = "Content";
            rtb.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)str);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting Startup = new FilterItemSetting();
            Startup.index = 6;
            Startup.StringValue = "Startup";
            Startup.FontStyle = "Normal";
            Startup.Background = "#000000";
            Startup.Foreground = "#000000";
            filterSettingList.Add(Startup);
            rtb.SetValue(RichTextBoxHelper_Accessor.FilterToShowProperty, (object)filterSettingList);
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs();
            RichTextBoxHelper_Accessor.OnDocumentXamlPropertyChanged(rtb, args);
        }
        [TestMethod()]
        public void OnDocumentXamlPropertyChangedfilterSettingListIsNotNullpatternColorIsNotNullTest()
        {
            String str = "WindowStartup";
            RichTextBox rtb = new RichTextBox();
            rtb.Name = "Content";
            rtb.SetValue(RichTextBoxHelper_Accessor.DocumentXamlProperty, (object)str);
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting Startup = new FilterItemSetting();
            Startup.index = 6;
            Startup.StringValue = "Startup";
            Startup.FontStyle = "Normal";
            Startup.Background = "#000000";
            Startup.Foreground = "#000000";
            PatternColor<CCSLogRecord> patternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
            Startup.PatternColor = patternColor;
            filterSettingList.Add(Startup);
            rtb.SetValue(RichTextBoxHelper_Accessor.FilterToShowProperty, (object)filterSettingList);
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs();
            RichTextBoxHelper_Accessor.OnDocumentXamlPropertyChanged(rtb, args);
        }
        /// <summary>
        ///A test for OnFilterToShowChanged
        ///</summary>
        [TestMethod()]
        public void OnFilterToShowChangedPatternColorIsNullTest()
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Name = "Content";
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting Startup = new FilterItemSetting();
            Startup.index = 6;
            Startup.StringValue = "Startup";
            Startup.FontStyle = "Normal";
            Startup.Background = "#000000";
            Startup.Foreground = "#000000";
            filterSettingList.Add(Startup);
            rtb.SetValue(RichTextBoxHelper_Accessor.FilterToShowProperty, (object)filterSettingList);
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(); 
            RichTextBoxHelper_Accessor.OnFilterToShowChanged(rtb, args);
        }
        [TestMethod()]
        public void OnFilterToShowChangedPatternColorIsNotNullTest()
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Name = "Content";
            List<FilterItemSetting> filterSettingList = new List<FilterItemSetting>();
            FilterItemSetting Startup = new FilterItemSetting();
            Startup.index = 6;
            Startup.StringValue = "Startup";
            Startup.FontStyle = "Normal";
            Startup.Background = "#000000";
            Startup.Foreground = "#000000";
            PatternColor<CCSLogRecord> patternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
            Startup.PatternColor = patternColor;
            filterSettingList.Add(Startup);
            rtb.SetValue(RichTextBoxHelper_Accessor.FilterToShowProperty, (object)filterSettingList);
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs();
            RichTextBoxHelper_Accessor.OnFilterToShowChanged(rtb, args);
        }
        /// <summary>
        ///A test for OnLineOfContentPropertyChanged
        ///</summary>
        [TestMethod()]
        public void OnLineOfContentPropertyChangedTest()
        {
            DependencyObject o = null;
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(); 
            RichTextBoxHelper_Accessor.OnLineOfContentPropertyChanged(o, args);
        }

        /// <summary>
        ///A test for OnShowPatternColoringChanged
        ///</summary>
        [TestMethod()]
        public void OnShowPatternColoringChangedTest()
        {
            DependencyObject o = null;
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(); 
            RichTextBoxHelper_Accessor.OnShowPatternColoringChanged(o, args);
        }

        /// <summary>
        ///A test for SetDocumentXaml
        ///</summary>
        [TestMethod()]
        public void SetDocumentXamlTest()
        {
            String str = "WindowStartup";
            RichTextBox rtb = new RichTextBox();
            rtb.Name = "Content";
            RichTextBoxHelper.SetDocumentXaml(rtb, str);
        }

        /// <summary>
        ///A test for SetFilterToShow
        ///</summary>
        [TestMethod()]
        public void SetFilterToShowTest()
        {
            RichTextBox rtb = new RichTextBox();
            List<FilterItemSetting> filters = new List<FilterItemSetting>();
            RichTextBoxHelper.SetFilterToShow(rtb, filters);
        }

        /// <summary>
        ///A test for SetFontStyle
        ///</summary>
        [TestMethod()]
        public void SetFontStyleNormalTest()
        {
            Run control = new Run("test");
            string fontStyle = "Normal";
            RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        }
        [TestMethod()]
        public void SetFontStyleBoldTest()
        {
            Run control = new Run("test");
            string fontStyle = "Bold";
            RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        }
        [TestMethod()]
        public void SetFontStyleItalicTest()
        {
            Run control = new Run("test");
            string fontStyle = "Italic";
            RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        }
        [TestMethod()]
        public void SetFontStyleBoldItalicTest()
        {
            Run control = new Run("test");
            string fontStyle = "BoldItalic";
            RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        }
        [TestMethod()]
        [ExpectedException(typeof(DataValueNotSupportedException))]
        public void SetFontStyleBoldItalicDataValueNotSupportedExceptionTest()
        {
            Run control = new Run("test");
            string fontStyle = "asdasdasd";
            RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        }
        /// <summary>
        ///A test for SetLineOfContent
        ///</summary>
        [TestMethod()]
        public void SetLineOfContentTest()
        {
            RichTextBox rtb = new RichTextBox();
            string value = "1";
            RichTextBoxHelper.SetLineOfContent(rtb, value);
        }

        /// <summary>
        ///A test for SetShowPatternColoring
        ///</summary>
        [TestMethod()]
        public void SetShowPatternColoringTest()
        {
            RichTextBox o = new RichTextBox();
            object value = new object(); 
            RichTextBoxHelper.SetShowPatternColoring(o, value);
        }

        /// <summary>
        ///A test for ShowPatternColoring
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShowPatternColoringContentPatternIsNullTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            object pattern = null;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, pattern, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringContentPatternIsNullTest1()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            FilterItemSetting item = new FilterItemSetting();
            PatternColor<CCSLogRecord> pattern = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringContentPatternIsNullTest2()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            FilterItemSetting item = new FilterItemSetting();
            PatternColor<CCSLogRecord> pattern = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringContentPatternIsNotNullRootkeyNotNullTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            FilterItemSetting item = new FilterItemSetting();
            Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>> root = new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>();
            root.Add(0, new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>(0, "", 1, new CCSLogRecord()));
            PatternColor<CCSLogRecord> pattern = new PatternColor<CCSLogRecord>(root, new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringContentPatternIsNotNullRootkeyNotNullListkeyNotNullTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            FilterItemSetting item = new FilterItemSetting();
            Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>> root = new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>();
            root.Add(0, new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>(0, "", 1, new CCSLogRecord()));
            List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>> list = new List<KeyIndexRecordPair<int,string,int,CCSLogRecord,string>>();
            KeyIndexRecordPair<int, string, int, CCSLogRecord, string> key = new KeyIndexRecordPair<int,string,int,CCSLogRecord,string>(0, "", 1, new CCSLogRecord());
            list.Add(key);
            PatternColor<CCSLogRecord> pattern = new PatternColor<CCSLogRecord>(root, list);
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringContentPatternIsNotNullRootkeyNullListkeyNotNullTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            FilterItemSetting item = new FilterItemSetting();
            Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>> root = new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>();
            root.Add(1, new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>(0, "", 1, new CCSLogRecord()));
            List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>> list = new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>();
            KeyIndexRecordPair<int, string, int, CCSLogRecord, string> key = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>(0, "", 1, new CCSLogRecord());
            list.Add(key);
            PatternColor<CCSLogRecord> pattern = new PatternColor<CCSLogRecord>(root, list);
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringContentPatternIsNotNullRootkeyNullListkeyNotNullTest1()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Content";
            FilterItemSetting item = new FilterItemSetting();
            Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>> root = new Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>();
            root.Add(1, new KeyIndexRecordPair<int, string, int, CXDILogRecord, string>(0, "", 1, new CXDILogRecord()));
            List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>> list = new List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>();
            KeyIndexRecordPair<int, string, int, CXDILogRecord, string> key = new KeyIndexRecordPair<int, string, int, CXDILogRecord, string>(0, "", 1, new CXDILogRecord());
            list.Add(key);
            PatternColor<CXDILogRecord> pattern = new PatternColor<CXDILogRecord>(root, list);
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }


        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShowPatternColoringMessagePatternIsNullTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Message";
            object pattern = null;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, pattern, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringMessagePatternIsNullTest1()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Message";
            FilterItemSetting item = new FilterItemSetting();
            PatternColor<CXDILogRecord> pattern = new PatternColor<CXDILogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>());
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringMessagePatternIsNullTest2()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Message";
            FilterItemSetting item = new FilterItemSetting();
            PatternColor<CXDILogRecord> pattern = new PatternColor<CXDILogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>());
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringMessagePatternIsNotNullRootkeyNotNullTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Message";
            FilterItemSetting item = new FilterItemSetting();
            Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>> root = new Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>();
            root.Add(0, new KeyIndexRecordPair<int, string, int, CXDILogRecord, string>(0, "", 1, new CXDILogRecord()));
            PatternColor<CXDILogRecord> pattern = new PatternColor<CXDILogRecord>(root, new List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>());
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringMessagePatternIsNotNullRootkeyNotNullListkeyNotNullTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Message";
            FilterItemSetting item = new FilterItemSetting();
            Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>> root = new Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>();
            root.Add(0, new KeyIndexRecordPair<int, string, int, CXDILogRecord, string>(0, "", 1, new CXDILogRecord()));
            List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>> list = new List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>();
            KeyIndexRecordPair<int, string, int, CXDILogRecord, string> key = new KeyIndexRecordPair<int, string, int, CXDILogRecord, string>(0, "", 1, new CXDILogRecord());
            list.Add(key);
            PatternColor<CXDILogRecord> pattern = new PatternColor<CXDILogRecord>(root, list);
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        [TestMethod()]
        public void ShowPatternColoringMessagePatternIsNotNullRootkeyNullListkeyNotNullTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Message";
            FilterItemSetting item = new FilterItemSetting();
            Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>> root = new Dictionary<int, KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>();
            root.Add(1, new KeyIndexRecordPair<int, string, int, CXDILogRecord, string>(0, "", 1, new CXDILogRecord()));
            List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>> list = new List<KeyIndexRecordPair<int, string, int, CXDILogRecord, string>>();
            KeyIndexRecordPair<int, string, int, CXDILogRecord, string> key = new KeyIndexRecordPair<int, string, int, CXDILogRecord, string>(0, "", 1, new CXDILogRecord());
            list.Add(key);
            PatternColor<CXDILogRecord> pattern = new PatternColor<CXDILogRecord>(root, list);
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }


        [TestMethod()]
        public void ShowPatternColoringMessagePatternIsNotNullRootkeyNullListkeyNotNullTest1()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Message";
            FilterItemSetting item = new FilterItemSetting();
            Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>> root = new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>();
            root.Add(1, new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>(0, "", 1, new CCSLogRecord()));
            List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>> list = new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>();
            KeyIndexRecordPair<int, string, int, CCSLogRecord, string> key = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>(0, "", 1, new CCSLogRecord());
            list.Add(key);
            PatternColor<CCSLogRecord> pattern = new PatternColor<CCSLogRecord>(root, list);
            item.PatternColor = pattern;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, item, filterItemSetting);
        }
        
        [TestMethod()]
        public void ShowPatternColoringNameIsNotContentAndMessageTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "Line";
            object pattern = null;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();
            RichTextBoxHelper_Accessor.ShowPatternColoring(richTextBox, pattern, filterItemSetting);
        }
        #region LongestCommonSubstring
        [TestMethod]
        /// <summary>
        ///A test for LongestCommonSubstring
        ///case : string 1 union with string2
        ///Expected : return expected list
        ///</summary>
        public void LongestCommonSubstring1()
        {
            List<string> expected = new List<string> { "ab", "cd", "ef" };
            CollectionAssert.AreEqual(expected, RichTextBoxHelper.LongestCommonSubstring("abcdef", 0, 2, 4, 4));
        }
        [TestMethod]
        /// <summary>
        ///A test for LongestCommonSubstring
        ///case : string 1 union with string2
        ///Expected : return expected list
        ///</summary>
        public void LongestCommonSubstring2()
        {
            List<string> expected = new List<string> { "ab", "cdef", "" };
            CollectionAssert.AreEqual(expected, RichTextBoxHelper.LongestCommonSubstring("abcdef", 0, 2, 6, 4));
        }
        [TestMethod]
        /// <summary>
        ///A test for LongestCommonSubstring
        ///case : string 1 contains string2
        ///Expected : return expected list
        ///</summary>
        public void LongestCommonSubstring3()
        {
            List<string> expected = new List<string> { "ab", "cdef", "gh" };
            CollectionAssert.AreEqual(expected, RichTextBoxHelper.LongestCommonSubstring("abcdefgh", 0, 2, 8, 4));
        }
        #endregion

        #region RGBToHex
        [TestMethod]
        /// <summary>
        ///A test for RGBToHex
        ///case : convert white color RBG to hex string
        ///Expected : return expected string
        ///</summary>
        public void RGBToHex_rgb_white()
        {
            string expected = "#000000";
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB rgb = new RichTextBoxHelper.RGB(0, 0, 0);
            Assert.AreEqual(expected, RichTextBoxHelper.RBGToHex(rgb));
        }
        [TestMethod]
        /// <summary>
        ///A test for RGBToHex
        ///case : convert black color RBG to hex string
        ///Expected : return expected string
        ///</summary>
        public void RGBToHex_rgb_black()
        {
            string expected = "#FFFFFF";
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB rgb = new RichTextBoxHelper.RGB(255, 255, 255);
            Assert.AreEqual(expected, RichTextBoxHelper.RBGToHex(rgb));
        }
        [TestMethod]
        /// <summary>
        ///A test for RGBToHex
        ///case : convert blue color RBG to hex string
        ///Expected : return expected string
        ///</summary>
        public void RGBToHex_rgb_blue()
        {
            string expected = "#0606FF";
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB rgb = new RichTextBoxHelper.RGB(6, 6, 255);
            Assert.AreEqual(expected, RichTextBoxHelper.RBGToHex(rgb));
        }
        #endregion

        #region ColorToRGB
        [TestMethod]
        /// <summary>
        ///A test for ColorToRGB
        ///case : convert hex string to color RBG white
        ///Expected : return expected RGB
        ///</summary>
        public void ColorToRGB_white()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB expected = new RichTextBoxHelper.RGB(0, 0, 0);
            Assert.AreEqual(expected, RichTextBoxHelper.ColorToRGB("#000000"));
        }
        [TestMethod]
        /// <summary>
        ///A test for ColorToRGB
        ///case : convert hex string to color RBG black
        ///Expected : return expected RGB
        ///</summary>
        public void ColorToRGB_black()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB expected = new RichTextBoxHelper.RGB(255, 255, 255);
            Assert.AreEqual(expected, RichTextBoxHelper.ColorToRGB("#FFFFFF"));
        }
        [TestMethod]
        /// <summary>
        ///A test for ColorToRGB
        ///case : convert hex string to color RBG blue
        ///Expected : return expected RGB
        ///</summary>
        public void ColorToRGB_blue()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB expected = new RichTextBoxHelper.RGB(6, 6, 255);
            Assert.AreEqual(expected, RichTextBoxHelper.ColorToRGB("#0606FF"));
        }
        #endregion

        #region LabtoRGB
        [TestMethod]
        /// <summary>
        ///A test for LabtoRGB
        ///case : convert lab color to RBG color white
        ///Expected : return expected RGB
        ///</summary>
        public void LabtoRGB_white()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB expected = new RichTextBoxHelper.RGB(0, 0, 0);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab = new RichTextBoxHelper.CIELab(0, 0, 0);
            Assert.AreEqual(expected, RichTextBoxHelper.LabtoRGB(lab));
        }
        [TestMethod]
        /// <summary>
        ///A test for LabtoRGB
        ///case : convert lab color to RBG color black
        ///Expected : return expected RGB
        ///</summary>
        public void LabtoRGB_black()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB expected = new RichTextBoxHelper.RGB(255, 255, 255);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab = RichTextBoxHelper.RGBtoLab(expected);
            Assert.AreEqual(expected.Blue, RichTextBoxHelper.LabtoRGB(lab).Blue);
        }
        [TestMethod]
        /// <summary>
        ///A test for LabtoRGB
        ///case : convert lab color to RBG color blue
        ///Expected : return expected RGB
        ///</summary>
        public void LabtoRGB_blue()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB expected = new RichTextBoxHelper.RGB(6, 6, 255);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab = RichTextBoxHelper.RGBtoLab(expected);
            Assert.AreEqual(255, RichTextBoxHelper.LabtoRGB(lab).Blue);
        }
        #endregion

        #region LabtoXYZ
        [TestMethod]
        /// <summary>
        ///A test for LabtoXYZ
        ///case : convert lab color to XYZ color white
        ///Expected : return expected XYZ
        ///</summary>
        public void LabtoXYZ_white()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIEXYZ expected = new RichTextBoxHelper.CIEXYZ(0, 0, 0);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab = new RichTextBoxHelper.CIELab(0, 0, 0);
            Assert.AreEqual(expected, RichTextBoxHelper.LabtoXYZ(lab.L, lab.A, lab.B));
        }
        [TestMethod]
        /// <summary>
        ///A test for LabtoXYZ
        ///case : convert lab color to XYZ 
        ///Expected : return expected XYZ
        ///</summary>
        public void LabtoXYZ_100()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab = new RichTextBoxHelper.CIELab(100, 128, 128);
            Assert.AreEqual(1, RichTextBoxHelper.LabtoXYZ(lab.L, lab.A, lab.B).X / 0.9505);
            Assert.AreEqual(1, RichTextBoxHelper.LabtoXYZ(lab.L, lab.A, lab.B).Y / 1);
        }
        #endregion
        #region RGBtoXYZ
        [TestMethod]
        /// <summary>
        ///A test for RGBtoXYZ
        ///case : convert RGB color to XYZ color white
        ///Expected : return expected XYZ
        ///</summary>
        public void RGBtoXYZ_white()
        {
            //LogViewer.MVVMHelper.RichTextBoxHelper.RGB rgb = new RichTextBoxHelper.RGB(0, 0, 0);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIEXYZ expected = new RichTextBoxHelper.CIEXYZ(0, 0, 0);
            Assert.AreEqual(expected, RichTextBoxHelper.RGBtoXYZ(0, 0, 0));
        }
        [TestMethod]
        /// <summary>
        ///A test for RGBtoXYZ
        ///case : convert RGB color to XYZ color black
        ///Expected : return expected XYZ
        ///</summary>
        public void RGBtoXYZ_black()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIEXYZ expected = new RichTextBoxHelper.CIEXYZ(255, 255, 255);
            Assert.AreEqual(expected.X, RichTextBoxHelper.RGBtoXYZ(255, 255, 255).X);
        }
        [TestMethod]
        /// <summary>
        ///A test for RGBtoXYZ
        ///case : convert RGB color to XYZ color blue
        ///Expected : return expected XYZ
        ///</summary>
        public void RGBtoXYZ_blue()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIEXYZ expected = new RichTextBoxHelper.CIEXYZ(6, 6, 255);
            Assert.AreEqual(expected.X, RichTextBoxHelper.RGBtoXYZ(255, 255, 255).X);
        }
        #endregion
        #region XYZToLab
        [TestMethod]
        /// <summary>
        ///A test for XYZToLab
        ///case : convert XYZ color to Lab color white
        ///Expected : return expected Lab
        ///</summary>
        public void XYZToLab_white()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab expected = new RichTextBoxHelper.CIELab(0, 0, 0);
            Assert.AreEqual(expected, RichTextBoxHelper.XYZtoLab(0, 0, 0));
        }
        #endregion
        #region XYZToRGB
        [TestMethod]
        /// <summary>
        ///A test for XYZToRGB
        ///case : convert XYZ color to RGB color white
        ///Expected : return expected RGB
        ///</summary>
        public void XYZToRGB_white()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB expected = new RichTextBoxHelper.RGB(0, 0, 0);
            Assert.AreEqual(expected, RichTextBoxHelper.XYZtoRGB(0, 0, 0));
        }
        #endregion
        #region mixLabColor
        [TestMethod]
        /// <summary>
        ///A test for mixLabColor
        ///case : mid two lab color
        ///Expected : return expected lab
        ///</summary>
        public void mixLabColor_1()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab1 = new RichTextBoxHelper.CIELab(0, 0, 0);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab2 = new RichTextBoxHelper.CIELab(10, 10, 10);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab expected = new RichTextBoxHelper.CIELab(5, 5, 5);
            Assert.AreEqual(expected, RichTextBoxHelper.mixLabColor(lab1, lab2));
        }
        [TestMethod]
        /// <summary>
        ///A test for mixLabColor
        ///case : mid two lab color
        ///Expected : return expected lab
        ///</summary>
        public void mixLabColor_2()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab1 = new RichTextBoxHelper.CIELab(0, 0, 0);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab2 = new RichTextBoxHelper.CIELab(20, 20, 20);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab expected = new RichTextBoxHelper.CIELab(10, 10, 10);
            Assert.AreEqual(expected, RichTextBoxHelper.mixLabColor(lab1, lab2));
        }
        [TestMethod]
        /// <summary>
        ///A test for mixLabColor
        ///case : mid two lab color
        ///Expected : return expected lab
        ///</summary>
        public void mixLabColor_3()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab1 = new RichTextBoxHelper.CIELab(50, 50, 50);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab2 = new RichTextBoxHelper.CIELab(100, 100, 100);
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab expected = new RichTextBoxHelper.CIELab(75, 75, 75);
            Assert.AreEqual(expected, RichTextBoxHelper.mixLabColor(lab1, lab2));
        }
        #endregion
        #region IndexOfAll
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll return List<int> of sub string in parrent string agnore lower fasle
        ///case : string not contains substring
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll_1()
        {
            string str = "aaabbbccc";
            string substring = "dddd";
            int expected = 0;
            List<int> indexs = RichTextBoxHelper.IndexOfAll(str, substring);
            Assert.AreEqual(expected, indexs.Count);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll return List<int> of sub string in parrent string agnore lower fasle
        ///case : string not contains substring Upper
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll_2()
        {
            string str = "aaabbbccc";
            string substring = "DDDD";
            int expected = 0;
            List<int> indexs = RichTextBoxHelper.IndexOfAll(str, substring);
            Assert.AreEqual(expected, indexs.Count);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll return List<int> of sub string in parrent string agnore lower fasle
        ///case : string contains substring 
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll_3()
        {
            string str = "aaabbbccc";
            string substring = "bbb";
            int expected = 3;
            List<int> indexs = RichTextBoxHelper.IndexOfAll(str, substring);
            Assert.AreEqual(expected, indexs[0]);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll return List<int> of sub string in parrent string agnore lower fasle
        ///case : string contains substring Upper
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll_4()
        {
            string str = "aaabbbccc";
            string substring = "BBB";
            int expected = 3;
            List<int> indexs = RichTextBoxHelper.IndexOfAll(str, substring);
            Assert.AreEqual(expected, indexs[0]);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll return List<int> of sub string in parrent string agnore lower fasle
        ///case : string contains more substring 
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll_5()
        {
            string str = "aaabbbcccbbb";
            string substring = "bbb";
            List<int> indexs = RichTextBoxHelper.IndexOfAll(str, substring);
            Assert.AreEqual(3, indexs[0]);
            Assert.AreEqual(9, indexs[1]);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll return List<int> of sub string in parrent string agnore lower fasle
        ///case : string contains more substring Upper
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll_6()
        {
            string str = "aaabbbcccBBB";
            string substring = "BBB";
            List<int> indexs = RichTextBoxHelper.IndexOfAll(str, substring);
            Assert.AreEqual(3, indexs[0]);
            Assert.AreEqual(9, indexs[1]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexOfAll_7()
        {
            string str = "";
            string substring = "";
            List<int> indexs = RichTextBoxHelper.IndexOfAll(str, substring);
            Assert.AreEqual(3, indexs[0]);
            Assert.AreEqual(9, indexs[1]);
        }
        #endregion
        #region IndexOfAll1
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll1 return List<int> of sub string in parrent string agnore lower true
        ///case : string not contains substring
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll1_1()
        {
            string str = "aaabbbccc";
            string substring = "dddd";
            int expected = 0;
            List<int> indexs = RichTextBoxHelper.IndexOfAll1(str, substring);
            Assert.AreEqual(expected, indexs.Count);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll1 return List<int> of sub string in parrent string agnore lower true
        ///case : string not contains substring Upper
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll1_2()
        {
            string str = "aaabbbccc";
            string substring = "DDDD";
            int expected = 0;
            List<int> indexs = RichTextBoxHelper.IndexOfAll1(str, substring);
            Assert.AreEqual(expected, indexs.Count);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll1 return List<int> of sub string in parrent string agnore lower true
        ///case : string contains substring 
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll1_3()
        {
            string str = "aaabbbccc";
            string substring = "bbb";
            int expected = 3;
            List<int> indexs = RichTextBoxHelper.IndexOfAll1(str, substring);
            Assert.AreEqual(expected, indexs[0]);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll1 return List<int> of sub string in parrent string agnore lower true
        ///case : string contains substring Upper
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll1_4()
        {
            string str = "aaabbbccc";
            string substring = "BBB";
            int expected = 0;
            List<int> indexs = RichTextBoxHelper.IndexOfAll1(str, substring);
            Assert.AreEqual(expected, indexs.Count);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll1 return List<int> of sub string in parrent string agnore lower true
        ///case : string contains more substring 
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll1_5()
        {
            string str = "aaabbbcccbbb";
            string substring = "bbb";
            List<int> indexs = RichTextBoxHelper.IndexOfAll1(str, substring);
            Assert.AreEqual(3, indexs[0]);
            Assert.AreEqual(9, indexs[1]);
        }
        [TestMethod]
        /// <summary>
        ///A test for IndexOfAll1 return List<int> of sub string in parrent string agnore lower true
        ///case : string contains more substring Upper
        ///Expected : return List<int>
        ///</summary>
        public void IndexOfAll1_6()
        {
            string str = "aaabbbcccBBB";
            string substring = "BBB";
            List<int> indexs = RichTextBoxHelper.IndexOfAll1(str, substring);
            Assert.AreEqual(9, indexs[0]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexOfAll1_7()
        {
            string str = "";
            string substring = "";
            List<int> indexs = RichTextBoxHelper.IndexOfAll1(str, substring);
        }
        #endregion
        #region CIELab
        [TestMethod()]
        public void CIELabEqualsTest()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab = new RichTextBoxHelper.CIELab();
            Assert.IsFalse(lab.Equals(null));
        }
        [TestMethod()]
        public void CIELabGetHashCodeTest()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab = new RichTextBoxHelper.CIELab();
            Assert.AreEqual(0, lab.GetHashCode());
        }
        [TestMethod()]
        public void CIELabOperatorNotEqual()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab = new RichTextBoxHelper.CIELab();
            lab.A = 0;
            lab.B = 0;
            lab.L = 0;
            LogViewer.MVVMHelper.RichTextBoxHelper.CIELab lab1 = new RichTextBoxHelper.CIELab();
            lab1.A = 1;
            lab1.B = 0;
            lab1.L = 0;
            Assert.IsTrue(lab != lab1);
        }
        #endregion
        #region CIEXYZ

        [TestMethod()]
        public void CIEXYZEqualsTest()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIEXYZ xyz = new RichTextBoxHelper.CIEXYZ();
            Assert.IsFalse(xyz.Equals(null));
        }
        [TestMethod()]
        public void CIEXYZGetHashCodeTest()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIEXYZ xyz = new RichTextBoxHelper.CIEXYZ();
            Assert.AreEqual(0, xyz.GetHashCode());
        }
        [TestMethod()]
        public void CIEXYZOperatorNotEqualTest()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.CIEXYZ xyz = new RichTextBoxHelper.CIEXYZ();
            xyz.X = 0;
            xyz.Y = 0;
            xyz.Z = 0;
            LogViewer.MVVMHelper.RichTextBoxHelper.CIEXYZ xyz1 = new RichTextBoxHelper.CIEXYZ();
            xyz1.X = 1;
            xyz1.Y = 0;
            xyz1.Z = 0;
            Assert.IsTrue(xyz != xyz1);
        }
        #endregion
        #region RGB

        [TestMethod()]
        public void RGBqualsTest()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB rgb = new RichTextBoxHelper.RGB();
            Assert.IsFalse(rgb.Equals(null));
        }
        [TestMethod()]
        public void RGBGetHashCodeTest()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB rgb = new RichTextBoxHelper.RGB();
            Assert.AreEqual(0, rgb.GetHashCode());
        }
        [TestMethod()]
        public void RGBOperatorNotEqualTest()
        {
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB rbg = new RichTextBoxHelper.RGB();
            rbg.Blue = 0;
            rbg.Red = 0;
            rbg.Green = 0;
            LogViewer.MVVMHelper.RichTextBoxHelper.RGB rbg1 = new RichTextBoxHelper.RGB();
            rbg.Blue = 1;
            rbg.Red = 0;
            rbg.Green = 0;
            Assert.IsTrue(rbg != rbg1);
        }
        #endregion
    }
}
