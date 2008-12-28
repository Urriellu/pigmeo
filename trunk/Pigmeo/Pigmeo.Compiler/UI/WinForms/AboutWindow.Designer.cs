namespace Pigmeo.Compiler.UI.WinForms {
	partial class AboutWindow {
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
			this.PicBoxLogo = new System.Windows.Forms.PictureBox();
			this.lblAppName = new System.Windows.Forms.Label();
			this.linkUrl = new System.Windows.Forms.LinkLabel();
			this.txtDesc = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.PicBoxLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// PicBoxLogo
			// 
			this.PicBoxLogo.Location = new System.Drawing.Point(136, 12);
			this.PicBoxLogo.Name = "PicBoxLogo";
			this.PicBoxLogo.Size = new System.Drawing.Size(168, 115);
			this.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PicBoxLogo.TabIndex = 0;
			this.PicBoxLogo.TabStop = false;
			// 
			// lblAppName
			// 
			this.lblAppName.AutoSize = true;
			this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAppName.Location = new System.Drawing.Point(12, 144);
			this.lblAppName.Name = "lblAppName";
			this.lblAppName.Size = new System.Drawing.Size(204, 17);
			this.lblAppName.TabIndex = 1;
			this.lblAppName.Text = "not set (name and version)";
			// 
			// linkUrl
			// 
			this.linkUrl.AutoSize = true;
			this.linkUrl.Location = new System.Drawing.Point(12, 445);
			this.linkUrl.Name = "linkUrl";
			this.linkUrl.Size = new System.Drawing.Size(59, 13);
			this.linkUrl.TabIndex = 3;
			this.linkUrl.TabStop = true;
			this.linkUrl.Text = "not set (url)";
			this.linkUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUrl_LinkClicked);
			// 
			// txtDesc
			// 
			this.txtDesc.BackColor = System.Drawing.SystemColors.Control;
			this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDesc.Location = new System.Drawing.Point(15, 173);
			this.txtDesc.Multiline = true;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(421, 87);
			this.txtDesc.TabIndex = 4;
			this.txtDesc.Text = "not set (description + devs)";
			// 
			// AboutWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 484);
			this.Controls.Add(this.txtDesc);
			this.Controls.Add(this.linkUrl);
			this.Controls.Add(this.lblAppName);
			this.Controls.Add(this.PicBoxLogo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutWindow";
			this.Text = "not set";
			((System.ComponentModel.ISupportInitialize)(this.PicBoxLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox PicBoxLogo;
		private System.Windows.Forms.Label lblAppName;
		private System.Windows.Forms.LinkLabel linkUrl;
		private System.Windows.Forms.TextBox txtDesc;
	}
}