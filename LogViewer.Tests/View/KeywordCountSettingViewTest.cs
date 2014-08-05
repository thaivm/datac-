using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.View;
using LogViewer.WindowViewModelMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Forms;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for KeywordCountSettingViewTest and is intended
    ///to contain all KeywordCountSettingViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KeywordCountSettingViewTest
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
        }
        //
        #endregion

        /// <summary>
        ///A test for DataGrid_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataGrid_KeyDownTest()
        {
            KeywordCountSettingView_Accessor target = new KeywordCountSettingView_Accessor();
            object sender = null;            
            var key = Key.Delete;                    // Key to send
            var target1 = Keyboard.FocusedElement;    // Target element
            var routedEvent = Keyboard.KeyDownEvent; // Event to send                        
            System.Windows.Input.KeyEventArgs e = new System.Windows.Input.KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, key);
            e.RoutedEvent = routedEvent;
            target.DataGrid_KeyDown(sender, e);
            
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            KeywordCountSettingView target = new KeywordCountSettingView();
            target.InitializeComponent();
            
        }

        /// <summary>
        ///A test for OnDatagridRowMouseDoubleClick
        ///</summary>
        [TestMethod()]
        public void OnDatagridRowMouseDoubleClickTest()
        {
            KeywordCountSettingView target = new KeywordCountSettingView();
            Microsoft.Windows.Controls.DataGridRow sender = new Microsoft.Windows.Controls.DataGridRow();
            sender.DataContext = "hihi";
           
            EventArgs args = null;
           // MouseButtonEventArgs e = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left) { RoutedEvent = Control.MouseDoubleClickEvent };
            //e.RoutedEvent = Control.MouseDoubleClickEvent;
          //  target.RaiseEvent(e);
            target.OnDatagridRowMouseDoubleClick(sender, args);
            
        }

        /// <summary>
        ///A test for System.Windows.Markup.IComponentConnector.Connect
        ///</summary>
        [TestMethod()]
        public void ConnectTest()
        {
            IComponentConnector target = new KeywordCountSettingView();
            int connectionId = 0;
            object target1 = null;
            target.Connect(connectionId, target1);
            
        }

        /// <summary>
        ///A test for System.Windows.Markup.IStyleConnector.Connect
        ///</summary>
        [TestMethod()]
        public void ConnectTest1()
        {
            IStyleConnector target = new KeywordCountSettingView();
            int connectionId = 0;
            object target1 = null;
            target.Connect(connectionId, target1);
            
        }
    }
}
