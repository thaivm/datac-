using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using Microsoft.Windows.Controls;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for DataGridDragDropBehaviorTest and is intended
    ///to contain all DataGridDragDropBehaviorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataGridDragDropBehaviorTest
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
        ///A test for AllowedEffects
        ///</summary>
        [TestMethod()]
        public void AllowedEffectsTest()
        {
            DataGridDragDropBehavior target = new DataGridDragDropBehavior();
            DragDropEffects expected = new DragDropEffects();
            DragDropEffects actual;
            target.AllowedEffects = expected;
            actual = target.AllowedEffects;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Command
        ///</summary>
        [TestMethod()]
        public void CommandTest()
        {
            DataGridDragDropBehavior target = new DataGridDragDropBehavior();
            DelegateCommand<DataGridDragDropEventArgs> expected = null;
            DelegateCommand<DataGridDragDropEventArgs> actual;
            target.Command = expected;
            actual = target.Command;
            Assert.AreEqual(expected, actual);
        }
    }
}
