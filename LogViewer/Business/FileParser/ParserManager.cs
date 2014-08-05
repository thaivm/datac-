using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using LogViewer.Model;

namespace LogViewer.Business.FileParser
{
    /// <summary>
    /// Version of all CCS log file: CcsVersion1(for the old version), CcsVersion2 (for the new version), UnknowFormat(undetected version)
    /// </summary>
    enum CcsFileParserType { CcsVersion1, CcsVersion2, UnknowFormat };
    /// <summary>
    /// Version of CXDI log file: CxdiVersion1(only one version currently), UnknowFormat(undetected version)
    /// </summary>
    enum CxdiFileParserType { CxdiVersion1, UnknowFormat };
    /// <summary>
    /// For detecting type of file: Memo(if the file is a memo file), CCS (if the file is CCS), CXDI(if the file is CXDI), UnknowType (cannot detected file)
    /// </summary>
    enum LogFileExt { Memo, Ccs, Cxdi, CCSMemo, CXDIMemo, UnknowType };
    /// <summary>
    /// Class provides static methods for detection file type, get the right log parser, memo parser object
    /// </summary>
    class ParserManager
    {
        /// <summary>
        /// Pattern for detection a new version CCS log file. The date format of log record will be used to detect CCS version.
        /// Detection format for CCS old version is: "number-number-number number:number:number.number"
        /// </summary>
        public static Regex BeginLogLineFormatCcsVersion1 =
            new Regex(@"(\d+)[-](\d+)[-](\d+)\s(\d+)[:](\d+)[:](\d+)[.](\d+)");

        /// <summary>
        /// Pattern for detection a new version CCS log file. The date format of log record will be used to detect CCS version.
        /// Detection format for CCS old version is: "number/number/number number:number:number.number"
        /// </summary>
        public static Regex BeginLogLineFormatCcsVersion2 =
            new Regex(@"(\d+)[/](\d+)[/](\d+)\s(\d+)[:](\d+)[:](\d+)[.](\d+)");
        /// <summary>
        /// Detect file type
        /// </summary>
        /// <param name="filePath">Location of file</param>
        /// <returns>Type of file, see the <see cref="LogFileExt"/></returns>
        public static LogFileExt DetectFileType(string filePath)
        {
            try
            {
                string ext = Path.GetExtension(filePath);
                string[] ccsType = { ".txt", ".csv" };
                if (CXDIParser.IsCxdIlogType(filePath) && ext.Contains(".xml")) return LogFileExt.Memo;
                else
                    if (CXDIParser.IsCxdIlogType(filePath))return LogFileExt.Cxdi;

                if (ext != null && ext.Contains(".xml")) return LogFileExt.Memo;
                CcsFileParserType ccsVersion = DetectCcsVersion(filePath);
                if (ccsVersion != CcsFileParserType.UnknowFormat) return LogFileExt.Ccs;
                return LogFileExt.UnknowType;
            }
            catch
            {
                return LogFileExt.UnknowType;
            }
        }
        /// <summary>
        /// Detect file type
        /// </summary>
        /// <param name="filePath">Location of file</param>
        /// <returns>Type of file, see the <see cref="LogFileExt"/></returns>
        public static LogFileExt DetectTypeOfMemoFile(string filePath)
        {
            try
            {
                string ext = Path.GetExtension(filePath);
                if (ext != null && ext.Contains(".xml"))
                {
                    var doc = new XmlDocument();
                    doc.Load(filePath);
                    //detect cxdi file 
                    var logAreaCxdi =
                        doc.SelectSingleNode("/UserMemorizedLogData/CXDI/LogArea");
                    if (logAreaCxdi != null)
                    {
                        var logContent = new StringReader(logAreaCxdi.InnerText);
                        var cxdiFileType = CxdiFileParserType.UnknowFormat;
                        if (CXDIParser.IsCxdIlogType(logContent)) cxdiFileType = CxdiFileParserType.CxdiVersion1;
                        logContent.Close();
                        logContent.Dispose();
                        if (cxdiFileType != CxdiFileParserType.UnknowFormat) { return LogFileExt.CXDIMemo; }
                    }
                    //detect ccs file
                    //detect cxdi file 
                    var logAreaCcs =
                        doc.SelectSingleNode("/UserMemorizedLogData/CCS/LogArea");
                    if (logAreaCcs != null)
                    {
                        var logContent = new StringReader(logAreaCcs.InnerText);
                        var ccsFileType = CcsFileParserType.UnknowFormat;
                        ccsFileType = DetectCcsVersion(logContent);

                        logContent.Close();
                        logContent.Dispose();
                        if (ccsFileType != CcsFileParserType.UnknowFormat) { return LogFileExt.CCSMemo; }
                    }
                }
            }
            catch
            {
                return LogFileExt.UnknowType;
            }
            return LogFileExt.UnknowType;

        }

        /// <summary>
        /// Auto detect and return parser object depend on version of CCS memo file.
        /// </summary>
        /// <param name="filePath">Location of file</param>
        /// <returns>Parser object, any of type: <see cref="CCSMemoParserOld"/>, <see cref="CCSMemoParserNew"/> or throw Exception if 
        /// cannot detect the format</returns>
        public static ILogParser<CCSLogRecord> GetCcsMemoParser(string filePath)
        {
            var fileType = CcsFileParserType.UnknowFormat;


            try
            {
                var doc = new XmlDocument();
                doc.Load(filePath);
                //Load log LogArea
                //hard code.
                var logArea =
                    doc.SelectSingleNode("/UserMemorizedLogData/CCS/LogArea");
                if (logArea != null)
                {
                    var logContent = new StringReader(logArea.InnerText);
                    fileType = DetectCcsVersion(logContent);
                    logContent.Close();
                    logContent.Dispose();
                }
            }
            catch
            {
                throw new Exception(Properties.Resources.NOT_DETECT_FORMAT_FILE_EXCEPTION);
            }

            if (fileType == CcsFileParserType.CcsVersion1)
            {
                return new CCSMemoParserOld();
            }
            if (fileType == CcsFileParserType.CcsVersion2)
            {
                return new CCSMemoParserNew();
            }
            else throw new Exception(Properties.Resources.NOT_DETECT_FORMAT_FILE_EXCEPTION);
        }

