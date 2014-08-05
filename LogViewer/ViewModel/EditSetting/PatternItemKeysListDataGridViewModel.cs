using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using System.Collections.ObjectModel;
namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for listing pattern item keys
    /// </summary>
    public class PatternItemKeysListDataGridViewModel : BaseDataGridViewModel<KeywordModel>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ownerVM">The owner view model, for examples: <see cref="PatternItemViewModel"/></param>
        public PatternItemKeysListDataGridViewModel(object ownerVM)
            : base(ownerVM)
        {
        }

        /// <summary>
        /// Validate pattern key item list
        /// </summary>
        /// <returns>String empty if item key list is valid, otherwise return error message</returns>
        protected override string ValidateData()
        {
            if (SourceList == null || SourceList.Count == 0)
            {
                return Properties.Resources.ValidateEmptyStringListMessage;
            }
            if (SourceList.Where(x => x.Value != null && !x.Value.Equals(String.Empty)).Count() == 0)
            {
                return Properties.Resources.ValidateEmptyStringValueMessage;
            }
            var keys = SourceList.Select(x => x.Value).Distinct();
            foreach (var i in keys)
            {
                if (SourceList.Where(x => x.Value != null && !x.Value.Equals(String.Empty) && x.Value == i).Count() >= 2)
                {
                    return Properties.Resources.ValidateUniqueStringValueMessage;
                }
            }
            //hard code.
            if (SourceList.Where(x => x.Value.Length > 50).Count() > 0)
            {
                return Properties.Resources.ValidateLengthStringValueMessage;
            }
            return String.Empty;
        }
        /// <summary>
        /// Create new key item
        /// </summary>
        /// <returns><see cref="KeywordModel"/></returns>
        protected override KeywordModel CreateNewItem()
        {
            return new KeywordModel
            {
                Value = string.Empty,
                Index = SourceList.Count + 1
            };
        }
        /// <summary>
        /// Add new keyword
        /// </summary>
        protected override void AddCL()
        {
            var newItem = CreateNewItem();
            SourceList.Add(newItem);
            RowForJump = newItem;
        }
        /// <summary>
        /// Delete list of specified keywords
        /// </summary>
        /// <param name="items">List of <see cref="KeywordModel"/></param>
        protected override void Delete(IList<object> items)
        {
            var tempList = new List<object>(items);
            foreach (var i in tempList)
            {
                var casted = i as KeywordModel;
                if (casted != null)
                {
                    try
                    {
                        SourceList.Remove(casted);
                    }
                    catch
                    { }
                }
            }

            int index = 1;
            List<KeywordModel> temps = new List<KeywordModel>(SourceList);
            foreach (var source in temps)
            {
                source.Index = index;
                index++;
            }
            SourceList = new ObservableCollection<KeywordModel>(temps);
            //OnPropertyChanged("SourceList");
        }

        /// <summary>
        /// Load keywords to <see cref="SourceList"/> 
        /// </summary>
        /// <param name="data">List of <see cref="KeywordModel"/></param>
        public override void LoadData(IEnumerable<KeywordModel> data)
        {
            List<KeywordModel> temp = new List<KeywordModel>();
            int index = 1;
            foreach (var i in data)
            {
                var copyable = i as ICopyable<KeywordModel>;
                if (copyable != null)
                {
                    KeywordModel copy = copyable.Copy();
                    copy.Index = index;
                    temp.Add(copy);
                }
                else
                {
                    KeywordModel copy = i;
                    copy.Index = index;
                    temp.Add(copy);
                }
                index++;
            }
            SourceList = new ObservableCollection<KeywordModel>(temp);
        }
    }
}
