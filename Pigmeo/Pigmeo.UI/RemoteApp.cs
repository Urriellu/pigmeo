using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pigmeo.UI {
	/// <summary>
	/// Custom application written by the user and run on a remote embedded system
	/// </summary>
	[DataContract(Namespace = "")]
	public class RemoteApp {
		/// <summary>
		/// ID of this application
		/// </summary>
		[DataMember]
		public string ID;

		/// <summary>
		/// Last time this program was run
		/// </summary>
		[DataMember]
		public DateTime LastExecution;
	}
}
