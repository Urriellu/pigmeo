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
			this.tabApps = new System.Windows.Forms.TabControl();
			this.tabSample = new System.Windows.Forms.TabPage();
			this.ctrlEmbApp_SAMPLE = new Pigmeo.UI.CtrlEmbApp();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.grpNewApp = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.txtNewApp = new System.Windows.Forms.TextBox();
			this.progressBar3 = new System.Windows.Forms.ProgressBar();
			this.btnInstallHostApp = new System.Windows.Forms.Button();
			this.btnDeleteSystem = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.progressBar4 = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.progressBar2 = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.ipAddressControl1 = new IPAddressControlLib.IPAddressControl();
			this.lblCpuUsage = new System.Windows.Forms.Label();
			this.lblConnected = new System.Windows.Forms.Label();
			this.lblSysInf = new System.Windows.Forms.Label();
			this.tabApps.SuspendLayout();
			this.tabSample.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.grpNewApp.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabApps
			// 
			this.tabApps.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabApps.Controls.Add(this.tabSample);
			this.tabApps.Controls.Add(this.tabPage6);
			this.tabApps.Location = new System.Drawing.Point(8, 78);
			this.tabApps.Multiline = true;
			this.tabApps.Name = "tabApps";
			this.tabApps.SelectedIndex = 0;
			this.tabApps.Size = new System.Drawing.Size(696, 332);
			this.tabApps.TabIndex = 36;
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
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.grpNewApp);
			this.tabPage6.Location = new System.Drawing.Point(23, 4);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(669, 324);
			this.tabPage6.TabIndex = 2;
			this.tabPage6.Text = "(new app) (NS)";
			this.tabPage6.UseVisualStyleBackColor = true;
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
			// progressBar3
			// 
			this.progressBar3.BackColor = System.Drawing.Color.Lime;
			this.progressBar3.ForeColor = System.Drawing.Color.Red;
			this.progressBar3.Location = new System.Drawing.Point(286, 52);
			this.progressBar3.Name = "progressBar3";
			this.progressBar3.Size = new System.Drawing.Size(168, 13);
			this.progressBar3.Step = 1;
			this.progressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar3.TabIndex = 35;
			this.progressBar3.Value = 20;
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(253, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 13);
			this.label2.TabIndex = 34;
			this.label2.Text = "Net:";
			// 
			// progressBar4
			// 
			this.progressBar4.BackColor = System.Drawing.Color.Lime;
			this.progressBar4.ForeColor = System.Drawing.Color.Red;
			this.progressBar4.Location = new System.Drawing.Point(286, 33);
			this.progressBar4.Name = "progressBar4";
			this.progressBar4.Size = new System.Drawing.Size(168, 13);
			this.progressBar4.Step = 1;
			this.progressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar4.TabIndex = 33;
			this.progressBar4.Value = 20;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(254, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 13);
			this.label3.TabIndex = 32;
			this.label3.Text = "HD:";
			// 
			// progressBar2
			// 
			this.progressBar2.BackColor = System.Drawing.Color.Lime;
			this.progressBar2.ForeColor = System.Drawing.Color.Red;
			this.progressBar2.Location = new System.Drawing.Point(46, 52);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(168, 13);
			this.progressBar2.Step = 1;
			this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar2.TabIndex = 31;
			this.progressBar2.Value = 20;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 30;
			this.label1.Text = "RAM:";
			// 
			// progressBar1
			// 
			this.progressBar1.BackColor = System.Drawing.Color.Lime;
			this.progressBar1.ForeColor = System.Drawing.Color.Red;
			this.progressBar1.Location = new System.Drawing.Point(46, 33);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(168, 13);
			this.progressBar1.Step = 1;
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 29;
			this.progressBar1.Value = 20;
			// 
			// ipAddressControl1
			// 
			this.ipAddressControl1.AllowInternalTab = false;
			this.ipAddressControl1.AutoHeight = true;
			this.ipAddressControl1.BackColor = System.Drawing.SystemColors.Window;
			this.ipAddressControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ipAddressControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ipAddressControl1.Location = new System.Drawing.Point(501, 23);
			this.ipAddressControl1.MinimumSize = new System.Drawing.Size(87, 20);
			this.ipAddressControl1.Name = "ipAddressControl1";
			this.ipAddressControl1.ReadOnly = false;
			this.ipAddressControl1.Size = new System.Drawing.Size(87, 20);
			this.ipAddressControl1.TabIndex = 28;
			this.ipAddressControl1.Text = "...";
			// 
			// lblCpuUsage
			// 
			this.lblCpuUsage.AutoSize = true;
			this.lblCpuUsage.Location = new System.Drawing.Point(8, 33);
			this.lblCpuUsage.Name = "lblCpuUsage";
			this.lblCpuUsage.Size = new System.Drawing.Size(32, 13);
			this.lblCpuUsage.TabIndex = 25;
			this.lblCpuUsage.Text = "CPU:";
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
			this.Controls.Add(this.tabApps);
			this.Controls.Add(this.progressBar3);
			this.Controls.Add(this.btnInstallHostApp);
			this.Controls.Add(this.btnDeleteSystem);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.progressBar4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.progressBar2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.ipAddressControl1);
			this.Controls.Add(this.lblCpuUsage);
			this.Controls.Add(this.lblConnected);
			this.Controls.Add(this.lblSysInf);
			this.MinimumSize = new System.Drawing.Size(710, 416);
			this.Name = "CtrlEmbSys";
			this.Size = new System.Drawing.Size(710, 416);
			this.Load += new System.EventHandler(this.CtrlEmbSys_Load);
			this.tabApps.ResumeLayout(false);
			this.tabSample.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.grpNewApp.ResumeLayout(false);
			this.grpNewApp.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabApps;
		private System.Windows.Forms.TabPage tabSample;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.GroupBox grpNewApp;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox txtNewApp;
		private System.Windows.Forms.ProgressBar progressBar3;
		private System.Windows.Forms.Button btnInstallHostApp;
		private System.Windows.Forms.Button btnDeleteSystem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar progressBar4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBar2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private IPAddressControlLib.IPAddressControl ipAddressControl1;
		private System.Windows.Forms.Label lblCpuUsage;
		private System.Windows.Forms.Label lblConnected;
		private System.Windows.Forms.Label lblSysInf;
		private CtrlEmbApp ctrlEmbApp_SAMPLE;
	}
}
