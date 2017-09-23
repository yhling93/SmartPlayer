# This python script read data set from folders and merge them into a whole data set
import os
import random

SMOTE_MODE = True

def singleDataSetGenerator():
    windowSize = [5, 10]
    folders = ['E:\Datas\\20170218', 'E:\Datas\\20170319']
    mergeFlag = [0, 1, 2]
    for i in range(len(windowSize)):
        for j in range(len(mergeFlag)):
            command = ''
            command += 'python FeatureMerger.py '
            command += folders[0] + ' ' + folders[1] + ' ' + str(windowSize[i]) + ' ' + str(mergeFlag[j])
            os.system(command)

def handleRawFeatureLines(featureLines):
    ratio = 0.8

    dataMap = {}
    # construct data map
    for line in featureLines:
        tmpStr = line.split()[0] # get the label
        label = int(tmpStr)

        if not (label == 2 or label == 3 or label == 12):
            if dataMap.has_key(label):
                dataMap[label].append(line)
            else:
                dataMap[label] = []
                dataMap[label].append(line)

    trainSet, testSet = [], []
    # random sampling to target ratio
    for label in dataMap.keys():
        partion = 1
        if label == 9 and not SMOTE_MODE:
            partion = 3
        if label == 10 and not SMOTE_MODE:
            partion = 2
        random.shuffle(dataMap[label])
        oriCount = len(dataMap[label])
        decimatedCount = int(oriCount / partion)

        trainLength = int(decimatedCount * ratio)
        testLength = decimatedCount - trainLength
        print 'Label: %s, Origin Count: %d, Decimated Count: %d, Train Count: %d, Test Count: %d'%(label, oriCount, decimatedCount, trainLength, testLength)
        trainSet.extend(dataMap[label][0:trainLength])
        testSet.extend(dataMap[label][trainLength:decimatedCount])

    return trainSet, testSet

def writeToFile(trainSet, testSet, outputFileNamePrefix):
    print 'Writing Data Set File' + outputFileNamePrefix

    outTrainFile = open(outputFileNamePrefix + '_train', 'w')
    outTestFile = open(outputFileNamePrefix + '_test', 'w')

    outTrainFile.writelines(trainSet)
    outTestFile.writelines(testSet)

    outTrainFile.close()
    outTestFile.close()

if __name__ == '__main__':
    targetDir = 'E:\Datas\wholeSet'
    if SMOTE_MODE:
        dataSetFileNames = { 'dataset_appearance_smote',
                        'dataset_interactionWithWindowSize5_smote', 'dataset_interactionWithWindowSize10_smote',
                        'dataset_mergedWithWindowSize5_smote', 'dataset_mergedWithWindowSize10_smote' }
        for dataSetName in dataSetFileNames:
            file = open(targetDir + '/' + dataSetName)
            lines = file.readlines()

            # handle data set
            trainSet, testSet = handleRawFeatureLines(lines)
            writeToFile(trainSet, testSet, targetDir + '/' + dataSetName)
        exit(0)

    targetRatio = 0.8
    folders = ['E:\Datas\\20170218\\Interaction_Data', 'E:\Datas\\20170319\\Interaction_Data']
    dataSetFileNames = { 'dataset_appearance',
                        'dataset_interactionWithWindowSize5', 'dataset_interactionWithWindowSize10',
                        'dataset_mergedWithWindowSize5', 'dataset_mergedWithWindowSize10' }

    targetDir = 'E:\Datas\wholeSet'


    for dataSetFileName in dataSetFileNames:
        dataSet = []
        for folder in folders:
            subFolders = os.listdir(folder)
            for subFolder in subFolders:
                filePath = folder + '/' + subFolder + '/' + dataSetFileName
                if not os.path.exists(filePath):
                    continue
                featureFile = open(filePath)
                curLines = featureFile.readlines()
                dataSet.extend(curLines)
                featureFile.close()

        # handle data set
        trainSet, testSet = handleRawFeatureLines(dataSet)
        writeToFile(trainSet, testSet, targetDir + '/' + dataSetFileName)
