// File:    BaseLogRecordDisplayViewModel.cs
// Author:  CuongPNB
// Created: Thursday, April 17, 2014 5:08:05 PM
// Purpose: Definition of Class BaseLogRecordDisplayViewModel

using System;
using LogViewer.Model;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Collections.Generic;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Base class provides common methods for display log record
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseLogRecordDisplayViewModel<T> : BaseViewModel where T : BaseLogRecord
    {
        /// <summary>
        /// Base log record data
        /// </summary>
        protected T _data;
        /// <summary>
        /// Get line of data
        /// </summary>
        public int Line
        {
            get
            {
                return _data.Line;
            }
        }
        /// <summary>
        /// Get base log record data
        /// </summary>
        public T Data
        {
            get
            {
                return _data;
            }
        }
        /// <summary>
        /// Get Date of data
        /// </summary>
        public String Date
        {
            get
            {
                return _data.Date;
            }
        }
        /// <summary>
        /// Get Time of data
        /// </summary>
        public String Time
        {
            get
            {
                return _data.Time;
            }
        }
        /// <summary>
        /// Check type of data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool IsViewModelOf(T data)
        {
            return data == _data;
        }
        /// <summary>
        /// Parent view model
        /// </summary>
        ILogsDisplayContainer<T> _ownerVM;
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="data">Base log record</param>
        /// <param name="ownerVM">Parent view model</param>
        protected BaseLogRecordDisplayViewModel(T data, ILogsDisplayContainer<T> ownerVM)
        {
            _ownerVM = ownerVM;
            _data = data;
        }
        /// <summary>
        /// Get filter item setting list
        /// </summary>
        public List<FilterItemSetting> FilterSetting
        {
            get
            {
                return _ownerVM.FilterSetting;
            }
        }
        /// <summary>
        /// Get pattern color of parent
        /// </summary>
        public PatternColor<T> PatternColor
        {
            get
            {
                return _ownerVM.PatternColor;
            }
        }
        /// <summary>
        /// Get or set bookmark status
        /// </summary>
        public bool IsBookmarked
        {
            get 
            {
                if (_ownerVM != null)
                {
                    if (_ownerVM.BookmarkList != null)
                        return _ownerVM.BookmarkList.Contains(_data);
                }
                return false;
            }
            set
            {
                OnPropertyChanged("IsBookmarked");
            }
        }
        /// <summary>
        /// Get or set Comment
        /// </summary>
        public string Comment
        {
            get
            {
                var commentSupporter = _ownerVM as ILogsDisplayContainer<T>;
                if (commentSupporter != null)
                {
                    var commentsDict = commentSupporter.CommentsDict;
                    if (commentsDict.ContainsKey(_data))
                    {
                        return commentSupporter.CommentsDict[_data];
                    }
                    else
                    {
                        return String.Empty;
                    }
                }
                return String.Empty;
            }
            set
            {
                var commentSupporter = _ownerVM as ILogsDisplayContainer<T>;
                if (commentSupporter != null)
                {
                    var commentsDict = commentSupporter.CommentsDict;
                    if (commentsDict.ContainsKey(_data))
                        commentsDict[_data] = value;
                    else
                        commentsDict.Add(_data, value);
                }
                OnPropertyChanged("Comment");
            }
        }
        
        protected DelegateCommand _bookmarkCommand;
        /// <summary>
        /// Get bookmark command
        /// </summary>
        public ICommand BookmarkCommand
        {
            get
            {
                if (_bookmarkCommand == null)
                {
                    _bookmarkCommand = new DelegateCommand(BookmarkCL);
                }
                return _bookmarkCommand;
            }
        }
        /// <summary>
        /// Callback when add bookmark
        /// </summary>
        protected virtual void BookmarkCL()
        {
            if (_ownerVM != null)
            {
                if (IsBookmarked == false)
                {
                    _ownerVM.AddBookmark(_data);
                }
                else
                {
                    _ownerVM.RemoveBookmark(_data);
                }
            }
        }
    }
}