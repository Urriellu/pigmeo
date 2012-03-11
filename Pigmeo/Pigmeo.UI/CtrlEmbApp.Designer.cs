namespace Pigmeo.UI {
	partial class CtrlEmbApp {
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
			this.lblApp = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btnBackup = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.progressBar5 = new System.Windows.Forms.ProgressBar();
			this.label5 = new System.Windows.Forms.Label();
			this.lblRunning = new System.Windows.Forms.Label();
			this.txtCmdOut = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// lblApp
			// 
			this.lblApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblApp.Location = new System.Drawing.Point(12, 9);
			this.lblApp.Name = "lblApp";
			this.lblApp.Size = new System.Drawing.Size(446, 20);
			this.lblApp.TabIndex = 34;
			this.lblApp.Text = "Custom Application: THISISTHEUNKNOWNID";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(542, 44);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(35, 30);
			this.button5.TabIndex = 33;
			this.button5.Text = "Open Project (NS)";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.Red;
			this.button2.Location = new System.Drawing.Point(624, 44);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(35, 30);
			this.button2.TabIndex = 32;
			this.button2.Text = "X";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// btnBackup
			// 
			this.btnBackup.Location = new System.Drawing.Point(583, 44);
			this.btnBackup.Name = "btnBackup";
			this.btnBackup.Size = new System.Drawing.Size(35, 30);
			this.btnBackup.TabIndex = 31;
			this.btnBackup.Text = "Backup data dir (NS)";
			this.btnBackup.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 51);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(53, 39);
			this.button1.TabIndex = 30;
			this.button1.Text = "Start/Stop";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(236, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(95, 13);
			this.label4.TabIndex = 29;
			this.label4.Text = "RAM used: XXMiB";
			// 
			// progressBar5
			// 
			this.progressBar5.BackColor = System.Drawing.Color.Lime;
			this.progressBar5.ForeColor = System.Drawing.Color.Red;
			this.progressBar5.Location = new System.Drawing.Point(274, 41);
			this.progressBar5.Name = "progressBar5";
			this.progressBar5.Size = new System.Drawing.Size(168, 13);
			this.progressBar5.Step = 1;
			this.progressBar5.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar5.TabIndex = 28;
			this.progressBar5.Value = 20;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(236, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 13);
			this.label5.TabIndex = 27;
			this.label5.Text = "CPU:";
			// 
			// lblRunning
			// 
			this.lblRunning.Location = new System.Drawing.Point(6, 35);
			this.lblRunning.Name = "lblRunning";
			this.lblRunning.Size = new System.Drawing.Size(152, 13);
			this.lblRunning.TabIndex = 26;
			this.lblRunning.Text = "Running: HH:MM:SS";
			this.lblRunning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtCmdOut
			// 
			this.txtCmdOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCmdOut.BackColor = System.Drawing.Color.Black;
			this.txtCmdOut.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCmdOut.ForeColor = System.Drawing.Color.White;
			this.txtCmdOut.Location = new System.Drawing.Point(6, 99);
			this.txtCmdOut.MinimumSize = new System.Drawing.Size(650, 50);
			this.txtCmdOut.Name = "txtCmdOut";
			this.txtCmdOut.ReadOnly = true;
			this.txtCmdOut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtCmdOut.Size = new System.Drawing.Size(657, 216);
			this.txtCmdOut.TabIndex = 25;
			this.txtCmdOut.Text = "(no console output)\n0123456789012345678901234567890123456789012345678901234567890" +
				"1234567890123456789\n";
			// 
			// CtrlEmbApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblApp);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnBackup);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.progressBar5);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblRunning);
			this.Controls.Add(this.txtCmdOut);
			this.MinimumSize = new System.Drawing.Size(669, 250);
			this.Name = "CtrlEmbApp";
			this.Size = new System.Drawing.Size(669, 324);
			this.Load += new System.EventHandler(this.CtrlEmbApp_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblApp;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnBackup;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ProgressBar progressBar5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblRunning;
		private System.Windows.Forms.RichTextBox txtCmdOut;
	}
}
