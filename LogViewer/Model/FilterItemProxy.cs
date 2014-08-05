using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using LogViewer.Business;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for creating proxy of <see cref="FilterItemSetting"/>, this class provide methods or initialize data for speed up
    /// filter process.
    /// </summary>
    public class FilterItemProxy 
    {
        FilterItemSetting _filterItemSetting;
        /// <summary>
        /// Get or set <see cref="FilterItemSetting"/>
        /// </summary>
        public FilterItemSetting FilterItemSettingObj
        {
            get { return _filterItemSetting; }
            set { _filterItemSetting = value; }
        }

        int _keywordCount = 0;
        Regex _regex;
        /// <summary>
        /// Check for a given string <paramref name="searchString"/> is match or not with current filter item
        /// </summary>
        /// <param name="searchString">string for search</param>
        /// <returns></returns>
        public bool IsMatch(string searchString) {
            if (_regex == null) return false;
            if (searchString == null || _filterItemSetting.StringValue == null) return false;
            if (_keywordCount > 0)
            {
                //Use regex if keyword count > 1
                return _regex.IsMatch(searchString);
            }
            else //Use string.constains if keyword count=1
                return searchString.Contains(_filterItemSetting.StringValue);
        }
        /// <summary>
        /// Initialize be for do <see cref="IsMatch"/>
        /// </summary>
        /// <param name="regexOption"></param>
        public void BuildSearchMethod(RegexOptions regexOption=RegexOptions.None){
            //Find expression

            var reg = new Regex("\".*?\"");
            var matches = reg.Matches(_filterItemSetting.StringValue);
            List<string> expressionPatternList = new List<string>();
            foreach (var item in matches)
            {
                expressionPatternList.Add(string.Format("{0}", item.ToString()));
            }

            if (expressionPatternList.Count > 0) {
                _keywordCount = 1;//process only one expression, inorge all remaind
                try
                {
                    _regex = new Regex(expressionPatternList[0].Replace("\"",""), RegexOptions.None);
                    return;
                }
                catch {
                    _regex = null;
                    return;
                }
            }

            //Split string value with or condition
            List<string> orArrayString = _filterItemSetting.StringValue.Split(new string[] { ConfigValue.SEARCH_KEY_OR }, StringSplitOptions.RemoveEmptyEntries).ToList();
            _keywordCount = orArrayString.Count();
            //Build and condition
            List<string> orArrayPattern = new List<string>();
            //Define rexgex object to extract regex expression
            foreach (string s in orArrayString)
            {

                List<string> operandOfAndKeywordList = s.Split(new string[] { ConfigValue.SEARCH_KEY_AND }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //Escape regex character

                _keywordCount += operandOfAndKeywordList.Count;
                //Build pattern from expression list
                string stringAndPattern = string.Empty;

                //Build pattern for and condition
                stringAndPattern += string.Format(@"{0}", string.Join("", operandOfAndKeywordList.Select(r => string.Format(@"(?=.*({0}))", Regex.Escape( r))).ToArray()));
                orArrayPattern.Add(string.Format("({0})",stringAndPattern));
            }
            //Build or condition
            string _searchPattern = string.Format("{0}", string.Join("|", orArrayPattern.ToArray()));
            _regex = new Regex(_searchPattern, regexOption);
        }
        /// <summary>
        /// Default constructor will initialize for <see cref="FilterItemSettingObj"/>
        /// </summary>
        public FilterItemProxy() {
             _filterItemSetting =  new FilterItemSetting();
        }
        /// <summary>
        /// Default constructor will preference to <see cref="FilterItemSettingObj"/>
        /// </summary>
        /// <param name="searchItem"><see cref="FilterItemSetting"/></param>

        public FilterItemProxy(FilterItemSetting searchItem)
        {
            _filterItemSetting = searchItem;
        }
        /// <summary>
        /// Default constructor will preference to <see cref="FilterItemSettingObj"/>
        /// </summary>
        /// <param name="searchItem"><see cref="FilterItemSetting"/></param>
        public FilterItemProxy(SearchItem searchItem)
        {
            _filterItemSetting = new FilterItemSetting();
            _filterItemSetting.LogItem = searchItem.LogItem;
            _filterItemSetting.StringValue = searchItem.StringValue.Trim();
        }
        /// <summary>
        /// Default constructor will preference to <see cref="FilterItemSettingObj"/>
        /// </summary>
        /// <param name="searchItem"><see cref="FilterItemSetting"/></param>
        public FilterItemProxy(ILogItemSearch searchItem)
        {
            _filterItemSetting = new FilterItemSetting();
            _filterItemSetting.LogItem = searchItem.LogItem;
            _filterItemSetting.StringValue = searchItem.StringValue.Trim();
        }
    }
}
