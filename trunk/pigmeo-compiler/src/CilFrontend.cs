using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Pigmeo.Internal;

namespace Pigmeo.Compiler {
	/// <summary>
	/// Everything related to the CIL Frontend, which parses the CIL, creates the required packages and optimizes it for all the architectures
	/// </summary>
	public class CilFrontend {
		private static AssemblyDefinition assDef;

		/// <summary>
		/// Runs the CIL Frontend
		/// </summary>
		/// <remarks>
		/// The CIL Frontend makes packages from all the required and optimizes it for all the architectures. Before calling this method take care of the required variables placed in the config class (UserApp, FileBundle, OriginalAssembly...)
		/// </remarks>
		public static void Frontend() {
			ShowInfo.InfoDebug("Running the frontend");
			ShowInfo.InfoDebug("Loading assembly of the given user application (" + config.Internal.UserApp + ")");
			assDef = AssemblyFactory.GetAssembly(config.Internal.UserApp);

			ShowInfo.InfoDebug("Creating the bundled assembly from the given user application");
			AssemblyDefinition bundle = CreateBundle(assDef.EntryPoint);

			ShowInfo.InfoDebug("Saving the bundle");
			//Unable to do it. Cecil doesn't seem to support it. Should try saving using .NET's reflection
			AssemblyFactory.SaveAssembly(bundle, config.Internal.FileBundle);

			ShowInfo.InfoDebug("Optimizing the bundle");
			AssemblyDefinition bundleOptimized = OptimizeBundle(bundle);

			ShowInfo.InfoDebug("Saving the optimized bundle");
			//AssemblyFactory.SaveAssembly(bundleOptimized, config.Internal.FileBundleOptimized);

			config.Internal.AssemblyToCompile = bundleOptimized;
		}

		/// <summary>
		/// Create an assembly containing everything needed by the application given by the user.
		/// </summary>
		/// <param name="entryPoint">Entry point of the application. Usually the Main() function</param>
		private static AssemblyDefinition CreateBundle(MethodDefinition entryPoint) {
			AssemblyMgmt bundle = new AssemblyMgmt();
			bundle.assembly = AssemblyFactory.DefineAssembly(config.Internal.AssemblyName, AssemblyKind.Console);
			config.Compilation.UserAppReferenceFiles = ListOfReferences(config.Internal.UserApp, false);
			bundle.CreateStaticMethodClass();
			bundle.AddStaticMethod(entryPoint, true);
			bundle.AddTrgLib();

			return bundle.assembly;
		}

		/// <summary>
		/// Optimizes the given assembly
		/// </summary>
		/// <remarks>
		/// Those optimizations are shared by all the architectures and can be done here, in the frontend. More optimizations will be done in the backend (but they depend on the target architecture and branch)
		/// </remarks>
		/// <param name="bundle">The assembly to be optimized</param>
		/// <returns>An optimized assembly</returns>
		private static AssemblyDefinition OptimizeBundle(AssemblyDefinition bundle) {
			AssemblyDefinition OptimizedBundle = bundle;

			//optimizations here...

			return OptimizedBundle;
		}

		/// <summary>
		/// Creates a list of references that will be bundled in a single package
		/// </summary>
		/// <param name="assembly">Path to the assembly which must be loaded</param>
		/// <param name="recursive">Specifies if resources of the found resources must also be added to the list</param>
		private static List<string> ListOfReferences(string assembly, bool recursive) {
			ShowInfo.InfoDebug("Loading resources of file " + assembly);

			List<string> references;

			AssemblyDefinition assDef = AssemblyFactory.GetAssembly(assembly);
			int AmountOfReferences = assDef.MainModule.AssemblyReferences.Count;
			ShowInfo.InfoDebug(assembly + " contains " + AmountOfReferences + " references to assemblies");

			references = new List<string>(AmountOfReferences);

			foreach(AssemblyNameReference ResName in assDef.MainModule.AssemblyReferences) {
				string ResPath = "";
				try {
					ResPath = System.Reflection.Assembly.Load(ResName.FullName).Location;
				} catch {
					//the following is done because I didn't manage to load an assembly located in the working directory (if it is the same as the directory where the original assembly (UserApp) is placed), even when it is supposed to work with Assembly.Load()
					try {
						ResPath = System.Reflection.Assembly.LoadFile(ResName.Name + ".dll").Location;
					} catch {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0001", true, ResName.FullName);
					}
				}
				if(!references.Contains(ResPath)) {
					ShowInfo.InfoDebug("New reference found: " + ResPath);
					references.Add(ResPath);
					
					//add the references of this reference
					if(recursive) references.AddRange(ListOfReferences(ResPath, true));
				}
			}

			return references;
		}

		/// <summary>
		/// Methods that modifies an assembly, such as adding a method or a class
		/// </summary>
		private class AssemblyMgmt {
			public AssemblyDefinition assembly;

			public void CreateStaticMethodClass() {
				assembly.MainModule.Types.Add(new TypeDefinition(config.Internal.GlobalStaticThings, config.Internal.GlobalNamespace, TypeAttributes.Sealed, null));
			}

