Visit http://pigmeo.org for more information




License:
	GNU General Public License v3

	the entire license text is in the file COPYING.txt

===============================

Minimum system requirements:
	Windows:
		-Microsoft .NET 2.0 or Mono 1.9
		-Microsoft .NET 3.5 if you want to use extensions methods from Pigmeo.Extensions in your program

	Linux and Unix-like:
		-Mono 1.9

	Also, you need NAnt for compiling the source code

	Note: it won't work on previous versions of mono due to bug https://bugzilla.novell.com/show_bug.cgi?id=355161

===============================

Compile everything:
	`nant`

More information about the compilation options:
	`nant help`

Now everything you need is in the "output/binaries" directory

===============================

Installation:
	Linux and Unix-like:
		Without installation:
			-copy all the files in output/binaries and output/binaries/GAC/ to some other folder (all of them to the same folder)
			-copy the scripts in the scripts/ directory to any place in your $PATH, such as /usr/local/bin
			-edit "pigmeo" and "pmc" scripts

		Installing it:
			-run `nant install` (not supported yet)

	Windows:
			-copy all the files in output/ and output/GAC/ to some other folder (all of them to the same folder)

===============================

Execution:
	on Unix-like:
		`mono /path/to/pigmeo-compiler/output/pigmeo-compiler.exe`
		or if you installed the scripts simply run:
		`pigmeo`

	on Windows:
		-double click on pigmeo-compiler.exe


