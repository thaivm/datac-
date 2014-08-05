using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using LogViewer.Model;

namespace LogViewer.Business.FileParser
{
    /// <summary>
    /// Class provides methods for extracting data from CXDI log file.
    /// </summary>
    public class CXDIParser : BaseParser<CXDILogRecord>, ILogParser<CXDILogRecord>
    {

        private bool IsHeaderCount { get; set; }
        private bool IsHeaderSaved { get; set; }
        private bool IsMessageLog { get; set; }
        private bool IsMessageErrorLog { get; set; }

        readonly string[] _firstSeperator = { "][" };
        readonly string[] _secondSeperator = { "]:" };
        readonly char[] _spaceSeperator = { ' ' };

        /// <summary>
        /// Parse CXDI log file.
        /// </summary>
        /// <param name="filePath">The path of log file</param>
        /// <returns>This hold records of log file, bookmark and comment.
        /// </returns>
        public virtual List<CXDILogRecord> ParserFromFile(string filePath)
        {
            var cxdiLogRecords = new List<CXDILogRecord>();
            var cxdilogNeedResetSensorDateList = new List<CXDILogRecord>();

            var i = 1;
            foreach (var lines in File.ReadAllLines(filePath, Encoding.UTF8))
            {
                if (SetBlogArea(lines) == true)
                {
                    continue;
                }
                if (IsMessageLog == true)
                {
                    if (!lines.Trim().Equals("") && lines[0].ToString().Equals("["))
                    {
                        string[] split = lines.Split(_firstSeperator,StringSplitOptions.None);
                        if (split.Length != 2)
                        {
                            continue;
                        }
                        ParseLine(cxdiLogRecords, i, split);
                        CorrectDateWhenSensorInit(cxdiLogRecords, cxdilogNeedResetSensorDateList, i-1);

                        i++;
                    }
                }
            }
            return cxdiLogRecords;
        }

        protected void ParseLine(List<CXDILogRecord> cxdiLogRecords, int i, string[] split)
        {
            string datetime = split[0].Substring(1);
            try
            {
                DateTime d = DateTime.Parse(datetime);

                //DateTime dt = Convert.ToDateTime(datetime);
                //string date = dt.Date.ToString("yyyy/MM/dd");
                //DateTime myTime = default(DateTime).Add(dt.TimeOfDay);
                //string time = myTime.ToString("hh:mm:ss.fff");

                string[] contents = split[1].Split(_secondSeperator, StringSplitOptions.None);
                string module = contents[0];
                string message = split[1].Substring(split[1].IndexOf(contents[1]));



                CXDILogRecord cxdiLogRecord = new CXDILogRecord()
                {
                    Line = i,
                    DateTime=d,
                    Module = module,
                    Message = message
                };

                cxdiLogRecords.Add(cxdiLogRecord);
            }
            catch
            {
            }

        }
        
        /// <summary>
        /// Extract firmware from log file.
        /// </summary>
        /// <param name="filePath">Location log file</param>
        /// <returns><see cref="CXDIFirmware"/></returns>
        public CXDIFirmware GetFirmware(string filePath)
        {
            var cxdiFirmware = new CXDIFirmware();
            ExtractFirmware(ReadAllLines(filePath), cxdiFirmware);
            return cxdiFirmware;
        }
        /// <summary>
        /// Extract firmware from log file.
        /// </summary>
        /// <param name="reader">Content of log file <see cref="StringReader"/></param>
        /// <returns><see cref="CXDIFirmware"/></returns>
        public CXDIFirmware GetFirmware(StringReader reader)
        {
            var cxdiFirmware = new CXDIFirmware();
            ExtractFirmware(ReadAllLines(reader), cxdiFirmware);
            return cxdiFirmware;
        }

        private void ExtractFirmware(IEnumerable<string> logLines, CXDIFirmware cxdiFirmware)
        {
            if (logLines == null) return;
            foreach (var lines in logLines)
            {
                if (SetBlogArea(lines) == true)
                {
                    continue;
                }
                if (IsHeaderCount == true)
                {
                    string[] split = lines.Split(':');
                    var counter = new Counter
                    {
                        parameter = split[0],
                        value = lines.Substring(split[0].Length + 1)
                    };
                    cxdiFirmware.Counter.Add(counter);
                }
                if (IsHeaderSaved == true)
                {
                    string[] split = lines.Split(':');
                    var saved = new Saved
                    {
                        parameter = split[0],
                        value = lines.Substring(split[0].Length + 1)
                    };
                    cxdiFirmware.Saved.Add(saved);
                }
                if (IsMessageLog == true || IsMessageErrorLog)
                {
                    break;
                }
            }
        }

      

        private IEnumerable<string> ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private IEnumerable<string> ReadAllLines(StringReader reader)
        {
            string lines;
            var array = new List<string>();
            while ((lines = reader.ReadLine()) != null)
            {
                array.Add(lines);
            }
            return array.ToArray();
        }

