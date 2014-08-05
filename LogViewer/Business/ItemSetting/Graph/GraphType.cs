using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Business
{
    /// <summary>
    /// Enum array for definition graph type. 
    /// Value: if the type of graph is valuation.
    /// Event: if the type of project is event
    /// <seealso cref="GraphParamSetting"/>.
    /// </summary>
    public enum GraphType
    {
        Value,
        Event
    }
}
