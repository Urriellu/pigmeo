using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR.PIC {
	public class Field:PIR.Field {
		public Location Location = new Location();

		public Field(PIR.Program ParentProgram, PRefl.Field ReflectedField):base(ParentProgram, ReflectedField) {
			foreach(PRefl.CustomAttr cattr in ReflectedField.CustomAttributes) {
				#region find its location
				if(cattr.CAttrType.FullName == "Pigmeo.Internal.PIC.Location") {
					try {
						if(cattr.Parameters.Count == 1) {
							Location = new Location((bool)cattr.Parameters[0].Value);
						} else if(cattr.Parameters.Count == 2) {
							Location = new Location((byte)cattr.Parameters[0].Value, (byte)cattr.Parameters[1].Value);
						} else if(cattr.Parameters.Count == 3) {
							Location = new Location((byte)cattr.Parameters[0].Value, (byte)cattr.Parameters[1].Value, (byte)cattr.Parameters[2].Value);
						} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Parsing CustomAttribute Pigmeo.Internal.PIC.Location but constructor is unknown");
					} catch(InvalidCastException) {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Parsing CustomAttribute Pigmeo.Internal.PIC.Location but constructor is unknown (invalid cast)");
					}
				}
				#endregion
			}
		}

		public override string[] ToStringAttributes() {
			List<string> attrs = new List<string>(base.ToStringAttributes());
			attrs.Add("Location(" + Location.ToString() + ")");
			return attrs.ToArray();
		}
	}
}
