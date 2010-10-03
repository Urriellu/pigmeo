using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Pigmeo.Internal;
using Pigmeo.PC;
using Pigmeo.Extensions;

namespace Pigmeo.PLPTC {
	/// <summary>
	/// PLPTC WinForms main form
	/// </summary>
	public partial class MainWindow:Form {
		ParallelPort pp = new ParallelPort();
		bool Connected = false;
		//int Margin = 5;
		System.Windows.Forms.Timer TimerReadInputs = new System.Windows.Forms.Timer();

		/// <summary>
		/// Instantiates a new WinForms Main Window
		/// </summary>
		public MainWindow() {
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e) {
			i18n.CurrentApp = "plptc-winforms";
			ImagePinout.ImageLocation = SharedSettings.ImagesDirectory + "/PpPinout.gif";
			LoadLanguageStrings();
			Connect();
			TimerReadInputs.Tick += new EventHandler(TimerReadInputs_Tick);
			ChkTimerOn.Checked = true;
			TimerReadInputs.Start();
			RadioDataOutputs.PerformClick();
			pp.Pin1 = pp.Pin14 = pp.Pin16 = pp.Pin17 = false;
		}

		void TimerReadInputs_Tick(object sender, EventArgs e) {
			if(Connected) {
				UpdateInputs();
			}
		}

		void UpdateInputs() {
			if(pp.Pin10 == false) LblPin10.Text = "0";
			else LblPin10.Text = "1";

			if(pp.Pin11 == false) LblPin11.Text = "0";
			else LblPin11.Text = "1";

			if(pp.Pin12 == false) LblPin12.Text = "0";
			else LblPin12.Text = "1";

			if(pp.Pin13 == false) LblPin13.Text = "0";
			else LblPin13.Text = "1";

			if(pp.Pin15 == false) LblPin15.Text = "0";
			else LblPin15.Text = "1";

			if(pp.DataIoStatus == DigitalIOConfig.Input) {
				UpdateShownDataValue(pp.Data);
			}
		}

		/// <summary>
		/// Updates the labels/textboxes showing the current value of the Data Port
		/// </summary>
		void UpdateShownDataValue(byte Value) {
			TxtDataChar.Text = "'" + (char)Value + "'";
			TxtDataBin.Text = Value.ToBinaryString();
			TxtDataHex.Text = "0x" + string.Format("{0:X4}", Value);
			NumData0.Value = (Value.GetBit(0)) ? 1 : 0;
			NumData1.Value = (Value.GetBit(1)) ? 1 : 0;
			NumData2.Value = (Value.GetBit(2)) ? 1 : 0;
			NumData3.Value = (Value.GetBit(3)) ? 1 : 0;
			NumData4.Value = (Value.GetBit(4)) ? 1 : 0;
			NumData5.Value = (Value.GetBit(5)) ? 1 : 0;
			NumData6.Value = (Value.GetBit(6)) ? 1 : 0;
			NumData7.Value = (Value.GetBit(7)) ? 1 : 0;
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
			LblGround.Text = i18n.str("Ground");
			ChkTimerOn.Text = i18n.str("TimerOn");
			LblDataHex.Text = i18n.str("Hexadecimal");
			LblDataChar.Text = i18n.str("DataChar");
			LblDataBinary.Text = i18n.str("Binary");
			RadioDataOutputs.Text = i18n.str("Outputs");
			RadioDataInputs.Text = i18n.str("Inputs");
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
			Connected = true;
		}

		private void ShowAsDisconnected() {
			ConnectionStatus.Text = "Disconnected";
			Connected = false;
		}

		private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
			Disconnect();
		}

		private void DataIoChanged(object sender, EventArgs e) {
			if(RadioDataOutputs.Checked) {
				pp.SetDataOutput();
				TxtDataBin.Enabled = true;
				TxtDataChar.Enabled = true;
				TxtDataHex.Enabled = true;
				NumData0.Enabled = true;
				NumData1.Enabled = true;
				NumData2.Enabled = true;
				NumData3.Enabled = true;
				NumData4.Enabled = true;
				NumData5.Enabled = true;
				NumData6.Enabled = true;
				NumData7.Enabled = true;
			} else {
				pp.SetDataInput();
				TxtDataBin.Enabled = false;
				TxtDataChar.Enabled = false;
				TxtDataHex.Enabled = false;
				NumData0.Enabled = false;
				NumData1.Enabled = false;
				NumData2.Enabled = false;
				NumData3.Enabled = false;
				NumData4.Enabled = false;
				NumData5.Enabled = false;
				NumData6.Enabled = false;
				NumData7.Enabled = false;
			}
		}

		private void NumPin1_ValueChanged(object sender, EventArgs e) {
			if(NumPin1.Value == 0) pp.Pin1 = false;
			else pp.Pin1 = true;
		}

		private void NumPin14_ValueChanged(object sender, EventArgs e) {
			if(NumPin14.Value == 0) pp.Pin14 = false;
			else pp.Pin14 = true;
		}

		private void NumPin16_ValueChanged(object sender, EventArgs e) {
			if(NumPin16.Value == 0) pp.Pin16 = false;
			else pp.Pin16 = true;
		}

		private void NumPin17_ValueChanged(object sender, EventArgs e) {
			if(NumPin17.Value == 0) pp.Pin17 = false;
			else pp.Pin17 = true;
		}

		private void NumTimerValue_ValueChanged(object sender, EventArgs e) {
			TimerReadInputs.Interval = (int)NumTimerValue.Value;
		}

		private void ChkTimerOn_CheckedChanged(object sender, EventArgs e) {
			if(ChkTimerOn.Checked) TimerReadInputs.Start();
			else TimerReadInputs.Stop();
		}

		/// <summary>
		/// One of the Data bits has changed. Read all of them, update the rest of representations, and put the value to the physical parallel port
		/// </summary>
		private void DataBitChanged(object sender, EventArgs e) {
			byte value = 0;
			if(NumData0.Value == 1) value.SetBit(0, true);
			if(NumData1.Value == 1) value.SetBit(1, true);
			if(NumData2.Value == 1) value.SetBit(2, true);
			if(NumData3.Value == 1) value.SetBit(3, true);
			if(NumData4.Value == 1) value.SetBit(4, true);
			if(NumData5.Value == 1) value.SetBit(5, true);
			if(NumData6.Value == 1) value.SetBit(6, true);
			if(NumData7.Value == 1) value.SetBit(7, true);
			UpdateShownDataValue(value);
			pp.Data = value;
		}

		private void TxtDataBin_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {
			byte value = TxtDataBin.Text.BinToByte();
			UpdateShownDataValue(value);
			pp.Data = value;
		}

		private void TxtDataHex_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {
			byte value = byte.Parse(TxtDataHex.Text.Remove(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
			UpdateShownDataValue(value);
			pp.Data = value;
		}

		private void TxtDataChar_TextChanged(object sender, EventArgs e) {
			byte value = (byte)TxtDataChar.Text[1];
			UpdateShownDataValue(value);
			pp.Data = value;
		}
	}
}
