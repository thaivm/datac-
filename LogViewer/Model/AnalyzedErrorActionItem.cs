// File:    AnalyzedErrorActionItem.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 8:39:58 AM
// Purpose: Definition of Class AnalyzedErrorActionItem

using System;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing analyzed result item.
    /// </summary>
    public class AnalyzedErrorActionItem
    {
        protected CCSLogRecord _record;
        /// <summary>
        /// Get or set <see cref="CCSLogRecord"/>log record
        /// </summary>
        public CCSLogRecord Record
        {
            get
            {
                return _record;
            }
            set
            {
                _record = value;
            }
        }
        protected ErrorActionItem _error;
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="error"><see cref="ErrorActionItem"/></param>
        /// <param name="record"></param>
        public AnalyzedErrorActionItem(ErrorActionItem error, CCSLogRecord record)
        {
            Record = record;
            _error = error;
        }
        /// <summary>
        /// Get or set line
        /// </summary>
        public int Line
        {
            get
            {
                return _record.Line;
            }
        }
        /// <summary>
        /// Get or set date
        /// </summary>
        public string Date
        {
            get
            {
                return _record.Date;
            }
        }
        /// <summary>
        /// Get or set time
        /// </summary>
        public string Time
        {
            get
            {
                return _record.Time;
            }
        }
        /// <summary>
        /// Get or set log type (error level)
        /// </summary>
        public string LogType
        {
            get
            {
                return _error.ErrorLv;
            }
        }
        /// <summary>
        /// Get or set error code
        /// </summary>
        public string ErrorCode
        {
            get
            {
                return _error.ErrorCode;
            }
        }
        /// <summary>
        /// Get or set error message
        /// </summary>
        public string Message
        {
            get
            {
                return _error.ErrorMessage;
            }
        }
        public string Recipe
        {
            get
            {
                return _error.ErrorRecipe;
            }
        }
    }
}