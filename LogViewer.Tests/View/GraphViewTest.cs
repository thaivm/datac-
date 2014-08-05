using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using System.ComponentModel;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.WindowViewModelMapping;
using Moq;
using Moq.Protected;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for GraphViewTest and is intended
    ///to contain all GraphViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GraphViewTest
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
        ///A test for GraphView Constructor
        ///</summary>
        [TestMethod()]
        public void GraphViewConstructorTest()
        {
            GraphView target = new GraphView();
           // Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DataPoint_MouseDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataPoint_MouseDownTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            //MouseButtonEventArgs e = null; // TODO: Initialize to an appropriate value

            MouseButtonEventArgs e = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            e.RoutedEvent = UIElement.MouseLeftButtonDownEvent;
            e.Source = this;
            
            target.DataPoint_MouseDown(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }



        /// <summary>
        ///A test for DataPoint_MouseMove
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataPoint_MouseMoveTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseButtonEventArgs e = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            e.RoutedEvent = UIElement.MouseLeftButtonDownEvent;
            e.Source = this;
            target.DataPoint_MouseMove(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DataPoint_MouseUp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataPoint_MouseUpTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseButtonEventArgs e = null; // TODO: Initialize to an appropriate value
            target.DataPoint_MouseUp(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetElementPixelSize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetElementPixelSizeTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            FrameworkElement element = new FrameworkElement(); // TODO: Initialize to an appropriate value
            
          //  Size expected = new Size(); // TODO: Initialize to an appropriate value
            Size actual;
            actual = target.GetElementPixelSize(element);
          //  Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIsInitGraphFlag
        ///</summary>
        [TestMethod()]
        public void GetIsInitGraphFlagTest()
        {
            DependencyObject o = new DependencyObject(); // TODO: Initialize to an appropriate value
            object actual;
            actual = GraphView.GetIsInitGraphFlag(o);
            //Assert.AreEqual(expected, actual);
         //   Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitGraphMaxScale
        ///</summary>
        [TestMethod()]
        public void InitGraphMaxScaleTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            target._chartDateTimeAxis = new DateTimeAxis();
            target._chartDateTimeAxis.Maximum = new DateTime();
            target._chartDateTimeAxis.Minimum = new DateTime();

            target.InitGraphMaxScale();
          //  Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            GraphView target = new GraphView(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MenuItem_Click
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void MenuItem_ClickTest()
        //{
        //    GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
        //    object sender = new object(); // TODO: Initialize to an appropriate value
        //    RoutedEventArgs e = new RoutedEventArgs(); // TODO: Initialize to an appropriate value
        //    var width = 1600;
        //    var height = 1200;

        //    var newChart = new Chart { Width = width, Height = height, Title = target.chart.Title};
        //    target.MenuItem_Click(sender, e);
        //  //  Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        /// <summary>
        ///A test for OnIsInitGraphFlagChanged
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void OnIsInitGraphFlagChangedTest()
        {
            GraphView o = new GraphView();
            
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs();
            GraphView.OnIsInitGraphFlagChanged(o, args);
        }

        /// <summary>
        ///A test for Plot_PreviewMouseDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Plot_PreviewMouseDownTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseButtonEventArgs e = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left); // TODO: Initialize to an appropriate value
            target.Plot_PreviewMouseDown(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Plot_PreviewMouseEnter
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Plot_PreviewMouseEnterTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = new object(); // TODO: Initialize to an appropriate value
            MouseEventArgs e = new MouseEventArgs(Mouse.PrimaryDevice, 0);
            e.RoutedEvent = Mouse.MouseEnterEvent;

            target.Plot_PreviewMouseEnter(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Plot_PreviewMouseMove
        ///</summary>
        [TestMethod()]
        public void Plot_PreviewMouseMoveTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); 
            object sender = null;
            MouseEventArgs e = new MouseEventArgs(Mouse.PrimaryDevice, 0);
            e.RoutedEvent = Mouse.MouseEnterEvent;

            target.Plot_PreviewMouseMove(sender, e);
        }

        /// <summary>
        ///A test for Plot_PreviewMouseUp
        ///</summary>
        [TestMethod()]
        public void Plot_PreviewMouseUpTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = new GraphView(); // TODO: Initialize to an appropriate value
            MouseButtonEventArgs e = null; // TODO: Initialize to an appropriate value
            target.Plot_PreviewMouseUp(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Plot_PreviewMouseWheel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Plot_PreviewMouseWheelTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseWheelEventArgs e = new MouseWheelEventArgs(Mouse.PrimaryDevice,0,1); // TODO: Initialize to an appropriate value
            target.Plot_PreviewMouseWheel(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetIfNotNull
        ///</summary>
        public void SetIfNotNullTestHelper<T>()
            where T : struct
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            T des = default(T); // TODO: Initialize to an appropriate value
         //   T desExpected = default(T); // TODO: Initialize to an appropriate value
            Nullable<T> source = new Nullable<T>(); // TODO: Initialize to an appropriate value
            target.SetIfNotNull<T>(ref des, source);
           // Assert.AreEqual(desExpected, des);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetIfNotNullTest()
        {
           // Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            //        "Please call SetIfNotNullTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for SetIsInitGraphFlag
        ///</summary>
        [TestMethod()]
        public void SetIsInitGraphFlagTest()
        {
            GraphView o = new GraphView(); 
            object value = false; 
            GraphView.SetIsInitGraphFlag(o, value);
        }

        /// <summary>
        ///A test for SetMaxMinAxis
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetMaxMinAxisTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            DateTime newMax = new DateTime(2008, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            DateTime newMin = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime upLimit = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime downLimit = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime upLimit1 = new DateTime(2008, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            DateTime downLimit1 = new DateTime(2009, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            DateTime standardMax = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime standardMax1 = new DateTime(2008, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            DateTime standardMin = new DateTime(2008, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            TimeSpan deltaMinLimit = new TimeSpan(); // TODO: Initialize to an appropriate value
            DateTimeAxis axis = new DateTimeAxis(); // TODO: Initialize to an appropriate value
            bool isMouseDrag = true; // TODO: Initialize to an appropriate value
            target.SetMaxMinAxis(newMax, newMin, upLimit, downLimit, standardMax, standardMin, deltaMinLimit, axis, isMouseDrag);
            target.SetMaxMinAxis(newMax, newMin, upLimit, downLimit, standardMax1, standardMin, deltaMinLimit, axis, isMouseDrag);

            isMouseDrag = false;
            target.SetMaxMinAxis(newMax, newMin, upLimit, downLimit, standardMax1, standardMin, deltaMinLimit, axis, isMouseDrag);
            target.SetMaxMinAxis(new DateTime(), newMin, upLimit, new DateTime(2002, 3, 9, 16, 5, 7, 123), standardMax1, standardMin, deltaMinLimit, axis, isMouseDrag);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }


        /// <summary>
        ///A test for SetMaxMinAxis in false case
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetMaxMinAxisTest_FalseCase()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            DateTime newMax = new DateTime(2010, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            DateTime newMin = new DateTime(2007, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            DateTime upLimit = new DateTime(2009, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            DateTime downLimit = new DateTime(2008, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            DateTime standardMax = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime standardMin = new DateTime(2008, 3, 9, 16, 5, 7, 123); // TODO: Initialize to an appropriate value
            TimeSpan deltaMinLimit = new TimeSpan(); // TODO: Initialize to an appropriate value
            DateTimeAxis axis = new DateTimeAxis(); // TODO: Initialize to an appropriate value
            bool isMouseDrag = false; // TODO: Initialize to an appropriate value
            target.SetMaxMinAxis(newMax, newMin, upLimit, downLimit, standardMax, standardMin, deltaMinLimit, axis, isMouseDrag);

            // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetMaxMinAxis
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetMaxMinAxisTest1()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            double newMax = 0F; // TODO: Initialize to an appropriate value
            double newMin = 0F; // TODO: Initialize to an appropriate value
            double upLimit = 0F; // TODO: Initialize to an appropriate value
            double downLimit = 0F; // TODO: Initialize to an appropriate value
            double standardMax = 0F; // TODO: Initialize to an appropriate value
            double standardMin = 0F; // TODO: Initialize to an appropriate value
            double deltaMinLimit = 0F; // TODO: Initialize to an appropriate value
            LinearAxis axis = null; // TODO: Initialize to an appropriate value
            bool isMouseDrag = false; // TODO: Initialize to an appropriate value
            target.SetMaxMinAxis(newMax, newMin, upLimit, downLimit, standardMax, standardMin, deltaMinLimit, axis, isMouseDrag);
            target.SetMaxMinAxis(5, 1, upLimit, downLimit, standardMax, standardMin, 2, axis, true);
            target.SetMaxMinAxis(5, 1, upLimit, downLimit, 6, 2, 2, axis, true);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Window_Closing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Window_ClosingTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            CancelEventArgs e = null; // TODO: Initialize to an appropriate value
            target.Window_Closing(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Window_SizeChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Window_SizeChangedTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            SizeChangedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.Window_SizeChanged(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ZoomChart
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ZoomChartTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            int delta = 1; // TODO: Initialize to an appropriate value
            target.FirstLineAxis.Maximum = 12;
            target.FirstLineAxis.Minimum = 1;
            target._upLimitScaleFirstY = 2;
            target._upLimitScaleSecondY = 2;
            target.SecondLineAxis.Maximum = 12;
            target.SecondLineAxis.Minimum = 1;

            target._chartDateTimeAxis = new DateTimeAxis();
            target._chartDateTimeAxis.Maximum = new DateTime();
            target._chartDateTimeAxis.Minimum = new DateTime();
         //   target._chartDateTimeAxis.Maximum =  new DateTime();
          //  target._chartDateTimeAxis.Minimum = new DateTime();
            target.ZoomChart(delta);
          
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ZoomChart smaller than 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ZoomChartTest_Smaller()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            int delta = -1; // TODO: Initialize to an appropriate value
            target.FirstLineAxis.Maximum = 2;
            target.FirstLineAxis.Minimum = 1;
            target._upLimitScaleFirstY = 2;
            target._upLimitScaleSecondY = 2;
            target.SecondLineAxis.Maximum = 2;
            target.SecondLineAxis.Minimum = 1;
            target._chartDateTimeAxis = new DateTimeAxis();
            target._chartDateTimeAxis.Maximum = new DateTime();
            target._chartDateTimeAxis.Minimum = new DateTime();

            target.ZoomChart(delta);

            // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ChartDateTimeAxis
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ChartDateTimeAxisTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            DateTimeAxis actual;
            actual = target.ChartDateTimeAxis;
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeltaLimitScaleDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DeltaLimitScaleDateTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            TimeSpan actual;
            target._isStandardScaleChanged = true;
            actual = target.DeltaLimitScaleDate;
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeltaLimitScaleFirstY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DeltaLimitScaleFirstYTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            double actual;
            target._isStandardScaleChanged = true;
            actual = target.DeltaLimitScaleFirstY;
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeltaLimitScaleSecondY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DeltaLimitScaleSecondYTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            double actual;
            target._isStandardScaleChanged = true;
            actual = target.DeltaLimitScaleSecondY;
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeltaZoomEachPolar
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DeltaZoomEachPolarTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.DeltaZoomEachPolar;
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DownLimitScaleDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DownLimitScaleDateTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target._isStandardScaleChanged = true;
            actual = target.DownLimitScaleDate;
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DownLimitScaleFirstY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DownLimitScaleFirstYTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            double actual;
            target._isStandardScaleChanged = true;
            actual = target.DownLimitScaleFirstY;
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DownLimitScaleSecondY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DownLimitScaleSecondYTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            double actual;
            target._isStandardScaleChanged = true;
            actual = target.DownLimitScaleSecondY;
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpLimitScaleDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UpLimitScaleDateTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target._isStandardScaleChanged = true;
            actual = target.UpLimitScaleDate;
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpLimitScaleFirstY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UpLimitScaleFirstYTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            double actual;
            target._isStandardScaleChanged = true;
            actual = target.UpLimitScaleFirstY;
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpLimitScaleSecondY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UpLimitScaleSecondYTest()
        {
            GraphView_Accessor target = new GraphView_Accessor(); // TODO: Initialize to an appropriate value
            double actual;
            target._isStandardScaleChanged = true;
            actual = target.UpLimitScaleSecondY;
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
