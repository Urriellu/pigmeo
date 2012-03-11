using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pigmeo.UI {
	public partial class CtrlEmbSys : UserControl {
		readonly string SystemID;
		//readonly TabControl ParentTab;

		/// <summary>
		/// Creates a new panel with the information and control of an Embedded System 
		/// </summary>
		public CtrlEmbSys(string systemId /*, TabControl parent*/) {
			InitializeComponent();
			SystemID = systemId;
			//ParentTab = parent;
		}

		/// <summary>
		/// TO BE USED BY THE VISUAL STUDIO EDITOR, DON'T CALL THIS MANUALLY
		/// </summary>*/
		public CtrlEmbSys()
			/*: this("")*/ {
			InitializeComponent();
		}

		private void CtrlEmbSys_Load(object sender, EventArgs e) {
			Dock = DockStyle.Fill;
		}
	}
}
