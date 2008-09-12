using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Represents a software program/application
	/// </summary>
	public class Program {
		public Method EntryPoint;
		public TypeCollection Types = new TypeCollection();
	}
}
