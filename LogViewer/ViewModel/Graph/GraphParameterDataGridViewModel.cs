using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Abstract class provides common methods for validate graph parameter setting item
    /// </summary>
    public abstract class BaseGraphParameterDataGridViewModel : BaseDataGridViewModel<GraphParamSetting>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ownerVM">The owner view model, for examples: <see cref="EditGraphParamSettingViewModel"/></param>
        public BaseGraphParameterDataGridViewModel(object ownerVM)
            : base(ownerVM)
        {
        }
        /// <summary>
        /// Use for checking can the parameter data grid view model can applying or not
        /// </summary>

        protected override bool CanAdd()
        {
            return SourceList.Count < 10;
        }
        /// <summary>
        /// Validate graph parameter setting item
        /// </summary>
        /// <returns>Error message if the inputed item is invalid, otherwise this method return an empty string</returns>
        protected override string ValidateData()
        {
            //hard code.
            var blankList = SourceList.Where(x => String.IsNullOrEmpty(x.StringValue)
                && String.IsNullOrEmpty(x.Name));
            var actualSourceList = SourceList.Except(blankList);
            //if (SourceList.Count > 10)
            //    return Properties.Resources.ValidateMaxRegisterItemMessage;
            if (actualSourceList.Where(x => String.IsNullOrEmpty(x.Name)).Count() > 0)
                return Properties.Resources.ValidateEmptyNameMessage;
            if (actualSourceList.Where(x => String.IsNullOrEmpty(x.StringValue)).Count() > 0)
                return Properties.Resources.ValidateEmptyStringObjectMessage;
            if (actualSourceList.Where(x => x.Name.Length > ConfigValue.MaxStringLength).Count() > 0)
                return Properties.Resources.ValidateLengthNameMessage;
            if (actualSourceList.Where(x => x.StringValue.Length > ConfigValue.MaxStringLength).Count() > 0)
                return Properties.Resources.ValidateLengthStringObjectMessage;
            var keys = actualSourceList.Select(x => x.Name).Distinct();
            foreach (var i in keys)
            {
                if (actualSourceList.Where(x => x.Name == i).Count() >= 2)
                {
                    return Properties.Resources.ValidateUniqueNameMessage;
                }
            }
            return string.Empty;
        }
    }
}
