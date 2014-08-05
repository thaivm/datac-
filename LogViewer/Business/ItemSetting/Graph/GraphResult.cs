using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides methods for storing graph result
    /// </summary>
    public class GraphResult
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphResult()
        {
            ResultList = new List<GraphParamResultItem>();
        }
        /// <summary>
        /// Get or set graph parameter setting <see cref="GraphParamSetting"/>
        /// </summary>
        public GraphParamSetting ParamSetting { get; set; }
        /// <summary>
        /// Get or set list of graph parameter result item <see cref="GraphParamSetting"/>
        /// </summary>
        public List<GraphParamResultItem> ResultList { get; set; }
    }
}
