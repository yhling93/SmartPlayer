#!/usr/bin/python
import random
from sys import argv

workDir = "/home/adam/SmartPlayer/Code/SVM_Fake"
featureFile = open("/home/adam/SmartPlayer/Code/SVM_Fake/all_feature_set.scale")
featureLines = featureFile.readlines()
totalNums = len(featureLines)

ration = argv[1]

dataList = {}

trainSet = file(workDir + "/datas/trainset_with_ration" + str(ration), "w+")
testSet = file(workDir + "/datas/testset_with_ration" + str(ration), "w+")


for str in featureLines:
    tmpStr = str.split()[0] # get the label

    # append string to the label dict item
    idx = int(tmpStr)
    if dataList.has_key(idx):
        dataList[idx].append(str)
    else:
        dataList[idx] = []
        dataList[idx].append(str)


for key in dataList.keys():
    random.shuffle(dataList[key])
    length = int(len(dataList[key])*float(ration))
    print 'key: ', key, ' total: ', len(dataList[key]), ' train: ', length, 'test: ', len(dataList[key]) - length
    trainSet.writelines(dataList[key][0:length])
    testSet.writelines(dataList[key][length:])


featureFile.close()
trainSet.close()
testSet.close()

'''
random.shuffle(featureLines)

foldNum = 5
featureEveryFold = totalNums / foldNum

for i in range(1):
    # 0 ~ x train set
    # x ~ x + featureEveryFold test set
    # x + featureEveryFold ~ end train set
    trainSet = file(workDir + "/datas/trainset_with_fold" + str(foldNum) + "_" + str(i), "w+")
    testSet = file(workDir + "/datas/testset_with_fold" + str(foldNum) + "_" + str(i), "w+")

    curFeatureFoldStartIdx = i * featureEveryFold
    curFeatureFoldEndIdx = curFeatureFoldStartIdx + featureEveryFold

    trainSet.writelines(featureLines[0:curFeatureFoldStartIdx])
    testSet.writelines(featureLines[curFeatureFoldStartIdx:curFeatureFoldEndIdx])
    trainSet.writelines(featureLines[curFeatureFoldEndIdx:])
    trainSet.close()
    testSet.close()
'''
