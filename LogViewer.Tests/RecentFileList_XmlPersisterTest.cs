using LogViewer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for RecentFileList_XmlPersisterTest and is intended
    ///to contain all RecentFileList_XmlPersisterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RecentFileList_XmlPersisterTest
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
        ///A test for CopyExcluding
        ///</summary>
        [TestMethod()]
        public void CopyExcludingTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            //target.Filepath = "test.xml";
            int max = 10;
            List<string> source = target.Load(max);
            string exclude = "test";
            List<string> target1 = new List<string>(source.Count + 1); ;
            target.CopyExcluding(source, exclude, target1, max);
            Assert.IsNotNull(target1.Count);
        }

        /// <summary>
        ///A test for InsertFile
        ///</summary>
        [TestMethod()]
        public void InsertFileTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            //target.Filepath = "test.xml";
            int max = 10;
            target.InsertFile("test", max);
            target.InsertFile("test1", max);
            List<string> actual = target.Load(max);
            Assert.AreEqual("test1", actual[0]);
            target.RemoveFile("test", max);
            target.RemoveFile("test2", max);
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod()]
        public void LoadTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            //target.Filepath = "test.xml";
            int max = 10;
            target.InsertFile("test", max);
            List<string> actual = target.Load(max);
            Assert.AreEqual("test", actual[0]);
            target.RemoveFile("test", max);
        }

        ///// <summary>
        /////A test for OpenStream
        /////</summary>
        //[TestMethod()]
        //public void OpenStreamTest()
        //{
        //    RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
        //    //target.Filepath = "test.xml";

        //    FileMode mode = FileMode.OpenOrCreate;
        //    var actual = target.OpenStream(mode);
        //    Assert.IsInstanceOfType(actual, typeof(RecentFileList.XmlPersister.SmartStream));

        //}

        /// <summary>
        ///A test for RecentFiles
        ///</summary>
        [TestMethod()]
        public void RecentFilesTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            int max = 10;
            List<string> actual;
            actual = target.RecentFiles(max);
            Assert.IsNotNull(actual.Count);
        }

        /// <summary>
        ///A test for RemoveFile
        ///</summary>
        [TestMethod()]
        public void RemoveFileTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            //target.Filepath = "test.xml";
            string filepath = "test";
            int max = 10;
            target.InsertFile(filepath, max);
            target.RemoveFile(filepath, max);
            List<string> actual = target.Load(max);
            Assert.IsNotNull(actual.Count);
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            //target.Filepath = "test.xml";
            List<string> list = new List<string>() { "test" };
            int max = 10;
            target.Save(list, max);
            List<string> actual = target.Load(max);
            Assert.AreEqual(1, actual.Count);
            target.RemoveFile("test", max);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            //target.Filepath = "test.xml";
            string filepath = "test"; 
            bool insert = true;
            int max = 10;
            target.Update(filepath, insert, max);
            List<string> actual = target.Load(max);
            Assert.AreEqual(1, actual.Count);
            target.RemoveFile(filepath, max);
        }

        /// <summary>
        ///A test for Filepath
        ///</summary>
        [TestMethod()]
        public void FilepathTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            string expected = string.Empty;
            string actual;
            target.Filepath = expected;
            actual = target.Filepath;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Stream
        ///</summary>
        [TestMethod()]
        public void StreamTest()
        {
            RecentFileList.XmlPersister target = new RecentFileList.XmlPersister();
            Stream expected = null;
            Stream actual;
            target.Stream = expected;
            actual = target.Stream;
            Assert.AreEqual(expected, actual);
        }
    }
}
