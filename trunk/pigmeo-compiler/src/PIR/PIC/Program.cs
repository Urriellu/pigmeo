using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR.PIC {
	/// <summary>
	/// Represents a Program for Microchip PIC Microcontrollers
	/// </summary>
	public class Program:PIR.Program {
		public readonly DataMemory DataMemory;

		/// <summary>
		/// Instantiates a new PIR.PIC.Program
		/// </summary>
		/// <remarks>
		/// Almost everything is retrieved from the reflected assembly at PIR.Program.GetFromCIL(), not here
		/// </remarks>
		public Program(PRefl.Assembly ReflectedAssembly):base(ReflectedAssembly) {
			DataMemory = new DataMemory(this);

			//now we choose the amount of data memory assigned to each type of memory
			DataMemory.StaticMemory.AssignAllGpr();
			//[stack missing]
			//[heap missing]
			//...
			//[more types of memory here]
		}

		/// <summary>
		/// Assign the Location() attribute to static fields that don't have it yet
		/// </summary>
		public void AssignLocations() {
			foreach(Type T in Types) {
				foreach(Field F in T.Fields) {
					if(F.IsStatic && !F.Location.DefinedInHeader && F.Location.Address.Undefined) {
						if(F.Size > Target.GprSize) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0008", false, string.Format("Size of Field {0} bigger than General Purpose Registers size on {1}", F.ToStringTypeAndName(), Target.Branch));
						F.Location = DataMemory.StaticMemory.Allocate((byte)F.Size);
						ShowInfo.InfoDebug("Assigned location {0} to static field {1}", F.Location, F.ToStringTypeAndName());
					} else ShowInfo.InfoDebug("{0} doesn't need to get a new Location assigned", F.ToStringTypeAndName());
				}
			}
		}

		/// <summary>
		/// Make operations use the PIC Working Register (W)
		/// </summary>
		public bool MakeOperationsUseW() {
			bool mod = false;
			foreach(Type T in Types) {
				foreach(Method M in T.Methods) {
					if(M.MakeOperationsUseW()) mod = true;
				}
			}
			return mod;
		}

		public new InfoPIC Target {
			get {
				return _Target as InfoPIC;
			}
		}
	}
}
