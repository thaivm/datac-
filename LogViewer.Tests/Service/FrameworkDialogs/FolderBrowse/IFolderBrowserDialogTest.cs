using LogViewer.Service.FrameworkDialogs.FolderBrowse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for IFolderBrowserDialogTest and is intended
    ///to contain all IFolderBrowserDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IFolderBrowserDialogTest
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
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            IFolderBrowserDialog target = new FolderBrowserDialogViewModel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectedPath
        ///</summary>
        [TestMethod()]
        public void SelectedPathTest()
        {
            IFolderBrowserDialog target = new FolderBrowserDialogViewModel(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.SelectedPath = expected;
            actual = target.SelectedPath;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ShowNewFolderButton
        ///</summary>
        [TestMethod()]
        public void ShowNewFolderButtonTest()
        {
            IFolderBrowserDialog target = new FolderBrowserDialogViewModel(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ShowNewFolderButton = expected;
            actual = target.ShowNewFolderButton;
            Assert.AreEqual(expected, actual);
        }
    }
}
