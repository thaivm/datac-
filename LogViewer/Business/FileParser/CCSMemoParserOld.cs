﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using LogViewer.Util;
using LogViewer.Model;

namespace LogViewer.Business.FileParser
{
    /// <summary>
    /// Class provides methods for parsing from or writing to an XML memo log file. This class support for CCS Old version
    /// </summary>

    class CCSMemoParserOld: CCSParserOld, ILogMemoParser<CCSLogRecord>
    {
        /// <summary>
        /// Parse CCS memo log file for CCS old version.
        /// </summary>
        /// <param name="filePath">The path of log file</param>
        /// <returns>MemoLog<T> object, this hold records of log file, bookmark and comment.
        /// </returns>
        public virtual MemoLog<CCSLogRecord> ParserFromFile(string filePath)
        {

            MemoLog<CCSLogRecord> memoLog = new MemoLog<CCSLogRecord>();

            if (File.Exists(filePath))
            {

                try
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePath);
                    //Load log LogArea
                    XmlNode logArea =
                        doc.SelectSingleNode("/UserMemorizedLogData/CCS/LogArea");
                    StringReader logContent = new StringReader(logArea.InnerText);
                    List<CCSLogRecord> ls = base.ParserFromFile(logContent);
                    logContent.Close();
                    logContent.Dispose();
                    if (ls != null) memoLog.Records = ls;

                    //Load comments
                    XmlNodeList commentList =
                        doc.SelectNodes("/UserMemorizedLogData/CCS/CommentArea/Comment");
                    foreach (XmlNode comment in commentList)
                    {

                        String line = comment.Attributes.GetNamedItem("Line").Value;
                        CCSLogRecord ccsRecord = memoLog.Records.Where(record => record.Line.ToString().Equals(line)).FirstOrDefault();
                        if (ccsRecord != null)
                        {
                            memoLog.Comments.Add(ccsRecord, comment.InnerText);
                        }
                    }

                    //Load bookmark
                    XmlNodeList bookmarList =
                        doc.SelectNodes("/UserMemorizedLogData/CCS/BookmarkArea/Bookmark");
                    //Load comments
                    foreach (XmlNode bookmark in bookmarList)
                    {

                        String line = bookmark.Attributes.GetNamedItem("Line").Value;
                        CCSLogRecord ccsRecord = memoLog.Records.Where(record => record.Line.ToString().Equals(line)).FirstOrDefault();
                        if (ccsRecord != null)
                            memoLog.Bookmarks.Add(ccsRecord);
                    }


                }
                catch (Exception e)
                {
                    //Read file error
                    throw e;
                }

            }
            return memoLog;
        }
        /// <summary>
        /// Export log records, comments and bookmarks to memo long in an XML file.
        /// </summary>
        /// <param name="filePath">location of an XML file</param>
        public bool WriteMemoLogFile(String filePath)
        {

            if (LogRecords == null || LogRecords.Count == 0) return false;
            try
            {

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (XmlWriter w = XmlWriter.Create(fs))
                    {

                        XmlDocument doc = new XmlDocument();
                        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        doc.AppendChild(docNode);

                        XmlNode UserMemorizedLogData = doc.CreateElement("UserMemorizedLogData");
                        doc.AppendChild(UserMemorizedLogData);
                        //Add CCS tag
                        XmlNode CCS = doc.CreateElement("CCS");
                        //Add comment area tag
                        XmlNode CommentArea = doc.CreateElement("CommentArea");
                        CCS.AppendChild(CommentArea);
                        //Build comment tag
                        int commentid = 0;
                        if (Comments != null)
                            foreach (CCSLogRecord record in Comments.Keys)
                            {

                                XmlNode Comment = doc.CreateElement("Comment");
                                //Build comment index
                                XmlAttribute commentId = doc.CreateAttribute("Id");
                                commentId.Value = commentid.ToString();
                                Comment.Attributes.Append(commentId);
                                //Build record line
                                XmlAttribute commentLine = doc.CreateAttribute("Line");
                                commentLine.Value = record.Line.ToString();
                                Comment.Attributes.Append(commentLine);
                                //Build comment content
                                Comment.InnerText = Comments[record];
                                CommentArea.AppendChild(Comment);
                                commentid++;
                            }
                        //Add bookmark area
                        XmlNode BookmarkArea = doc.CreateElement("BookmarkArea");
                        CCS.AppendChild(BookmarkArea);
                        int bookmarkIndex = 0;
                        if (Bookmarks != null)
                            foreach (CCSLogRecord record in Bookmarks)
                            {
                                XmlNode bookmark = doc.CreateElement("Bookmark");
                                //Build bookmark index
                                XmlAttribute bookmakID = doc.CreateAttribute("Id");
                                bookmakID.Value = bookmarkIndex.ToString();
                                bookmark.Attributes.Append(bookmakID);
                                //Build bookmark line
                                XmlAttribute bookmakLine = doc.CreateAttribute("Line");
                                bookmakLine.Value = record.Line.ToString();
                                bookmark.Attributes.Append(bookmakLine);
                                BookmarkArea.AppendChild(bookmark);
                                bookmarkIndex++;
                            }

                        //Build LogArea
                        //Add bookmark area
                        XmlNode LogArea = doc.CreateElement("LogArea");
                        XmlAttribute logAreaLine = doc.CreateAttribute("TotalLine");
                        logAreaLine.Value = LogRecords.Count.ToString();
                        LogArea.Attributes.Append(logAreaLine);
                        StringBuilder logContent = new StringBuilder();
                        foreach (CCSLogRecord record in LogRecords)
                        {
                            logContent.AppendLine(string.Format("{0} {1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", Utility.NVL(record.Date.Replace('/','-')), Utility.NVL(record.Time), Utility.NVL(record.HostName), Utility.NVL(record.Mode), Utility.NVL(record.ThreadId), Utility.NVL(record.Type), Utility.NVL(record.Id), Utility.NVL(record.Content), Utility.NVL(record.AdditionalInfo), Utility.NVL(record.PersonalInfo), Utility.NVL(record.ClassName)));
                        }
                        LogArea.InnerText = logContent.ToString();
                        CCS.AppendChild(LogArea);
                        UserMemorizedLogData.AppendChild(CCS);


                        doc.Save(w);
                        w.Close();
                    }
                    fs.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
