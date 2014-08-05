using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for setting keyword count parameter item
    /// </summary>
    public class EditCCSKeywordCountSettingViewModel : EditKeywordCountSettingViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyEvent"><see cref="Action<T>"/></param>
        public EditCCSKeywordCountSettingViewModel(Action<List<KeywordCountItemSetting>> onApplyEvent) : 
            base(onApplyEvent)
        {

        }
        /// <summary>
        /// Get default log item
        /// </summary>
        /// <returns></returns>
        protected override string GetDefaultLogItem()
        {
            return ConfigValue.CCSHeader.HEADER_CONTENT;
        }
        /// <summary>
        /// Get all default log items
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
