using System;
using System.Drawing;
using System.Windows.Forms;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.UI.WinForms {
	public partial class MainWindow:Form {
		public MainWindow() {
			InitializeComponent();
			this.Size = new Size(650, 450);
			LoadLanguageStrings();
			PanelCompilation.Dock = PanelCompilerConfig.Dock = PanelCompilationConfig.Dock = DockStyle.Fill;
			txtPathExe.Text = config.Internal.UserApp;
			txtPathBundle.Text = config.Internal.FileBundle;
			txtPathAsm.Text = config.Internal.FileAsm;
			PanelCompilationConfig.Hide();
			PanelCompilerConfig.Hide();
		}

		/// <summary>
		/// Loads all language-dependent strings shown in the window
		/// </summary>
		protected void LoadLanguageStrings(){
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
			lblPathExe.Text = i18n.str(15);
			lblPathBundle.Text = i18n.str(16);
			lblPathBundle.Tag = i18n.str(17);
			lblPathAsm.Text = i18n.str(18);
			lblPathAsm.Tag = i18n.str(19);
			btnCompilation.Text = i18n.str(21);
			btnCompilerConfig.Text = i18n.str(22);
			btnCompilationConfig.Text = i18n.str(23);
			btnCompile.Text = i18n.str(24);
			btnClearOutput.Text = i18n.str(25);

			ResizeControls();
		}

		/// <summary>
		/// Resizes the controls to adapt them to language-dependent sizes
		/// </summary>
		protected void ResizeControls() {
			Size OldLocation;
			
			OldLocation = (Size)txtPathExe.Location;
			txtPathExe.Location = new Point(lblPathExe.Location.X + lblPathExe.Size.Width + 5, txtPathExe.Location.Y);
			txtPathExe.Size -= (Size)(txtPathExe.Location - OldLocation);

			OldLocation = (Size)txtPathBundle.Location;
			txtPathBundle.Location = new Point(lblPathBundle.Location.X + lblPathBundle.Size.Width + 5, txtPathBundle.Location.Y);
			txtPathBundle.Size -= (Size)(txtPathBundle.Location - OldLocation);

			OldLocation = (Size)txtPathAsm.Location;
			txtPathAsm.Location = new Point(lblPathAsm.Location.X + lblPathAsm.Size.Width + 5, txtPathAsm.Location.Y);
			txtPathAsm.Size -= (Size)(txtPathAsm.Location - OldLocation);
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
			OpenDialog.Title = "Select a .NET executable to compile";
			OpenDialog.InitialDirectory = config.Internal.WorkingDirectory;
			OpenDialog.Filter = ".NET executable files (*.exe)|*.exe|All files (*.*)|*.*";
			OpenDialog.FilterIndex = 0;
			OpenDialog.RestoreDirectory = false;
			if(OpenDialog.ShowDialog() == DialogResult.OK) {
				txtPathExe.Text = OpenDialog.FileName;
				txtPathBundle.Text = System.IO.Path.GetDirectoryName(txtPathExe.Text) + "/" + System.IO.Path.GetFileNameWithoutExtension(txtPathExe.Text) + "-bundle.exe";
				txtPathAsm.Text = System.IO.Path.GetDirectoryName(txtPathExe.Text) + "/" + System.IO.Path.GetFileNameWithoutExtension(txtPathExe.Text) + ".asm";
				if(config.Internal.UI == UserInterface.WinForms) UI.UIs.WinFormsMainWindow.ProgBar.Value = 0;
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
			SaveDialog.Title = "Select a destination for the bundle";
			SaveDialog.Filter = ".NET executable files (*.exe)|*.exe|All files (*.*)|*.*";
			SaveDialog.FilterIndex = 0;
			SaveDialog.RestoreDirectory = false;
			if(SaveDialog.ShowDialog() == DialogResult.OK) {
				txtPathBundle.Text = SaveDialog.FileName;
			}
		}

		private void btnPathAsm_Click(object sender, EventArgs e) {
			SaveFileDialog SaveDialog = new SaveFileDialog();
			SaveDialog.InitialDirectory = config.Internal.WorkingDirectory;
			SaveDialog.Title = "Select a destination file for the assembly language";
			SaveDialog.Filter = "Assembly language files (*.asm)|*.asm|All files (*.*)|*.*";
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
			txtOutput.Text = "";
			GlobalShares.Compile();
		}

		private void btnClearOutput_Click(object sender, EventArgs e) {
			txtOutput.Clear();
			ProgBar.Value = 0;
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
			MainContainer.SplitterDistance = 83;
		}

	}
}
