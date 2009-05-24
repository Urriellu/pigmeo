namespace Pigmeo.PLPTC {
	partial class Pinout {
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
			this.ImageRealPCVertical = new System.Windows.Forms.PictureBox();
			this.ImageRealPortHoriz = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.ImageRealPCVertical)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ImageRealPortHoriz)).BeginInit();
			this.SuspendLayout();
			// 
			// ImageRealPCVertical
			// 
			this.ImageRealPCVertical.Location = new System.Drawing.Point(12, 12);
			this.ImageRealPCVertical.Name = "ImageRealPCVertical";
			this.ImageRealPCVertical.Size = new System.Drawing.Size(118, 376);
			this.ImageRealPCVertical.TabIndex = 0;
			this.ImageRealPCVertical.TabStop = false;
			// 
			// ImageRealPortHoriz
			// 
			this.ImageRealPortHoriz.Location = new System.Drawing.Point(191, 12);
			this.ImageRealPortHoriz.Name = "ImageRealPortHoriz";
			this.ImageRealPortHoriz.Size = new System.Drawing.Size(350, 101);
			this.ImageRealPortHoriz.TabIndex = 1;
			this.ImageRealPortHoriz.TabStop = false;
			// 
			// Pinout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 409);
			this.Controls.Add(this.ImageRealPortHoriz);
			this.Controls.Add(this.ImageRealPCVertical);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Pinout";
			this.Text = "NOT SET (Pinout)";
			this.Load += new System.EventHandler(this.Pinout_Load);
			((System.ComponentModel.ISupportInitialize)(this.ImageRealPCVertical)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ImageRealPortHoriz)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox ImageRealPCVertical;
		private System.Windows.Forms.PictureBox ImageRealPortHoriz;
	}
}