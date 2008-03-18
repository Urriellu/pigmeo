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
			this.txtEditorText = new System.Windows.Forms.TextBox();
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtEditorText
			// 
			this.txtEditorText.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtEditorText.Location = new System.Drawing.Point(0, 52);
			this.txtEditorText.Multiline = true;
			this.txtEditorText.Name = "txtEditorText";
			this.txtEditorText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtEditorText.Size = new System.Drawing.Size(722, 378);
			this.txtEditorText.TabIndex = 2;
			this.txtEditorText.Text = "not set (file contents)";
			this.txtEditorText.WordWrap = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem001,
            this.MenuItem005});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(722, 24);
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
			// 
			// MenuItem007
			// 
			this.MenuItem007.Name = "MenuItem007";
			this.MenuItem007.Size = new System.Drawing.Size(171, 22);
			this.MenuItem007.Text = "not set (redo)";
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
			// 
			// MenuItem009
			// 
			this.MenuItem009.Name = "MenuItem009";
			this.MenuItem009.Size = new System.Drawing.Size(171, 22);
			this.MenuItem009.Text = "not set (copy)";
			// 
			// MenuItem010
			// 
			this.MenuItem010.Name = "MenuItem010";
			this.MenuItem010.Size = new System.Drawing.Size(171, 22);
			this.MenuItem010.Text = "not set (paste)";
			// 
			// MenuItem011
			// 
			this.MenuItem011.Name = "MenuItem011";
			this.MenuItem011.Size = new System.Drawing.Size(171, 22);
			this.MenuItem011.Text = "not set (delete)";
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
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(722, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "toolStripButton2";
			// 
			// AsmEditorWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(722, 430);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.txtEditorText);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "AsmEditorWindow";
			this.Text = "not set (asm editor window)";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtEditorText;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem MenuItem001;
		private System.Windows.Forms.ToolStripMenuItem MenuItem002;
		private System.Windows.Forms.ToolStripMenuItem MenuItem003;
		private System.Windows.Forms.ToolStrip toolStrip1;
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
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;

	}
}