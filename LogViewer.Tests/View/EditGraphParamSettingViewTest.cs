using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using System.Windows.Markup;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.ViewModel;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EditGraphParamSettingViewTest and is intended
    ///to contain all EditGraphParamSettingViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EditGraphParamSettingViewTest
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
        public void SetUp()
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
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
        }
        //
        #endregion


        /// <summary>
        ///A test for EditGraphParamSettingView Constructor
        ///</summary>
        [TestMethod()]
        public void EditGraphParamSettingViewConstructorTest()
        {
            EditGraphParamSettingView target = new EditGraphParamSettingView();
        }

        /// <summary>
        ///A test for DataGrid_KeyDown - e.Key != Key.Delete
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataGrid_KeyDown_NotDeleteTest()
        {
            EditGraphParamSettingView_Accessor target = new EditGraphParamSettingView_Accessor(); 
            object sender = null; 
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, Key.Down);
            target.DataGrid_KeyDown(sender, e);
            Assert.IsFalse(e.Handled);
        }

        /// <summary>
        ///A test for DataGrid_KeyDown - e.Key = Key.Delete
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataGrid_KeyDown_DeleteTest()
        {
            EditGraphParamSettingView_Accessor target = new EditGraphParamSettingView_Accessor();
            object sender = null;
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, Key.Delete);
            e.RoutedEvent = Keyboard.KeyDownEvent;
            target.DataGrid_KeyDown(sender, e);
            Assert.IsTrue(e.Handled);
        }

        /// <summary>
        ///A test for InitializeComponent - _contentLoaded is
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            EditGraphParamSettingView target = new EditGraphParamSettingView(); 
            target.InitializeComponent();
        }

        /// <summary>
        ///A test for System.Windows.Markup.IComponentConnector.Connect - connectionId = 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Connect_0Test()
        {
            IComponentConnector target = new EditGraphParamSettingView(); 
            int connectionId = 0; 
            object obj = null;
            target.Connect(connectionId, obj);
        }

        /// <summary>
        ///A test for System.Windows.Markup.IComponentConnector.Connect - connectionId = 1
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Connect_1Test()
        {
            IComponentConnector target = new EditGraphParamSettingView();
            int connectionId = 1;
            object obj = new Microsoft.Windows.Controls.DataGrid();
            target.Connect(connectionId, obj);
        }

        /// <summary>
        ///A test for System.Windows.Markup.IComponentConnector.Connect - connectionId = 2
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Connect_2Test()
        {
            IComponentConnector target = new EditGraphParamSettingView();
            int connectionId = 2;
            object obj = new Microsoft.Windows.Controls.DataGrid();
            target.Connect(connectionId, obj);
        }
    }
}
