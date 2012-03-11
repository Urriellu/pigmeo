namespace Pigmeo.UI {
	partial class FrmEmbdSys {
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
			this.btnWhatIsThis = new System.Windows.Forms.Button();
			this.tabsEmbSys = new System.Windows.Forms.TabControl();
			this.tabSampleSys = new System.Windows.Forms.TabPage();
			this.ctrlEmbSys1 = new Pigmeo.UI.CtrlEmbSys();
			this.tabNewSys = new System.Windows.Forms.TabPage();
			this.grpNewSys = new System.Windows.Forms.GroupBox();
			this.lblAddNewSysIntro = new System.Windows.Forms.Label();
			this.lblNewSysId = new System.Windows.Forms.Label();
			this.btnAddNewSys = new System.Windows.Forms.Button();
			this.txtNewEmbSysId = new System.Windows.Forms.TextBox();
			this.tabsEmbSys.SuspendLayout();
			this.tabSampleSys.SuspendLayout();
			this.tabNewSys.SuspendLayout();
			this.grpNewSys.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnWhatIsThis
			// 
			this.btnWhatIsThis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWhatIsThis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWhatIsThis.ForeColor = System.Drawing.Color.Blue;
			this.btnWhatIsThis.Location = new System.Drawing.Point(675, 380);
			this.btnWhatIsThis.Name = "btnWhatIsThis";
			this.btnWhatIsThis.Size = new System.Drawing.Size(27, 28);
			this.btnWhatIsThis.TabIndex = 13;
			this.btnWhatIsThis.Text = "?";
			this.btnWhatIsThis.UseVisualStyleBackColor = true;
			// 
			// tabsEmbSys
			// 
			this.tabsEmbSys.Controls.Add(this.tabSampleSys);
			this.tabsEmbSys.Controls.Add(this.tabNewSys);
			this.tabsEmbSys.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabsEmbSys.Location = new System.Drawing.Point(0, 0);
			this.tabsEmbSys.Name = "tabsEmbSys";
			this.tabsEmbSys.SelectedIndex = 0;
			this.tabsEmbSys.Size = new System.Drawing.Size(718, 442);
			this.tabsEmbSys.TabIndex = 14;
			// 
			// tabSampleSys
			// 
			this.tabSampleSys.Controls.Add(this.ctrlEmbSys1);
			this.tabSampleSys.Location = new System.Drawing.Point(4, 22);
			this.tabSampleSys.Name = "tabSampleSys";
			this.tabSampleSys.Padding = new System.Windows.Forms.Padding(3);
			this.tabSampleSys.Size = new System.Drawing.Size(710, 416);
			this.tabSampleSys.TabIndex = 0;
			this.tabSampleSys.Text = "SAMPLE SYS - REMOVE";
			this.tabSampleSys.UseVisualStyleBackColor = true;
			// 
			// ctrlEmbSys1
			// 
			this.ctrlEmbSys1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctrlEmbSys1.Location = new System.Drawing.Point(3, 3);
			this.ctrlEmbSys1.MinimumSize = new System.Drawing.Size(710, 416);
			this.ctrlEmbSys1.Name = "ctrlEmbSys1";
			this.ctrlEmbSys1.Size = new System.Drawing.Size(710, 416);
			this.ctrlEmbSys1.TabIndex = 0;
			// 
			// tabNewSys
			// 
			this.tabNewSys.Controls.Add(this.btnWhatIsThis);
			this.tabNewSys.Controls.Add(this.grpNewSys);
			this.tabNewSys.Location = new System.Drawing.Point(4, 22);
			this.tabNewSys.Name = "tabNewSys";
			this.tabNewSys.Size = new System.Drawing.Size(710, 416);
			this.tabNewSys.TabIndex = 2;
			this.tabNewSys.Text = "(add new system)";
			this.tabNewSys.UseVisualStyleBackColor = true;
			this.tabNewSys.Click += new System.EventHandler(this.tabPage3_Click);
			// 
			// grpNewSys
			// 
			this.grpNewSys.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.grpNewSys.Controls.Add(this.lblAddNewSysIntro);
			this.grpNewSys.Controls.Add(this.lblNewSysId);
			this.grpNewSys.Controls.Add(this.btnAddNewSys);
			this.grpNewSys.Controls.Add(this.txtNewEmbSysId);
			this.grpNewSys.Location = new System.Drawing.Point(71, 127);
			this.grpNewSys.Name = "grpNewSys";
			this.grpNewSys.Size = new System.Drawing.Size(562, 167);
			this.grpNewSys.TabIndex = 4;
			this.grpNewSys.TabStop = false;
			this.grpNewSys.Text = "(NS) Add new Embedded System";
			// 
			// lblAddNewSysIntro
			// 
			this.lblAddNewSysIntro.Location = new System.Drawing.Point(21, 34);
			this.lblAddNewSysIntro.Name = "lblAddNewSysIntro";
			this.lblAddNewSysIntro.Size = new System.Drawing.Size(522, 41);
			this.lblAddNewSysIntro.TabIndex = 1;
			this.lblAddNewSysIntro.Text = "(NS) This form lets you add a new Embedded System so later you can access it and " +
				"run your own apps on it.";
			// 
			// lblNewSysId
			// 
			this.lblNewSysId.AutoSize = true;
			this.lblNewSysId.Location = new System.Drawing.Point(137, 96);
			this.lblNewSysId.Name = "lblNewSysId";
			this.lblNewSysId.Size = new System.Drawing.Size(189, 13);
			this.lblNewSysId.TabIndex = 3;
			this.lblNewSysId.Text = "(NS) ID of the new Embedded System:";
			// 
			// btnAddNewSys
			// 
			this.btnAddNewSys.Enabled = false;
			this.btnAddNewSys.Location = new System.Drawing.Point(339, 89);
			this.btnAddNewSys.Name = "btnAddNewSys";
			this.btnAddNewSys.Size = new System.Drawing.Size(75, 53);
			this.btnAddNewSys.TabIndex = 0;
			this.btnAddNewSys.Text = "Add new Embedded System";
			this.btnAddNewSys.UseVisualStyleBackColor = true;
			// 
			// txtNewEmbSysId
			// 
			this.txtNewEmbSysId.Location = new System.Drawing.Point(140, 120);
			this.txtNewEmbSysId.MaxLength = 25;
			this.txtNewEmbSysId.Name = "txtNewEmbSysId";
			this.txtNewEmbSysId.Size = new System.Drawing.Size(186, 20);
			this.txtNewEmbSysId.TabIndex = 2;
			this.txtNewEmbSysId.TextChanged += new System.EventHandler(this.txtNewEmbSysId_TextChanged);
			// 
			// FrmEmbdSys
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(718, 442);
			this.Controls.Add(this.tabsEmbSys);
			this.MinimumSize = new System.Drawing.Size(734, 480);
			this.Name = "FrmEmbdSys";
			this.Text = "FrmEmbdSys";
			this.Load += new System.EventHandler(this.FrmEmbdSys_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEmbdSys_FormClosing);
			this.tabsEmbSys.ResumeLayout(false);
			this.tabSampleSys.ResumeLayout(false);
			this.tabNewSys.ResumeLayout(false);
			this.grpNewSys.ResumeLayout(false);
			this.grpNewSys.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnWhatIsThis;
		private System.Windows.Forms.TabControl tabsEmbSys;
		private System.Windows.Forms.TabPage tabSampleSys;
		private System.Windows.Forms.TabPage tabNewSys;
		private System.Windows.Forms.Label lblAddNewSysIntro;
		private System.Windows.Forms.Button btnAddNewSys;
		private System.Windows.Forms.Label lblNewSysId;
		private System.Windows.Forms.GroupBox grpNewSys;
		private System.Windows.Forms.TextBox txtNewEmbSysId;
		private CtrlEmbSys ctrlEmbSys1;
	}
}