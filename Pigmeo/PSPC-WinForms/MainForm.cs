using System;
using System.Windows.Forms;
using Pigmeo.Internal;
using System.IO.Ports;

namespace PSPC_WinForms {
	public partial class MainForm : Form {
		SerialPort port = new SerialPort();

		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			i18n.CurrentApp = "pspc-winforms";
			LoadPorts();
			CmbBaudRate.SelectedIndex = 3;
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
			Terminal.Text += Text;
			Terminal.Update();
		}

		void LogLine(string Text) {
			Log(Text + Environment.NewLine);
		}

		void LogLine(object obj) {
			LogLine(obj.ToString());
		}

		void LoadPorts() {
			CmbPort.Items.Clear();
			foreach (string Name in SerialPort.GetPortNames()) {
				CmbPort.Items.Add(Name);
			}
			if (CmbPort.Items.Count > 0) CmbPort.SelectedIndex = 0;
		}

		private void LoadLangStrings() {
			this.Text = i18n.str("WindowTitle");
		}

		private void BtnDisconnect_Click(object sender, EventArgs e) {
			if (port != null) {
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
			if(port!=null && port.IsOpen) port.Close();

			int baud = int.Parse(CmbBaudRate.Text);
			int DBits = int.Parse(CmbDataBits.Text);
			StopBits SB = (StopBits)Enum.Parse(typeof(StopBits), CmbStopBits.Text);
			Parity P = (Parity)Enum.Parse(typeof(Parity), CmbParity.Text);

			port = new SerialPort(CmbPort.Text, baud, P, DBits, SB);

			port.Open();
			LogLine(port.BaudRate);
			LogLine(port.DataBits);
			LogLine(port.StopBits);
			LogLine(port.Parity);
			LogLine(port.PortName);

			EnableControls();
			if (port.IsOpen) {
				Terminal.Focus();
				LogLine("Connected");
			}
			Log("Waiting for data...");
			port.ReadTimeout = 5000;
			int data = port.ReadByte();
			Log(data);
		}
	}
}
