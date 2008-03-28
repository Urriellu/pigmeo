using System;
using System.Drawing;
using System.Windows.Forms;
using Pigmeo.Internal;
using Pigmeo.Extensions;

namespace Pigmeo.Compiler.UI.WinForms {
	public partial class MainWindow:Form {
		protected int SplitterDist = 83;

		public MainWindow() {
			ShowInfo.InfoDebug("Instantiating a new Pigmeo.Compiler.UI.WinForms.MainWindow");

			Image OpenFileIcon = Image.FromFile(config.Internal.ImagesDirectory + "/openfile.png").Scale(config.Internal.SizeIconSmallButtons, config.Internal.SizeIconSmallButtons);
			Image InfoIcon = Image.FromFile(config.Internal.ImagesDirectory + "/info.png").Scale(config.Internal.SizeIconSmallButtons, config.Internal.SizeIconSmallButtons);
			//Image SaveFileIcon = Image.FromFile(config.Internal.ImagesDirectory + "/save.png").Scale(config.Internal.SizeIconSmallButtons, config.Internal.SizeIconSmallButtons);
			Image EditIcon = Image.FromFile(config.Internal.ImagesDirectory + "/edit.png").Scale(config.Internal.SizeIconSmallButtons, config.Internal.SizeIconSmallButtons);
			Image RunIcon = Image.FromFile(config.Internal.ImagesDirectory + "/run.png").Scale(42, 42);
			Image Settings01 = Image.FromFile(config.Internal.ImagesDirectory + "/settings01.png").Scale(config.Internal.SizeIconPanelButtons, config.Internal.SizeIconPanelButtons);
			Image Settings02 = Image.FromFile(config.Internal.ImagesDirectory + "/settings02.png").Scale(config.Internal.SizeIconPanelButtons, config.Internal.SizeIconPanelButtons);

			InitializeComponent();

			#region global settings
			LoadLanguageStrings();
			PanelCompilation.Dock = PanelCompilerConfig.Dock = PanelCompilationConfig.Dock = DockStyle.Fill;
			SplitterDist = MainContainer.SplitterDistance = btnCompilationConfig.Location.X + btnCompilationConfig.Size.Width + 8;
			btnCompilation.Image = RunIcon;
			btnCompilerConfig.Image = Settings01;
			btnCompilationConfig.Image = Settings02;
			btnCompilation.Text = btnCompilationConfig.Text = btnCompilerConfig.Text = "";
			btnClearOutput.PerformClick();
			#endregion

			#region Compilation panel
			txtPathExe.Text = config.Internal.UserApp;
			txtPathBundle.Text = config.Internal.FileBundle;
			txtPathAsm.Text = config.Internal.FileAsm;
			lblProgress.Text = "0%";
			PanelCompilationConfig.Hide();
			PanelCompilerConfig.Hide();
			ProgBar.Value = 0;
			btnOpenPathExe.Text = btnPathBundle.Text = btnPathAsm.Text = btnOpenAsmEditor.Text = "";
			btnOpenPathExe.Image = btnPathBundle.Image = btnPathAsm.Image = OpenFileIcon;
			btnExeInfo.Text = "";
			btnExeInfo.Image = InfoIcon;
			btnCompile.Image = RunIcon.Scale(25, 25);
			btnOpenAsmEditor.Image = EditIcon;
			#endregion

			#region Compiler config panel
			txtBundleAssemblyName.Text = config.Internal.AssemblyName;
			txtBundleMainModuleName.Text = config.Internal.MainModuleName;
			txtGlobalNamespace.Text = config.Internal.GlobalNamespace;
			txtBundleGlobalStaticThings.Text = config.Internal.GlobalStaticThings;
			txtErrorFilePath.Text = config.Internal.FileError;
			txtSymbolTablePath.Text = config.Internal.FileSymbolTable;
			txtSummaryPath.Text = config.Internal.FileSummary;
			btnOpenErrorFile.Text = btnOpenSymbolTableFile.Text = btnOpenSummaryFile.Text = "";
			btnOpenErrorFile.Image = btnOpenSymbolTableFile.Image = btnOpenSummaryFile.Image = OpenFileIcon;
			chkGenerateErrorFile.Checked = config.Internal.GenerateErrorFile;
			chkGenerateSymbolTable.Checked = config.Internal.GenerateSymbolTableFile;
			chkGenerateSummaryFile.Checked = config.Internal.GenerateSummaryFile;
			chkGenerateAsmFile.Checked = config.Internal.GenerateAsmFile;
			switch(config.Internal.EndOfLine) {
				case LineEndings.Unix:
					radioEOFUnix.Checked = true;
					break;
				case LineEndings.MacOS9:
					radioEOFMacOS.Checked = true;
					break;
				default:
					radioEOFWindows.Checked = true;
					break;
			}
			switch(config.Internal.NumeralSystem) {
				case NumeralSystems.Binary:
					radioNumeralSystemBinary.Checked = true;
					break;
				case NumeralSystems.Octal:
					radioNumeralSystemOctal.Checked = true;
					break;
				case NumeralSystems.Decimal:
					radioNumeralSystemDecimal.Checked = true;
					break;
				case NumeralSystems.Hexadecimal:
					radioNumeralSystemHexadecimal.Checked = true;
					break;
				default:
					radioNumeralSystemHexadecimal.Checked = true;
					break;
			}
			switch(config.Internal.Verbosity) {
				case VerbosityLevel.Quiet:
					radioVerbQuiet.Checked = true;
					break;
				case VerbosityLevel.Verbose:
					radioVerbVerbose.Checked = true;
					break;
				case VerbosityLevel.Debug:
					radioVerbDebug.Checked = true;
					break;
				default:
					radioVerbDebug.Checked = true;
					break;
			}
			foreach(string lang in i18n.AvailableLanguages) {
				int index = comboLanguages.Items.Add(System.Globalization.CultureInfo.GetCultureInfo(lang).NativeName);
				if(lang == i18n.CurrentLanguage) comboLanguages.SelectedIndex = index;
			}
			#endregion

			#region Compilation config panel
			btnOpenCompilationConfigFile.Text = "";
			btnOpenCompilationConfigFile.Image = OpenFileIcon;
			txtCompilationConfigFile.Text = config.Internal.CompilationConfigFile;
			txtPersonalNotes.Text = config.Compilation.PersonalNotes;
			#endregion
		}

