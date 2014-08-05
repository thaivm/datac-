using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CXDIResultSearchKeywordViewModelTest and is intended
    ///to contain all CXDIResultSearchKeywordViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CXDIResultSearchKeywordViewModelTest
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
        ///A test for GetDefaultSelectedLogItem
        ///</summary>
        //GetDefaultSelectedLogItemTest_False_StringNull
        [TestMethod()]
        public void GetDefaultSelectedLogItemTest_False_StringNull()
        {
            CXDIResultSearchKeywordViewModel_Accessor target = new CXDIResultSearchKeywordViewModel_Accessor();
            string expected = string.Empty;
            string actual;
            actual = target.GetDefaultSelectedLogItem();
            Assert.AreNotEqual(expected, actual);            
        }
        //GetDefaultSelectedLogItemTest_False_anotherValue
        [TestMethod()]
        public void GetDefaultSelectedLogItemTest_False_anotherValue()
        {
            CXDIResultSearchKeywordViewModel_Accessor target = new CXDIResultSearchKeywordViewModel_Accessor();
            string expected = "abc";
            string actual;
            actual = target.GetDefaultSelectedLogItem();
            Assert.AreNotEqual(expected, actual);
        }
        //GetDefaultSelectedLogItemTest_True
        [TestMethod()]
        public void GetDefaultSelectedLogItemTest_True()
        {
            CXDIResultSearchKeywordViewModel_Accessor target = new CXDIResultSearchKeywordViewModel_Accessor();
            string expected = "Message";
            string actual;
            actual = target.GetDefaultSelectedLogItem();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InitLogItemList
        ///</summary>
        [TestMethod()]
        public void InitLogItemListTest()
        {
            CXDIResultSearchKeywordViewModel_Accessor target = new CXDIResultSearchKeywordViewModel_Accessor();
            List<ValueDisplayPair<string, string>> expected = new List<ValueDisplayPair<string,string>>();
            expected.Add(new ValueDisplayPair<string, string> { Value = "Line", Display = "Line" });
            expected.Add(new ValueDisplayPair<string, string> { Value = "Date", Display = "Date" });
            expected.Add(new ValueDisplayPair<string, string> { Value = "Time", Display = "Time" });
            expected.Add(new ValueDisplayPair<string, string> { Value = "Module", Display = "Module" });
            expected.Add(new ValueDisplayPair<string, string> { Value = "Message", Display = "Message" });
            expected.Add(new ValueDisplayPair<string, string> { Value = "Comment", Display = "Comment" });
            List<ValueDisplayPair<string, string>> actual;
            actual = target.InitLogItemList();
            Assert.ReferenceEquals(expected, actual); 
            
        }

        /// <summary>
        ///A test for IsValidLogField
        ///</summary>
        //IsValidLogFieldTest_False_StringEmpty
        [TestMethod()]
        public void IsValidLogFieldTest_False_StringEmpty()
        {
            CXDIResultSearchKeywordViewModel_Accessor target = new CXDIResultSearchKeywordViewModel_Accessor();
            string value = string.Empty;
            bool expected = false;
            bool actual;
            actual = target.IsValidLogField(value);
            Assert.AreEqual(expected, actual);            
        }
        //IsValidLogFieldTest_False_AnotherValue
        [TestMethod()]
        public void IsValidLogFieldTest_False_AnotherValue()
        {
            CXDIResultSearchKeywordViewModel_Accessor target = new CXDIResultSearchKeywordViewModel_Accessor();
            string value = string.Empty;
            bool expected = false;
            bool actual;
            actual = target.IsValidLogField(value);
            Assert.AreEqual(expected, actual);
        }
        //IsValidLogFieldTest_True
        [TestMethod()]
        
        public void IsValidLogFieldTest_True()
        {
            CXDIResultSearchKeywordViewModel_Accessor target = new CXDIResultSearchKeywordViewModel_Accessor();
            string value = "Message";
            bool expected = true;
            bool actual;
            actual = target.IsValidLogField(value);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for IsCCS
        ///</summary>
        [TestMethod()]
        public void IsCCSTest()
        {
            CXDIResultSearchKeywordViewModel target = new CXDIResultSearchKeywordViewModel();
            bool actual;
            actual = target.IsCCS;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsCXDI
        ///</summary>
        [TestMethod()]
        public void IsCXDITest()
        {
            CXDIResultSearchKeywordViewModel target = new CXDIResultSearchKeywordViewModel();
            bool actual;
            actual = target.IsCXDI;
            Assert.IsTrue(actual);
        }
    }
}
