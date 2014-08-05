using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using LogViewer.Util;
using System.Collections;
using LogViewer.Business;
using System.Windows;


namespace LogViewer.ViewModel
{
    /// <summary>
    /// Base class provides common methods for setting graph parameter view model
    /// </summary>
    public class GraphViewModel : BaseWindowViewModel
    {
        protected event GetGraphDataDelegate OnApplyGraphSettingEvent;
        const double MaxValueRange = 999999999999;

        readonly TimeSpan DeltaTimeSpan = new TimeSpan(0, 1, 0);
        IList<GraphParamSetting> _graphParamSetting;
        GraphRangeSetting GraphRangeSettingValue
        {
            get
            {
                return ConfigValue.GraphRangeSettingValue;
            }
            set
            {
                ConfigValue.GraphRangeSettingValue = value;
            }
        }

        public CXDILogRecord _firstRecord;
        public CXDILogRecord _lastRecord;
        public SetRangeOfGraphViewModel _graphRangeVM;
        public EditGraphParamSettingViewModel _graphParamVM;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyGraphSettingEvent"><see cref="GetGraphDataDelegate"/></param>
        public GraphViewModel(GetGraphDataDelegate onApplyGraphSettingEvent)
        {
            OnApplyGraphSettingEvent = onApplyGraphSettingEvent;
            GraphRangeSettingValue = new GraphRangeSetting();
            _graphRangeVM = new SetRangeOfGraphViewModel(ApplyRangeSetting);
            _graphParamVM = new EditGraphParamSettingViewModel(ApplyParamSetting);
        }
        protected bool _isShowEvent;
        /// <summary>
        /// Get or set IsShowEvent
        /// </summary>
        public bool IsShowEvent
        {
            get
            {
                return _isShowEvent;
            }
            set
            {
                _isShowEvent = value;
                OnPropertyChanged("IsShowEvent");
            }
        }

        protected bool _isHaveGraphData;
        /// <summary>
        /// Get or set status for graph had or had no data
        /// </summary>
        public bool IsHaveGraphData
        {
            get
            {
                return _isHaveGraphData;
            }
            set
            {
                _isHaveGraphData = value;
                OnPropertyChanged("IsHaveGraphData");
            }
        }

        protected bool _isInitGraphFlag;
        /// <summary>
        /// Get or set status for graph initialization
        /// </summary>
        public bool IsInitGraphFlag
        {
            get
            {
                return _isInitGraphFlag;
            }
            set
            {
                _isInitGraphFlag = value;
                OnPropertyChanged("IsInitGraphFlag");
            }
        }
        /// <summary>
        /// Get or set maximum range of Y axis of the first line
        /// </summary>

        public double FirstRangeMaxY
        {
            get
            {
                return GraphRangeSettingValue.FirstYRangeTo;
            }
            set
            {
                if (value > MaxValueRange)
                {
                    value = MaxValueRange;
                }
                GraphRangeSettingValue.FirstYRangeTo = value;
                OnPropertyChanged("FirstRangeMaxY");
            }
        }
        /// <summary>
        /// Get or set minimum range of Y axis of the first line
        /// </summary>

        public double FirstRangeMinY
        {
            get
            {
                return GraphRangeSettingValue.FirstYRangeFrom;
            }
            set
            {
                if (value > MaxValueRange)
                {
                    value = MaxValueRange - 1;
                }
                GraphRangeSettingValue.FirstYRangeFrom = value;
                OnPropertyChanged("FirstRangeMinY");
            }
        }
        /// <summary>
        /// Get or set maximum range of Y axis of the second line
        /// </summary>
        public double SecondRangeMaxY
        {
            get
            {
                return GraphRangeSettingValue.SecondYRangeTo;
            }
            set
            {
                if (value > MaxValueRange)
                {
                    value = MaxValueRange;
                }
                GraphRangeSettingValue.SecondYRangeTo = value;
                OnPropertyChanged("SecondRangeMaxY");
            }
        }
        /// <summary>
        /// Get or set minimum range of Y axis of the second line
        /// </summary>
        public double SecondRangeMinY
        {
            get
            {
                return GraphRangeSettingValue.SecondYRangeFrom;
            }
            set
            {
                if (value > MaxValueRange)
                {
                    value = MaxValueRange - 1;
                }
                GraphRangeSettingValue.SecondYRangeFrom = value;
                OnPropertyChanged("SecondRangeMinY");
            }
        }
        /// <summary>
        /// Get or set minimum date
        /// </summary>
        public DateTime MinDate
        {
            get
            {
                return GraphRangeSettingValue.From;
            }
            set
            {
                GraphRangeSettingValue.From = value;
                OnPropertyChanged("MinDate");
            }
        }
        /// <summary>
        /// Get or set maximum date
        /// </summary>
        public DateTime MaxDate
        {
            get
            {
                return GraphRangeSettingValue.To;
            }
            set
            {
                GraphRangeSettingValue.To = value;
                OnPropertyChanged("MaxDate");
            }
        }

