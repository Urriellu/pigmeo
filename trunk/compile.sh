#!/bin/bash

# cd into the script's directory
MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath

echo Compiling...

./CountLinesOfCode.sh

mkdir -p output/GAC
mkdir -p output/doc

./pigmeo-framework/compile.sh
./pigmeo-compiler/compile.sh


# cd into the directory where you were before running this script
cd $MyOldPath
