using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler {
	public static class UnknownError {
		public static List<string> ShownMsgs = new List<string>();

		public static string GenerateErrorReport(Exception e) {
			string report = "";

			report += config.Internal.AppName + " " + config.Internal.AppVersion + Environment.NewLine;

			report += Environment.NewLine;

			report += "Date and time: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + Environment.NewLine;
			report += "CLR version: " + Environment.Version + Environment.NewLine;
			report += "Calling command: " + Environment.CommandLine + Environment.NewLine;
			report += "Current directory: " + Environment.CurrentDirectory + Environment.NewLine;
			report += "OS: " + Environment.OSVersion + Environment.NewLine;
			report += "Base directory: " + AppDomain.CurrentDomain.BaseDirectory + Environment.NewLine;
			report += "App Domain friendly name: " + AppDomain.CurrentDomain.FriendlyName + Environment.NewLine;

			report += "Pigmeo Compiler executable file: " + config.Internal.ExePath + Environment.NewLine;
			report += "Interface language: " + config.Internal.lang + Environment.NewLine;
			report += "Config path: " + config.Internal.PigmeoConfigPath + Environment.NewLine;
			report += "User interface: " + config.Internal.UI.ToString() + Environment.NewLine;
			report += "User application being compiled: " + config.Internal.UserApp + Environment.NewLine;
			report += "Working directory: " + config.Internal.WorkingDirectory + Environment.NewLine;

			report += Environment.NewLine;

			foreach(string str in ShownMsgs) {
				report += str + Environment.NewLine;
			}

			report += Environment.NewLine;

			report += "Type: " + e.GetType().Name + Environment.NewLine;
			report += "Message: " + e.Message + Environment.NewLine;
			report += "Source: " + e.TargetSite.Name + Environment.NewLine;
			report += "Stack trace:" + Environment.NewLine + e.StackTrace;
			Exception Inner = e.InnerException;
			while(Inner != null) {
				report += Environment.NewLine + Inner.Message.ToString();
				Inner = Inner.InnerException;
			}

			return report;
		}
	}
}
