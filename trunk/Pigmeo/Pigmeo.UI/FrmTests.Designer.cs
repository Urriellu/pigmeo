namespace Pigmeo.UI {
	partial class FrmTests {
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
			this.grpProjects = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.embPrj2 = new Pigmeo.UI.CtrlEmbAppMenu_OLD();
			this.embPrj1 = new Pigmeo.UI.CtrlEmbAppMenu_OLD();
			this.grpProjects.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpProjects
			// 
			this.grpProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.grpProjects.Controls.Add(this.panel1);
			this.grpProjects.Location = new System.Drawing.Point(12, 12);
			this.grpProjects.Name = "grpProjects";
			this.grpProjects.Size = new System.Drawing.Size(244, 244);
			this.grpProjects.TabIndex = 5;
			this.grpProjects.TabStop = false;
			this.grpProjects.Text = "Projects on this Embedded System";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.embPrj2);
			this.panel1.Controls.Add(this.embPrj1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(238, 225);
			this.panel1.TabIndex = 3;
			// 
			// embPrj2
			// 
			this.embPrj2.Location = new System.Drawing.Point(3, 88);
			this.embPrj2.Name = "embPrj2";
			this.embPrj2.Size = new System.Drawing.Size(215, 79);
			this.embPrj2.TabIndex = 1;
			// 
			// embPrj1
			// 
			this.embPrj1.Location = new System.Drawing.Point(3, 3);
			this.embPrj1.Name = "embPrj1";
			this.embPrj1.Size = new System.Drawing.Size(215, 79);
			this.embPrj1.TabIndex = 0;
			// 
			// FrmTests
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(709, 268);
			this.Controls.Add(this.grpProjects);
			this.Name = "FrmTests";
			this.Text = "FrmTests";
			this.grpProjects.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpProjects;
		private System.Windows.Forms.Panel panel1;
		private CtrlEmbAppMenu_OLD embPrj2;
		private CtrlEmbAppMenu_OLD embPrj1;

	}
}