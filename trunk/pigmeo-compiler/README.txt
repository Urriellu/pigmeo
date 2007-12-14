"pigmeo-compiler" is part of "pigmeo" project.
Visit http://pigmeo.urriellu.net for more information




License:
	GNU General Public License v3

	the entire license text is in the file COPYING.txt

===============================

Compilation on Unix-like systems:
	`./compile.sh`


Now everything you need is in the "output" directory

===============================

Installation:
	You don't need to install it

	If you want to install it you only need to copy "output" directory to wherever you want.
	For example (on unix-like):
		`cp output /usr/share/pigmeo`

	If you want to exceute if comfortably you can create a script called "pigmeo" in the binaries directory (i.e. /usr/bin) with the following contents (replace /usr/share/pigmeo with the path to its installation directory)
		#!/bin/sh
		exec /usr/bin/mono /usr/share/pigmeo/pigmeo-compiler.exe "$@"
	and make it executable (chmod 755 /usr/bin/pigmeo)

===============================

Execution:
	on Unix-like:
		`mono /path/to/pigmeo-compiler/output/pigmeo-compiler.exe`
		or if you installed it:
		`mono /usr/share/pigmeo/pigmeo-compiler.exe`

	on Windows:
		-run `pigmeo-compiler.exe` form the command line