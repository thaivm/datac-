using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Collections.ObjectModel;
using System.Linq;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for PatternItemKeysListDataGridViewModelTest and is intended
    ///to contain all PatternItemKeysListDataGridViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PatternItemKeysListDataGridViewModelTest
    {

        public static PrivateObject target;
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
            target = new PrivateObject(new PatternItemKeysListDataGridViewModel(null));
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
        ///A test for AddCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void AddCLTest()
        {
            List<KeywordModel> data = new List<KeywordModel>();
            KeywordModel model = new KeywordModel();
            model.Index = 1;
            model.Value = "test";
            data.Add(model);
            target.Invoke("LoadData", new object[] { data });
            target.Invoke("AddCL");
            ObservableCollection<KeywordModel> actual = (ObservableCollection<KeywordModel>)target.GetProperty("SourceList");
            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        ///A test for CreateNewItem
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateNewItemTest()
        {
            List<KeywordModel> data = new List<KeywordModel>();
            KeywordModel model = new KeywordModel();
            model.Index = 1;
            model.Value = "test";
            data.Add(model);
            target.Invoke("LoadData", new object[] { data });
            KeywordModel actual = (KeywordModel)target.Invoke("CreateNewItem");
            Assert.AreEqual(String.Empty, actual.Value);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DeleteTest()
        {
            List<KeywordModel> data = new List<KeywordModel>();
            KeywordModel model = new KeywordModel();
            model.Index = 1;
            model.Value = "test1";
            data.Add(model);
            KeywordModel model1 = new KeywordModel();
            model1.Index = 2;
            model1.Value = "test2";
            data.Add(model1);
            target.Invoke("LoadData", new object[] { data });
            List<KeywordModel> deleteList = new List<KeywordModel>();
            deleteList.Add(model1);
            target.Invoke("Delete", new object[] { deleteList.Cast<object>().ToList() });
            ObservableCollection<KeywordModel> actual = (ObservableCollection<KeywordModel>)target.GetProperty("SourceList");
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        public void LoadDataTest()
        {
            List<KeywordModel> data = new List<KeywordModel>();
            KeywordModel model = new KeywordModel();
            model.Index = 1;
            model.Value = "test";
            data.Add(model);
            target.Invoke("LoadData", new object[]{data});
            ObservableCollection<KeywordModel> actual = (ObservableCollection<KeywordModel>)target.GetProperty("SourceList");
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        ///A test for ValidateData
        ///</summary>
        [TestMethod()]
        public void ValidateDataSourceListIsNotNullOrEmptyTest()
        {
            List<KeywordModel> data = new List<KeywordModel>();
            KeywordModel model = new KeywordModel();
            model.Index = 1;
            model.Value = "test";
            data.Add(model);
            target.Invoke("LoadData", new object[] { data });
            string actual = (string)target.Invoke("ValidateData");
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ValidateDataSourceListIsNotNullOrEmptyAndElementOfSourceListIsEmptyTest()
        {
            List<KeywordModel> data = new List<KeywordModel>();
            KeywordModel model = new KeywordModel();
            model.Index = 1;
            model.Value = "";
            data.Add(model);
            target.Invoke("LoadData", new object[] { data });
            string actual = (string)target.Invoke("ValidateData");
            Assert.AreEqual("String must not be empty", actual);
        }
        [TestMethod()]
        public void ValidateUniqueStringTest()
        {
            List<KeywordModel> data = new List<KeywordModel>();
            KeywordModel model = new KeywordModel();
            model.Index = 1;
            model.Value = "test";
            data.Add(model);
            KeywordModel model1 = new KeywordModel();
            model1.Index = 2;
            model1.Value = "test";
            data.Add(model1);
            target.Invoke("LoadData", new object[] { data });
            string actual = (string)target.Invoke("ValidateData");
            Assert.AreEqual("String must be unique", actual);
        }
        [TestMethod()]
        public void ValidateLengthStringTest()
        {
            List<KeywordModel> data = new List<KeywordModel>();
            KeywordModel model = new KeywordModel();
            model.Index = 1;
            model.Value = "test";
            data.Add(model);
            KeywordModel model1 = new KeywordModel();
            model1.Index = 2;
            model1.Value = "123456789012345678901234567890123456789012345678901234567890";
            data.Add(model1);
            target.Invoke("LoadData", new object[] { data });
            string actual = (string)target.Invoke("ValidateData");
            Assert.AreEqual("Maximum length of String is 50 characters", actual);
        }
        [TestMethod()]
        public void ValidateDataSourceListIsNullTest()
        {
            string expected = "List of String must not be empty";
            string actual = (string)target.Invoke("ValidateData");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ValidateDataSourceListIsEmptyTest()
        {
            string expected = "List of String must not be empty";
            List<KeywordModel> data = new List<KeywordModel>();
            target.Invoke("LoadData", new object[] { data });
            string actual = (string)target.Invoke("ValidateData");
            Assert.AreEqual(expected, actual);
        }
    }
}
