namespace LogViewer.Service.FrameworkDialogs.SaveFile
{
    /// <summary>
    /// Model class provides properties for saving file
    /// </summary>
	public class SaveFileDialogViewModel : ISaveFileDialog
	{
        /// <summary>
        /// Get or set file name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Get or set default extension
        /// </summary>
        public string DefaultExt { get; set; }
        /// <summary>
        /// Get or set filter string
        /// </summary>
        public string Filter { get; set; }
	}
}
