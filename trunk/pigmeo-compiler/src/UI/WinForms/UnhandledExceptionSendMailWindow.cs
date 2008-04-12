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
			lblSendReport.Text = i18n.str("lbl_send_report");
			lblPrivateInfo.Text = i18n.str("lbl_PrivateInfo");
			btnSend.Text = i18n.str("Send");
			btnIgnore.Text = i18n.str("Ignore");

			ResizeControls();
		}

		protected void ResizeControls() {
			ShowInfo.InfoDebug("Resizing controls (WinForms unhandled exception mail sender interface)");

			Label WidestLabel = lblDescription;
			if(lblPrivateInfo.Size.Width > WidestLabel.Size.Width) WidestLabel = lblPrivateInfo;
			if(lblSendReport.Size.Width > WidestLabel.Size.Width) WidestLabel = lblSendReport;
			this.MinimumSize = new Size(WidestLabel.Location.X + WidestLabel.Size.Width + 5, 300);
		}

		private void btnIgnore_Click(object sender, EventArgs e) {
			ShowInfo.InfoDebug("Ignoring unknown error");
			this.Close();
		}

		[PigmeoToDo("find a public SMTP server, build our own, or send bug reports by other way")]
		private void btnSend_Click(object sender, EventArgs e) {
			ShowInfo.InfoDebug("Sending e-mail to developers about an unknown error");

			try {
				System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
				message.To.Add("bug-reports@pigmeo.org");
				message.Subject = "Unknown error";
				message.From = new System.Net.Mail.MailAddress("PigmeoCompiler@pigmeo.org");
				message.Body = txtMailContents.Text;

				System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("localhost");
				smtp.Send(message);
			} catch {
				MessageBox.Show(i18n.str("UnableSendBug"), i18n.str(12), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} finally {
				this.Close();
			}
		}
	}
}
