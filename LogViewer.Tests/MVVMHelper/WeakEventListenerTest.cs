using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Windows.Controls;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for WeakEventListenerTest and is intended
    ///to contain all WeakEventListenerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WeakEventListenerTest
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
        ///A test for contructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contructorest()
        {
            WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs> target = new WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>(null, null);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contructorest1()
        {
            WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs> target = new WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>(new DataGridDragDropBehavior(), null);
        }
        [TestMethod()]
        public void Contructorest2()
        {
            WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs> target = new WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>(new DataGridDragDropBehavior(), new DataGrid());
        }

        /// <summary>
        ///A test for Detach
        ///</summary>
        [TestMethod()]
        public void DetachTest2()
        {
            WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs> target = new WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>(new DataGridDragDropBehavior(), new DataGrid());
            target.OnDetachAction = new Action<WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>, DataGrid>((x,y) => { });
            target.Detach();
            Assert.IsNull(target.OnDetachAction);
        }
        /// <summary>
        ///A test for OnEvent
        ///</summary>
        [TestMethod()]
        public void OnEventTest()
        {
            WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs> target = new WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>(new DataGridDragDropBehavior(), new DataGrid());
            object source1 = null;
            target.OnEventAction = new Action<DataGridDragDropBehavior, object, DragEventArgs>((x,y,z) => { });
            target.OnEvent(source1, null);
        }
        [TestMethod()]
        public void OnEventTest1()
        {
            WeakEventListener_Accessor<DataGridDragDropBehavior, DataGrid, DragEventArgs> target = new WeakEventListener_Accessor<DataGridDragDropBehavior, DataGrid, DragEventArgs>(new DataGridDragDropBehavior(), new DataGrid());
            object source1 = null;
            target.OnEventAction = new Action<DataGridDragDropBehavior, object, DragEventArgs>((x, y, z) => { });
            target._weakInstance.Target = null;
            target.OnEvent(source1, null);
        }
        /// <summary>
        ///A test for OnDetachAction
        ///</summary>
        [TestMethod()]
        public void OnDetachActionTest()
        {
            WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs> target = new WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>(new DataGridDragDropBehavior(), new DataGrid());
            target.OnDetachAction = null;
            var actual = target.OnDetachAction;
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        ///A test for OnEventAction
        ///</summary>
        [TestMethod()]
        public void OnEventActionTest()
        {
            WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs> target = new WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>(new DataGridDragDropBehavior(), new DataGrid());
            target.OnEventAction = null;
            var actual = target.OnEventAction;
            Assert.AreEqual(null, actual);
        }
    }
}
