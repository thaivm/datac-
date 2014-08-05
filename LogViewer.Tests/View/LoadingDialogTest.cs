using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Markup;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Input;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for LoadingDialogTest and is intended
    ///to contain all LoadingDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoadingDialogTest
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
        ///A test for LoadingDialog Constructor
        ///</summary>
        [TestMethod()]
        public void LoadingDialogConstructorTest()
        {
            LoadingDialog target = new LoadingDialog();
        }

        /// <summary>
        ///A test for InitializeComponent - _contentLoaded = true
        ///</summary>
        [TestMethod()]
        public void InitializeComponent_TrueTest()
        {
            LoadingDialog target = new LoadingDialog();
            PrivateObject param = new PrivateObject(target);
            param.SetFieldOrProperty("_contentLoaded", true);
            target.InitializeComponent();
            var result = (bool) param.GetFieldOrProperty("_contentLoaded");
            Assert.IsTrue(result);
        }

        /// <summary>
        ///A test for InitializeComponent - _contentLoaded = false
        ///</summary>
        [TestMethod()]
        public void InitializeComponent_FalseTest()
        {
            LoadingDialog target = new LoadingDialog();
            PrivateObject param = new PrivateObject(target);
            param.SetFieldOrProperty("_contentLoaded", false);
            target.InitializeComponent();
            var result = (bool)param.GetFieldOrProperty("_contentLoaded");
            Assert.IsTrue(result);
        }

        /// <summary>
        ///A test for OnSourceInitialized - PresentationSource.FromVisual(target) is null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void OnSourceInitialized_NullTest()
        {
            LoadingDialog_Accessor target = new LoadingDialog_Accessor();
            EventArgs e = null; 
            target.OnSourceInitialized(e);
        }

        /// <summary>
        ///A test for System.Windows.Markup.IComponentConnector.Connect
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ConnectTest()
        {
            IComponentConnector target = new LoadingDialog();
            PrivateObject param = new PrivateObject(target);
            param.SetFieldOrProperty("_contentLoaded", false);
            int connectionId = 0; 
            object obj = new object();
            target.Connect(connectionId, obj);
            var result = (bool)param.GetFieldOrProperty("_contentLoaded");
            Assert.IsTrue(result);
        }

        /// <summary>
        ///A test for Window_Loaded
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Window_LoadedTest()
        {
            LoadingDialog_Accessor target = new LoadingDialog_Accessor(); 
            object sender = null; 
            RoutedEventArgs e = null; 
            target.Window_Loaded(sender, e);
        }

        /// <summary>
        ///A test for hwndSourceHook - msg != WM_SHOWWINDOW
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void hwndSourceHook_NotWM_SHOWWINDOWTest()
        {
            LoadingDialog_Accessor target = new LoadingDialog_Accessor(); 
            IntPtr hwnd = new IntPtr();
            int msg = 0; 
            IntPtr wParam = new IntPtr(); 
            IntPtr lParam = new IntPtr(); 
            bool handled = true; 
            IntPtr expected = IntPtr.Zero; 
            IntPtr actual;
            actual = target.hwndSourceHook(hwnd, msg, wParam, lParam, ref handled);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for hwndSourceHook - msg = WM_SHOWWINDOW - hMenu = IntPtr.Zero
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void hwndSourceHook_WM_SHOWWINDOW_ZeroTest()
        {
            LoadingDialog_Accessor target = new LoadingDialog_Accessor();
            IntPtr hwnd = IntPtr.Zero;
            int msg = 0x00000018;
            IntPtr wParam = new IntPtr();
            IntPtr lParam = new IntPtr();
            bool handled = true;
            IntPtr expected = IntPtr.Zero;
            IntPtr actual;
            actual = target.hwndSourceHook(hwnd, msg, wParam, lParam, ref handled);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for hwndSourceHook - msg = WM_SHOWWINDOW - hMenu != IntPtr.Zero
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void hwndSourceHook_WM_SHOWWINDOW_NotZeroTest()
        //{
        //    LoadingDialog_Accessor target = new LoadingDialog_Accessor();
        //    IntPtr hwnd = new IntPtr(2);
        //    int msg = 0x00000018;
        //    IntPtr wParam = new IntPtr(2);
        //    IntPtr lParam = new IntPtr(2);
        //    bool handled = true;
        //    IntPtr expected = IntPtr.Zero;
        //    IntPtr actual;
        //    actual = target.hwndSourceHook(hwnd, msg, wParam, lParam, ref handled);
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
