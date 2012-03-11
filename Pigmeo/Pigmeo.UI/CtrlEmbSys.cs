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
		readonly EmbeddedSystem Sys;

		/// <summary>
		/// Creates a new panel with the information and control of an Embedded System 
		/// </summary>
		public CtrlEmbSys(EmbeddedSystem sys) {
			InitializeComponent();
			this.Sys=sys;

			lblSysInf.Text = Sys.SysInfo;
			ip.Text = Sys.IP;
		}

		/// <summary>
		/// TO BE USED BY THE VISUAL STUDIO EDITOR, DON'T CALL THIS MANUALLY
		/// </summary>*/
		public CtrlEmbSys()
			/*: this("")*/ {
			InitializeComponent();
			tabsApps.TabPages.Remove(tabSample);
			tabSample = null;
			//remove the sample app tab
			
		}

		private void CtrlEmbSys_Load(object sender, EventArgs e) {
			Dock = DockStyle.Fill;
		}
	}
}
