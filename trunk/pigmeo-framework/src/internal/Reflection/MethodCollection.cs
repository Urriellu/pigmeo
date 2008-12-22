﻿using System;
using System.Collections.Generic;
using Pigmeo.Extensions;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a collection of Methods
	/// </summary>
	public class MethodCollection:List<Method> {
		/// <summary>
		/// Creates a new collection of methods with the given default capacity
		/// </summary>
		/// <param name="Capacity">Default capacity. This collection will automatically resize itself when needed</param>
		public MethodCollection(int Capacity) : base(Capacity) { }

		/// <summary>
		/// Indicates if a Method exists in this collection, by its given name
		/// </summary>
		/// <param name="MethodName">Name of the Method being looked for</param>
		public bool Contains(string MethodName) {
			ShowExternalInfo.InfoDebug("Checking wheter {0} exists in this MethodCollection or not", MethodName);
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].Name == MethodName) return true;
			}
			return false;
		}

		public string[] Names {
			get {
				if(_Names == null) {
					_Names = new string[this.Count];
					for(int i = 0 ; i < this.Count ; i++) _Names[i] = this[i].Name;
				}
				return _Names;
			}
		}
		protected string[] _Names;

		/* this can't be used because it finds a method based only on its name, so it won't find the correct method when there are multiple methods with the same name
		/// <summary>
		/// Retrieves a Method from this collection, by its given name
		/// </summary>
		/// <param name="MethodName">Name of the method being retrieved</param>
		public Method this[string MethodName] {
			get {
				ShowExternalInfo.InfoDebug("Trying to retrieve the method {0} from this MethodCollection. Known methods: {1}", MethodName, Names.CommaSeparatedList());
				for(int i = 0 ; i < this.Count ; i++) {
					if(this[i].Name == MethodName) return this[i];
				}
				throw new ArgumentException("The method does not exist");
			}
		}*/

		/* this doesn't work either because the metadata token changes over time (why???)
		/// <summary>
		/// Retrieves a Method from this collection, by its given TokenID
		/// </summary>
		/// <param name="TokenID">Metadata token ID of the method being retrieved</param>
		public Method GetByTokenID(UInt32 TokenID) {
			ShowExternalInfo.InfoDebug("Retrieving method with TokenID {0}", TokenID);
			for(int i = 0 ; i < this.Count ; i++) {
				ShowExternalInfo.InfoDebug("Trying {0} (TokenID: {1})", this[i].FullName, this[i].TokenID);
				if(this[i].TokenID == TokenID) return this[i];
			}
			throw new ArgumentException("The method does not exist");
		}*/

		/// <summary>
		/// Retrieves a Method from this collection
		/// </summary>
		public Method GetMethod(string Name, params string[] ParamsFullNames) {
			ShowExternalInfo.InfoDebug("Trying to retrieve method {0}({1}) from this MethodCollection", Name, ParamsFullNames.CommaSeparatedList());
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].Name == Name && this[i].Parameters.Count == ParamsFullNames.Length) {
					bool found = true;
					for(UInt16 j = 0 ; j < ParamsFullNames.Length ; j++) {
						if(this[i].Parameters[j].ParamType.FullName != ParamsFullNames[j]) found = false;
					}
					if(found) return this[i];
				}
			}
			throw new ArgumentException("The method does not exist");
		}

		/// <summary>
		/// Gets a reflected Method from this collection given its Mono.Cecil representation
		/// </summary>
		/// <param name="MCCilMethod"></param>
		/// <returns></returns>
		public Method GetFromCecil(Mono.Cecil.MethodReference MCCilMethod) {
			//NOTE: non-static methods in PRefl have one more parameter than in Mono.Cecil, because in Mono.Cecil the "this" parameter is not considered a parameter, it's implicit
			if(!MCCilMethod.HasThis) {
				string[] Params = new string[MCCilMethod.Parameters.Count];
				for(int i = 0 ; i < Params.Length ; i++) {
					Params[i] = MCCilMethod.Parameters[i].ParameterType.FullName;
				}
				return GetMethod(MCCilMethod.Name, Params);
			} else {
				string[] Params = new string[MCCilMethod.Parameters.Count + 1];
				Params[0] = MCCilMethod.DeclaringType.FullName;
				for(int i = 0 ; i < MCCilMethod.Parameters.Count ; i++) {
					Params[i + 1] = MCCilMethod.Parameters[i].ParameterType.FullName;
				}
				return GetMethod(MCCilMethod.Name, Params);
			}
		}
	}
}
