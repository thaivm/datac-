using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Collections.ObjectModel;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseGraphParameterDataGridViewModelTest and is intended
    ///to contain all BaseGraphParameterDataGridViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseGraphParameterDataGridViewModelTest
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


        //internal virtual BaseGraphParameterDataGridViewModel_Accessor CreateBaseGraphParameterDataGridViewModel_Accessor()
        //{
        //    BaseGraphParameterDataGridViewModel_Accessor target = null;
        //    return target;
        //}

        /// <summary>
        ///A test for CanAdd
        ///</summary>
        //CanAddTest_True
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanAddTest_True()
        {
            object obj = new object();
            PrivateObject param0 = new PrivateObject(new EventDataGridViewModel(obj));
            BaseGraphParameterDataGridViewModel_Accessor target = new BaseGraphParameterDataGridViewModel_Accessor(param0);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            list.Add(new GraphParamSetting());
            target._sourceList = list;
            bool expected = true;
            bool actual;
            actual = target.CanAdd();
            Assert.AreEqual(expected, actual);            
        }
        //CanAddTest_False
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanAddTest_False()
        {
            object obj = new object();
            PrivateObject param0 = new PrivateObject(new EventDataGridViewModel(obj));
            BaseGraphParameterDataGridViewModel_Accessor target = new BaseGraphParameterDataGridViewModel_Accessor(param0);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            list.Add(new GraphParamSetting());
            target.SourceList = list;
            bool expected = false;
            bool actual;
            actual = target.CanAdd();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateData  String length is empty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest_StringValueLengthEmpty()
        {
            PrivateObject param0 = new PrivateObject(new EventDataGridViewModel(new object()));
            BaseGraphParameterDataGridViewModel_Accessor target = new BaseGraphParameterDataGridViewModel_Accessor(param0);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting();
            item.StringValue = string.Empty;
            item.Name = "djflkssdlkfjlakjd";
            list.Add(item);
            target.SourceList = list;
            string expected = "Object must not be empty";
            string actual;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateData  String length > 50
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest_StringValueLength()
        {
            PrivateObject param0 = new PrivateObject(new EventDataGridViewModel(new object()));
            BaseGraphParameterDataGridViewModel_Accessor target = new BaseGraphParameterDataGridViewModel_Accessor(param0);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting();
            item.StringValue = "aklsdlkjsdlfkjsdlkfjlskdjflksdjflsdjflksjdlfkjsdlkfjlakjd;lkfjas;lkfj;alskjf;lkasjd;lfkj;eljweoirwoeijflksdjflksdjf;lkajs;flksjd;flkjsa;lkfjs;lkfj;sldkjflsjdf";
            item.Name = "djflkssdlkfjlakjd";
            list.Add(item);
            target.SourceList = list;
            string expected = "Maximum length of Object is 50 characters";
            string actual;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for ValidateData - Name legth is empty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest_NameLengthEmpty()
        {
            PrivateObject param0 = new PrivateObject(new EventDataGridViewModel(new object()));
            BaseGraphParameterDataGridViewModel_Accessor target = new BaseGraphParameterDataGridViewModel_Accessor(param0);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting();
            item.StringValue = "aklsdlkjsdlfkjsdlkfjlskdjflksdjflsdjflksjdlfkjsdlkfjlakjd;lkfjas;lkfj;alskjf;lkasjd;lfkj;eljweoirwoeijflksdjflksdjf;lkajs;flksjd;flkjsa;lkfjs;lkfj;sldkjflsjdf";
            item.Name = string.Empty;
            list.Add(item);
            target.SourceList = list;
            string expected = "Name must not be empty";
            string actual;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateData - Name legth > 50
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest_NameLength()
        {
            PrivateObject param0 = new PrivateObject(new EventDataGridViewModel(new object()));
            BaseGraphParameterDataGridViewModel_Accessor target = new BaseGraphParameterDataGridViewModel_Accessor(param0);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting();
            item.StringValue = "aklsdlkjsdlfkjsdlkfjlskdjflksdjflsdjflksjdlfkjsdlkfjlakjd;lkfjas;lkfj;alskjf;lkasjd;lfkj;eljweoirwoeijflksdjflksdjf;lkajs;flksjd;flkjsa;lkfjs;lkfj;sldkjflsjdf";
            item.Name = "aklsdlkjsdlfkjsdlkfjlskdjflksdjflsdjflksjdlfkjsdlkfjlakjdaklsdlkjsdlfkjsdlkfjlskdjflksdjflsdjflksjdlfkjsdlkfjlakjdaklsdlkjsdlfkjsdlkfjlskdjflksdjflsdjflksjdlfkjsdlkfjlakjd";
            list.Add(item);
            target.SourceList = list;
            string expected = "Maximum length of Name is 50 characters";
            string actual;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateData - Name is duplicate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest_NameDuplicate()
        {
            PrivateObject param0 = new PrivateObject(new EventDataGridViewModel(new object()));
            BaseGraphParameterDataGridViewModel_Accessor target = new BaseGraphParameterDataGridViewModel_Accessor(param0);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting { StringValue = "String", Name = "Name" };
            GraphParamSetting item1 = new GraphParamSetting { StringValue = "String", Name = "Name" };
            list.Add(item);
            list.Add(item1);
            target.SourceList = list;
            string expected = "Name must be unique";
            string actual;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateData - Name is not duplicate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest_NameNotDuplicate()
        {
            PrivateObject param0 = new PrivateObject(new EventDataGridViewModel(new object()));
            BaseGraphParameterDataGridViewModel_Accessor target = new BaseGraphParameterDataGridViewModel_Accessor(param0);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting { StringValue = "String", Name = "Name" };
            GraphParamSetting item1 = new GraphParamSetting { StringValue = "String1", Name = "Name1" };
            list.Add(item);
            list.Add(item1);
            target.SourceList = list;
            string expected = string.Empty;
            string actual;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);
        }
    }
}
