#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo -e "\tBuilding the (internal) global things of the Pigmeo Framework"
	gmcs -t:library -langversion:linq -lib:../../../references,../../output/ -r:Mono.Cecil,System.Core.dll,Pigmeo.dll -out:../../output/Pigmeo.Internal.dll *.cs
echo -e "\t\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
