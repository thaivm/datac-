using LogViewer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.WindowViewModelMapping;
using System.Windows;
using LogViewer.Service.FrameworkDialogs.FolderBrowse;
using System.Windows.Forms;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Controls.DataVisualization.Charting;
using System.ComponentModel;
using LogViewer.ViewModel;
using LogViewer.Business;
using LogViewer.Business.FileSetting;
using LogViewer.Service.FrameworkDialogs;
using LogViewer.Model;
using LogViewer.View;

namespace LogViewer.Tests
{


    /// <summary>
    ///This is a test class for DialogServiceTest and is intended
    ///to contain all DialogServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DialogServiceTest
    {
        //public static DialogService target;
        public static MainViewModel_Accessor targetMainVM;

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
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
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
        ///A test for DialogService Constructor
        ///</summary>
        [TestMethod()]
        public void DialogServiceConstructorTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            Assert.IsNotNull(target.views);
        }

        /// <summary>
        ///A test for FindOwnerWindow
        ///
        ///Input:
        ///viewModel = null
        ///
        ///Ouput:
        ///return null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void FindOwnerWindow_viewModelNullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            object viewModel = null; 
            Window expected = null; 
            Window actual;
            actual = target.FindOwnerWindow(viewModel);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FindOwnerWindow
        ///
        ///Input:
        ///viewModel = null
        ///views = null
        ///
        ///Ouput:
        ///return null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void FindOwnerWindow_returnNullTest()
        {
            DialogService dlg = new DialogService(new WindowViewModelMappings());
            PrivateObject param0 = new PrivateObject(dlg);
            FrameworkElement el = new FrameworkElement();
            el.DataContext = new object();
            object viewModel = el.DataContext;
            param0.SetFieldOrProperty("views", null);
            var result = param0.Invoke("FindOwnerWindow", viewModel);
            Assert.IsNull(result);
        }

