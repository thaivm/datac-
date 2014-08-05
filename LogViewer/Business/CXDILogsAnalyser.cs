// File:    CXDILogsAnalyser.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 2:16:20 PM
// Purpose: Definition of Class CXDILogsAnalyser

using System;
using LogViewer.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using LogViewer.Business.FileParser;
using System.Diagnostics;
namespace LogViewer.Business
{
    /// <summary>
    /// Class provides methods for analyzing CXDI log data
    /// </summary>
    public class CXDILogsAnalyser : BaseLogsAnalyser<CXDILogRecord>
    {
        /// <summary>
        /// Construct tor for CXDILogsAnalyser
        /// </summary>
        public CXDILogsAnalyser()
        {
            _firmWare = new CXDIFirmware();
        }

        protected CXDIFirmware _firmWare;
        /// <summary>
        /// Get or set Firmware object. After run <see cref="LoadLogFile">LoadLogFile</see>, this properties return CXDIFirmware object
        /// </summary>
        public CXDIFirmware Firmware
        {
            get
            {
                if (_firmWare == null)
                {
                    _firmWare = new CXDIFirmware();
                }
                return _firmWare;
            }
            set
            {
                _firmWare = value;
            }
        }
        /// <summary>
        /// Get <see cref="FilterItemProxy"/> from <see cref="KeywordCountItemSetting"/>
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        protected override FilterItemProxy GetFilterItemProxy(KeywordCountItemSetting keyword)
        {
            FilterItemProxy filterItemProxy = new FilterItemProxy(keyword);
            return filterItemProxy;
        
        }
        /// <summary>
        /// Load all log record from log file.
        /// </summary>
        /// <param name="filePath">The log record's file path</param>
        /// <param name="isAdd">The variable used to check either old log record buffer
        /// was replaced or merged with new one</param>
        public override void LoadLogFile(String filePath, bool isAdd)
        {
            LogFileExt fileExt = ParserManager.DetectFileType(filePath);
            if (fileExt == LogFileExt.Memo)
            {
                iLogParser = ParserManager.GetCxdiMemoParser(filePath);
                base.LoadMemoLogFile(filePath);
                _isMemoLoaded = true;
                CXDILogRecord firstRecord = _allLogRecordsBuffer.FirstOrDefault();
                if (firstRecord != null)
                {
                    string fileContainFirstRecord = _allLogRecordsBufferWithFileName.FirstOrDefault(x => x.Value.Contains(firstRecord)).Key;
                    Firmware = ((CXDIParser)iLogParser).GetFirmware(fileContainFirstRecord);
                }
                return;
            }
            if (fileExt == LogFileExt.Cxdi)
            {
                iLogParser = ParserManager.GetCxdiCsvLogParser(filePath);
                base.LoadLogFile(filePath, isAdd);
                _isMemoLoaded = false;
                CXDILogRecord firstRecord = _allLogRecordsBuffer.FirstOrDefault();
                if (firstRecord != null)
                {
                    string fileContainFirstRecord = _allLogRecordsBufferWithFileName.FirstOrDefault(x => x.Value.Contains(firstRecord)).Key;
                    Firmware = ((CXDIParser)iLogParser).GetFirmware(fileContainFirstRecord);
                }
            }
            else throw new Exception(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, filePath));
        }
        
