using System;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// PIR Operation
	/// </summary>
	/// <remarks>
	/// An operation can be thought as a function or low level instruction
	/// </remarks>
	public abstract class Operation {
		public Method ParentMethod;

		public int Index {
			get {
				return ParentMethod.Operations.IndexOf(this);
			}
		}

		/// <summary>
		/// Operator (+, -, Copy, Call...)
		/// </summary>
		public string Operator { get; protected set; }

		/// <summary>
		/// Operation arity (number of arguments)
		/// </summary>
		public int Arity {
			get {
				if(Arguments != null) return Arguments.Length;
				else return 0;
			}
		}

		/// <summary>
		/// Operation arguments
		/// </summary>
		public Operand[] Arguments;

		/// <summary>
		/// Operand which indicates the place where the result of this operation will be stored
		/// </summary>
		public Operand Result;

		public override string ToString() {
			if(Arity == 0) return ToString1st();
			if(Arity == 2) return ToString1st() + Arguments[0].ToString() + " " + Operator + " " + Arguments[1].ToString();
			return ToString1st() + "UNKNOWN";
		}

		/// <summary>
		/// Generates the first part of the ToString() method for all derived Operations
		/// </summary>
		protected string ToString1st() {
			string ret = string.Format("Op_{0:x3}: ", Index);
			if(Result != null) ret += Result.ToString() + " := ";
			else ret += Operator;
			return ret;
		}

		protected Operation(Method ParentMethod) {
			this.ParentMethod = ParentMethod;
		}

		#region static methods
		public static Operation GetFromPRefl(PRefl.Instruction InstrBeingParsed, Method ParentMethod) {
			ShowInfo.InfoDebug("Converting the P.I.Reflection Instruction {0} to a PIR Operation in method", InstrBeingParsed.ToString(), ParentMethod.ToString());
			if(InstrBeingParsed is PRefl.Instructions.ldc_i4) return new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldc_i4);
			else return new Nop(ParentMethod);
		}
		#endregion
	}
}
