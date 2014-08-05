// File:    CCSParser.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 1:29:52 PM
// Purpose: Definition of Class CCSParser

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using LogViewer.Model;

namespace LogViewer.Business.FileParser
{
    /// <summary>
    /// Class provides methods for extracting data from CCS log file. This class support for CCS new version
    /// </summary>
    public class CCSParserNew : BaseParser<CCSLogRecord>, ILogParser<CCSLogRecord>
    {
        readonly char[] _colonSeperator = { ',' };
        readonly char[] _spaceSeperator = { ' ' };

        /// <summary>
        /// Parse CCS log file for CCS new version.
        /// </summary>
        /// <param name="filePath">The path of log file</param>
        /// <returns>This hold records of log file.
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
                    string line = sr.ReadLine();

                    if (HasBeginLogRecord(line, ParserManager.BeginLogLineFormatCcsVersion2) && HasBeginLogRecord(strBuffer, ParserManager.BeginLogLineFormatCcsVersion2))
                    {
                        try
                        {
                            ParserLine(ccsLogRecords, ref i, ref strBuffer, _colonSeperator,_spaceSeperator);
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
                if (HasBeginLogRecord(strBuffer, ParserManager.BeginLogLineFormatCcsVersion2))
                {
                    ParserLine(ccsLogRecords, ref i, ref strBuffer, _colonSeperator,_spaceSeperator);
                }
                sr.Close();
            }
            return ccsLogRecords;
        }

        /// <summary>
        /// Parse CCS log file for CCS new version.
        /// </summary>
        /// <param name="reader">String of log file hold by StringReader object</param>
        /// <returns>This hold records of log file.
        /// </returns>
        public virtual List<CCSLogRecord> ParserFromFile(StringReader reader)
        {
            var ccsLogRecords = new List<CCSLogRecord>();
            try
            {
                int i = 1;
                string strBuffer = string.Empty;
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    if (HasBeginLogRecord(line, ParserManager.BeginLogLineFormatCcsVersion2) && HasBeginLogRecord(strBuffer, ParserManager.BeginLogLineFormatCcsVersion2))
                    {
                        ParserLine(ccsLogRecords, ref i, ref strBuffer,_colonSeperator,_spaceSeperator);
                        strBuffer = line;
                        continue;
                    }
                    strBuffer += line;

                }
                if (HasBeginLogRecord(strBuffer, ParserManager.BeginLogLineFormatCcsVersion2))
                {
                    ParserLine(ccsLogRecords, ref i, ref strBuffer, _colonSeperator,_spaceSeperator);
                }
            }
            catch
            {
                throw;
            }

            return ccsLogRecords;

        }
        private void ParserLine(List<CCSLogRecord> ccsLogRecords, ref int i, ref string strBuffer, char[] colonSeperator, char[] spaceSeperator)
        {
            //var values = strBuffer.Split(colonSeperator, StringSplitOptions.None);
            var values = Array.ConvertAll(strBuffer.Split(colonSeperator, StringSplitOptions.None), p => p.Trim());
            string id = values[4];
            string datetime = values[0];

            try
            {
                DateTime d = DateTime.Parse(datetime);
                //DateTime dt = Convert.ToDateTime(datetime);
                //string date = dt.Date.ToString("yyyy/MM/dd");
                //DateTime myTime = default(DateTime).Add(dt.TimeOfDay);
                //string time = myTime.ToString("hh:mm:ss.fff");
                string type = values[3];

                string contents;
                //process for colon symbol
                if (values.Length > 9)
                {
                    var arr = new List<string>();
                    for (var column = 5; column < values.Length - 3; column++)
                    {
                        arr.Add(values[column]);
                    }
                    contents = string.Join(",", arr.ToArray());
                }
                else
                    contents = values[5];
                string hostName = values[1];
                string className = values[values.Length - 1];
                string threadId = values[2];

                var ccsLog = new CCSLogRecord
                {
                    Id = id,
                    DateTime=d,
                    Type = type,
                    Line = i++,
                    ClassName = className,
                    ThreadId = threadId,
                    AdditionalInfo = values[values.Length - 3],
                    PersonalInfo = values[values.Length - 2],
                    Content = contents,
                    HostName = hostName,
                    Module = string.Empty,
                    Mode = string.Empty
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