using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using LogViewer.Model;

namespace LogViewer.Business.FileParser
{
    /// <summary>
    /// Class provides methods for extracting data from CCS log file. This class support for CCS old version
    /// </summary>

    class CCSParserOld : BaseParser<CCSLogRecord>, ILogParser<CCSLogRecord>
    {
        readonly char[] _colonSeperator = { ',' };
        readonly char[] _spaceSeperator = { ' ' };
        /// <summary>
        /// Parse CCS log file for CCS old version.
        /// </summary>
        /// <param name="filePath">The path of log file</param>
        /// <returns>This hold records of log file
        /// </returns>
        public virtual List<CCSLogRecord> ParserFromFile(string filePath)
        {

            var ccsLogRecords = new List<CCSLogRecord>();
            int i = 1;
            string strBuffer = string.Empty;
            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {
                while (sr.Peek() >= 0)
                {

                    var line = sr.ReadLine();

                    if (HasBeginLogRecord(line, ParserManager.BeginLogLineFormatCcsVersion1) && HasBeginLogRecord(strBuffer, ParserManager.BeginLogLineFormatCcsVersion1))
                    {
                        try
                        {
                            ParserLine(ccsLogRecords, ref i, ref strBuffer, _colonSeperator, _spaceSeperator);
                            strBuffer = line;
                            continue;
                        }
                        catch
                        {
                            //throw new Exception(string.Format(Properties.Resources.WRONG_FORMAT_FILE_EXCEPTION, line));
                        }
                    }
                    strBuffer += line;
                }
                if (HasBeginLogRecord(strBuffer, ParserManager.BeginLogLineFormatCcsVersion1))
                {
                    ParserLine(ccsLogRecords, ref i, ref strBuffer, _colonSeperator, _spaceSeperator);
                }
                sr.Close();
            }
            return ccsLogRecords;
        }

        /// <summary>
        /// Parse CCS log file for CCS old version.
        /// </summary>
        /// <param name="reader">String of log file hold by StringReader object</param>
        /// <returns>This hold records of log file.
        /// </returns>
        public virtual List<CCSLogRecord> ParserFromFile(StringReader reader)
        {
            var ccsLogRecords = new List<CCSLogRecord>();

            int i = 1;
            string strBuffer = string.Empty;
            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLine();
                if (HasBeginLogRecord(line, ParserManager.BeginLogLineFormatCcsVersion1) && HasBeginLogRecord(strBuffer, ParserManager.BeginLogLineFormatCcsVersion1))
                {
                    ParserLine(ccsLogRecords, ref i, ref strBuffer, _colonSeperator, _spaceSeperator);
                    strBuffer = line;
                    continue;
                }
                strBuffer += line;

            }
            if (HasBeginLogRecord(strBuffer, ParserManager.BeginLogLineFormatCcsVersion1))
            {
                ParserLine(ccsLogRecords, ref i, ref strBuffer, _colonSeperator, _spaceSeperator);
            }

            return ccsLogRecords;

        }
        private static void ParserLine(ICollection<CCSLogRecord> ccsLogRecords, ref int i, ref string strBuffer, char[] colonSeperator, char[] spaceSeperator)
        {
            if (strBuffer.Contains('\0'))
            {
                strBuffer = strBuffer.Replace('\0', ' ');
            }
            //var values = strBuffer.Split(colonSeperator, StringSplitOptions.None);
            var values = Array.ConvertAll(strBuffer.Split(colonSeperator, StringSplitOptions.None), p => p.Trim());
            string id = values[5];
            string datetime = values[0];
            try
            {
               DateTime d= DateTime.Parse(datetime);

                string[] dateTimeArr = datetime.Split(spaceSeperator, StringSplitOptions.None);
                string type = values[4];
                string contents;
                //process for colon symbol
                if (values.Length > 10)
                {
                    var arr = new List<string>();
                    //Ignore for 2 column 7,8
                    for (var column = 6; column <= values.Length - 4; column++)
                    {
                        arr.Add(values[column]);
                    }
                    contents = string.Join(",", arr.ToArray());
                }
                else
                    contents = values[6];

                string hostName = values[1];
                string className = values[values.Length - 1];
                string threadId = values[3];

                var ccsLog = new CCSLogRecord
                {
                    Id = id,
                    DateTime = d,
                    Type = type,
                    Line = i++,
                    ClassName = className,
                    ThreadId = threadId,
                    AdditionalInfo = values[values.Length - 3],
                    PersonalInfo = values[values.Length - 2],
                    Content = contents,
                    HostName = hostName,
                    Mode = values[2],
                    Module = string.Empty
                };
                ccsLogRecords.Add(ccsLog);
            }
            catch
            {
            }


        }

        private static bool HasBeginLogRecord(string strBuffer, Regex reg)
        {
            if (strBuffer == null || strBuffer.Trim().Length == 0) return false;

            return reg.IsMatch(strBuffer);
        }

    }
}
