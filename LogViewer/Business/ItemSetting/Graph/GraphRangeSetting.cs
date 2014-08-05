using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides method for setting range of graph
    /// </summary>
    public class GraphRangeSetting : ICopyable<GraphRangeSetting>
    {
        /// <summary>
        /// Get or set "From" date.
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Get or set "To" date
        /// </summary>
        public DateTime To { get; set; }
        /// <summary>
        /// Get or set the first "From" parameter for Y axis. 
        /// </summary>
        public double FirstYRangeFrom { get; set; }
        /// <summary>
        /// Get or set the first "To" parameter for Y axis. 
        /// </summary>
        public double FirstYRangeTo { get; set; }
        /// <summary>
        /// Get or set the second "From" parameter for Y axis. 
        /// </summary>
        public double SecondYRangeFrom { get; set; }
        /// <summary>
        /// Get or set the second "To" parameter for Y axis. 
        /// </summary>
        public double SecondYRangeTo { get; set; }
        /// <summary>
        /// Clone to new object
        /// </summary>
        /// <returns></returns>
        public GraphRangeSetting Copy()
        {
            GraphRangeSetting temp = new GraphRangeSetting()
            {
                From = this.From,
                FirstYRangeTo = this.FirstYRangeTo,
                FirstYRangeFrom = this.FirstYRangeFrom,
                SecondYRangeFrom = this.SecondYRangeFrom,
                SecondYRangeTo = this.SecondYRangeTo,
                To = this.To
            };
            return temp;
        }
    }
}
