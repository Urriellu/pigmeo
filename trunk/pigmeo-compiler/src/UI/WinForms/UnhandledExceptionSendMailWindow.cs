using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.UI.WinForms {
	public partial class UnhandledExceptionSendMailWindow:Form {
		protected Exception ThrownException;

		public UnhandledExceptionSendMailWindow(Exception e) {
			InitializeComponent();
			ThrownException = e;
		}

		private void UnhandledExceptionSendMailWindow_Load(object sender, EventArgs e) {
			ShowInfo.InfoDebug("Instantiating a new Pigmeo.Compiler.UI.WinForms.UnhandledExceptionSendMailWindow");

			#region global settings
			LoadLanguageStrings();
			txtMailContents.Text = UnknownError.GenerateErrorReport(ThrownException);
			#endregion

			btnSend.Focus();
		}

		protected void LoadLanguageStrings() {
			ShowInfo.InfoDebug("Loading language strings (WinForms unhandled exception mail sender interface)");

			this.Text = i18n.str("unknown_error");
			lblDescription.Text = i18n.str("lbl_description");
			btnSend.Text = i18n.str("Send");
			btnIgnore.Text = i18n.str("Ignore");
		}

		private void btnIgnore_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
