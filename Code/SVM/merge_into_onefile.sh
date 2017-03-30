#!/bin/bash
dataDir=/home/adam/Experiment_Data/$1/Interaction_Data

#workDir=$dataDir/$2
#python readfile.py $workDir

for dir in `ls $dataDir`
do
    `cat $dataDir/$dir/feature_file >> all_feature_set`
    #workDir=$dataDir/$dir
    #echo 'handling dir:'$workDir
    #python readfile.py $workDir
done
