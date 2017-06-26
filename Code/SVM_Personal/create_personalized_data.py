import sys,os
import random

baseDataDir = ['/home/adam/Experiment_Data/20170218/Interaction_Data','/home/adam/Experiment_Data/20170319/Interaction_Data']

dataLines = []
dataTrainSetArr = {}
dataTestSetArr = {}

allTrainSet = []

cnt = 0
recordCnt = 0

for i in range(len(baseDataDir)):
    for dirpath, dirnames, filenames in os.walk(baseDataDir[i]):
        featureFileName = dirpath + '/feature_file'
        if os.path.exists(featureFileName):
            if not dataTrainSetArr.has_key(cnt):
                dataTrainSetArr[cnt] = []
                dataTestSetArr[cnt] = []
            if i == 0:
                recordCnt = cnt + 1
            featureFile = open(featureFileName)
            featureLines = featureFile.readlines()
            dataSize = len(featureLines)
            dataDic = {}
            for curstr in featureLines:
                tmpStr = curstr.split()[0]
                idx = int(tmpStr)
                if dataDic.has_key(idx):
                    dataDic[idx].append(curstr)
                else:
                    dataDic[idx] = []
                    dataDic[idx].append(curstr)

            for key in dataDic.keys():
                random.shuffle(dataDic[key])
                length = int(len(dataDic[key]) * 0.8)
                dataTrainSetArr[cnt].extend(dataDic[key][0:length])
                dataTestSetArr[cnt].extend(dataDic[key][length:])
            cnt += 1
            featureFile.close()

for key in dataTrainSetArr.keys():
    allTrainSet.extend(dataTrainSetArr[key])

trainSetFile = file('/home/adam/SmartPlayer/Code/SVM_Personal/datas/personal_train', 'w+')
trainSetFile.writelines(allTrainSet)

for j in range(recordCnt):
    testSetFile = file("/home/adam/SmartPlayer/Code/SVM_Personal/datas/personal_test_" + str(j), 'w+')
    testSetFile.writelines(dataTestSetArr[j])
    testSetFile.close()
    
