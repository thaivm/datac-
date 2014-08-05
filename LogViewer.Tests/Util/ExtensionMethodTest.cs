using LogViewer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using LogViewer.Model;
using System.Runtime.Serialization.Formatters.Binary;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ExtensionMethodTest and is intended
    ///to contain all ExtensionMethodTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtensionMethodTest
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
        ///A test for ClearAndSetNull - list is not null
        ///</summary>
        [TestMethod()]
        public void ClearAndSetNull_NotNullTest()
        {
            ICollection<CCSLogRecord> list = new List<CCSLogRecord>();
            ExtensionMethod.ClearAndSetNull<CCSLogRecord>(list);
        }

        /// <summary>
        ///A test for ClearAndSetNull - list is null
        ///</summary>
        [TestMethod()]
        public void ClearAndSetNull_NullTest()
        {
            ICollection<CCSLogRecord> list = null;
            ExtensionMethod.ClearAndSetNull<CCSLogRecord>(list);
        }

        /// <summary>
        ///A test for DeepCopy
        ///</summary>
        //[TestMethod()]
        //public void DeepCopyTest()
        //{
        //    //CCSLogRecord expected = new CCSLogRecord
        //    //    {
        //    //        Type = "1",
        //    //        Time = "01:01:01.001",
        //    //        ThreadId = "1"
        //    //    };
        //    //expected.DeepCopy<CCSLogRecord>();
        //    //CCSLogRecord actual;
        //    //actual = ExtensionMethod.DeepCopy<CCSLogRecord>(expected);
        //    //Assert.AreEqual(expected, actual);
        //}
    }
}
