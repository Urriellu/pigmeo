namespace Pigmeo.Compiler.UI.WinForms {
	partial class MainWindow {
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
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem003 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem004 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem006 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem005 = new System.Windows.Forms.ToolStripMenuItem();
			this.MainContainer = new System.Windows.Forms.SplitContainer();
			this.btnCompilationConfig = new System.Windows.Forms.Button();
			this.btnCompilerConfig = new System.Windows.Forms.Button();
			this.btnCompilation = new System.Windows.Forms.Button();
			this.PanelCompilationConfig = new System.Windows.Forms.Panel();
			this.PanelCompilerConfig = new System.Windows.Forms.Panel();
			this.PanelCompilation = new System.Windows.Forms.Panel();
			this.btnPathAsm = new System.Windows.Forms.Button();
			this.txtPathAsm = new System.Windows.Forms.TextBox();
			this.lblPathAsm = new System.Windows.Forms.Label();
			this.btnPathBundle = new System.Windows.Forms.Button();
			this.lblPathBundle = new System.Windows.Forms.Label();
			this.lblPathExe = new System.Windows.Forms.Label();
			this.txtPathBundle = new System.Windows.Forms.TextBox();
			this.btnExeInfo = new System.Windows.Forms.Button();
			this.btnOpenPathExe = new System.Windows.Forms.Button();
			this.txtPathExe = new System.Windows.Forms.TextBox();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnCompile = new System.Windows.Forms.Button();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnClearOutput = new System.Windows.Forms.Button();
			this.MenuItem007 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem008 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem009 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem010 = new System.Windows.Forms.ToolStripMenuItem();
			this.ProgBar = new System.Windows.Forms.ProgressBar();
			this.menuStrip1.SuspendLayout();
			this.MainContainer.Panel1.SuspendLayout();
			this.MainContainer.Panel2.SuspendLayout();
			this.MainContainer.SuspendLayout();
			this.PanelCompilation.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem001,
            this.MenuItem007,
            this.MenuItem004});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1205, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// MenuItem001
			// 
			this.MenuItem001.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem002,
            this.toolStripMenuItem1,
            this.MenuItem003});
			this.MenuItem001.Name = "MenuItem001";
			this.MenuItem001.Size = new System.Drawing.Size(78, 20);
			this.MenuItem001.Text = "not set (file)";
			// 
			// MenuItem002
			// 
			this.MenuItem002.Name = "MenuItem002";
			this.MenuItem002.Size = new System.Drawing.Size(154, 22);
			this.MenuItem002.Text = "not set (open)";
			this.MenuItem002.Click += new System.EventHandler(this.MenuItem002_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
			// 
			// MenuItem003
			// 
			this.MenuItem003.Name = "MenuItem003";
			this.MenuItem003.Size = new System.Drawing.Size(154, 22);
			this.MenuItem003.Text = "not set (exit)";
			this.MenuItem003.Click += new System.EventHandler(this.MenuItem003_Click);
			// 
			// MenuItem004
			// 
			this.MenuItem004.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem006,
            this.toolStripMenuItem2,
            this.MenuItem005});
			this.MenuItem004.Name = "MenuItem004";
			this.MenuItem004.Size = new System.Drawing.Size(84, 20);
			this.MenuItem004.Text = "not set (help)";
			// 
			// MenuItem006
			// 
			this.MenuItem006.Name = "MenuItem006";
			this.MenuItem006.Size = new System.Drawing.Size(195, 22);
			this.MenuItem006.Text = "not set (go to website)";
			this.MenuItem006.Click += new System.EventHandler(this.MenuItem006_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 6);
			// 
			// MenuItem005
			// 
			this.MenuItem005.Name = "MenuItem005";
			this.MenuItem005.Size = new System.Drawing.Size(195, 22);
			this.MenuItem005.Text = "not set (about)";
			this.MenuItem005.Click += new System.EventHandler(this.MenuItem005_Click);
			// 
			// MainContainer
			// 
			this.MainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MainContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.MainContainer.IsSplitterFixed = true;
			this.MainContainer.Location = new System.Drawing.Point(0, 27);
			this.MainContainer.Name = "MainContainer";
			// 
			// MainContainer.Panel1
			// 
			this.MainContainer.Panel1.Controls.Add(this.btnCompilationConfig);
			this.MainContainer.Panel1.Controls.Add(this.btnCompilerConfig);
			this.MainContainer.Panel1.Controls.Add(this.btnCompilation);
			// 
			// MainContainer.Panel2
			// 
			this.MainContainer.Panel2.Controls.Add(this.PanelCompilation);
			this.MainContainer.Panel2.Controls.Add(this.PanelCompilationConfig);
			this.MainContainer.Panel2.Controls.Add(this.PanelCompilerConfig);
			this.MainContainer.Size = new System.Drawing.Size(1205, 770);
			this.MainContainer.SplitterDistance = 82;
			this.MainContainer.TabIndex = 1;
			this.MainContainer.SizeChanged += new System.EventHandler(this.MainContainer_SizeChanged);
			// 
			// btnCompilationConfig
			// 
			this.btnCompilationConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCompilationConfig.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnCompilationConfig.Location = new System.Drawing.Point(1, 149);
			this.btnCompilationConfig.Name = "btnCompilationConfig";
			this.btnCompilationConfig.Size = new System.Drawing.Size(77, 68);
			this.btnCompilationConfig.TabIndex = 2;
			this.btnCompilationConfig.Text = "not set (compilation config)";
			this.btnCompilationConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCompilationConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCompilationConfig.UseVisualStyleBackColor = true;
			this.btnCompilationConfig.Click += new System.EventHandler(this.btnCompilationConfig_Click);
			// 
			// btnCompilerConfig
			// 
			this.btnCompilerConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCompilerConfig.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnCompilerConfig.Location = new System.Drawing.Point(1, 75);
			this.btnCompilerConfig.Name = "btnCompilerConfig";
			this.btnCompilerConfig.Size = new System.Drawing.Size(77, 68);
			this.btnCompilerConfig.TabIndex = 1;
			this.btnCompilerConfig.Text = "not set (compiler config)";
			this.btnCompilerConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCompilerConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCompilerConfig.UseVisualStyleBackColor = true;
			this.btnCompilerConfig.Click += new System.EventHandler(this.btnCompilerConfig_Click);
			// 
			// btnCompilation
			// 
			this.btnCompilation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCompilation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnCompilation.Location = new System.Drawing.Point(1, 1);
			this.btnCompilation.Name = "btnCompilation";
			this.btnCompilation.Size = new System.Drawing.Size(77, 68);
			this.btnCompilation.TabIndex = 0;
			this.btnCompilation.Text = "not set (compilation)";
			this.btnCompilation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCompilation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCompilation.UseVisualStyleBackColor = true;
			this.btnCompilation.Click += new System.EventHandler(this.btnCompilation_Click);
			// 
			// PanelCompilationConfig
			// 
			this.PanelCompilationConfig.Location = new System.Drawing.Point(3, 468);
			this.PanelCompilationConfig.Name = "PanelCompilationConfig";
			this.PanelCompilationConfig.Size = new System.Drawing.Size(1109, 295);
			this.PanelCompilationConfig.TabIndex = 2;
			// 
			// PanelCompilerConfig
			// 
			this.PanelCompilerConfig.Location = new System.Drawing.Point(3, 253);
			this.PanelCompilerConfig.Name = "PanelCompilerConfig";
			this.PanelCompilerConfig.Size = new System.Drawing.Size(1109, 209);
			this.PanelCompilerConfig.TabIndex = 1;
			// 
			// PanelCompilation
			// 
			this.PanelCompilation.Controls.Add(this.ProgBar);
			this.PanelCompilation.Controls.Add(this.btnClearOutput);
			this.PanelCompilation.Controls.Add(this.btnCompile);
			this.PanelCompilation.Controls.Add(this.txtOutput);
			this.PanelCompilation.Controls.Add(this.btnPathAsm);
			this.PanelCompilation.Controls.Add(this.txtPathAsm);
			this.PanelCompilation.Controls.Add(this.lblPathAsm);
			this.PanelCompilation.Controls.Add(this.btnPathBundle);
			this.PanelCompilation.Controls.Add(this.lblPathBundle);
			this.PanelCompilation.Controls.Add(this.lblPathExe);
			this.PanelCompilation.Controls.Add(this.txtPathBundle);
			this.PanelCompilation.Controls.Add(this.btnExeInfo);
			this.PanelCompilation.Controls.Add(this.btnOpenPathExe);
			this.PanelCompilation.Controls.Add(this.txtPathExe);
			this.PanelCompilation.Location = new System.Drawing.Point(3, 3);
			this.PanelCompilation.Name = "PanelCompilation";
			this.PanelCompilation.Size = new System.Drawing.Size(1109, 306);
			this.PanelCompilation.TabIndex = 0;
			// 
			// btnPathAsm
			// 
			this.btnPathAsm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPathAsm.Location = new System.Drawing.Point(928, 54);
			this.btnPathAsm.Name = "btnPathAsm";
			this.btnPathAsm.Size = new System.Drawing.Size(55, 23);
			this.btnPathAsm.TabIndex = 9;
			this.btnPathAsm.Text = "not set (open path asm)";
			this.btnPathAsm.UseVisualStyleBackColor = true;
			this.btnPathAsm.Click += new System.EventHandler(this.btnPathAsm_Click);
			// 
			// txtPathAsm
			// 
			this.txtPathAsm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPathAsm.Location = new System.Drawing.Point(110, 55);
			this.txtPathAsm.Name = "txtPathAsm";
			this.txtPathAsm.Size = new System.Drawing.Size(812, 20);
			this.txtPathAsm.TabIndex = 8;
			this.txtPathAsm.Text = "not set (path to asm)";
			this.txtPathAsm.TextChanged += new System.EventHandler(this.txtPathAsm_TextChanged);
			// 
			// lblPathAsm
			// 
			this.lblPathAsm.AutoSize = true;
			this.lblPathAsm.Location = new System.Drawing.Point(3, 58);
			this.lblPathAsm.Name = "lblPathAsm";
			this.lblPathAsm.Size = new System.Drawing.Size(103, 13);
			this.lblPathAsm.TabIndex = 7;
			this.lblPathAsm.Text = "not set (path to asm)";
			// 
			// btnPathBundle
			// 
			this.btnPathBundle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPathBundle.Enabled = false;
			this.btnPathBundle.Location = new System.Drawing.Point(928, 28);
			this.btnPathBundle.Name = "btnPathBundle";
			this.btnPathBundle.Size = new System.Drawing.Size(55, 23);
			this.btnPathBundle.TabIndex = 6;
			this.btnPathBundle.Text = "not set (open path bundle dialog)";
			this.btnPathBundle.UseVisualStyleBackColor = true;
			this.btnPathBundle.Click += new System.EventHandler(this.btnPathBundle_Click);
			// 
			// lblPathBundle
			// 
			this.lblPathBundle.AutoSize = true;
			this.lblPathBundle.Location = new System.Drawing.Point(3, 32);
			this.lblPathBundle.Name = "lblPathBundle";
			this.lblPathBundle.Size = new System.Drawing.Size(116, 13);
			this.lblPathBundle.TabIndex = 5;
			this.lblPathBundle.Text = "not set (path to bundle)";
			// 
			// lblPathExe
			// 
			this.lblPathExe.AutoSize = true;
			this.lblPathExe.Location = new System.Drawing.Point(3, 6);
			this.lblPathExe.Name = "lblPathExe";
			this.lblPathExe.Size = new System.Drawing.Size(101, 13);
			this.lblPathExe.TabIndex = 4;
			this.lblPathExe.Text = "not set (path to exe)";
			// 
			// txtPathBundle
			// 
			this.txtPathBundle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPathBundle.Location = new System.Drawing.Point(125, 29);
			this.txtPathBundle.Name = "txtPathBundle";
			this.txtPathBundle.ReadOnly = true;
			this.txtPathBundle.Size = new System.Drawing.Size(797, 20);
			this.txtPathBundle.TabIndex = 3;
			this.txtPathBundle.Text = "not set (path to bundle)";
			this.txtPathBundle.TextChanged += new System.EventHandler(this.txtPathBundle_TextChanged);
			// 
			// btnExeInfo
			// 
			this.btnExeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExeInfo.Location = new System.Drawing.Point(928, 1);
			this.btnExeInfo.Name = "btnExeInfo";
			this.btnExeInfo.Size = new System.Drawing.Size(55, 23);
			this.btnExeInfo.TabIndex = 2;
			this.btnExeInfo.Text = "not set (info)";
			this.btnExeInfo.UseVisualStyleBackColor = true;
			this.btnExeInfo.Click += new System.EventHandler(this.btnExeInfo_Click);
			// 
			// btnOpenPathExe
			// 
			this.btnOpenPathExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenPathExe.Location = new System.Drawing.Point(867, 1);
			this.btnOpenPathExe.Name = "btnOpenPathExe";
			this.btnOpenPathExe.Size = new System.Drawing.Size(55, 23);
			this.btnOpenPathExe.TabIndex = 1;
			this.btnOpenPathExe.Text = "not set (open path exe)";
			this.btnOpenPathExe.UseVisualStyleBackColor = true;
			this.btnOpenPathExe.Click += new System.EventHandler(this.btnOpenPathExe_Click);
			// 
			// txtPathExe
			// 
			this.txtPathExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPathExe.Location = new System.Drawing.Point(110, 3);
			this.txtPathExe.Name = "txtPathExe";
			this.txtPathExe.Size = new System.Drawing.Size(751, 20);
			this.txtPathExe.TabIndex = 0;
			this.txtPathExe.Text = "not set (path to exe)";
			this.txtPathExe.TextChanged += new System.EventHandler(this.txtPathExe_TextChanged);
			// 
			// txtOutput
			// 
			this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
			this.txtOutput.Location = new System.Drawing.Point(3, 93);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(1103, 185);
			this.txtOutput.TabIndex = 10;
			// 
			// btnCompile
			// 
			this.btnCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCompile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnCompile.Location = new System.Drawing.Point(1010, 1);
			this.btnCompile.Name = "btnCompile";
			this.btnCompile.Size = new System.Drawing.Size(92, 50);
			this.btnCompile.TabIndex = 11;
			this.btnCompile.Text = "not set (compile)";
			this.btnCompile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCompile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCompile.UseVisualStyleBackColor = true;
			this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 800);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(1205, 22);
			this.StatusStrip.TabIndex = 2;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(41, 17);
			this.StatusLabel.Text = "not set";
			// 
			// btnClearOutput
			// 
			this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearOutput.Location = new System.Drawing.Point(1010, 54);
			this.btnClearOutput.Name = "btnClearOutput";
			this.btnClearOutput.Size = new System.Drawing.Size(92, 23);
			this.btnClearOutput.TabIndex = 12;
			this.btnClearOutput.Text = "not set (clear output)";
			this.btnClearOutput.UseVisualStyleBackColor = true;
			this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
			// 
			// MenuItem007
			// 
			this.MenuItem007.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem008,
            this.MenuItem009,
            this.MenuItem010});
			this.MenuItem007.Name = "MenuItem007";
			this.MenuItem007.Size = new System.Drawing.Size(86, 20);
			this.MenuItem007.Text = "not set (view)";
			// 
			// MenuItem008
			// 
			this.MenuItem008.Name = "MenuItem008";
			this.MenuItem008.Size = new System.Drawing.Size(224, 22);
			this.MenuItem008.Text = "not set (compilation)";
			this.MenuItem008.Click += new System.EventHandler(this.MenuItem008_Click);
			// 
			// MenuItem009
			// 
			this.MenuItem009.Name = "MenuItem009";
			this.MenuItem009.Size = new System.Drawing.Size(224, 22);
			this.MenuItem009.Text = "not set (compiler settings)";
			this.MenuItem009.Click += new System.EventHandler(this.MenuItem009_Click);
			// 
			// MenuItem010
			// 
			this.MenuItem010.Name = "MenuItem010";
			this.MenuItem010.Size = new System.Drawing.Size(224, 22);
			this.MenuItem010.Text = "not set (compilation settings)";
			this.MenuItem010.Click += new System.EventHandler(this.MenuItem010_Click);
			// 
			// ProgBar
			// 
			this.ProgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBar.Location = new System.Drawing.Point(0, 284);
			this.ProgBar.Name = "ProgBar";
			this.ProgBar.Size = new System.Drawing.Size(1103, 19);
			this.ProgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgBar.TabIndex = 13;
			this.ProgBar.Value = 80;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1205, 822);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MainContainer);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(600, 400);
			this.Name = "MainWindow";
			this.Text = "not set";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.MainContainer.Panel1.ResumeLayout(false);
			this.MainContainer.Panel2.ResumeLayout(false);
			this.MainContainer.ResumeLayout(false);
			this.PanelCompilation.ResumeLayout(false);
			this.PanelCompilation.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem MenuItem001;
		private System.Windows.Forms.ToolStripMenuItem MenuItem002;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem MenuItem003;
		private System.Windows.Forms.ToolStripMenuItem MenuItem004;
		private System.Windows.Forms.ToolStripMenuItem MenuItem005;
		private System.Windows.Forms.ToolStripMenuItem MenuItem006;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.SplitContainer MainContainer;
		private System.Windows.Forms.Button btnCompilation;
		private System.Windows.Forms.Button btnCompilationConfig;
		private System.Windows.Forms.Button btnCompilerConfig;
		private System.Windows.Forms.Panel PanelCompilationConfig;
		private System.Windows.Forms.Panel PanelCompilerConfig;
		private System.Windows.Forms.Panel PanelCompilation;
		private System.Windows.Forms.TextBox txtPathExe;
		private System.Windows.Forms.Button btnOpenPathExe;
		private System.Windows.Forms.Button btnExeInfo;
		private System.Windows.Forms.TextBox txtPathBundle;
		private System.Windows.Forms.Button btnPathBundle;
		private System.Windows.Forms.Label lblPathBundle;
		private System.Windows.Forms.Label lblPathExe;
		private System.Windows.Forms.TextBox txtPathAsm;
		private System.Windows.Forms.Label lblPathAsm;
		private System.Windows.Forms.Button btnPathAsm;
		private System.Windows.Forms.Button btnCompile;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.Button btnClearOutput;
		public System.Windows.Forms.StatusStrip StatusStrip;
		public System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.ToolStripMenuItem MenuItem007;
		private System.Windows.Forms.ToolStripMenuItem MenuItem008;
		private System.Windows.Forms.ToolStripMenuItem MenuItem009;
		private System.Windows.Forms.ToolStripMenuItem MenuItem010;
		public System.Windows.Forms.ProgressBar ProgBar;
	}
}