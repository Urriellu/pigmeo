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
		/// Path to the directory where all the settings related to pigmeo are stored
		/// </summary>
		public static string PigmeoConfigPath {
			get {
				//choose the config path
				if(_PigmeoConfigPath == null) {
					if(Environment.OSVersion.Platform == PlatformID.Unix)
						_PigmeoConfigPath = Environment.GetEnvironmentVariable("HOME") + "/.pigmeo/";
					else
						_PigmeoConfigPath = "C:" + Environment.GetEnvironmentVariable("HOMEPATH") + "\\pigmeo\\";
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
