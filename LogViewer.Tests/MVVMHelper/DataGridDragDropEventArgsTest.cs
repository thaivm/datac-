using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for DataGridDragDropEventArgsTest and is intended
    ///to contain all DataGridDragDropEventArgsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataGridDragDropEventArgsTest
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
        ///A test for Effects
        ///</summary>
        [TestMethod()]
        public void EffectsTest()
        {
            DataGridDragDropEventArgs target = new DataGridDragDropEventArgs(); 
            DragDropEffects expected = new DragDropEffects(); 
            DragDropEffects actual;
            target.Effects = expected;
            actual = target.Effects;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Source
        ///</summary>
        [TestMethod()]
        public void SourceTest()
        {
            DataGridDragDropEventArgs target = new DataGridDragDropEventArgs(); 
            string expected = string.Empty; 
            string actual;
            target.Source = expected;
            actual = target.Source;
            Assert.AreEqual(expected, actual);
        }
    }
}
