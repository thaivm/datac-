﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of saved of firmware <seealso cref="CXDIFirmware"/>
    /// </summary>
    public class Saved
    {
        /// <summary>
        /// Get or set parameter
        /// </summary>
        public string parameter { get; set; }
        /// <summary>
        /// Get or set value
        /// </summary>
        public string value { get; set; }
    }
}
