using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pigmeo.Internal;

namespace Pigmeo.UI {
	public partial class FrmEmbSys : Form {
		public FrmEmbSys() {
			InitializeComponent();

			try {
				Font fontFixedWidth = new Font(FontFamily.GenericMonospace, 10.0F);
				txtCmdOut.Font = fontFixedWidth;
			} catch {
				// if it fails, the standard font will display
			}
		}

		private void FrmEmbSys_Load(object sender, EventArgs e) {
			UpdateLang();
		}

		private void UpdateLang() {
			btnAddSystem.Tag = i18n.str("AddEmbeddedSystem");
		}
	}
}
