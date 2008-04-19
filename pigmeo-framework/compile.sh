#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo "Building the Pigmeo Framework"
	./src/extensions/compile.sh
	./src/compile.sh
	./src/internal/compile.sh
	./src/devices/compile.sh
	./src/MCU/compile.sh



# cd into the directory where you were before running this script
cd $MyOldPath
