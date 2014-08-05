using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for graph parameter setting item
    /// </summary>
    public class ParameterDataGridViewModel : BaseGraphParameterDataGridViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ownerVM">The owner view model, for examples: <see cref="EditGraphParamSettingViewModel"/></param>
        public ParameterDataGridViewModel(object ownerVM)
            : base(ownerVM)
        {
        }
        /// <summary>
        /// Validate graph parameter setting item
        /// </summary>
        /// <returns>Error message if the inputed item is invalid, otherwise this method return an empty string</returns>
        protected override string ValidateData()
        {
            string errorMessage = base.ValidateData();
            if (!String.IsNullOrEmpty(errorMessage))
                return errorMessage;
            if (SourceList.Where(x => x.Enabled).Count() > 2)
                return Properties.Resources.ValidateMaximumEnableParameter;
            return String.Empty;
        }
        /// <summary>
        /// Create new parameter item
        /// </summary>
        /// <returns><see cref="GraphParamSetting"/></returns>
        protected override GraphParamSetting CreateNewItem()
        {
            return new GraphParamSetting { GraphTypeValue = GraphType.Value };
        }
    }
}
