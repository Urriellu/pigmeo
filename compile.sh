#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath

echo Compiling...

./CountLinesOfCode.sh

mkdir -p output/GAC

cp references/Mono.Cecil.dll output/GAC		#we need Cecil in the GAC because it is required by other libraries that must be in the GAC
./pigmeo-framework/compile.sh
./pigmeo-compiler/compile.sh
cp -a images output
cp -a i18n output


# cd into the directory where you were before running this script
cd $MyOldPath
