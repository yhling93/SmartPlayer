#!/bin/bash
dataDir=/home/adam/Experiment_Data/$1/Interaction_Data

for dir in `ls $dataDir`
do
    `cat $dataDir/$dir/feature_fake_file >> all_feature_set`
    #workDir=$dataDir/$dir
    #echo 'handling dir:'$workDir
    #python readfile.py $workDir
done
