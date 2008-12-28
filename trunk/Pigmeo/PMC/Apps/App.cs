using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Pigmeo.Internal;

namespace Pigmeo.PMC {
	/// <summary>
	/// Represents a software application that can be called from within PMC
	/// </summary>
	public class App {
		/// <summary>
		/// Application's real name
		/// </summary>
		public readonly string RealName;

		/// <summary>
		/// Application's unix name
		/// </summary>
		public readonly string UnixName;

		/// <summary>
		/// Application's command (the \"word\" being executed from the command line, without arguments)
		/// </summary>
		public readonly string Command;

		/// <summary>
		/// List of parameters passed to the application command
		/// </summary>
		public List<string> Parameters = new List<string>();

		/// <summary>
		/// Application currently running as a child process. Null if no application is currently running
		/// </summary>
		/// <remarks>
		/// Required by static event handlers
		/// </remarks>
		protected static App RunningApp;

		/// <summary>
		/// Path to the executable file (command not included)
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

		/// <summary>
		/// Full path to the executable file
		/// </summary>
		public string CmdFullPath {
			get {
				return CmdPath + config.PathSplitter + Command;
			}
		}

		/// <summary>
		/// Instantiates a new App, given its real name, its Unix name and the command for calling it
		/// </summary>
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
						if(_IsInstalled.HasValue && _IsInstalled.Value == true) break; //skip the rest of folders when already found
						PrintMsg.InfoDebug("Looking for \"{0}\" in {1}", Command, folder);
						DirectoryInfo di = new DirectoryInfo(folder);
						if(di.Exists) {
							FileInfo[] files = di.GetFiles();
							foreach(FileInfo file in files) {
								if(_IsInstalled.HasValue && _IsInstalled.Value == true) break; //skip the rest of file when already found
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

		/// <summary>
		/// Runs the application
		/// </summary>
		/// <returns>Value returned by the application</returns>
		public virtual int Run() {
			RunningApp = this;

			PrintMsg.InfoDebug("Running \"{0}\"'s base.Run()  (\"Pigmeo.PMC.App.Run()\")", this.RealName);

			string arguments = "";
			ProcessStartInfo ProcInfo;
			Process proc;

			foreach(string parameter in Parameters) {
				arguments += " " + parameter;
			}

			ProcInfo = new ProcessStartInfo(Command, arguments);
			ProcInfo.CreateNoWindow = true;
			ProcInfo.ErrorDialog = false;
			ProcInfo.RedirectStandardError = true;
			ProcInfo.RedirectStandardOutput = true;
			ProcInfo.UseShellExecute = false;
			proc = new Process();
			proc.StartInfo = ProcInfo;
			proc.OutputDataReceived += new DataReceivedEventHandler(OuputHandler);
			proc.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);
			PrintMsg.InfoDebug("Executing: {0}{1}", Command, arguments);
			proc.Start();
			PrintMsg.InfoDebug("Reading outputs");
			proc.BeginErrorReadLine();
			proc.BeginOutputReadLine();
			PrintMsg.InfoDebug("Waiting for exit...");
			proc.WaitForExit();

			if(proc.ExitCode == 0) PrintMsg.InfoVerbose(i18n.str("AppEndOk", this.RealName));

			RunningApp = null;
			return proc.ExitCode;
		}

		protected static void OuputHandler(object SendingProcess, DataReceivedEventArgs OutLine) {
			PrintMsg.WriteLine(RunningApp, OutLine.Data);
		}

		protected static void ErrorHandler(object SendingProcess, DataReceivedEventArgs OutLine) {
			PrintMsg.WriteErrorLine(RunningApp, OutLine.Data);
		}
	}
}
