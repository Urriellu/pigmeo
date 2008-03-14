#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo "Building the Pigmeo Compiler"
	gmcs -t:winexe -langversion:linq -lib:../references,../output,../output/GAC -r:System.Core.dll,System.Data.dll,System.Drawing.dll,System.Windows.Forms.dll,Mono.Cecil.dll,Pigmeo.dll,Pigmeo.Internal.dll,Pigmeo.Extensions.dll -doc:../output/GAC/pigmeo-compiler.xml -out:../output/pigmeo-compiler.exe src/*.cs src/BackendPIC14/*.cs src/BackendPIC14/instructions/*.cs src/UI/*.cs src/UI/WinForms/*.cs
echo -e "\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
