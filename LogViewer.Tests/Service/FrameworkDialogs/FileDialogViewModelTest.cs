using LogViewer.Service.FrameworkDialogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Service.FrameworkDialogs.OpenFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for FileDialogViewModelTest and is intended
    ///to contain all FileDialogViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FileDialogViewModelTest
    {
        public static FileDialogViewModel target;

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
        ///Init
        ///</summary>
        [TestInitialize()]
        public void Init_FileDialogViewModel()
        {
            target = new OpenFileDialogViewModel();
        }
        
        /// <summary>
        ///A test for AddExtension
        ///</summary>
        [TestMethod()]
        public void AddExtensionTest()
        {
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.AddExtension = expected;
            actual = target.AddExtension;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CheckFileExists
        ///</summary>
        [TestMethod()]
        public void CheckFileExistsTest()
        {
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            target.CheckFileExists = expected;
            actual = target.CheckFileExists;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CheckPathExists
        ///</summary>
        [TestMethod()]
        public void CheckPathExistsTest()
        {
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.CheckPathExists = expected;
            actual = target.CheckPathExists;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DefaultExt
        ///</summary>
        [TestMethod()]
        public void DefaultExtTest()
        {
            string expected = "Default"; // TODO: Initialize to an appropriate value
            string actual;
            target.DefaultExt = expected;
            actual = target.DefaultExt;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        [TestMethod()]
        public void FileNameTest()
        {
            string expected = "file name"; // TODO: Initialize to an appropriate value
            string actual;
            target.FileName = expected;
            actual = target.FileName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FileNames
        ///</summary>
        [TestMethod()]
        public void FileNamesTest()
        {
            string[] expected = new string[]{"file1", "file2"}; // TODO: Initialize to an appropriate value
            string[] actual;
            target.FileNames = expected;
            actual = target.FileNames;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Filter
        ///</summary>
        [TestMethod()]
        public void FilterTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Filter = expected;
            actual = target.Filter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InitialDirectory
        ///</summary>
        [TestMethod()]
        public void InitialDirectoryTest()
        {
            string expected = "InitialDirectory"; // TODO: Initialize to an appropriate value
            string actual;
            target.InitialDirectory = expected;
            actual = target.InitialDirectory;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Title
        ///</summary>
        [TestMethod()]
        public void TitleTest()
        {
            string expected = "Title"; // TODO: Initialize to an appropriate value
            string actual;
            target.Title = expected;
            actual = target.Title;
            Assert.AreEqual(expected, actual);
        }
    }
}
