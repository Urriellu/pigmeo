namespace Pigmeo.UI {
	partial class CtrlEmbSys {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tabsApps = new System.Windows.Forms.TabControl();
			this.tabSample = new System.Windows.Forms.TabPage();
			this.ctrlEmbApp_SAMPLE = new Pigmeo.UI.CtrlEmbApp();
			this.tabNewApp = new System.Windows.Forms.TabPage();
			this.grpNewApp = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.txtNewApp = new System.Windows.Forms.TextBox();
			this.progNet = new System.Windows.Forms.ProgressBar();
			this.btnInstallHostApp = new System.Windows.Forms.Button();
			this.btnDeleteSystem = new System.Windows.Forms.Button();
			this.lblNet = new System.Windows.Forms.Label();
			this.progHd = new System.Windows.Forms.ProgressBar();
			this.lblHd = new System.Windows.Forms.Label();
			this.progRam = new System.Windows.Forms.ProgressBar();
			this.lblRam = new System.Windows.Forms.Label();
			this.progCpu = new System.Windows.Forms.ProgressBar();
			this.ip = new IPAddressControlLib.IPAddressControl();
			this.lblCpu = new System.Windows.Forms.Label();
			this.lblConnected = new System.Windows.Forms.Label();
			this.lblSysInf = new System.Windows.Forms.Label();
			this.tabsApps.SuspendLayout();
			this.tabSample.SuspendLayout();
			this.tabNewApp.SuspendLayout();
			this.grpNewApp.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabsApps
			// 
			this.tabsApps.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabsApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabsApps.Controls.Add(this.tabSample);
			this.tabsApps.Controls.Add(this.tabNewApp);
			this.tabsApps.Location = new System.Drawing.Point(8, 78);
			this.tabsApps.Multiline = true;
			this.tabsApps.Name = "tabsApps";
			this.tabsApps.SelectedIndex = 0;
			this.tabsApps.Size = new System.Drawing.Size(696, 332);
			this.tabsApps.TabIndex = 36;
			// 
			// tabSample
			// 
			this.tabSample.Controls.Add(this.ctrlEmbApp_SAMPLE);
			this.tabSample.Location = new System.Drawing.Point(23, 4);
			this.tabSample.Name = "tabSample";
			this.tabSample.Padding = new System.Windows.Forms.Padding(3);
			this.tabSample.Size = new System.Drawing.Size(669, 324);
			this.tabSample.TabIndex = 0;
			this.tabSample.Text = "SAMPLE-REMOVE";
			this.tabSample.UseVisualStyleBackColor = true;
			// 
			// ctrlEmbApp_SAMPLE
			// 
			this.ctrlEmbApp_SAMPLE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctrlEmbApp_SAMPLE.Location = new System.Drawing.Point(3, 3);
			this.ctrlEmbApp_SAMPLE.MinimumSize = new System.Drawing.Size(669, 250);
			this.ctrlEmbApp_SAMPLE.Name = "ctrlEmbApp_SAMPLE";
			this.ctrlEmbApp_SAMPLE.Size = new System.Drawing.Size(669, 318);
			this.ctrlEmbApp_SAMPLE.TabIndex = 0;
			// 
			// tabNewApp
			// 
			this.tabNewApp.Controls.Add(this.grpNewApp);
			this.tabNewApp.Location = new System.Drawing.Point(23, 4);
			this.tabNewApp.Name = "tabNewApp";
			this.tabNewApp.Padding = new System.Windows.Forms.Padding(3);
			this.tabNewApp.Size = new System.Drawing.Size(669, 324);
			this.tabNewApp.TabIndex = 2;
			this.tabNewApp.Text = "(new app) (NS)";
			this.tabNewApp.UseVisualStyleBackColor = true;
			// 
			// grpNewApp
			// 
			this.grpNewApp.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.grpNewApp.Controls.Add(this.button4);
			this.grpNewApp.Controls.Add(this.label6);
			this.grpNewApp.Controls.Add(this.label7);
			this.grpNewApp.Controls.Add(this.button3);
			this.grpNewApp.Controls.Add(this.txtNewApp);
			this.grpNewApp.Location = new System.Drawing.Point(160, 71);
			this.grpNewApp.Name = "grpNewApp";
			this.grpNewApp.Size = new System.Drawing.Size(422, 167);
			this.grpNewApp.TabIndex = 5;
			this.grpNewApp.TabStop = false;
			this.grpNewApp.Text = "(NS) Add new Custom Application";
			// 
			// button4
			// 
			this.button4.Enabled = false;
			this.button4.Location = new System.Drawing.Point(309, 83);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 53);
			this.button4.TabIndex = 4;
			this.button4.Text = "New App from Existing Code (NS)";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(21, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(374, 41);
			this.label6.TabIndex = 1;
			this.label6.Text = "(NS) This form lets you add a new Custom Application, written by yourself, which " +
				"you will be able to run on the currently selected Embedded System.";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(26, 90);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(158, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "(NS) ID of the new Custom App:";
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(228, 83);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 53);
			this.button3.TabIndex = 0;
			this.button3.Text = "Create New Custom Application (NS)";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// txtNewApp
			// 
			this.txtNewApp.Location = new System.Drawing.Point(29, 114);
			this.txtNewApp.MaxLength = 25;
			this.txtNewApp.Name = "txtNewApp";
			this.txtNewApp.Size = new System.Drawing.Size(186, 20);
			this.txtNewApp.TabIndex = 2;
			// 
			// progNet
			// 
			this.progNet.BackColor = System.Drawing.Color.Lime;
			this.progNet.ForeColor = System.Drawing.Color.Red;
			this.progNet.Location = new System.Drawing.Point(286, 52);
			this.progNet.Name = "progNet";
			this.progNet.Size = new System.Drawing.Size(168, 13);
			this.progNet.Step = 1;
			this.progNet.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progNet.TabIndex = 35;
			this.progNet.Value = 20;
			// 
			// btnInstallHostApp
			// 
			this.btnInstallHostApp.Location = new System.Drawing.Point(652, 6);
			this.btnInstallHostApp.Name = "btnInstallHostApp";
			this.btnInstallHostApp.Size = new System.Drawing.Size(34, 30);
			this.btnInstallHostApp.TabIndex = 26;
			this.btnInstallHostApp.Text = "Install Host (must ask: root pass, user to run everything)";
			this.btnInstallHostApp.UseVisualStyleBackColor = true;
			// 
			// btnDeleteSystem
			// 
			this.btnDeleteSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteSystem.ForeColor = System.Drawing.Color.Red;
			this.btnDeleteSystem.Location = new System.Drawing.Point(652, 42);
			this.btnDeleteSystem.Name = "btnDeleteSystem";
			this.btnDeleteSystem.Size = new System.Drawing.Size(34, 30);
			this.btnDeleteSystem.TabIndex = 27;
			this.btnDeleteSystem.Text = "X";
			this.btnDeleteSystem.UseVisualStyleBackColor = true;
			// 
			// lblNet
			// 
			this.lblNet.AutoSize = true;
			this.lblNet.Location = new System.Drawing.Point(253, 52);
			this.lblNet.Name = "lblNet";
			this.lblNet.Size = new System.Drawing.Size(27, 13);
			this.lblNet.TabIndex = 34;
			this.lblNet.Text = "Net:";
			// 
			// progHd
			// 
			this.progHd.BackColor = System.Drawing.Color.Lime;
			this.progHd.ForeColor = System.Drawing.Color.Red;
			this.progHd.Location = new System.Drawing.Point(286, 33);
			this.progHd.Name = "progHd";
			this.progHd.Size = new System.Drawing.Size(168, 13);
			this.progHd.Step = 1;
			this.progHd.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progHd.TabIndex = 33;
			this.progHd.Value = 20;
			// 
			// lblHd
			// 
			this.lblHd.AutoSize = true;
			this.lblHd.Location = new System.Drawing.Point(254, 33);
			this.lblHd.Name = "lblHd";
			this.lblHd.Size = new System.Drawing.Size(26, 13);
			this.lblHd.TabIndex = 32;
			this.lblHd.Text = "HD:";
			// 
			// progRam
			// 
			this.progRam.BackColor = System.Drawing.Color.Lime;
			this.progRam.ForeColor = System.Drawing.Color.Red;
			this.progRam.Location = new System.Drawing.Point(46, 52);
			this.progRam.Name = "progRam";
			this.progRam.Size = new System.Drawing.Size(168, 13);
			this.progRam.Step = 1;
			this.progRam.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progRam.TabIndex = 31;
			this.progRam.Value = 20;
			// 
			// lblRam
			// 
			this.lblRam.AutoSize = true;
			this.lblRam.Location = new System.Drawing.Point(6, 52);
			this.lblRam.Name = "lblRam";
			this.lblRam.Size = new System.Drawing.Size(34, 13);
			this.lblRam.TabIndex = 30;
			this.lblRam.Text = "RAM:";
			// 
			// progCpu
			// 
			this.progCpu.BackColor = System.Drawing.Color.Lime;
			this.progCpu.ForeColor = System.Drawing.Color.Red;
			this.progCpu.Location = new System.Drawing.Point(46, 33);
			this.progCpu.Name = "progCpu";
			this.progCpu.Size = new System.Drawing.Size(168, 13);
			this.progCpu.Step = 1;
			this.progCpu.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progCpu.TabIndex = 29;
			this.progCpu.Value = 20;
			// 
			// ip
			// 
			this.ip.AllowInternalTab = false;
			this.ip.AutoHeight = true;
			this.ip.BackColor = System.Drawing.SystemColors.Window;
			this.ip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ip.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ip.Location = new System.Drawing.Point(501, 23);
			this.ip.MinimumSize = new System.Drawing.Size(87, 20);
			this.ip.Name = "ip";
			this.ip.ReadOnly = false;
			this.ip.Size = new System.Drawing.Size(87, 20);
			this.ip.TabIndex = 28;
			this.ip.Text = "...";
			// 
			// lblCpu
			// 
			this.lblCpu.AutoSize = true;
			this.lblCpu.Location = new System.Drawing.Point(8, 33);
			this.lblCpu.Name = "lblCpu";
			this.lblCpu.Size = new System.Drawing.Size(32, 13);
			this.lblCpu.TabIndex = 25;
			this.lblCpu.Text = "CPU:";
			// 
			// lblConnected
			// 
			this.lblConnected.ForeColor = System.Drawing.Color.Red;
			this.lblConnected.Location = new System.Drawing.Point(473, 54);
			this.lblConnected.Name = "lblConnected";
			this.lblConnected.Size = new System.Drawing.Size(140, 13);
			this.lblConnected.TabIndex = 23;
			this.lblConnected.Text = "NOT CONNECTED (NS)";
			this.lblConnected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSysInf
			// 
			this.lblSysInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSysInf.Location = new System.Drawing.Point(8, 9);
			this.lblSysInf.Name = "lblSysInf";
			this.lblSysInf.Size = new System.Drawing.Size(446, 20);
			this.lblSysInf.TabIndex = 24;
			this.lblSysInf.Text = "System (NS): Linux/RasPi, distro,  kernel, hostname, architecture";
			// 
			// CtrlEmbSys
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabsApps);
			this.Controls.Add(this.progNet);
			this.Controls.Add(this.btnInstallHostApp);
			this.Controls.Add(this.btnDeleteSystem);
			this.Controls.Add(this.lblNet);
			this.Controls.Add(this.progHd);
			this.Controls.Add(this.lblHd);
			this.Controls.Add(this.progRam);
			this.Controls.Add(this.lblRam);
			this.Controls.Add(this.progCpu);
			this.Controls.Add(this.ip);
			this.Controls.Add(this.lblCpu);
			this.Controls.Add(this.lblConnected);
			this.Controls.Add(this.lblSysInf);
			this.MinimumSize = new System.Drawing.Size(710, 416);
			this.Name = "CtrlEmbSys";
			this.Size = new System.Drawing.Size(710, 416);
			this.Load += new System.EventHandler(this.CtrlEmbSys_Load);
			this.tabsApps.ResumeLayout(false);
			this.tabSample.ResumeLayout(false);
			this.tabNewApp.ResumeLayout(false);
			this.grpNewApp.ResumeLayout(false);
			this.grpNewApp.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabsApps;
		private System.Windows.Forms.TabPage tabSample;
		private System.Windows.Forms.TabPage tabNewApp;
		private System.Windows.Forms.GroupBox grpNewApp;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox txtNewApp;
		private System.Windows.Forms.ProgressBar progNet;
		private System.Windows.Forms.Button btnInstallHostApp;
		private System.Windows.Forms.Button btnDeleteSystem;
		private System.Windows.Forms.Label lblNet;
		private System.Windows.Forms.ProgressBar progHd;
		private System.Windows.Forms.Label lblHd;
		private System.Windows.Forms.ProgressBar progRam;
		private System.Windows.Forms.Label lblRam;
		private System.Windows.Forms.ProgressBar progCpu;
		private IPAddressControlLib.IPAddressControl ip;
		private System.Windows.Forms.Label lblCpu;
		private System.Windows.Forms.Label lblConnected;
		private System.Windows.Forms.Label lblSysInf;
		private CtrlEmbApp ctrlEmbApp_SAMPLE;
	}
}