			/// <summary>
			/// Adds a static method to the class where all static methods are stored
			/// </summary>
			/// <param name="method">The method which must be added</param>
			/// <param name="IsEntryPoint">This method is the entry point of the application</param>
			public void AddStaticMethod(MethodDefinition method, bool IsEntryPoint) {
				MethodDefinition MethodCloned = method.Clone();
				assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Methods.Add(MethodCloned);
				if(IsEntryPoint) assembly.EntryPoint = MethodCloned;

				foreach(Instruction inst in method.Body.Instructions) {
					if(inst.OpCode == OpCodes.Ldsfld) {
						//a static field is being loaded, so we add it to GlobalThings
						FieldReference StaticVariableReference = inst.Operand as FieldReference;
						ShowInfo.InfoDebug("Found new static variable: "+StaticVariableReference.Name+" in "+StaticVariableReference.DeclaringType.FullName);
						FieldDefinition StaticVariableDefinition = FindFieldDefinition(StaticVariableReference);
						//assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Fields.Add(StaticVariableDefinition);
						FieldDefinition NewField = new FieldDefinition(StaticVariableDefinition.Name, StaticVariableDefinition.FieldType, StaticVariableDefinition.Attributes);
						foreach(CustomAttribute custAttr in StaticVariableDefinition.CustomAttributes) {
							NewField.CustomAttributes.Add(custAttr.Clone());
						}
						assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Fields.Add(NewField);
					}
				}
			}

			/// <summary>
			/// Adds a static method to the class where all static methods are stored
			/// </summary>
			/// <param name="method">The method which must be added</param>
			public void AddStaticMethod(MethodDefinition method) {
				AddStaticMethod(method, false);
			}

			/// <summary>
			/// Adds a custom attribute that contains the name of the target device library, so the compiler or debugger are able to load the required library (such as PIC16F716.dll) where all the info about the target device is stored
			/// </summary>
			public void AddTrgLib() {
				Architecture TargetArch = Architecture.Unknown;
				Branch TargetBranch = Branch.Unknown;
				string DeviceLibraryPath = "";

				//get list of original resources
				//config.Compilation.UserAppResourceFiles = ListOfResources(config.Internal.UserApp, false);


				//find the device library
				ShowInfo.InfoDebug("Looking for the device library");
				if(config.Compilation.UserAppReferenceFiles.Count == 0) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0003", true);
				foreach(string ass in config.Compilation.UserAppReferenceFiles) {
					AssemblyDefinition assDef = AssemblyFactory.GetAssembly(ass);
					foreach(CustomAttribute attr in assDef.CustomAttributes) {
						attr.Resolve();
						if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceLibrary") {
							TargetArch = (Architecture)attr.ConstructorParameters[0];
							//TargetArch = (Architecture)Enum.Parse(typeof(Architecture), attr.ConstructorParameters[0].ToString());
							TargetBranch = (Branch)attr.ConstructorParameters[1];
							//TargetBranch = (Branch)Enum.Parse(typeof(Branch), attr.ConstructorParameters[1].ToString());
							DeviceLibraryPath = ass;
							ShowInfo.InfoDebug("Found the device library: " + assDef.Name.Name+", Target architecture: "+TargetArch.ToString()+", Target Branch: "+TargetBranch.ToString());
						}
					}
				}

				if(DeviceLibraryPath=="") ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0003", true);


				//add name of the device library to the assembly as a custom attribute
				/*
                old version using enums (not supported by cecil)
                CustomAttribute ca = new CustomAttribute(assembly.MainModule.Import(typeof(Pigmeo.Internal.DeviceTarget).GetConstructor(new Type[] { typeof(Architecture), typeof(Branch), typeof(string) })));
				ca.ConstructorParameters.Add(TargetArch);
				ca.ConstructorParameters.Add(TargetBranch);
				ca.ConstructorParameters.Add(DeviceLibraryPath);
				assembly.CustomAttributes.Add(ca);
                */
                CustomAttribute ca = new CustomAttribute(assembly.MainModule.Import(typeof(Pigmeo.Internal.DeviceTarget).GetConstructor(new Type[] { typeof(string), typeof(string), typeof(string) })));
                ca.ConstructorParameters.Add(TargetArch.ToString());
                ca.ConstructorParameters.Add(TargetBranch.ToString());
                ca.ConstructorParameters.Add(DeviceLibraryPath);
                assembly.CustomAttributes.Add(ca);
			}

			/// <summary>
			/// Looks for the definition of a field within the assembly references
			/// </summary>
			private FieldDefinition FindFieldDefinition(FieldReference fieldRef) {
				FieldDefinition fldDef = null;
				foreach(string reference in config.Compilation.UserAppReferenceFiles) {
					AssemblyDefinition RefAssDef = AssemblyFactory.GetAssembly(reference);
					ShowInfo.InfoDebug("Looking for " + fieldRef.Name + " definition in " + reference+"->"+fieldRef.DeclaringType.FullName);
					if(RefAssDef.MainModule.Types.Contains(fieldRef.DeclaringType.FullName)) {
						ShowInfo.InfoDebug("Found DeclaringType of field " + fieldRef.Name + " within " + reference);
						fldDef = RefAssDef.MainModule.Types[fieldRef.DeclaringType.FullName].Fields.GetField(fieldRef.Name);
					}
				}
				if(fldDef == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0005", true);

				return fldDef.Clone();
			}
		}
	}
}
