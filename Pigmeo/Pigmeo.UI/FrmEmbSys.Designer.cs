namespace Pigmeo.UI {
	partial class FrmEmbSys {
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
			this.txtCmdOut = new System.Windows.Forms.RichTextBox();
			this.grpSystem = new System.Windows.Forms.GroupBox();
			this.ipAddressControl1 = new IPAddressControlLib.IPAddressControl();
			this.btnDeleteSystem = new System.Windows.Forms.Button();
			this.btnInstallHostApp = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.lbHdUsage = new System.Windows.Forms.Label();
			this.lblNumProcs = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblCpuUsage = new System.Windows.Forms.Label();
			this.lblSysInf = new System.Windows.Forms.Label();
			this.lblConnected = new System.Windows.Forms.Label();
			this.btnAddSystem = new System.Windows.Forms.Button();
			this.cmbSystems = new System.Windows.Forms.ComboBox();
			this.btnWhatIsThis = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.grpSystem.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtCmdOut
			// 
			this.txtCmdOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCmdOut.BackColor = System.Drawing.Color.Black;
			this.txtCmdOut.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCmdOut.ForeColor = System.Drawing.Color.White;
			this.txtCmdOut.Location = new System.Drawing.Point(259, 312);
			this.txtCmdOut.MinimumSize = new System.Drawing.Size(650, 50);
			this.txtCmdOut.Name = "txtCmdOut";
			this.txtCmdOut.ReadOnly = true;
			this.txtCmdOut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtCmdOut.Size = new System.Drawing.Size(650, 151);
			this.txtCmdOut.TabIndex = 0;
			this.txtCmdOut.Text = "(no console output)\n0123456789012345678901234567890123456789012345678901234567890" +
				"1234567890123456789\n";
			// 
			// grpSystem
			// 
			this.grpSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpSystem.Controls.Add(this.btnWhatIsThis);
			this.grpSystem.Controls.Add(this.ipAddressControl1);
			this.grpSystem.Controls.Add(this.btnDeleteSystem);
			this.grpSystem.Controls.Add(this.btnInstallHostApp);
			this.grpSystem.Controls.Add(this.label4);
			this.grpSystem.Controls.Add(this.lbHdUsage);
			this.grpSystem.Controls.Add(this.lblNumProcs);
			this.grpSystem.Controls.Add(this.label3);
			this.grpSystem.Controls.Add(this.lblCpuUsage);
			this.grpSystem.Controls.Add(this.lblSysInf);
			this.grpSystem.Controls.Add(this.lblConnected);
			this.grpSystem.Controls.Add(this.btnAddSystem);
			this.grpSystem.Controls.Add(this.cmbSystems);
			this.grpSystem.Location = new System.Drawing.Point(12, 12);
			this.grpSystem.Name = "grpSystem";
			this.grpSystem.Size = new System.Drawing.Size(897, 110);
			this.grpSystem.TabIndex = 1;
			this.grpSystem.TabStop = false;
			this.grpSystem.Text = "Embedded System (NS)";
			// 
			// ipAddressControl1
			// 
			this.ipAddressControl1.AllowInternalTab = false;
			this.ipAddressControl1.AutoHeight = true;
			this.ipAddressControl1.BackColor = System.Drawing.SystemColors.Window;
			this.ipAddressControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ipAddressControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ipAddressControl1.Location = new System.Drawing.Point(350, 16);
			this.ipAddressControl1.MinimumSize = new System.Drawing.Size(87, 20);
			this.ipAddressControl1.Name = "ipAddressControl1";
			this.ipAddressControl1.ReadOnly = false;
			this.ipAddressControl1.Size = new System.Drawing.Size(87, 20);
			this.ipAddressControl1.TabIndex = 12;
			this.ipAddressControl1.Text = "...";
			// 
			// btnDeleteSystem
			// 
			this.btnDeleteSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteSystem.ForeColor = System.Drawing.Color.Red;
			this.btnDeleteSystem.Location = new System.Drawing.Point(259, 23);
			this.btnDeleteSystem.Name = "btnDeleteSystem";
			this.btnDeleteSystem.Size = new System.Drawing.Size(43, 30);
			this.btnDeleteSystem.TabIndex = 11;
			this.btnDeleteSystem.Text = "X";
			this.btnDeleteSystem.UseVisualStyleBackColor = true;
			// 
			// btnInstallHostApp
			// 
			this.btnInstallHostApp.Location = new System.Drawing.Point(496, 11);
			this.btnInstallHostApp.Name = "btnInstallHostApp";
			this.btnInstallHostApp.Size = new System.Drawing.Size(49, 39);
			this.btnInstallHostApp.TabIndex = 10;
			this.btnInstallHostApp.Text = "Install Host";
			this.btnInstallHostApp.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(301, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(191, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Net usage: XXXKiB/s in, XXXKiB/s out";
			// 
			// lbHdUsage
			// 
			this.lbHdUsage.AutoSize = true;
			this.lbHdUsage.Location = new System.Drawing.Point(301, 64);
			this.lbHdUsage.Name = "lbHdUsage";
			this.lbHdUsage.Size = new System.Drawing.Size(244, 13);
			this.lbHdUsage.TabIndex = 8;
			this.lbHdUsage.Text = "HD usage: sda XXXMiB free (XX%) out of XXXMiB";
			// 
			// lblNumProcs
			// 
			this.lblNumProcs.AutoSize = true;
			this.lblNumProcs.Location = new System.Drawing.Point(575, 64);
			this.lblNumProcs.Name = "lblNumProcs";
			this.lblNumProcs.Size = new System.Drawing.Size(122, 13);
			this.lblNumProcs.TabIndex = 7;
			this.lblNumProcs.Text = "Running XXX processes";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(206, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "RAM: XXXMiB (XX%) used / XXXMiB total";
			// 
			// lblCpuUsage
			// 
			this.lblCpuUsage.AutoSize = true;
			this.lblCpuUsage.Location = new System.Drawing.Point(14, 64);
			this.lblCpuUsage.Name = "lblCpuUsage";
			this.lblCpuUsage.Size = new System.Drawing.Size(57, 13);
			this.lblCpuUsage.TabIndex = 5;
			this.lblCpuUsage.Text = "CPU: XX%";
			// 
			// lblSysInf
			// 
			this.lblSysInf.Location = new System.Drawing.Point(575, 16);
			this.lblSysInf.Name = "lblSysInf";
			this.lblSysInf.Size = new System.Drawing.Size(312, 37);
			this.lblSysInf.TabIndex = 4;
			this.lblSysInf.Text = "System (NS): Linux/RasPi, distro,  kernel, hostname, architecture";
			// 
			// lblConnected
			// 
			this.lblConnected.AutoSize = true;
			this.lblConnected.ForeColor = System.Drawing.Color.Red;
			this.lblConnected.Location = new System.Drawing.Point(347, 37);
			this.lblConnected.Name = "lblConnected";
			this.lblConnected.Size = new System.Drawing.Size(124, 13);
			this.lblConnected.TabIndex = 2;
			this.lblConnected.Text = "NOT CONNECTED (NS)";
			// 
			// btnAddSystem
			// 
			this.btnAddSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.btnAddSystem.Location = new System.Drawing.Point(210, 23);
			this.btnAddSystem.Name = "btnAddSystem";
			this.btnAddSystem.Size = new System.Drawing.Size(43, 30);
			this.btnAddSystem.TabIndex = 1;
			this.btnAddSystem.Text = "+";
			this.btnAddSystem.UseVisualStyleBackColor = true;
			// 
			// cmbSystems
			// 
			this.cmbSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSystems.FormattingEnabled = true;
			this.cmbSystems.Location = new System.Drawing.Point(17, 28);
			this.cmbSystems.Name = "cmbSystems";
			this.cmbSystems.Size = new System.Drawing.Size(187, 21);
			this.cmbSystems.TabIndex = 0;
			// 
			// btnWhatIsThis
			// 
			this.btnWhatIsThis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWhatIsThis.ForeColor = System.Drawing.Color.Blue;
			this.btnWhatIsThis.Location = new System.Drawing.Point(864, 76);
			this.btnWhatIsThis.Name = "btnWhatIsThis";
			this.btnWhatIsThis.Size = new System.Drawing.Size(27, 28);
			this.btnWhatIsThis.TabIndex = 13;
			this.btnWhatIsThis.Text = "?";
			this.btnWhatIsThis.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.HotTrack = true;
			this.tabControl1.Location = new System.Drawing.Point(50, 188);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(200, 156);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(192, 130);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "prj01";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(192, 130);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "projectnumber2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// FrmEmbSys
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(921, 475);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.grpSystem);
			this.Controls.Add(this.txtCmdOut);
			this.MinimumSize = new System.Drawing.Size(937, 436);
			this.Name = "FrmEmbSys";
			this.Text = "Pigmeo for Embedded Systems";
			this.Load += new System.EventHandler(this.FrmEmbSys_Load);
			this.grpSystem.ResumeLayout(false);
			this.grpSystem.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtCmdOut;
		private System.Windows.Forms.GroupBox grpSystem;
		private System.Windows.Forms.ComboBox cmbSystems;
		private System.Windows.Forms.Button btnAddSystem;
		private System.Windows.Forms.Label lblSysInf;
		private System.Windows.Forms.Label lblConnected;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbHdUsage;
		private System.Windows.Forms.Label lblNumProcs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblCpuUsage;
		private System.Windows.Forms.Button btnDeleteSystem;
		private System.Windows.Forms.Button btnInstallHostApp;
		private IPAddressControlLib.IPAddressControl ipAddressControl1;
		private System.Windows.Forms.Button btnWhatIsThis;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
	}
}