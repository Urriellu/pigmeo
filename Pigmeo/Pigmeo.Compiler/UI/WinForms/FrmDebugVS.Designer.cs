namespace Pigmeo.Compiler.UI.WinForms {
	partial class FrmDebugVS {
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("output #1");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("output #2");
			this.tabsDebug = new System.Windows.Forms.TabControl();
			this.tabReflectedAss = new System.Windows.Forms.TabPage();
			this.txtReflectedAss = new System.Windows.Forms.RichTextBox();
			this.tabAssInfo = new System.Windows.Forms.TabPage();
			this.txtAssInfo = new System.Windows.Forms.RichTextBox();
			this.tabOutputs = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lstOutputs = new System.Windows.Forms.ListView();
			this.txtDebugOutput = new System.Windows.Forms.RichTextBox();
			this.tabAssemblyLang = new System.Windows.Forms.TabPage();
			this.txtGenAsm = new System.Windows.Forms.RichTextBox();
			this.tabsDebug.SuspendLayout();
			this.tabReflectedAss.SuspendLayout();
			this.tabAssInfo.SuspendLayout();
			this.tabOutputs.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabAssemblyLang.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabsDebug
			// 
			this.tabsDebug.Controls.Add(this.tabReflectedAss);
			this.tabsDebug.Controls.Add(this.tabAssInfo);
			this.tabsDebug.Controls.Add(this.tabOutputs);
			this.tabsDebug.Controls.Add(this.tabAssemblyLang);
			this.tabsDebug.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabsDebug.Location = new System.Drawing.Point(0, 0);
			this.tabsDebug.Name = "tabsDebug";
			this.tabsDebug.SelectedIndex = 0;
			this.tabsDebug.Size = new System.Drawing.Size(1039, 631);
			this.tabsDebug.TabIndex = 0;
			// 
			// tabReflectedAss
			// 
			this.tabReflectedAss.Controls.Add(this.txtReflectedAss);
			this.tabReflectedAss.Location = new System.Drawing.Point(4, 22);
			this.tabReflectedAss.Name = "tabReflectedAss";
			this.tabReflectedAss.Padding = new System.Windows.Forms.Padding(3);
			this.tabReflectedAss.Size = new System.Drawing.Size(1031, 605);
			this.tabReflectedAss.TabIndex = 3;
			this.tabReflectedAss.Text = "Reflected Assembly";
			this.tabReflectedAss.UseVisualStyleBackColor = true;
			// 
			// txtReflectedAss
			// 
			this.txtReflectedAss.BackColor = System.Drawing.SystemColors.Window;
			this.txtReflectedAss.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtReflectedAss.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtReflectedAss.Location = new System.Drawing.Point(3, 3);
			this.txtReflectedAss.Name = "txtReflectedAss";
			this.txtReflectedAss.ReadOnly = true;
			this.txtReflectedAss.Size = new System.Drawing.Size(1025, 599);
			this.txtReflectedAss.TabIndex = 0;
			this.txtReflectedAss.Text = "";
			// 
			// tabAssInfo
			// 
			this.tabAssInfo.Controls.Add(this.txtAssInfo);
			this.tabAssInfo.Location = new System.Drawing.Point(4, 22);
			this.tabAssInfo.Name = "tabAssInfo";
			this.tabAssInfo.Padding = new System.Windows.Forms.Padding(3);
			this.tabAssInfo.Size = new System.Drawing.Size(1031, 605);
			this.tabAssInfo.TabIndex = 0;
			this.tabAssInfo.Text = "Assembly Information";
			this.tabAssInfo.UseVisualStyleBackColor = true;
			// 
			// txtAssInfo
			// 
			this.txtAssInfo.BackColor = System.Drawing.SystemColors.Window;
			this.txtAssInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAssInfo.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAssInfo.Location = new System.Drawing.Point(3, 3);
			this.txtAssInfo.Name = "txtAssInfo";
			this.txtAssInfo.ReadOnly = true;
			this.txtAssInfo.Size = new System.Drawing.Size(1025, 599);
			this.txtAssInfo.TabIndex = 0;
			this.txtAssInfo.Text = "";
			// 
			// tabOutputs
			// 
			this.tabOutputs.Controls.Add(this.splitContainer1);
			this.tabOutputs.Location = new System.Drawing.Point(4, 22);
			this.tabOutputs.Name = "tabOutputs";
			this.tabOutputs.Padding = new System.Windows.Forms.Padding(3);
			this.tabOutputs.Size = new System.Drawing.Size(1031, 605);
			this.tabOutputs.TabIndex = 1;
			this.tabOutputs.Text = "Debugging Outputs";
			this.tabOutputs.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lstOutputs);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtDebugOutput);
			this.splitContainer1.Size = new System.Drawing.Size(1025, 599);
			this.splitContainer1.SplitterDistance = 252;
			this.splitContainer1.TabIndex = 1;
			// 
			// lstOutputs
			// 
			this.lstOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstOutputs.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.lstOutputs.Location = new System.Drawing.Point(0, 0);
			this.lstOutputs.MultiSelect = false;
			this.lstOutputs.Name = "lstOutputs";
			this.lstOutputs.ShowGroups = false;
			this.lstOutputs.ShowItemToolTips = true;
			this.lstOutputs.Size = new System.Drawing.Size(252, 599);
			this.lstOutputs.TabIndex = 2;
			this.lstOutputs.UseCompatibleStateImageBehavior = false;
			this.lstOutputs.View = System.Windows.Forms.View.List;
			this.lstOutputs.SelectedIndexChanged += new System.EventHandler(this.lstOutputs_SelectedIndexChanged);
			// 
			// txtDebugOutput
			// 
			this.txtDebugOutput.BackColor = System.Drawing.SystemColors.Window;
			this.txtDebugOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDebugOutput.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDebugOutput.Location = new System.Drawing.Point(0, 0);
			this.txtDebugOutput.Name = "txtDebugOutput";
			this.txtDebugOutput.ReadOnly = true;
			this.txtDebugOutput.Size = new System.Drawing.Size(769, 599);
			this.txtDebugOutput.TabIndex = 0;
			this.txtDebugOutput.Text = "Here we\'ll show miscellaneous debugging outputs.";
			this.txtDebugOutput.WordWrap = false;
			// 
			// tabAssemblyLang
			// 
			this.tabAssemblyLang.Controls.Add(this.txtGenAsm);
			this.tabAssemblyLang.Location = new System.Drawing.Point(4, 22);
			this.tabAssemblyLang.Name = "tabAssemblyLang";
			this.tabAssemblyLang.Padding = new System.Windows.Forms.Padding(3);
			this.tabAssemblyLang.Size = new System.Drawing.Size(1031, 605);
			this.tabAssemblyLang.TabIndex = 2;
			this.tabAssemblyLang.Text = "Generated Assembly Lang";
			this.tabAssemblyLang.UseVisualStyleBackColor = true;
			// 
			// txtGenAsm
			// 
			this.txtGenAsm.BackColor = System.Drawing.SystemColors.Window;
			this.txtGenAsm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtGenAsm.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGenAsm.Location = new System.Drawing.Point(3, 3);
			this.txtGenAsm.Name = "txtGenAsm";
			this.txtGenAsm.ReadOnly = true;
			this.txtGenAsm.Size = new System.Drawing.Size(1025, 599);
			this.txtGenAsm.TabIndex = 0;
			this.txtGenAsm.Text = "";
			this.txtGenAsm.WordWrap = false;
			// 
			// FrmDebugVS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1039, 631);
			this.Controls.Add(this.tabsDebug);
			this.Name = "FrmDebugVS";
			this.Text = "Debugging example from Visual Studio";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmDebugVS_Load);
			this.tabsDebug.ResumeLayout(false);
			this.tabReflectedAss.ResumeLayout(false);
			this.tabAssInfo.ResumeLayout(false);
			this.tabOutputs.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tabAssemblyLang.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabsDebug;
		private System.Windows.Forms.TabPage tabAssInfo;
		private System.Windows.Forms.TabPage tabOutputs;
		private System.Windows.Forms.RichTextBox txtAssInfo;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.RichTextBox txtDebugOutput;
		private System.Windows.Forms.TabPage tabAssemblyLang;
		private System.Windows.Forms.RichTextBox txtGenAsm;
		private System.Windows.Forms.TabPage tabReflectedAss;
		private System.Windows.Forms.RichTextBox txtReflectedAss;
		private System.Windows.Forms.ListView lstOutputs;
	}
}