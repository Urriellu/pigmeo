using System;
using System.Windows.Forms;
using Pigmeo.Internal;
using System.IO.Ports;
using System.Threading;
using System.Text;

namespace PSPC_WinForms {
	public partial class MainForm:Form {
		static MainForm TheForm;
		static SerialPort port = new SerialPort();
		Thread ThreadReceiver;

		public MainForm() {
			TheForm = this;
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			i18n.CurrentApp = "pspc-winforms";
			LoadPorts();
			CmbBaudRate.SelectedIndex = 5;
			CmbParity.SelectedIndex = 0;
			CmbDataBits.SelectedIndex = 1;
			CmbStopBits.SelectedIndex = 0;
			LoadLangStrings();
		}

		void Log(object obj) {
			Log(obj.ToString());
		}

		void Log(string Text) {
			Console.WriteLine(Text);
			Invoke(new Action<string>(TerminalAppendText), Text); //thread-safe requirement
		}

		void LogLine(string Text) {
			Log(Text + Environment.NewLine);
		}

		void LogLine(object obj) {
			LogLine(obj.ToString());
		}

		/// <summary>
		/// Appends a given text to the end of the Terminal. Required for thread safety
		/// </summary>s
		void TerminalAppendText(string TextToAppend) {
			Terminal.Text += TextToAppend;
		}

		void LoadPorts() {
			CmbPort.Items.Clear();
			foreach(string Name in SerialPort.GetPortNames()) {
				CmbPort.Items.Add(Name);
			}
			if(CmbPort.Items.Count > 0) CmbPort.SelectedIndex = 0;
		}

		private void LoadLangStrings() {
			this.Text = i18n.str("WindowTitle");
			LblSendStr.Text = i18n.str("SendString");
			LblSendHex.Text = i18n.str("SendHex");
			LblSendDecimal.Text = i18n.str("SendDecimal");
			LblSendBinary.Text = i18n.str("SendBinary");
			BtnSend.Text = i18n.str("Send");
			gbPortSettings.Text = i18n.str("SpSettings");
			LblPort.Text = i18n.str("Port");
			LblBaudRate.Text = i18n.str("BaudRate");
			LblParity.Text = i18n.str("Parity");
			LblDataBits.Text = i18n.str("DataBits");
			LblStopBits.Text = i18n.str("StopBits");
			BtnConnect.Text = i18n.str("Connect");
			BtnDisconnect.Text = i18n.str("Disconnect");
		}

		private void BtnDisconnect_Click(object sender, EventArgs e) {
			ThreadReceiver.Abort();
			ThreadReceiver = null;
			if(port != null) {
				port.Close();
				port.Dispose();
				port = null;
			}
			LoadPorts();
			DisableControls();
		}

		void EnableControls() {
		}

		void DisableControls() {
		}

		private void BtnConnect_Click(object sender, EventArgs e) {
			if(port != null && port.IsOpen) port.Close();

			int baud = int.Parse(CmbBaudRate.Text);
			int DBits = int.Parse(CmbDataBits.Text);
			StopBits SB = (StopBits)Enum.Parse(typeof(StopBits), CmbStopBits.Text);
			Parity P = (Parity)Enum.Parse(typeof(Parity), CmbParity.Text);

			port = new SerialPort(CmbPort.Text, baud, P, DBits, SB);

			port.Open();
			EnableControls();
			Terminal.Clear();
			if(port.IsOpen) Terminal.Focus();
			ThreadReceiver = new Thread(DataReceiver);
			ThreadReceiver.Start();
		}

		static void DataReceiver() {
			while(port != null && TheForm != null) {
				TheForm.Log(port.ReadExisting());
			}
		}

		private void BtnSend_Click(object sender, EventArgs e) {
			string[] DataStr = TxtSendDecimal.Text.Split(' ');
			byte[] Data = new byte[DataStr.Length];
			for(int i = 0 ; i < DataStr.Length ; i++) Data[i] = byte.Parse(DataStr[i]);
			if(TxtSendDecimal.Text.Length > 0) port.Write(Data, 0, Data.Length);
		}
	}
}
