using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pigmeo.Internal;

namespace Pigmeo.PLPTC {
	public partial class Pinout:Form {
		public Pinout() {
			InitializeComponent();
		}

		private void Pinout_Load(object sender, EventArgs e) {
			ImageRealPCVertical.ImageLocation = SharedSettings.ImagesDirectory + "/ParallelPort_Real_01.jpg";
			ImageRealPortHoriz.ImageLocation = SharedSettings.ImagesDirectory + "/ParallelPort_Real_02.jpg";
		}
	}
}