        /// <summary>
        /// Auto detect and return parser object depend on version of CCS file.
        /// </summary>
        /// <param name="filePath">Location of file</param>
        /// <returns>Parser object, any of type: <see cref="CCSMemoParserOld"/>, <see cref="CCSMemoParserNew"/> or throw Exception if 
        /// cannot detect the format</returns>

        public static ILogParser<CCSLogRecord> GetCcsCsvParser(string filePath)
        {
            var fileType = DetectCcsVersion(filePath);
            if (fileType == CcsFileParserType.CcsVersion1)
            {
                return new CCSParserOld();
            }
            if (fileType == CcsFileParserType.CcsVersion2)
            {
                return new CCSParserNew();
            }
            else throw new Exception(Properties.Resources.NOT_DETECT_FORMAT_FILE_EXCEPTION);
        }

        /// <summary>
        /// Auto detect and return parser object depend on version of CCS file.
        /// </summary>
        /// <param name="reader">log data hold by StringReader object </param>
        /// <returns>Parser object, any of type: <see cref="CCSMemoParserOld"/>, <see cref="CCSMemoParserNew"/> or throw Exception if 
        /// cannot detect the format</returns>
        public static ILogParser<CCSLogRecord> GetCcsCsvParser(StringReader reader)
        {
            var fileType = DetectCcsVersion(reader);
            if (fileType == CcsFileParserType.CcsVersion1)
            {
                return new CCSParserOld();
            }
            if (fileType == CcsFileParserType.CcsVersion2)
            {
                return new CCSParserNew();
            }
            else throw new Exception(Properties.Resources.NOT_DETECT_FORMAT_FILE_EXCEPTION);
        }
        /// <summary>
        /// Auto detect and return parser object for CXDI file.
        /// </summary>
        /// <param name="filePath">Location of file</param>
        /// <returns> <see cref="CXDIParser">CXDIParser</see> object, throw Exception if 
        /// cannot detect the format</returns>

        public static ILogParser<CXDILogRecord> GetCxdiCsvLogParser(string filePath)
        {
            CxdiFileParserType fileType = DetectCxdiVersion(filePath);
            if (fileType == CxdiFileParserType.CxdiVersion1)
            {
                return new CXDIParser();
            }
            else throw new Exception(Properties.Resources.NOT_DETECT_FORMAT_FILE_EXCEPTION);
        }
        /// <summary>
        /// Auto detect and return parser object for CXDI memo file.
        /// </summary>
        /// <param name="filePath">Location of file</param>
        /// <returns> <see cref="CXDIMemoParser">CXDIMemoParser</see> object</returns>

        public static ILogParser<CXDILogRecord> GetCxdiMemoParser(string filePath)
        {
            return new CXDIMemoParser();
        }

        /// <summary>
        /// Detect version of ccs log file base one number of column in a log block
        /// </summary>
        /// <param name="filePath">path to the log file</param>
        /// <returns>ccs log version: CCSFileParserType.CCSVersion1 (for old version), 
        /// CCSFileParserType.CCSVersion2 (for new version),
        /// CCSFileParserType.UnknowVersion (cannot detect version)
        /// </returns>
        protected static CcsFileParserType DetectCcsVersion(string filePath)
        {
            try
            {
                string strBuffer = string.Empty;

                using (var sr = new StreamReader(filePath, Encoding.Default))
                {
                    string line;
                    while (sr.Peek() >= 0)
                    {
                        line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line)) continue;
                        if (BeginLogLineFormatCcsVersion1.IsMatch(line)) return CcsFileParserType.CcsVersion1;
                        if (BeginLogLineFormatCcsVersion2.IsMatch(line)) return CcsFileParserType.CcsVersion2;
                        else return CcsFileParserType.UnknowFormat;
                    }
                    sr.Close();
                }
            }
            catch
            {
                throw new Exception(Properties.Resources.NOT_READ_FILE_EXCEPTION + filePath);
            }
            return CcsFileParserType.UnknowFormat;
        }

        protected static CcsFileParserType DetectCcsVersion(StringReader sr)
        {
            string strBuffer = string.Empty;

            string line;
            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;
                if (BeginLogLineFormatCcsVersion1.IsMatch(line)) return CcsFileParserType.CcsVersion1;
                if (BeginLogLineFormatCcsVersion2.IsMatch(line)) return CcsFileParserType.CcsVersion2;
                else return CcsFileParserType.UnknowFormat;
            }
            return CcsFileParserType.UnknowFormat;
        }



        protected static CxdiFileParserType DetectCxdiVersion(string filePath)
        {
            if (filePath == null) return CxdiFileParserType.UnknowFormat;
            return CXDIParser.IsCxdIlogType(filePath)
                ? CxdiFileParserType.CxdiVersion1
                : CxdiFileParserType.UnknowFormat;
        }

        protected static CxdiFileParserType DetectCxdiVersion(StringReader sr)
        {
            if (sr == null) return CxdiFileParserType.UnknowFormat;
            return CXDIParser.IsCxdIlogType(sr) ? CxdiFileParserType.CxdiVersion1 : CxdiFileParserType.UnknowFormat;
        }

    }
}
