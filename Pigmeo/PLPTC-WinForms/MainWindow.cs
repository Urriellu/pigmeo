using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Pigmeo.Internal;
using Pigmeo.PC;

namespace Pigmeo.PLPTC {
	public partial class MainWindow:Form {
		ParallelPort pp = new ParallelPort();
		Pinout PinoutWindow = new Pinout();

		public MainWindow() {
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e) {
			i18n.CurrentApp = "plptc-winforms";
			LoadLanguageStrings();
			Connect();
			RadioStatus17_0.PerformClick();
		}

		/// <summary>
		/// Loads all language-dependent strings shown in the window
		/// </summary>
		public void LoadLanguageStrings() {
			Text = i18n.str("PlptcTitle");
			fileToolStripMenuItem.Text = i18n.str("File");
			exitToolStripMenuItem.Text = i18n.str("Exit");
			parallelPortToolStripMenuItem.Text = i18n.str("ParallelPort");
			connectToolStripMenuItem.Text = i18n.str("Connect");
			disconnectToolStripMenuItem.Text = i18n.str("Disconnect");
			helpToolStripMenuItem.Text = i18n.str("Help");
			LblPinNo.Text = i18n.str("Pin");
			LblIO.Text = i18n.str("I/O");
			pinoutToolStripMenuItem.Text = i18n.str("PpPinout");
			
			RadioStatus17_0.Text = i18n.str("Radio0");
			RadioStatus17_1.Text = i18n.str("Radio1");

			PinoutWindow.Text = i18n.str("PpPinout");
		}

		private void Connect() {
			try {
				pp.Initialize();
				ShowAsConnected();
			} catch(Exception ex) {
				StatusTxt.Text = ex.Message;
			}
		}

		private void Disconnect() {
			pp.Close();
			ShowAsDisconnected();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Disconnect();
			this.Close();
		}

		private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
			Connect();
		}

		private void ShowAsConnected() {
			ConnectionStatus.Text = "Connected";
		}

		private void ShowAsDisconnected() {
			ConnectionStatus.Text = "Disconnected";
		}

		private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
			Disconnect();
		}

		private void RadioStatus17_0_CheckedChanged(object sender, EventArgs e) {
			pp.Pin17 = false;
		}

		private void RadioStatus17_1_CheckedChanged(object sender, EventArgs e) {
			pp.Pin17 = true;
		}

		private void pinoutToolStripMenuItem_Click(object sender, EventArgs e) {
			PinoutWindow.Show();
		}
	}
}
