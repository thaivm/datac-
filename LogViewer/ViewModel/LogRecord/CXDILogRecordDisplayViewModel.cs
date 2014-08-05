// File:    CXDILogRecordDisplayViewModel.cs
// Author:  CuongPNB
// Created: Thursday, April 17, 2014 5:11:47 PM
// Purpose: Definition of Class CXDILogRecordDisplayViewModel

using System;
using LogViewer.Model;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method display CXDI log record
    /// </summary>
    public class CXDILogRecordDisplayViewModel : BaseLogRecordDisplayViewModel<CXDILogRecord>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="data">CXDI log record</param>
        /// <param name="ownerVM">Parent view model</param>
        public CXDILogRecordDisplayViewModel(CXDILogRecord data, ILogsDisplayContainer<CXDILogRecord> ownerVM)
            : base(data, ownerVM)
        {
        }
        /// <summary>
        /// Get module of data
        /// </summary>
        public string Module
        {
            get
            {
                return _data.Module;
            }
        }
        /// <summary>
        /// Get message of data
        /// </summary>
        public string Message
        {
            get
            {
                return _data.Message;
            }
        }
    }
}