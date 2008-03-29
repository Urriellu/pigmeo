#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo -e "\tBuilding classes available for everybody: PC apps, MCU apps, compiler, debugger..."
	gmcs -t:library -langversion:linq -r:System.Core.dll -doc:../../output/GAC/Pigmeo.xml -out:../../output/GAC/Pigmeo.dll *.cs
echo -e "\t\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath