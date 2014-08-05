using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Windows;
using Microsoft.Windows.Controls;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EditFilterSettingViewTest and is intended
    ///to contain all EditFilterSettingViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EditFilterSettingViewTest
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
                ServiceLocator.Register<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
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
        //
        #endregion


        /// <summary>
        ///A test for EditFilterSettingView Constructor
        ///</summary>
        [TestMethod()]
        public void EditFilterSettingViewConstructorTest()
        {
            EditFilterSettingView target = new EditFilterSettingView();
          //  Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DataGrid_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataGrid_KeyDownTest()
        {
            EditFilterSettingView_Accessor target = new EditFilterSettingView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value

            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, Key.Delete);
            e.RoutedEvent = UIElement.KeyDownEvent;
            target.DataGrid_KeyDown(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            EditFilterSettingView target = new EditFilterSettingView(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnDatagridRowMouseDoubleClick
        ///</summary>
        [TestMethod()]
        public void OnDatagridRowMouseDoubleClickTest()
        {
            EditFilterSettingView target = new EditFilterSettingView(); // TODO: Initialize to an appropriate value
            object sender = new DataGridRow(); // TODO: Initialize to an appropriate value
            EventArgs args = null; // TODO: Initialize to an appropriate value
            target.OnDatagridRowMouseDoubleClick(sender, args);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
