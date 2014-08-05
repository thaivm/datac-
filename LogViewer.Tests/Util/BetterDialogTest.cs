using LogViewer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BetterDialogTest and is intended
    ///to contain all BetterDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BetterDialogTest
    {
        public static BetterDialog_Accessor target;

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
        [TestMethod()]
        [TestInitialize()]
        [DeploymentItem("LogViewer.exe")]
        public void Init_BetterDialogTest()
        {
            string title = "Confirm"; // TODO: Initialize to an appropriate value
            string largeHeading = "Are you sure yo want to delete?"; // TODO: Initialize to an appropriate value
            string smallExplanation = string.Empty; // TODO: Initialize to an appropriate value
            string leftButton = "OK"; // TODO: Initialize to an appropriate value
            string rightButton = "Cancel"; // TODO: Initialize to an appropriate value
            Image iconSet = null; // TODO: Initialize to an appropriate value
            target = new BetterDialog_Accessor(title, largeHeading, smallExplanation, leftButton, rightButton, iconSet);
        }

        /// <summary>
        ///BetterDialogContructor - left button is empty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BetterDialogContructor_LeftButtonEmptyTest()
        {
            string title = "Confirm"; // TODO: Initialize to an appropriate value
            string largeHeading = "Are you sure yo want to delete?"; // TODO: Initialize to an appropriate value
            string smallExplanation = string.Empty; // TODO: Initialize to an appropriate value
            string leftButton = string.Empty; // TODO: Initialize to an appropriate value
            string rightButton = "Cancel"; // TODO: Initialize to an appropriate value
            Image iconSet = null; // TODO: Initialize to an appropriate value
            target = new BetterDialog_Accessor(title, largeHeading, smallExplanation, leftButton, rightButton, iconSet);
        }

        /// <summary>
        ///BetterDialogContructor - this.Width < 260
        ///</summary>
     //   [TestMethod()]
     //   [DeploymentItem("LogViewer.exe")]
     //   public void BetterDialogContructor_WidthLess260Test()
     //   {
     //       string title = "Confirm"; // TODO: Initialize to an appropriate value
     //       string largeHeading = "Are you sure yo want to delete?"; // TODO: Initialize to an appropriate value
     //       string smallExplanation = string.Empty; // TODO: Initialize to an appropriate value
     //       string leftButton = "OK"; // TODO: Initialize to an appropriate value
     //       string rightButton = "Cancel"; // TODO: Initialize to an appropriate value
     //       //target = new BetterDialog_Accessor(title, largeHeading, smallExplanation, leftButton, rightButton, null);
     //       //PrivateObject param0 = new PrivateObject(typeof(BetterDialog));
     //       //param0.SetFieldOrProperty("Width", 250);
     //       //param0.Invoke("BetterDialog", title, largeHeading, smallExplanation, leftButton, rightButton, null);
     ////       BetterDialog dlg = new BetterDialog(title, largeHeading, smallExplanation, leftButton, rightButton, null);
     //  //     dlg.Width = 250;
     //    //   dlg = new BetterDialog(title, largeHeading, smallExplanation, leftButton, rightButton, null);
     //   }

        /// <summary>
        ///A test for Dispose - disposing is true and components is not null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingTrue_componentsNotNullTest()
        {
            //init value
            bool disposing = true; // TODO: Initialize to an appropriate value
            var a = new Container();
            a.Add(new Component(), "Test");
            target.components = a;

            //result
            target.Dispose(disposing);
            Assert.AreEqual(0, target.components.Components.Count);
        }

        /// <summary>
        ///A test for Dispose - disposing is false and components is not null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingFalse_componentsNotNullTest()
        {
            //init value
            bool disposing = false; // TODO: Initialize to an appropriate value
            var a = new Container();
            a.Add(new Component(), "Test");
            target.components = a;

            //result
            target.Dispose(disposing);
            Assert.AreEqual(1, target.components.Components.Count);
        }

        /// <summary>
        ///A test for Dispose - disposing is true and components is null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingTrue_componentsNullTest()
        {
            //init value
            bool disposing = true; // TODO: Initialize to an appropriate value
            target.components = null;

            //result
            target.Dispose(disposing);
            Assert.IsNull(target.components);
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitializeComponentTest()
        {
            target.InitializeComponent();
        }




    }
}
