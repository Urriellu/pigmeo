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
			this.Status17 = new System.Windows.Forms.GroupBox();
			this.RadioStatus17_1 = new System.Windows.Forms.RadioButton();
			this.RadioStatus17_0 = new System.Windows.Forms.RadioButton();
			this.LblPinNo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.LblIO = new System.Windows.Forms.Label();
			this.LblIO17 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.pinoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.Status17.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.menuStrip1.Size = new System.Drawing.Size(709, 24);
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
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pinoutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
			this.helpToolStripMenuItem.Text = "NOT SET (Help)";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionStatus,
            this.StatusTxt});
			this.statusStrip1.Location = new System.Drawing.Point(0, 595);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(709, 22);
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
			// Status17
			// 
			this.Status17.Controls.Add(this.RadioStatus17_1);
			this.Status17.Controls.Add(this.RadioStatus17_0);
			this.Status17.Location = new System.Drawing.Point(187, 212);
			this.Status17.Name = "Status17";
			this.Status17.Size = new System.Drawing.Size(510, 48);
			this.Status17.TabIndex = 2;
			this.Status17.TabStop = false;
			this.Status17.Text = "Pin 17 Status";
			// 
			// RadioStatus17_1
			// 
			this.RadioStatus17_1.AutoSize = true;
			this.RadioStatus17_1.Location = new System.Drawing.Point(260, 19);
			this.RadioStatus17_1.Name = "RadioStatus17_1";
			this.RadioStatus17_1.Size = new System.Drawing.Size(87, 17);
			this.RadioStatus17_1.TabIndex = 1;
			this.RadioStatus17_1.TabStop = true;
			this.RadioStatus17_1.Text = "NOT SET (1)";
			this.RadioStatus17_1.UseVisualStyleBackColor = true;
			this.RadioStatus17_1.CheckedChanged += new System.EventHandler(this.RadioStatus17_1_CheckedChanged);
			// 
			// RadioStatus17_0
			// 
			this.RadioStatus17_0.AutoSize = true;
			this.RadioStatus17_0.Location = new System.Drawing.Point(19, 19);
			this.RadioStatus17_0.Name = "RadioStatus17_0";
			this.RadioStatus17_0.Size = new System.Drawing.Size(87, 17);
			this.RadioStatus17_0.TabIndex = 0;
			this.RadioStatus17_0.TabStop = true;
			this.RadioStatus17_0.Text = "NOT SET (0)";
			this.RadioStatus17_0.UseVisualStyleBackColor = true;
			this.RadioStatus17_0.CheckedChanged += new System.EventHandler(this.RadioStatus17_0_CheckedChanged);
			// 
			// LblPinNo
			// 
			this.LblPinNo.AutoSize = true;
			this.LblPinNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblPinNo.Location = new System.Drawing.Point(12, 186);
			this.LblPinNo.Name = "LblPinNo";
			this.LblPinNo.Size = new System.Drawing.Size(116, 17);
			this.LblPinNo.TabIndex = 3;
			this.LblPinNo.Text = "NOT SET (Pin)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 233);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "17";
			// 
			// LblIO
			// 
			this.LblIO.AutoSize = true;
			this.LblIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblIO.Location = new System.Drawing.Point(63, 186);
			this.LblIO.Name = "LblIO";
			this.LblIO.Size = new System.Drawing.Size(114, 17);
			this.LblIO.TabIndex = 4;
			this.LblIO.Text = "NOT SET (I/O)";
			// 
			// LblIO17
			// 
			this.LblIO17.AutoSize = true;
			this.LblIO17.Location = new System.Drawing.Point(84, 233);
			this.LblIO17.Name = "LblIO17";
			this.LblIO17.Size = new System.Drawing.Size(39, 13);
			this.LblIO17.TabIndex = 5;
			this.LblIO17.Text = "Output";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.LblIO);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.LblPinNo);
			this.panel1.Controls.Add(this.LblIO17);
			this.panel1.Controls.Add(this.Status17);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(709, 571);
			this.panel1.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(84, 284);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Output";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Location = new System.Drawing.Point(187, 266);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(510, 48);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pin 17 Status";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(260, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(87, 17);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "NOT SET (1)";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(19, 19);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(87, 17);
			this.radioButton2.TabIndex = 0;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "NOT SET (0)";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 284);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "17";
			// 
			// pinoutToolStripMenuItem
			// 
			this.pinoutToolStripMenuItem.Name = "pinoutToolStripMenuItem";
			this.pinoutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.pinoutToolStripMenuItem.Text = "NOT SET (Pinout)";
			this.pinoutToolStripMenuItem.Click += new System.EventHandler(this.pinoutToolStripMenuItem_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(709, 617);
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
			this.Status17.ResumeLayout(false);
			this.Status17.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
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
		private System.Windows.Forms.GroupBox Status17;
		private System.Windows.Forms.RadioButton RadioStatus17_1;
		private System.Windows.Forms.RadioButton RadioStatus17_0;
		private System.Windows.Forms.Label LblPinNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label LblIO;
		private System.Windows.Forms.Label LblIO17;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolStripMenuItem pinoutToolStripMenuItem;

	}
}

