using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of CXDI firmware
    /// </summary>
    public class CXDIFirmware
    {
        /// <summary>
        /// Get or set list of <see cref="Counter"/>
        /// </summary>
        public List<Counter> Counter { get; set; }
        /// <summary>
        /// Get or set list of <see cref="Saved"/>
        /// </summary>
        public List<Saved> Saved { get; set; }
        /// <summary>
        /// Default constructor initialize for <see cref="Counter"/> and <see cref="Saved"/>
        /// </summary>
        public CXDIFirmware()
        {
            Counter = new List<Counter>();
            Saved = new List<Saved>();
        }
    }
}

