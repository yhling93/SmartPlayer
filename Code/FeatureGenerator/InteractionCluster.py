from sklearn.cluster import KMeans
import numpy as np
import os

dataSetDirs = ['E:\Datas\\20170218\Interaction_Data', 'E:\Datas\\20170319\Interaction_Data']
dataSetNames = ['interactionWithWindowSize5', 'interactionWithWindowSize10']

if __name__ == '__main__':
    dataSetName = dataSetNames[0]
    data = []
    for dataSetDir in dataSetDirs:
        folders = os.listdir(dataSetDir)
        for folder in folders:
            interactionFilePath = dataSetDir + folder + dataSetName
            if not os.path.exists(interactionFilePath):
                continue
            interactionFile = open(interactionFile)
            lines = interactionFile.readlines()
            for line in lines:
                curFeature = line.split()
                data.append(curFeature)

    X = np.array(data)
    kMeans = KMeans(n_clusters=8).fix(X)
    print kMeans.cluster_centers_