using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Pigmeo.Compiler.UI.WinForms {
	public partial class AsmEditorWindow:Form {
		protected string file;

		public AsmEditorWindow(string file) {
			InitializeComponent();
			this.file = file;
			LoadFile();
		}

		protected void LoadFile() {
			txtEditorText.Clear();
			TextReader tr = new StreamReader(file);
			bool EOF = false;
			while(!EOF) {
				try {
					txtEditorText.Text += tr.ReadLine() + Environment.NewLine;
				} catch(ArgumentOutOfRangeException) {
					EOF = true;
				}
			}
			tr.Close();
		}

		protected void SaveFile() {
		}

		private void MenuItem002_Click(object sender, EventArgs e) {
			LoadFile();
		}

		private void MenuItem004_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void MenuItem003_Click(object sender, EventArgs e) {
			SaveFile();
		}

		private void MenuItem014_Click(object sender, EventArgs e) {
			if(txtEditorText.WordWrap == true) {
				txtEditorText.WordWrap = false;
				txtEditorText.ScrollBars = ScrollBars.Both;
			} else {
				txtEditorText.WordWrap = true;
				txtEditorText.ScrollBars = ScrollBars.Vertical;
			}
		}
	}
}
