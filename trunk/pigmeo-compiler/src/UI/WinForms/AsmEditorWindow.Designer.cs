namespace Pigmeo.Compiler.UI.WinForms {
	partial class AsmEditorWindow {
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.MenuItem001 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem002 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem003 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem004 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem005 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem006 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem007 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem008 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem009 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem010 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem011 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem012 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem013 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem014 = new System.Windows.Forms.ToolStripMenuItem();
			this.rtxtEditorText = new System.Windows.Forms.RichTextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem001,
            this.MenuItem005,
            this.MenuItem013});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1031, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// MenuItem001
			// 
			this.MenuItem001.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem002,
            this.MenuItem003,
            this.toolStripMenuItem1,
            this.MenuItem004});
			this.MenuItem001.Name = "MenuItem001";
			this.MenuItem001.Size = new System.Drawing.Size(78, 20);
			this.MenuItem001.Text = "not set (file)";
			// 
			// MenuItem002
			// 
			this.MenuItem002.Name = "MenuItem002";
			this.MenuItem002.Size = new System.Drawing.Size(153, 22);
			this.MenuItem002.Text = "not set (load)";
			this.MenuItem002.Click += new System.EventHandler(this.MenuItem002_Click);
			// 
			// MenuItem003
			// 
			this.MenuItem003.Name = "MenuItem003";
			this.MenuItem003.Size = new System.Drawing.Size(153, 22);
			this.MenuItem003.Text = "not set (save)";
			this.MenuItem003.Click += new System.EventHandler(this.MenuItem003_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
			// 
			// MenuItem004
			// 
			this.MenuItem004.Name = "MenuItem004";
			this.MenuItem004.Size = new System.Drawing.Size(153, 22);
			this.MenuItem004.Text = "not set (exit)";
			this.MenuItem004.Click += new System.EventHandler(this.MenuItem004_Click);
			// 
			// MenuItem005
			// 
			this.MenuItem005.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem006,
            this.MenuItem007,
            this.toolStripMenuItem2,
            this.MenuItem008,
            this.MenuItem009,
            this.MenuItem010,
            this.MenuItem011,
            this.toolStripMenuItem3,
            this.MenuItem012});
			this.MenuItem005.Name = "MenuItem005";
			this.MenuItem005.Size = new System.Drawing.Size(82, 20);
			this.MenuItem005.Text = "not set (edit)";
			// 
			// MenuItem006
			// 
			this.MenuItem006.Name = "MenuItem006";
			this.MenuItem006.Size = new System.Drawing.Size(171, 22);
			this.MenuItem006.Text = "not set (undo)";
			this.MenuItem006.Click += new System.EventHandler(this.MenuItem006_Click);
			// 
			// MenuItem007
			// 
			this.MenuItem007.Name = "MenuItem007";
			this.MenuItem007.Size = new System.Drawing.Size(171, 22);
			this.MenuItem007.Text = "not set (redo)";
			this.MenuItem007.Click += new System.EventHandler(this.MenuItem007_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
			// 
			// MenuItem008
			// 
			this.MenuItem008.Name = "MenuItem008";
			this.MenuItem008.Size = new System.Drawing.Size(171, 22);
			this.MenuItem008.Text = "not set (cut)";
			this.MenuItem008.Click += new System.EventHandler(this.MenuItem008_Click);
			// 
			// MenuItem009
			// 
			this.MenuItem009.Name = "MenuItem009";
			this.MenuItem009.Size = new System.Drawing.Size(171, 22);
			this.MenuItem009.Text = "not set (copy)";
			this.MenuItem009.Click += new System.EventHandler(this.MenuItem009_Click);
			// 
			// MenuItem010
			// 
			this.MenuItem010.Name = "MenuItem010";
			this.MenuItem010.Size = new System.Drawing.Size(171, 22);
			this.MenuItem010.Text = "not set (paste)";
			this.MenuItem010.Click += new System.EventHandler(this.MenuItem010_Click);
			// 
			// MenuItem011
			// 
			this.MenuItem011.Name = "MenuItem011";
			this.MenuItem011.Size = new System.Drawing.Size(171, 22);
			this.MenuItem011.Text = "not set (delete)";
			this.MenuItem011.Click += new System.EventHandler(this.MenuItem011_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(168, 6);
			// 
			// MenuItem012
			// 
			this.MenuItem012.Name = "MenuItem012";
			this.MenuItem012.Size = new System.Drawing.Size(171, 22);
			this.MenuItem012.Text = "not set (select all)";
			this.MenuItem012.Click += new System.EventHandler(this.MenuItem012_Click);
			// 
			// MenuItem013
			// 
			this.MenuItem013.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem014});
			this.MenuItem013.Name = "MenuItem013";
			this.MenuItem013.Size = new System.Drawing.Size(96, 20);
			this.MenuItem013.Text = "not set (format)";
			// 
			// MenuItem014
			// 
			this.MenuItem014.Name = "MenuItem014";
			this.MenuItem014.Size = new System.Drawing.Size(181, 22);
			this.MenuItem014.Text = "not set (word wrap)";
			this.MenuItem014.Click += new System.EventHandler(this.MenuItem014_Click);
			// 
			// rtxtEditorText
			// 
			this.rtxtEditorText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtxtEditorText.Location = new System.Drawing.Point(0, 24);
			this.rtxtEditorText.Name = "rtxtEditorText";
			this.rtxtEditorText.Size = new System.Drawing.Size(1031, 406);
			this.rtxtEditorText.TabIndex = 4;
			this.rtxtEditorText.Text = "not set (file contents)";
			this.rtxtEditorText.TextChanged += new System.EventHandler(this.rtxtEditorText_TextChanged);
			// 
			// AsmEditorWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1031, 430);
			this.Controls.Add(this.rtxtEditorText);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "AsmEditorWindow";
			this.Text = "not set (asm editor window)";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AsmEditorWindow_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem MenuItem001;
		private System.Windows.Forms.ToolStripMenuItem MenuItem002;
		private System.Windows.Forms.ToolStripMenuItem MenuItem003;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem MenuItem004;
		private System.Windows.Forms.ToolStripMenuItem MenuItem005;
		private System.Windows.Forms.ToolStripMenuItem MenuItem006;
		private System.Windows.Forms.ToolStripMenuItem MenuItem007;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem MenuItem008;
		private System.Windows.Forms.ToolStripMenuItem MenuItem009;
		private System.Windows.Forms.ToolStripMenuItem MenuItem010;
		private System.Windows.Forms.ToolStripMenuItem MenuItem011;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem MenuItem012;
		private System.Windows.Forms.ToolStripMenuItem MenuItem013;
		private System.Windows.Forms.ToolStripMenuItem MenuItem014;
		private System.Windows.Forms.RichTextBox rtxtEditorText;

	}
}