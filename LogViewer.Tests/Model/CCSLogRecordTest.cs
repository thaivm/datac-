using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CCSLogRecordTest and is intended
    ///to contain all CCSLogRecordTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CCSLogRecordTest
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
        ///A test for CCSLogRecord Constructor
        ///</summary>
        [TestMethod()]
        public void CCSLogRecordConstructorTest()
        {
            CCSLogRecord target = new CCSLogRecord();
            Assert.AreNotEqual(null,target);
        }

        /// <summary>
        ///A test for AdditionalInfo
        ///</summary>
        [TestMethod()]
        public void AdditionalInfoTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.AdditionalInfo = expected;
            actual = target.AdditionalInfo;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ClassName
        ///</summary>
        [TestMethod()]
        public void ClassNameTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.ClassName = expected;
            actual = target.ClassName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Content
        ///</summary>
        [TestMethod()]
        public void ContentTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.Content = expected;
            actual = target.Content;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HostName
        ///</summary>
        [TestMethod()]
        public void HostNameTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.HostName = expected;
            actual = target.HostName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Mode
        ///</summary>
        [TestMethod()]
        public void ModeTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.Mode = expected;
            actual = target.Mode;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Module
        ///</summary>
        [TestMethod()]
        public void ModuleTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.Module = expected;
            actual = target.Module;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PersonalInfo
        ///</summary>
        [TestMethod()]
        public void PersonalInfoTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.PersonalInfo = expected;
            actual = target.PersonalInfo;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ThreadId
        ///</summary>
        [TestMethod()]
        public void ThreadIdTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.ThreadId = expected;
            actual = target.ThreadId;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            CCSLogRecord target = new CCSLogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);
        }
    }
}
