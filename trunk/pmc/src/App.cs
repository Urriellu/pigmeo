using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Pigmeo.PMC {
	/// <summary>
	/// Represents a software application that can be called from within PMC
	/// </summary>
	public class App {
		public readonly string RealName;
		public readonly string UnixName;
		public readonly string Command;

		/// <summary>
		/// Full path to the executable file
		/// </summary>
		public string CmdPath {
			get {
				return _CmdPath;
			}
			set {
				_IsInstalled = null;
			}
		}
		private string _CmdPath;

		public App(string RealName, string UnixName, string Command) {
			this.RealName = RealName;
			this.UnixName = UnixName;
			this.Command = Command;
		}

		/// <summary>
		/// Checks whether this application is installed or not
		/// </summary>
		public bool IsInstalled {
			get {
				if(!_IsInstalled.HasValue) {
					PrintMsg.InfoDebug("Checking whether {0} is installed or not", RealName);
					string path = Environment.GetEnvironmentVariable("PATH");
					string[] folders = path.Split(';', ':');
					foreach(string folder in folders) {
						PrintMsg.InfoDebug("Looking for \"{0}\" in {1}", Command, folder);
						DirectoryInfo di = new DirectoryInfo(folder);
						if(di.Exists) {
							FileInfo[] files = di.GetFiles();
							foreach(FileInfo file in files) {
								if(file.Name == Command) {
									PrintMsg.InfoDebug("Found \"{0}\" in {1}", Command, folder);
									_IsInstalled = true;
									_CmdPath = di.ToString();
								}
							}
						}
					}
				}
				return _IsInstalled.Value;
			}
		}
		private bool? _IsInstalled;

		public override string ToString() {
			return RealName;
		}
	}
}
