using LogViewer.Service.FrameworkDialogs.OpenFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using LogViewer.Service.FrameworkDialogs;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for OpenFileDialogTest and is intended
    ///to contain all OpenFileDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OpenFileDialogTest
    {
        public static OpenFileDialog_Accessor target;

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
        public void Init_OpenFileDialog()
        {
            IOpenFileDialog openFileDialog = new OpenFileDialogViewModel(); 
            target = new OpenFileDialog_Accessor(openFileDialog);
        }

        /// <summary>
        ///A test for OpenFileDialog Constructor
        ///</summary>
        [TestMethod()]
        public void OpenFileDialogConstructorTest()
        {
            Assert.IsNotNull(target.concreteOpenFileDialog);
        }

        /// <summary>
        ///A test for Dispose
        ///
        ///Input:
        ///disposing = false
        ///concreteOpenFileDialog = new System.Windows.Forms.OpenFileDialog()
        ///
        ///Output:
        ///concreteOpenFileDialog != null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingFalse_concreteOpenFileDialogNotNullTest()
        {
            bool disposing = false;
            target.concreteOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            target.Dispose(disposing);
            Assert.IsNotNull(target.concreteOpenFileDialog);
        }

        /// <summary>
        ///A test for Dispose
        ///
        ///Input:
        ///disposing = true
        ///concreteOpenFileDialog = null
        ///
        ///Output:
        ///concreteOpenFileDialog = null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingTrue_concreteOpenFileDialogNullTest()
        {
            bool disposing = true;
            target.concreteOpenFileDialog = null;
            target.Dispose(disposing);
            Assert.IsNull(target.concreteOpenFileDialog);
        }

        /// <summary>
        ///A test for Dispose
        ///
        ///Input:
        ///disposing = true
        ///concreteOpenFileDialog = new System.Windows.Forms.OpenFileDialog()
        ///
        ///Output:
        ///concreteOpenFileDialog = null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingTrue_concreteOpenFileDialogNotNullTest()
        {
            bool disposing = true;
            target.concreteOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            target.Dispose(disposing);
            Assert.IsNull(target.concreteOpenFileDialog);
        }

        /// <summary>
        ///A test for Dispose
        ///
        ///Input:
        ///concreteOpenFileDialog = new System.Windows.Forms.OpenFileDialog()
        ///
        ///Output:
        ///concreteOpenFileDialog = null
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            target.concreteOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            target.Dispose();
            Assert.IsNull(target.concreteOpenFileDialog);
        }

        /// <summary>
        ///A test for Finalize
        ///
        ///Input:
        ///concreteOpenFileDialog = new System.Windows.Forms.OpenFileDialog()
        ///
        ///Output:
        ///concreteOpenFileDialog != null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void FinalizeTest()
        {
            target.concreteOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            target.Finalize();
            Assert.IsNotNull(target.concreteOpenFileDialog);
        }

        /// <summary>
        ///A test for ShowDialog
        ///
        ///Input:
        ///Select and click OK button
        ///
        ///Output:
        ///DialogResult.OK
        ///</summary>
        //[TestMethod()]
        //public void ShowDialog_OKTest()
        //{
        //    target.concreteOpenFileDialog.Title = "Select and click OK button";
        //    IWin32Window owner = new WindowWrapper(new Window());
        //    Assert.IsNotNull(target.ShowDialog(owner));
        //}

        /// <summary>
        ///A test for ShowDialog
        ///
        ///Input:
        ///Click Cancel button
        ///
        ///Output:
        ///DialogResult.Cancel
        ///</summary>
        //[TestMethod()]
        //public void ShowDialog_CancelTest()
        //{
        //    target.concreteOpenFileDialog.Title = "Click Cancel button";
        //    IWin32Window owner = new WindowWrapper(new Window());
        //    Assert.AreEqual(DialogResult.Cancel, target.ShowDialog(owner));
        //}
    }
}
