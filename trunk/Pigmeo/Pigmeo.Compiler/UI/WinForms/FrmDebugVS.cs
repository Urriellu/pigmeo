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
				lstOutputs.Items.Add(item.Title);
				lstOutputs.Items[lstOutputs.Items.Count - 1].Tag = item.Name;
			}
			if(lstOutputs.Items.Count > 0) lstOutputs.Items[0].Selected = true;
			Refresh();
		}

		private void lstOutputs_SelectedIndexChanged(object sender, EventArgs e) {
			if(lstOutputs.SelectedIndices.Count > 0) {
				int ind = lstOutputs.SelectedIndices[0];
				foreach(var msg in Outputs[ind].Messages) {
					txtDebugOutput.AppendText(msg.Key + ":" + Environment.NewLine);
					txtDebugOutput.AppendText(msg.Value + ":" + Environment.NewLine);
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
	}
}
