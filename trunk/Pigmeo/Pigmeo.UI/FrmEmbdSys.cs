using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pigmeo.UI {
	public partial class FrmEmbdSys : Form {
		public FrmEmbdSys() {
			InitializeComponent();
		}

		private void FrmEmbdSys_Load(object sender, EventArgs e) {
			//remove the sample tab, we don't want it anymore
			tabsEmbSys.TabPages.Remove(tabSampleSys);
			tabSampleSys = null;
		}

		private void tabPage3_Click(object sender, EventArgs e) {

		}

		private void txtNewEmbSysId_TextChanged(object sender, EventArgs e) {
			bool changed = false;
			do {
				changed = false;
				foreach (char c in txtNewEmbSysId.Text) {
					if (!char.IsLetterOrDigit(c)) {
						txtNewEmbSysId.Text = txtNewEmbSysId.Text.Replace(c.ToString(), "");
						changed = true;
						break;
					}
				}
			} while (changed);

			if (txtNewEmbSysId.Text.Length > 0 && txtNewEmbSysId.Text.Length <= 25) btnAddNewSys.Enabled = true;
			else btnAddNewSys.Enabled = false;
		}

		private void FrmEmbdSys_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			Hide();
		}
	}
}
