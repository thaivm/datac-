using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Collections.Generic;
using System.Windows.Documents;
using LogViewer.Business;

namespace LogViewer.Tests
{


    /// <summary>
    ///This is a test class for AnalyzedErrorActionItemTest and is intended
    ///to contain all AnalyzedErrorActionItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AnalyzedPatternResultItem
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {

        }
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
            ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.Register<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.Register<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
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
        ///A test for AnalyzedPatternResultItem Constructor
        ///</summary>
        [TestMethod()]
        public void AnalyzedPatternResultItemContructorTest()
        {
            AnalyzedPatternResultItem_Accessor<CCSLogRecord> target = new AnalyzedPatternResultItem_Accessor<CCSLogRecord>();
            Assert.IsNotNull(target._foundPattern);
            Assert.IsNotNull(target._rootKey);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            AnalyzedPatternResultItem_Accessor<CCSLogRecord> target = new AnalyzedPatternResultItem_Accessor<CCSLogRecord>();
            string expected = "Name";
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            AnalyzedPatternResultItem_Accessor<CCSLogRecord> target = new AnalyzedPatternResultItem_Accessor<CCSLogRecord>();
            Assert.AreEqual(target._foundPattern.Keys.Count, target.Count);
        }

        /// <summary>
        ///A test for LogRecords
        ///</summary>
        [TestMethod()]
        public void LogRecordsTest()
        {
            AnalyzedPatternResultItem_Accessor<CCSLogRecord> target = new AnalyzedPatternResultItem_Accessor<CCSLogRecord>();
            Assert.AreEqual(target._foundPattern.Keys.Count, target.LogRecords.Count);
        }

        /// <summary>
        ///A test for RootKey
        ///</summary>
        [TestMethod()]
        public void RootKeyTest()
        {
            AnalyzedPatternResultItem_Accessor<CCSLogRecord> target = new AnalyzedPatternResultItem_Accessor<CCSLogRecord>();
            Dictionary<CCSLogRecord, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>> expected = 
                new Dictionary<CCSLogRecord, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>();
            target.RootKey = expected;
            var actual = target.RootKey;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FoundPattern
        ///</summary>
        [TestMethod()]
        public void FoundPatternTest()
        {
            AnalyzedPatternResultItem_Accessor<CCSLogRecord> target = new AnalyzedPatternResultItem_Accessor<CCSLogRecord>();
            Assert.AreEqual(target._foundPattern, target.FoundPattern);
        }

        /// <summary>
        ///A test for PatternItem
        ///</summary>
        [TestMethod()]
        public void PatternItemTest()
        {
            AnalyzedPatternResultItem_Accessor<CCSLogRecord> target = new AnalyzedPatternResultItem_Accessor<CCSLogRecord>();
            PatternItemSetting expected = new PatternItemSetting();
            target.PatternItem = expected;
            var actual = target.PatternItem;
            Assert.AreEqual(expected, actual);
        }
    }
}
