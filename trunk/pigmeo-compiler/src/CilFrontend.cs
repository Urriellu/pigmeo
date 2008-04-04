using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {
	/// <summary>
	/// Everything related to the CIL Frontend, which parses the CIL, creates the required packages and optimizes it for all the architectures
	/// </summary>
	public class CilFrontend {
		/// <summary>
		/// Original assembly: the application written by the user
		/// </summary>
		private static AssemblyDefinition assDef;

		/// <summary>
		/// Runs the CIL Frontend
		/// </summary>
		/// <remarks>
		/// The CIL Frontend makes packages from all the required assemblies and optimizes it for all the architectures. Before calling this method take care of the required variables placed in the config class (UserApp, FileBundle, OriginalAssembly...)
		/// </remarks>
		public static void Frontend() {
			ShowInfo.InfoDebug("Running the frontend");
			ShowInfo.InfoDebug("Loading assembly of the given user application (" + config.Internal.UserApp + ")");
			assDef = AssemblyFactory.GetAssembly(config.Internal.UserApp);
			GlobalShares.CompilationProgress = 5;

			AssemblyDefinition bundle = CreateBundle(assDef.EntryPoint);
			GlobalShares.CompilationProgress = 25;

			ShowInfo.InfoDebug("Saving the bundle");
			if(config.Internal.SaveBundle) AssemblyFactory.SaveAssembly(bundle, config.Internal.FileBundle);
			GlobalShares.CompilationProgress = 27;

			AssemblyDefinition bundleOptimized = OptimizeBundle(bundle);
			GlobalShares.CompilationProgress = 35;

			ShowInfo.InfoDebug("Saving the optimized bundle");
			//AssemblyFactory.SaveAssembly(bundleOptimized, config.Internal.FileBundleOptimized);
			GlobalShares.CompilationProgress = 37;

			GlobalShares.AssemblyToCompile = bundleOptimized;
		}

		/// <summary>
		/// Create an assembly containing everything needed by the application given by the user.
		/// </summary>
		/// <param name="entryPoint">Entry point of the application. Usually the Main() function</param>
		private static AssemblyDefinition CreateBundle(MethodDefinition entryPoint) {
			ShowInfo.InfoDebug("Creating the bundled assembly from the given user application");

			AssemblyMgmt bundle = new AssemblyMgmt();
			bundle.assembly = AssemblyFactory.DefineAssembly(config.Internal.AssemblyName, AssemblyKind.Console);
			GlobalShares.UserAppReferenceFiles = ListOfReferences(config.Internal.UserApp, false);
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
		[PigmeoToDo("Optimizations not designed yet")]
		private static AssemblyDefinition OptimizeBundle(AssemblyDefinition bundle) {
			ShowInfo.InfoDebug("Optimizing the bundle");

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

			references = new List<string>(AmountOfReferences+1);
			references.Add(assembly); //the user application is also an assembly being bundled

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
			/// <summary>
			/// Assembly which is being worked on
			/// </summary>
			public AssemblyDefinition assembly;

			/// <summary>
			/// Associates a FieldReference with a FieldDefinition. The first time some FieldReference is found is added here with its related FieldDefinition, which was previously modified to satisfy naming conventions, so the following references to the field will know which definition should point to
			/// </summary>
			//private Dictionary<FieldReference, FieldDefinition> FieldsRelation = new Dictionary<FieldReference, FieldDefinition>();

			/// <summary>
			/// Associates two FieldReferences: the first one is the original FieldReference found as operator in some instructions within the user's original application. The second one is the new FieldReference which points to the new FieldDefinition within the static class meant to store all the static variables within the bundled assembly
			/// </summary>
			protected Dictionary<FieldReference, FieldReference> FieldsRelation = new Dictionary<FieldReference, FieldReference>();

			/// <summary>
			/// Associates two Instructions: the first one is the original Instruction contained within the original method. The second one is the instruction added to the bundle, which some times is the same as the original (if inst.IsFrontEndDontTouch()) but in some cases that instruction is modified here in the frontend before being added to the bundle.
			/// </summary>
			protected Dictionary<Instruction, Instruction> InstructionsRelation = new Dictionary<Instruction, Instruction>(); 

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
				//assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Methods.Add(MethodCloned);
				if(IsEntryPoint) assembly.EntryPoint = MethodCloned;
				MethodCloned.Body = CreateNewBody(method);
				MethodCloned.DeclaringType = assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].GetOriginalType();
				ShowInfo.InfoDebug("Adding method " + MethodCloned.Name + " to " + config.Internal.GlobalStaticThingsFullName);
				assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Methods.Add(MethodCloned.Clone());
			}

			/// <summary>
			/// Creates the new body of the method, modifying all the required instructions for an easier compilation (done later in the backend)
			/// </summary>
			/// <param name="OriginalMethod">The original method where the instructions belong</param>
			/// <returns>The new body ready for being compiled</returns>
			[PigmeoToDo("We need to support more instructions")]
			protected MethodBody CreateNewBody(MethodDefinition OriginalMethod) {
				ShowInfo.InfoDebug("Creating new body for method {0}", OriginalMethod.ToString());

				MethodBody NewBody = new MethodBody(OriginalMethod);
				CilWorker cw = NewBody.CilWorker;

				foreach(Instruction inst in OriginalMethod.Body.Instructions) {
					ShowInfo.InfoDebug("Processing instruction {0} in method {1}", inst.OpCode.ToString(), OriginalMethod.ToString());
					Instruction NewInst = null;

					if(inst.OpCode.IsFrontendDontTouch()) {
						ShowInfo.InfoDebug("This instruction doesn't need to be modified");
						NewInst = inst;
					} else {
						if(inst.OpCode.ReferencesStaticField()) NewInst = ProcessInstruction_ItReferencesStaticField(inst, cw);
						else if(inst.ReferencesAnotherInstruction()) NewInst = ProcessInstruction_ItReferencesAnotherInstruction(inst);
						else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0006", false, inst.OpCode.ToString());
					}

					InstructionsRelation.Add(inst, NewInst);
					cw.Append(NewInst);
				}
				return NewBody;
			}

			protected Instruction ProcessInstruction_ItReferencesStaticField(Instruction OriginalInstr, CilWorker cw) {
				ShowInfo.InfoDebug("Processing an instruction that references a static field");
				//a static field is being loaded, so we add it to GlobalThings
				FieldReference StaticVariableOriginalReference = OriginalInstr.Operand as FieldReference;
				FieldReference StaticVariableNewReference = StaticVariableOriginalReference;
				if(FieldsRelation.ContainsKey(StaticVariableOriginalReference)) {
					ShowInfo.InfoDebug("Found known static variable {0} in {1}", StaticVariableOriginalReference.Name, StaticVariableOriginalReference.DeclaringType.FullName);
					//don't need to being added to FieldsRelation nor the list of fields in the bundle (assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Fields)
				} else {
					ShowInfo.InfoDebug("Found new static variable {0} in {1}", StaticVariableOriginalReference.Name, StaticVariableOriginalReference.DeclaringType.FullName);

					FieldDefinition StaticVariableOriginalDefinition = FindFieldDefinition(StaticVariableOriginalReference);
					StaticVariableNewReference.DeclaringType = assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].GetOriginalType();

					string FieldName = StaticVariableOriginalReference.Name;
					//if this variable requires a special name in assembly language, we'll call by that name at GlobalStaticThings
					ShowInfo.InfoDebug("It has {0} custom attributes", StaticVariableOriginalDefinition.CustomAttributes.Count);
					foreach(CustomAttribute cattr in StaticVariableOriginalDefinition.CustomAttributes) {
						if(cattr.Constructor.DeclaringType.FullName == "Pigmeo.AsmName") {
							string NewName = cattr.ConstructorParameters[0] as string;
							ShowInfo.InfoDebug("The static variable {0} wants to be called {1}", StaticVariableOriginalReference.Name, NewName);
							FieldName = NewName;
						}
					}

					FieldDefinition StaticVariableNewDefinition = new FieldDefinition(FieldName, StaticVariableOriginalDefinition.FieldType.GetOriginalType(), StaticVariableOriginalDefinition.Attributes);
					foreach(CustomAttribute cattr in StaticVariableOriginalDefinition.CustomAttributes) StaticVariableNewDefinition.CustomAttributes.Add(cattr.Clone());
					StaticVariableNewReference.Name = StaticVariableNewDefinition.Name;

					FieldsRelation.Add(StaticVariableOriginalReference, StaticVariableNewReference);
					assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Fields.Add(StaticVariableNewDefinition);
					ShowInfo.InfoDebug("Now there are {0} fields in {1}", assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Fields.Count.ToString(), config.Internal.GlobalStaticThingsFullName);
				}

				Instruction NewInst = null;
				if(OriginalInstr.OpCode == OpCodes.Stsfld) NewInst = cw.Create(OpCodes.Stsfld, StaticVariableNewReference);
				else if(OriginalInstr.OpCode == OpCodes.Ldsfld) NewInst = cw.Create(OpCodes.Ldsfld, StaticVariableNewReference);
				else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0006", false, OriginalInstr.OpCode.ToString());
				return NewInst;
			}

			protected Instruction ProcessInstruction_ItReferencesAnotherInstruction(Instruction OriginalInstr) {
				ShowInfo.InfoDebug("Processing an instruction that references another instruction");
				Instruction NewInstr = OriginalInstr;

				NewInstr.Operand = InstructionsRelation[OriginalInstr.Operand as Instruction];

				return NewInstr;
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
				if(GlobalShares.UserAppReferenceFiles.Count == 0) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0003", true);
				foreach(string ass in GlobalShares.UserAppReferenceFiles) {
					AssemblyDefinition assDef = AssemblyFactory.GetAssembly(ass);
					foreach(CustomAttribute attr in assDef.CustomAttributes) {
						attr.Resolve();
						if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceLibrary") {
							TargetArch = (Architecture)attr.ConstructorParameters[0];
							TargetBranch = (Branch)attr.ConstructorParameters[1];
							DeviceLibraryPath = ass;
							ShowInfo.InfoDebug("Found the device library: " + assDef.Name.Name+", Target architecture: "+TargetArch.ToString()+", Target Branch: "+TargetBranch.ToString());
						}
					}
				}

				if(DeviceLibraryPath=="") ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0003", true);


				//add name of the device library to the assembly as a custom attribute
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
				foreach(string reference in GlobalShares.UserAppReferenceFiles) {
					AssemblyDefinition RefAssDef = AssemblyFactory.GetAssembly(reference);
					ShowInfo.InfoDebug("Looking for \"{0}\" definition in {1}->{2}", fieldRef.Name, reference, fieldRef.DeclaringType.FullName);
					if(RefAssDef.MainModule.Types.Contains(fieldRef.DeclaringType.FullName)) {
						ShowInfo.InfoDebug("Found DeclaringType of field {0} within {1}", fieldRef.Name, reference);
						fldDef = RefAssDef.MainModule.Types[fieldRef.DeclaringType.FullName].Fields.GetField(fieldRef.Name);
					}
				}
				if(fldDef == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0005", true);

				return fldDef.Clone();
			}
		}
	}
}
