#!/bin/bash
dataDir1=/home/adam/Experiment_Data/20170218/Interaction_Data
dataDir2=/home/adam/Experiment_Data/20170319/Interaction_Data

for dir in `ls $dataDir1`
do
    workDir=$dataDir1/$dir
    python readfile.py $workDir
done
for dir in `ls $dataDir2`
do
    workDir=$dataDir2/$dir
    python readfile.py $workDir
done
