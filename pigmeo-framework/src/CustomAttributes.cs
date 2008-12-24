﻿using System;

namespace Pigmeo {
	/// <summary>
	/// Specifies the name given when compiled to assembly language.
	/// </summary>
	/// <remarks>
	/// Useful in device libraries and when working with assembly language, so you know how a variable or function will be called.
	/// </remarks>
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class AsmName:Attribute {
		public readonly string name;

		public AsmName(string name) {
			this.name = name;
		}
	}

	/// <summary>
	/// Specifies that the method implemented in managed code will be used on managed environments and most architectures, but will be replaced by code written in assembly language when compiling for the given architecture
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class AsmReplace:Attribute {
		public readonly string Path;
		public readonly Architecture Arch;

		public AsmReplace(Architecture arch, string path) {
			this.Arch = arch;
			this.Path = path;
		}
	}

	/// <summary>
	/// Indicates that this method should never be called. Its instructions will be injected wherever the method is called
	/// </summary>
	/// <remarks>
	/// Users should never use this attribute, because inlinization is processed by Pigmeo Compiler and can be configured in the Compilation Settings
	/// </remarks>
	[AttributeUsage(AttributeTargets.Method)]
	public class InLine:Attribute {
	}
}
