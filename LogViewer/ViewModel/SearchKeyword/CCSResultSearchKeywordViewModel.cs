using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// class provides method for search CCS keyword.
    /// </summary>
    public class CCSResultSearchKeywordViewModel : BaseResultSearchKeywordViewModel<CCSLogRecord>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CCSResultSearchKeywordViewModel()
        {
        }

        /// <summary>
        /// Initialize log item list
        /// </summary>
        /// <returns></returns>
        protected override List<ValueDisplayPair<string, string>> InitLogItemList()
        {
            var result = new List<ValueDisplayPair<string, string>>();
            ConfigValue.CCSHeader.AllLogField.ForEach((x) =>
            {
                result.Add(
                    new ValueDisplayPair<string, string> { Value = x, Display = Util.Utility.Translate(x) });
            });
            return result;
        }

        /// <summary>
        /// Get default selected log item
        /// </summary>
        /// <returns></returns>
        protected override string GetDefaultSelectedLogItem()
        {
            return ConfigValue.CCSHeader.HEADER_CONTENT;
        }
        /// <summary>
        /// Check log field valid
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        protected override bool IsValidLogField(string value)
        {
            return ConfigValue.CCSHeader.AllLogField.Contains(value);
        }
        /// <summary>
        /// Get IsCCS alway return true
        /// </summary>
        public override bool IsCCS
        {
            get { return true; }
        }
        /// <summary>
        /// Get IsCXDI alway return false
        /// </summary>
        public override bool IsCXDI
        {
            get { return false; }
        }
    }
}
