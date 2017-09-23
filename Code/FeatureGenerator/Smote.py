from imblearn.over_sampling import SMOTE
from collections import Counter
import numpy as np
dataSetNames = ['dataset_interactionWithWindowSize5', 'dataset_interactionWithWindowSize10',
                'dataset_appearance', 'dataset_mergedWithWindowSize5', 'dataset_mergedWithWindowSize10']
dataSetDir = 'E:\Datas\wholeSet'

def handleLines(datas, labels, lines):
    for line in lines:
        curFeature = line.split()
        curLabel = curFeature[0]
        labels.append(int(curLabel))
        tmpSet = []
        for i in range(1, len(curFeature)):
            feature = curFeature[i].split(':')[1]
            tmpSet.append(float(feature))
        datas.append(tmpSet)

if __name__ == '__main__':
    for i in range(len(dataSetNames)):
        dataSetName = dataSetNames[i]
        print 'Handling ', dataSetName
        trainSetFile = open(dataSetDir + '/' + dataSetName + '_train')
        testSetFile = open(dataSetDir + '/' + dataSetName + '_test')
        trainLines = trainSetFile.readlines()
        testLines = testSetFile.readlines()

        datas = []
        labels = []

        handleLines(datas, labels, trainLines)
        handleLines(datas, labels, testLines)

        X = np.array(datas)
        Y = np.array(labels)

        print('Original dataset shape {}'.format(Counter(Y)))

        sm = SMOTE(kind='svm')

        X_res, Y_res = sm.fit_sample(X,Y)
        print('Resampled dataset shape {}'.format(Counter(Y_res)))

        outPutFile = open(dataSetDir + '/' + dataSetName + '_smote', 'w')
        for i in range(len(Y_res)):
            outStr = str(Y_res[i]) + ' '
            featureLen = len(X_res[i])
            for j in range(featureLen - 1):
                outStr += str(j) + ':' + str(X_res[i][j]) + ' '
            outStr += str(featureLen - 1) + ':' + str(X_res[featureLen - 1][j])
            outStr += '\n'
            outPutFile.write(outStr)

        testSetFile.close()
        trainSetFile.close()
        outPutFile.close()