#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo -e "\tBuilding the global things of the Pigmeo Framework"
	gmcs -t:library -langversion:linq -r:System.Core.dll -out:../../output/Pigmeo.dll *.cs
echo -e "\t\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
