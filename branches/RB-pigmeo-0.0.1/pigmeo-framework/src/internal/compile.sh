#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo -e "\tBuilding the (internal) global things of the Pigmeo Framework"
	gmcs -t:library -lib:../../../references,../../../output/GAC -r:Mono.Cecil.dll,System.Core.dll,Pigmeo.dll,Pigmeo.Extensions.dll  -doc:../../../output/GAC/Pigmeo.Internal.xml -out:../../../output/GAC/Pigmeo.Internal.dll *.cs PIC14/*.cs
echo -e "\t\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
