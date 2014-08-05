using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class supporting for pattern analyze process.
    /// </summary>
    public class Cage
    {
        /// <summary>
        /// Get or set element of cage
        /// </summary>
        public List<StringLineIndexLevelPair<string, int, int, int, DateTime>> elementOfCage;
        /// <summary>
        /// Get or set is value that specified pattern had been detected.
        /// </summary>
        public bool IsPattern { get; set; }
    }

}
