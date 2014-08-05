using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides method for processing graph parameter result item
    /// </summary>
    public class GraphParamResultItem
    {
        /// <summary>
        /// Get or set date time
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Get or set value of result item
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Clone to new object
        /// </summary>
        /// <returns><see cref="GraphParamResultItem"/></returns>
        public GraphParamResultItem Clone() {
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Time;
            item.Value = Value;
            return item;
        }
    }
}
