using System;
using Pigmeo.Extensions;

namespace Pigmeo.Internal.PIC {
	//NOTE: attributes used internally by PIC devices, not by users, other architectures or branches

	/// <summary>
	/// Specifies the location of a field in the PIC's RAM
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class Location:Attribute {
		/// <summary>
		/// The address of this register
		/// </summary>
		public readonly RegisterAddress Address = new RegisterAddress();

		/// <summary>
		/// Indicates if the location of this field/register in defined in the header file (*.inc, used by the assembler)
		/// </summary>
		public readonly bool DefinedInHeader;

		public readonly bool IncludeBit = false;

		/// <summary>
		/// Specifies the location of a field by its given memory bank and address
		/// </summary>
		/// <param name="Bank">PIC's Memory Bank</param>
		public Location(byte Bank, byte Address) {
			this.Address = new RegisterAddress(Bank, Address);
			DefinedInHeader = false;
		}

		/// <summary>
		/// Specifies the location of a bit by its given memory bank, address and bit location inside a register
		/// </summary>
		/// <param name="Bank">PIC's Memory Bank</param>
		public Location(byte Bank, byte Address, byte Bit) {
			this.Address = new RegisterAddress(Bank, Address, Bit);
			DefinedInHeader = false;
			IncludeBit = true;
		}

		/// <summary>
		/// Specifies that the location of this field is defined in the header file (the .inc file used by the assembler)
		/// </summary>
		/// <param name="DefinedInHeader"></param>
		public Location(bool DefinedInHeader) {
			this.DefinedInHeader = DefinedInHeader;
		}

		/// <summary>
		/// Indicates an undefined location. Its final location will be chosen by Pigmeo Compiler
		/// </summary>
		public Location() {
		}

		public override string ToString() {
			if(DefinedInHeader) return "Defined In Header";
			else if(Address.Undefined) return "Undefined";
			else {
				string txt = string.Format("Bank {0}, Address {1} (0x{1:X2})", Address.Bank, Address.Address);
				if(IncludeBit) txt += ", Bit " + Address.Bit;
				return txt;
			}
		}
	}

	/// <summary>
	/// Indicates the Configuration Word where a Configuration Bit can be found
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class ConfigWord : Attribute {
		public readonly byte Word;

		/// <summary>
		/// Indicates the Configuration Word where a Configuration Bit can be found
		/// </summary>
		public ConfigWord(byte Word) {
			this.Word = Word;
		}
	}
}
