using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Business.FileSetting
{
    /// <summary>
    /// Class provides methods for throwing exception in case of setting file exception. This class had no parameter in contructor
    /// </summary>
    class UserSettingFileException : Exception
    {
        /// <summary>
        /// Default parameter
        /// </summary>
        public UserSettingFileException()
        {
        }
        /// <summary>
        /// Used for throw exception in case of setting file exception.
        /// </summary>
        /// <param name="message">Exception information</param>
        public UserSettingFileException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// Used for throw exception in case of setting file exception.
        /// </summary>
        /// <param name="message">Exception information</param>
        /// <param name="inner">Parent<see cref="Exception">Exception</see></param>
        public UserSettingFileException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