        /// <summary>
        /// Writes memo log to file.
        /// </summary>
        /// <param name="filePath">The output file's path</param>
        /// <returns></returns>
        public override bool WriteMemo(String filePath)
        {
            try
            {
                CXDIMemoParser memoParser = new CXDIMemoParser();
                memoParser.LogRecords = AllLogRecordsBuffer;
                memoParser.Comments = Comments;
                memoParser.Bookmarks = BookmarkBuffer;
                memoParser.FirmWare = Firmware;
                iLogParser = memoParser;
                return base.WriteMemoLogFile(filePath);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Load all log memo from memo log file.
        /// </summary>
        /// <param name="filePath">The memo log's file path</param>
        public override void LoadMemoLogFile(string filePath)
        {
            try
            {
                iLogParser = new CXDIMemoParser();
                base.LoadMemoLogFile(filePath);

                _isMemoLoaded = true;
                CXDILogRecord firstRecord = _allLogRecordsBuffer.FirstOrDefault();
                if (firstRecord != null)
                {
                    string fileContainFirstRecord = _allLogRecordsBufferWithFileName.FirstOrDefault(x => x.Value.Contains(firstRecord)).Key;
                    Firmware = ((CXDIParser)iLogParser).GetFirmware(fileContainFirstRecord);
                }


            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Get value of Message column
        /// </summary>
        /// <param name="record"></param>
        /// <returns>Value of Message column</returns>
        protected override string GetColumnContentValue(CXDILogRecord record)
        {
            if (record == null) return string.Empty;
            return record.Message;
        }

        /// <summary>
        /// Extract data from log records. AllLogRecordsBuffer must be set before.
        /// </summary>
        /// <param name="paramList">List of parameter will be analyze</param>
        /// <param name="graphLineData1">There are at most two result of value parameters. This is the first result after analyze</param>
        /// <param name="graphLineData2">There are at most two result of value parameters. This is the second result after analyze</param>
        /// <param name="eventResults">The result of event parameter after analyze </param>
        public void AnalyGraphParam(IList<GraphParamSetting> paramList, out GraphResult graphLineData1,out GraphResult graphLineData2, out IList<GraphResult> eventResults)
        {
            
            graphLineData1 = new GraphResult();
            graphLineData2 = new GraphResult();
            eventResults = new List<GraphResult>();
            if (paramList == null) return;

            int numOfGraphLine = InitGraphLineData(paramList, graphLineData1, graphLineData2, eventResults);

            if (numOfGraphLine+eventResults.Count == 0) return;

            List<string> paramValueArray = BuildSearchPattern(paramList);
            String paramValuePattern = string.Join("|", paramValueArray.ToArray());
            Regex searchPatternRegex = new Regex(paramValuePattern);
            foreach (CXDILogRecord record in _allLogRecordsBuffer)
            {
                    //Detect for match pattern in GraphParamSetting list
                    if (searchPatternRegex.IsMatch(record.Message))
                    {
                        //Parsing date for repairing analyze
                        string strDate = String.Format("{0} {1}", record.Date, record.Time);
                        DateTime recordDateTime;
                        try
                        {
                            recordDateTime = DateTime.Parse(strDate);
                        }
                        catch
                        {
                            continue;
                        }


                        MatchCollection matchList = Regex.Matches(record.Message, paramValuePattern);
                        var valueMatchedlist = matchList.Cast<Match>().Select(match => match.Value.Trim()).ToList();
                        BuildGraphParamResult(valueMatchedlist, graphLineData1, graphLineData2, numOfGraphLine, recordDateTime, eventResults, record.Message);
                    }
            }
        }
        Regex rg = new Regex(@"((\d+)|[\+](\d+)|[\-](\d+))(\s*)(\[msec\])");
        Regex rg1 = new Regex(@"((\d+)|[\+](\d+)|[\-](\d+))");

        private bool BuildGraphParamResult(List<string> valueMatchedlist, GraphResult graphLineData1, GraphResult graphLineData2, int numOfGraphLine, DateTime recordDateTime, IList<GraphResult> eventResults,string message)
        {
            //Build graph param result
            foreach (String matchedString in valueMatchedlist)
            {
                    string[] twoPartsArray = matchedString.Split(':');
                    GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
                    graphParamResultItem.Time = recordDateTime;
                    if (twoPartsArray.Length > 1)
                    {
                        switch (numOfGraphLine)
                        {
                            case 1:
                                //The matched value owner by graphLineData1
                                if (graphLineData1.ParamSetting.StringValue.IndexOf(twoPartsArray[0].Trim()) >= 0)
                                {
                                    double value;
                                    //parse value for value graph parameter;
                                    try
                                    {
                                        value = double.Parse(twoPartsArray[1]);
                                    }
                                    catch
                                    {
                                        return false;
                                    }

                                    //parse value for value graph parameter;
                                    graphParamResultItem.Value = value;

                                    graphLineData1.ResultList.Add(graphParamResultItem);

                                }
                                break;
                            case 2:
                                //The matched value owner by graphLineData1
                                if (graphLineData1.ParamSetting.StringValue.IndexOf(twoPartsArray[0].Trim()) >= 0)
                                {
                                    double value;
                                    //parse value for value graph parameter;
                                    try
                                    {
                                        value = double.Parse(twoPartsArray[1].Trim());
                                    }
                                    catch
                                    {
                                        return true;
                                    }
                                    //parse value for value graph parameter;
                                    graphParamResultItem.Value = value;
                                    graphLineData1.ResultList.Add(graphParamResultItem);

                                }
                                //The matched value owner by graphLineData2
                                if (graphLineData2.ParamSetting.StringValue.IndexOf(twoPartsArray[0].Trim()) >= 0)
                                {
                                    double value;
                                    //parse value for value graph parameter;
                                    try
                                    {
                                        value = double.Parse(twoPartsArray[1]);
                                    }
                                    catch
                                    {
                                        return true;
                                    }
                                    //parse value for value graph parameter;
                                    graphParamResultItem.Value = value;

                                    graphLineData2.ResultList.Add(graphParamResultItem);

                                }
                                break;
                        }
                    }
                    //Build event result list
                    foreach (GraphResult graphResult in eventResults)
                    {
                        if (message.Contains(graphResult.ParamSetting.StringValue))
                        {
                            GraphParamResultItem eventGraphParamResultItem = graphParamResultItem.Clone();
                            eventGraphParamResultItem.Value = 0;
                                MatchCollection match = rg.Matches(message);
                                if (match.Count > 0)
                                {
                                    MatchCollection match1 = rg1.Matches(match[0].Value);
                                    if (match1.Count > 0)
                                    {
                                        try
                                        {
                                            eventGraphParamResultItem.Value = double.Parse(match1[0].Value);
                                        }
                                        catch { eventGraphParamResultItem.Value = 0; }
                                    }
                                    else
                                    {
                                        eventGraphParamResultItem.Value = 0;
                                    }
                                }
                                else {
                                    eventGraphParamResultItem.Value = 0;
                                }
                            //Get event millisecond
                            graphResult.ResultList.Add(eventGraphParamResultItem);
                        }
                    }
            
            }
            return false;
        }

        private List<string> BuildSearchPattern(IList<GraphParamSetting> paramList)
        {
            List<string> paramValueArray = new List<string>();
            foreach (GraphParamSetting param in paramList)
            {
                if (param.Enabled)
                {
                    string strformat;
                    if (param.GraphTypeValue == GraphType.Event)
                    {
                        strformat = string.Format(@"(\r?{0})",Regex.Escape(param.StringValue));
                    }
                    else
                    {
                        //Replace colon to string empty
                        Regex r = new Regex(@"([:|\s*]$)");
                        string replaceString = r.Replace(param.StringValue.Trim(), String.Empty);


                        strformat = string.Format(@"(\r?({0})(\s*:\s*)(-?[0-9]\d*(.\d+)?))", Regex.Escape(replaceString));
                    }
                    paramValueArray.Add(strformat);
                }
            }
            return paramValueArray;
        }

        private int InitGraphLineData(IList<GraphParamSetting> paramList, GraphResult graphLineData1, GraphResult graphLineData2, IList<GraphResult> eventResults)
        {
            List<GraphParamSetting> twoGraphParamSetting = paramList.Where(p => (p.Enabled && p.GraphTypeValue == GraphType.Value)).Take(2).ToList();
            List<GraphParamSetting> paramSettingEventList = paramList.Where(p => (p.Enabled && p.GraphTypeValue == GraphType.Event)).ToList();

            //Build two GraphParamSetting for 2 line data
            switch (twoGraphParamSetting.Count)
            {
                case 1:
                    graphLineData1.ParamSetting = twoGraphParamSetting[0];
                    break;
                case 2:
                    graphLineData1.ParamSetting = twoGraphParamSetting[0];
                    graphLineData2.ParamSetting = twoGraphParamSetting[1];
                    break;
            }
            //Build eventResultList
            foreach (GraphParamSetting graphParamSetting in paramSettingEventList)
            {
                GraphResult graphResult = new GraphResult();
                graphResult.ParamSetting = graphParamSetting;
                eventResults.Add(graphResult);
            }
            return twoGraphParamSetting.Count;
        }
        /// <summary>
        /// Get value of a column specified by log item parameter.
        /// </summary>
        /// <param name="record"><see cref="CXDILogRecord"/></param>
        /// <param name="logItem">Name of log column</param>
        /// <returns>Value of the column</returns>
        protected override string GetColumnValue(CXDILogRecord record, string logItem)
        {
            if (record == null) return string.Empty;
            //Line
            if (logItem.Contains(ConfigValue.CXDIHeader.HEADER_LINE))
            {
                return record.Line.ToString();
            }
            //Date
            if (logItem.Contains(ConfigValue.CXDIHeader.HEADER_DATE))
            {
                 return record.Date;
            }
            //Time
            if (logItem.Contains(ConfigValue.CXDIHeader.HEADER_TIME))
            {
                return record.Time;
            }

            if (logItem.Contains(ConfigValue.CXDIHeader.HEADER_MESSAGE))
            {
                return record.Message;
            }
            if (logItem.Contains(ConfigValue.CXDIHeader.HEADER_MODULE))
            {
                return record.Module;
            }

            if (logItem.Contains(ConfigValue.CXDIHeader.HEADER_COMMENT))
            {
                if (_comments.ContainsKey(record))
                {
                    return _comments[record];
                }
                return string.Empty;
            }
            return string.Empty;
        }
    }
}