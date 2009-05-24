namespace Pigmeo.PLPTC {
	partial class MainWindow {
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.parallelPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusTxt = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.RadioDataInputs = new System.Windows.Forms.RadioButton();
			this.RadioDataOutputs = new System.Windows.Forms.RadioButton();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.LblDataBinary = new System.Windows.Forms.Label();
			this.LblDataHex = new System.Windows.Forms.Label();
			this.TxtDataBin = new System.Windows.Forms.MaskedTextBox();
			this.TxtDataHex = new System.Windows.Forms.MaskedTextBox();
			this.LblDataChar = new System.Windows.Forms.Label();
			this.TxtDataChar = new System.Windows.Forms.MaskedTextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.LblMs = new System.Windows.Forms.Label();
			this.ChkTimerOn = new System.Windows.Forms.CheckBox();
			this.NumTimerValue = new System.Windows.Forms.NumericUpDown();
			this.LblPin15 = new System.Windows.Forms.Label();
			this.LblPin10 = new System.Windows.Forms.Label();
			this.LblPin11 = new System.Windows.Forms.Label();
			this.LblPin12 = new System.Windows.Forms.Label();
			this.LblPin13 = new System.Windows.Forms.Label();
			this.NumData7 = new System.Windows.Forms.NumericUpDown();
			this.NumData6 = new System.Windows.Forms.NumericUpDown();
			this.NumData5 = new System.Windows.Forms.NumericUpDown();
			this.NumData4 = new System.Windows.Forms.NumericUpDown();
			this.NumData3 = new System.Windows.Forms.NumericUpDown();
			this.NumData2 = new System.Windows.Forms.NumericUpDown();
			this.NumData1 = new System.Windows.Forms.NumericUpDown();
			this.NumData0 = new System.Windows.Forms.NumericUpDown();
			this.NumPin1 = new System.Windows.Forms.NumericUpDown();
			this.NumPin14 = new System.Windows.Forms.NumericUpDown();
			this.NumPin16 = new System.Windows.Forms.NumericUpDown();
			this.LblGround = new System.Windows.Forms.Label();
			this.NumPin17 = new System.Windows.Forms.NumericUpDown();
			this.ImagePinout = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumTimerValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData0)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumPin1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumPin14)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumPin16)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumPin17)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ImagePinout)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.parallelPortToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(768, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
			this.fileToolStripMenuItem.Text = "NOT SET (File)";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.exitToolStripMenuItem.Text = "NOT SET (Exit)";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// parallelPortToolStripMenuItem
			// 
			this.parallelPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
			this.parallelPortToolStripMenuItem.Name = "parallelPortToolStripMenuItem";
			this.parallelPortToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
			this.parallelPortToolStripMenuItem.Text = "NOT SET (Parallel Port)";
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.connectToolStripMenuItem.Text = "NOT SET (Connect)";
			this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// disconnectToolStripMenuItem
			// 
			this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
			this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.disconnectToolStripMenuItem.Text = "NOT SET (Disconnect)";
			this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
			this.helpToolStripMenuItem.Text = "NOT SET (Help)";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionStatus,
            this.StatusTxt});
			this.statusStrip1.Location = new System.Drawing.Point(0, 531);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(768, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ConnectionStatus
			// 
			this.ConnectionStatus.Name = "ConnectionStatus";
			this.ConnectionStatus.Size = new System.Drawing.Size(148, 17);
			this.ConnectionStatus.Text = "NOT SET (Connection Status)";
			// 
			// StatusTxt
			// 
			this.StatusTxt.Name = "StatusTxt";
			this.StatusTxt.Size = new System.Drawing.Size(91, 17);
			this.StatusTxt.Text = "NOT SET (Status)";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.RadioDataInputs);
			this.panel1.Controls.Add(this.RadioDataOutputs);
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.LblDataBinary);
			this.panel1.Controls.Add(this.LblDataHex);
			this.panel1.Controls.Add(this.TxtDataBin);
			this.panel1.Controls.Add(this.TxtDataHex);
			this.panel1.Controls.Add(this.LblDataChar);
			this.panel1.Controls.Add(this.TxtDataChar);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.LblMs);
			this.panel1.Controls.Add(this.ChkTimerOn);
			this.panel1.Controls.Add(this.NumTimerValue);
			this.panel1.Controls.Add(this.LblPin15);
			this.panel1.Controls.Add(this.LblPin10);
			this.panel1.Controls.Add(this.LblPin11);
			this.panel1.Controls.Add(this.LblPin12);
			this.panel1.Controls.Add(this.LblPin13);
			this.panel1.Controls.Add(this.NumData7);
			this.panel1.Controls.Add(this.NumData6);
			this.panel1.Controls.Add(this.NumData5);
			this.panel1.Controls.Add(this.NumData4);
			this.panel1.Controls.Add(this.NumData3);
			this.panel1.Controls.Add(this.NumData2);
			this.panel1.Controls.Add(this.NumData1);
			this.panel1.Controls.Add(this.NumData0);
			this.panel1.Controls.Add(this.NumPin1);
			this.panel1.Controls.Add(this.NumPin14);
			this.panel1.Controls.Add(this.NumPin16);
			this.panel1.Controls.Add(this.LblGround);
			this.panel1.Controls.Add(this.NumPin17);
			this.panel1.Controls.Add(this.ImagePinout);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(768, 507);
			this.panel1.TabIndex = 6;
			// 
			// RadioDataInputs
			// 
			this.RadioDataInputs.AutoSize = true;
			this.RadioDataInputs.Location = new System.Drawing.Point(509, 72);
			this.RadioDataInputs.Name = "RadioDataInputs";
			this.RadioDataInputs.Size = new System.Drawing.Size(110, 17);
			this.RadioDataInputs.TabIndex = 45;
			this.RadioDataInputs.TabStop = true;
			this.RadioDataInputs.Text = "NOT SET (Inputs)";
			this.RadioDataInputs.UseVisualStyleBackColor = true;
			this.RadioDataInputs.CheckedChanged += new System.EventHandler(this.DataIoChanged);
			// 
			// RadioDataOutputs
			// 
			this.RadioDataOutputs.AutoSize = true;
			this.RadioDataOutputs.Location = new System.Drawing.Point(509, 46);
			this.RadioDataOutputs.Name = "RadioDataOutputs";
			this.RadioDataOutputs.Size = new System.Drawing.Size(118, 17);
			this.RadioDataOutputs.TabIndex = 44;
			this.RadioDataOutputs.TabStop = true;
			this.RadioDataOutputs.Text = "NOT SET (Outputs)";
			this.RadioDataOutputs.UseVisualStyleBackColor = true;
			this.RadioDataOutputs.CheckedChanged += new System.EventHandler(this.DataIoChanged);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pictureBox2.Location = new System.Drawing.Point(245, 15);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 138);
			this.pictureBox2.TabIndex = 43;
			this.pictureBox2.TabStop = false;
			// 
			// LblDataBinary
			// 
			this.LblDataBinary.AutoSize = true;
			this.LblDataBinary.Location = new System.Drawing.Point(295, 71);
			this.LblDataBinary.Name = "LblDataBinary";
			this.LblDataBinary.Size = new System.Drawing.Size(92, 13);
			this.LblDataBinary.TabIndex = 42;
			this.LblDataBinary.Text = "NOT SET (Binary)";
			// 
			// LblDataHex
			// 
			this.LblDataHex.AutoSize = true;
			this.LblDataHex.Location = new System.Drawing.Point(263, 45);
			this.LblDataHex.Name = "LblDataHex";
			this.LblDataHex.Size = new System.Drawing.Size(124, 13);
			this.LblDataHex.TabIndex = 41;
			this.LblDataHex.Text = "NOT SET (Hexadecimal)";
			// 
			// TxtDataBin
			// 
			this.TxtDataBin.Location = new System.Drawing.Point(393, 68);
			this.TxtDataBin.Mask = "00000000";
			this.TxtDataBin.Name = "TxtDataBin";
			this.TxtDataBin.Size = new System.Drawing.Size(56, 20);
			this.TxtDataBin.TabIndex = 40;
			this.TxtDataBin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxtDataBin.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TxtDataBin_MaskInputRejected);
			// 
			// TxtDataHex
			// 
			this.TxtDataHex.Location = new System.Drawing.Point(393, 42);
			this.TxtDataHex.Mask = "\\0x>AA";
			this.TxtDataHex.Name = "TxtDataHex";
			this.TxtDataHex.Size = new System.Drawing.Size(56, 20);
			this.TxtDataHex.TabIndex = 39;
			this.TxtDataHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxtDataHex.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TxtDataHex_MaskInputRejected);
			// 
			// LblDataChar
			// 
			this.LblDataChar.AutoSize = true;
			this.LblDataChar.Location = new System.Drawing.Point(246, 18);
			this.LblDataChar.Name = "LblDataChar";
			this.LblDataChar.Size = new System.Drawing.Size(141, 13);
			this.LblDataChar.TabIndex = 38;
			this.LblDataChar.Text = "NOT SET (UTF-8 character)";
			// 
			// TxtDataChar
			// 
			this.TxtDataChar.Culture = new System.Globalization.CultureInfo("en-US");
			this.TxtDataChar.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.TxtDataChar.Location = new System.Drawing.Point(393, 15);
			this.TxtDataChar.Mask = "\'a\'";
			this.TxtDataChar.Name = "TxtDataChar";
			this.TxtDataChar.ResetOnSpace = false;
			this.TxtDataChar.Size = new System.Drawing.Size(56, 20);
			this.TxtDataChar.TabIndex = 37;
			this.TxtDataChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxtDataChar.TextChanged += new System.EventHandler(this.TxtDataChar_TextChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pictureBox1.Location = new System.Drawing.Point(649, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(5, 138);
			this.pictureBox1.TabIndex = 36;
			this.pictureBox1.TabStop = false;
			// 
			// LblMs
			// 
			this.LblMs.AutoSize = true;
			this.LblMs.Location = new System.Drawing.Point(116, 472);
			this.LblMs.Name = "LblMs";
			this.LblMs.Size = new System.Drawing.Size(20, 13);
			this.LblMs.TabIndex = 35;
			this.LblMs.Text = "ms";
			// 
			// ChkTimerOn
			// 
			this.ChkTimerOn.AutoSize = true;
			this.ChkTimerOn.Location = new System.Drawing.Point(12, 447);
			this.ChkTimerOn.Name = "ChkTimerOn";
			this.ChkTimerOn.Size = new System.Drawing.Size(122, 17);
			this.ChkTimerOn.TabIndex = 34;
			this.ChkTimerOn.Text = "NOT SET (TimerOn)";
			this.ChkTimerOn.UseVisualStyleBackColor = true;
			this.ChkTimerOn.CheckedChanged += new System.EventHandler(this.ChkTimerOn_CheckedChanged);
			// 
			// NumTimerValue
			// 
			this.NumTimerValue.Location = new System.Drawing.Point(12, 470);
			this.NumTimerValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.NumTimerValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.NumTimerValue.Name = "NumTimerValue";
			this.NumTimerValue.Size = new System.Drawing.Size(98, 20);
			this.NumTimerValue.TabIndex = 33;
			this.NumTimerValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.NumTimerValue.ValueChanged += new System.EventHandler(this.NumTimerValue_ValueChanged);
			// 
			// LblPin15
			// 
			this.LblPin15.AutoSize = true;
			this.LblPin15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblPin15.Location = new System.Drawing.Point(590, 366);
			this.LblPin15.Name = "LblPin15";
			this.LblPin15.Size = new System.Drawing.Size(14, 13);
			this.LblPin15.TabIndex = 32;
			this.LblPin15.Text = "0";
			// 
			// LblPin10
			// 
			this.LblPin10.AutoSize = true;
			this.LblPin10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblPin10.Location = new System.Drawing.Point(218, 116);
			this.LblPin10.Name = "LblPin10";
			this.LblPin10.Size = new System.Drawing.Size(14, 13);
			this.LblPin10.TabIndex = 31;
			this.LblPin10.Text = "0";
			// 
			// LblPin11
			// 
			this.LblPin11.AutoSize = true;
			this.LblPin11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblPin11.Location = new System.Drawing.Point(166, 116);
			this.LblPin11.Name = "LblPin11";
			this.LblPin11.Size = new System.Drawing.Size(14, 13);
			this.LblPin11.TabIndex = 30;
			this.LblPin11.Text = "0";
			// 
			// LblPin12
			// 
			this.LblPin12.AutoSize = true;
			this.LblPin12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblPin12.Location = new System.Drawing.Point(118, 116);
			this.LblPin12.Name = "LblPin12";
			this.LblPin12.Size = new System.Drawing.Size(14, 13);
			this.LblPin12.TabIndex = 29;
			this.LblPin12.Text = "0";
			// 
			// LblPin13
			// 
			this.LblPin13.AutoSize = true;
			this.LblPin13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblPin13.Location = new System.Drawing.Point(69, 116);
			this.LblPin13.Name = "LblPin13";
			this.LblPin13.Size = new System.Drawing.Size(14, 13);
			this.LblPin13.TabIndex = 28;
			this.LblPin13.Text = "0";
			// 
			// NumData7
			// 
			this.NumData7.Location = new System.Drawing.Point(256, 114);
			this.NumData7.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumData7.Name = "NumData7";
			this.NumData7.Size = new System.Drawing.Size(40, 20);
			this.NumData7.TabIndex = 27;
			this.NumData7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumData7.Leave += new System.EventHandler(this.DataBitChanged);
			// 
			// NumData6
			// 
			this.NumData6.Location = new System.Drawing.Point(306, 114);
			this.NumData6.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumData6.Name = "NumData6";
			this.NumData6.Size = new System.Drawing.Size(40, 20);
			this.NumData6.TabIndex = 26;
			this.NumData6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumData6.Leave += new System.EventHandler(this.DataBitChanged);
			// 
			// NumData5
			// 
			this.NumData5.Location = new System.Drawing.Point(356, 114);
			this.NumData5.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumData5.Name = "NumData5";
			this.NumData5.Size = new System.Drawing.Size(40, 20);
			this.NumData5.TabIndex = 25;
			this.NumData5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumData5.Leave += new System.EventHandler(this.DataBitChanged);
			// 
			// NumData4
			// 
			this.NumData4.Location = new System.Drawing.Point(409, 114);
			this.NumData4.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumData4.Name = "NumData4";
			this.NumData4.Size = new System.Drawing.Size(40, 20);
			this.NumData4.TabIndex = 24;
			this.NumData4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumData4.Leave += new System.EventHandler(this.DataBitChanged);
			// 
			// NumData3
			// 
			this.NumData3.Location = new System.Drawing.Point(460, 114);
			this.NumData3.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumData3.Name = "NumData3";
			this.NumData3.Size = new System.Drawing.Size(40, 20);
			this.NumData3.TabIndex = 23;
			this.NumData3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumData3.Leave += new System.EventHandler(this.DataBitChanged);
			// 
			// NumData2
			// 
			this.NumData2.Location = new System.Drawing.Point(509, 114);
			this.NumData2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumData2.Name = "NumData2";
			this.NumData2.Size = new System.Drawing.Size(40, 20);
			this.NumData2.TabIndex = 22;
			this.NumData2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumData2.Leave += new System.EventHandler(this.DataBitChanged);
			// 
			// NumData1
			// 
			this.NumData1.Location = new System.Drawing.Point(558, 114);
			this.NumData1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumData1.Name = "NumData1";
			this.NumData1.Size = new System.Drawing.Size(40, 20);
			this.NumData1.TabIndex = 21;
			this.NumData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumData1.Leave += new System.EventHandler(this.DataBitChanged);
			// 
			// NumData0
			// 
			this.NumData0.Location = new System.Drawing.Point(606, 114);
			this.NumData0.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumData0.Name = "NumData0";
			this.NumData0.Size = new System.Drawing.Size(40, 20);
			this.NumData0.TabIndex = 20;
			this.NumData0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumData0.Leave += new System.EventHandler(this.DataBitChanged);
			// 
			// NumPin1
			// 
			this.NumPin1.Location = new System.Drawing.Point(657, 114);
			this.NumPin1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumPin1.Name = "NumPin1";
			this.NumPin1.Size = new System.Drawing.Size(40, 20);
			this.NumPin1.TabIndex = 19;
			this.NumPin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumPin1.ValueChanged += new System.EventHandler(this.NumPin1_ValueChanged);
			// 
			// NumPin14
			// 
			this.NumPin14.Location = new System.Drawing.Point(632, 364);
			this.NumPin14.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumPin14.Name = "NumPin14";
			this.NumPin14.Size = new System.Drawing.Size(40, 20);
			this.NumPin14.TabIndex = 18;
			this.NumPin14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumPin14.ValueChanged += new System.EventHandler(this.NumPin14_ValueChanged);
			// 
			// NumPin16
			// 
			this.NumPin16.Location = new System.Drawing.Point(530, 364);
			this.NumPin16.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumPin16.Name = "NumPin16";
			this.NumPin16.Size = new System.Drawing.Size(40, 20);
			this.NumPin16.TabIndex = 17;
			this.NumPin16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumPin16.ValueChanged += new System.EventHandler(this.NumPin16_ValueChanged);
			// 
			// LblGround
			// 
			this.LblGround.AutoSize = true;
			this.LblGround.Location = new System.Drawing.Point(252, 402);
			this.LblGround.Name = "LblGround";
			this.LblGround.Size = new System.Drawing.Size(98, 13);
			this.LblGround.TabIndex = 16;
			this.LblGround.Text = "NOT SET (Ground)";
			this.LblGround.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NumPin17
			// 
			this.NumPin17.Location = new System.Drawing.Point(482, 364);
			this.NumPin17.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumPin17.Name = "NumPin17";
			this.NumPin17.Size = new System.Drawing.Size(40, 20);
			this.NumPin17.TabIndex = 15;
			this.NumPin17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumPin17.ValueChanged += new System.EventHandler(this.NumPin17_ValueChanged);
			// 
			// ImagePinout
			// 
			this.ImagePinout.BackColor = System.Drawing.SystemColors.Control;
			this.ImagePinout.InitialImage = null;
			this.ImagePinout.Location = new System.Drawing.Point(12, 124);
			this.ImagePinout.Name = "ImagePinout";
			this.ImagePinout.Size = new System.Drawing.Size(742, 275);
			this.ImagePinout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ImagePinout.TabIndex = 14;
			this.ImagePinout.TabStop = false;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 553);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.Text = "NOT SET (Pigmeo LPT Controller)";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumTimerValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumData0)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumPin1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumPin14)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumPin16)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumPin17)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ImagePinout)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel StatusTxt;
		private System.Windows.Forms.ToolStripStatusLabel ConnectionStatus;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem parallelPortToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox ImagePinout;
		private System.Windows.Forms.NumericUpDown NumPin17;
		private System.Windows.Forms.Label LblGround;
		private System.Windows.Forms.NumericUpDown NumPin1;
		private System.Windows.Forms.NumericUpDown NumPin14;
		private System.Windows.Forms.NumericUpDown NumPin16;
		private System.Windows.Forms.NumericUpDown NumData7;
		private System.Windows.Forms.NumericUpDown NumData6;
		private System.Windows.Forms.NumericUpDown NumData5;
		private System.Windows.Forms.NumericUpDown NumData4;
		private System.Windows.Forms.NumericUpDown NumData3;
		private System.Windows.Forms.NumericUpDown NumData2;
		private System.Windows.Forms.NumericUpDown NumData1;
		private System.Windows.Forms.NumericUpDown NumData0;
		private System.Windows.Forms.Label LblPin13;
		private System.Windows.Forms.Label LblPin12;
		private System.Windows.Forms.Label LblPin15;
		private System.Windows.Forms.Label LblPin10;
		private System.Windows.Forms.Label LblPin11;
		private System.Windows.Forms.CheckBox ChkTimerOn;
		private System.Windows.Forms.NumericUpDown NumTimerValue;
		private System.Windows.Forms.Label LblMs;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MaskedTextBox TxtDataChar;
		private System.Windows.Forms.MaskedTextBox TxtDataHex;
		private System.Windows.Forms.Label LblDataChar;
		private System.Windows.Forms.MaskedTextBox TxtDataBin;
		private System.Windows.Forms.Label LblDataHex;
		private System.Windows.Forms.Label LblDataBinary;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.RadioButton RadioDataInputs;
		private System.Windows.Forms.RadioButton RadioDataOutputs;

	}
}

