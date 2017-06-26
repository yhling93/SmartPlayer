#!/usr/bin/python

import re
import sys
import random


workDir = sys.argv[1] # get work dir
fakeThreshold = int(sys.argv[2]) # fake num threshold

featureFile = open(workDir + '/feature_file')
featureFakeFile = file(workDir + '/feature_fake_file', "w+")

featureLines = featureFile.readlines()

dataDic = {}

for str in featureLines:

    label = int(str.split()[0])
    if not dataDic.has_key(label) and not (label == 2 or label == 3 or label == 12):
        dataDic[label] = []
    if not (label == 2 or label == 3 or label == 12):
        dataDic[label].append(str)

# fake procedure
for key in dataDic.keys():
    if len(dataDic[key]) < fakeThreshold:
        while len(dataDic[key]) < fakeThreshold:
            dataDic[key].extend(dataDic[key]) 
    featureFakeFile.writelines(dataDic[key])


