namespace PSPC_WinForms {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.gbPortSettings = new System.Windows.Forms.GroupBox();
			this.LblPort = new System.Windows.Forms.Label();
			this.CmbPort = new System.Windows.Forms.ComboBox();
			this.LblStopBits = new System.Windows.Forms.Label();
			this.CmbBaudRate = new System.Windows.Forms.ComboBox();
			this.CmbStopBits = new System.Windows.Forms.ComboBox();
			this.LblBaudRate = new System.Windows.Forms.Label();
			this.LblDataBits = new System.Windows.Forms.Label();
			this.CmbParity = new System.Windows.Forms.ComboBox();
			this.CmbDataBits = new System.Windows.Forms.ComboBox();
			this.LblParity = new System.Windows.Forms.Label();
			this.BtnSend = new System.Windows.Forms.Button();
			this.LblSendStr = new System.Windows.Forms.Label();
			this.TxtSendString = new System.Windows.Forms.TextBox();
			this.Terminal = new System.Windows.Forms.RichTextBox();
			this.LblSendDecimal = new System.Windows.Forms.Label();
			this.TxtSendDecimal = new System.Windows.Forms.TextBox();
			this.LblSendHex = new System.Windows.Forms.Label();
			this.TxtSendHex = new System.Windows.Forms.TextBox();
			this.LblSendBinary = new System.Windows.Forms.Label();
			this.TxtSendBinary = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.TxtStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtnDisconnect = new System.Windows.Forms.Button();
			this.BtnConnect = new System.Windows.Forms.Button();
			this.gbPortSettings.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbPortSettings
			// 
			this.gbPortSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.gbPortSettings.Controls.Add(this.LblPort);
			this.gbPortSettings.Controls.Add(this.CmbPort);
			this.gbPortSettings.Controls.Add(this.LblStopBits);
			this.gbPortSettings.Controls.Add(this.CmbBaudRate);
			this.gbPortSettings.Controls.Add(this.CmbStopBits);
			this.gbPortSettings.Controls.Add(this.LblDataBits);
			this.gbPortSettings.Controls.Add(this.CmbParity);
			this.gbPortSettings.Controls.Add(this.CmbDataBits);
			this.gbPortSettings.Controls.Add(this.LblParity);
			this.gbPortSettings.Controls.Add(this.LblBaudRate);
			this.gbPortSettings.Location = new System.Drawing.Point(15, 433);
			this.gbPortSettings.Name = "gbPortSettings";
			this.gbPortSettings.Size = new System.Drawing.Size(440, 64);
			this.gbPortSettings.TabIndex = 5;
			this.gbPortSettings.TabStop = false;
			this.gbPortSettings.Text = "NOT SET (Serial Port Settings)";
			// 
			// LblPort
			// 
			this.LblPort.AutoSize = true;
			this.LblPort.Location = new System.Drawing.Point(12, 19);
			this.LblPort.Name = "LblPort";
			this.LblPort.Size = new System.Drawing.Size(82, 13);
			this.LblPort.TabIndex = 0;
			this.LblPort.Text = "NOT SET (Port)";
			// 
			// CmbPort
			// 
			this.CmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbPort.FormattingEnabled = true;
			this.CmbPort.Location = new System.Drawing.Point(13, 35);
			this.CmbPort.Name = "CmbPort";
			this.CmbPort.Size = new System.Drawing.Size(136, 21);
			this.CmbPort.TabIndex = 1;
			// 
			// LblStopBits
			// 
			this.LblStopBits.AutoSize = true;
			this.LblStopBits.Location = new System.Drawing.Point(365, 19);
			this.LblStopBits.Name = "LblStopBits";
			this.LblStopBits.Size = new System.Drawing.Size(105, 13);
			this.LblStopBits.TabIndex = 8;
			this.LblStopBits.Text = "NOT SET (Stop Bits)";
			// 
			// CmbBaudRate
			// 
			this.CmbBaudRate.FormattingEnabled = true;
			this.CmbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
			this.CmbBaudRate.Location = new System.Drawing.Point(156, 35);
			this.CmbBaudRate.Name = "CmbBaudRate";
			this.CmbBaudRate.Size = new System.Drawing.Size(69, 21);
			this.CmbBaudRate.TabIndex = 3;
			// 
			// CmbStopBits
			// 
			this.CmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbStopBits.FormattingEnabled = true;
			this.CmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
			this.CmbStopBits.Location = new System.Drawing.Point(363, 35);
			this.CmbStopBits.Name = "CmbStopBits";
			this.CmbStopBits.Size = new System.Drawing.Size(65, 21);
			this.CmbStopBits.TabIndex = 9;
			// 
			// LblBaudRate
			// 
			this.LblBaudRate.AutoSize = true;
			this.LblBaudRate.Location = new System.Drawing.Point(155, 19);
			this.LblBaudRate.Name = "LblBaudRate";
			this.LblBaudRate.Size = new System.Drawing.Size(114, 13);
			this.LblBaudRate.TabIndex = 2;
			this.LblBaudRate.Text = "NOT SET (Baud Rate)";
			// 
			// LblDataBits
			// 
			this.LblDataBits.AutoSize = true;
			this.LblDataBits.Location = new System.Drawing.Point(299, 19);
			this.LblDataBits.Name = "LblDataBits";
			this.LblDataBits.Size = new System.Drawing.Size(106, 13);
			this.LblDataBits.TabIndex = 6;
			this.LblDataBits.Text = "NOT SET (Data Bits)";
			// 
			// CmbParity
			// 
			this.CmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbParity.FormattingEnabled = true;
			this.CmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
			this.CmbParity.Location = new System.Drawing.Point(231, 35);
			this.CmbParity.Name = "CmbParity";
			this.CmbParity.Size = new System.Drawing.Size(60, 21);
			this.CmbParity.TabIndex = 5;
			// 
			// CmbDataBits
			// 
			this.CmbDataBits.FormattingEnabled = true;
			this.CmbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
			this.CmbDataBits.Location = new System.Drawing.Point(297, 35);
			this.CmbDataBits.Name = "CmbDataBits";
			this.CmbDataBits.Size = new System.Drawing.Size(60, 21);
			this.CmbDataBits.TabIndex = 7;
			// 
			// LblParity
			// 
			this.LblParity.AutoSize = true;
			this.LblParity.Location = new System.Drawing.Point(233, 19);
			this.LblParity.Name = "LblParity";
			this.LblParity.Size = new System.Drawing.Size(89, 13);
			this.LblParity.TabIndex = 4;
			this.LblParity.Text = "NOT SET (Parity)";
			// 
			// BtnSend
			// 
			this.BtnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSend.Location = new System.Drawing.Point(571, 314);
			this.BtnSend.Name = "BtnSend";
			this.BtnSend.Size = new System.Drawing.Size(75, 98);
			this.BtnSend.TabIndex = 9;
			this.BtnSend.Text = "NOT SET (Send)";
			// 
			// LblSendStr
			// 
			this.LblSendStr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblSendStr.AutoSize = true;
			this.LblSendStr.Location = new System.Drawing.Point(12, 317);
			this.LblSendStr.Name = "LblSendStr";
			this.LblSendStr.Size = new System.Drawing.Size(118, 13);
			this.LblSendStr.TabIndex = 7;
			this.LblSendStr.Text = "NOT SET (Send String)";
			// 
			// TxtSendString
			// 
			this.TxtSendString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TxtSendString.Location = new System.Drawing.Point(136, 314);
			this.TxtSendString.Name = "TxtSendString";
			this.TxtSendString.Size = new System.Drawing.Size(429, 20);
			this.TxtSendString.TabIndex = 8;
			// 
			// Terminal
			// 
			this.Terminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Terminal.Location = new System.Drawing.Point(12, 12);
			this.Terminal.Name = "Terminal";
			this.Terminal.Size = new System.Drawing.Size(634, 296);
			this.Terminal.TabIndex = 6;
			this.Terminal.Text = "";
			// 
			// LblSendDecimal
			// 
			this.LblSendDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblSendDecimal.AutoSize = true;
			this.LblSendDecimal.Location = new System.Drawing.Point(12, 369);
			this.LblSendDecimal.Name = "LblSendDecimal";
			this.LblSendDecimal.Size = new System.Drawing.Size(129, 13);
			this.LblSendDecimal.TabIndex = 10;
			this.LblSendDecimal.Text = "NOT SET (Send Decimal)";
			// 
			// TxtSendDecimal
			// 
			this.TxtSendDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TxtSendDecimal.Location = new System.Drawing.Point(147, 366);
			this.TxtSendDecimal.Name = "TxtSendDecimal";
			this.TxtSendDecimal.Size = new System.Drawing.Size(418, 20);
			this.TxtSendDecimal.TabIndex = 11;
			// 
			// LblSendHex
			// 
			this.LblSendHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblSendHex.AutoSize = true;
			this.LblSendHex.Location = new System.Drawing.Point(12, 343);
			this.LblSendHex.Name = "LblSendHex";
			this.LblSendHex.Size = new System.Drawing.Size(110, 13);
			this.LblSendHex.TabIndex = 12;
			this.LblSendHex.Text = "NOT SET (Send Hex)";
			// 
			// TxtSendHex
			// 
			this.TxtSendHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TxtSendHex.Location = new System.Drawing.Point(128, 340);
			this.TxtSendHex.Name = "TxtSendHex";
			this.TxtSendHex.Size = new System.Drawing.Size(437, 20);
			this.TxtSendHex.TabIndex = 13;
			// 
			// LblSendBinary
			// 
			this.LblSendBinary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblSendBinary.AutoSize = true;
			this.LblSendBinary.Location = new System.Drawing.Point(12, 395);
			this.LblSendBinary.Name = "LblSendBinary";
			this.LblSendBinary.Size = new System.Drawing.Size(120, 13);
			this.LblSendBinary.TabIndex = 14;
			this.LblSendBinary.Text = "NOT SET (Send Binary)";
			// 
			// TxtSendBinary
			// 
			this.TxtSendBinary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TxtSendBinary.Location = new System.Drawing.Point(138, 392);
			this.TxtSendBinary.Name = "TxtSendBinary";
			this.TxtSendBinary.Size = new System.Drawing.Size(427, 20);
			this.TxtSendBinary.TabIndex = 15;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TxtStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 506);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(658, 22);
			this.statusStrip1.TabIndex = 16;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// TxtStatus
			// 
			this.TxtStatus.Name = "TxtStatus";
			this.TxtStatus.Size = new System.Drawing.Size(91, 17);
			this.TxtStatus.Text = "NOT SET (Status)";
			// 
			// BtnDisconnect
			// 
			this.BtnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnDisconnect.Location = new System.Drawing.Point(530, 474);
			this.BtnDisconnect.Name = "BtnDisconnect";
			this.BtnDisconnect.Size = new System.Drawing.Size(116, 23);
			this.BtnDisconnect.TabIndex = 17;
			this.BtnDisconnect.Text = "NOT SET (Disconnect)";
			this.BtnDisconnect.UseVisualStyleBackColor = true;
			this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
			// 
			// BtnConnect
			// 
			this.BtnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnConnect.Location = new System.Drawing.Point(530, 445);
			this.BtnConnect.Name = "BtnConnect";
			this.BtnConnect.Size = new System.Drawing.Size(116, 23);
			this.BtnConnect.TabIndex = 18;
			this.BtnConnect.Text = "NOT SET (Connect)";
			this.BtnConnect.UseVisualStyleBackColor = true;
			this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(658, 528);
			this.Controls.Add(this.BtnConnect);
			this.Controls.Add(this.BtnDisconnect);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.LblSendBinary);
			this.Controls.Add(this.TxtSendBinary);
			this.Controls.Add(this.LblSendHex);
			this.Controls.Add(this.TxtSendHex);
			this.Controls.Add(this.LblSendDecimal);
			this.Controls.Add(this.TxtSendDecimal);
			this.Controls.Add(this.BtnSend);
			this.Controls.Add(this.LblSendStr);
			this.Controls.Add(this.TxtSendString);
			this.Controls.Add(this.Terminal);
			this.Controls.Add(this.gbPortSettings);
			this.Name = "MainForm";
			this.Text = "NOT SET";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.gbPortSettings.ResumeLayout(false);
			this.gbPortSettings.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbPortSettings;
		private System.Windows.Forms.Label LblPort;
		private System.Windows.Forms.ComboBox CmbPort;
		private System.Windows.Forms.Label LblStopBits;
		private System.Windows.Forms.ComboBox CmbBaudRate;
		private System.Windows.Forms.ComboBox CmbStopBits;
		private System.Windows.Forms.Label LblBaudRate;
		private System.Windows.Forms.Label LblDataBits;
		private System.Windows.Forms.ComboBox CmbParity;
		private System.Windows.Forms.ComboBox CmbDataBits;
		private System.Windows.Forms.Label LblParity;
		private System.Windows.Forms.Button BtnSend;
		private System.Windows.Forms.Label LblSendStr;
		private System.Windows.Forms.TextBox TxtSendString;
		private System.Windows.Forms.RichTextBox Terminal;
		private System.Windows.Forms.Label LblSendDecimal;
		private System.Windows.Forms.TextBox TxtSendDecimal;
		private System.Windows.Forms.Label LblSendHex;
		private System.Windows.Forms.TextBox TxtSendHex;
		private System.Windows.Forms.Label LblSendBinary;
		private System.Windows.Forms.TextBox TxtSendBinary;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel TxtStatus;
		private System.Windows.Forms.Button BtnDisconnect;
		private System.Windows.Forms.Button BtnConnect;
	}
}

