using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.UI.WinForms {
	public partial class AboutWindow:Form {
		public AboutWindow() {
			InitializeComponent();
			LoadLanguageStrings();
			Image PigmeoLogo = Image.FromFile(config.Internal.ExeLocation+"/images/pigmeo-logo.png");
			PicBoxLogo.Image = PigmeoLogo;
			linkUrl.Location = new Point(linkUrl.Location.X, txtDesc.Location.Y + txtDesc.Size.Height + 20);
			this.Size = new Size(this.Size.Width, linkUrl.Location.Y + linkUrl.Size.Height + 50);
		}

		/// <summary>
		/// Loads all language-dependent strings shown in the window
		/// </summary>
		protected void LoadLanguageStrings() {
			this.Text = i18n.str(4, config.Internal.AppName);
			lblAppName.Text=config.Internal.AppName+" "+config.Internal.AppVersion;
			txtDesc.Text = i18n.str(7) + Environment.NewLine + Environment.NewLine + i18n.str(8) + Environment.NewLine;
			foreach(string developer in config.Internal.Developers.Split('\n')) {
				txtDesc.Text += "    " + developer + Environment.NewLine;
			}
			linkUrl.Text = config.Internal.PrjWebsite;
		}

		private void linkUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(config.Internal.PrjWebsite);
		}
	}
}
