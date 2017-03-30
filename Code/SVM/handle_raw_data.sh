#!/bin/bash
dataDir=/home/adam/Experiment_Data/$1/Interaction_Data

#workDir=$dataDir/$2
#python readfile.py $workDir

for dir in `ls $dataDir`
do
    workDir=$dataDir/$dir
    echo 'handling dir:'$workDir
    python readfile.py $workDir
done
