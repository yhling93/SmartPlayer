#!/usr/bin/python

from collections import Counter
from imblearn.over_sampling import SMOTE

import random
import numpy as np

featureFile = open("rawdata")
featureLines = featureFile.readlines()

dictFeature = {}

minorSet = set([1,4,5,6,7,8,11])

for i in range(0, len(featureLines)):
    features = featureLines[i].split()
    key = int(features[0])
    if not dictFeature.has_key(key):
        dictFeature[key] = []
    featureArray = []
    for j in range(1, len(features)):
        value = features[j].split(':')[1]
        featureArray.append(float(value))
    dictFeature[key].append(featureArray)

dictKeySize = {}
dictKeyOffset = {}
wholeFeatureArray = []

curoffset = 0
for key in dictFeature.keys():
    wholeFeatureArray.extend(dictFeature[key])
    dictKeySize[key] = len(dictFeature[key])
    dictKeyOffset[key] = curoffset
    curoffset += len(dictFeature[key])

sm = SMOTE(ratio=0.15, kind='borderline1')

for key in dictFeature.keys():
    if key in minorSet:
        keyOffset = dictKeyOffset[key]
        keySize = dictKeySize[key]
        largeArray = []
        largeArray.extend(wholeFeatureArray[0:keyOffset])
        largeArray.extend(wholeFeatureArray[keyOffset + keySize:])
        smallArray = dictFeature[key]
        #print len(largeArray), len(smallArray)
        largeY = [1] * len(largeArray)
        smallY = [0] * len(smallArray)
        largeArray.extend(smallArray)
        largeY.extend(smallY)
        X = np.array(largeArray)
        y = np.array(largeY)
        #print('Original dataset shape {}'.format(Counter(y)))
        X_res, y_res = sm.fit_sample(X,y)
        #print('Resample dataset shape {}'.format(Counter(y_res)))
        newArray = []
        for j in range(0, len(y_res)):
            if y_res[j] == 0:
                # X_res is a small class
                newArray.append(X_res[j])
        dictFeature[key] = newArray

total = 0
targetFile = file('./data_after_smote','w+')
targetArray = []
for key in dictFeature.keys():
    #print key, len(dictFeature[key])
    #total += len(dictFeature[key])
    for i in range(0, len(dictFeature[key])):
        string = str(key)
        featureArray = dictFeature[key][i]
        for j in range(0, len(featureArray)):
           string = string + ' ' + str(j) + ':' + str(featureArray[j])
        string += '\n'
        targetArray.append(string)

targetFile.writelines(targetArray)


'''
X = np.array(wholeFeatureArray)
y = np.array(labels)

#y = labels
#print y
print('Original dataset shape {}'.format(Counter(y)))
#print y

sm = SMOTE(ratio=0)

X_res, y_res = sm.fit_sample(X,y)

print('Resample dataset shape {}'.format(Counter(y_res)))
'''
