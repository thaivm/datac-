using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for FilterItemProxyTest and is intended
    ///to contain all FilterItemProxyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FilterItemProxyTest
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
        ///A test for IsMatch - regex is null
        ///</summary>
        [TestMethod()]
        public void IsMatch_RegexNullTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            Assert.IsFalse(target.IsMatch("1"));
        }

        /// <summary>
        ///A test for IsMatch - searchString is null
        ///</summary>
        [TestMethod()]
        public void IsMatch_SearchStringNullTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._regex = new Regex("\\d");
            target._filterItemSetting.StringValue = "1";
            Assert.IsFalse(target.IsMatch(null));
        }

        /// <summary>
        ///A test for IsMatch - _filterItemSetting is null
        ///</summary>
        [TestMethod()]
        public void IsMatch_FilterItemSettingNullTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._regex = new Regex("\\d");
            Assert.IsFalse(target.IsMatch("1"));
        }

        /// <summary>
        ///A test for IsMatch - _keywordCount > 0 and regex
        ///</summary>
        [TestMethod()]
        public void IsMatch_KeywordCountRegexGreaterZeroTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._regex = new Regex("\\d");
            target._filterItemSetting.StringValue = "1";
            target._keywordCount = 1;
            Assert.IsFalse(target.IsMatch("\\d"));
        }

        /// <summary>
        ///A test for IsMatch - _keywordCount > 0 and string
        ///</summary>
        [TestMethod()]
        public void IsMatch_KeywordCountStringGreaterZeroTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._regex = new Regex("\\d");
            target._filterItemSetting.StringValue = "1";
            target._keywordCount = 1;
            Assert.IsTrue(target.IsMatch("1"));
        }

        /// <summary>
        ///A test for IsMatch - _keywordCount = 0 and not filter
        ///</summary>
        [TestMethod()]
        public void IsMatch_KeywordCountEqualsZeroNotFilterTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._regex = new Regex("\\d");
            target._filterItemSetting.StringValue = "2";
            target._keywordCount = 0;
            Assert.IsFalse(target.IsMatch("1"));
        }

        /// <summary>
        ///A test for IsMatch - _keywordCount = 0 and filter setting
        ///</summary>
        [TestMethod()]
        public void IsMatch_KeywordCountEqualsZeroFilterTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._regex = new Regex("\\d");
            target._filterItemSetting.StringValue = "2";
            target._keywordCount = 0;
            Assert.IsTrue(target.IsMatch("2"));
        }

        /// <summary>
        ///A test for BuildSearchMethod
        ///</summary>
        [TestMethod()]
        public void BuildSearchMethodStringTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._filterItemSetting.StringValue = "\"?\"";
            target.BuildSearchMethod(RegexOptions.None);
            Assert.IsNull(target._regex);
        }

        /// <summary>
        ///A test for BuildSearchMethod
        ///</summary>
        [TestMethod()]
        public void BuildSearchMethodRegexTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._filterItemSetting.StringValue = "\"\\d\"";
            target.BuildSearchMethod(RegexOptions.None);
            Assert.IsNotNull(target._regex);
        }

        /// <summary>
        ///A test for BuildSearchMethod
        ///</summary>
        [TestMethod()]
        public void BuildSearchMethodORTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._filterItemSetting.StringValue = "1 OR 2";
            target.BuildSearchMethod(RegexOptions.IgnoreCase);
            Assert.IsNotNull(target._regex);
        }

        /// <summary>
        ///A test for BuildSearchMethod
        ///</summary>
        [TestMethod()]
        public void BuildSearchMethodANDTest()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            target._filterItemSetting.StringValue = "1 2";
            target.BuildSearchMethod(RegexOptions.IgnoreCase);
            Assert.IsNotNull(target._regex);
        }

        /// <summary>
        ///A test for FilterItemSettingObj
        ///</summary>
        [TestMethod()]
        public void FilterItemSettingObjTest()
        {
            FilterItemProxy target = new FilterItemProxy(); 
            FilterItemSetting expected = null; 
            FilterItemSetting actual;
            target.FilterItemSettingObj = expected;
            actual = target.FilterItemSettingObj;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FilterItemProxy - contructor 0
        ///</summary>
        [TestMethod()]
        public void FilterItemProxyContructor0Test()
        {
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor();
            Assert.IsNotNull(target._filterItemSetting);
        }

        /// <summary>
        ///A test for FilterItemProxy - contructor - FilterItemSetting
        ///</summary>
        [TestMethod()]
        public void FilterItemProxyContructor_FilterItemSettingTest()
        {
            var expected = new FilterItemSetting();
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor(expected);
            Assert.AreEqual(expected, target._filterItemSetting);
        }

        /// <summary>
        ///A test for FilterItemProxy - contructor - SearchItem
        ///</summary>
        [TestMethod()]
        public void FilterItemProxyContructor_SearchItemTest()
        {
            var expected = new SearchItem();
            expected.StringValue = "Test";
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor(expected);
            Assert.AreEqual(expected.LogItem, target._filterItemSetting.LogItem);
            Assert.AreEqual(expected.StringValue.Trim(), target._filterItemSetting.StringValue);
        }

        /// <summary>
        ///A test for FilterItemProxy - contructor - ILogItemSearch
        ///</summary>
        [TestMethod()]
        public void FilterItemProxyContructor_ILogItemSearchTest()
        {
            var expected = new KeywordCountItemSetting();
            expected.StringValue = "Test";
            FilterItemProxy_Accessor target = new FilterItemProxy_Accessor(expected);
            Assert.AreEqual(expected.LogItem, target._filterItemSetting.LogItem);
            Assert.AreEqual(expected.StringValue.Trim(), target._filterItemSetting.StringValue);
        }
    }
}
