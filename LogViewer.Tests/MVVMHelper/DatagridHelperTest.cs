using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using Microsoft.Windows.Controls;
using LogViewer.Model;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for DatagridHelperTest and is intended
    ///to contain all DatagridHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatagridHelperTest
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
        ///A test for FindVisualChild
        ///</summary>
        [TestMethod()]
        public void FindVisualChildTest()
        {
            DataGrid o = new DataGrid();
            List<CCSLogRecord> list = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.Id = "1";
            record.HostName = "test";
            record.AdditionalInfo = "";
            record.ClassName = "";
            record.Content = "test";
            record.DateTime = DateTime.Parse("2013-12-12 12:12:12.000");
            record.Line = 1;
            record.Mode = "";
            record.Module = "";
            record.PersonalInfo = "";
            record.ThreadId = "123";
            record.Type = "E";
            list.Add(record);
            o.ItemsSource = list;
            DependencyObject actual;
            actual = DatagridHelper_Accessor.FindVisualChild<DependencyObject>(o);
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        ///A test for GetCell
        ///</summary>
        [TestMethod()]
        public void GetCellTest()
        {
            DataGrid o = new DataGrid();
            List<CCSLogRecord> list = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.Id = "1";
            record.HostName = "test";
            record.AdditionalInfo = "";
            record.ClassName = "";
            record.Content = "test";
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            record.Line = 1;
            record.Mode = "";
            record.Module = "";
            record.PersonalInfo = "";
            record.ThreadId = "123";
            record.Type = "E";
            list.Add(record);
            o.ItemsSource = list;
            DataGridRow rowContainer = new DataGridRow();
            int column = 0; 
            DataGridCell expected = null;
            DataGridCell actual;
            actual = DatagridHelper_Accessor.GetCell(o, rowContainer, column);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetClickedRow
        ///</summary>
        [TestMethod()]
        public void GetClickedRowTest()
        {
            DataGrid o = new DataGrid();
            object expected = null;
            object actual;
            DatagridHelper.SetClickedRow(o, expected);
            actual = DatagridHelper.GetClickedRow(o);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDoubleClickedRow
        ///</summary>
        [TestMethod()]
        public void GetDoubleClickedRowTest()
        {
            DataGrid o = new DataGrid();
            object expected = null; 
            object actual;
            DatagridHelper.SetDoubleClickedRow(o, expected);
            actual = DatagridHelper.GetDoubleClickedRow(o);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetRecordToFollow
        ///</summary>
        [TestMethod()]
        public void GetRecordToFollowTest()
        {
            DataGrid o = new DataGrid();
            object expected = null; 
            object actual;
            DatagridHelper.SetRecordToFollow(o, expected);
            actual = DatagridHelper.GetRecordToFollow(o);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetRecordToShow
        ///</summary>
        [TestMethod()]
        public void GetRecordToShowTest()
        {
            DataGrid o = new DataGrid();
            object expected = null;
            object actual;
            DatagridHelper.SetRecordToShow(o, expected);
            actual = DatagridHelper.GetRecordToShow(o);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetRefreshData
        ///</summary>
        [TestMethod()]
        public void GetRefreshDataTest()
        {
            DataGrid o = new DataGrid();
            object expected = true;
            object actual;
            DatagridHelper.SetRefreshData(o, expected);
            actual = DatagridHelper.GetRefreshData(o);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OnRecordToFollowChanged
        ///</summary>
        [TestMethod()]
        public void OnRecordToFollowChangedRowIsNotNullTest()
        {
            DataGrid o = new DataGrid();
            List<CCSLogRecord> list = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.Id = "1";
            record.HostName = "test";
            record.AdditionalInfo = "";
            record.ClassName = "";
            record.Content = "test";
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            record.Line = 1;
            record.Mode = "";
            record.Module = "";
            record.PersonalInfo = "";
            record.ThreadId = "123";
            record.Type = "E";
            list.Add(record);
            o.ItemsSource = list;
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(DatagridHelper_Accessor.RecordToFollowProperty, null, record);
            DatagridHelper.OnRecordToFollowChanged(o, args);
        }
        [TestMethod()]
        public void OnRecordToFollowChangedRowIsNullTest()
        {
            DataGrid o = new DataGrid();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs();
            DatagridHelper.OnRecordToFollowChanged(o, args);
        }
        /// <summary>
        ///A test for OnRecordToShowChanged
        ///</summary>
        [TestMethod()]
        public void OnRecordToShowChangedRowIsNullTest()
        {
            DataGrid o = new DataGrid();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(); 
            DatagridHelper.OnRecordToShowChanged(o, args);
        }
        [TestMethod()]
        public void OnRecordToShowChangedRowIsNotNullTest()
        {
            DataGrid o = new DataGrid();
            List<CCSLogRecord> list = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.Id = "1";
            record.HostName = "test";
            record.AdditionalInfo = "";
            record.ClassName = "";
            record.Content = "test";
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            record.Line = 1;
            record.Mode = "";
            record.Module = "";
            record.PersonalInfo = "";
            record.ThreadId = "123";
            record.Type = "E";
            list.Add(record);
            o.ItemsSource = list;
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(DatagridHelper_Accessor.RecordToShowProperty, null, record);
            DatagridHelper.OnRecordToShowChanged(o, args);
        }
        /// <summary>
        ///A test for OnRefreshDataChanged
        ///</summary>
        [TestMethod()]
        public void OnRefreshDataChangedTest()
        {
            DataGrid o = new DataGrid();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(DatagridHelper_Accessor.RefreshDataProperty, false, true);
            DatagridHelper.OnRefreshDataChanged(o, args);
            Assert.IsFalse((bool)DatagridHelper.GetRefreshData(o));
        }

        /// <summary>
        ///A test for SetClickedRow
        ///</summary>
        [TestMethod()]
        public void SetClickedRowTest()
        {
            DataGrid o = new DataGrid();
            object value = null;
            DatagridHelper.SetClickedRow(o, value);
            Assert.IsNull(DatagridHelper.GetClickedRow(o));
        }

        /// <summary>
        ///A test for SetDoubleClickedRow
        ///</summary>
        [TestMethod()]
        public void SetDoubleClickedRowTest()
        {
            DataGrid o = new DataGrid();
            object value = null;
            DatagridHelper.SetDoubleClickedRow(o, value);
            Assert.IsNull(DatagridHelper.GetDoubleClickedRow(o));
        }

        /// <summary>
        ///A test for SetRecordToFollow
        ///</summary>
        [TestMethod()]
        public void SetRecordToFollowTest()
        {
            DataGrid o = new DataGrid();
            object value = null;
            DatagridHelper.SetRecordToFollow(o, value);
            Assert.IsNull(DatagridHelper.GetRecordToFollow(o));
        }

        /// <summary>
        ///A test for SetRecordToShow
        ///</summary>
        [TestMethod()]
        public void SetRecordToShowTest()
        {
            DataGrid o = new DataGrid();
            object value = null;
            DatagridHelper.SetRecordToShow(o, value);
            Assert.IsNull(DatagridHelper.GetRecordToShow(o));
        }

        /// <summary>
        ///A test for SetRefreshData
        ///</summary>
        [TestMethod()]
        public void SetRefreshDataTest()
        {
            DataGrid o = new DataGrid();
            object value = true;
            DatagridHelper.SetRefreshData(o, value);
            Assert.IsTrue((bool)DatagridHelper.GetRefreshData(o));
        }
    }
}
