using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pigmeo.UI {
	public partial class CtrlEmbApp : UserControl {
		readonly string AppID;

		public CtrlEmbApp(string appId) {
			AppID = appId;
			InitializeComponent();
		}

		/// <summary>
		/// TO BE USED BY THE VISUAL STUDIO EDITOR, DON'T CALL THIS MANUALLY
		/// </summary>
		public CtrlEmbApp()
			/*: this("")*/ {
			InitializeComponent();
		}

		private void CtrlEmbApp_Load(object sender, EventArgs e) {

		}
	}
}
