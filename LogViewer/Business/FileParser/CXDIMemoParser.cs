using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using LogViewer.Model;
using LogViewer.Util;

namespace LogViewer.Business.FileParser
{
    /// <summary>
    /// Class provides methods for extracting log or writing memo CXDI log file.
    /// </summary>
    class CXDIMemoParser : CXDIParser, ILogMemoParser<CXDILogRecord>
    {
        /// <summary>
        /// Store information of 
        /// </summary>
        public CXDIFirmware FirmWare { set; get; }

        /// <summary>
        /// Extract data from CXDI memo log file.
        /// </summary>
        /// <param name="filePath">The path of log file</param>
        /// <returns>MemoLog<T> object, this hold records of log file, bookmark and comment.
        /// </returns>
        public virtual MemoLog<CXDILogRecord> ParserFromFile(string filePath)
        {
            var memoLog = new MemoLog<CXDILogRecord>();

            if (File.Exists(filePath))
            {
                var doc = new XmlDocument();
                doc.Load(filePath);
                //Load log LogArea
                var logArea =
                    doc.SelectSingleNode("/UserMemorizedLogData/CXDI/LogArea");
                if (logArea != null)
                {
                    var logContent = new StringReader(logArea.InnerText);
                    var ls = base.ParserFromFile(logContent);
                    if (ls != null) memoLog.Records = ls;
                }

                //Load comments
                XmlNodeList commentList =
                    doc.SelectNodes("/UserMemorizedLogData/CXDI/CommentArea/Comment");
                if (commentList != null)
                    foreach (XmlNode comment in commentList)
                    {
                        if (comment.Attributes != null)
                        {
                            var line = comment.Attributes.GetNamedItem("Line").Value;
                            var cxdiRecord = memoLog.Records.FirstOrDefault(record => record.Line.ToString().Equals(line));
                            if (cxdiRecord != null)
                            {
                                memoLog.Comments.Add(cxdiRecord, comment.InnerText);
                            }
                        }
                    }

                //Load bookmark
                var bookmarList =
                    doc.SelectNodes("/UserMemorizedLogData/CXDI/BookmarkArea/Bookmark");
                //Load comments
                if (bookmarList != null)
                    foreach (XmlNode bookmark in bookmarList)
                    {
                        if (bookmark.Attributes != null)
                        {
                            var line = bookmark.Attributes.GetNamedItem("Line").Value;
                            var ccsRecord = memoLog.Records.FirstOrDefault(record => record.Line.ToString().Equals(line));
                            if (ccsRecord != null)
                                memoLog.Bookmarks.Add(ccsRecord);
                        }
                    }
            }
            return memoLog;
        }

        /// <summary>
        /// Export log records, comments and bookmarks to memo long in an XML file.
        /// </summary>
        /// <param name="filePath">location of an XML file</param>
        public bool WriteMemoLogFile(string filePath)
        {
            if (LogRecords == null || LogRecords.Count == 0) return false;
            try
            {

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    using (XmlWriter w = XmlWriter.Create(fs))
                    {

                        var doc = new XmlDocument();
                        var docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        doc.AppendChild(docNode);

                        var userMemorizedLogData = doc.CreateElement("UserMemorizedLogData");
                        doc.AppendChild(userMemorizedLogData);
                        //Add ccs tag
                        var cxdi = doc.CreateElement("CXDI");
                        //Add comment area tag
                        var commentArea = doc.CreateElement("CommentArea");
                        cxdi.AppendChild(commentArea);
                        //Build comment tag
                        int commentid = 0;
                        if (Comments != null)
                            foreach (CXDILogRecord record in Comments.Keys)
                            {

                                var comment = doc.CreateElement("Comment");
                                //Build comment index
                                var commentId = doc.CreateAttribute("Id");
                                commentId.Value = commentid.ToString();
                                comment.Attributes.Append(commentId);
                                //Build record line
                                var commentLine = doc.CreateAttribute("Line");
                                commentLine.Value = record.Line.ToString();
                                comment.Attributes.Append(commentLine);
                                //Build comment content
                                comment.InnerText = Comments[record];
                                commentArea.AppendChild(comment);
                                commentid++;
                            }
                        //Add bookmark area
                        var bookmarkArea = doc.CreateElement("BookmarkArea");
                        cxdi.AppendChild(bookmarkArea);
                        int bookmarkIndex = 0;
                        if (Bookmarks != null)
                            foreach (var record in Bookmarks)
                            {
                                var bookmark = doc.CreateElement("Bookmark");
                                //Build bookmark index
                                var bookmakId = doc.CreateAttribute("Id");
                                bookmakId.Value = bookmarkIndex.ToString();
                                bookmark.Attributes.Append(bookmakId);
                                //Build bookmark line
                                var bookmakLine = doc.CreateAttribute("Line");
                                bookmakLine.Value = record.Line.ToString();
                                bookmark.Attributes.Append(bookmakLine);
                                bookmarkArea.AppendChild(bookmark);
                                bookmarkIndex++;
                            }

                        //Build LogArea
                        //Add bookmark area
                        var logArea = doc.CreateElement("LogArea");
                        var logAreaLine = doc.CreateAttribute("TotalLine");
                        logAreaLine.Value = LogRecords.Count.ToString();
                        logArea.Attributes.Append(logAreaLine);


                        var logContent = new StringBuilder();
                        logContent.AppendLine(ConfigValue.COUNTER_PARAMETER);
                        foreach (var counter in FirmWare.Counter)
                        {
                            logContent.AppendLine(string.Format("{0}:{1}", counter.parameter, counter.value));
                        }
                        logContent.AppendLine(ConfigValue.END_COUNTER_PARAMETER);
                        logContent.AppendLine(ConfigValue.SAVE_PARAMETER);
                        foreach (var save in FirmWare.Saved)
                        {
                            logContent.AppendLine(string.Format("{0}:{1}", save.parameter, save.value));
                        }
                        logContent.AppendLine(ConfigValue.MESSAGE_LOG);

                        foreach (var record in LogRecords)
                        {

                            logContent.AppendLine(string.Format("[{0} {1}][{2}]:{3}", Utility.NVL(record.Date), Utility.NVL(record.Time), Utility.NVL(record.Module), Utility.NVL(record.Message)));
                        }
                        logArea.InnerText = logContent.ToString();
                        cxdi.AppendChild(logArea);
                        userMemorizedLogData.AppendChild(cxdi);


                        doc.Save(w);
                        w.Close();
                    }
                    fs.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
