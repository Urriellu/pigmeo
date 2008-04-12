namespace Pigmeo.Compiler.UI.WinForms {
	partial class UnhandledExceptionSendMailWindow {
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
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtMailContents = new System.Windows.Forms.RichTextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.btnIgnore = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(12, 20);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(170, 13);
			this.lblDescription.TabIndex = 0;
			this.lblDescription.Text = "not set (unknown error description)";
			// 
			// txtMailContents
			// 
			this.txtMailContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMailContents.BackColor = System.Drawing.SystemColors.Window;
			this.txtMailContents.Location = new System.Drawing.Point(1, 48);
			this.txtMailContents.Multiline = true;
			this.txtMailContents.Name = "txtMailContents";
			this.txtMailContents.ReadOnly = true;
			this.txtMailContents.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtMailContents.Size = new System.Drawing.Size(641, 309);
			this.txtMailContents.TabIndex = 1;
			this.txtMailContents.Text = "not set";
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Location = new System.Drawing.Point(420, 363);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(107, 30);
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "not set (send)";
			this.btnSend.UseVisualStyleBackColor = true;
			// 
			// btnIgnore
			// 
			this.btnIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnIgnore.Location = new System.Drawing.Point(533, 363);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.Size = new System.Drawing.Size(97, 30);
			this.btnIgnore.TabIndex = 3;
			this.btnIgnore.Text = "not set (ignore)";
			this.btnIgnore.UseVisualStyleBackColor = true;
			this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
			// 
			// UnhandledExceptionSendMailWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 405);
			this.Controls.Add(this.btnIgnore);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtMailContents);
			this.Controls.Add(this.lblDescription);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "UnhandledExceptionSendMailWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "not set (unknown error)";
			this.Load += new System.EventHandler(this.UnhandledExceptionSendMailWindow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.RichTextBox txtMailContents;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnIgnore;
	}
}