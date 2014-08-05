using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Model;
using LogViewer.Business;
using LogViewer.MVVMHelper;
using System.Windows;
using System.Collections.Generic;
using LogViewer.Util;
using LogViewer.View;
using System.Reflection;
using System.Collections.ObjectModel;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseWindowViewModelTest and is intended
    ///to contain all BaseWindowViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseWindowViewModelTest 
    {
        public static MainViewModel_Accessor targetMainVM;
        public static CCSMainViewModel_Accessor ccsMain;
        public static CXDIMainViewModel_Accessor cxdiMain;
        public static GraphViewModel_Accessor graph;

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
        [ClassInitialize()]
        public static void MyTestInitialize(TestContext context)
        {
            if(!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
            ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.Register<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.Register<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
            }
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        [ClassCleanup()]
        public static void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
        }
        //
        #endregion


        /// <summary>
        ///A test for BaseWindowViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void BaseWindowViewModelConstructorTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CloseCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CloseCommandCLTest()
        {
            BaseWindowViewModel_Accessor target = new BaseWindowViewModel_Accessor(); 
            target.CloseCommandCL();
            Assert.IsFalse(target.IsShow);
        }

        /// <summary>
        ///A test for CloseDialog != null
        ///</summary>
        [TestMethod()]
        public void CloseDialog_NotNullTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel();
            target.IsShow = true;
            target.CloseAction += new Action(() => { });
            target.CloseDialog();
            Assert.IsFalse(target.IsShow);
        }

        /// <summary>
        ///A test for CloseDialog = null
        ///</summary>
        [TestMethod()]
        public void CloseDialog_NullTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel();
            target.IsShow = true;
            target.CloseAction += null;
            target.CloseDialog();
            Assert.IsTrue(target.IsShow);
        }

        /// <summary>
        ///A test for Show - IsShow = false
        ///</summary>
        [TestMethod()]
        public void ShowIsShowFalseTest()
        {
            BaseWindowViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); 
            target.IsShow = false;
            CCSMainViewModel ccs = new LogViewer.ViewModel.CCSMainViewModel(new object(), new CCSSettingManager(), targetMainVM.CCSShowRecordWithDateTime, null);
            target.Show(ccs);
            Assert.IsTrue(target.IsShow);
        }

        /// <summary>
        ///A test for Show - IsShow = true && _dialogService.Views is null
        ///</summary>
        [TestMethod()]
        public void ShowIsShow_dialogServiceNullTest()
        {
            BaseWindowViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            target.IsShow = true;
            PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
            ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);
            target.Show(ccsMain.MainViewModelObject);
            Assert.AreEqual(target.GetType(), typeof(SetLogDisplayViewModel));
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() not equal
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypeNotEqualTrueTest()
        {
            BaseWindowViewModel target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); 
            target.IsShow = true;
            PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
            ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            EditFilterSettingView pattern = new EditFilterSettingView();
            pattern.DataContext = new EditCCSFilterSettingViewModel(ccsMain.ApplyFilterSetting);
            pattern.Title = "CCS";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            target.Show(ccsMain.MainViewModelObject);
            var result = BaseWindowViewModel_Accessor._dialogService.Views[0].GetType();

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(result, typeof(EditFilterSettingView));
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is GraphView
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueGraphViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            cxdiMain = new LogViewer.ViewModel.CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting); 
            target.IsShow = true;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            GraphView pattern = new GraphView();
            pattern.DataContext = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.GraphView;
            sender.WindowState = System.Windows.WindowState.Maximized;
            target.Show(cxdiMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Normal, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is EditFilterSettingView && CCS
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueEditFilterSettingViewCCSTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
            ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditCCSFilterSettingViewModel(ccsMain.ApplyFilterSetting); 
            target.IsShow = true;
            target.IsCCS = true;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            EditFilterSettingView pattern = new EditFilterSettingView();
            pattern.DataContext = new EditCCSFilterSettingViewModel(ccsMain.ApplyFilterSetting);
            pattern.Title = "CCS";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.EditFilterSettingView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(ccsMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Normal, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is EditFilterSettingView && CCS -> not show
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueEditFilterSettingViewCCS_NotShowTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
            ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditCCSFilterSettingViewModel(ccsMain.ApplyFilterSetting);
            target.IsShow = true;
            target.IsCCS = false;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            EditFilterSettingView pattern = new EditFilterSettingView();
            pattern.DataContext = new EditCCSFilterSettingViewModel(ccsMain.ApplyFilterSetting);
            pattern.Title = "CCS";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.EditFilterSettingView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(ccsMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Maximized, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is EditFilterSettingView && CXDI
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueEditFilterSettingViewCXDITest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            cxdiMain = new LogViewer.ViewModel.CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditCXDIFilterSettingViewModel(cxdiMain.ApplyFilterSetting); 
            target.IsShow = true;
            target.IsCCS = false;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            EditFilterSettingView pattern = new EditFilterSettingView();
            pattern.DataContext = new EditCXDIFilterSettingViewModel(cxdiMain.ApplyFilterSetting);
            pattern.Title = "CXDI";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.EditFilterSettingView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(cxdiMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Normal, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is EditCXDIFilterSettingView && CCS -> not show
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueEditFilterSettingViewCXDI_NotShowTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            cxdiMain = new LogViewer.ViewModel.CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditCXDIFilterSettingViewModel(cxdiMain.ApplyFilterSetting);
            target.IsShow = true;
            target.IsCCS = true;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            EditFilterSettingView pattern = new EditFilterSettingView();
            pattern.DataContext = new EditCXDIFilterSettingViewModel(cxdiMain.ApplyFilterSetting);
            pattern.Title = "CXDI";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.EditFilterSettingView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(cxdiMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Maximized, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is KeywordCountSettingView && CCS
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueKeywordCountSettingViewCCSTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
            ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditCCSKeywordCountSettingViewModel(ccsMain.ApplyKeywordCountSetting); 
            target.IsShow = true;
            target.IsCCS = true;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            KeywordCountSettingView pattern = new KeywordCountSettingView();
            pattern.DataContext = new EditCCSKeywordCountSettingViewModel(ccsMain.ApplyKeywordCountSetting);
            pattern.Title = "CCS";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.KeywordCountSettingView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(ccsMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Normal, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is KeywordCountSettingView && CCS -> not show
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueKeywordCountSettingViewCCS_NotShowTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
            ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditCCSKeywordCountSettingViewModel(ccsMain.ApplyKeywordCountSetting);
            target.IsShow = true;
            target.IsCCS = false;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            KeywordCountSettingView pattern = new KeywordCountSettingView();
            pattern.DataContext = new EditCCSKeywordCountSettingViewModel(ccsMain.ApplyKeywordCountSetting);
            pattern.Title = "CCS";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.KeywordCountSettingView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(ccsMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Maximized, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is KeywordCountSettingView && CXDI
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueKeywordCountSettingViewCXDITest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            cxdiMain = new LogViewer.ViewModel.CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditCXDIKeywordCountSettingViewModel(cxdiMain.ApplyKeywordCountSetting); 
            target.IsShow = true;
            target.IsCCS = false;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            KeywordCountSettingView pattern = new KeywordCountSettingView();
            pattern.DataContext = new EditCXDIKeywordCountSettingViewModel(cxdiMain.ApplyKeywordCountSetting);
            pattern.Title = "CXDI";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.KeywordCountSettingView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(cxdiMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Normal, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is KeywordCountSettingView && CXDI - not show
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueKeywordCountSettingViewCXDI_NotShowTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            cxdiMain = new LogViewer.ViewModel.CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditCXDIKeywordCountSettingViewModel(cxdiMain.ApplyKeywordCountSetting);
            target.IsShow = true;
            target.IsCCS = true;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            KeywordCountSettingView pattern = new KeywordCountSettingView();
            pattern.DataContext = new EditCXDIKeywordCountSettingViewModel(cxdiMain.ApplyKeywordCountSetting);
            pattern.Title = "CXDI";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.KeywordCountSettingView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(cxdiMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Maximized, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is PatternManagerView && CCS
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTruePatternManagerViewCCSTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
            ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditPatternSettingViewModel(ccsMain.ApplyPatternSetting); 
            target.IsShow = true;
            target.IsCCS = true;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            PatternManagerView pattern = new PatternManagerView();
            pattern.DataContext = new EditPatternSettingViewModel(ccsMain.ApplyPatternSetting);
            pattern.Title = "CCS";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.PatternManagerView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(ccsMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Normal, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is PatternManagerView && CCS - not show
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTruePatternManagerViewCCS_NotShowTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
            ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditPatternSettingViewModel(ccsMain.ApplyPatternSetting);
            target.IsShow = true;
            target.IsCCS = false;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            PatternManagerView pattern = new PatternManagerView();
            pattern.DataContext = new EditPatternSettingViewModel(ccsMain.ApplyPatternSetting);
            pattern.Title = "CCS";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.PatternManagerView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(ccsMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Maximized, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is PatternManagerView && CXDI
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTruePatternManagerViewCXDITest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            cxdiMain = new LogViewer.ViewModel.CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditPatternSettingViewModel(cxdiMain.ApplyPatternSetting); 
            target.IsShow = true;
            target.IsCCS = false;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            PatternManagerView pattern = new PatternManagerView();
            pattern.DataContext = new EditPatternSettingViewModel(cxdiMain.ApplyPatternSetting);
            pattern.Title = "CXDI";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });            
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.PatternManagerView;
            sender.WindowState = WindowState.Maximized;

            //run and return result
            target.Show(cxdiMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Normal, result);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is PatternManagerView && CXDI -> not show
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTruePatternManagerViewCXDI_NotShowTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            cxdiMain = new LogViewer.ViewModel.CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new EditPatternSettingViewModel(cxdiMain.ApplyPatternSetting);
            target.IsShow = true;
            target.IsCCS = true;

            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            PatternManagerView pattern = new PatternManagerView();
            pattern.DataContext = new EditPatternSettingViewModel(cxdiMain.ApplyPatternSetting);
            pattern.Title = "CXDI";
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { pattern });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.PatternManagerView;
            sender.WindowState = System.Windows.WindowState.Maximized;

            //run and return result
            target.Show(cxdiMain.MainViewModelObject);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Maximized, sender.WindowState);
        }

        /// <summary>
        ///A test for Show - IsShow = true && GetType() equal && view is SearchKeywordView
        ///</summary>
        [TestMethod()]
        public void ShowIsShowGetTypetEqualTrueSearchKeywordViewTest()
        {
            BaseWindowViewModel target = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord); 
            target.IsShow = true;
            
            //set _dialogService.Views
            PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
            SearchKeywordView search = new SearchKeywordView();
            search.DataContext = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { search });
            var sender = BaseWindowViewModel_Accessor._dialogService.Views[0] as LogViewer.View.SearchKeywordView;
            sender.WindowState = System.Windows.WindowState.Maximized;
            
            //run and return result
            target.Show(targetMainVM);
            var result = sender.WindowState;

            //clear value
            param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });

            //result
            Assert.AreEqual(System.Windows.WindowState.Normal, sender.WindowState);
        }

        /// <summary>
        ///A test for ShowDialog
        ///</summary>
        //[TestMethod()]
        //public void ShowDialogTest()
        //{
        //    PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
        //    ccsMain = new LogViewer.ViewModel.CCSMainViewModel_Accessor(param0);
        //    BaseWindowViewModel edit = new EditPatternSettingViewModel(ccsMain.ApplyPatternSetting);
        //    BaseEditSettingViewModel<PatternItemSetting> model = new EditPatternSettingViewModel(ccsMain.ApplyPatternSetting);
        //    PatternItemViewModel item = new PatternItemViewModel(x => model.ItemSettingList.Add(x));
        //    edit.ShowDialog(item);
        //    //clear value
        //    PrivateObject param = new PrivateObject(BaseWindowViewModel_Accessor._dialogService);
        //    param.SetFieldOrProperty("views", new HashSet<FrameworkElement> { });
        //}

        /// <summary>
        ///A test for dialog_Closing - GraphView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void dialog_ClosingGraphViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            CXDIMainViewModel_Accessor cxdiMain = new CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            target.dialog_Closing(new GraphView(), new CancelEventArgs());
        }

        /// <summary>
        ///A test for dialog_Closing - SearchKeywordView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void dialog_ClosingSearchKeywordViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            CXDIMainViewModel_Accessor cxdiMain = new CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            target.dialog_Closing(new SearchKeywordView(), new CancelEventArgs());
        }

        /// <summary>
        ///A test for dialog_Closing - EditFilterSettingView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void dialog_ClosingEditFilterSettingViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            CXDIMainViewModel_Accessor cxdiMain = new CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            target.dialog_Closing(new EditFilterSettingView(), new CancelEventArgs());
        }

        /// <summary>
        ///A test for dialog_Closing - KeywordCountSettingView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void dialog_ClosingKeywordCountSettingViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            CXDIMainViewModel_Accessor cxdiMain = new CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            target.dialog_Closing(new KeywordCountSettingView(), new CancelEventArgs());
        }

        /// <summary>
        ///A test for dialog_Closing - PatternManagerView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void dialog_ClosingPatternManagerViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            CXDIMainViewModel_Accessor cxdiMain = new CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            target.dialog_Closing(new PatternManagerView(), new CancelEventArgs());
        }

        /// <summary>
        ///A test for dialog_Closing - PatternItemView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void dialog_ClosingPatternItemViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            CXDIMainViewModel_Accessor cxdiMain = new CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            target.dialog_Closing(new PatternItemView(), new CancelEventArgs());
        }

        /// <summary>
        ///A test for dialog_Closing - EditGraphParamSettingView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void dialog_ClosingEditGraphParamSettingViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            CXDIMainViewModel_Accessor cxdiMain = new CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            target.dialog_Closing(new EditGraphParamSettingView(), new CancelEventArgs());
        }

        /// <summary>
        ///A test for dialog_Closing - SetRangeOfGraphView
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void dialog_ClosingSetRangeOfGraphViewTest()
        {
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            CXDIMainViewModel_Accessor cxdiMain = new CXDIMainViewModel_Accessor(param0);
            BaseWindowViewModel target = new GraphViewModel(cxdiMain.ApplyGraphSetting);
            target.dialog_Closing(new SetRangeOfGraphView(), new CancelEventArgs());
        }

        /// <summary>
        ///A test for CloseCommand
        ///</summary>
        [TestMethod()]
        public void CloseCommandIsNotNullTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel(); 
            PrivateObject param0 = new PrivateObject(target);
            param0.SetField("_closeCommand", new DelegateCommand(target.CloseDialog));
            Assert.IsNotNull(target.CloseCommand);
        }

        /// <summary>
        ///A test for CloseCommand
        ///</summary>
        [TestMethod()]
        public void CloseCommandIsNullTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel(); 
            PrivateObject param0 = new PrivateObject(target);
            param0.SetField("_closeCommand", null);
            Assert.IsNotNull(target.CloseCommand);
        }

        /// <summary>
        ///A test for IsCCS - false
        ///</summary>
        [TestMethod()]
        public void IsCCS_FalseTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel(); 
            bool expected = false; 
            bool actual;
            target.IsCCS = expected;
            actual = target.IsCCS;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsCCS - true
        ///</summary>
        [TestMethod()]
        public void IsCCS_TrueTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel();
            bool expected = true;
            bool actual;
            target.IsCCS = expected;
            actual = target.IsCCS;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsShow - false
        ///</summary>
        [TestMethod()]
        public void IsShow_FalseTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel(); 
            bool expected = false; 
            bool actual;
            target.IsShow = expected;
            actual = target.IsShow;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsShow - true
        ///</summary>
        [TestMethod()]
        public void IsShow_TrueTest()
        {
            BaseWindowViewModel target = new BaseWindowViewModel();
            bool expected = true;
            bool actual;
            target.IsShow = expected;
            actual = target.IsShow;
            Assert.AreEqual(expected, actual);
        }
    }
}
