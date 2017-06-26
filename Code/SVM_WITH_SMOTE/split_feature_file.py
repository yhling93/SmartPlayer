#!/usr/bin/python
import random
from sys import argv

#workDir = "/home/adam/SmartPlayer/Code/SVM_Multi_Undersampling_Plus_Minus_Oversampling"
#featureFile = open("/home/adam/SmartPlayer/Code/SVM_Multi_Undersampling_Plus_Minus_Oversampling/datas/fourninedata.scale")

workDir = './raw_datas'
#featureFileName = 'data_after_boardline_smote.scale'
featureFileName = 'data_after_boardline_smote_and_pca_with_49.scale'

featureFile = open(workDir + '/' + featureFileName)
featureLines = featureFile.readlines()
totalNums = len(featureLines)

ration = argv[1]

dataList = {}

isStatistic = True 

if not isStatistic:
    trainSet = file(workDir + '/' + featureFileName + '.train_' + str(ration), "w+")
    testSet = file(workDir + '/' + featureFileName + '.test_' + str(ration), "w+")


for str in featureLines:
    tmpStr = str.split()[0] # get the label

    # append string to the label dict item
    idx = int(tmpStr)

    if not (idx == 2 or idx == 3 or idx == 12):
        if dataList.has_key(idx):
            dataList[idx].append(str)
        else:
            dataList[idx] = []
            dataList[idx].append(str)

cnt = 0

for key in dataList.keys():
    partion = 1
    #if key == 9: # normal or unknown state
    #    partion = 3
    #if key == 10:
    #    partion = 2
    random.shuffle(dataList[key])

    totalLength = int(len(dataList[key]) / partion)
    cnt += totalLength
    trainLength = int(totalLength * float(ration))
    testLength = totalLength - trainLength
    

    #length = int(len(dataList[key]) * float(ration))
    #print 'key: ', key, ' total: ', len(dataList[key]), ' train: ', length, 'test: ', len(dataList[key]) - length
    print 'key: ', key, ' total: ', totalLength, ' train: ', trainLength, 'test: ', testLength
    if not isStatistic:
        trainSet.writelines(dataList[key][0:trainLength])
        testSet.writelines(dataList[key][trainLength:totalLength])

print 'Total size: ', cnt
featureFile.close()
if not isStatistic:
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
