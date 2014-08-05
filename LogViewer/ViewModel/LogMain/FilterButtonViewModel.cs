using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    public class FilterButtonViewModel : BaseViewModel
    {
        /// <summary>
        /// Class provides method for filtering
        /// </summary>
        protected event Action OnClickEvent;
        FilterItemSetting _data;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="data"><see cref="FilterItemSetting"/></param>
        /// <param name="onClickEvent"><see cref="Action"/></param>
        public FilterButtonViewModel(FilterItemSetting data, Action onClickEvent)
        {
            OnClickEvent = onClickEvent;
            _data = data;
        }
        /// <summary>
        /// Get font style
        /// </summary>
        public string FontStyle 
        {
            get
            {
                return _data.FontStyle;
            }
        }
        /// <summary>
        /// Get foreground
        /// </summary>
        public String Foreground 
        {
            get
            {
                return _data.Foreground;
            }
        }
        /// <summary>
        /// Get background
        /// </summary>

        public String Background 
        {
            get
            {
                return _data.Background;
            }
        }
        /// <summary>
        /// Get filter name
        /// </summary>

        public string Name 
        {
            get
            {
                return _data.Name;
            }
        }
        /// <summary>
        /// Get enable status
        /// </summary>

        public bool Enabled
        {
            get
            {
                return _data.Enabled;
            }
            set
            {
                _data.Enabled = value;
                OnClickEvent();
                OnPropertyChanged("Enabled");
            }
        }
    }
}
