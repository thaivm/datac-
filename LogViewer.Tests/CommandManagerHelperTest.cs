using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CommandManagerHelperTest and is intended
    ///to contain all CommandManagerHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandManagerHelperTest
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
        ///A test for AddHandlersToRequerySuggested
        ///</summary>
        [TestMethod()]
        public void AddHandlersToRequerySuggestedHandlersIsNullTest()
        {
            List<WeakReference> handlers = null; 
            CommandManagerHelper.AddHandlersToRequerySuggested(handlers);
        }
        [TestMethod()]
        public void AddHandlersToRequerySuggestedHandlersIsNotNullTest()
        {
            List<WeakReference> handlers = new List<WeakReference>();
            CommandManagerHelper.AddHandlersToRequerySuggested(handlers);
        }
        [TestMethod()]
        public void AddHandlersToRequerySuggestedHandlersIsNotEmptyTest()
        {
            List<WeakReference> handlers = new List<WeakReference>();
            EventHandler e = new EventHandler((obj, ev) => { });
            WeakReference weak = new WeakReference(e);
            handlers.Add(weak);
            CommandManagerHelper.AddHandlersToRequerySuggested(handlers);
        }
        /// <summary>
        ///A test for CallWeakReferenceHandlers
        ///</summary>
        [TestMethod()]
        public void CallWeakReferenceHandlersHandlersIsNullTest()
        {
            List<WeakReference> handlers = null;
            CommandManagerHelper.CallWeakReferenceHandlers(handlers);
        }
        [TestMethod()]
        public void CallWeakReferenceHandlersHandlersIsNotNullTest()
        {
            List<WeakReference> handlers = new List<WeakReference>();
            CommandManagerHelper.CallWeakReferenceHandlers(handlers);
        }
        [TestMethod()]
        public void CallWeakReferenceHandlersHandlersIsNotEmptyTest()
        {
            List<WeakReference> handlers = new List<WeakReference>();
            EventHandler e = new EventHandler((obj, ev) => { });
            WeakReference weak = new WeakReference(e);
            handlers.Add(weak);
            CommandManagerHelper.CallWeakReferenceHandlers(handlers);
        }
        [TestMethod()]
        public void CallWeakReferenceHandlersHandlersIsNotEmptyHandlerIsNullTest()
        {
            List<WeakReference> handlers = new List<WeakReference>();
            //EventHandler e = new EventHandler((obj, ev) => { });
            EventHandler e = null;
            WeakReference weak = new WeakReference(e);
            handlers.Add(weak);
            CommandManagerHelper.CallWeakReferenceHandlers(handlers);
        }
        /// <summary>
        ///A test for RemoveHandlersFromRequerySuggested
        ///</summary>
        [TestMethod()]
        public void RemoveHandlersFromRequerySuggestedHandlersIsNullTest()
        {
            List<WeakReference> handlers = null;
            CommandManagerHelper.RemoveHandlersFromRequerySuggested(handlers);
        }
        [TestMethod()]
        public void RemoveHandlersFromRequerySuggestedHandlersIsNotNullTest()
        {
            List<WeakReference> handlers = new List<WeakReference>();
            CommandManagerHelper.RemoveHandlersFromRequerySuggested(handlers);
        }
        [TestMethod()]
        public void RemoveHandlersFromRequerySuggestedHandlersIsNotEmptyTest()
        {
            List<WeakReference> handlers = new List<WeakReference>();
            EventHandler e = new EventHandler((obj, ev) => { });
            WeakReference weak = new WeakReference(e);
            handlers.Add(weak);
            CommandManagerHelper.RemoveHandlersFromRequerySuggested(handlers);
        }

    }
}
