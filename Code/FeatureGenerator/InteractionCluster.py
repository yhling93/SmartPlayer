from sklearn.cluster import KMeans
import numpy as np
import os

dataSetDirs = ['E:\Datas\\20170218\Interaction_Data', 'E:\Datas\\20170319\Interaction_Data']
dataSetNames = ['interactionFeatureWithWindowSize5', 'interactionFeatureWithWindowSize10']
featureList = ['Play', 'Pause', 'FullScreen', 'PlayTime', 'Rate', 'FastF', 'Rewind', 'ForwardS', 'ReverseS', 'PauseCnt',
               'PauseLen', 'FastFCnt', 'FastFLen', 'RewindCnt', 'RewindLen', 'ForwardSCnt', 'ForwardSLen', 'ReverseSCnt',
               'ReverseSLen', 'AvgPlayRate']

if __name__ == '__main__':
    dataSetName = dataSetNames[1]
    data = []
    for dataSetDir in dataSetDirs:
        folders = os.listdir(dataSetDir)
        for folder in folders:
            interactionFilePath = dataSetDir + '/' + folder + '/' + dataSetName
            if not os.path.exists(interactionFilePath):
                continue
            interactionFile = open(interactionFilePath)
            lines = interactionFile.readlines()
            for line in lines:
                curFeature = line.split()
                curFeatureSet = []
                for i in range(len(curFeature)):
                    curFeatureSet.append(float(curFeature[i]))
                data.append(curFeatureSet)
            interactionFile.close()
    print 'start clustering'
    feature_cnt = 20
    n_cluster = 8
    X = np.array(data)
    kMeans = KMeans(n_clusters=n_cluster, max_iter=1000, n_init=20).fit(X)
    for i in range(len(kMeans.cluster_centers_)):
        outPutStr = ''
        for j in range(feature_cnt):
            if j == 2 or j == 3 or j == 5 or j == 6 or j == 11 or j == 12 or j == 13 or j == 14:
                continue
            val = round(kMeans.cluster_centers_[i][j], 2)
            if val == -0.0:
                val = 0.0
            outPutStr += featureList[j] + ':' + str(val) + '\t'
        outPutStr += '\n'
        print outPutStr

    labelMap = {}
    for i in range(len(kMeans.labels_)):
        curLabel = kMeans.labels_[i];
        if labelMap.has_key(curLabel):
            labelMap[curLabel] = labelMap[curLabel] + 1
        else:
            labelMap[curLabel] = 1

    resultStr = ''

    for label in labelMap.keys():
        resultStr += str(label) + ':' + str(labelMap[label]) + '\t'
    print resultStr