using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using System.Collections.ObjectModel;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for editing graph parameters
    /// </summary>
    public class EditGraphParamSettingViewModel : BaseApplyWindowViewModel<IList<GraphParamSetting>>
    {
        IList<GraphParamSetting> _graphParamSetting;
        /// <summary>
        /// Get or set <see cref="ParameterDataGridViewModel"/>
        /// </summary>
        public ParameterDataGridViewModel ParameterDataGridVM { get; set; }
        /// <summary>
        /// Get or set <see cref="EventDataGridViewModel"/>
        /// </summary>
        public EventDataGridViewModel EventDataGridVM { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyEvent"><see cref="Action<T>"/></param>
        public EditGraphParamSettingViewModel(Action<IList<GraphParamSetting>> onApplyEvent)
            : base(onApplyEvent)
        {
            
        }
        /// <summary>
        /// Get list of <see cref="GraphParamSetting"/>
        /// </summary>
        /// <returns>List of <see cref="GraphParamSetting"/></returns>
        protected override IList<GraphParamSetting> GetDataToApply()
        {
            return ParameterDataGridVM.SourceList.Where(x =>
                !String.IsNullOrEmpty(x.StringValue) && !String.IsNullOrEmpty(x.Name))
                .Concat(EventDataGridVM.SourceList.Where(x =>
                !String.IsNullOrEmpty(x.StringValue) && !String.IsNullOrEmpty(x.Name))).ToList();
        }
        /// <summary>
        /// Use for checking can the parameter data grid view model can applying or not
        /// </summary>
        protected override bool CanApply
        {
            get
            {
                return ParameterDataGridVM.IsDataValid && EventDataGridVM.IsDataValid;
            }
        }
        /// <summary>
        /// Log parameter to <see cref="ParameterDataGridVM"/>
        /// </summary>
        /// <param name="graphParamSetting">List of <see cref="GraphParamSetting"/></param>
        public void LoadParam(IList<GraphParamSetting> graphParamSetting)
        {
            _graphParamSetting = graphParamSetting;
            ParameterDataGridVM = new ParameterDataGridViewModel(this);
            ParameterDataGridVM.LoadData(_graphParamSetting.Where(x => x.GraphTypeValue == GraphType.Value));
            EventDataGridVM = new EventDataGridViewModel(this);
            EventDataGridVM.LoadData(_graphParamSetting.Where(x => x.GraphTypeValue == GraphType.Event));
        }
    }
}
