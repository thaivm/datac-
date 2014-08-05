using LogViewer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for RecentFileList_ApplicationAttributesTest and is intended
    ///to contain all RecentFileList_ApplicationAttributesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RecentFileList_ApplicationAttributesTest
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
        ///A test for CompanyName
        ///</summary>
        [TestMethod()]
        public void CompanyNameTest()
        {
            string expected = string.Empty;
            string actual;
            RecentFileList_Accessor.ApplicationAttributes.CompanyName = expected;
            actual = RecentFileList_Accessor.ApplicationAttributes.CompanyName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Copyright
        ///</summary>
        [TestMethod()]
        public void CopyrightTest()
        {
            string expected = string.Empty;
            string actual;
            RecentFileList_Accessor.ApplicationAttributes.Copyright = expected;
            actual = RecentFileList_Accessor.ApplicationAttributes.Copyright;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ProductName
        ///</summary>
        [TestMethod()]
        public void ProductNameTest()
        {
            string expected = string.Empty; 
            string actual;
            RecentFileList_Accessor.ApplicationAttributes.ProductName = expected;
            actual = RecentFileList_Accessor.ApplicationAttributes.ProductName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Title
        ///</summary>
        [TestMethod()]
        public void TitleTest()
        {
            string expected = string.Empty; 
            string actual;
            RecentFileList_Accessor.ApplicationAttributes.Title = expected;
            actual = RecentFileList_Accessor.ApplicationAttributes.Title;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            string expected = string.Empty;
            string actual;
            RecentFileList_Accessor.ApplicationAttributes.Version = expected;
            actual = RecentFileList_Accessor.ApplicationAttributes.Version;
            Assert.AreEqual(expected, actual);
        }
    }
}
