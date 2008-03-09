#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo -e "\tBuilding the extensions to .NET Framework"
	gmcs -t:library -langversion:linq -r:System.Core.dll,System.Drawing.dll -doc:../../../output/GAC/Pigmeo.Extensions.xml -out:../../../output/GAC/Pigmeo.Extensions.dll *.cs
echo -e "\t\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
