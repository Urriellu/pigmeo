#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo "Building PMC"
	gmcs -t:exe -lib:../references,../output,../output/GAC -r:System.Core.dll,System.Data.dll,Pigmeo.dll,Pigmeo.Internal.dll,Pigmeo.Extensions.dll -doc:../output/GAC/pmc.xml -out:../output/pmc.exe src/*.cs
echo -e "\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
