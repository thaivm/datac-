using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.CustomException
{
    /// <summary>
    /// Exception class provide method for throwing not support exception <seealso cref="FontStyleHelper"/>
    /// </summary>
    class DataValueNotSupportedException : NotSupportedException
    {
        /// <summary>
        /// Throw message <see cref="Properties.Resources.DATA_VALUE_NOT_SUPPORTED_EXCEPTION_MESSAGE"/>
        /// </summary>
        public override string Message
        {

            get
            {
                return Properties.Resources.DATA_VALUE_NOT_SUPPORTED_EXCEPTION_MESSAGE;
            }
        }
    }
}
