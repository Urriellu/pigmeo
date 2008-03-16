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
			this.MenuItem007 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem008 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem009 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem010 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem004 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem006 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem005 = new System.Windows.Forms.ToolStripMenuItem();
			this.MainContainer = new System.Windows.Forms.SplitContainer();
			this.btnCompilationConfig = new System.Windows.Forms.Button();
			this.btnCompilerConfig = new System.Windows.Forms.Button();
			this.btnCompilation = new System.Windows.Forms.Button();
			this.PanelCompilerConfig = new System.Windows.Forms.Panel();
			this.groupVerbosity = new System.Windows.Forms.GroupBox();
			this.radioVerbDebug = new System.Windows.Forms.RadioButton();
			this.radioVerbVerbose = new System.Windows.Forms.RadioButton();
			this.radioVerbQuiet = new System.Windows.Forms.RadioButton();
			this.chkGenerateAsmFile = new System.Windows.Forms.CheckBox();
			this.chkGenerateSummaryFile = new System.Windows.Forms.CheckBox();
			this.chkGenerateSymbolTable = new System.Windows.Forms.CheckBox();
			this.chkGenerateErrorFile = new System.Windows.Forms.CheckBox();
			this.lblSummaryFile = new System.Windows.Forms.Label();
			this.txtSummaryPath = new System.Windows.Forms.TextBox();
			this.btnOpenSummaryFile = new System.Windows.Forms.Button();
			this.btnOpenSymbolTableFile = new System.Windows.Forms.Button();
			this.txtSymbolTablePath = new System.Windows.Forms.TextBox();
			this.lblSymbolTableFile = new System.Windows.Forms.Label();
			this.btnOpenErrorFile = new System.Windows.Forms.Button();
			this.lblLanguage = new System.Windows.Forms.Label();
			this.lblErrorFile = new System.Windows.Forms.Label();
			this.txtErrorFilePath = new System.Windows.Forms.TextBox();
			this.groupAssLangFile = new System.Windows.Forms.GroupBox();
			this.chkAddComentsAsm = new System.Windows.Forms.CheckBox();
			this.groupNumeralSystem = new System.Windows.Forms.GroupBox();
			this.radioNumeralSystemOctal = new System.Windows.Forms.RadioButton();
			this.radioNumeralSystemHexadecimal = new System.Windows.Forms.RadioButton();
			this.radioNumeralSystemDecimal = new System.Windows.Forms.RadioButton();
			this.radioNumeralSystemBinary = new System.Windows.Forms.RadioButton();
			this.groupEOF = new System.Windows.Forms.GroupBox();
			this.radioEOFMacOS = new System.Windows.Forms.RadioButton();
			this.radioEOFUnix = new System.Windows.Forms.RadioButton();
			this.radioEOFWindows = new System.Windows.Forms.RadioButton();
			this.groupBundle = new System.Windows.Forms.GroupBox();
			this.lblBundleGlobalStaticThings = new System.Windows.Forms.Label();
			this.txtBundleGlobalStaticThings = new System.Windows.Forms.TextBox();
			this.btnDefaultBundleNames = new System.Windows.Forms.Button();
			this.lblGlobalNamespace = new System.Windows.Forms.Label();
			this.txtGlobalNamespace = new System.Windows.Forms.TextBox();
			this.txtBundleMainModuleName = new System.Windows.Forms.TextBox();
			this.lblBundleMainModuleName = new System.Windows.Forms.Label();
			this.txtBundleAssemblyName = new System.Windows.Forms.TextBox();
			this.lblBundleAssemblyName = new System.Windows.Forms.Label();
			this.lblCompilerConfNote = new System.Windows.Forms.Label();
			this.PanelCompilation = new System.Windows.Forms.Panel();
			this.ProgBar = new System.Windows.Forms.ProgressBar();
			this.btnClearOutput = new System.Windows.Forms.Button();
			this.btnCompile = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
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
			this.PanelCompilationConfig = new System.Windows.Forms.Panel();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.comboLanguages = new System.Windows.Forms.ComboBox();
			this.lblCompilationConfNote = new System.Windows.Forms.Label();
			this.txtCompilationConfigFile = new System.Windows.Forms.TextBox();
			this.lblCompilationConfigFile = new System.Windows.Forms.Label();
			this.btnOpenCompilationConfigFile = new System.Windows.Forms.Button();
			this.btnSaveCompilationConfigFile = new System.Windows.Forms.Button();
			this.btnLoadCompilationConfigFile = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtPersonalNotes = new System.Windows.Forms.TextBox();
			this.lblPersonalNotes = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.MainContainer.Panel1.SuspendLayout();
			this.MainContainer.Panel2.SuspendLayout();
			this.MainContainer.SuspendLayout();
			this.PanelCompilerConfig.SuspendLayout();
			this.groupVerbosity.SuspendLayout();
			this.groupAssLangFile.SuspendLayout();
			this.groupNumeralSystem.SuspendLayout();
			this.groupEOF.SuspendLayout();
			this.groupBundle.SuspendLayout();
			this.PanelCompilation.SuspendLayout();
			this.PanelCompilationConfig.SuspendLayout();
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
			this.menuStrip1.Size = new System.Drawing.Size(1203, 24);
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
			this.MainContainer.Panel2.Controls.Add(this.PanelCompilerConfig);
			this.MainContainer.Panel2.Controls.Add(this.PanelCompilation);
			this.MainContainer.Panel2.Controls.Add(this.PanelCompilationConfig);
			this.MainContainer.Size = new System.Drawing.Size(1203, 763);
			this.MainContainer.SplitterDistance = 83;
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
			// PanelCompilerConfig
			// 
			this.PanelCompilerConfig.AutoScroll = true;
			this.PanelCompilerConfig.Controls.Add(this.comboLanguages);
			this.PanelCompilerConfig.Controls.Add(this.groupVerbosity);
			this.PanelCompilerConfig.Controls.Add(this.chkGenerateAsmFile);
			this.PanelCompilerConfig.Controls.Add(this.chkGenerateSummaryFile);
			this.PanelCompilerConfig.Controls.Add(this.chkGenerateSymbolTable);
			this.PanelCompilerConfig.Controls.Add(this.chkGenerateErrorFile);
			this.PanelCompilerConfig.Controls.Add(this.lblSummaryFile);
			this.PanelCompilerConfig.Controls.Add(this.txtSummaryPath);
			this.PanelCompilerConfig.Controls.Add(this.btnOpenSummaryFile);
			this.PanelCompilerConfig.Controls.Add(this.btnOpenSymbolTableFile);
			this.PanelCompilerConfig.Controls.Add(this.txtSymbolTablePath);
			this.PanelCompilerConfig.Controls.Add(this.lblSymbolTableFile);
			this.PanelCompilerConfig.Controls.Add(this.btnOpenErrorFile);
			this.PanelCompilerConfig.Controls.Add(this.lblLanguage);
			this.PanelCompilerConfig.Controls.Add(this.lblErrorFile);
			this.PanelCompilerConfig.Controls.Add(this.txtErrorFilePath);
			this.PanelCompilerConfig.Controls.Add(this.groupAssLangFile);
			this.PanelCompilerConfig.Controls.Add(this.groupBundle);
			this.PanelCompilerConfig.Controls.Add(this.lblCompilerConfNote);
			this.PanelCompilerConfig.Location = new System.Drawing.Point(3, 166);
			this.PanelCompilerConfig.Name = "PanelCompilerConfig";
			this.PanelCompilerConfig.Size = new System.Drawing.Size(1106, 296);
			this.PanelCompilerConfig.TabIndex = 1;
			// 
			// groupVerbosity
			// 
			this.groupVerbosity.Controls.Add(this.radioVerbDebug);
			this.groupVerbosity.Controls.Add(this.radioVerbVerbose);
			this.groupVerbosity.Controls.Add(this.radioVerbQuiet);
			this.groupVerbosity.Location = new System.Drawing.Point(6, 709);
			this.groupVerbosity.Name = "groupVerbosity";
			this.groupVerbosity.Size = new System.Drawing.Size(1081, 96);
			this.groupVerbosity.TabIndex = 25;
			this.groupVerbosity.TabStop = false;
			this.groupVerbosity.Text = "not set (verbosity)";
			// 
			// radioVerbDebug
			// 
			this.radioVerbDebug.AutoSize = true;
			this.radioVerbDebug.Location = new System.Drawing.Point(15, 65);
			this.radioVerbDebug.Name = "radioVerbDebug";
			this.radioVerbDebug.Size = new System.Drawing.Size(96, 17);
			this.radioVerbDebug.TabIndex = 2;
			this.radioVerbDebug.TabStop = true;
			this.radioVerbDebug.Text = "not set (debug)";
			this.radioVerbDebug.UseVisualStyleBackColor = true;
			this.radioVerbDebug.CheckedChanged += new System.EventHandler(this.radioVerbDebug_CheckedChanged);
			// 
			// radioVerbVerbose
			// 
			this.radioVerbVerbose.AutoSize = true;
			this.radioVerbVerbose.Location = new System.Drawing.Point(15, 42);
			this.radioVerbVerbose.Name = "radioVerbVerbose";
			this.radioVerbVerbose.Size = new System.Drawing.Size(104, 17);
			this.radioVerbVerbose.TabIndex = 1;
			this.radioVerbVerbose.TabStop = true;
			this.radioVerbVerbose.Text = "not set (verbose)";
			this.radioVerbVerbose.UseVisualStyleBackColor = true;
			this.radioVerbVerbose.CheckedChanged += new System.EventHandler(this.radioVerbVerbose_CheckedChanged);
			// 
			// radioVerbQuiet
			// 
			this.radioVerbQuiet.AutoSize = true;
			this.radioVerbQuiet.Location = new System.Drawing.Point(15, 19);
			this.radioVerbQuiet.Name = "radioVerbQuiet";
			this.radioVerbQuiet.Size = new System.Drawing.Size(89, 17);
			this.radioVerbQuiet.TabIndex = 0;
			this.radioVerbQuiet.TabStop = true;
			this.radioVerbQuiet.Text = "not set (quiet)";
			this.radioVerbQuiet.UseVisualStyleBackColor = true;
			this.radioVerbQuiet.CheckedChanged += new System.EventHandler(this.radioVerbQuiet_CheckedChanged);
			// 
			// chkGenerateAsmFile
			// 
			this.chkGenerateAsmFile.AutoSize = true;
			this.chkGenerateAsmFile.Location = new System.Drawing.Point(15, 676);
			this.chkGenerateAsmFile.Name = "chkGenerateAsmFile";
			this.chkGenerateAsmFile.Size = new System.Drawing.Size(147, 17);
			this.chkGenerateAsmFile.TabIndex = 24;
			this.chkGenerateAsmFile.Text = "not set (generate asm file)";
			this.chkGenerateAsmFile.UseVisualStyleBackColor = true;
			this.chkGenerateAsmFile.CheckedChanged += new System.EventHandler(this.chkGenerateAsmFile_CheckedChanged);
			// 
			// chkGenerateSummaryFile
			// 
			this.chkGenerateSummaryFile.AutoSize = true;
			this.chkGenerateSummaryFile.Location = new System.Drawing.Point(15, 653);
			this.chkGenerateSummaryFile.Name = "chkGenerateSummaryFile";
			this.chkGenerateSummaryFile.Size = new System.Drawing.Size(169, 17);
			this.chkGenerateSummaryFile.TabIndex = 23;
			this.chkGenerateSummaryFile.Text = "not set (generate summary file)";
			this.chkGenerateSummaryFile.UseVisualStyleBackColor = true;
			this.chkGenerateSummaryFile.CheckedChanged += new System.EventHandler(this.chkGenerateSummaryFile_CheckedChanged);
			// 
			// chkGenerateSymbolTable
			// 
			this.chkGenerateSymbolTable.AutoSize = true;
			this.chkGenerateSymbolTable.Location = new System.Drawing.Point(15, 630);
			this.chkGenerateSymbolTable.Name = "chkGenerateSymbolTable";
			this.chkGenerateSymbolTable.Size = new System.Drawing.Size(170, 17);
			this.chkGenerateSymbolTable.TabIndex = 22;
			this.chkGenerateSymbolTable.Text = "not set (generate symbol table)";
			this.chkGenerateSymbolTable.UseVisualStyleBackColor = true;
			this.chkGenerateSymbolTable.CheckedChanged += new System.EventHandler(this.chkGenerateSymbolTable_CheckedChanged);
			// 
			// chkGenerateErrorFile
			// 
			this.chkGenerateErrorFile.AutoSize = true;
			this.chkGenerateErrorFile.Location = new System.Drawing.Point(15, 607);
			this.chkGenerateErrorFile.Name = "chkGenerateErrorFile";
			this.chkGenerateErrorFile.Size = new System.Drawing.Size(149, 17);
			this.chkGenerateErrorFile.TabIndex = 21;
			this.chkGenerateErrorFile.Text = "not set (generate error file)";
			this.chkGenerateErrorFile.UseVisualStyleBackColor = true;
			this.chkGenerateErrorFile.CheckedChanged += new System.EventHandler(this.chkGenerateErrorFile_CheckedChanged);
			// 
			// lblSummaryFile
			// 
			this.lblSummaryFile.AutoSize = true;
			this.lblSummaryFile.Location = new System.Drawing.Point(12, 573);
			this.lblSummaryFile.Name = "lblSummaryFile";
			this.lblSummaryFile.Size = new System.Drawing.Size(105, 13);
			this.lblSummaryFile.TabIndex = 20;
			this.lblSummaryFile.Text = "not set (summary file)";
			// 
			// txtSummaryPath
			// 
			this.txtSummaryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSummaryPath.Location = new System.Drawing.Point(123, 570);
			this.txtSummaryPath.Name = "txtSummaryPath";
			this.txtSummaryPath.Size = new System.Drawing.Size(929, 20);
			this.txtSummaryPath.TabIndex = 19;
			this.txtSummaryPath.Text = "not set (path to summary file)";
			this.txtSummaryPath.TextChanged += new System.EventHandler(this.txtSymmaryPath_TextChanged);
			// 
			// btnOpenSummaryFile
			// 
			this.btnOpenSummaryFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenSummaryFile.Location = new System.Drawing.Point(1058, 568);
			this.btnOpenSummaryFile.Name = "btnOpenSummaryFile";
			this.btnOpenSummaryFile.Size = new System.Drawing.Size(23, 23);
			this.btnOpenSummaryFile.TabIndex = 18;
			this.btnOpenSummaryFile.Text = "not set (open path summary file)";
			this.btnOpenSummaryFile.UseVisualStyleBackColor = true;
			this.btnOpenSummaryFile.Click += new System.EventHandler(this.btnOpenSummaryFile_Click);
			// 
			// btnOpenSymbolTableFile
			// 
			this.btnOpenSymbolTableFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenSymbolTableFile.Location = new System.Drawing.Point(1058, 542);
			this.btnOpenSymbolTableFile.Name = "btnOpenSymbolTableFile";
			this.btnOpenSymbolTableFile.Size = new System.Drawing.Size(23, 23);
			this.btnOpenSymbolTableFile.TabIndex = 17;
			this.btnOpenSymbolTableFile.Text = "not set (open path symbol table file)";
			this.btnOpenSymbolTableFile.UseVisualStyleBackColor = true;
			this.btnOpenSymbolTableFile.Click += new System.EventHandler(this.btnOpenSymbolTableFile_Click);
			// 
			// txtSymbolTablePath
			// 
			this.txtSymbolTablePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSymbolTablePath.Location = new System.Drawing.Point(140, 545);
			this.txtSymbolTablePath.Name = "txtSymbolTablePath";
			this.txtSymbolTablePath.Size = new System.Drawing.Size(912, 20);
			this.txtSymbolTablePath.TabIndex = 16;
			this.txtSymbolTablePath.Text = "not set (path to symbol table file)";
			this.txtSymbolTablePath.TextChanged += new System.EventHandler(this.txtSymbolTablePath_TextChanged);
			// 
			// lblSymbolTableFile
			// 
			this.lblSymbolTableFile.AutoSize = true;
			this.lblSymbolTableFile.Location = new System.Drawing.Point(12, 547);
			this.lblSymbolTableFile.Name = "lblSymbolTableFile";
			this.lblSymbolTableFile.Size = new System.Drawing.Size(122, 13);
			this.lblSymbolTableFile.TabIndex = 15;
			this.lblSymbolTableFile.Text = "not set (symbol table file)";
			// 
			// btnOpenErrorFile
			// 
			this.btnOpenErrorFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenErrorFile.Location = new System.Drawing.Point(1058, 517);
			this.btnOpenErrorFile.Name = "btnOpenErrorFile";
			this.btnOpenErrorFile.Size = new System.Drawing.Size(23, 23);
			this.btnOpenErrorFile.TabIndex = 14;
			this.btnOpenErrorFile.Text = "not set (open path error file)";
			this.btnOpenErrorFile.UseVisualStyleBackColor = true;
			this.btnOpenErrorFile.Click += new System.EventHandler(this.btnOpenErrorFile_Click);
			// 
			// lblLanguage
			// 
			this.lblLanguage.AutoSize = true;
			this.lblLanguage.Location = new System.Drawing.Point(13, 825);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new System.Drawing.Size(92, 13);
			this.lblLanguage.TabIndex = 5;
			this.lblLanguage.Text = "not set (language)";
			// 
			// lblErrorFile
			// 
			this.lblErrorFile.AutoSize = true;
			this.lblErrorFile.Location = new System.Drawing.Point(12, 522);
			this.lblErrorFile.Name = "lblErrorFile";
			this.lblErrorFile.Size = new System.Drawing.Size(85, 13);
			this.lblErrorFile.TabIndex = 4;
			this.lblErrorFile.Text = "not set (error file)";
			// 
			// txtErrorFilePath
			// 
			this.txtErrorFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrorFilePath.Location = new System.Drawing.Point(103, 519);
			this.txtErrorFilePath.Name = "txtErrorFilePath";
			this.txtErrorFilePath.Size = new System.Drawing.Size(949, 20);
			this.txtErrorFilePath.TabIndex = 3;
			this.txtErrorFilePath.Text = "not set (path to error file)";
			this.txtErrorFilePath.TextChanged += new System.EventHandler(this.txtErrorFilePath_TextChanged);
			// 
			// groupAssLangFile
			// 
			this.groupAssLangFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupAssLangFile.Controls.Add(this.chkAddComentsAsm);
			this.groupAssLangFile.Controls.Add(this.groupNumeralSystem);
			this.groupAssLangFile.Controls.Add(this.groupEOF);
			this.groupAssLangFile.Location = new System.Drawing.Point(6, 208);
			this.groupAssLangFile.Name = "groupAssLangFile";
			this.groupAssLangFile.Size = new System.Drawing.Size(1081, 291);
			this.groupAssLangFile.TabIndex = 2;
			this.groupAssLangFile.TabStop = false;
			this.groupAssLangFile.Text = "not set (assembly language file settings)";
			// 
			// chkAddComentsAsm
			// 
			this.chkAddComentsAsm.AutoSize = true;
			this.chkAddComentsAsm.Location = new System.Drawing.Point(15, 261);
			this.chkAddComentsAsm.Name = "chkAddComentsAsm";
			this.chkAddComentsAsm.Size = new System.Drawing.Size(136, 17);
			this.chkAddComentsAsm.TabIndex = 2;
			this.chkAddComentsAsm.Text = "not set (add comments)";
			this.chkAddComentsAsm.UseVisualStyleBackColor = true;
			// 
			// groupNumeralSystem
			// 
			this.groupNumeralSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupNumeralSystem.Controls.Add(this.radioNumeralSystemOctal);
			this.groupNumeralSystem.Controls.Add(this.radioNumeralSystemHexadecimal);
			this.groupNumeralSystem.Controls.Add(this.radioNumeralSystemDecimal);
			this.groupNumeralSystem.Controls.Add(this.radioNumeralSystemBinary);
			this.groupNumeralSystem.Location = new System.Drawing.Point(10, 128);
			this.groupNumeralSystem.Name = "groupNumeralSystem";
			this.groupNumeralSystem.Size = new System.Drawing.Size(1058, 116);
			this.groupNumeralSystem.TabIndex = 1;
			this.groupNumeralSystem.TabStop = false;
			this.groupNumeralSystem.Text = "not set (numeral system)";
			// 
			// radioNumeralSystemOctal
			// 
			this.radioNumeralSystemOctal.AutoSize = true;
			this.radioNumeralSystemOctal.Location = new System.Drawing.Point(18, 42);
			this.radioNumeralSystemOctal.Name = "radioNumeralSystemOctal";
			this.radioNumeralSystemOctal.Size = new System.Drawing.Size(89, 17);
			this.radioNumeralSystemOctal.TabIndex = 3;
			this.radioNumeralSystemOctal.TabStop = true;
			this.radioNumeralSystemOctal.Text = "not set (octal)";
			this.radioNumeralSystemOctal.UseVisualStyleBackColor = true;
			this.radioNumeralSystemOctal.CheckedChanged += new System.EventHandler(this.radioNumeralSystemOctal_CheckedChanged);
			// 
			// radioNumeralSystemHexadecimal
			// 
			this.radioNumeralSystemHexadecimal.AutoSize = true;
			this.radioNumeralSystemHexadecimal.Location = new System.Drawing.Point(18, 88);
			this.radioNumeralSystemHexadecimal.Name = "radioNumeralSystemHexadecimal";
			this.radioNumeralSystemHexadecimal.Size = new System.Drawing.Size(125, 17);
			this.radioNumeralSystemHexadecimal.TabIndex = 2;
			this.radioNumeralSystemHexadecimal.TabStop = true;
			this.radioNumeralSystemHexadecimal.Text = "not set (hexadecimal)";
			this.radioNumeralSystemHexadecimal.UseVisualStyleBackColor = true;
			this.radioNumeralSystemHexadecimal.CheckedChanged += new System.EventHandler(this.radioNumeralSystemHexadecimal_CheckedChanged);
			// 
			// radioNumeralSystemDecimal
			// 
			this.radioNumeralSystemDecimal.AutoSize = true;
			this.radioNumeralSystemDecimal.Location = new System.Drawing.Point(18, 65);
			this.radioNumeralSystemDecimal.Name = "radioNumeralSystemDecimal";
			this.radioNumeralSystemDecimal.Size = new System.Drawing.Size(102, 17);
			this.radioNumeralSystemDecimal.TabIndex = 1;
			this.radioNumeralSystemDecimal.TabStop = true;
			this.radioNumeralSystemDecimal.Text = "not set (decimal)";
			this.radioNumeralSystemDecimal.UseVisualStyleBackColor = true;
			this.radioNumeralSystemDecimal.CheckedChanged += new System.EventHandler(this.radioNumeralSystemDecimal_CheckedChanged);
			// 
			// radioNumeralSystemBinary
			// 
			this.radioNumeralSystemBinary.AutoSize = true;
			this.radioNumeralSystemBinary.Location = new System.Drawing.Point(18, 19);
			this.radioNumeralSystemBinary.Name = "radioNumeralSystemBinary";
			this.radioNumeralSystemBinary.Size = new System.Drawing.Size(94, 17);
			this.radioNumeralSystemBinary.TabIndex = 0;
			this.radioNumeralSystemBinary.TabStop = true;
			this.radioNumeralSystemBinary.Text = "not set (binary)";
			this.radioNumeralSystemBinary.UseVisualStyleBackColor = true;
			this.radioNumeralSystemBinary.CheckedChanged += new System.EventHandler(this.radioNumeralSystemBinary_CheckedChanged);
			// 
			// groupEOF
			// 
			this.groupEOF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupEOF.Controls.Add(this.radioEOFMacOS);
			this.groupEOF.Controls.Add(this.radioEOFUnix);
			this.groupEOF.Controls.Add(this.radioEOFWindows);
			this.groupEOF.Location = new System.Drawing.Point(10, 25);
			this.groupEOF.Name = "groupEOF";
			this.groupEOF.Size = new System.Drawing.Size(1058, 92);
			this.groupEOF.TabIndex = 0;
			this.groupEOF.TabStop = false;
			this.groupEOF.Text = "not set (EOF)";
			// 
			// radioEOFMacOS
			// 
			this.radioEOFMacOS.AutoSize = true;
			this.radioEOFMacOS.Location = new System.Drawing.Point(18, 65);
			this.radioEOFMacOS.Name = "radioEOFMacOS";
			this.radioEOFMacOS.Size = new System.Drawing.Size(204, 17);
			this.radioEOFMacOS.TabIndex = 2;
			this.radioEOFMacOS.TabStop = true;
			this.radioEOFMacOS.Text = "Apple II, Commodore, Mac OS 9 (\"\\r\")";
			this.radioEOFMacOS.UseVisualStyleBackColor = true;
			this.radioEOFMacOS.CheckedChanged += new System.EventHandler(this.radioEOFMacOS_CheckedChanged);
			// 
			// radioEOFUnix
			// 
			this.radioEOFUnix.AutoSize = true;
			this.radioEOFUnix.Location = new System.Drawing.Point(18, 42);
			this.radioEOFUnix.Name = "radioEOFUnix";
			this.radioEOFUnix.Size = new System.Drawing.Size(405, 17);
			this.radioEOFUnix.TabIndex = 1;
			this.radioEOFUnix.TabStop = true;
			this.radioEOFUnix.Text = "Unix, Linux, Mac OS X, BSD, AIX, Xenix, BeOS, Amiga, RISC OS, Multics  (\"\\n\")";
			this.radioEOFUnix.UseVisualStyleBackColor = true;
			this.radioEOFUnix.CheckedChanged += new System.EventHandler(this.radioEOFUnix_CheckedChanged);
			// 
			// radioEOFWindows
			// 
			this.radioEOFWindows.AutoSize = true;
			this.radioEOFWindows.Location = new System.Drawing.Point(18, 19);
			this.radioEOFWindows.Name = "radioEOFWindows";
			this.radioEOFWindows.Size = new System.Drawing.Size(284, 17);
			this.radioEOFWindows.TabIndex = 0;
			this.radioEOFWindows.TabStop = true;
			this.radioEOFWindows.Text = "Microsoft Windows, CP/M, MP/M, DOS, OS/2 (\"\\r\\n\")";
			this.radioEOFWindows.UseVisualStyleBackColor = true;
			this.radioEOFWindows.CheckedChanged += new System.EventHandler(this.radioEOFWindows_CheckedChanged);
			// 
			// groupBundle
			// 
			this.groupBundle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBundle.Controls.Add(this.lblBundleGlobalStaticThings);
			this.groupBundle.Controls.Add(this.txtBundleGlobalStaticThings);
			this.groupBundle.Controls.Add(this.btnDefaultBundleNames);
			this.groupBundle.Controls.Add(this.lblGlobalNamespace);
			this.groupBundle.Controls.Add(this.txtGlobalNamespace);
			this.groupBundle.Controls.Add(this.txtBundleMainModuleName);
			this.groupBundle.Controls.Add(this.lblBundleMainModuleName);
			this.groupBundle.Controls.Add(this.txtBundleAssemblyName);
			this.groupBundle.Controls.Add(this.lblBundleAssemblyName);
			this.groupBundle.Location = new System.Drawing.Point(6, 40);
			this.groupBundle.Name = "groupBundle";
			this.groupBundle.Size = new System.Drawing.Size(1081, 162);
			this.groupBundle.TabIndex = 1;
			this.groupBundle.TabStop = false;
			this.groupBundle.Text = "not set (bundle strings)";
			// 
			// lblBundleGlobalStaticThings
			// 
			this.lblBundleGlobalStaticThings.AutoSize = true;
			this.lblBundleGlobalStaticThings.Location = new System.Drawing.Point(7, 105);
			this.lblBundleGlobalStaticThings.Name = "lblBundleGlobalStaticThings";
			this.lblBundleGlobalStaticThings.Size = new System.Drawing.Size(135, 13);
			this.lblBundleGlobalStaticThings.TabIndex = 8;
			this.lblBundleGlobalStaticThings.Text = "not set (global static things)";
			// 
			// txtBundleGlobalStaticThings
			// 
			this.txtBundleGlobalStaticThings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBundleGlobalStaticThings.Location = new System.Drawing.Point(147, 102);
			this.txtBundleGlobalStaticThings.Name = "txtBundleGlobalStaticThings";
			this.txtBundleGlobalStaticThings.Size = new System.Drawing.Size(921, 20);
			this.txtBundleGlobalStaticThings.TabIndex = 7;
			this.txtBundleGlobalStaticThings.Text = "not set";
			this.txtBundleGlobalStaticThings.TextChanged += new System.EventHandler(this.txtBundleGlobalStaticThings_TextChanged);
			// 
			// btnDefaultBundleNames
			// 
			this.btnDefaultBundleNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDefaultBundleNames.Location = new System.Drawing.Point(931, 128);
			this.btnDefaultBundleNames.Name = "btnDefaultBundleNames";
			this.btnDefaultBundleNames.Size = new System.Drawing.Size(137, 25);
			this.btnDefaultBundleNames.TabIndex = 6;
			this.btnDefaultBundleNames.Text = "not set (default)";
			this.btnDefaultBundleNames.UseVisualStyleBackColor = true;
			this.btnDefaultBundleNames.Click += new System.EventHandler(this.btnDefaultBundleNames_Click);
			// 
			// lblGlobalNamespace
			// 
			this.lblGlobalNamespace.AutoSize = true;
			this.lblGlobalNamespace.Location = new System.Drawing.Point(7, 79);
			this.lblGlobalNamespace.Name = "lblGlobalNamespace";
			this.lblGlobalNamespace.Size = new System.Drawing.Size(134, 13);
			this.lblGlobalNamespace.TabIndex = 5;
			this.lblGlobalNamespace.Text = "not set (global namespace)";
			// 
			// txtGlobalNamespace
			// 
			this.txtGlobalNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtGlobalNamespace.Location = new System.Drawing.Point(147, 76);
			this.txtGlobalNamespace.Name = "txtGlobalNamespace";
			this.txtGlobalNamespace.Size = new System.Drawing.Size(921, 20);
			this.txtGlobalNamespace.TabIndex = 4;
			this.txtGlobalNamespace.Text = "not set";
			this.txtGlobalNamespace.TextChanged += new System.EventHandler(this.txtGlobalNamespace_TextChanged);
			// 
			// txtBundleMainModuleName
			// 
			this.txtBundleMainModuleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBundleMainModuleName.Location = new System.Drawing.Point(149, 50);
			this.txtBundleMainModuleName.Name = "txtBundleMainModuleName";
			this.txtBundleMainModuleName.Size = new System.Drawing.Size(919, 20);
			this.txtBundleMainModuleName.TabIndex = 3;
			this.txtBundleMainModuleName.Text = "not set";
			this.txtBundleMainModuleName.TextChanged += new System.EventHandler(this.txtMainModuleName_TextChanged);
			// 
			// lblBundleMainModuleName
			// 
			this.lblBundleMainModuleName.AutoSize = true;
			this.lblBundleMainModuleName.Location = new System.Drawing.Point(7, 53);
			this.lblBundleMainModuleName.Name = "lblBundleMainModuleName";
			this.lblBundleMainModuleName.Size = new System.Drawing.Size(136, 13);
			this.lblBundleMainModuleName.TabIndex = 2;
			this.lblBundleMainModuleName.Text = "not set (main module name)";
			// 
			// txtBundleAssemblyName
			// 
			this.txtBundleAssemblyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBundleAssemblyName.Location = new System.Drawing.Point(132, 24);
			this.txtBundleAssemblyName.Name = "txtBundleAssemblyName";
			this.txtBundleAssemblyName.Size = new System.Drawing.Size(936, 20);
			this.txtBundleAssemblyName.TabIndex = 1;
			this.txtBundleAssemblyName.Text = "not set";
			this.txtBundleAssemblyName.TextChanged += new System.EventHandler(this.txtBundleAssemblyName_TextChanged);
			// 
			// lblBundleAssemblyName
			// 
			this.lblBundleAssemblyName.AutoSize = true;
			this.lblBundleAssemblyName.Location = new System.Drawing.Point(6, 27);
			this.lblBundleAssemblyName.Name = "lblBundleAssemblyName";
			this.lblBundleAssemblyName.Size = new System.Drawing.Size(120, 13);
			this.lblBundleAssemblyName.TabIndex = 0;
			this.lblBundleAssemblyName.Text = "not set (assembly name)";
			// 
			// lblCompilerConfNote
			// 
			this.lblCompilerConfNote.AutoSize = true;
			this.lblCompilerConfNote.Location = new System.Drawing.Point(13, 10);
			this.lblCompilerConfNote.Name = "lblCompilerConfNote";
			this.lblCompilerConfNote.Size = new System.Drawing.Size(200, 13);
			this.lblCompilerConfNote.TabIndex = 0;
			this.lblCompilerConfNote.Text = "not set (these are the compiler settings...)";
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
			this.PanelCompilation.Size = new System.Drawing.Size(1106, 157);
			this.PanelCompilation.TabIndex = 0;
			// 
			// ProgBar
			// 
			this.ProgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBar.Location = new System.Drawing.Point(6, 135);
			this.ProgBar.Name = "ProgBar";
			this.ProgBar.Size = new System.Drawing.Size(1094, 19);
			this.ProgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgBar.TabIndex = 13;
			this.ProgBar.Value = 80;
			// 
			// btnClearOutput
			// 
			this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearOutput.Location = new System.Drawing.Point(1007, 54);
			this.btnClearOutput.Name = "btnClearOutput";
			this.btnClearOutput.Size = new System.Drawing.Size(92, 23);
			this.btnClearOutput.TabIndex = 12;
			this.btnClearOutput.Text = "not set (clear output)";
			this.btnClearOutput.UseVisualStyleBackColor = true;
			this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
			// 
			// btnCompile
			// 
			this.btnCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCompile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnCompile.Location = new System.Drawing.Point(1007, 1);
			this.btnCompile.Name = "btnCompile";
			this.btnCompile.Size = new System.Drawing.Size(92, 50);
			this.btnCompile.TabIndex = 11;
			this.btnCompile.Text = "not set (compile)";
			this.btnCompile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCompile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCompile.UseVisualStyleBackColor = true;
			this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
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
			this.txtOutput.Size = new System.Drawing.Size(1100, 36);
			this.txtOutput.TabIndex = 10;
			// 
			// btnPathAsm
			// 
			this.btnPathAsm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPathAsm.Location = new System.Drawing.Point(928, 54);
			this.btnPathAsm.Name = "btnPathAsm";
			this.btnPathAsm.Size = new System.Drawing.Size(52, 23);
			this.btnPathAsm.TabIndex = 9;
			this.btnPathAsm.Text = "not set (open path asm)";
			this.btnPathAsm.UseVisualStyleBackColor = true;
			this.btnPathAsm.Click += new System.EventHandler(this.btnPathAsm_Click);
			// 
			// txtPathAsm
			// 
			this.txtPathAsm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPathAsm.Location = new System.Drawing.Point(122, 55);
			this.txtPathAsm.Name = "txtPathAsm";
			this.txtPathAsm.Size = new System.Drawing.Size(797, 20);
			this.txtPathAsm.TabIndex = 8;
			this.txtPathAsm.Text = "not set (path to asm)";
			this.txtPathAsm.TextChanged += new System.EventHandler(this.txtPathAsm_TextChanged);
			// 
			// lblPathAsm
			// 
			this.lblPathAsm.AutoSize = true;
			this.lblPathAsm.Location = new System.Drawing.Point(13, 58);
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
			this.btnPathBundle.Size = new System.Drawing.Size(52, 23);
			this.btnPathBundle.TabIndex = 6;
			this.btnPathBundle.Text = "not set (open path bundle dialog)";
			this.btnPathBundle.UseVisualStyleBackColor = true;
			this.btnPathBundle.Click += new System.EventHandler(this.btnPathBundle_Click);
			// 
			// lblPathBundle
			// 
			this.lblPathBundle.AutoSize = true;
			this.lblPathBundle.Location = new System.Drawing.Point(12, 32);
			this.lblPathBundle.Name = "lblPathBundle";
			this.lblPathBundle.Size = new System.Drawing.Size(116, 13);
			this.lblPathBundle.TabIndex = 5;
			this.lblPathBundle.Text = "not set (path to bundle)";
			// 
			// lblPathExe
			// 
			this.lblPathExe.AutoSize = true;
			this.lblPathExe.Location = new System.Drawing.Point(12, 6);
			this.lblPathExe.Name = "lblPathExe";
			this.lblPathExe.Size = new System.Drawing.Size(101, 13);
			this.lblPathExe.TabIndex = 4;
			this.lblPathExe.Text = "not set (path to exe)";
			// 
			// txtPathBundle
			// 
			this.txtPathBundle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPathBundle.Location = new System.Drawing.Point(135, 29);
			this.txtPathBundle.Name = "txtPathBundle";
			this.txtPathBundle.ReadOnly = true;
			this.txtPathBundle.Size = new System.Drawing.Size(784, 20);
			this.txtPathBundle.TabIndex = 3;
			this.txtPathBundle.Text = "not set (path to bundle)";
			this.txtPathBundle.TextChanged += new System.EventHandler(this.txtPathBundle_TextChanged);
			// 
			// btnExeInfo
			// 
			this.btnExeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExeInfo.Location = new System.Drawing.Point(957, 1);
			this.btnExeInfo.Name = "btnExeInfo";
			this.btnExeInfo.Size = new System.Drawing.Size(23, 23);
			this.btnExeInfo.TabIndex = 2;
			this.btnExeInfo.Text = "not set (info)";
			this.btnExeInfo.UseVisualStyleBackColor = true;
			this.btnExeInfo.Click += new System.EventHandler(this.btnExeInfo_Click);
			// 
			// btnOpenPathExe
			// 
			this.btnOpenPathExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenPathExe.Location = new System.Drawing.Point(928, 1);
			this.btnOpenPathExe.Name = "btnOpenPathExe";
			this.btnOpenPathExe.Size = new System.Drawing.Size(23, 23);
			this.btnOpenPathExe.TabIndex = 1;
			this.btnOpenPathExe.Text = "not set (open path exe)";
			this.btnOpenPathExe.UseVisualStyleBackColor = true;
			this.btnOpenPathExe.Click += new System.EventHandler(this.btnOpenPathExe_Click);
			// 
			// txtPathExe
			// 
			this.txtPathExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPathExe.Location = new System.Drawing.Point(119, 3);
			this.txtPathExe.Name = "txtPathExe";
			this.txtPathExe.Size = new System.Drawing.Size(800, 20);
			this.txtPathExe.TabIndex = 0;
			this.txtPathExe.Text = "not set (path to exe)";
			this.txtPathExe.TextChanged += new System.EventHandler(this.txtPathExe_TextChanged);
			// 
			// PanelCompilationConfig
			// 
			this.PanelCompilationConfig.AutoScroll = true;
			this.PanelCompilationConfig.Controls.Add(this.lblPersonalNotes);
			this.PanelCompilationConfig.Controls.Add(this.txtPersonalNotes);
			this.PanelCompilationConfig.Controls.Add(this.groupBox2);
			this.PanelCompilationConfig.Controls.Add(this.groupBox1);
			this.PanelCompilationConfig.Controls.Add(this.btnLoadCompilationConfigFile);
			this.PanelCompilationConfig.Controls.Add(this.btnSaveCompilationConfigFile);
			this.PanelCompilationConfig.Controls.Add(this.btnOpenCompilationConfigFile);
			this.PanelCompilationConfig.Controls.Add(this.lblCompilationConfigFile);
			this.PanelCompilationConfig.Controls.Add(this.txtCompilationConfigFile);
			this.PanelCompilationConfig.Controls.Add(this.lblCompilationConfNote);
			this.PanelCompilationConfig.Location = new System.Drawing.Point(3, 468);
			this.PanelCompilationConfig.Name = "PanelCompilationConfig";
			this.PanelCompilationConfig.Size = new System.Drawing.Size(1106, 288);
			this.PanelCompilationConfig.TabIndex = 2;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 793);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(1203, 22);
			this.StatusStrip.TabIndex = 2;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(41, 17);
			this.StatusLabel.Text = "not set";
			// 
			// comboLanguages
			// 
			this.comboLanguages.FormattingEnabled = true;
			this.comboLanguages.Location = new System.Drawing.Point(111, 822);
			this.comboLanguages.Name = "comboLanguages";
			this.comboLanguages.Size = new System.Drawing.Size(160, 21);
			this.comboLanguages.Sorted = true;
			this.comboLanguages.TabIndex = 26;
			this.comboLanguages.SelectedIndexChanged += new System.EventHandler(this.comboLanguages_SelectedIndexChanged);
			// 
			// lblCompilationConfNote
			// 
			this.lblCompilationConfNote.AutoSize = true;
			this.lblCompilationConfNote.Location = new System.Drawing.Point(13, 18);
			this.lblCompilationConfNote.Name = "lblCompilationConfNote";
			this.lblCompilationConfNote.Size = new System.Drawing.Size(214, 13);
			this.lblCompilationConfNote.TabIndex = 0;
			this.lblCompilationConfNote.Text = "not set (these are the compilation settings...)";
			// 
			// txtCompilationConfigFile
			// 
			this.txtCompilationConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCompilationConfigFile.Location = new System.Drawing.Point(168, 44);
			this.txtCompilationConfigFile.Name = "txtCompilationConfigFile";
			this.txtCompilationConfigFile.Size = new System.Drawing.Size(675, 20);
			this.txtCompilationConfigFile.TabIndex = 1;
			this.txtCompilationConfigFile.Text = "not set (compilation config file)";
			this.txtCompilationConfigFile.TextChanged += new System.EventHandler(this.txtCompilationConfigFile_TextChanged);
			// 
			// lblCompilationConfigFile
			// 
			this.lblCompilationConfigFile.AutoSize = true;
			this.lblCompilationConfigFile.Location = new System.Drawing.Point(13, 47);
			this.lblCompilationConfigFile.Name = "lblCompilationConfigFile";
			this.lblCompilationConfigFile.Size = new System.Drawing.Size(149, 13);
			this.lblCompilationConfigFile.TabIndex = 2;
			this.lblCompilationConfigFile.Text = "not set (compilation config file)";
			// 
			// btnOpenCompilationConfigFile
			// 
			this.btnOpenCompilationConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenCompilationConfigFile.Location = new System.Drawing.Point(849, 42);
			this.btnOpenCompilationConfigFile.Name = "btnOpenCompilationConfigFile";
			this.btnOpenCompilationConfigFile.Size = new System.Drawing.Size(23, 23);
			this.btnOpenCompilationConfigFile.TabIndex = 3;
			this.btnOpenCompilationConfigFile.Text = "not set (open path compilation config)";
			this.btnOpenCompilationConfigFile.UseVisualStyleBackColor = true;
			this.btnOpenCompilationConfigFile.Click += new System.EventHandler(this.btnOpenCompilationConfigFile_Click);
			// 
			// btnSaveCompilationConfigFile
			// 
			this.btnSaveCompilationConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveCompilationConfigFile.Enabled = false;
			this.btnSaveCompilationConfigFile.Location = new System.Drawing.Point(981, 42);
			this.btnSaveCompilationConfigFile.Name = "btnSaveCompilationConfigFile";
			this.btnSaveCompilationConfigFile.Size = new System.Drawing.Size(84, 23);
			this.btnSaveCompilationConfigFile.TabIndex = 4;
			this.btnSaveCompilationConfigFile.Text = "not set (save compilation config)";
			this.btnSaveCompilationConfigFile.UseVisualStyleBackColor = true;
			this.btnSaveCompilationConfigFile.Click += new System.EventHandler(this.btnSaveCompilationConfigFile_Click);
			// 
			// btnLoadCompilationConfigFile
			// 
			this.btnLoadCompilationConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadCompilationConfigFile.Enabled = false;
			this.btnLoadCompilationConfigFile.Location = new System.Drawing.Point(891, 42);
			this.btnLoadCompilationConfigFile.Name = "btnLoadCompilationConfigFile";
			this.btnLoadCompilationConfigFile.Size = new System.Drawing.Size(84, 23);
			this.btnLoadCompilationConfigFile.TabIndex = 5;
			this.btnLoadCompilationConfigFile.Text = "not set (load compilation config)";
			this.btnLoadCompilationConfigFile.UseVisualStyleBackColor = true;
			this.btnLoadCompilationConfigFile.Click += new System.EventHandler(this.btnLoadCompilationConfigFile_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Location = new System.Drawing.Point(6, 79);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1081, 100);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "some option here";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Location = new System.Drawing.Point(6, 193);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1081, 100);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "another option here";
			// 
			// txtPersonalNotes
			// 
			this.txtPersonalNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPersonalNotes.Location = new System.Drawing.Point(6, 321);
			this.txtPersonalNotes.Multiline = true;
			this.txtPersonalNotes.Name = "txtPersonalNotes";
			this.txtPersonalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPersonalNotes.Size = new System.Drawing.Size(1081, 230);
			this.txtPersonalNotes.TabIndex = 0;
			this.txtPersonalNotes.Text = "not set (personal notes)";
			this.txtPersonalNotes.TextChanged += new System.EventHandler(this.txtPersonalNotes_TextChanged);
			// 
			// lblPersonalNotes
			// 
			this.lblPersonalNotes.AutoSize = true;
			this.lblPersonalNotes.Location = new System.Drawing.Point(13, 305);
			this.lblPersonalNotes.Name = "lblPersonalNotes";
			this.lblPersonalNotes.Size = new System.Drawing.Size(117, 13);
			this.lblPersonalNotes.TabIndex = 8;
			this.lblPersonalNotes.Text = "not set (personal notes)";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1203, 815);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MainContainer);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(600, 400);
			this.Name = "MainWindow";
			this.Text = "not set";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Leave += new System.EventHandler(this.MainWindow_Leave);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.MainContainer.Panel1.ResumeLayout(false);
			this.MainContainer.Panel2.ResumeLayout(false);
			this.MainContainer.ResumeLayout(false);
			this.PanelCompilerConfig.ResumeLayout(false);
			this.PanelCompilerConfig.PerformLayout();
			this.groupVerbosity.ResumeLayout(false);
			this.groupVerbosity.PerformLayout();
			this.groupAssLangFile.ResumeLayout(false);
			this.groupAssLangFile.PerformLayout();
			this.groupNumeralSystem.ResumeLayout(false);
			this.groupNumeralSystem.PerformLayout();
			this.groupEOF.ResumeLayout(false);
			this.groupEOF.PerformLayout();
			this.groupBundle.ResumeLayout(false);
			this.groupBundle.PerformLayout();
			this.PanelCompilation.ResumeLayout(false);
			this.PanelCompilation.PerformLayout();
			this.PanelCompilationConfig.ResumeLayout(false);
			this.PanelCompilationConfig.PerformLayout();
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
		private System.Windows.Forms.Label lblCompilerConfNote;
		private System.Windows.Forms.GroupBox groupBundle;
		private System.Windows.Forms.TextBox txtBundleAssemblyName;
		private System.Windows.Forms.Label lblBundleAssemblyName;
		private System.Windows.Forms.TextBox txtBundleMainModuleName;
		private System.Windows.Forms.Label lblBundleMainModuleName;
		private System.Windows.Forms.TextBox txtGlobalNamespace;
		private System.Windows.Forms.Label lblGlobalNamespace;
		private System.Windows.Forms.Button btnDefaultBundleNames;
		private System.Windows.Forms.Label lblBundleGlobalStaticThings;
		private System.Windows.Forms.TextBox txtBundleGlobalStaticThings;
		private System.Windows.Forms.GroupBox groupAssLangFile;
		private System.Windows.Forms.GroupBox groupEOF;
		private System.Windows.Forms.RadioButton radioEOFWindows;
		private System.Windows.Forms.RadioButton radioEOFUnix;
		private System.Windows.Forms.RadioButton radioEOFMacOS;
		private System.Windows.Forms.GroupBox groupNumeralSystem;
		private System.Windows.Forms.RadioButton radioNumeralSystemHexadecimal;
		private System.Windows.Forms.RadioButton radioNumeralSystemDecimal;
		private System.Windows.Forms.RadioButton radioNumeralSystemBinary;
		private System.Windows.Forms.RadioButton radioNumeralSystemOctal;
		private System.Windows.Forms.CheckBox chkAddComentsAsm;
		private System.Windows.Forms.Label lblErrorFile;
		private System.Windows.Forms.TextBox txtErrorFilePath;
		private System.Windows.Forms.Button btnOpenErrorFile;
		private System.Windows.Forms.Label lblLanguage;
		private System.Windows.Forms.Label lblSummaryFile;
		private System.Windows.Forms.TextBox txtSummaryPath;
		private System.Windows.Forms.Button btnOpenSummaryFile;
		private System.Windows.Forms.Button btnOpenSymbolTableFile;
		private System.Windows.Forms.TextBox txtSymbolTablePath;
		private System.Windows.Forms.Label lblSymbolTableFile;
		private System.Windows.Forms.CheckBox chkGenerateAsmFile;
		private System.Windows.Forms.CheckBox chkGenerateSummaryFile;
		private System.Windows.Forms.CheckBox chkGenerateSymbolTable;
		private System.Windows.Forms.CheckBox chkGenerateErrorFile;
		private System.Windows.Forms.GroupBox groupVerbosity;
		private System.Windows.Forms.RadioButton radioVerbDebug;
		private System.Windows.Forms.RadioButton radioVerbVerbose;
		private System.Windows.Forms.RadioButton radioVerbQuiet;
		private System.Windows.Forms.ComboBox comboLanguages;
		private System.Windows.Forms.Label lblCompilationConfNote;
		private System.Windows.Forms.Label lblCompilationConfigFile;
		private System.Windows.Forms.TextBox txtCompilationConfigFile;
		private System.Windows.Forms.Button btnOpenCompilationConfigFile;
		private System.Windows.Forms.Button btnSaveCompilationConfigFile;
		private System.Windows.Forms.Button btnLoadCompilationConfigFile;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtPersonalNotes;
		private System.Windows.Forms.Label lblPersonalNotes;
	}
}