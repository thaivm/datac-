using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.View;
using LogViewer.WindowViewModelMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Media;
using Microsoft.Windows.Controls;

namespace LogViewer.Tests
{
    public class FakePresentationSource : PresentationSource
    {
        protected override CompositionTarget GetCompositionTargetCore()
        {
            return null;
        }

        public override Visual RootVisual { get; set; }

        public override bool IsDisposed { get { return false; } }
    }
    
    /// <summary>
    ///This is a test class for SearchKeywordViewTest and is intended
    ///to contain all SearchKeywordViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SearchKeywordViewTest
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
        #endregion


        ///// <summary>
        /////A test for SearchKeywordView Constructor
        /////</summary>
        //[TestMethod()]
        //public void SearchKeywordViewConstructorTest()
        //{
        //    SearchKeywordView target = new SearchKeywordView();
        //  //  Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        /// <summary>
        ///A test for DataGrid_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataGrid_KeyDownTest()
        {
            SearchKeywordView_Accessor target = new SearchKeywordView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = new object();

            //Keyboard.PrimaryDevice.ActiveSource = null; 
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, Key.Delete);
            e.RoutedEvent = UIElement.KeyDownEvent;
            target.DataGrid_KeyDown(sender, e);
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            SearchKeywordView target = new SearchKeywordView(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
          //  Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnDatagridRecordRowPressEnter
        ///</summary>
        [TestMethod()]
        public void OnDatagridRecordRowPressEnterTest()
        {
            SearchKeywordView target = new SearchKeywordView(); // TODO: Initialize to an appropriate value
            DataGridRow sender = new DataGridRow(); // TODO: Initialize to an appropriate value
            //KeyEventArgs args = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, Key.Enter);
            e.RoutedEvent = UIElement.KeyDownEvent;

            target.OnDatagridRecordRowPressEnter(sender, e);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnDatagridRowMouseDoubleClick
        ///</summary>
        [TestMethod()]
        public void OnDatagridRowMouseDoubleClickTest()
        {
            SearchKeywordView target = new SearchKeywordView(); // TODO: Initialize to an appropriate value
            DataGridRow sender = new DataGridRow(); // TODO: Initialize to an appropriate value
            EventArgs args = null; // TODO: Initialize to an appropriate value
            target.OnDatagridRowMouseDoubleClick(sender, args);
            
        }

        /// <summary>
        ///A test for SetDatagridDoubleClickedRow
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetDatagridDoubleClickedRowTest()
        {
            SearchKeywordView_Accessor target = new SearchKeywordView_Accessor(); // TODO: Initialize to an appropriate value
            DataGridRow rowObj = new DataGridRow(); // TODO: Initialize to an appropriate value
            target.SetDatagridDoubleClickedRow(rowObj);
           /// Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetDatagridDoubleClickedRow
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetDatagridDoubleClickedRow_NotNullDataTest()
        {
            SearchKeywordView_Accessor target = new SearchKeywordView_Accessor(); // TODO: Initialize to an appropriate value
            DataGridRow rowObj = null; // TODO: Initialize to an appropriate value
            target.SetDatagridDoubleClickedRow(rowObj);
            /// Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

    }
}
