#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo -e "\tBuilding the classes available for all the microcontrollers, but not for PC"
	gmcs -t:library -langversion:linq -r:System.Core.dll -doc:../../../output/doc/Pigmeo.MCU.xml -out:../../../output/GAC/Pigmeo.MCU.dll *.cs
echo -e "\t\t[DONE]"



# cd into the directory where you were before running this script
cd $MyOldPath
