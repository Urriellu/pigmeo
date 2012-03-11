namespace Pigmeo.UI {
	partial class CtrlEmbAppMenu_OLD {
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
			this.lblPrjId = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblPrjId
			// 
			this.lblPrjId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrjId.Location = new System.Drawing.Point(6, 6);
			this.lblPrjId.Name = "lblPrjId";
			this.lblPrjId.Size = new System.Drawing.Size(135, 23);
			this.lblPrjId.TabIndex = 0;
			this.lblPrjId.Text = "THISISPRJID";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(156, 41);
			this.label2.TabIndex = 1;
			this.label2.Text = "this is the description of this project being run on a microcontroller";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(169, 28);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(45, 45);
			this.button1.TabIndex = 2;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(151, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "HH:MM:SS";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// EmbPrj
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblPrjId);
			this.Name = "EmbPrj";
			this.Size = new System.Drawing.Size(215, 79);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblPrjId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
	}
}
