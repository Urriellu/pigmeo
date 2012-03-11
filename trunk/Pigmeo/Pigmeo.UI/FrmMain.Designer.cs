namespace Pigmeo.UI {
	partial class FrmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnParallelPort = new System.Windows.Forms.Button();
			this.btnSerialPort = new System.Windows.Forms.Button();
			this.btnEmbSys = new System.Windows.Forms.Button();
			this.btnArduino = new System.Windows.Forms.Button();
			this.btnCompiler = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.embeddedSystemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runLocalHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pigmeoWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.btnParallelPort);
			this.panel1.Controls.Add(this.btnSerialPort);
			this.panel1.Controls.Add(this.btnEmbSys);
			this.panel1.Controls.Add(this.btnArduino);
			this.panel1.Controls.Add(this.btnCompiler);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(71, 543);
			this.panel1.TabIndex = 1;
			// 
			// btnParallelPort
			// 
			this.btnParallelPort.Enabled = false;
			this.btnParallelPort.Location = new System.Drawing.Point(3, 216);
			this.btnParallelPort.Name = "btnParallelPort";
			this.btnParallelPort.Size = new System.Drawing.Size(65, 65);
			this.btnParallelPort.TabIndex = 4;
			this.btnParallelPort.Text = "Parallel Port";
			this.btnParallelPort.UseVisualStyleBackColor = true;
			// 
			// btnSerialPort
			// 
			this.btnSerialPort.Enabled = false;
			this.btnSerialPort.Location = new System.Drawing.Point(3, 145);
			this.btnSerialPort.Name = "btnSerialPort";
			this.btnSerialPort.Size = new System.Drawing.Size(65, 65);
			this.btnSerialPort.TabIndex = 3;
			this.btnSerialPort.Text = "Serial Port";
			this.btnSerialPort.UseVisualStyleBackColor = true;
			// 
			// btnEmbSys
			// 
			this.btnEmbSys.Location = new System.Drawing.Point(3, 74);
			this.btnEmbSys.Name = "btnEmbSys";
			this.btnEmbSys.Size = new System.Drawing.Size(65, 65);
			this.btnEmbSys.TabIndex = 2;
			this.btnEmbSys.Text = "RasPi / Embedded";
			this.btnEmbSys.UseVisualStyleBackColor = true;
			this.btnEmbSys.Click += new System.EventHandler(this.btnEmbSys_Click);
			// 
			// btnArduino
			// 
			this.btnArduino.Enabled = false;
			this.btnArduino.Location = new System.Drawing.Point(3, 3);
			this.btnArduino.Name = "btnArduino";
			this.btnArduino.Size = new System.Drawing.Size(65, 65);
			this.btnArduino.TabIndex = 1;
			this.btnArduino.Text = "Arduino";
			this.btnArduino.UseVisualStyleBackColor = true;
			// 
			// btnCompiler
			// 
			this.btnCompiler.Enabled = false;
			this.btnCompiler.Location = new System.Drawing.Point(3, 287);
			this.btnCompiler.Name = "btnCompiler";
			this.btnCompiler.Size = new System.Drawing.Size(65, 65);
			this.btnCompiler.TabIndex = 0;
			this.btnCompiler.Text = "Compiler";
			this.btnCompiler.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.embeddedSystemsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(828, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.fileToolStripMenuItem.Text = "File (NS)";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "Exit (NS)";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// embeddedSystemsToolStripMenuItem
			// 
			this.embeddedSystemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runLocalHostToolStripMenuItem});
			this.embeddedSystemsToolStripMenuItem.Enabled = false;
			this.embeddedSystemsToolStripMenuItem.Name = "embeddedSystemsToolStripMenuItem";
			this.embeddedSystemsToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
			this.embeddedSystemsToolStripMenuItem.Text = "Embedded Systems (NS)";
			// 
			// runLocalHostToolStripMenuItem
			// 
			this.runLocalHostToolStripMenuItem.Name = "runLocalHostToolStripMenuItem";
			this.runLocalHostToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.runLocalHostToolStripMenuItem.Text = "Run Local Host... (NS)";
			this.runLocalHostToolStripMenuItem.Click += new System.EventHandler(this.runLocalHostToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pigmeoWebsiteToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
			this.helpToolStripMenuItem.Text = "Help (NS)";
			// 
			// pigmeoWebsiteToolStripMenuItem
			// 
			this.pigmeoWebsiteToolStripMenuItem.Name = "pigmeoWebsiteToolStripMenuItem";
			this.pigmeoWebsiteToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.pigmeoWebsiteToolStripMenuItem.Text = "Pigmeo Website (NS)";
			this.pigmeoWebsiteToolStripMenuItem.Click += new System.EventHandler(this.pigmeoWebsiteToolStripMenuItem_Click);
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.españolToolStripMenuItem});
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			this.languageToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.languageToolStripMenuItem.Text = "Language (NS)";
			// 
			// englishToolStripMenuItem
			// 
			this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
			this.englishToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.englishToolStripMenuItem.Text = "English";
			// 
			// españolToolStripMenuItem
			// 
			this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
			this.españolToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.españolToolStripMenuItem.Text = "Español";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Enabled = false;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.aboutToolStripMenuItem.Text = "About... (NS)";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 567);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.Text = "Pigmeo";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.panel1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCompiler;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pigmeoWebsiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Button btnParallelPort;
		private System.Windows.Forms.Button btnSerialPort;
		private System.Windows.Forms.Button btnEmbSys;
		private System.Windows.Forms.Button btnArduino;
		private System.Windows.Forms.ToolStripMenuItem embeddedSystemsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runLocalHostToolStripMenuItem;


	}
}

