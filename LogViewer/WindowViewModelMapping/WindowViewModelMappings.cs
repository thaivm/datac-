using System;
using System.Collections.Generic;
using LogViewer.View;
using LogViewer.ViewModel;
using LogViewer.Model;

namespace LogViewer.WindowViewModelMapping
{
	/// <summary>
	/// Class describing the Window-ViewModel mappings used by the dialog service.
	/// </summary>
	public class WindowViewModelMappings : IWindowViewModelMappings
	{
		private IDictionary<Type, Type> mappings;


		/// <summary>
		/// Initializes a new instance of the <see cref="WindowViewModelMappings"/> class.
		/// </summary>
		public WindowViewModelMappings()
		{
			mappings = new Dictionary<Type, Type>
			{
                { typeof(EditCCSFilterSettingViewModel), typeof(EditFilterSettingView) },
                { typeof(EditCXDIFilterSettingViewModel), typeof(EditFilterSettingView) },
                { typeof(EditCCSKeywordCountSettingViewModel), typeof(KeywordCountSettingView) },
                { typeof(EditCXDIKeywordCountSettingViewModel), typeof(KeywordCountSettingView) },
                { typeof(EditPatternSettingViewModel), typeof(PatternManagerView) },
			    { typeof(SearchKeywordViewModel), typeof(SearchKeywordView) },
		        { typeof(JumpToLineViewModel), typeof(MoveToLine) },
                { typeof(LoadingDialogViewModel), typeof(LoadingDialog) },
				{ typeof(JumpToTimeViewModel<CCSLogRecord>), typeof(MoveToTime) },
                { typeof(JumpToTimeViewModel<CXDILogRecord>), typeof(MoveToTime) },
                { typeof(SetFontStyleDialogViewModel), typeof(SetFontStyleDialog) },
                { typeof(PatternItemViewModel), typeof(PatternItemView) },
                { typeof(SetLogDisplayViewModel), typeof(LogDisplaySettingView) },
                { typeof(GraphViewModel), typeof(GraphView) },
                { typeof(EditGraphParamSettingViewModel), typeof(EditGraphParamSettingView) },
                { typeof(SetRangeOfGraphViewModel), typeof(SetRangeOfGraphView) },
                { typeof(MessageBoxExportViewModel), typeof(ExportFileNameDialogView) },
			};
		}


		/// <summary>
		/// Gets the window type based on registered ViewModel type.
		/// </summary>
		/// <param name="viewModelType">The type of the ViewModel.</param>
		/// <returns>The window type based on registered ViewModel type.</returns>
		public Type GetWindowTypeFromViewModelType(Type viewModelType)
		{
			return mappings[viewModelType];
		}
	}
}