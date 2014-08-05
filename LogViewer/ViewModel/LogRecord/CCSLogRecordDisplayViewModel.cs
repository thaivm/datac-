// File:    CCSLogRecordDisplayViewModel.cs
// Author:  CuongPNB
// Created: Thursday, April 17, 2014 5:11:20 PM
// Purpose: Definition of Class CCSLogRecordDisplayViewModel

using System;
using LogViewer.Model;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method display CCS log record
    /// </summary>
    public class CCSLogRecordDisplayViewModel : BaseLogRecordDisplayViewModel<CCSLogRecord>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="data">CCS log record</param>
        /// <param name="ownerVM">Parent view model</param>
        public CCSLogRecordDisplayViewModel(CCSLogRecord data, ILogsDisplayContainer<CCSLogRecord> ownerVM)
            : base(data, ownerVM)
        {
        }
        /// <summary>
        /// Get host name of data
        /// </summary>
        public string HostName
        {
            get
            {
                return _data.HostName;
            }
        }
        /// <summary>
        /// Get thread id of data
        /// </summary>
        public string ThreadId
        {
            get 
            {
                return _data.ThreadId;
            }
        }
        /// <summary>
        /// Get type of data
        /// </summary>
        public string Type
        {
            get 
            {
                return _data.Type;
            }
        }
        /// <summary>
        /// Get id of data
        /// </summary>
        public string Id
        { 
            get 
            {
                return _data.Id;
            }
        }
        /// <summary>
        /// Get content of data
        /// </summary>
        public string Content
        {
            get
            {
                return _data.Content;
            }
        }
        /// <summary>
        /// Get personal information of data
        /// </summary>
        public string PersonalInfo
        {
            get
            {
                return _data.PersonalInfo;
            }
        }
        /// <summary>
        /// Get additional information of data
        /// </summary>
        public string AdditionalInfo
        {
            get
            {
                return _data.AdditionalInfo;
            }
        }
        /// <summary>
        /// Get class name of data
        /// </summary>
        public string ClassName
        {
            get
            {
                return _data.ClassName;
            }
        }
        /// <summary>
        /// Get mode of data
        /// </summary>
        public string Mode
        {
            get
            {
                return _data.Mode;
            }
        }

        //public string HEADER_HOSTNAME = ;
        //public string HEADER_THREADID;
        //public string headerType;
        //public string headerId;
        //public string headerContent;
        //public string headerAdditionalinfo;
        //public string headerPersonalinfo;
        //public string headerClassname;
        //public string headerModule;
    }
}