		/// <summary>
		/// Loads all language-dependent strings shown in the window
		/// </summary>
		public void LoadLanguageStrings() {
			ShowInfo.InfoDebug("Loading language strings (WinForms interface)");

			#region global
			this.Text = config.Internal.AppName;
			MenuItem001.Text = i18n.str(1);
			MenuItem002.Text = i18n.str(2);
			MenuItem003.Text = i18n.str(3);
			MenuItem004.Text = i18n.str(6);
			MenuItem005.Text = i18n.str(4, config.Internal.AppName);
			MenuItem006.Text = i18n.str(14);
			MenuItem007.Text = i18n.str(20);
			MenuItem008.Text = i18n.str(21);
			MenuItem009.Text = i18n.str(22);
			MenuItem010.Text = i18n.str(23);
			StatusLabel.Text = i18n.str(52);
			btnCompilation.Tag = i18n.str(21);
			btnCompilerConfig.Tag = i18n.str(22);
			btnCompilationConfig.Tag = i18n.str(23);
			#endregion

			#region compilation panel
			lblPathExe.Text = i18n.str(15);
			lblPathBundle.Text = i18n.str(16);
			lblPathBundle.Tag = i18n.str(17);
			lblPathAsm.Text = i18n.str(18);
			lblPathAsm.Tag = i18n.str(19);
			btnCompile.Text = i18n.str(24);
			btnClearOutput.Text = i18n.str(25);
			#endregion

			#region compiler config panel
			lblCompilerConfNote.Text = i18n.str(53);
			groupBundle.Text = i18n.str(54);
			lblBundleAssemblyName.Text = i18n.str(55);
			lblBundleMainModuleName.Text = i18n.str(56);
			lblGlobalNamespace.Text = i18n.str(57);
			lblBundleGlobalStaticThings.Text = i18n.str(58);
			btnDefaultBundleNames.Text = i18n.str(59);
			groupAssLangFile.Text = i18n.str(60);
			groupEOF.Text = i18n.str(61);
			groupNumeralSystem.Text = i18n.str(62);
			radioNumeralSystemBinary.Text = i18n.str(63);
			radioNumeralSystemDecimal.Text = i18n.str(64);
			radioNumeralSystemHexadecimal.Text = i18n.str(65);
			radioNumeralSystemOctal.Text = i18n.str(66);
			chkAddComentsAsm.Text = i18n.str(67);
			lblErrorFile.Text = i18n.str(68);
			lblSymbolTableFile.Text = i18n.str(69);
			lblSummaryFile.Text = i18n.str(70);
			chkGenerateErrorFile.Text = i18n.str(77);
			chkGenerateSymbolTable.Text = i18n.str(78);
			chkGenerateSummaryFile.Text = i18n.str(79);
			chkGenerateAsmFile.Text = i18n.str(80);
			groupVerbosity.Text = i18n.str(81);
			radioVerbQuiet.Text = i18n.str(82);
			radioVerbVerbose.Text = i18n.str(83);
			radioVerbDebug.Text = i18n.str(84);
			lblLanguage.Text = i18n.str(85);
			#endregion

			#region compilation config panel
			lblCompilationConfNote.Text = i18n.str(86);
			btnLoadCompilationConfigFile.Text = i18n.str(90);
			btnSaveCompilationConfigFile.Text = i18n.str(91);
			lblCompilationConfigFile.Text = i18n.str(95);
			lblPersonalNotes.Text = i18n.str(99);
			#endregion

			ResizeControls();
		}

