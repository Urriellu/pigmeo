Visit http://pigmeo.org for more information




License:
	GNU General Public License v3

	The entire license text is in the file COPYING.txt

============================================================

PREREQUISITES

Minimum system requirements:
	Linux and Unix-like:
		-Mono 1.9

	Microsoft Windows:
		-Microsoft .NET 2.0 or Mono 1.9
		-Microsoft .NET 3.5 if you want to use extensions methods from Pigmeo.Extensions in your program

	Also, you need NAnt for compiling the source code

	Note: it won't work on previous versions of mono due to bug https://bugzilla.novell.com/show_bug.cgi?id=355161

============================================================

DEVELOPMENT

Developing Pigmeo from Microsoft Windows:
	Using Visual Studio:
		Note: Pigmeo is compiled using NAnt instead of MSBuild (provided by Visual Studio), so we need to download NAnt (it doesn't need to be installed) and set up Visual Studio for executing NAnt when we press a key combination
		-Download the latest sources from http://dev.pigmeo.org/wiki/Repositories
		-Download the latest NAnt binary package from http://nant.sourceforge.net/
		-Unpack NAnt binaries wherever you want them to be "installed"
		-Open Pigmeo.sln using Visual Studio 2008
		-Go to Tools -> External Tools -> Add
		-Set the following parameters:
			-Title: NAnt
			-Command: [path to the previously downloaded NAnt.exe, as in C:\Documents and Settings\MyUser\Desktop\nant-version\bin\NAnt.exe]
			-Arguments [empty]
			-Initial directory: $(SolutionDir)
			-Use Output window: [Checked]
		-Click on "Move Up" until NAnt is the first tool
		-Go to Tools -> Options -> Environment -> Keyboard
		-Choose "Tools.ExternalCommand1"
		-Click on the "Press shortcut keys" text box
		-Now press the key or key combination you want to use for compiling Pigmeo. For example, you can use F6 (the default key used for building a solution)
		-Click "Assign"
		-Click "OK" to close the dialog
		Now you can open Pigmeo.sln whenever you want, make your changes and press F6 (or whatever combination you choosed)

============================================================

COMPILATION

Compilation from the command-line:
	`nant`

More information about the compilation options:
	`nant help`

Now everything you need is in the "output/binaries" directory

============================================================

INSTALLATION

Linux and Unix-like:
	Without installation:
		-copy all the files in output/binaries and output/binaries/GAC/ to some other folder (all of them to the same folder)
		-copy the scripts in the scripts/ directory to any place in your $PATH, such as /usr/local/bin
		-edit "pigmeo" and "pmc" scripts

	Installing it:
		-run `nant install` (not supported yet)

Microsoft Windows:
		-copy all the files in output/ and output/GAC/ to some other folder (all of them to the same folder)

============================================================

EXECUTION

Linux and Unix-like:
	`mono /path/to/pigmeo-compiler/output/pigmeo-compiler.exe`
	or if you installed the scripts simply run:
	`pigmeo`

Microsoft Windows:
	-double click on pigmeo-compiler.exe


