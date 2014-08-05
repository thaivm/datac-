using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using LogViewer.Model;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ItemsControlExtensionsTest and is intended
    ///to contain all ItemsControlExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ItemsControlExtensionsTest
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
        ///A test for CenteringOffset
        ///</summary>
        [TestMethod()]
        public void CenteringOffsetTest()
        {
            double center = 0F; 
            double viewport = 0F; 
            double extent = 0F; 
            double expected = 0F; 
            double actual;
            actual = ItemsControlExtensions_Accessor.CenteringOffset(center, viewport, extent);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FirstVisualChild
        ///</summary>
        [TestMethod()]
        public void FirstVisualChildTest()
        {
            Visual visual = null; 
            DependencyObject expected = null; 
            DependencyObject actual;
            actual = ItemsControlExtensions_Accessor.FirstVisualChild(visual);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ScrollToCenterOfView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ScrollToCenterOfViewTest()
        {
            ItemsControl itemsControl = null; 
            object item = null; 
            ItemsControlExtensions.ScrollToCenterOfView(itemsControl, item);
        }

        /// <summary>
        ///A test for TryScrollToCenterOfView
        ///</summary>
        [TestMethod()]
        public void TryScrollToCenterOfViewTest()
        {
            List<CCSLogRecord> list = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.Line = 1;
            record.Id = "1";
            CCSLogRecord record1 = new CCSLogRecord();
            record1.Line = 2;
            record1.Id = "2";
            list.Add(record);
            list.Add(record1);
            DataGrid itemsControl = new DataGrid();
            itemsControl.ItemsSource = list;
            bool expected = false;
            bool actual;
            actual = ItemsControlExtensions_Accessor.TryScrollToCenterOfView(itemsControl, record);
            Assert.AreEqual(expected, actual);
        }
    }
}
