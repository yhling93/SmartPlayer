#!/bin/bash
dataDir=/home/adam/Experiment_Data/$1/Interaction_Data

for dir in `ls $dataDir`
do
    workDir=$dataDir/$dir
    echo 'handling dir:'$workDir
    python create_fake_data.py $workDir $2
done
