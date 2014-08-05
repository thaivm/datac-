using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Interop;
using System.Windows.Controls.DataVisualization.Charting.Primitives;


namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for ShowGraphView.xaml
    /// </summary>
    public partial class GraphView : Window
    {
        const int DELTASIZE = 100;
        const double MaxScale = 2;
        const double MinScale = 0.5;
        const double DeltaZoom = 0.25;

        private static readonly DependencyProperty IsInitGraphFlagProperty =
          DependencyProperty.RegisterAttached("IsInitGraphFlag", typeof(bool), typeof(GraphView),
          new PropertyMetadata(false, new PropertyChangedCallback(OnIsInitGraphFlagChanged)));
        public static object GetIsInitGraphFlag(DependencyObject o)
        {
            return o.GetValue(IsInitGraphFlagProperty);
        }
        public static void SetIsInitGraphFlag(DependencyObject o, object value)
        {
            o.SetValue(IsInitGraphFlagProperty, value);
        }
        public static void OnIsInitGraphFlagChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //var source = (DependencyObject)sender; 
            //BindingOperations
            var graphView = o as GraphView;
            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(new Action(() =>
            {
                graphView.InitGraphMaxScale();
            }), priority: System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        public void InitGraphMaxScale()
        {
            SetIfNotNull(ref _standardScaleMaxDate, ChartDateTimeAxis.Maximum);
            SetIfNotNull(ref _standardScaleMinDate, ChartDateTimeAxis.Minimum);
            SetIfNotNull(ref _standardScaleMaxFirstY, FirstLineAxis.Maximum);
            SetIfNotNull(ref _standardScaleMinFirstY, FirstLineAxis.Minimum);
            SetIfNotNull(ref _standardScaleMaxSecondY, SecondLineAxis.Maximum);
            SetIfNotNull(ref _standardScaleMinSecondY, SecondLineAxis.Minimum);
            _isStandardScaleChanged = true;
        }

        private void SetIfNotNull<T>(ref T des, T? source) where T : struct,IComparable
        {
            if (source != null)
            {
                des = source.Value;
            }
        }

        double _standardScaleMaxFirstY;
        double _standardScaleMinFirstY;
        double _standardScaleMaxSecondY;
        double _standardScaleMinSecondY;
        DateTime _standardScaleMaxDate;
        DateTime _standardScaleMinDate;

        bool _isStandardScaleChanged;
        double _upLimitScaleFirstY;
        double UpLimitScaleFirstY
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxFirstY - _standardScaleMinFirstY;
                    _upLimitScaleFirstY = _standardScaleMaxFirstY + deltaRange / 2;
                }
                return _upLimitScaleFirstY;
            }
        }

        double _downLimitScaleFirstY;
        double DownLimitScaleFirstY
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxFirstY - _standardScaleMinFirstY;
                    _downLimitScaleFirstY = _standardScaleMinFirstY - deltaRange / 2;
                }
                return _downLimitScaleFirstY;
            }
        }

        double _deltaLimitScaleFirstY;
        double DeltaLimitScaleFirstY
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxFirstY - _standardScaleMinFirstY;
                    _deltaLimitScaleFirstY = deltaRange / 2;
                }
                return _deltaLimitScaleFirstY;
            }
        }

        double _upLimitScaleSecondY;
        double UpLimitScaleSecondY
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxSecondY - _standardScaleMinSecondY;
                    _upLimitScaleSecondY = _standardScaleMaxSecondY + deltaRange / 2;
                }
                return _upLimitScaleSecondY;
            }
        }

        double _downLimitScaleSecondY;
        double DownLimitScaleSecondY
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxSecondY - _standardScaleMinSecondY;
                    _downLimitScaleSecondY = _standardScaleMinSecondY - deltaRange / 2;
                }
                return _downLimitScaleSecondY;
            }
        }

        double _deltaLimitScaleSecondY;
        double DeltaLimitScaleSecondY
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxSecondY - _standardScaleMinSecondY;
                    _deltaLimitScaleSecondY = deltaRange / 2;
                }
                return _deltaLimitScaleSecondY;
            }
        }

        DateTime _upLimitScaleDate;
        DateTime UpLimitScaleDate
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxDate - _standardScaleMinDate;
                    _upLimitScaleDate = _standardScaleMaxDate.AddMinutes(deltaRange.TotalMinutes / 2);
                }
                return _upLimitScaleDate;
            }
        }

        DateTime _downLimitScaleDate;
        DateTime DownLimitScaleDate
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxDate - _standardScaleMinDate;
                    _downLimitScaleDate = _standardScaleMinDate.AddMinutes(0 - deltaRange.TotalMinutes / 2);
                }
                return _downLimitScaleDate;
            }
        }

        TimeSpan _deltaLimitScaleDate;
        TimeSpan DeltaLimitScaleDate
        {
            get
            {
                if (_isStandardScaleChanged)
                {
                    var deltaRange = _standardScaleMaxDate - _standardScaleMinDate;
                    _deltaLimitScaleDate = new TimeSpan(0, Convert.ToInt32(deltaRange.TotalMinutes / 2), 0);
                }
                return _deltaLimitScaleDate;
            }
        }

        double DeltaZoomEachPolar
        {
            get
            {
                return DeltaZoom / 2;
            }
        }

        DateTimeAxis _chartDateTimeAxis;
        DateTimeAxis ChartDateTimeAxis
        {
            get
            {
                if (_chartDateTimeAxis == null)
                    _chartDateTimeAxis = chart.FindName("dateTimeAxis") as DateTimeAxis;
                return _chartDateTimeAxis;
            }
        }

        public GraphView()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBoxManager.Unregister();
            System.Windows.Forms.MessageBoxManager.Yes = LogViewer.Properties.Resources.Yes;
            System.Windows.Forms.MessageBoxManager.No = LogViewer.Properties.Resources.No;

            //Register manager
            System.Windows.Forms.MessageBoxManager.Register();
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = LogViewer.Model.ConfigValue.ExportedGraphImageFileName;
            dlg.DefaultExt = LogViewer.Model.ConfigValue.ExportedGraphImageFileExtension;
            dlg.Filter = LogViewer.Model.ConfigValue.ExportedGraphImageFileFilter;
            var result = dlg.ShowDialog();
            if (result.Value)
            {
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
              (int)chart.ActualWidth,
              (int)chart.ActualHeight,
              96d,
              96d,
              PixelFormats.Pbgra32);
                Size size = new Size(chart.ActualWidth, chart.ActualHeight);

                Rectangle rect = new Rectangle()
                {
                    Width = chart.ActualWidth,
                    Height = chart.ActualHeight,
                    Fill = new VisualBrush(chart)
                };
                rect.Measure(size);
                rect.Arrange(new Rect(size));
                rect.UpdateLayout();

                renderBitmap.Render(rect);
                using (FileStream outStream = new FileStream(dlg.FileName, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    encoder.Save(outStream);
                    outStream.Close();
                }
            }
        }

        private void Plot_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) > 0)
            {
                ZoomChart(e.Delta);
                e.Handled = true;
            }
        }

        //private void Plot_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if ((Keyboard.Modifiers & ModifierKeys.Control) > 0)
        //    {
        //        if (e.Key == Key.OemPlus)
        //            ZoomChart(1);
        //        else if (e.Key == Key.OemMinus)
        //            ZoomChart(-1);
        //    }
        //}

        private void ZoomChart(int delta)
        {

            if (delta > 0)
            {
                if (FirstLineAxis.Maximum != null && FirstLineAxis.Minimum != null)
                {
                    var newMax = FirstLineAxis.Maximum.Value + (FirstLineAxis.Maximum.Value - FirstLineAxis.Minimum.Value) * DeltaZoomEachPolar;
                    var newMin = FirstLineAxis.Minimum.Value - (FirstLineAxis.Maximum.Value - FirstLineAxis.Minimum.Value) * DeltaZoomEachPolar;
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleFirstY, DownLimitScaleFirstY, _standardScaleMaxFirstY,
                        _standardScaleMinFirstY, DeltaLimitScaleFirstY, FirstLineAxis);
                }

                if (SecondLineAxis.Maximum != null && SecondLineAxis.Minimum != null)
                {
                    var newMax = SecondLineAxis.Maximum.Value + (SecondLineAxis.Maximum.Value - SecondLineAxis.Minimum.Value) * DeltaZoomEachPolar;
                    var newMin = SecondLineAxis.Minimum.Value - (SecondLineAxis.Maximum.Value - SecondLineAxis.Minimum.Value) * DeltaZoomEachPolar;
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleSecondY, DownLimitScaleSecondY, _standardScaleMaxSecondY,
                        _standardScaleMinSecondY, DeltaLimitScaleSecondY, SecondLineAxis);
                }

                if (ChartDateTimeAxis.Maximum != null && ChartDateTimeAxis.Minimum != null)
                {
                    var newMax = ChartDateTimeAxis.Maximum.Value.Add(
                        new TimeSpan(0,
                        Convert.ToInt32((ChartDateTimeAxis.Maximum.Value - ChartDateTimeAxis.Minimum.Value)
                        .TotalMinutes * DeltaZoomEachPolar), 0));
                    var newMin = ChartDateTimeAxis.Minimum.Value.Subtract(
                        new TimeSpan(0,
                        Convert.ToInt32((ChartDateTimeAxis.Maximum.Value - ChartDateTimeAxis.Minimum.Value)
                        .TotalMinutes * DeltaZoomEachPolar), 0));
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleDate, DownLimitScaleDate, _standardScaleMaxDate,
                        _standardScaleMinDate, DeltaLimitScaleDate, ChartDateTimeAxis);
                }
                _isStandardScaleChanged = false;

            }
            else if (delta < 0)
            {
                if (FirstLineAxis.Maximum != null && FirstLineAxis.Minimum != null)
                {
                    var newMax = FirstLineAxis.Maximum.Value - (FirstLineAxis.Maximum.Value - FirstLineAxis.Minimum.Value) * DeltaZoomEachPolar;
                    var newMin = FirstLineAxis.Minimum.Value + (FirstLineAxis.Maximum.Value - FirstLineAxis.Minimum.Value) * DeltaZoomEachPolar;
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleFirstY, DownLimitScaleFirstY, _standardScaleMaxFirstY,
                        _standardScaleMinFirstY, DeltaLimitScaleFirstY, FirstLineAxis);
                }
                if (SecondLineAxis.Maximum != null && SecondLineAxis.Minimum != null)
                {
                    var newMax = SecondLineAxis.Maximum.Value - (SecondLineAxis.Maximum.Value - SecondLineAxis.Minimum.Value) * DeltaZoomEachPolar;
                    var newMin = SecondLineAxis.Minimum.Value + (SecondLineAxis.Maximum.Value - SecondLineAxis.Minimum.Value) * DeltaZoomEachPolar;
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleSecondY, DownLimitScaleSecondY, _standardScaleMaxSecondY,
                        _standardScaleMinSecondY, DeltaLimitScaleSecondY, SecondLineAxis);
                }
                if (ChartDateTimeAxis.Maximum != null && ChartDateTimeAxis.Minimum != null)
                {
                    var newMax = ChartDateTimeAxis.Maximum.Value.Subtract(new TimeSpan(0,
                        Convert.ToInt32((ChartDateTimeAxis.Maximum.Value - ChartDateTimeAxis.Minimum.Value)
                        .TotalMinutes * DeltaZoomEachPolar), 0));
                    var newMin = ChartDateTimeAxis.Minimum.Value.Add(new TimeSpan(0,
                        Convert.ToInt32((ChartDateTimeAxis.Maximum.Value - ChartDateTimeAxis.Minimum.Value)
                        .TotalMinutes * DeltaZoomEachPolar), 0));
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleDate, DownLimitScaleDate, _standardScaleMaxDate,
                        _standardScaleMinDate, DeltaLimitScaleDate, ChartDateTimeAxis);
                }
                _isStandardScaleChanged = false;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void SetMaxMinAxis(double newMax, double newMin, double upLimit,
            double downLimit, double standardMax, double standardMin, double deltaMinLimit, LinearAxis axis, bool isMouseDrag = false)
        {
            var deltaMaxMin = newMax - newMin;
            if (deltaMaxMin > deltaMinLimit)
            {
                if (isMouseDrag)
                {
                    if (standardMax < newMax)
                    {
                        return;
                    }
                    else if (standardMin > newMin)
                    {
                        return;
                    }
                }
                else
                {
                    if (upLimit < newMax)
                    {
                        newMax = upLimit;
                    }
                    if (downLimit > newMin)
                    {
                        newMin = downLimit;
                    }
                }
                axis.Maximum = Math.Round(newMax, 1);
                axis.Minimum = Math.Round(newMin, 1);
            }
        }

        private void SetMaxMinAxis(DateTime newMax, DateTime newMin, DateTime upLimit,
            DateTime downLimit, DateTime standardMax, DateTime standardMin, TimeSpan deltaMinLimit, DateTimeAxis axis, bool isMouseDrag = false)
        {
            var deltaMaxMin = newMax - newMin;
            if (deltaMaxMin > deltaMinLimit)
            {
                if (isMouseDrag)
                {
                    if (standardMax < newMax)
                    {
                        return;
                    }
                    else if (standardMin > newMin)
                    {
                        return;
                    }
                }
                else
                {
                    if (upLimit < newMax)
                    {
                        newMax = upLimit;
                    }
                    if (downLimit > newMin)
                    {
                        newMin = downLimit;
                    }
                }
                axis.Maximum = newMax;
                axis.Minimum = newMin;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            chart.Series.Clear();
        }
        System.Windows.Point _previousPoint;
        private void Plot_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var panel = Util.Utility.FindParentWithType<EdgePanel>(sender as DependencyObject);
                Point currentPoint = e.GetPosition(panel);
                var deltaX = currentPoint.X - _previousPoint.X;
                var deltaY = currentPoint.Y - _previousPoint.Y;
                Size plotSize = GetElementPixelSize(panel);
                if (FirstLineAxis.Maximum != null && FirstLineAxis.Minimum != null)
                {
                    var deltaRange = FirstLineAxis.Maximum.Value - FirstLineAxis.Minimum.Value;
                    var deltaRangeInPoint = plotSize.Height;
                    var newMax = FirstLineAxis.Maximum.Value + deltaRange * deltaY / deltaRangeInPoint;
                    var newMin = FirstLineAxis.Minimum.Value + deltaRange * deltaY / deltaRangeInPoint;
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleFirstY, DownLimitScaleFirstY, _standardScaleMaxFirstY,
                        _standardScaleMinFirstY, DeltaLimitScaleFirstY, FirstLineAxis, true);
                }
                if (SecondLineAxis.Maximum != null && SecondLineAxis.Minimum != null)
                {
                    var deltaRange = SecondLineAxis.Maximum.Value - SecondLineAxis.Minimum.Value;
                    var deltaRangeInPoint = plotSize.Height;
                    var newMax = SecondLineAxis.Maximum.Value + deltaRange * deltaY / deltaRangeInPoint;
                    var newMin = SecondLineAxis.Minimum.Value + deltaRange * deltaY / deltaRangeInPoint;
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleSecondY, DownLimitScaleSecondY, _standardScaleMaxSecondY,
                        _standardScaleMinSecondY, DeltaLimitScaleSecondY, SecondLineAxis, true);
                }
                if (ChartDateTimeAxis.Maximum != null && ChartDateTimeAxis.Minimum != null)
                {
                    var deltaRange = (ChartDateTimeAxis.Maximum.Value - ChartDateTimeAxis.Minimum.Value).TotalMinutes;
                    var deltaRangeInPoint = plotSize.Width;
                    var deltaMinute = Convert.ToInt32(deltaX / deltaRangeInPoint * deltaRange);
                    var newMax = ChartDateTimeAxis.Maximum.Value.Subtract(new TimeSpan(0, deltaMinute, 0));
                    var newMin = ChartDateTimeAxis.Minimum.Value.Subtract(new TimeSpan(0, deltaMinute, 0));
                    SetMaxMinAxis(newMax, newMin, UpLimitScaleDate, DownLimitScaleDate, _standardScaleMaxDate,
                        _standardScaleMinDate, DeltaLimitScaleDate, ChartDateTimeAxis, true);
                }
                _isStandardScaleChanged = false;
                _previousPoint = currentPoint;
            }
        }

        private void Plot_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var panel = Util.Utility.FindParentWithType<EdgePanel>(sender as DependencyObject);
                panel.Cursor = Cursors.Hand;
                _previousPoint = e.GetPosition(panel);
            }
        }

        private void Plot_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var panel = Util.Utility.FindParentWithType<EdgePanel>(sender as DependencyObject);
            if(panel != null)
                panel.Cursor = Cursors.Arrow;
        }

        private void Plot_PreviewMouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                var panel = Util.Utility.FindParentWithType<EdgePanel>(sender as DependencyObject);
                if (panel != null)
                    panel.Cursor = Cursors.Arrow;
            }
        }

        private void DataPoint_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Plot_PreviewMouseDown(sender, e);
        }

        private void DataPoint_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Plot_PreviewMouseUp(sender, e);
        }

        private void DataPoint_MouseMove(object sender, MouseEventArgs e)
        {
            Plot_PreviewMouseMove(sender, e);
        }

        private System.Windows.Size GetElementPixelSize(FrameworkElement element)
        {
            double pixelWidth;
            double pixelHeight;
            using (var graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
            {
                pixelWidth = (int)(element.ActualWidth * graphics.DpiX / 96.0);
                pixelHeight = (int)(element.ActualHeight * graphics.DpiY / 96.0);
            }
            return new System.Windows.Size() { Height = pixelHeight, Width = pixelWidth };
        }


    }
}
