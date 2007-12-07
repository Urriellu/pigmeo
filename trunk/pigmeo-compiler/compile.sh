#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo "Building the Pigmeo Compiler"
	gmcs -t:exe -lib:../references,../pigmeo-framework/output -r:Mono.Cecil.dll,Pigmeo.dll,Pigmeo.Internal.dll -out:output/pigmeo-compiler.exe src/*.cs src/BackendPIC8bit/*.cs src/BackendPIC8bit/instructions/*.cs #src/CilFrontend/*.cs
	cp ../references/Mono.Cecil.dll output/
echo -e "\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