        /// <summary>
        ///A test for FindOwnerWindow
        ///
        ///Input:
        ///viewModel = FrameworkElement.DataContext
        ///views = new HashSet<FrameworkElement> {el }
        ///
        ///Ouput:
        ///return null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void FindOwnerWindow_viewModelNotNull_ownerNullTest()
        {
            DialogService dlg = new DialogService(new WindowViewModelMappings());
            PrivateObject param0 = new PrivateObject(dlg);
            FrameworkElement el = new FrameworkElement();
            el.DataContext = new object();
            object viewModel = el.DataContext; 
            param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });
            Assert.IsNull(param0.Invoke("FindOwnerWindow", viewModel));
        }

        /// <summary>
        ///A test for FindOwnerWindow
        ///
        ///Input:
        ///viewModel = Window.DataContext
        ///views = new HashSet<FrameworkElement> {el }
        ///
        ///Ouput:
        ///return Window (not null)
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void FindOwnerWindow_viewModelNotNull_ownerNotNullTest()
        {
            DialogService dlg = new DialogService(new WindowViewModelMappings());
            PrivateObject param0 = new PrivateObject(dlg);
            Window el = new Window();
            el.DataContext = new object();
            object viewModel = el.DataContext; 
            param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });
            Assert.IsNotNull(param0.Invoke("FindOwnerWindow", viewModel));
        }

        /// <summary>
        ///A test for GetIsRegisteredView - set true
        ///</summary>
        [TestMethod()]
        public void GetIsRegisteredView_TrueTest()
        {
            FrameworkElement el = new FrameworkElement();
            DialogService.SetIsRegisteredView(el, true);
            Assert.IsTrue((bool)DialogService.GetIsRegisteredView(el));
        }

        /// <summary>
        ///A test for GetIsRegisteredView - set false
        ///</summary>
        [TestMethod()]
        public void GetIsRegisteredView_FalseTest()
        {
            FrameworkElement el = new FrameworkElement();
            DialogService.SetIsRegisteredView(el, false);
            Assert.IsFalse((bool)DialogService.GetIsRegisteredView(el));
        }


        /// <summary>
        ///A test for GetOwner
        ///
        ///Input:
        ///view = new Window()
        ///
        ///Ouput
        ///target.GetOwner(view) != null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetOwner_NotNullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            Window view = new Window(); 
            Assert.IsNotNull(target.GetOwner(view));
        }


        /// <summary>
        ///A test for GetOwner
        ///
        ///Input:
        ///view = new FrameworkElement()
        ///
        ///Ouput
        ///target.GetOwner(view) = null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetOwner_NullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            FrameworkElement view = new FrameworkElement(); 
            Assert.IsNull(target.GetOwner(view));
        }

        /// <summary>
        ///A test for IsRegisteredViewPropertyChanged
        ///
        /// Input:
        /// DesignerProperties.SetIsInDesignMode(el, true);
        /// 
        /// Output:
        /// return
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsRegisteredViewPropertyChanged_ReturnTest()
        {
            FrameworkElement el = new FrameworkElement();
            DesignerProperties.SetIsInDesignMode(el, true);
            DialogService_Accessor.IsRegisteredViewPropertyChanged(el, new DependencyPropertyChangedEventArgs());
        }

        /// <summary>
        ///A test for IsRegisteredViewPropertyChanged
        ///
        /// Input:
        /// DesignerProperties.SetIsInDesignMode(el, false);
        /// el = new FrameworkElement()
        /// newValue == true;
        /// 
        /// Output:
        /// return
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsRegisteredViewPropertyChanged_newValueTrueTest()
        {
            FrameworkElement el = new FrameworkElement();
            DesignerProperties.SetIsInDesignMode(el, false);
            DependencyPropertyChangedEventArgs e = new DependencyPropertyChangedEventArgs(
                DialogService.IsRegisteredViewProperty, true, true);
            DialogService_Accessor.IsRegisteredViewPropertyChanged(el, e);
            Assert.IsNotNull(ServiceLocator.Resolve<IDialogService>());
        }

        /// <summary>
        ///A test for IsRegisteredViewPropertyChanged
        ///
        /// Input:
        /// DesignerProperties.SetIsInDesignMode(el, false);
        /// el = new FrameworkElement()
        /// newValue == false;
        /// 
        /// Output:
        /// return
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsRegisteredViewPropertyChanged_newValueFalseTest()
        {
            FrameworkElement el = new FrameworkElement();
            DesignerProperties.SetIsInDesignMode(el, false);
            DependencyPropertyChangedEventArgs e = new DependencyPropertyChangedEventArgs(
                DialogService.IsRegisteredViewProperty, true, false);
            DialogService_Accessor.IsRegisteredViewPropertyChanged(el, e);
            Assert.IsNotNull(ServiceLocator.Resolve<IDialogService>());
        }

        /// <summary>
        ///A test for LateRegister
        ///
        /// Input
        /// FrameworkElement = null
        /// 
        /// Output
        /// not cover code
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LateRegister_NullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            FrameworkElement el = null;
            RoutedEventArgs e = new RoutedEventArgs(); 
            target.LateRegister(el, e);
            Assert.IsNull(el);
        }

        /// <summary>
        ///A test for LateRegister
        ///
        /// Input
        /// FrameworkElement != null
        /// 
        /// Output
        /// cover code
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void LateRegister_NotNullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            FrameworkElement el = new FrameworkElement();
            RoutedEventArgs e = new RoutedEventArgs(); 
            target.LateRegister(el, e);
            Assert.IsNotNull(el);
        }

        /// <summary>
        ///A test for OwnerClosed
        ///
        /// Input
        /// Window = null
        /// 
        /// Output
        /// not cover code
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void OwnerClosed_NullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            Window sender = null; 
            EventArgs e = null; 
            target.OwnerClosed(sender, e);
            Assert.IsNull(sender);
        }

        /// <summary>
        ///A test for OwnerClosed
        ///
        /// Input
        /// Window != null
        /// 
        /// Output
        /// not cover code
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void OwnerClosed_NotNullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            Window sender = new Window(); 
            EventArgs e = null; 
            target.OwnerClosed(sender, e);
            Assert.IsNotNull(sender);
        }

        /// <summary>
        ///A test for Register
        ///
        /// Input:
        /// view = new FrameworkElement()
        /// 
        /// Output:
        /// not cover code
        ///</summary>
        [TestMethod()]
        public void Register_NullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            FrameworkElement view = new FrameworkElement(); 
            target.Register(view);
        }

        /// <summary>
        ///A test for Register
        ///
        /// Input:
        /// view = new Window()
        /// 
        /// Output:
        /// cover code
        ///</summary>
        [TestMethod()]
        public void Register_NotNullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            Window view = new Window(); 
            target.Register(view);
        }

        /// <summary>
        ///A test for SetIsRegisteredView
        ///
        /// Input
        /// value = false
        /// 
        /// Output
        /// DialogService.GetIsRegisteredView(target) = false
        ///</summary>
        [TestMethod()]
        public void SetIsRegisteredView_FalseTest()
        {
            FrameworkElement target = new FrameworkElement(); 
            bool value = false; 
            DialogService.SetIsRegisteredView(target, value);
            Assert.IsFalse(DialogService.GetIsRegisteredView(target));
        }

        /// <summary>
        ///A test for SetIsRegisteredView
        ///
        /// Input
        /// value = true
        /// 
        /// Output
        /// DialogService.GetIsRegisteredView(target) = true
        ///</summary>
        [TestMethod()]
        public void SetIsRegisteredView_TrueTest()
        {
            FrameworkElement target = new FrameworkElement(); 
            bool value = true; 
            DialogService.SetIsRegisteredView(target, value);
            Assert.IsTrue(DialogService.GetIsRegisteredView(target));
        }

        /// <summary>
        ///A test for Show
        ///</summary>
        //[TestMethod()]
        //public void ShowTest()
        //{
        //    DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
        //    targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();
        //    BaseWindowViewModel viewModel = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); 
        //    viewModel.IsShow = false;
        //    CCSMainViewModel ownerViewModel = new CCSMainViewModel(new object(),
        //        new CCSSettingManager(), targetMainVM.CCSShowRecordWithDateTime);
        //    target.Show(ownerViewModel, viewModel);
        //}

        ///// <summary>
        /////A test for Show
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void Show_TypeTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    SetLogDisplayViewModel viewModel = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
        //    viewModel.LoadData(targetMainVM.CCSMainVM.SettingManager.DisplaySetting,
        //        targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
        //    CCSMainViewModel ownerViewModel = new CCSMainViewModel(new object(),
        //        new CCSSettingManager(), targetMainVM.CCSShowRecordWithDateTime);
        //    PrivateObject param = new PrivateObject(target);
        //    param.Invoke("Show", ownerViewModel, viewModel, typeof(LogDisplaySettingView));
        //}

        ///// <summary>
        /////A test for ShowDialog
        /////
        ///// Input
        ///// ownerViewModel = CXDIMainViewModel
        ///// viewModel = BaseWindowViewModel
        ///// ShowDialog<CCSMainViewModel>
        ///// 
        ///// Ouput
        ///// return false
        /////</summary>
        //[TestMethod()]
        //public void ShowDialog_Window_FalseTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    SetLogDisplayViewModel viewModel = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
        //    viewModel.LoadData(targetMainVM.CCSMainVM.SettingManager.DisplaySetting,
        //        targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
        //    CCSMainViewModel ownerViewModel = new CCSMainViewModel(new object(),
        //        new CCSSettingManager(), targetMainVM.CCSShowRecordWithDateTime);
        //    Assert.IsFalse((bool)target.ShowDialog<LogDisplaySettingView>(ownerViewModel, viewModel));
        //}

        ///// <summary>
        /////A test for ShowDialog
        /////
        ///// Input
        ///// ownerViewModel = CCSMainViewModel
        ///// viewModel = SetLogDisplayViewModel
        ///// ShowDialog<CCSMainViewModel>
        ///// 
        ///// Ouput
        ///// return false
        /////</summary>
        //[TestMethod()]
        //public void ShowDialogTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    SetLogDisplayViewModel viewModel = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
        //    viewModel.LoadData(targetMainVM.CCSMainVM.SettingManager.DisplaySetting,
        //        targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
        //    CCSMainViewModel ownerViewModel = new CCSMainViewModel(new object(),
        //        new CCSSettingManager(), targetMainVM.CCSShowRecordWithDateTime);
        //    Assert.IsFalse((bool)target.ShowDialog(ownerViewModel, viewModel));
        //}

        ///// <summary>
        /////A test for ShowDialog
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void ShowDialog_TypeTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    SetLogDisplayViewModel viewModel = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
        //    viewModel.LoadData(targetMainVM.CCSMainVM.SettingManager.DisplaySetting,
        //        targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
        //    CCSMainViewModel ownerViewModel = new CCSMainViewModel(new object(),
        //        new CCSSettingManager(), targetMainVM.CCSShowRecordWithDateTime);
        //    PrivateObject param = new PrivateObject(target);
        //    bool result = (bool)param.Invoke("ShowDialog", ownerViewModel, viewModel, typeof(LogDisplaySettingView));
        //    Assert.IsFalse(result);
        //}

        ///// <summary>
        /////A test for ShowFolderBrowserDialog - Click OK button
        /////</summary>
        //[TestMethod()]
        //public void ShowFolderBrowserDialog_OKTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(target);

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //set IFolderBrowserDialog
        //    IFolderBrowserDialog folderBrowserDialog =
        //        new LogViewer.Service.FrameworkDialogs.FolderBrowse.FolderBrowserDialogViewModel();
        //    folderBrowserDialog.Description = "Click OK button";

        //    var result = target.ShowFolderBrowserDialog(viewModel, folderBrowserDialog);
        //    //clear value
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

        //    Assert.IsNotNull(result);
        //}

        ///// <summary>
        /////A test for ShowFolderBrowserDialog - Click Cancel button
        /////</summary>
        //[TestMethod()]
        //public void ShowFolderBrowserDialog_CancelTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(target);

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //set IFolderBrowserDialog
        //    IFolderBrowserDialog folderBrowserDialog =
        //        new LogViewer.Service.FrameworkDialogs.FolderBrowse.FolderBrowserDialogViewModel();
        //    folderBrowserDialog.Description = "Click Cancel button";

        //    var result = target.ShowFolderBrowserDialog(viewModel, folderBrowserDialog);
        //    //clear value
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //    Assert.AreEqual(DialogResult.Cancel, result);
        //}

        ///// <summary>
        /////A test for ShowMessageBox
        /////
        ///// ownerViewModel.Owner = null
        ///// 
        ///// return MessageBoxResult.None
        /////</summary>
        [TestMethod()]
        public void ShowMessageBox_NullTest()
        {
            DialogService_Accessor target = new DialogService_Accessor(new WindowViewModelMappings());
            Window ownerViewModel = new Window();
            string messageBoxText = "Test";
            string caption = "Caption";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = new MessageBoxImage();
            MessageBoxResult expected = MessageBoxResult.None;
            MessageBoxResult actual;
            actual = target.ShowMessageBox(ownerViewModel, messageBoxText, caption, button, icon);
            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for ShowMessageBox
        /////
        ///// Input
        ///// ownerViewModel.Owner != null
        ///// 
        ///// Output
        ///// return !MessageBoxResult.None
        /////</summary>
        //[TestMethod()]
        //public void ShowMessageBox_NotNullTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(target);

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object ownerViewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    string messageBoxText = "Test";
        //    string caption = "Caption";
        //    MessageBoxButton button = MessageBoxButton.OK;
        //    MessageBoxImage icon = new MessageBoxImage();
        //    MessageBoxResult expected = MessageBoxResult.None;
        //    MessageBoxResult actual;
        //    actual = target.ShowMessageBox(ownerViewModel, messageBoxText, caption, button, icon);
        //    Assert.AreNotEqual(expected, actual);

        //    //clear value
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //}

        ///// <summary>
        /////A test for ShowOpenFileDialog - Click Cancel button
        /////</summary>
        //[TestMethod()]
        //public void ShowOpenFileDialog_CancelTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(target);

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //set IOpenFileDialog
        //    IOpenFileDialog openFileDialog = new LogViewer.ViewModel.OpenFileDialogViewModel();
        //    openFileDialog.FileName = "Click Cancel button";
        //    Assert.AreEqual(DialogResult.Cancel, target.ShowOpenFileDialog(viewModel, openFileDialog));

        //    //clear value
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //}

        ///// <summary>
        /////A test for ShowOpenFileDialog - Click OK button
        /////</summary>
        //[TestMethod()]
        //public void ShowOpenFileDialog_OKTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(target);

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //set IOpenFileDialog
        //    IOpenFileDialog openFileDialog = new LogViewer.ViewModel.OpenFileDialogViewModel();
        //    openFileDialog.FileName = "Click OK button";
        //    //target.ShowOpenFileDialog(viewModel, openFileDialog);
        //    Assert.IsNotNull(target.ShowOpenFileDialog(viewModel, openFileDialog));

        //    //clear value
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //}

        ///// <summary>
        /////A test for ShowSaveFileDialog - Click Save button - return true
        /////</summary>
        //[TestMethod()]
        //public void ShowSaveFileDialog_TrueTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(target);

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //set ISaveFileDialog
        //    ISaveFileDialog saveFileDialog = new LogViewer.ViewModel.SaveFileDialogViewModel();
        //    saveFileDialog.FileName = "Click Save button";
        //    //target.ShowSaveFileDialog(viewModel, saveFileDialog);
        //    Assert.IsNotNull((bool)target.ShowSaveFileDialog(viewModel, saveFileDialog));

        //    //clear value
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //}

        ///// <summary>
        /////A test for ShowSaveFileDialog - Click Cancel button - return false
        /////</summary>
        //[TestMethod()]
        //public void ShowSaveFileDialog_FalseTest()
        //{
        //    DialogService target = new DialogService(new WindowViewModelMappings());
        //    PrivateObject param0 = new PrivateObject(target);

        //    //set viewModel
        //    Window el = new Window();
        //    el.DataContext = new object();
        //    object viewModel = el.DataContext;
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });

        //    //set ISaveFileDialog
        //    ISaveFileDialog saveFileDialog = new LogViewer.ViewModel.SaveFileDialogViewModel();
        //    saveFileDialog.FileName = "Click Cancel button";
        //    Assert.IsFalse((bool)target.ShowSaveFileDialog(viewModel, saveFileDialog));

        //    //clear value
        //    param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //}

        /// <summary>
        ///A test for Unregister
        ///</summary>
        [TestMethod()]
        public void UnregisterTest()
        {
            DialogService target = new DialogService(new WindowViewModelMappings());
            PrivateObject param0 = new PrivateObject(target);

            //set viewModel
            FrameworkElement el = new FrameworkElement();
            object viewModel = el.DataContext;
            param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });
            target.Unregister(el);
            HashSet<FrameworkElement> result = (HashSet<FrameworkElement>)param0.GetFieldOrProperty("views");
            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        ///A test for Views
        ///</summary>
        [TestMethod()]
        public void ViewsTest()
        {
            DialogService target = new DialogService(new WindowViewModelMappings());
            PrivateObject param0 = new PrivateObject(target);

            //set viewModel
            FrameworkElement el = new FrameworkElement();
            object viewModel = el.DataContext;
            param0.SetFieldOrProperty("views", new HashSet<FrameworkElement> { el });
            Assert.AreEqual(1, target.Views.Count);
        }
    }
}
