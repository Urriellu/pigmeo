using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pigmeo.Internal;

namespace Pigmeo.UI {
	public partial class FrmMain : Form {
		FrmEmbdSys frmEmbeddedSystems;

		public FrmMain() {
			InitializeComponent();
		}

		private void FrmMain_Load(object sender, EventArgs e) {
		}

		private void runLocalHostToolStripMenuItem_Click(object sender, EventArgs e) {
			if (MessageBox.Show(i18n.str("AskRunLocalHost"), i18n.str("RunLocalHost"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
				MessageBox.Show("NOW WE SHOULD RUN THE HOST");
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void pigmeoWebsiteToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start(SharedSettings.PrjWebsite);
		}

		private void btnEmbSys_Click(object sender, EventArgs e) {
			if (frmEmbeddedSystems == null) {
				frmEmbeddedSystems = new FrmEmbdSys();
				frmEmbeddedSystems.MdiParent = this;
			}
			if (frmEmbeddedSystems.WindowState == FormWindowState.Minimized) frmEmbeddedSystems.WindowState = FormWindowState.Normal;
			frmEmbeddedSystems.Show();
			frmEmbeddedSystems.BringToFront();
			frmEmbeddedSystems.Activate();
			frmEmbeddedSystems.Focus();
		}
	}
}
