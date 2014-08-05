using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Xml;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using LogViewer.Model;
using LogViewer.Business.FileParser;

namespace LogViewer.Util
{
    /// <summary>
    /// Class provides method for recentory file
    /// </summary>
	public class RecentFileList : Separator
	{
        /// <summary>
        /// Get property RecentFile
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <returns>Recent file</returns>
        public static RecentFileAction GetRecentFile(DependencyObject obj)
        {
            return (RecentFileAction)obj.GetValue(RecentFileProperty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <param name="value">Recent file</param>
        public static void SetRecentFile(DependencyObject obj, RecentFileAction value)
        {
            obj.SetValue(RecentFileProperty, value);
        }
        /// <summary>
        /// Dependency property for the <see cref="P:RecentFile"/> property.
        /// </summary>
        public static readonly DependencyProperty RecentFileProperty =
          DependencyProperty.RegisterAttached("RecentFile", typeof(RecentFileAction), typeof(RecentFileList),
          new PropertyMetadata(null, new PropertyChangedCallback(RecentFilePropertyChanged)));
        /// <summary>
        /// Recent file property changed
        /// </summary>
        /// <param name="o">Dependency object</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        public static void RecentFilePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            RecentFileList recent = o as RecentFileList;
            RecentFileAction recentFileAction = args.NewValue as RecentFileAction;
            if (recentFileAction.FilePath != null)
            {
                recent.InsertFile(recentFileAction.FilePath);
            }
            recent.RecentActionLoadCCS = recentFileAction.RecentActionLoadCCS;
            recent.RecentActionLoadCXDI = recentFileAction.RecentActionLoadCXDI;
        }
        /// <summary>
        /// Interface persist
        /// </summary>
		public interface IPersist
		{
            /// <summary>
            /// List recent file
            /// </summary>
            /// <param name="max">Maximum recent file</param>
            /// <returns>A collection</returns>
			List<string> RecentFiles( int max );
            /// <summary>
            /// Insert file to recent list
            /// </summary>
            /// <param name="filepath">File path</param>
            /// <param name="max">Maximum recent file</param>
			void InsertFile( string filepath, int max );
            /// <summary>
            /// Remove file to recent list
            /// </summary>
            /// <param name="filepath">File path</param>
            /// <param name="max">Maximum recent file</param>
			void RemoveFile( string filepath, int max );
		}
        /// <summary>
        /// Persister
        /// </summary>
		public IPersist Persister { get; set; }
        /// <summary>
        /// Use registry persister
        /// </summary>
		public void UseRegistryPersister() { Persister = new RegistryPersister(); }
        /// <summary>
        /// Use registry persister by key
        /// </summary>
        /// <param name="key">Key</param>
		public void UseRegistryPersister( string key ) { Persister = new RegistryPersister( key ); }
        /// <summary>
        /// Use XML persister
        /// </summary>
		public void UseXmlPersister() { Persister = new XmlPersister(); }
        /// <summary>
        /// Use XML persister by file
        /// </summary>
        /// <param name="filepath">File path</param>
		public void UseXmlPersister( string filepath ) { Persister = new XmlPersister( filepath ); }
        /// <summary>
        /// Use XML persister by stream
        /// </summary>
        /// <param name="stream">Stream</param>
		public void UseXmlPersister( Stream stream ) { Persister = new XmlPersister( stream ); }
        /// <summary>
        /// Get or set maximum number of file
        /// </summary>
		public int MaxNumberOfFiles { get; set; }
        /// <summary>
        /// Get or set Maximum path length
        /// </summary>
		public int MaxPathLength { get; set; }
        /// <summary>
        /// Get or set menu item
        /// </summary>
		public MenuItem FileMenu { get; set; }

		/// <summary>
		/// Used in: String.Format( MenuItemFormat, index, filepath, displayPath );
		/// Default = "_{0}:  {2}"
		/// </summary>
		public string MenuItemFormatOneToNine { get; set; }

		/// <summary>
		/// Used in: String.Format( MenuItemFormat, index, filepath, displayPath );
		/// Default = "{0}:  {2}"
		/// </summary>
		public string MenuItemFormatTenPlus { get; set; }
        /// <summary>
        /// Get delegate menu item text
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="filepath">File path</param>
        /// <returns></returns>
		public delegate string GetMenuItemTextDelegate( int index, string filepath );
		/// <summary>
        /// Get or set GetMenuItemTextHandler
		/// </summary>
        public GetMenuItemTextDelegate GetMenuItemTextHandler { get; set; }

//		public event EventHandler<MenuClickEventArgs> MenuClick;
        /// <summary>
        /// Separator
        /// </summary>
        public Separator _Separator = null;
        /// <summary>
        /// List recent file
        /// </summary>
        public List<RecentFile> _RecentFiles = null;
        /// <summary>
        /// Action recent when load CCS
        /// </summary>
        public Action<string> RecentActionLoadCCS;
        /// <summary>
        /// Action recent when load CXDI
        /// </summary>
        public Action<string> RecentActionLoadCXDI;
        /// <summary>
        /// Default constructor for RecentFileList
        /// </summary>
		public RecentFileList()
		{
			Persister = new RegistryPersister();

			MaxNumberOfFiles = 10;
			MaxPathLength = 50;
			MenuItemFormatOneToNine = "_{0}:  {2}";
			MenuItemFormatTenPlus = "{0}:  {2}";

			this.Loaded += ( s, e ) => HookFileMenu();
		}
        /// <summary>
        /// Hook file menu
        /// </summary>
        public void HookFileMenu()
		{
			MenuItem parent = Parent as MenuItem;
			if ( parent == null ) throw new ApplicationException( "Parent must be a MenuItem" );

			if ( FileMenu == parent ) return;

			if ( FileMenu != null ) FileMenu.SubmenuOpened -= _FileMenu_SubmenuOpened;

			FileMenu = parent;
			FileMenu.SubmenuOpened += _FileMenu_SubmenuOpened;
		}
        /// <summary>
        /// Get RecentFiles
        /// </summary>
		public List<string> RecentFiles { get { return Persister.RecentFiles( MaxNumberOfFiles ); } }
        /// <summary>
        /// Remove file to recent list
        /// </summary>
        /// <param name="filepath">File path</param>
		public void RemoveFile( string filepath ) { Persister.RemoveFile( filepath, MaxNumberOfFiles ); }
        /// <summary>
        /// Insert file to recent list
        /// </summary>
        /// <param name="filepath"></param>
		public void InsertFile( string filepath ) { Persister.InsertFile( filepath, MaxNumberOfFiles ); }
        /// <summary>
        /// Open sub-menu in file menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _FileMenu_SubmenuOpened(object sender, RoutedEventArgs e)
		{
			SetMenuItems();
		}
        /// <summary>
        /// Set menu items
        /// </summary>
        public void SetMenuItems()
		{
			RemoveMenuItems();

			LoadRecentFiles();

			InsertMenuItems();
		}
        /// <summary>
        /// Remove menu items
        /// </summary>
        public void RemoveMenuItems()
		{
			if ( _Separator != null ) FileMenu.Items.Remove( _Separator );

			if ( _RecentFiles != null )
				foreach ( RecentFile r in _RecentFiles )
					if ( r.MenuItem != null )
						FileMenu.Items.Remove( r.MenuItem );

			_Separator = null;
			_RecentFiles = null;
		}
        /// <summary>
        /// Insert menu items
        /// </summary>
        public void InsertMenuItems()
		{
			if ( _RecentFiles == null ) return;
			if ( _RecentFiles.Count == 0 ) return;

			int iMenuItem = FileMenu.Items.IndexOf( this );
			foreach ( RecentFile r in _RecentFiles )
			{
				string header = GetMenuItemText( r.Number + 1, r.Filepath, r.DisplayPath );

				r.MenuItem = new MenuItem { Header = header };
				r.MenuItem.Click += MenuItem_Click;

				FileMenu.Items.Insert( ++iMenuItem, r.MenuItem );
			}

			_Separator = new Separator();
			FileMenu.Items.Insert( ++iMenuItem, _Separator );
		}
        /// <summary>
        /// Get menu item text
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="filepath">File path</param>
        /// <param name="displaypath">Display path</param>
        /// <returns>Text of menu item</returns>
        public string GetMenuItemText(int index, string filepath, string displaypath)
		{
			GetMenuItemTextDelegate delegateGetMenuItemText = GetMenuItemTextHandler;
			if ( delegateGetMenuItemText != null ) return delegateGetMenuItemText( index, filepath );

			string format = ( index < 10 ? MenuItemFormatOneToNine : MenuItemFormatTenPlus );

			string shortPath = ShortenPathname( displaypath, MaxPathLength );

			return String.Format( format, index, filepath, shortPath );
		}


		/// <summary>
		/// Shortens a pathname for display purposes.
		/// </summary>
		/// <param labelName="pathname">The pathname to shorten.</param>
		/// <param labelName="maxLength">The maximum number of characters to be displayed.</param>
		/// <remarks>Shortens a pathname by either removing consecutive components of a path
		/// and/or by removing characters from the end of the filename and replacing
		/// then with three ellipses (...)
		/// <para>In all cases, the root of the passed path will be preserved in it's entirety.</para>
		/// <para>If a UNC path is used or the pathname and maxLength are particularly short,
		/// the resulting path may be longer than maxLength.</para>
		/// <para>This method expects fully resolved pathnames to be passed to it.
		/// (Use Path.GetFullPath() to obtain this.)</para>
		/// </remarks>
		/// <returns></returns>
		static public string ShortenPathname( string pathname, int maxLength )
		{
			if ( pathname.Length <= maxLength )
				return pathname;

			string root = Path.GetPathRoot( pathname );
			if ( root.Length > 3 )
				root += Path.DirectorySeparatorChar;

			string[] elements = pathname.Substring( root.Length ).Split( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );

			int filenameIndex = elements.GetLength( 0 ) - 1;

			if ( elements.GetLength( 0 ) == 1 ) // pathname is just a root and filename
			{
				if ( elements[ 0 ].Length > 5 ) // long enough to shorten
				{
					// if path is a UNC path, root may be rather long
					if ( root.Length + 6 >= maxLength )
					{
						return root + elements[ 0 ].Substring( 0, 3 ) + "...";
					}
					else
					{
						return pathname.Substring( 0, maxLength - 3 ) + "...";
					}
				}
			}
			else if ( ( root.Length + 4 + elements[ filenameIndex ].Length ) > maxLength ) // pathname is just a root and filename
			{
				root += "...\\";

				int len = elements[ filenameIndex ].Length;
				if ( len < 6 )
					return root + elements[ filenameIndex ];

				if ( ( root.Length + 6 ) >= maxLength )
				{
					len = 3;
				}
				else
				{
					len = maxLength - root.Length - 3;
				}
				return root + elements[ filenameIndex ].Substring( 0, len ) + "...";
			}
			else if ( elements.GetLength( 0 ) == 2 )
			{
				return root + "...\\" + elements[ 1 ];
			}
			else
			{
				int len = 0;
				int begin = 0;

				for ( int i = 0 ; i < filenameIndex ; i++ )
				{
					if ( elements[ i ].Length > len )
					{
						begin = i;
						len = elements[ i ].Length;
					}
				}

				int totalLength = pathname.Length - len + 3;
				int end = begin + 1;

				while ( totalLength > maxLength )
				{
					if ( begin > 0 )
						totalLength -= elements[ --begin ].Length - 1;

					if ( totalLength <= maxLength )
						break;

					if ( end < filenameIndex )
						totalLength -= elements[ ++end ].Length - 1;

					if ( begin == 0 && end == filenameIndex )
						break;
				}

				// assemble final string

				for ( int i = 0 ; i < begin ; i++ )
				{
					root += elements[ i ] + '\\';
				}

				root += "...\\";

				for ( int i = end ; i < filenameIndex ; i++ )
				{
					root += elements[ i ] + '\\';
				}

				return root + elements[ filenameIndex ];
			}
			return pathname;
		}
        /// <summary>
        /// Load recent files
        /// </summary>
        public void LoadRecentFiles()
		{
			_RecentFiles = LoadRecentFilesCore();
		}
        /// <summary>
        /// Load recent files core
        /// </summary>
        /// <returns></returns>
        public List<RecentFile> LoadRecentFilesCore()
		{
			List<string> list = RecentFiles;

			List<RecentFile> files = new List<RecentFile>( list.Count );

			int i = 0;
			foreach ( string filepath in list )
				files.Add( new RecentFile( i++, filepath ) );

			return files;
		}
        /// <summary>
        /// Class Recent file model
        /// </summary>
        public class RecentFile
		{
            /// <summary>
            /// Number of recent
            /// </summary>
			public int Number = 0;
            /// <summary>
            /// File path
            /// </summary>
			public string Filepath = "";
            /// <summary>
            /// Menu item
            /// </summary>
			public MenuItem MenuItem = null;
            /// <summary>
            /// Display path
            /// </summary>
			public string DisplayPath
			{
				get
				{
					return Path.Combine(
						Path.GetDirectoryName( Filepath ),
						Path.GetFileNameWithoutExtension( Filepath ) );
				}
			}
            /// <summary>
            /// Default constructor
            /// </summary>
            /// <param name="number"></param>
            /// <param name="filepath"></param>
			public RecentFile( int number, string filepath )
			{
				this.Number = number;
				this.Filepath = filepath;
			}
		}
        /// <summary>
        /// Class provides method for click menu 
        /// </summary>
		public class MenuClickEventArgs : EventArgs
		{
            /// <summary>
            /// Get or set File path
            /// </summary>
			public string Filepath { get; private set; }
            /// <summary>
            /// Default constructor
            /// </summary>
            /// <param name="filepath">File path</param>
			public MenuClickEventArgs( string filepath )
			{
				this.Filepath = filepath;
			}
		}
        /// <summary>
        /// Menu item click
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        public void MenuItem_Click(object sender, EventArgs e)
		{
			MenuItem menuItem = sender as MenuItem;

			OnMenuClick( menuItem );
		}
        /// <summary>
        /// On menu click
        /// </summary>
        /// <param name="menuItem">Menu item</param>
        public virtual void OnMenuClick(MenuItem menuItem)
		{
			string filePath = GetFilepath( menuItem );
            HandleAction(filePath);
		}
        /// <summary>
        /// Handle Action when menu item click
        /// </summary>
        /// <param name="filePath">File path</param>
        public void HandleAction(string filePath)
        {
            if (String.IsNullOrEmpty(filePath)) return;
            LogFileExt fileType = ParserManager.DetectFileType(filePath);
            switch (fileType)
            {
                case LogFileExt.Ccs:
                    {
                        RecentActionLoadCCS(filePath);
                        break;
                    }
                case LogFileExt.Cxdi:
                    {
                        RecentActionLoadCXDI(filePath);
                        break;
                    }
                case LogFileExt.Memo:
                    {
                        LogFileExt memoType = ParserManager.DetectTypeOfMemoFile(filePath);
                        switch (memoType)
                        {
                            case LogFileExt.CCSMemo:
                                {
                                    RecentActionLoadCCS(filePath);
                                    break;
                                }
                            case LogFileExt.CXDIMemo:
                                {
                                    RecentActionLoadCXDI(filePath);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// Get file path of menu item
        /// </summary>
        /// <param name="menuItem">Menu item</param>
        /// <returns>File path of menu item</returns>
        public string GetFilepath(MenuItem menuItem)
		{
			foreach ( RecentFile r in _RecentFiles )
				if ( r.MenuItem == menuItem )
					return r.Filepath;

			return String.Empty;
		}

        /// <summary>
        /// Class provides method for registry persister
        /// </summary>
        public class RegistryPersister : IPersist
		{
            /// <summary>
            /// Get or set Registry key
            /// </summary>
			public string RegistryKey { get; set; }
            /// <summary>
            /// Default constructor
            /// </summary>
			public RegistryPersister()
			{
				RegistryKey =
					"Software\\" +
					"Canon Inc" + "\\" +
					"LogViewer" + "\\" +
					"RecentFileList";
			}
            /// <summary>
            /// Constructor by key
            /// </summary>
            /// <param name="key"></param>
			public RegistryPersister( string key )
			{
				RegistryKey = key;
			}
            /// <summary>
            /// Get key by index
            /// </summary>
            /// <param name="i">Index</param>
            /// <returns></returns>
            public string Key(int i) { return i.ToString("00"); }
            /// <summary>
            /// Get recent list by maximum recent file
            /// </summary>
            /// <param name="max"></param>
            /// <returns>A collection file path</returns>
			public List<string> RecentFiles( int max )
			{
				RegistryKey k = Registry.CurrentUser.OpenSubKey( RegistryKey );
				if ( k == null ) k = Registry.CurrentUser.CreateSubKey( RegistryKey );

				List<string> list = new List<string>( max );

				for ( int i = 0 ; i < max ; i++ )
				{
					string filename = ( string ) k.GetValue( Key( i ) );

					if ( String.IsNullOrEmpty( filename ) ) break;

					list.Add( filename );
				}

				return list;
			}
            /// <summary>
            /// Insert file to recent file
            /// </summary>
            /// <param name="filepath">File path</param>
            /// <param name="max">Maximum recent file</param>
			public void InsertFile( string filepath, int max )
			{
				RegistryKey k = Registry.CurrentUser.OpenSubKey( RegistryKey );
				if ( k == null ) Registry.CurrentUser.CreateSubKey( RegistryKey );
				k = Registry.CurrentUser.OpenSubKey( RegistryKey, true );

				RemoveFile( filepath, max );

				for ( int i = max - 2 ; i >= 0 ; i-- )
				{
					string sThis = Key( i );
					string sNext = Key( i + 1 );

					object oThis = k.GetValue( sThis );
					if ( oThis == null ) continue;

					k.SetValue( sNext, oThis );
				}

				k.SetValue( Key( 0 ), filepath );
			}
            /// <summary>
            /// Remove file by file path to recent file
            /// </summary>
            /// <param name="filepath">File path</param>
            /// <param name="max">Maximum recent file</param>
			public void RemoveFile( string filepath, int max )
			{
				RegistryKey k = Registry.CurrentUser.OpenSubKey( RegistryKey );
				if ( k == null ) return;

				for ( int i = 0 ; i < max ; i++ )
				{
                    again:
					string s = ( string ) k.GetValue( Key( i ) );
					if ( s != null && s.Equals( filepath, StringComparison.CurrentCultureIgnoreCase ) )
					{
						RemoveFile( i, max );
						goto again;
					}
				}
			}
            /// <summary>
            /// Remove file by index to recent file
            /// </summary>
            /// <param name="filepath">File path</param>
            /// <param name="max">Maximum recent file</param>
            public void RemoveFile(int index, int max)
			{
				RegistryKey k = Registry.CurrentUser.OpenSubKey( RegistryKey, true );
				if ( k == null ) return;

				k.DeleteValue( Key( index ), false );

				for ( int i = index ; i < max - 1 ; i++ )
				{
					string sThis = Key( i );
					string sNext = Key( i + 1 );

					object oNext = k.GetValue( sNext );
					if ( oNext == null ) break;

					k.SetValue( sThis, oNext );
					k.DeleteValue( sNext );
				}
			}
		}

		//-----------------------------------------------------------------------------------------
        /// <summary>
        /// Class provides method for save file path to XML file
        /// </summary>
        public class XmlPersister : IPersist
		{
            /// <summary>
            /// Get or set file path
            /// </summary>
			public string Filepath { get; set; }
            /// <summary>
            /// Get or set stream
            /// </summary>
			public Stream Stream { get; set; }
            /// <summary>
            /// Default constructor
            /// </summary>
			public XmlPersister()
			{
				Filepath =
					Path.Combine(
						Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ),
						"Canon Inc" + "\\" +
						"LogViewer" + "\\" +
						"RecentFileList.xml" );
			}
            /// <summary>
            /// Constructor by file path
            /// </summary>
            /// <param name="filepath"></param>
			public XmlPersister( string filepath )
			{
				Filepath = filepath;
			}
            /// <summary>
            /// Constructor by stream
            /// </summary>
            /// <param name="stream"></param>
			public XmlPersister( Stream stream )
			{
				Stream = stream;
			}
            /// <summary>
            /// Get List file path by maximum recent file
            /// </summary>
            /// <param name="max"></param>
            /// <returns>A collection string</returns>
			public List<string> RecentFiles( int max )
			{
				return Load( max );
			}
            /// <summary>
            /// Insert file path
            /// </summary>
            /// <param name="filepath">File path</param>
            /// <param name="max">Maximum recent file</param>
			public void InsertFile( string filepath, int max )
			{
				Update( filepath, true, max );
			}
            /// <summary>
            /// Remove file path
            /// </summary>
            /// <param name="filepath">File path</param>
            /// <param name="max">Maximum recent file</param>
			public void RemoveFile( string filepath, int max )
			{
				Update( filepath, false, max );
			}
            /// <summary>
            /// Update file path
            /// </summary>
            /// <param name="filepath">File path</param>
            /// <param name="insert">Status insert</param>
            /// <param name="max">Maximum recent file</param>
            public void Update(string filepath, bool insert, int max)
			{
				List<string> old = Load( max );

				List<string> list = new List<string>( old.Count + 1 );

				if ( insert ) list.Add( filepath );

				CopyExcluding( old, filepath, list, max );

				Save( list, max );
			}
            /// <summary>
            /// Copy excluding
            /// </summary>
            /// <param name="source">List file path</param>
            /// <param name="exclude">string exclude</param>
            /// <param name="target">List target</param>
            /// <param name="max">Maximum number</param>
            public void CopyExcluding(List<string> source, string exclude, List<string> target, int max)
			{
				foreach ( string s in source )
					if ( !String.IsNullOrEmpty( s ) )
						if ( !s.Equals( exclude, StringComparison.OrdinalIgnoreCase ) )
							if ( target.Count < max )
								target.Add( s );
			}
            /// <summary>
            /// Class provides method open file 
            /// </summary>
            public class SmartStream : IDisposable
			{
				bool _IsStreamOwned = true;
				Stream _Stream = null;

				public Stream Stream { get { return _Stream; } }

				public static implicit operator Stream( SmartStream me ) { return me.Stream; }

				public SmartStream( string filepath, FileMode mode )
				{
					_IsStreamOwned = true;
                    //MessageBox.Show(filepath);
					Directory.CreateDirectory( Path.GetDirectoryName( filepath ) );
					_Stream = File.Open( filepath, mode );
				}

				public SmartStream( Stream stream )
				{
					_IsStreamOwned = false;
					_Stream = stream;
				}

				public void Dispose()
				{
					if ( _IsStreamOwned && _Stream != null ) _Stream.Dispose();

					_Stream = null;
				}
			}
            /// <summary>
            /// Open stream
            /// </summary>
            /// <param name="mode">File mode</param>
            /// <returns>Smart Stream</returns>
            public SmartStream OpenStream(FileMode mode)
			{
				if ( !String.IsNullOrEmpty( Filepath ) )
				{
					return new SmartStream( Filepath, mode );
				}
				else
				{
					return new SmartStream( Stream );
				}
			}
            /// <summary>
            /// Load file path from xml file
            /// </summary>
            /// <param name="max">Maximum recent file</param>
            /// <returns>A collection string</returns>
            public List<string> Load(int max)
			{
				List<string> list = new List<string>( max );

				using ( MemoryStream ms = new MemoryStream() )
				{
					using ( SmartStream ss = OpenStream( FileMode.OpenOrCreate ) )
					{
						if ( ss.Stream.Length == 0 ) return list;

						ss.Stream.Position = 0;

						byte[] buffer = new byte[ 1 << 20 ];
						for ( ; ; )
						{
							int bytes = ss.Stream.Read( buffer, 0, buffer.Length );
							if ( bytes == 0 ) break;
							ms.Write( buffer, 0, bytes );
						}

						ms.Position = 0;
					}

					XmlTextReader x = null;

					try
					{
						x = new XmlTextReader( ms );

						while ( x.Read() )
						{
							switch ( x.NodeType )
							{
								case XmlNodeType.XmlDeclaration:
								case XmlNodeType.Whitespace:
									break;

								case XmlNodeType.Element:
									switch ( x.Name )
									{
										case "RecentFiles": break;

										case "RecentFile":
											if ( list.Count < max ) list.Add( x.GetAttribute( 0 ) );
											break;

										default: Debug.Assert( false ); break;
									}
									break;

								case XmlNodeType.EndElement:
									switch ( x.Name )
									{
										case "RecentFiles": return list;
										default: Debug.Assert( false ); break;
									}
									break;

								default:
									Debug.Assert( false );
									break;
							}
						}
					}
					finally
					{
						if ( x != null ) x.Close();
					}
				}
				return list;
			}
            /// <summary>
            /// Save list file path to XML file
            /// </summary>
            /// <param name="list">List file path</param>
            /// <param name="max">Maximum recent file</param>
            public void Save(List<string> list, int max)
			{
				using ( MemoryStream ms = new MemoryStream() )
				{
					XmlTextWriter x = null;

					try
					{
						x = new XmlTextWriter( ms, Encoding.UTF8 );
						if ( x == null ) { Debug.Assert( false ); return; }

						x.Formatting = Formatting.Indented;

						x.WriteStartDocument();

						x.WriteStartElement( "RecentFiles" );

						foreach ( string filepath in list )
						{
							x.WriteStartElement( "RecentFile" );
							x.WriteAttributeString( "Filepath", filepath );
							x.WriteEndElement();
						}

						x.WriteEndElement();

						x.WriteEndDocument();

						x.Flush();

						using ( SmartStream ss = OpenStream( FileMode.Create ) )
						{
							ss.Stream.SetLength( 0 );

							ms.Position = 0;

							byte[] buffer = new byte[ 1 << 20 ];
							for ( ; ; )
							{
								int bytes = ms.Read( buffer, 0, buffer.Length );
								if ( bytes == 0 ) break;
								ss.Stream.Write( buffer, 0, bytes );
							}
						}
					}
					finally
					{
						if ( x != null ) x.Close();
					}
				}
			}
		}

		//-----------------------------------------------------------------------------------------

	}
}
