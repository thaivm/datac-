// File:    AnalyzedUserActionItem.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 8:39:52 AM
// Purpose: Definition of Class AnalyzedUserActionItem

using System;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing result of user action.
    /// </summary>
    public class AnalyzedUserActionItem
    {
        protected UserActionItem _action;
        protected CCSLogRecord _record;
        /// <summary>
        /// Get or set <see cref="CCSLogRecord"/>
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
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="action"><see cref="UserActionItem"/></param>
        /// <param name="record"><see cref="CCSLogRecord"/></param>
        public AnalyzedUserActionItem(UserActionItem action, CCSLogRecord record)
        {
            _action = action;
            _record = record;
        }
        /// <summary>
        /// Get line of record
        /// </summary>
        public int Line
        {
            get
            {
                return _record.Line;
            }
        }
        /// <summary>
        /// Get date of record
        /// </summary>
        public string Date
        {
            get
            {
                return _record.Date;
            }
        }
        /// <summary>
        /// Get time of record
        /// </summary>
        public string Time
        {
            get
            {
                return _record.Time;
            }
        }
        /// <summary>
        /// Get user action
        /// </summary>
        public string UserAction
        {
            get
            {
                return _action.UserAction;
            }
        }
    }
}