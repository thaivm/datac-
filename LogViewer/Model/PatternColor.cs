using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace LogViewer.Model
{
    /// <summary>
    /// Class provides properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    public class PatternColor<T> where T : BaseLogRecord 
    {
        public Dictionary<int, KeyIndexRecordPair<int, string, int, T, string>> _rootKey;
        //public Dictionary<int, List<string>> _dicKey;
        public List<KeyIndexRecordPair<int, string, int, T, string>> _dicKey;
        /// <summary>
        /// Initializes a new instance of the PatternColor class.
        /// </summary>
        public PatternColor(Dictionary<int, KeyIndexRecordPair<int, string, int, T, string>> rootKey, List<KeyIndexRecordPair<int, string, int, T, string>> dicKey)
        {
            _rootKey = rootKey;
            _dicKey = dicKey;
        }
    }
}