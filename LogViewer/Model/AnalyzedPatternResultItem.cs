// File:    AnalyzedPatternResultItem.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 9:08:36 AM
// Purpose: Definition of Class AnalyzedPatternResultItem

using System;
using System.Collections.Generic;
using System.Linq;
using LogViewer.Business;
namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing analyzed pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AnalyzedPatternResultItem<T>
    {
        /// <summary>
        /// Default constructor. The constructor will initialize for <see cref="FoundPattern"/> and <see cref="RootKey"/>
        /// </summary>
        public AnalyzedPatternResultItem()
        {
            _foundPattern = new Dictionary<T, List<KeyIndexRecordPair<int, string, int, T, string>>>();
            _rootKey = new Dictionary<T, KeyIndexRecordPair<int, string, int, T, string>>();
        }
        /// <summary>
        /// Get or set name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get number of keys found after analyze current pattern.
        /// </summary>
        public int Count { get { return _foundPattern.Keys.Count; } }
        /// <summary>
        /// Get list of found log record.
        /// </summary>
        public List<T> LogRecords { get { return _foundPattern.Keys.ToList(); } }
        protected Dictionary<T, KeyIndexRecordPair<int, string, int, T, string>> _rootKey;
        /// <summary>
        /// Get or set root key
        /// </summary>
        public Dictionary<T, KeyIndexRecordPair<int, string, int, T, string>> RootKey { get { return _rootKey; } set { _rootKey = value; } }
        protected Dictionary<T, List<KeyIndexRecordPair<int, string, int, T, string>>> _foundPattern;
        /// <summary>
        /// Get or set found pattern
        /// </summary>
        public Dictionary<T, List<KeyIndexRecordPair<int, string, int, T, string>>> FoundPattern { get { return _foundPattern; } }
        /// <summary>
        /// Get or set <see cref="PatternItemSetting"/>
        /// </summary>
        public PatternItemSetting PatternItem { get; set; }
    }
}