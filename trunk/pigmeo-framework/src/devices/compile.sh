#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath


echo -e "\tBuilding the libraries for each device"	
	for i in $(ls *.cs); do
		i=`echo $i | sed s/.cs$//`
		echo -e "\t\tBuilding: $i.dll"
		gmcs -t:library -langversion:linq -lib:../../../output/,../../../output/GAC/ -r:System.Core.dll,Pigmeo.dll,Pigmeo.Internal.dll,Pigmeo.Extensions.dll -doc:../../../output/GAC/$i.xml -out:../../../output/GAC/$i.dll $i.cs
	done



# cd into the directory where you were before running this script
cd $MyOldPath
