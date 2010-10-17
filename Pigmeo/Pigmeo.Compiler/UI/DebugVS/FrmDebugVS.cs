using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.UI.WinForms {
	public partial class FrmDebugVS:Form {
		readonly List<OutputBlock> Outputs;

		public FrmDebugVS(List<OutputBlock> Outputs) {
			InitializeComponent();
			this.Outputs = Outputs;
		}

		private void FrmDebugVS_Load(object sender, EventArgs e) {
			lstOutputs.Items.Clear();
			tabsDebug.SelectTab(tabOutputs);
			UpdateLstOutputs();
		}

		public void UpdateLstOutputs() {
			ListViewItem LastSelectedItem = (lstOutputs.SelectedItems.Count > 0) ? lstOutputs.SelectedItems[0] : null;
			txtDebugOutput.Clear();
			lstOutputs.Items.Clear();
			foreach(var item in Outputs) {
				//if(Outputs[Outputs.Count-1] != item) {
					lstOutputs.Items.Add(item.Title);
					lstOutputs.Items[lstOutputs.Items.Count - 1].Tag = item.Name;
				//}
			}
			if(lstOutputs.Items.Count > 0) lstOutputs.Items[0].Selected = true;
			Refresh();
		}

		Color Color1 = Color.Blue;
		Color Color2 = Color.DarkGreen;

		/// <summary>
		/// One output-message block is selected. Show it on the right
		/// </summary>
		private void lstOutputs_SelectedIndexChanged(object sender, EventArgs e) {
			Color currentColor = Color2;
			if(lstOutputs.SelectedIndices.Count > 0) {
				int ind = lstOutputs.SelectedIndices[0];
				foreach(var msg in Outputs[ind].Messages) {
					//invert current colors
					if(currentColor == Color1) currentColor = Color2;
					else currentColor = Color1;

					int first = txtDebugOutput.Text.Length;
					if(!string.IsNullOrEmpty(msg.Key)) txtDebugOutput.AppendText(msg.Key + ":" + Environment.NewLine);
					txtDebugOutput.AppendText(msg.Value + Environment.NewLine);
					txtDebugOutput.Select(first, txtDebugOutput.Text.Length - 1);
					txtDebugOutput.SelectionColor = currentColor;
				}
			} else txtDebugOutput.Clear();
		}

		public void SetReflectedAssembly(PRefl.Assembly ReflectedAssembly) {
			txtReflectedAss.Clear();
			txtReflectedAss.Text = ReflectedAssembly.ToString();
		}

		public void SetAsm(string[] AsmCode) {
			txtGenAsm.Clear();
			foreach(string line in AsmCode) {
				txtGenAsm.AppendText(line + Environment.NewLine);
			}
		}

		internal void SetExeInfo(List<string> info) {
			txtAssInfo.Clear();
			foreach(string line in info) {
				txtAssInfo.AppendText(line + Environment.NewLine);
			}
		}

		internal void UpdateEndCompilation() {
			UpdateLstOutputs();
			lblCompiling.Hide();
		}
	}
}
