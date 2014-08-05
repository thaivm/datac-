using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provide method for setting filtering parameter item
    /// </summary>
    public class EditCCSFilterSettingViewModel : EditFilterSettingViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyFilterEvent"><see cref="Action<T>"/></param>
        public EditCCSFilterSettingViewModel(Action<List<FilterItemSetting>> onApplyFilterEvent)
            : base(onApplyFilterEvent)
        {

        }

        /// <summary>
        /// Get default log  item
        /// </summary>
        /// <returns></returns>
        protected override string GetDefaultLogItem()
        {
            return ConfigValue.CCSHeader.HEADER_CONTENT;
        }

        /// <summary>
        /// Get all log item
        /// </summary>
        public override List<ValueDisplayPair<string, string>> AllLogItems
        {
            get 
            {
                var result = new List<ValueDisplayPair<string, string>>();
                ConfigValue.CCSHeader.AllLogField.ForEach((x) =>
                {
                    result.Add(
                        new ValueDisplayPair<string, string> { Value = x, Display = Util.Utility.Translate(x) });
                });
                return result;
            }
        }
    }
}
