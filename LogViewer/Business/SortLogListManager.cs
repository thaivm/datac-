using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides static methods for sorting log records.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SortLogListManager<T> where T : BaseLogRecord
    {
        /// <summary>
        /// Sort all record in a dictionary, the comparative method base on date time. If the date time is the same, 
        /// Line will be use instead of.
        /// </summary>
        /// <param name="_allLogRecordsBufferWithFileName">Dictionary of log records</param>
        /// <returns></returns>

        public static IEnumerable<T> SortAllRecord(Dictionary<string, List<T>> _allLogRecordsBufferWithFileName)
        {
            var result = new List<T>();
            foreach (List<T> recordList in _allLogRecordsBufferWithFileName.Values)
            {
                result.AddRange(recordList);
            }
            result.Sort((x, y) =>
            {

                int cmp = x.DateTime.CompareTo(y.DateTime);
                if (cmp == 0)
                {
                    return x.Line.CompareTo(y.Line);
                }
                return cmp;
            }
                );
            return result;
        }
        /// <summary>
        /// Sort all record in list, the comparative method base on date time. If the date time is the same, 
        /// Line will be use instead of.
        /// </summary>
        /// <param name="recordList">List of log records</param>
        /// <returns></returns>
        public static IEnumerable<T> SortAllRecord(List<T> recordList)
        {
            List<T> result = new List<T>();
            result.AddRange(recordList);
            result.Sort((x, y) =>
            {

                int cmp = x.DateTime.CompareTo(y.DateTime);
                if (cmp == 0)
                {
                    return x.Line.CompareTo(y.Line);
                }
                return cmp;
            }
                );
            return result;
        }
        /// <summary>
        /// Sort all record in dictionary by date & time in ascending when merging
        /// </summary>
        /// <param name="_allLogRecordsBufferWithFileName">Dictionary of all record grouped by file name</param>
        /// <returns></returns>
        protected IEnumerable<T> SortByFile(Dictionary<string, List<T>> _allLogRecordsBufferWithFileName)
        {
            //Build Sorted the list

            List<string> sortedFile = new List<string>();
            List<T> result = new List<T>();
            List<T> nextLog;
            while ((nextLog = GetTheOldestLogFileRecord(_allLogRecordsBufferWithFileName, sortedFile)) != null)
            {
                result.AddRange(nextLog);
            }
            return result;
        }
        /// <summary>
        /// Get the oldest record list in the set of log file record when user load multi file
        /// </summary>
        /// <param name="_allLogRecordsBufferWithFileName">Dictionary of record </param>
        /// <param name="sortedFile"></param>
        /// <returns></returns>
        protected List<T> GetTheOldestLogFileRecord(Dictionary<string, List<T>> _allLogRecordsBufferWithFileName, List<string> sortedFile)
        {
            var unSortedLogFile = _allLogRecordsBufferWithFileName.Keys.Where(allfileNameKey => !sortedFile.Any(sortedFileName => sortedFileName == allfileNameKey)).ToList();
            //Find for the first file to make default newest record
            string oldestFileKey = unSortedLogFile.FirstOrDefault();
            //unSortedLogFile
            if (oldestFileKey == null) return null;
            var oldestRecord = _allLogRecordsBufferWithFileName[oldestFileKey].FirstOrDefault();
            //Remove the key from the list unSortedLogFile to sign it as sorted
            unSortedLogFile.Remove(oldestFileKey);
            foreach (string currentFileKey in unSortedLogFile)
            {
                var currentRecord = _allLogRecordsBufferWithFileName[currentFileKey].First();
                string currentRecordDateTime = currentRecord.Date + currentRecord.Time;
                string oldestDateTime = oldestRecord.Date + oldestRecord.Time;
                if (oldestDateTime.CompareTo(currentRecordDateTime) >= 0)
                {
                    oldestRecord = currentRecord;
                    oldestFileKey = currentFileKey;
                }
            }
            sortedFile.Add(oldestFileKey);

            //foreach(var aRemaindedLogFileRecord  in 
            return _allLogRecordsBufferWithFileName[oldestFileKey];
        }

    }

}
