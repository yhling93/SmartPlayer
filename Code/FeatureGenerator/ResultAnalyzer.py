
resultList = ['dataset_interactionWithWindowSize10', 'dataset_interactionWithWindowSize5', 'dataset_appearance',
              'dataset_mergedWithWindowSize5', 'dataset_mergedWithWindowSize10']
smoteResultList = ['dataset_interactionWithWindowSize10_smote', 'dataset_interactionWithWindowSize5_smote', 'dataset_appearance_smote',
              'dataset_mergedWithWindowSize5_smote', 'dataset_mergedWithWindowSize10_smote']
ReverseLabelMap = {1:'amuse', 2:'tired', 3:'despise',
        4:'thinking', 5:'notetaking', 6:'confused',
        7:'surprised', 8:'distracted', 9:'normal',
        10:'unknow', 11:'concentrated', 12:'bored'}

dataSetDir = 'E:\Datas\wholeSet'
testSetSuffix = '_test'
resultSuffix = '.result'

def Statistics(dataSetName):
    print 'Handling data set: ', dataSetName

    testSetFile = open(dataSetDir + '/' + dataSetName + testSetSuffix)
    resultFile = open(dataSetDir + '/' + dataSetName + resultSuffix)
    testLines = testSetFile.readlines()
    realResult, predictResult = [], []
    for line in testLines:
        label = int(line.split()[0])
        realResult.append(label)

    resultFile.readline() # skip fisrt line
    predictLines = resultFile.readlines()
    for line in predictLines:
        label = int(line.split()[0])
        predictResult.append(label)

    # statistics
    exactMap, predictMap, realMap = {}, {}, {}
    totalCnt, matchCnt = len(realResult), 0
    for i in range(0, len(realResult)):
        realMap[realResult[i]] = realMap.get(realResult[i], 0) + 1
        predictMap[predictResult[i]] = predictMap.get(predictResult[i], 0) + 1
        if realResult[i] == predictResult[i]:
            exactMap[realResult[i]] = exactMap.get(realResult[i], 0) + 1
            matchCnt += 1

    for label in realMap.keys():
        print '########### Label: ', ReverseLabelMap[label], '###########'
        accuracy, recall, f1 = 0.0, 0.0, 0.0
        if realMap.get(label ,0) != 0:
            accuracy = 1.0 * exactMap.get(label, 0) / realMap.get(label)
        if predictMap.get(label, 0) != 0:
            recall = 1.0 * exactMap.get(label, 0) / predictMap.get(label)
        if (accuracy + recall) != 0:
            f1 = 2.0 * accuracy * recall / (accuracy + recall)
        print 'key: ', ReverseLabelMap[label], ' accuracy: ', accuracy, ' recall: ', recall, ' f1 value: ',f1
        print 'real cnt: ', realMap.get(label, 0), 'predict cnt: ', predictMap.get(label, 0), 'exact cnt: ', exactMap.get(label, 0)
    print 'total accuracy: ', 1.0 * matchCnt / totalCnt

if __name__ == '__main__':
    for dataSetName in smoteResultList:
        Statistics(dataSetName)