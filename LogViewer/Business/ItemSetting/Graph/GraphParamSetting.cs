using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides method for process graph parameter
    /// </summary>
    public class GraphParamSetting : BaseItemSetting, ICopyable<GraphParamSetting>
    {
        protected string _stringValue;
        /// <summary>
        /// Get or set value for parameter
        /// </summary>
        public string StringValue 
        {
            get
            {
                return _stringValue;
            }
            set
            {
                if (value != null)
                    value = value.Trim();
                _stringValue = value;
            }
        }
        /// <summary>
        /// Get or set <see cref="Prototype"/>
        /// </summary>
        public Prototype PrototypeValue { get; set; }
        /// <summary>
        /// Get or set <see cref="GraphType"/>
        /// </summary>
        public GraphType GraphTypeValue { get; set; }
        /// <summary>
        /// Clone to new object
        /// </summary>
        /// <returns><see cref="GraphParameterSetting"/></returns>
        public GraphParamSetting Copy()
        {
            GraphParamSetting temp = new GraphParamSetting();
            temp.Enabled = this.Enabled;
            temp.GraphTypeValue = this.GraphTypeValue;
            temp.Id = this.Id;
            temp.Name = this.Name;
            temp.PrototypeValue = this.PrototypeValue;
            temp.StringValue = this.StringValue;
            return temp;
        }
    }
}
