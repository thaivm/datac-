using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for KeyIndexRecordPairTest and is intended
    ///to contain all KeyIndexRecordPairTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KeyIndexRecordPairTest
    {
        public static KeyIndexRecordPair<int, string, int, CCSLogRecord, string> target;
        public static CCSLogRecord ccs;

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
        ///A test for KeyIndexRecordPair`0 Constructor
        ///</summary>
        [TestMethod()]
        public void KeyIndexRecordPairConstructor0Test()
        {
            target = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>();
        }

        /// <summary>
        ///A test for KeyIndexRecordPair`5 Constructor
        ///</summary>
        [TestMethod()]
        public void KeyIndexRecordPairConstructor5Test()
        {
            ccs = new CCSLogRecord
            {
                AdditionalInfo = "",
                ClassName = "",
                Content = "12345",
                DateTime =DateTime.Parse("2013/10/02 01:01:01.001"),
                HostName = "1",
                Id = "1",
                Line = 1,
                Mode = "",
                Module = "1",
                PersonalInfo = "",
                ThreadId = "1",
                Type = "E"
            };
            target = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>(1, "234", 2, ccs);
            Assert.AreEqual(1, target.Line);
            Assert.AreEqual("234", target.Key);
            Assert.AreEqual(2, target.Index);
            Assert.AreEqual(ccs, target.Record);
        }

        /// <summary>
        ///A test for Color
        ///</summary>
        [TestMethod()]
        public void ColorTest()
        {
            target = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>();
            string expected = ConfigValue.listColor[0]; // TODO: Initialize to an appropriate value
            string actual;
            target.Color = expected;
            actual = target.Color;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            target = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>();
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Index = expected;
            actual = target.Index;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            target = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>();
            string expected = "1"; // TODO: Initialize to an appropriate value
            string actual;
            target.Key = expected;
            actual = target.Key;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void LineTest()
        {
            target = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>();
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Line = expected;
            actual = target.Line;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Record
        ///</summary>
        [TestMethod()]
        public void RecordTest()
        {
            target = new KeyIndexRecordPair<int, string, int, CCSLogRecord, string>();
            CCSLogRecord expected = ccs; // TODO: Initialize to an appropriate value
            CCSLogRecord actual;
            target.Record = expected;
            actual = target.Record;
            Assert.AreEqual(expected, actual);
        }
    }
}
