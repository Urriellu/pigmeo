#!/bin/bash

MyPath=`dirname $0`
MyOldPath=$PWD
cd $MyPath

LinesFramework=`find pigmeo-framework -type f -name "*.cs" 2>/dev/null | xargs cat | wc -l`
FilesFramework=`ls -R pigmeo-framework | grep .cs$ | wc -l`
LinesCompiler=`find pigmeo-compiler -type f -name "*.cs" 2>/dev/null | xargs cat | wc -l`
FilesCompiler=`ls -R pigmeo-compiler | grep .cs$ | wc -l`
let TotalLines=$LinesFramework+$LinesCompiler
let TotalFiles=$FilesFramework+$FilesCompiler
echo Framework: $LinesFramework lines of code in $FilesFramework \".cs\" files
echo Compiler: $LinesCompiler lines of code in $FilesCompiler \".cs\" files
echo Total: $TotalLines lines of code in $TotalFiles \".cs\" files

cd "$MyOldPath"


