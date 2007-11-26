#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo "Building the Pigmeo Compiler"
	gmcs -t:exe -lib:src/references -r:Mono.Cecil.dll -out:output/pigmeo-compiler.exe src/*.cs src/CilFrontend/*.cs
echo -e "\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
