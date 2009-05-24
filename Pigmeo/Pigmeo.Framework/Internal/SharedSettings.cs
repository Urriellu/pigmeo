using System;

namespace Pigmeo.Internal {
	/// <summary>
	/// Settings shared by all Pigmeo-related applications and libraries
	/// </summary>
	public static class SharedSettings {
		/// <summary>
		/// Version of this application
		/// </summary>
		public const string AppVersion = "0.0.3-svn";

		/// <summary>
		/// Domain of this project
		/// </summary>
		public const string PrjDomain = "pigmeo.org";

		/// <summary>
		/// Website of this project
		/// </summary>
		public static string PrjWebsite {
			get {
				return "http://" + PrjDomain + "/";
			}
		}

		/// <summary>
		/// Full path to the running executable file
		/// </summary>
		public static string ExePath {
			get {
				if(_ExePath == null) _ExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
				return _ExePath;
			}
		}
		private static string _ExePath;

		/// <summary>
		/// Full path to the directory that contains the running executable file. The last character is NOT a slash ('/')
		/// </summary>
		public static string ExeLocation {
			get {
				if(_ExeLocation == null) _ExeLocation = System.IO.Path.GetDirectoryName(ExePath);
				return _ExeLocation;
			}
		}
		private static string _ExeLocation;

		/// <summary>
		/// Full path to the directory that contains all the required images for the graphical interfaces. The last character is NOT a slash ('/')
		/// </summary>
		public static string ImagesDirectory {
			get {
				return ExeLocation + "/images";
			}
		}

		/// <summary>
		/// Full path to the directory containing the language files. The last character is NOT a slash ('/')
		/// </summary>
		public static string LanguageFilesDir {
			get {
				return ExeLocation + "/i18n";
			}
		}

		/// <summary>
		/// Path to the directory where all the settings related to pigmeo are stored
		/// </summary>
		public static string PigmeoConfigPath {
			get {
				//choose the config path
				if(_PigmeoConfigPath == null) {
					ShowExternalInfo.InfoDebug("Looking for the Pigmeo config path");
					if(Environment.OSVersion.Platform == PlatformID.Unix) {
						_PigmeoConfigPath = Environment.GetEnvironmentVariable("HOME") + "/.pigmeo/";
					} else {
						_PigmeoConfigPath = "C:" + Environment.GetEnvironmentVariable("HOMEPATH") + "\\pigmeo\\";
					}
					ShowExternalInfo.InfoDebug("Pigmeo config path: {0}", _PigmeoConfigPath);
				}
				return _PigmeoConfigPath;
			}
		}
		private static string _PigmeoConfigPath;

		public static string WorkingDirectory {
			get {
				if(_WorkingDirectory == null) _WorkingDirectory = Environment.CurrentDirectory;
				return _WorkingDirectory;
			}
			set {
				_WorkingDirectory = value;
			}
		}
		private static string _WorkingDirectory;
	}
}