        private bool SetBlogArea(string line)
        {
            bool flag = false;
            if (line.Contains(ConfigValue.COUNTER_PARAMETER))
            {
                IsHeaderCount = true;
                IsHeaderSaved = false;
                IsMessageLog = false;
                IsMessageErrorLog = false;
                flag = true;
            }
            if (line.Contains(ConfigValue.END_COUNTER_PARAMETER))
            {
                IsHeaderCount = false;
                IsHeaderSaved = false;
                IsMessageLog = false;
                IsMessageErrorLog = false;
                flag = true;
            }
            if (line.Contains(ConfigValue.SAVE_PARAMETER))
            {
                IsHeaderCount = false;
                IsHeaderSaved = true;
                IsMessageLog = false;
                IsMessageErrorLog = false;
                flag = true;
            }
            if (line.Contains(ConfigValue.MESSAGE_ERROR_LOG))
            {
                IsHeaderCount = false;
                IsHeaderSaved = false;
                IsMessageLog = false;
                IsMessageErrorLog = true;
                flag = true;
            }
            if (line.Contains(ConfigValue.MESSAGE_LOG))
            {
                IsHeaderCount = false;
                IsHeaderSaved = false;
                IsMessageLog = true;
                IsMessageErrorLog = false;
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Load all log record from a log builder.
        /// </summary>
        /// <param name="reader">The string reader was used to read log record</param>
        /// <returns></returns>
        public virtual List<CXDILogRecord> ParserFromFile(StringReader reader)
        {

            var cxdiLogRecords = new List<CXDILogRecord>();
            var cxdilogNeedResetSensorDateList = new List<CXDILogRecord>();

            int i = 1;
            string lines;
            while ((lines = reader.ReadLine()) != null)
            {
                if (SetBlogArea(lines) == true)
                {
                    continue;
                }
                if (IsMessageLog == true)
                {
                    if (!lines.Trim().Equals("") && lines[0].ToString().Equals("["))
                    {
                        string[] split = lines.Split(_firstSeperator, StringSplitOptions.None);
                        if (split.Length != 2)
                        {
                            continue;
                        }
                        ParseLine(cxdiLogRecords, i, split);
                        CorrectDateWhenSensorInit(cxdiLogRecords, cxdilogNeedResetSensorDateList, i - 1);

                        i++;
                    }
                }
            }
            return cxdiLogRecords;


        }
       
        private void CorrectDateWhenSensorInit(IList<CXDILogRecord> cxdiLogRecords, ICollection<CXDILogRecord> cxdilogNeedResetSensorDateList, int i)
        {
            if (cxdiLogRecords == null) return;
            if (cxdilogNeedResetSensorDateList == null)
                return;
            if (cxdiLogRecords[i].Date.IndexOf(ConfigValue.SensorInitTime) >= 0)
            {
                cxdilogNeedResetSensorDateList.Add(cxdiLogRecords[i]);

            }
            if (cxdilogNeedResetSensorDateList.Count > 0)
            {
                if (cxdiLogRecords[i].Date.IndexOf(ConfigValue.SensorInitTime) < 0)
                {
                    foreach (CXDILogRecord record in cxdilogNeedResetSensorDateList)
                    {
                        //record.Date=cxdiLogRecords[i].Date.Clone().ToString();

                        try
                        {
                            string afterDate = cxdiLogRecords[i].Date.Clone().ToString();
                            string afterTime = Convert.ToDateTime(string.Format("{0} {1}", cxdiLogRecords[i].Date, cxdiLogRecords[i].Time)).ToString("HH:mm:ss.fff");
                            
                            record.DateTime = DateTime.Parse(string.Format("{0} {1}",afterDate,afterTime));
                            
                        }
                        catch { }
                    }
                    cxdilogNeedResetSensorDateList.Clear();
                }
            }
        }
        /// <summary>
        /// Check for given file by filePath is CXDI log file or not
        /// </summary>
        /// <param name="filePath">The path of given log file</param>
        /// <returns>True: if the give file is CXDI, otherwise is false.</returns>
        public static bool IsCxdIlogType(string filePath)
        {
            var cxdiParser = new CXDIParser();
            try
            {
                CXDIFirmware firmware = cxdiParser.GetFirmware(filePath);
                if (firmware.Counter.Count > 0 || firmware.Saved.Count > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        /// <summary>
        /// Check for given file by filePath is CXDI log file or not
        /// </summary>
        /// <param name="reader">Hold log data in StringReader object</param>
        /// <returns>True: if the give file is CXDI, otherwise is false.</returns>
        public static bool IsCxdIlogType(StringReader reader)
        {
            var cxdiParser = new CXDIParser();
            try
            {
                var firmware = cxdiParser.GetFirmware(reader);
                if (firmware.Counter.Count > 0 || firmware.Saved.Count > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

    }
}
