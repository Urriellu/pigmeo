/*
This file is part of Pigmeo.

Pigmeo is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 3 of the License, or
(at your option) any later version.

Pigmeo is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>. 
*/

using System;
using System.Collections;

namespace PigmeoCompiler {

	/// <summary>
	/// Objects derived from this class will be resource files found in the config file
	/// </summary>
	public class ResourceFile {
		/// <summary>
		/// Type of resource (CilBytecodes...)
		/// </summary>
		public readonly string type;

		/// <summary>
		/// Resource file name
		/// </summary>
		public readonly string file;

		/// <summary>
		/// Where the source file is located (local, GAC...)
		/// </summary>
		public readonly string source;

		/// <summary>
		/// Gets the path to the resource file
		/// </summary>
		public string path {
			get {
				string ret = "";
				switch(source) {
					case "local":
						ret = file;
						break;
					case "GAC":
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "assemblies in the GAC");
						break;
					default:
						throw new Exception("unknown source \"" + source + "\" for the file " + file);
						break;
				}
				return ret;
			}
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ResourceFile"/> class.
		/// </summary>
		/// <param name="ptype">Type of resource (CilBytecodes...)</param>
		/// <param name="pfile">Resource file name</param>
		/// <param name="psource">Where the source file is located (local, GAC...)</param>
		public ResourceFile(string ptype, string pfile, string psource) {
			//here we should test if the values are valid
			type = ptype;
			file = pfile;
			source = psource;
		}
	}
}
