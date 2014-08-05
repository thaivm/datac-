using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for creating new item for graph parameter setting
    /// </summary>
    public class EventDataGridViewModel : BaseGraphParameterDataGridViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ownerVM">The owner view model, for examples: <see cref="EditGraphParamSettingViewModel"/></param>
        public EventDataGridViewModel(object ownerVM)
            : base(ownerVM)
        {
        }
        /// <summary>
        /// Create new parameter item
        /// </summary>
        /// <returns><see cref="GraphParamSetting"/></returns>
        protected override GraphParamSetting CreateNewItem()
        {
            return new GraphParamSetting { GraphTypeValue = GraphType.Event };
        }
    }
}
