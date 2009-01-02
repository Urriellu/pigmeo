using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which references a Local Variable
	/// </summary>
	/// <remarks>
	/// LocalVariableValueOperand, LocalVariableBitOperand, LocalVariableAddrOperand... they all derive from LocalVariableOperand because they all get "something" from a Local Variable
	/// </remarks>
	public abstract class LocalVariableOperand:Operand {
		public LocalVariable TheLV;

		public LocalVariableOperand(LocalVariable ReferencedLV) {
			this.TheLV = ReferencedLV;
		}

		/// <summary>
		/// Gets a LocalVariableOperand, its Value, Bit, or Address based on the type of the given Parameter Operand. The Local Variable it references is taken from the given ParamRelation
		/// </summary>
		public static LocalVariableOperand GetSameRef(ParameterOperand OriginalParamOpd, Dictionary<Parameter, LocalVariable> ParamRelation) {
			Parameter RefdParam = OriginalParamOpd.TheParameter;
			LocalVariable NewRefdLV = ParamRelation[RefdParam];
			if(OriginalParamOpd is ParameterValueOperand) return new LocalVariableValueOperand(NewRefdLV);
			else if(OriginalParamOpd is ParameterBitOperand) return new LocalVariableBitOperand(NewRefdLV, (OriginalParamOpd as ParameterBitOperand).Bit);
			else if(OriginalParamOpd is ParameterAddrOperand) return new LocalVariableAddrOperand(NewRefdLV);
			else throw new ArgumentException("The original parameter is neither a value, bit or address");
		}

		/// <summary>
		/// Gets a LocalVariableOperand, its Value, Bit, or Address based on the type of the given Local Variable Operand. The Local Variable it references is taken from the given LVRelation
		/// </summary>
		public static LocalVariableOperand GetSameRef(LocalVariableOperand OriginalLVOpd, Dictionary<LocalVariable, LocalVariable> LVRelation) {
			LocalVariable RefdLV = OriginalLVOpd.TheLV;
			if(!LVRelation.ContainsKey(RefdLV)) throw new ArgumentException("Local variable not found in the LVRelation: " + RefdLV.ToString());
			LocalVariable NewRefdLV = LVRelation[RefdLV];
			if(OriginalLVOpd is LocalVariableValueOperand) return new LocalVariableValueOperand(NewRefdLV);
			else if(OriginalLVOpd is LocalVariableBitOperand) return new LocalVariableBitOperand(NewRefdLV, (OriginalLVOpd as LocalVariableBitOperand).Bit);
			else if(OriginalLVOpd is LocalVariableAddrOperand) return new LocalVariableAddrOperand(NewRefdLV);
			else throw new ArgumentException("The original local variable is neither a value, bit or address");
		}
	}
}
