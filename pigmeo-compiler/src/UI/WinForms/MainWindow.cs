using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pigmeo.Compiler;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.UI.WinForms {
	public partial class MainWindow:Form {
		public MainWindow() {
			InitializeComponent();
			LoadLanguageStrings();
		}

		/// <summary>
		/// Loads all language-dependent strings shown in the window
		/// </summary>
		protected void LoadLanguageStrings(){
			this.Text = config.Internal.AppName;
			MenuItem001.Text = i18n.str(1);
			MenuItem002.Text = i18n.str(2);
			MenuItem003.Text = i18n.str(3);
			MenuItem004.Text = i18n.str(6);
			MenuItem005.Text = i18n.str(4, config.Internal.AppName);
		}

		private void MenuItem003_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void MenuItem002_Click(object sender, EventArgs e) {
			Unimplemented();
		}

		protected void Unimplemented() {
			MessageBox.Show(i18n.str(13), i18n.str(12), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void MenuItem005_Click(object sender, EventArgs e) {
			AboutWindow abw = new AboutWindow();
			abw.ShowDialog();
		}
	}
}
