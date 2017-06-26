#!/usr/bin/python

import numpy as np
from sklearn.decomposition import PCA

filename = 'data_after_boardline_smote' # the file name should be set

rawdatafile = open(filename)


rawlines = rawdatafile.readlines()

size = len(rawlines)
labels = []

wholeFeaturesArray = []
for i in range(0, size):
    features = rawlines[i].split()
    labels.append(features[0])
    featureArray = []
    for j in range(1, len(features)):
        value = features[j].split(':')[1]
        featureArray.append(value)
    wholeFeaturesArray.append(featureArray)

X = np.array(wholeFeaturesArray)

pca = PCA(n_components=0.9999,copy=True)
newX = pca.fit_transform(X)


targetFileName = filename + '_and_pca_with_49'

targetFile= file(targetFileName, "w+")
print newX.shape[0]

targetStrArr = []

for i in range(0, newX.shape[0]):
    string = labels[i]
    for j in range(0, newX.shape[1]):
        string = string + ' ' + str(j) + ':' + str(newX[i][j])
    string = string + '\n'
    targetStrArr.append(string)

targetFile.writelines(targetStrArr)
#print pca.explained_variance_ratio_
#print pca.explained_variance_:q;q;q;eiiidad
#print pca.n_components_



