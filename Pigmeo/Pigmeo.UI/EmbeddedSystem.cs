using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pigmeo.UI {
	/// <summary>
	/// Represents an Embedded System/Computer where the user can run his own programs
	/// </summary>
	[DataContract]
	public class EmbeddedSystem {
		/// <summary>
		/// ID of this Embedded System
		/// </summary>
		[DataMember]
		public readonly string ID;

		/// <summary>
		/// Latest known system information (operating system, kernel, hostname...)
		/// </summary>
		[DataMember]
		public string SysInfo = "Unknown Operating System";

		/// <summary>
		/// IP Address of this remote system
		/// </summary>
		[DataMember]
		public string IP = "127.0.0.1";

		[DataMember]
		public Dictionary<string, RemoteApp> Apps = new Dictionary<string, RemoteApp>();

		public EmbeddedSystem(string id) {
			this.ID = id;
		}
	}
}
