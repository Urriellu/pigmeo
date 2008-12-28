using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.UI.WinForms {
	public partial class AsmEditorWindow:Form {
		protected string file;
		protected Architecture arch;

		/// <summary>
		/// The text contained in the file. This variable is required by AsmEditorWindow_FormClosing()
		/// </summary>
		protected string FileContents;

		protected bool DontSave = false;

		public AsmEditorWindow(string file, Architecture arch) {
			InitializeComponent();
			LoadLanguageStrings();
			this.file = file;
			this.arch = arch;
			LoadFile();
		}

		protected void LoadLanguageStrings() {
			this.Text = i18n.str(117);
			MenuItem001.Text = i18n.str(1);
			MenuItem002.Text = i18n.str(90);
			MenuItem003.Text = i18n.str(91);
			MenuItem004.Text = i18n.str(3);
			MenuItem005.Text = i18n.str(118);
			MenuItem006.Text = i18n.str(119);
			MenuItem007.Text = i18n.str(120);
			MenuItem008.Text = i18n.str(121);
			MenuItem009.Text = i18n.str(122);
			MenuItem010.Text = i18n.str(123);
			MenuItem011.Text = i18n.str(124);
			MenuItem012.Text = i18n.str(125);
			MenuItem013.Text = i18n.str(126);
			MenuItem014.Text = i18n.str(127);
		}

		protected void LoadFile() {
			rtxtEditorText.Clear();
			TextReader tr = new StreamReader(file);
			FileContents = tr.ReadToEnd();
			rtxtEditorText.Text = FileContents;
			tr.Close();
		}

		protected void SaveFile() {
			TextWriter tw = new StreamWriter(file);
			FileContents = rtxtEditorText.Text;
			foreach(string line in rtxtEditorText.Text.Split(LineEndings.LineEndingsArray, StringSplitOptions.None)) {
				tw.WriteLine(line);
			}
			tw.Close();
		}

		/// <summary>
		/// Highlights the syntax in the RichTextBox
		/// </summary>
		[PigmeoToDo("This is a fast-coded dirty implementation. It must be rewritten in a proper way, supporting more types of assembly language, and more things")]
		protected void SyntaxHighlight() {
			switch(arch) {
				case Architecture.PIC:
					SyntaxHighlightPIC();
					break;
			}
		}

		[PigmeoToDo("This is a fast-coded dirty implementation. It must be rewritten in a proper way, supporting more types of assembly language, and more things")]
		protected void SyntaxHighlightPIC() {
			string[] keywords = { "INCLUDE", "ORG", "END", "__CONFIG", "CONSTANT", "DB", "DE", "DEFINE", "DT", "ELSE",
								"ENDC", "ENDIF", "ENDW", "EQU", "IF", "IFDEF", "IFNDEF", "PROCESSOR", "SET",
								"UNDEFINE", "VARIABLE", "WHILE"};
			string[] instructions = { "ADDWF", "ANDLW", "BCF", "BSF", "BTFSC", "BTFSS", "CALL", "CBLOCK", "CLRF",
									"CLRW", "CLRWDT", "COMF", "DECFSZ", "GOTO", "INCF", "INCFSZ", "IORLW",
									"IORWF", "MOVF", "MOVLW", "NOP", "RETFIE", "RETLW", "RETURN", "RLF", "RRF", "SUBLW",
									"SUBWF", "SWAPF", "XORLW", "XORWF", "MOVWF"};
			Color KeywordColor = Color.Green;
			Color InstructionColor = Color.Blue;

			foreach(string kwrd in keywords) {
				int pos = rtxtEditorText.Find(kwrd, RichTextBoxFinds.WholeWord);
				int LastPos = pos + kwrd.Length;
				while(pos >= 0) {
					rtxtEditorText.Select(pos, kwrd.Length);
					rtxtEditorText.SelectionColor = KeywordColor;

					pos = rtxtEditorText.Find(kwrd, LastPos, RichTextBoxFinds.WholeWord);
					LastPos = pos + kwrd.Length;
				}
			}
			foreach(string instr in instructions) {
				int pos = rtxtEditorText.Find(instr, RichTextBoxFinds.WholeWord);
				int LastPos = pos + instr.Length;
				while(pos >= 0) {
					rtxtEditorText.Select(pos, instr.Length);
					rtxtEditorText.SelectionColor = InstructionColor;

					pos = rtxtEditorText.Find(instr, LastPos, RichTextBoxFinds.WholeWord);
					LastPos = pos + instr.Length;
				}
			}
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
			if(rtxtEditorText.WordWrap == true) {
				rtxtEditorText.WordWrap = false;
				rtxtEditorText.ScrollBars = RichTextBoxScrollBars.Both;
			} else {
				rtxtEditorText.WordWrap = true;
				rtxtEditorText.ScrollBars = RichTextBoxScrollBars.Vertical;
			}
		}

		private void MenuItem010_Click(object sender, EventArgs e) {
			rtxtEditorText.Paste();
		}

		private void MenuItem006_Click(object sender, EventArgs e) {
			rtxtEditorText.Undo();
		}

		[Pigmeo.Internal.PigmeoToDo("Unimplemented")]
		private void MenuItem007_Click(object sender, EventArgs e) {
		}

		private void MenuItem008_Click(object sender, EventArgs e) {
			rtxtEditorText.Cut();
		}

		private void MenuItem009_Click(object sender, EventArgs e) {
			rtxtEditorText.Copy();
		}

		private void MenuItem011_Click(object sender, EventArgs e) {
			rtxtEditorText.SelectedText = "";
		}

		private void AsmEditorWindow_FormClosing(object sender, FormClosingEventArgs e) {
			if(rtxtEditorText.Text!=FileContents && !DontSave) {
				switch(MessageBox.Show(i18n.str(116, file), i18n.str(115), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3)) {
					case DialogResult.Yes:
						SaveFile();
						break;
					case DialogResult.No:
						DontSave = true;
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
		}

		private void MenuItem012_Click(object sender, EventArgs e) {
			rtxtEditorText.SelectAll();
		}

		private void rtxtEditorText_TextChanged(object sender, EventArgs e) {
			SyntaxHighlight();
		}
	}
}
