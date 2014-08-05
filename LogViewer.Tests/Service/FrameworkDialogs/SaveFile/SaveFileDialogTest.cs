using LogViewer.Service.FrameworkDialogs.SaveFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using LogViewer.Service.FrameworkDialogs;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SaveFileDialogTest and is intended
    ///to contain all SaveFileDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SaveFileDialogTest
    {
        public static SaveFileDialog_Accessor target;

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
        ///A test for SaveFileDialog Constructor
        ///</summary>
        [TestMethod()]
        [TestInitialize()]
        public void SaveFileDialogConstructorTest()
        {
            SaveFileDialogViewModel dlgVM = new SaveFileDialogViewModel();
            target = new SaveFileDialog_Accessor(dlgVM);
        }

        /// <summary>
        ///A test for Dispose - disposing is false
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingFalseTest()
        {
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.concreteSaveFileDialog = new Microsoft.Win32.SaveFileDialog();
            target.Dispose(disposing);
            Assert.IsNotNull(target.concreteSaveFileDialog);
        }

        /// <summary>
        ///A test for Dispose - disposing is true - concreteSaveFileDialog is not null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_concreteSaveFileDialogNotNullTest()
        {
            bool disposing = true; // TODO: Initialize to an appropriate value
            target.concreteSaveFileDialog = new Microsoft.Win32.SaveFileDialog();
            target.Dispose(disposing);
            Assert.IsNull(target.concreteSaveFileDialog);
        }

        /// <summary>
        ///A test for Dispose - disposing is true - concreteSaveFileDialog is  null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_concreteSaveFileDialogNullTest()
        {
            bool disposing = true; // TODO: Initialize to an appropriate value
            target.concreteSaveFileDialog = null;
            target.Dispose(disposing);
            Assert.IsNull(target.concreteSaveFileDialog);
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            target.Dispose();
            Assert.IsNull(target.concreteSaveFileDialog);
        }

        /// <summary>
        ///A test for Finalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void FinalizeTest()
        {
            target.concreteSaveFileDialog = new Microsoft.Win32.SaveFileDialog();
            target.Finalize();
            Assert.IsNotNull(target.concreteSaveFileDialog);
        }

        /// <summary>
        ///A test for ShowDialog
        ///
        ///Input:
        ///Click Cancel button
        ///
        ///Ouput
        ///return false
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void ShowDialog_FalseTest()
        //{
        //    target.concreteSaveFileDialog.Title = "Click Cancel button";
        //    IWin32Window owner = new WindowWrapper(new System.Windows.Window());
        //    Assert.IsFalse((bool)target.ShowDialog(owner));
        //}

        /// <summary>
        ///A test for ShowDialog
        ///
        ///Input:
        ///Select file and click OK button
        ///
        ///Ouput
        ///return true
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void ShowDialog_TrueTest()
        //{
        //    target.concreteSaveFileDialog.Title = "Select file and click OK button";
        //    IWin32Window owner = new WindowWrapper(new System.Windows.Window());
        //    Assert.IsNotNull((bool)target.ShowDialog(owner));
        //}
    }
}
