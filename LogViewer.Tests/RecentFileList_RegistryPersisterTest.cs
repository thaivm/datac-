using LogViewer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace LogViewer.Tests
{


    /// <summary>
    ///This is a test class for RecentFileList_RegistryPersisterTest and is intended
    ///to contain all RecentFileList_RegistryPersisterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RecentFileList_RegistryPersisterTest
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
        ///A test for InsertFile
        ///</summary>
        [TestMethod()]
        public void InsertFileTest()
        {
            RecentFileList o = new RecentFileList();
            o.InsertFile("test");
            o.InsertFile("test1");
            o.InsertFile("test2");
            RecentFileList.RegistryPersister target = new RecentFileList.RegistryPersister();
            string filepath = "test";
            int max = 10;
            target.InsertFile(filepath, max);
            RegistryKey k = Registry.CurrentUser.OpenSubKey(target.RegistryKey);
            string actual = (string)k.GetValue("00");
            Assert.AreEqual(filepath, actual);
            o.RemoveFile("test");
            o.RemoveFile("test1");
            o.RemoveFile("test2");
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            RecentFileList.RegistryPersister target = new RecentFileList.RegistryPersister();
            int i = 0;
            string expected = string.Empty;
            string actual;
            actual = target.Key(i);
            Assert.AreEqual("00", actual);
        }

        /// <summary>
        ///A test for RecentFiles
        ///</summary>
        [TestMethod()]
        public void RecentFilesTest()
        {
            RecentFileList.RegistryPersister target = new RecentFileList.RegistryPersister();
            int max = 0;
            List<string> actual;
            actual = target.RecentFiles(max);
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for RemoveFile
        ///</summary>
        [TestMethod()]
        public void RemoveFileTest()
        {
            RecentFileList o = new RecentFileList();
            o.InsertFile("test");
            o.InsertFile("test1");
            o.InsertFile("test2");
            RecentFileList.RegistryPersister target = new RecentFileList.RegistryPersister();
            string filepath = "test";
            int max = 10;
            o.RemoveFile("test");
            target.InsertFile(filepath, max);
            RegistryKey k = Registry.CurrentUser.OpenSubKey(target.RegistryKey);
            target.RemoveFile(0, 10);
            List<string> actual = target.RecentFiles(max);
            Assert.AreEqual("test2", actual[0]);
            o.RemoveFile("test1");
            o.RemoveFile("test2");
        }

        /// <summary>
        ///A test for RemoveFile
        ///</summary>
        [TestMethod()]
        public void RemoveFileTest1()
        {
            RecentFileList o = new RecentFileList();
            o.InsertFile("test");
            o.InsertFile("test1");
            o.InsertFile("test2");
            RecentFileList.RegistryPersister target = new RecentFileList.RegistryPersister();
            string filepath = "test";
            int max = 10;
            o.RemoveFile("test");
            target.InsertFile(filepath, max);
            RegistryKey k = Registry.CurrentUser.OpenSubKey(target.RegistryKey);
            target.RemoveFile("test", 10);
            List<string> actual = target.RecentFiles(max);
            Assert.AreEqual("test2", actual[0]);
            o.RemoveFile("test1");
            o.RemoveFile("test2");
        }

        /// <summary>
        ///A test for RegistryKey
        ///</summary>
        [TestMethod()]
        public void RegistryKeyTest()
        {
            RecentFileList.RegistryPersister target = new RecentFileList.RegistryPersister();
            string expected = string.Empty;
            string actual;
            target.RegistryKey = expected;
            actual = target.RegistryKey;
            Assert.AreEqual(expected, actual);
        }
    }
}
