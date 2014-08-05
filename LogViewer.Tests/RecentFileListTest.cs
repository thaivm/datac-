using LogViewer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Controls;
using System.Windows;
using LogViewer.Model;
using System.Collections.Generic;
using System.IO;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for RecentFileListTest and is intended
    ///to contain all RecentFileListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RecentFileListTest
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
        ///A test for GetFilepath
        ///</summary>
        [TestMethod()]
        public void GetFilepathTest()
        {
            RecentFileList target = new RecentFileList();
            MenuItem menuItem = new MenuItem();
            target._RecentFiles = new List<RecentFileList.RecentFile>();
            string expected = string.Empty; 
            string actual;
            actual = target.GetFilepath(menuItem);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetMenuItemText
        ///</summary>
        [TestMethod()]
        public void GetMenuItemTextTest()
        {
            RecentFileList target = new RecentFileList();
            int index = 0;
            string filepath = string.Empty;
            string displaypath = string.Empty;
            string expected = "_0:  ";
            string actual;
            actual = target.GetMenuItemText(index, filepath, displaypath);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetRecentFile
        ///</summary>
        [TestMethod()]
        public void GetRecentFileTest()
        {
            RecentFileList obj = new RecentFileList();
            RecentFileAction expected = null;
            RecentFileAction actual;
            actual = RecentFileList.GetRecentFile(obj);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InsertFile
        ///</summary>
        [TestMethod()]
        public void InsertFileTest()
        {
            RecentFileList target = new RecentFileList();
            string filepath = "test";
            target.InsertFile(filepath);
            target.LoadRecentFiles();
            Assert.IsNotNull(target._RecentFiles.Count);
            target.RemoveFile(filepath);
        }

        /// <summary>
        ///A test for InsertMenuItems
        ///</summary>
        [TestMethod()]
        public void InsertMenuItemsRecentFilesNullTest()
        {
            RecentFileList target = new RecentFileList();
            target.InsertMenuItems();
            Assert.IsNull(target._RecentFiles);
        }

        /// <summary>
        ///A test for LoadRecentFilesCore
        ///</summary>
        [TestMethod()]
        public void LoadRecentFilesCoreTest()
        {
            RecentFileList target = new RecentFileList();
            List<RecentFileList.RecentFile> actual;
            actual = target.LoadRecentFilesCore();
            Assert.IsNotNull(actual.Count);
        }

        /// <summary>
        ///A test for MenuItem_Click
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void MenuItem_ClickTest()
        {
            RecentFileList target = new RecentFileList(); 
            object sender = null;
            EventArgs e = null;
            target.MenuItem_Click(sender, e);
        }

        /// <summary>
        ///A test for HandleAction
        ///</summary>
        [TestMethod()]
        public void HandleActionFilePathIsEmptyTest()
        {
            string filePath = "";
            RecentFileList target = new RecentFileList();
            target.RecentActionLoadCCS = new Action<string>((str) => { target.InsertFile(str); });
            target.HandleAction(filePath);
            Assert.IsNull(target._RecentFiles);    
        }
        [TestMethod()]
        public void HandleActionCaseUnKnowTest()
        {
            string filePath = "test.csv";
            RecentFileList target = new RecentFileList();
            target.RecentActionLoadCCS = new Action<string>((str) => { target.InsertFile(str); });
            target.HandleAction(filePath);
            Assert.IsNull(target._RecentFiles); 
            target.RemoveFile(filePath);
        }

        [TestMethod()]
        [DeploymentItem(@"CCS20131002.txt")]
        public void HandleActionCaseCCSTest()
        {
            string file = @"CCS20131002.txt";
            string filePath = Path.GetFullPath(file);
            RecentFileList target = new RecentFileList();
            target.RecentActionLoadCCS = new Action<string>((str) => { target.InsertFile(str); });
            target.HandleAction(filePath);
            Assert.AreEqual(filePath, target.RecentFiles[0]);
            target.RemoveFile(filePath);
        }

        [TestMethod()]
        [DeploymentItem(@"TestCXDIParser.log")]
        public void HandleActionCaseCXDITest()
        {
            string file = @"TestCXDIParser.log";
            string filePath = Path.GetFullPath(file);
            RecentFileList target = new RecentFileList();
            target.RecentActionLoadCXDI = new Action<string>((str) => { target.InsertFile(str); });
            target.HandleAction(filePath);
            Assert.AreEqual(filePath, target.RecentFiles[0]);
            target.RemoveFile(filePath);
        }

        [TestMethod()]
        [DeploymentItem(@"FileConfig\MemoCCS20140606153129.xml")]
        public void HandleActionCaseMemoCCSTest()
        {
            string file = @"MemoCCS20140606153129.xml";
            string filePath = Path.GetFullPath(file);
            RecentFileList target = new RecentFileList();
            target.RecentActionLoadCCS = new Action<string>((str) => { target.InsertFile(str); });
            target.HandleAction(filePath);
            Assert.AreEqual(filePath, target.RecentFiles[0]);
            target.RemoveFile(filePath);
        }

        [TestMethod()]
        [DeploymentItem(@"FileConfig\MemoCXDI20140606153152.xml")]
        public void HandleActionCaseMemoCXDITest()
        {
            string file = @"MemoCXDI20140606153152.xml";
            string filePath = Path.GetFullPath(file);
            RecentFileList target = new RecentFileList();
            target.RecentActionLoadCXDI = new Action<string>((str) => { target.InsertFile(str); });
            target.HandleAction(filePath);
            Assert.AreEqual(filePath, target.RecentFiles[0]);
            target.RemoveFile(filePath);
        }
        /// <summary>
        ///A test for RecentFilePropertyChanged
        ///</summary>
        [TestMethod()]
        public void RecentFilePropertyChangedTest()
        {
            RecentFileList o = new RecentFileList();
            RecentFileAction fileAction = new RecentFileAction("test", new Action<string>((str)=>{}), new Action<string>((str)=>{}));
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(RecentFileList.RecentFileProperty, null, fileAction);
            RecentFileList.RecentFilePropertyChanged(o, args);
            o.LoadRecentFiles();
            Assert.AreEqual("test", o._RecentFiles[0].Filepath);
        }

        /// <summary>
        ///A test for RemoveFile
        ///</summary>
        [TestMethod()]
        public void RemoveFileTest()
        {
            RecentFileList o = new RecentFileList();
            RecentFileAction fileAction = new RecentFileAction("test", new Action<string>((str) => { }), new Action<string>((str) => { }));
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(RecentFileList.RecentFileProperty, null, fileAction);
            RecentFileList.RecentFilePropertyChanged(o, args);
            o.RemoveFile("test");
            o.LoadRecentFiles();
            Assert.IsNotNull(o._RecentFiles.Count);
        }

        /// <summary>
        ///A test for RemoveMenuItems
        ///</summary>
        //[TestMethod()]
        //public void RemoveMenuItemsTest()
        //{
        //    RecentFileList target = new RecentFileList();
        //    target.RemoveMenuItems();
        //}

        ///// <summary>
        /////A test for SetMenuItems
        /////</summary>
        //[TestMethod()]
        //public void SetMenuItemsTest()
        //{
        //    RecentFileList target = new RecentFileList(); // TODO: Initialize to an appropriate value
        //    target.SetMenuItems();
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        /// <summary>
        ///A test for SetRecentFile
        ///</summary>
        [TestMethod()]
        public void SetRecentFileTest()
        {
            RecentFileList obj = new RecentFileList();
            RecentFileAction value = new RecentFileAction("test", new Action<string>((str) => { }), new Action<string>((str) => { }));
            RecentFileList.SetRecentFile(obj, value);
            RecentFileAction actual = (RecentFileAction)obj.GetValue(RecentFileList.RecentFileProperty);
            Assert.AreEqual(value.FilePath, actual.FilePath);
        }

        /// <summary>
        ///A test for ShortenPathname
        ///</summary>
        [TestMethod()]
        public void ShortenPathnameIsEmptyTest()
        {
            string pathname = string.Empty;
            int maxLength = 0;
            string expected = string.Empty;
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ShortenPathnameIsNotEmptyTest()
        {
            string pathname = "c:\\abc\\test.xml";
            int maxLength = 0;
            string expected = "c:\\...\\tes...";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShortenLengthPathnameMoreThan3Test()
        {
            string pathname = "cd:\\abc\\test.xml";
            int maxLength = 0;
            string expected = "...\\tes...";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ShortenLengthElementEqua1Test()
        {
            string pathname = "test.xml";
            int maxLength = 0;
            string expected = "tes...";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ShortenLengthElementEqua1LessThanMaxLengthTest()
        {
            string pathname = "test.xml";
            int maxLength = 50;
            string expected = "test.xml";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ShortenLengthElementEqua2MoreThanMaxLengthTest()
        {
            string pathname = "puckingabcaaa\\test.xml";
            int maxLength = 13;
            string expected = "...\\test.xml";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShortenLengthElementEqua2LessThanMaxLengthTest()
        {
            string pathname = "puck\\test.xml";
            int maxLength = 11;
            string expected = "...\\test...";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShortenLengthElementEqua2LessThanMaxLengthRootLessThan6Test()
        {
            string pathname = "pucka\\a.xml";
            int maxLength = 8;
            string expected = "...\\a.xml";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ShortenLengthElementMoreThan2Test()
        {
            string pathname = "abasdasdasdcd\\pucka\\a.xml";
            int maxLength = 20;
            string expected = "...\\pucka\\a.xml";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShortenLengthElementMoreThan2TotalLengthMoreThanMaxLengthTest()
        {
            string pathname = "sdasdasdasdasdasdasdasdcd\\aaaaaapucka\\a.xml";
            int maxLength = 20;
            string expected = "...\\a.xml";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShortenLengthElementMoreThan2TotalLengthMoreThanMaxLengthBeginMoreThan0Test()
        {
            string pathname = "aaa\\sdasdasdasdasdasdasdasdcd\\aaaaaapucka\\a.xml";
            int maxLength = 20;
            string expected = "...\\a.xml";
            string actual;
            actual = RecentFileList.ShortenPathname(pathname, maxLength);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _FileMenu_SubmenuOpened
        ///</summary>
        //[TestMethod()]
        //public void _FileMenu_SubmenuOpenedTest()
        //{
        //    RecentFileList target = new RecentFileList();
        //    object sender = null;
        //    RoutedEventArgs e = null;
        //    target._FileMenu_SubmenuOpened(sender, e);
        //}

        /// <summary>
        ///A test for FileMenu
        ///</summary>
        [TestMethod()]
        public void FileMenuTest()
        {
            RecentFileList target = new RecentFileList();
            MenuItem expected = null;
            MenuItem actual;
            target.FileMenu = expected;
            actual = target.FileMenu;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetMenuItemTextHandler
        ///</summary>
        [TestMethod()]
        public void GetMenuItemTextHandlerTest()
        {
            RecentFileList target = new RecentFileList();
            RecentFileList.GetMenuItemTextDelegate expected = null;
            RecentFileList.GetMenuItemTextDelegate actual;
            target.GetMenuItemTextHandler = expected;
            actual = target.GetMenuItemTextHandler;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MaxNumberOfFiles
        ///</summary>
        [TestMethod()]
        public void MaxNumberOfFilesTest()
        {
            RecentFileList target = new RecentFileList(); 
            int expected = 0;
            int actual;
            target.MaxNumberOfFiles = expected;
            actual = target.MaxNumberOfFiles;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MaxPathLength
        ///</summary>
        [TestMethod()]
        public void MaxPathLengthTest()
        {
            RecentFileList target = new RecentFileList(); 
            int expected = 0;
            int actual;
            target.MaxPathLength = expected;
            actual = target.MaxPathLength;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MenuItemFormatOneToNine
        ///</summary>
        [TestMethod()]
        public void MenuItemFormatOneToNineTest()
        {
            RecentFileList target = new RecentFileList();
            string expected = string.Empty;
            string actual;
            target.MenuItemFormatOneToNine = expected;
            actual = target.MenuItemFormatOneToNine;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MenuItemFormatTenPlus
        ///</summary>
        [TestMethod()]
        public void MenuItemFormatTenPlusTest()
        {
            RecentFileList target = new RecentFileList();
            string expected = string.Empty;
            string actual;
            target.MenuItemFormatTenPlus = expected;
            actual = target.MenuItemFormatTenPlus;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Persister
        ///</summary>
        [TestMethod()]
        public void PersisterTest()
        {
            RecentFileList target = new RecentFileList();
            RecentFileList.IPersist expected = null;
            RecentFileList.IPersist actual;
            target.Persister = expected;
            actual = target.Persister;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RecentFiles
        ///</summary>
        [TestMethod()]
        public void RecentFilesTest()
        {
            RecentFileList target = new RecentFileList();
            List<string> actual;
            target.InsertFile("test");
            actual = target.RecentFiles;
            Assert.AreEqual("test", actual[0]);
            target.RemoveFile("test");
        }
    }
}
