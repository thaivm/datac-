using System;
using System.Windows.Forms;
using WinFormsSaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace LogViewer.Service.FrameworkDialogs.SaveFile
{
	/// <summary>
	/// Class wrapping Microsoft.Win32.SaveFileDialog, making it accept a ViewModel.
	/// </summary>
	public class SaveFileDialog : IDisposable
	{
		protected readonly ISaveFileDialog saveFileDialog;
		protected WinFormsSaveFileDialog concreteSaveFileDialog;
		
		public SaveFileDialog(ISaveFileDialog saveFileDialog)
		{
			this.saveFileDialog = saveFileDialog;

			// Create concrete FolderBrowserDialog
			concreteSaveFileDialog = new WinFormsSaveFileDialog
			{
				FileName = saveFileDialog.FileName,
				DefaultExt = saveFileDialog.DefaultExt,
				Filter = saveFileDialog.Filter
			};
		}

		public bool? ShowDialog(IWin32Window owner)
		{
			var result = concreteSaveFileDialog.ShowDialog();
			saveFileDialog.FileName = concreteSaveFileDialog.FileName;
            return result;
		}


		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting
		/// unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


        ~SaveFileDialog()
		{
			Dispose(false);
		}

        /// <summary>
        /// Dispose object
        /// </summary>
        /// <param name="disposing">True:dispose and set null the holder object;False: dispose and not set null</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (concreteSaveFileDialog != null)
				{
					concreteSaveFileDialog = null;
				}
			}
		}

		#endregion
	}
}