		/// <summary>
		/// Resizes the controls to adapt them to language-dependent sizes
		/// </summary>
		protected void ResizeControls() {
			ShowInfo.InfoDebug("Resizing controls of the WinForms GUI");

			#region compilation panel
			ResizeTxtBoxRespectToLabel(txtPathExe, lblPathExe);
			ResizeTxtBoxRespectToLabel(txtPathBundle, lblPathBundle);
			ResizeTxtBoxRespectToLabel(txtPathAsm, lblPathAsm);
			#endregion

			#region compiler settings panel
			ResizeTxtBoxRespectToLabel(txtBundleAssemblyName, lblBundleAssemblyName);
			ResizeTxtBoxRespectToLabel(txtBundleMainModuleName, lblBundleMainModuleName);
			ResizeTxtBoxRespectToLabel(txtGlobalNamespace, lblGlobalNamespace);
			ResizeTxtBoxRespectToLabel(txtBundleGlobalStaticThings, lblBundleGlobalStaticThings);

			ResizeTxtBoxRespectToLabel(txtErrorFilePath, lblErrorFile);
			ResizeTxtBoxRespectToLabel(txtSymbolTablePath, lblSymbolTableFile);
			ResizeTxtBoxRespectToLabel(txtSummaryPath, lblSummaryFile);

			comboLanguages.Location = new Point(lblLanguage.Location.X + lblLanguage.Size.Width + 5, comboLanguages.Location.Y);
			#endregion

			#region compilation settings panel
			ResizeTxtBoxRespectToLabel(txtCompilationConfigFile, lblCompilationConfigFile);
			#endregion
		}

		protected void ResizeTxtBoxRespectToLabel(TextBox txtbx, Label lbl) {
			Size OldLocation = (Size)txtbx.Location;
			txtbx.Location = new Point(lbl.Location.X + lbl.Size.Width + 5, txtbx.Location.Y);
			txtbx.Size -= (Size)(txtbx.Location - OldLocation);
		}

		/// <summary>
		/// Selects the corrects values in the compilation settings panel, based on the variables from config.Compilation
		/// </summary>
		[PigmeoToDo("Unimplemented")]
		protected void UpdateCompilationSettings() {
		}

		private void MenuItem003_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void MenuItem002_Click(object sender, EventArgs e) {
			btnOpenPathExe.PerformClick();
		}

