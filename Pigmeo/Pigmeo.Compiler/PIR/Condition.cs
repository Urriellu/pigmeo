using System;
using System.ComponentModel;

namespace Pigmeo.Compiler.PIR {
	public enum Condition {
		[Description("==")]
		Equal,
		[Description("!=")]
		NotEqual,
		[Description("<")]
		LessThan,
		[Description(">")]
		GreaterThan,
		[Description("<=")]
		LessThanOrEqual,
		[Description(">=")]
		GreaterThanOrEqual
	}

	public static class ConditionExtensions {
		public static string ToSymbolString(this Condition TheCondition) {
			DescriptionAttribute[] attributes = (DescriptionAttribute[])TheCondition.GetType().GetField(TheCondition.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
			if(attributes.Length == 0) throw new NotImplementedException("Undefined symbol");
			return attributes[0].Description;
		}
	}
}
