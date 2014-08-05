using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for FilterButtonAreaTest and is intended
    ///to contain all FilterButtonAreaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FilterButtonAreaTest
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
        ///A test for FilterButtonArea Constructor
        ///</summary>
        [TestMethod()]
        public void FilterButtonAreaConstructorTest()
        {
            FilterButtonArea target = new FilterButtonArea();
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            FilterButtonArea target = new FilterButtonArea();
            target.InitializeComponent();
            
        }

        /// <summary>
        ///A test for LoadDataRemain
        ///</summary>
        [TestMethod()]
        public void LoadDataRemainTest()
        {
            FilterButtonArea target = new FilterButtonArea();
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);  
            IEnumerable data = list;                        
            target.LoadDataRemain(data);
            
        }

        /// <summary>
        ///A test for LoadDataSummary
        ///</summary>
        [TestMethod()]
        public void LoadDataSummaryTest()
        {
            FilterButtonArea target = new FilterButtonArea();
            ArrayList aList = new ArrayList();
            aList.Add(1);
            aList.Add(2);
            aList.Add(3);            
            IEnumerable data = aList;
            target.LoadDataSummary(data);            
        }
        //
        [TestMethod()]
        public void LoadDataSummaryTest1()
        {
            FilterButtonArea target = new FilterButtonArea();
            ArrayList aList = new ArrayList();
            aList.Add(1);
            aList.Add(2);
            aList.Add(3);
            aList.Add(1);
            aList.Add(2);
            aList.Add(3);
            aList.Add(1);
            aList.Add(2);
            aList.Add(3);
            aList.Add(1);
            aList.Add(2);
            aList.Add(3);
            IEnumerable data = aList;
            target.LoadDataSummary(data);
        }

        /// <summary>
        ///A test for OnIsDisplayThreeDotChanged
        ///</summary>
        [TestMethod()]
        public void OnIsDisplayThreeDotChangedTest()
        {
            DependencyObject o = null;
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs();
            FilterButtonArea.OnIsDisplayThreeDotChanged(o, args);
            
        }

        /// <summary>
        ///A test for OnItemsSourceRemainChanged
        ///</summary>
        [TestMethod()]
        public void OnItemsSourceRemainChangedTest()
        {
            DependencyObject o = new FilterButtonArea();     
            IList a = new ArrayList();
            a.Add(1);
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(FilterButtonArea_Accessor.ItemsSourceRemainProperty, new object(), a);
            FilterButtonArea.OnItemsSourceRemainChanged(o, args);
            
        }

        /// <summary>
        ///A test for OnItemsSourceSummaryChanged
        ///</summary>
        [TestMethod()]
        public void OnItemsSourceSummaryChangedTest()
        {
            DependencyObject o = new FilterButtonArea();
            IList list = new ArrayList();
            list.Add(1);
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(FilterButtonArea_Accessor.ItemsSourceSummaryProperty, new object(), list);
            FilterButtonArea.OnItemsSourceSummaryChanged(o, args);
            
        }

        /// <summary>
        ///A test for System.Windows.Markup.IComponentConnector.Connect
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ConnectTest()
        {
            IComponentConnector target = new FilterButtonArea();
            int connectionId = 0;
            object target1 = null;
            target.Connect(connectionId, target1);
            
        }

        /// <summary>
        ///A test for System.Windows.Markup.IStyleConnector.Connect
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ConnectTest1()
        {
            IStyleConnector target = new FilterButtonArea();
            int connectionId = 0;
            object target1 = null;
            target.Connect(connectionId, target1);
            
        }

        /// <summary>
        ///A test for ToggleButton_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ToggleButton_ClickTest()
        {
            FilterButtonArea_Accessor target = new FilterButtonArea_Accessor();
            object sender = null;
            RoutedEventArgs e = null;
            target.ToggleButton_Click(sender, e);
            
        }

        /// <summary>
        ///A test for IsDisplayThreeDot
        ///</summary>
        [TestMethod()]
        public void IsDisplayThreeDotTest()
        {
            FilterButtonArea target = new FilterButtonArea();
            bool expected = false;
            bool actual;
            target.IsDisplayThreeDot = expected;
            actual = target.IsDisplayThreeDot;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for ItemsSourceRemain
        ///</summary>
        [TestMethod()]
        public void ItemsSourceRemainTest()
        {
            FilterButtonArea target = new FilterButtonArea();
            IList expected = null;
            IList actual;
            target.ItemsSourceRemain = expected;
            actual = target.ItemsSourceRemain;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for ItemsSourceSummary
        ///</summary>
        [TestMethod()]
        public void ItemsSourceSummaryTest()
        {
            FilterButtonArea target = new FilterButtonArea();
            IList expected = null;
            IList actual;
            target.ItemsSourceSummary = expected;
            actual = target.ItemsSourceSummary;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for RemainList
        ///</summary>
        [TestMethod()]
        public void RemainListTest()
        {
            FilterButtonArea target = new FilterButtonArea();
            ObservableCollection<FilterButtonArea.DataPosition> expected = new ObservableCollection<FilterButtonArea.DataPosition>();
            ObservableCollection<FilterButtonArea.DataPosition> actual;
            target.RemainList = expected;
            actual = target.RemainList;
            Assert.AreEqual(expected, actual);
            
        }
    }
}