		protected void Unimplemented() {
			MessageBox.Show(i18n.str(13), i18n.str(12), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void MenuItem005_Click(object sender, EventArgs e) {
			AboutWindow abw = new AboutWindow();
			abw.ShowDialog();
		}

		private void MenuItem006_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start(config.Internal.PrjWebsite);
		}

		private void btnOpenPathExe_Click(object sender, EventArgs e) {
			OpenFileDialog OpenDialog = new OpenFileDialog();
			OpenDialog.Title = i18n.str(92);
			OpenDialog.InitialDirectory = config.Internal.WorkingDirectory;
			OpenDialog.Filter = i18n.str(93);
			OpenDialog.FilterIndex = 0;
			OpenDialog.RestoreDirectory = false;
			if(OpenDialog.ShowDialog() == DialogResult.OK) {
				txtPathExe.Text = OpenDialog.FileName;
				txtPathBundle.Text = System.IO.Path.GetDirectoryName(txtPathExe.Text) + "/" + System.IO.Path.GetFileNameWithoutExtension(txtPathExe.Text) + "-bundle.exe";
				txtPathAsm.Text = System.IO.Path.GetDirectoryName(txtPathExe.Text) + "/" + System.IO.Path.GetFileNameWithoutExtension(txtPathExe.Text) + ".asm";
				GlobalShares.CompilationProgress = 0;
			}
		}

		private void txtPathExe_TextChanged(object sender, EventArgs e) {
			config.Internal.UserApp = txtPathExe.Text;
		}

		private void txtPathBundle_TextChanged(object sender, EventArgs e) {
			config.Internal.FileBundle = txtPathBundle.Text;
		}

		private void txtPathAsm_TextChanged(object sender, EventArgs e) {
			config.Internal.FileAsm = txtPathAsm.Text;
		}

		private void btnCompilation_Click(object sender, EventArgs e) {
			PanelCompilation.Show();
			PanelCompilerConfig.Hide();
			PanelCompilationConfig.Hide();
		}

		private void btnCompilerConfig_Click(object sender, EventArgs e) {
			PanelCompilation.Hide();
			PanelCompilerConfig.Show();
			PanelCompilationConfig.Hide();
		}

		private void btnCompilationConfig_Click(object sender, EventArgs e) {
			PanelCompilation.Hide();
			PanelCompilerConfig.Hide();
			PanelCompilationConfig.Show();
		}

		private void btnPathBundle_Click(object sender, EventArgs e) {
			SaveFileDialog SaveDialog = new SaveFileDialog();
			SaveDialog.InitialDirectory = config.Internal.WorkingDirectory;
			SaveDialog.Title = i18n.str(94);
			SaveDialog.Filter = i18n.str(93);
			SaveDialog.FilterIndex = 0;
			SaveDialog.RestoreDirectory = false;
			if(SaveDialog.ShowDialog() == DialogResult.OK) {
				txtPathBundle.Text = SaveDialog.FileName;
			}
		}

		private void btnPathAsm_Click(object sender, EventArgs e) {
			SaveFileDialog SaveDialog = new SaveFileDialog();
			SaveDialog.InitialDirectory = config.Internal.WorkingDirectory;
			SaveDialog.Title = i18n.str(96); ;
			SaveDialog.Filter = i18n.str(97); ;
			SaveDialog.FilterIndex = 0;
			SaveDialog.RestoreDirectory = false;
			if(SaveDialog.ShowDialog() == DialogResult.OK) {
				txtPathAsm.Text = SaveDialog.FileName;
			}
		}

		private void btnExeInfo_Click(object sender, EventArgs e) {
			Unimplemented();
		}

		private void btnCompile_Click(object sender, EventArgs e) {
			StatusLabel.Text = i18n.str(129);
			txtOutput.Clear();
			GlobalShares.Compile();
			StatusLabel.Text = i18n.str(130);
		}

		private void btnClearOutput_Click(object sender, EventArgs e) {
			txtOutput.Clear();
			StatusLabel.Text = "";
			GlobalShares.CompilationProgress = 0;
		}

		private void MenuItem008_Click(object sender, EventArgs e) {
			btnCompilation.PerformClick();
		}

		private void MenuItem009_Click(object sender, EventArgs e) {
			btnCompilerConfig.PerformClick();
		}

		private void MenuItem010_Click(object sender, EventArgs e) {
			btnCompilationConfig.PerformClick();
		}

		private void MainContainer_SizeChanged(object sender, EventArgs e) {
			MainContainer.SplitterDistance = SplitterDist;
		}

		private void txtBundleAssemblyName_TextChanged(object sender, EventArgs e) {
			config.Internal.AssemblyName = txtBundleAssemblyName.Text;
		}

		private void txtMainModuleName_TextChanged(object sender, EventArgs e) {
			config.Internal.MainModuleName = txtBundleMainModuleName.Text;
		}

		private void txtGlobalNamespace_TextChanged(object sender, EventArgs e) {
			config.Internal.GlobalNamespace = txtGlobalNamespace.Text;
		}

		private void btnDefaultBundleNames_Click(object sender, EventArgs e) {
			txtBundleAssemblyName.Text = "PigmeoBundle";
			txtBundleMainModuleName.Text = "BundleMainModule";
			txtGlobalNamespace.Text = "GlobalNamespace";
			txtBundleGlobalStaticThings.Text = "GlobalThings";
		}

		private void txtBundleGlobalStaticThings_TextChanged(object sender, EventArgs e) {
			config.Internal.GlobalStaticThings = txtBundleGlobalStaticThings.Text;
		}

		private void radioEOFWindows_CheckedChanged(object sender, EventArgs e) {
			if(radioEOFWindows.Checked) config.Internal.EndOfLine = LineEndings.Windows;
		}

		private void radioEOFUnix_CheckedChanged(object sender, EventArgs e) {
			if(radioEOFUnix.Checked) config.Internal.EndOfLine = LineEndings.Unix;
		}

		private void radioEOFMacOS_CheckedChanged(object sender, EventArgs e) {
			if(radioEOFMacOS.Checked) config.Internal.EndOfLine = LineEndings.MacOS9;
		}

		private void radioNumeralSystemBinary_CheckedChanged(object sender, EventArgs e) {
			if(radioNumeralSystemBinary.Checked) config.Internal.NumeralSystem = NumeralSystems.Binary;
		}

		private void radioNumeralSystemOctal_CheckedChanged(object sender, EventArgs e) {
			if(radioNumeralSystemOctal.Checked) config.Internal.NumeralSystem = NumeralSystems.Octal;
		}

		private void radioNumeralSystemDecimal_CheckedChanged(object sender, EventArgs e) {
			if(radioNumeralSystemDecimal.Checked) config.Internal.NumeralSystem = NumeralSystems.Decimal;
		}

		private void radioNumeralSystemHexadecimal_CheckedChanged(object sender, EventArgs e) {
			if(radioNumeralSystemHexadecimal.Checked) config.Internal.NumeralSystem = NumeralSystems.Hexadecimal;
		}

		private void txtErrorFilePath_TextChanged(object sender, EventArgs e) {
			config.Internal.FileError = txtErrorFilePath.Text;
		}

		private void txtSymbolTablePath_TextChanged(object sender, EventArgs e) {
			config.Internal.FileSymbolTable = txtSymbolTablePath.Text;
		}

		private void txtSymmaryPath_TextChanged(object sender, EventArgs e) {
			config.Internal.FileSummary = txtSummaryPath.Text;
		}

		private void btnOpenErrorFile_Click(object sender, EventArgs e) {
			SaveFileDialog SaveDialog = new SaveFileDialog();
			SaveDialog.InitialDirectory = config.Internal.WorkingDirectory;
			SaveDialog.Title = i18n.str(71);
			SaveDialog.Filter = i18n.str(72);
			SaveDialog.FilterIndex = 0;
			SaveDialog.RestoreDirectory = false;
			if(SaveDialog.ShowDialog() == DialogResult.OK) {
				txtErrorFilePath.Text = SaveDialog.FileName;
			}
		}

		private void btnOpenSymbolTableFile_Click(object sender, EventArgs e) {
			SaveFileDialog SaveDialog = new SaveFileDialog();
			SaveDialog.InitialDirectory = config.Internal.WorkingDirectory;
			SaveDialog.Title = i18n.str(73);
			SaveDialog.Filter = i18n.str(74);
			SaveDialog.FilterIndex = 0;
			SaveDialog.RestoreDirectory = false;
			if(SaveDialog.ShowDialog() == DialogResult.OK) {
				txtSymbolTablePath.Text = SaveDialog.FileName;
			}
		}

		private void btnOpenSummaryFile_Click(object sender, EventArgs e) {
			SaveFileDialog SaveDialog = new SaveFileDialog();
			SaveDialog.InitialDirectory = config.Internal.WorkingDirectory;
			SaveDialog.Title = i18n.str(75);
			SaveDialog.Filter = i18n.str(76);
			SaveDialog.FilterIndex = 0;
			SaveDialog.RestoreDirectory = false;
			if(SaveDialog.ShowDialog() == DialogResult.OK) {
				txtSummaryPath.Text = SaveDialog.FileName;
			}
		}

		private void chkGenerateErrorFile_CheckedChanged(object sender, EventArgs e) {
			config.Internal.GenerateErrorFile = chkGenerateErrorFile.Checked;
		}

		private void chkGenerateSymbolTable_CheckedChanged(object sender, EventArgs e) {
			config.Internal.GenerateSymbolTableFile = chkGenerateSymbolTable.Checked;
		}

		private void chkGenerateSummaryFile_CheckedChanged(object sender, EventArgs e) {
			config.Internal.GenerateSummaryFile = chkGenerateSummaryFile.Checked;
		}

		private void chkGenerateAsmFile_CheckedChanged(object sender, EventArgs e) {
			config.Internal.GenerateAsmFile = chkGenerateAsmFile.Checked;
		}

		private void radioVerbQuiet_CheckedChanged(object sender, EventArgs e) {
			if(radioVerbQuiet.Checked) config.Internal.Verbosity = VerbosityLevel.Quiet;
		}

		private void radioVerbVerbose_CheckedChanged(object sender, EventArgs e) {
			if(radioVerbVerbose.Checked) config.Internal.Verbosity = VerbosityLevel.Verbose;
		}

		private void radioVerbDebug_CheckedChanged(object sender, EventArgs e) {
			if(radioVerbDebug.Checked) config.Internal.Verbosity = VerbosityLevel.Debug;
		}

		private void comboLanguages_SelectedIndexChanged(object sender, EventArgs e) {
			config.Internal.lang = i18n.GetLangFromNativeName((string)comboLanguages.SelectedItem);
		}

		private void btnOpenCompilationConfigFile_Click(object sender, EventArgs e) {
			OpenFileDialog OpenDialog = new OpenFileDialog();
			OpenDialog.Title = i18n.str(88);
			OpenDialog.InitialDirectory = config.Internal.WorkingDirectory;
			OpenDialog.Filter = i18n.str(89);
			OpenDialog.FilterIndex = 0;
			OpenDialog.RestoreDirectory = false;
			if(OpenDialog.ShowDialog() == DialogResult.OK) {
				txtCompilationConfigFile.Text = OpenDialog.FileName;
			}
		}

		private void txtCompilationConfigFile_TextChanged(object sender, EventArgs e) {
			config.Internal.CompilationConfigFile = txtCompilationConfigFile.Text;
		}

		private void btnLoadCompilationConfigFile_Click(object sender, EventArgs e) {
			config.Compilation.ReadCompilationConfigFile();
			UpdateCompilationSettings();
		}

		private void btnSaveCompilationConfigFile_Click(object sender, EventArgs e) {
			config.Compilation.SaveCompilationConfigFile();
		}

		private void txtPersonalNotes_TextChanged(object sender, EventArgs e) {
			config.Compilation.PersonalNotes = txtPersonalNotes.Text;
		}

		[PigmeoToDo("Choose architecture on-the-fly")]
		private void btnOpenAsmEditor_Click(object sender, EventArgs e) {
			UIs.WinFormsAsmEditor = new AsmEditorWindow(txtPathAsm.Text, Architecture.PIC14);
			UIs.WinFormsAsmEditor.ShowDialog(this);
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
			config.Internal.SaveCompilerConfigFile();
		}

		private void txtOutput_LinkClicked(object sender, LinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(e.LinkText);
		}

	}
}
