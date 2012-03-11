using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Pigmeo.Internal;

namespace Pigmeo.UI {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			i18n.CurrentApp = "pigmeo-ui";

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmMain());
		}
	}
}