        protected GraphResult _graphLineData1;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 1)
        /// </summary>
        public GraphResult GraphLineData1
        {
            get
            {
                return _graphLineData1;
            }
            set
            {
                _graphLineData1 = value;
                OnPropertyChanged("GraphLineData1");
            }
        }
        protected GraphResult _graphLineData2;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 2)
        /// </summary>
        public GraphResult GraphLineData2
        {
            get
            {
                return _graphLineData2;
            }
            set
            {
                _graphLineData2 = value;
                OnPropertyChanged("GraphLineData2");
            }
        }

        protected GraphResult _graphEventData1;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 1)
        /// </summary>
        public GraphResult GraphEventData1
        {
            get
            {
                return _graphEventData1;
            }
            set
            {
                _graphEventData1 = value;
                OnPropertyChanged("GraphEventData1");
            }
        }

        protected GraphResult _graphEventData2;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 2)
        /// </summary>
        public GraphResult GraphEventData2
        {
            get
            {
                return _graphEventData2;
            }
            set
            {
                _graphEventData2 = value;
                OnPropertyChanged("GraphEventData2");
            }
        }

        protected GraphResult _graphEventData3;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 3)
        /// </summary>
        public GraphResult GraphEventData3
        {
            get
            {
                return _graphEventData3;
            }
            set
            {
                _graphEventData3 = value;
                OnPropertyChanged("GraphEventData3");
            }
        }

        protected GraphResult _graphEventData4;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 4)
        /// </summary>
        public GraphResult GraphEventData4
        {
            get
            {
                return _graphEventData4;
            }
            set
            {
                _graphEventData4 = value;
                OnPropertyChanged("GraphEventData4");
            }
        }

        protected GraphResult _graphEventData5;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 5)
        /// </summary>
        public GraphResult GraphEventData5
        {
            get
            {
                return _graphEventData5;
            }
            set
            {
                _graphEventData5 = value;
                OnPropertyChanged("GraphEventData5");
            }
        }

        protected GraphResult _graphEventData6;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 6)
        /// </summary>
        public GraphResult GraphEventData6
        {
            get
            {
                return _graphEventData6;
            }
            set
            {
                _graphEventData6 = value;
                OnPropertyChanged("GraphEventData6");
            }
        }

        protected GraphResult _graphEventData7;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 7)
        /// </summary>
        public GraphResult GraphEventData7
        {
            get
            {
                return _graphEventData7;
            }
            set
            {
                _graphEventData7 = value;
                OnPropertyChanged("GraphEventData7");
            }
        }

        protected GraphResult _graphEventData8;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 8)
        /// </summary>
        public GraphResult GraphEventData8
        {
            get
            {
                return _graphEventData8;
            }
            set
            {
                _graphEventData8 = value;
                OnPropertyChanged("GraphEventData8");
            }
        }

        protected GraphResult _graphEventData9;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 9)
        /// </summary>
        public GraphResult GraphEventData9
        {
            get
            {
                return _graphEventData9;
            }
            set
            {
                _graphEventData9 = value;
                OnPropertyChanged("GraphEventData9");
            }
        }

        protected GraphResult _graphEventData10;
        /// <summary>
        /// Get or set <see cref="GraphResult"/> (line 10)
        /// </summary>
        public GraphResult GraphEventData10
        {
            get
            {
                return _graphEventData10;
            }
            set
            {
                _graphEventData10 = value;
                OnPropertyChanged("GraphEventData10");
            }
        }

        protected DelegateCommand _paramSettingCommand;
        /// <summary>
        /// Command interface for setting parameter
        /// </summary>
        public ICommand ParamSettingCommand
        {
            get
            {
                if (_paramSettingCommand == null)
                {
                    _paramSettingCommand = new DelegateCommand(ParamSettingCL);
                }
                return _paramSettingCommand;
            }
        }
        /// <summary>
        /// Command function for setting parameter
        /// </summary>
        protected void ParamSettingCL()
        {
            //EditGraphParamSettingViewModel vm = new EditGraphParamSettingViewModel(ApplyParamSetting, _graphParamSetting);
            //vm.ShowDialog(this);
            _graphParamVM.LoadParam(_graphParamSetting);
            _graphParamVM.Show(this);
        }

        protected DelegateCommand _setRangeCommand;
        /// <summary>
        /// Command interface function for setting range
        /// </summary>
        public ICommand SetRangeCommand
        {
            get
            {
                if (_setRangeCommand == null)
                {
                    _setRangeCommand = new DelegateCommand(SetRangeCommandCL);
                }
                return _setRangeCommand;
            }
        }
        /// <summary>
        /// Command function for setting range
        /// </summary>
        protected void SetRangeCommandCL()
        {
            _graphRangeVM.Setting = GraphRangeSettingValue.Copy();
            //_graphRangeVM.Max = _firstRecord.
            if (_firstRecord != null)
            {
                DateTime min = Convert.ToDateTime(_firstRecord.Date + " " + _firstRecord.Time);
                DateTime max = Convert.ToDateTime(_lastRecord.Date + " " + _lastRecord.Time);
                if (min == max)
                {
                    _graphRangeVM.Min = (min - DeltaTimeSpan).ToString("yyyy-MM-dd HH:mm");
                    _graphRangeVM.Max = (max + DeltaTimeSpan).ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    _graphRangeVM.Min = min.ToString("yyyy-MM-dd HH:mm");
                    _graphRangeVM.Max = max.ToString("yyyy-MM-dd HH:mm");
                }
            }
            else
            {
                _graphRangeVM.Min = (DateTime.Now - DeltaTimeSpan).ToString("yyyy-MM-dd HH:mm");
                _graphRangeVM.Max = (DateTime.Now + DeltaTimeSpan).ToString("yyyy-MM-dd HH:mm");
            }
            _graphRangeVM.Show(this);
            
        }

        protected DelegateCommand _exportToCSVCommand;
        /// <summary>
        /// Command function for exporting graph data to CSV file
        /// </summary>
        public ICommand ExportToCSVCommand
        {
            get
            {
                if (_exportToCSVCommand == null)
                {
                    _exportToCSVCommand = new DelegateCommand(ExportToCSVCL);
                }
                return _exportToCSVCommand;
            }
        }
        /// <summary>
        /// Check for graph result has data or not
        /// </summary>
        /// <param name="graphResult"><see cref="GraphResult"/></param>
        /// <returns>True: has data, False: has no data</returns>
        protected bool HasData(GraphResult graphResult)
        {
            if (graphResult != null && graphResult.ResultList.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Do export graph data to CSV
        /// </summary>
        protected void ExportToCSVCL()
        {
            System.Windows.Forms.MessageBoxManager.Unregister();
            System.Windows.Forms.MessageBoxManager.Yes = LogViewer.Properties.Resources.Yes;
            System.Windows.Forms.MessageBoxManager.No = LogViewer.Properties.Resources.No;

            //Register manager
            System.Windows.Forms.MessageBoxManager.Register();
            SaveFileDialogViewModel dlgVM = new SaveFileDialogViewModel()
            {
                DefaultExt = ConfigValue.ExportedGraphCSVResultFileExtension,
                FileName = ConfigValue.ExportedGraphCSVResultFileName,
                Filter = ConfigValue.ExportedGraphCSVResultFileFilter,
            };

            if (!(HasData(GraphEventData1) || HasData(GraphEventData2) ||
                HasData(GraphEventData3) || HasData(GraphEventData4) ||
                HasData(GraphEventData5) || HasData(GraphEventData6) ||
                HasData(GraphEventData7) || HasData(GraphEventData8) ||
                HasData(GraphEventData9) || HasData(GraphEventData10) ||
                HasData(GraphLineData1) || HasData(GraphLineData2)))
            {
                MessageBoxViewModel messageBoxExport = new MessageBoxViewModel();
                messageBoxExport.Caption = Properties.Resources.Warning;
                messageBoxExport.Text = Properties.Resources.GRAPH_EXPORT_NO_DATA;
                messageBoxExport.ShowDialog(this);
                return;
            }

            var result = dlgVM.ShowDialog(this);
            //if (result.Value)
            //{
            //    string str = ExportToCSV();
            //    try
            //    {
            //        System.IO.File.WriteAllText(dlgVM.FileName, str);
            //    }
            //    catch(Exception e)
            //    {
            //        MessageBox.Show(string.Format(Properties.Resources.EXPORT_FAILURE, dlgVM.FileName));
            //    }
            //}
            export(dlgVM, result.Value);
        }
        /// <summary>
        /// Do exporting graph data to CSV file
        /// </summary>
        /// <param name="dlgVM"><see cref="SaveFileDialogViewModel"/> for selecting file path</param>
        /// <param name="isExport">Exporting status, True: success, False: fail</param>
        protected void export(SaveFileDialogViewModel dlgVM, bool isExport)
        {
            if (isExport)
            {
                string str = ExportToCSV();
                try
                {
                    System.IO.File.WriteAllText(dlgVM.FileName, str);
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format(Properties.Resources.EXPORT_FAILURE, dlgVM.FileName));
                    var result = dlgVM.ShowDialog(this);
                    export(dlgVM, result.Value);
                }
            }
        }
        /// <summary>
        /// Export graph data to CSV
        /// </summary>
        /// <returns>result of string</returns>
        public string ExportToCSV()
        {
            List<List<string>> matrixCSV = new List<List<string>>();
            if (GraphLineData1 != null)
                AddRangeWhenNotNull(matrixCSV, ExportGraphLineDataToCSVMatrix(GraphLineData1.ParamSetting.Name,
                    GraphLineData1.ResultList.Where(x => IsInRangeGraphLine1(x))));
            if (GraphLineData2 != null)
                AddRangeWhenNotNull(matrixCSV, ExportGraphLineDataToCSVMatrix(GraphLineData2.ParamSetting.Name,
                    GraphLineData2.ResultList.Where(x => IsInRangeGraphLine2(x))));
            if (GraphEventData1 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData1.ParamSetting.Name,
                    GraphEventData1.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData2 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData2.ParamSetting.Name,
                    GraphEventData2.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData3 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData3.ParamSetting.Name,
                    GraphEventData3.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData4 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData4.ParamSetting.Name,
                    GraphEventData4.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData5 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData5.ParamSetting.Name,
                    GraphEventData5.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData6 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData6.ParamSetting.Name,
                    GraphEventData6.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData7 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData7.ParamSetting.Name,
                    GraphEventData7.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData8 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData8.ParamSetting.Name,
                    GraphEventData8.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData9 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData9.ParamSetting.Name,
                    GraphEventData9.ResultList.Where(x => IsInRangeGraphEvent(x))));
            if (GraphEventData10 != null)
                AddWhenNotNull(matrixCSV, ExportGraphEventDataToCSVMatrix(GraphEventData10.ParamSetting.Name,
                    GraphEventData10.ResultList.Where(x => IsInRangeGraphEvent(x))));

            StringBuilder strBuilder = new StringBuilder();

            var longestColumn = matrixCSV.OrderBy(x => x.Count).LastOrDefault();

            int maxRow = longestColumn.Count;
            int totalColumn = matrixCSV.Count;

            for (int line = 0; line < maxRow; line++)
            {
                for (int column = 0; column < totalColumn; column++)
                {
                    if (line < matrixCSV[column].Count)
                        strBuilder.AppendFormat("{0},", matrixCSV[column][line]);
                    else
                        strBuilder.Append(",");
                }
                strBuilder.Remove(strBuilder.Length - 1, 1);
                strBuilder.AppendLine();
            }
            return strBuilder.ToString();
        }
        /// <summary>
        /// Check for <see cref="GraphParamResultItem"/> (value case, line 1) is in range or not
        /// </summary>
        /// <param name="item"><see cref="GraphParamResultItem"/></param>
        /// <returns>True: if is in range, otherwise is False</returns>
        protected bool IsInRangeGraphLine1(GraphParamResultItem item)
        {
            return IsInRangeGraphEvent(item)
                && item.Value >= FirstRangeMinY && item.Value <= FirstRangeMaxY;
        }
        /// <summary>
        /// Check for <see cref="GraphParamResultItem"/> (value case, line 2) is in range or not
        /// </summary>
        /// <param name="item"><see cref="GraphParamResultItem"/></param>
        /// <returns>True: if is in range, otherwise is False</returns>
        protected bool IsInRangeGraphLine2(GraphParamResultItem item)
        {
            return IsInRangeGraphEvent(item)
                && item.Value >= SecondRangeMinY && item.Value <= SecondRangeMaxY;
        }
        /// <summary>
        /// Check for <see cref="GraphParamResultItem"/> (event case) is in range or not
        /// </summary>
        /// <param name="item"><see cref="GraphParamResultItem"/></param>
        /// <returns>True: if is in range, otherwise is False</returns>
        protected bool IsInRangeGraphEvent(GraphParamResultItem item)
        {
            return item.Time <= MaxDate && item.Time >= MinDate;
        }
        /// <summary>
        /// Add element
        /// </summary>
        /// <typeparam name="T">Is List<string></typeparam>
        /// <param name="list">List of string, is a reference result list</param>
        /// <param name="element">List of string result <see cref="ExportGraphLineDataToCSVMatrix"/> or <see cref="ExportGraphEventDataToCSVMatrix"/></param>
        protected void AddWhenNotNull<T>(List<T> list, T element)
        {
            if (element != null)
            {
                list.Add(element);
            }
        }
        /// <summary>
        /// Add range
        /// </summary>
        /// <typeparam name="T">Is List<string></typeparam>
        /// <param name="list">List of string, is a reference result list</param>
        /// <param name="range">List of string result <see cref="ExportGraphLineDataToCSVMatrix"/> or <see cref="ExportGraphEventDataToCSVMatrix"/></param>
        protected void AddRangeWhenNotNull<T>(List<T> list, List<T> range)
        {
            if (range != null)
            {
                list.AddRange(range);
            }
        }
        /// <summary>
        /// Create list of exporting data to export  graph data csv file
        /// </summary>
        /// <param name="name">Name of value parameter</param>
        /// <param name="resultList">List of <see cref="GraphParamResultItem"/></param>
        /// <returns>List of result data</returns>
        protected List<List<string>> ExportGraphLineDataToCSVMatrix(string name, IEnumerable<GraphParamResultItem> resultList)
        {
            List<List<string>> allArr = null;
            if (resultList != null && resultList.Count() > 0)
            {
                allArr = new List<List<string>>();
                List<string> arrX = new List<string>();
                arrX.Add(String.Format("{0}_X", name));
                foreach (var i in resultList)
                {
                    arrX.Add(String.Format("{0}", i.Time.ToString("yyyy/MM/dd HH:mm:ss.fff")));
                }

                List<string> arrY = new List<string>();
                arrY.Add(String.Format("{0}_Y", name));
                foreach (var i in resultList)
                {
                    arrY.Add(String.Format("{0}", i.Value));
                }

                allArr.Add(arrX);
                allArr.Add(arrY);
            }
            return allArr;
        }
        /// <summary>
        /// Create list of exporting data to export  graph data csv file
        /// </summary>
        /// <param name="name">Name of event parameter <seealso cref="GraphParamSetting"/></param>
        /// <param name="resultList">List of <see cref="GraphParamResultItem"/></param>
        /// <returns>List of result data</returns>
        protected List<string> ExportGraphEventDataToCSVMatrix(string name, IEnumerable<GraphParamResultItem> resultList)
        {
            List<string> arr = null;
            if (resultList != null && resultList.Count() > 0)
            {
                arr = new List<string>();
                arr.Add(String.Format("{0}_X", name));
                foreach (var i in resultList)
                {
                    arr.Add(String.Format("{0}", i.Time.ToString("yyyy/MM/dd HH:mm:ss.fff")));
                }
            }
            return arr;
        }
        /// <summary>
        /// Apply for parameter setting
        /// </summary>
        /// <param name="paramSetting">List of <see cref="GraphParamSetting"/></param>
        protected virtual void ApplyParamSetting(IList<GraphParamSetting> paramSetting)
        {
            LoadingDialogViewModel loadDlgVM = new LoadingDialogViewModel();
            loadDlgVM.ExecuteWhilePopUpLoading(() =>
                {
                    _graphParamSetting = paramSetting;
                    GraphResult graphLineData1, graphLineData2;
                    IList<GraphResult> eventResults;
                    OnApplyGraphSettingEvent(_graphParamSetting, out graphLineData1, out graphLineData2, out eventResults);

                    LoadData(graphLineData1, graphLineData2, eventResults);
                }, this, null);
        }
        /// <summary>
        /// Apply for range setting
        /// </summary>
        /// <param name="rangeSetting"><see cref="GraphRangeSetting"/></param>
        protected virtual void ApplyRangeSetting(GraphRangeSetting rangeSetting)
        {
            SetMinMaxAxes(rangeSetting);
            IsInitGraphFlag = !IsInitGraphFlag;
        }
        /// <summary>
        /// Set limit mininize and maximize for axises
        /// </summary>
        /// <param name="rangeSetting"><see cref="GraphRangeSetting"/></param>
        protected void SetMinMaxAxes(GraphRangeSetting rangeSetting)
        {
            //must ensure set these max, min value in right order, otherwise will have min > max exception
            if (rangeSetting.FirstYRangeTo < FirstRangeMinY)
            {
                FirstRangeMinY = rangeSetting.FirstYRangeFrom;
                FirstRangeMaxY = rangeSetting.FirstYRangeTo;
            }
            else
            {
                FirstRangeMaxY = rangeSetting.FirstYRangeTo;
                FirstRangeMinY = rangeSetting.FirstYRangeFrom;
            }
            if (rangeSetting.SecondYRangeTo < SecondRangeMinY)
            {
                SecondRangeMinY = rangeSetting.SecondYRangeFrom;
                SecondRangeMaxY = rangeSetting.SecondYRangeTo;
            }
            else
            {
                SecondRangeMaxY = rangeSetting.SecondYRangeTo;
                SecondRangeMinY = rangeSetting.SecondYRangeFrom;
            }
            if (rangeSetting.To < MinDate)
            {
                MinDate = rangeSetting.From;
                MaxDate = rangeSetting.To;
            }
            else
            {
                MaxDate = rangeSetting.To;
                MinDate = rangeSetting.From;
            }
        }
        /// <summary>
        /// Initial vertical value for event line
        /// </summary>
        /// <param name="eventListData">Event line <see cref="GraphResult"/></param>
        /// <returns>List of <see cref="GraphResult"/></returns>
        public IList<GraphResult> InitValueVeticalEvent(IList<GraphResult> eventListData)
        {
            double max = 0;
            double min = 0;
            foreach (var eventData in eventListData)
            {
                double maxValue = (double)eventData.ResultList.Max(x => x.Value);
                if (maxValue > max)
                {
                    max = maxValue;
                }
                double minValue = (double)eventData.ResultList.Min(x => x.Value);
                if (maxValue < min)
                {
                    min = minValue;
                }
            }
            //double medium = (max + min) / 2;

            //foreach (var eventData in eventListData)
            //{
            //    foreach (var item in eventData.ResultList)
            //    {
            //        if (item.Value == 0)
            //        {
            //            item.Value = medium;
            //        }
            //    }
            //}
            return eventListData;
        }
        /// <summary>
        /// Load analyzed data to <see cref="GraphResult"/> for display to graph
        /// </summary>
        /// <param name="graphLineData1">The first <see cref="GraphResult"/></param>
        /// <param name="graphLineData2">The second <see cref="GraphResult"/></param>
        /// <param name="eventListData">Event line <see cref="GraphResult"/></param>
        protected virtual void LoadData(GraphResult graphLineData1, GraphResult graphLineData2,
            IList<GraphResult> eventListData)
        {
            IList<GraphResult> eventList = InitValueVeticalEvent(eventListData);
            InitGraphRangeSetting(graphLineData1, graphLineData2, eventList);
            GraphLineData1 = graphLineData1;
            if (GraphLineData1.ResultList.Count == 0)
            {
                GraphLineData1 = null;
            }

            GraphLineData2 = graphLineData2;
            if (GraphLineData2.ResultList.Count == 0)
            {
                GraphLineData2 = null;
            }
            GraphEventData1 = GraphEventData2 = GraphEventData3 = GraphEventData4 = GraphEventData5 =
                GraphEventData6 = GraphEventData7 = GraphEventData8 = GraphEventData9 = GraphEventData10 = null;
            for (int i = 0; i < eventList.Count; i++)
            {
                var graphResult = eventList[i];
                if (graphResult.ResultList.Count <= 0)
                    continue;
                switch (i)
                {
                    case 0:
                        {
                            GraphEventData1 = graphResult;
                            break;
                        }
                    case 1:
                        {
                            GraphEventData2 = graphResult;
                            break;
                        }
                    case 2:
                        {
                            GraphEventData3 = graphResult;
                            break;
                        }
                    case 3:
                        {
                            GraphEventData4 = graphResult;
                            break;
                        }
                    case 4:
                        {
                            GraphEventData5 = graphResult;
                            break;
                        }
                    case 5:
                        {
                            GraphEventData6 = graphResult;
                            break;
                        }
                    case 6:
                        {
                            GraphEventData7 = graphResult;
                            break;
                        }
                    case 7:
                        {
                            GraphEventData8 = graphResult;
                            break;
                        }
                    case 8:
                        {
                            GraphEventData9 = graphResult;
                            break;
                        }
                    case 9:
                        {
                            GraphEventData10 = graphResult;
                            break;
                        }
                }
            }
            if (GraphLineData1 == null &&
                GraphLineData2 == null &&
                GraphEventData1 == null &&
                GraphEventData2 == null &&
                GraphEventData3 == null &&
                GraphEventData4 == null &&
                GraphEventData5 == null &&
                GraphEventData6 == null &&
                GraphEventData7 == null &&
                GraphEventData8 == null &&
                GraphEventData9 == null &&
                GraphEventData10 == null)
            {
                IsHaveGraphData = false;
            }
            else
            {
                IsHaveGraphData = true;
            }
            if (GraphEventData1 == null &&
                GraphEventData2 == null &&
                GraphEventData3 == null &&
                GraphEventData4 == null &&
                GraphEventData5 == null &&
                GraphEventData6 == null &&
                GraphEventData7 == null &&
                GraphEventData8 == null &&
                GraphEventData9 == null &&
                GraphEventData10 == null)
            {
                IsShowEvent = false;
            }
            else
            {
                IsShowEvent = true;
            }
                
        }
        /// <summary>
        /// Initialize for displaying graph
        /// </summary>
        /// <param name="graphLineData1">The first <see cref="GraphResult"/></param>
        /// <param name="graphLineData2">The second <see cref="GraphResult"/></param>
        /// <param name="eventListData">Event line <see cref="GraphResult"/></param>
        protected virtual void InitGraphRangeSetting(GraphResult graphLineData1, GraphResult graphLineData2,
            IList<GraphResult> eventListData)
        {
            GraphRangeSetting graphRangeSettingValue = new GraphRangeSetting();
            if (ConfigValue.Is1stTimeSetFirstYRange && graphLineData1 != null
                && graphLineData1.ResultList.Count() > 0)
            {
                var firstMax = graphLineData1.ResultList.OrderBy(x => x.Value).LastOrDefault();
                var firstMin = graphLineData1.ResultList.OrderBy(x => x.Value).FirstOrDefault();
                if (firstMax.Value == firstMin.Value)
                {
                    graphRangeSettingValue.FirstYRangeTo = firstMax.Value + 1;
                    graphRangeSettingValue.FirstYRangeFrom = firstMin.Value - 1;
                }
                else
                {
                    graphRangeSettingValue.FirstYRangeTo = firstMax.Value;
                    graphRangeSettingValue.FirstYRangeFrom = firstMin.Value;
                }
                ConfigValue.Is1stTimeSetFirstYRange = false;
            }
            else if (!(graphLineData1 != null
                && graphLineData1.ResultList.Count() > 0))
            {
                graphRangeSettingValue.FirstYRangeTo = 1;
                graphRangeSettingValue.FirstYRangeFrom = 0;
            }
            if (ConfigValue.Is1stTimeSetSecondYRange && graphLineData2 != null
                && graphLineData2.ResultList.Count() > 0)
            {
                var secondMax = graphLineData2.ResultList.OrderBy(x => x.Value).LastOrDefault();
                var secondMin = graphLineData2.ResultList.OrderBy(x => x.Value).FirstOrDefault();
                if (secondMax.Value == secondMin.Value)
                {
                    graphRangeSettingValue.SecondYRangeTo = secondMax.Value + 1;
                    graphRangeSettingValue.SecondYRangeFrom = secondMin.Value - 1;
                }
                else
                {
                    graphRangeSettingValue.SecondYRangeTo = secondMax.Value;
                    graphRangeSettingValue.SecondYRangeFrom = secondMin.Value;
                }
                ConfigValue.Is1stTimeSetSecondYRange = false;
            }
            else if(!(graphLineData2 != null
                && graphLineData2.ResultList.Count() > 0))
            {
                graphRangeSettingValue.SecondYRangeTo = 1;
                graphRangeSettingValue.SecondYRangeFrom = 0;
            }
            if (ConfigValue.Is1stTimeSetDateRange)
            {
                List<GraphParamResultItem> allResult = new List<GraphParamResultItem>();
                foreach (var i in eventListData)
                {
                    allResult.AddRange(i.ResultList);
                }
                if (graphLineData1 != null)
                    allResult.AddRange(graphLineData1.ResultList);
                if (graphLineData2 != null)
                    allResult.AddRange(graphLineData2.ResultList);
                if (allResult.Count > 1)
                {
                    var minDate = allResult.OrderBy(x => x.Time).FirstOrDefault();
                    var maxDate = allResult.OrderBy(x => x.Time).LastOrDefault();
                    if (minDate.Time == maxDate.Time)
                    {
                        graphRangeSettingValue.From = minDate.Time - new TimeSpan(0, 1, 0);
                        graphRangeSettingValue.To = maxDate.Time + new TimeSpan(0, 1, 0);
                    }
                    else
                    {
                        graphRangeSettingValue.From = minDate.Time;
                        graphRangeSettingValue.To = maxDate.Time;
                    }
                    ConfigValue.Is1stTimeSetDateRange = false;
                }
                else if (allResult.Count == 1)
                {
                    var minDate = allResult.FirstOrDefault();
                    graphRangeSettingValue.From = minDate.Time - new TimeSpan(0,1,0);
                    graphRangeSettingValue.To = minDate.Time + new TimeSpan(0, 1, 0);
                }
                else if (allResult.Count <= 0)
                {
                    graphRangeSettingValue.From = DateTime.Now - new TimeSpan(1, 0, 0);
                    graphRangeSettingValue.To = DateTime.Now + new TimeSpan(1, 0, 0);
                }
            }
            SetMinMaxAxes(graphRangeSettingValue);
            IsInitGraphFlag = !IsInitGraphFlag;
            
            ConfigValue.Is1stTimeSetFirstYRange = true;
            ConfigValue.Is1stTimeSetSecondYRange = true;
            ConfigValue.Is1stTimeSetDateRange = true;
        }
        /// <summary>
        /// Load analyzed data to <see cref="GraphResult"/> for display to graph
        /// </summary>
        /// <param name="graphLineData1">The first <see cref="GraphResult"/></param>
        /// <param name="graphLineData2">The second <see cref="GraphResult"/></param>
        /// <param name="eventListData">Event line <see cref="GraphResult"/></param>
        /// <param name="paramSetting"><see cref="GraphParamSetting"/></param>
        public virtual void LoadData(GraphResult graphLineData1, GraphResult graphLineData2,
            IList<GraphResult> eventListData, IList<GraphParamSetting> paramSetting)
        {
            IsInitGraphFlag = false;
            _graphParamSetting = paramSetting;
            LoadData(graphLineData1, graphLineData2, eventListData);
        }
        /// <summary>
        /// Close dialog
        /// </summary>
        public override void CloseDialog()
        {
            _graphRangeVM.CloseDialog();
            _graphParamVM.CloseDialog();
            base.CloseDialog();
            
        }
        /// <summary>
        /// Close the dialog then set <see cref="IsShow"/> status of <see cref="GraphRangeVM"/> and <see cref="GrapParamVM"/> to false
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e"><see cref="CancelEventArgs"/></param>
        public override void dialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _graphRangeVM.IsShow = false;
            _graphParamVM.IsShow = false;
            base.dialog_Closing(sender, e);
        }
    }
}
