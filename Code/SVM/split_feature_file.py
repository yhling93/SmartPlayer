#!/usr/bin/python
import random

workDir = "/home/adam/SmartPlayer/Code/SVM"
featureFile = open("/home/adam/SmartPlayer/Code/SVM/all_feature_set.scale")
featureLines = featureFile.readlines()
totalNums = len(featureLines)

random.shuffle(featureLines)

foldNum = 10
featureEveryFold = totalNums / foldNum

for i in range(foldNum):
    # 0 ~ x train set
    # x ~ x + featureEveryFold test set
    # x + featureEveryFold ~ end train set
    trainSet = file(workDir + "/datas/trainset" + str(i), "w+")
    testSet = file(workDir + "/datas/testset" + str(i), "w+")

    curFeatureFoldStartIdx = i * featureEveryFold
    curFeatureFoldEndIdx = curFeatureFoldStartIdx + featureEveryFold

    trainSet.writelines(featureLines[0:curFeatureFoldStartIdx])
    testSet.writelines(featureLines[curFeatureFoldStartIdx:curFeatureFoldEndIdx])
    trainSet.writelines(featureLines[curFeatureFoldEndIdx:])
    trainSet.close()
    testSet.close()
