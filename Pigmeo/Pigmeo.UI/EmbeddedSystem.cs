using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Pigmeo.UI.Properties;
using Pigmeo.Internal;
using Pigmeo.PC;

namespace Pigmeo.UI {
	/// <summary>
	/// Represents an Embedded System/Computer where the user can run his own programs
	/// </summary>
	[DataContract(Namespace = "")]
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

		/// <summary>
		/// Directory where to store (locally) all the information related to the embedded systems
		/// </summary>
		public static string EmbSysDir {
			get {
				return SharedSettings.PigmeoConfigPath + "/EmbeddedSystems";
			}
		}

		/// <summary>
		/// Directory where all the files related to this Embedded System are located
		/// </summary>
		public string LocalDir {
			get {
				return EmbSysDir + "/" + ID;
			}
		}

		/// <summary>
		/// File which includes all the info about one embedded system
		/// </summary>
		public string InfoFile {
			get {
				return LocalDir + "/EmbSys.xml";
			}
		}

		public bool Save() {
			return XmlHelper.SaveXml(InfoFile, this);
		}
	}
}
