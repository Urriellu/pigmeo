using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace Pigmeo.PC {
	public static class XmlHelper {
		public static bool SaveXml(string file, object obj) {
			if (string.IsNullOrEmpty(file) || obj == null) throw new Exception("Incorrect parameters for saving file");
			try {
				string dir = Path.GetDirectoryName(file);
				DataDirCreate(dir);

				XmlWriterSettings xws = new XmlWriterSettings();
				xws.Indent = true;
				xws.OmitXmlDeclaration = true;
				xws.NewLineHandling = NewLineHandling.Entitize;
				DataContractSerializer dcs = new DataContractSerializer(obj.GetType());
				XmlWriter xw = XmlWriter.Create(file, xws);
				dcs.WriteObject(xw, obj);
				xw.Close();
				return true;
			} catch (SerializationException ex) {
				if (ex.Message.Contains("with data contract name")) {
					throw new Exception("Must add a KnownTypeAttribute to class. " + ex.Message);
				} else throw ex;
			} catch (InvalidDataContractException ex) {
				throw new Exception("Must add DataContact to some class. " + ex.Message);
			} catch (Exception ex) {
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="file"></param>
		/// <param name="obj"></param>
		/// <remarks>http://www.silverlighthostingnews.com/index.php/archives/251</remarks>
		public static bool SaveXmlBinary(string file, object obj) {
			if (string.IsNullOrEmpty(file) || obj == null) throw new Exception("Incorrect parameters for saving file");
			try {
				string dir = Path.GetDirectoryName(file);
				DataDirCreate(dir);

				var strings = new List<XmlDictionaryString>();
				var stream = new MemoryStream();
				var dictionary = new XmlDictionary();
				var session = new XmlBinaryWriterSession();
				var rdr = new XmlBinaryReaderSession();

				var key = 0;

				DataContractSerializer dcs = new DataContractSerializer(obj.GetType());
				FileStream fs = new FileStream(file, FileMode.Create);
				XmlDictionaryWriter xw = XmlDictionaryWriter.CreateBinaryWriter(fs, dictionary, session);

				foreach (var val in strings) {
					if (session.TryAdd(val, out key)) {
						rdr.Add(key, val.Value);
					}
				}

				dcs.WriteObject(xw, obj);
				xw.Flush();
				fs.Position = 0;
				xw.Close();
				fs.Close();
				return true;
			} catch (Exception ex) {
				return false;
			}
		}

		public static T LoadFromXml<T>(string file) {
			//try {
			XmlReaderSettings xws = new XmlReaderSettings();
			DataContractSerializer dcs = new DataContractSerializer(typeof(T));
			XmlReader xw = XmlReader.Create(file, xws);
			T readObj = (T)dcs.ReadObject(xw);
			xw.Close();

			return readObj;
			/*} catch {
				return default(T);
			}*/
		}

		/// <summary>
		/// If DataDir (where everything is stored for this object) doesn't exist, it's created
		/// </summary>
		/// <returns>True if exists or newly created. False if doesn't exist and couldn't be created</returns>
		static bool DataDirCreate(string dir) {
			if (Directory.Exists(dir)) {
				return true;
			} else {
				try {
					Directory.CreateDirectory(dir);
					return true;
				} catch {
					return false;
				}
			}
		}
	}

}
