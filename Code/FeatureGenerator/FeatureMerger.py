from sys import argv
import os

def MergeFeature(folderpath, windowSize):
    interactionFeatureFile = open(folderPath + '/interactionFeatureWithWindowSize' + str(windowSize)) # the idx of features is [0, 19] interactionfeatures:20
    faceFile = open(folderPath + '/Facedata.md') # the idx of features is [20, 275] facefeatures:256
    labelFile = open(folderPath + '/label.txt')

def HandleInteractionFeature(interactionLines, target):
    for line in interactionLines:
        curfeature = line.split( )
        toStr = ""
        for i in range(len(curfeature)):
            toStr += str(i) + ':' + curfeature[i] + ' '
        target.append(toStr)
    return

def TransfromToSvmFormat(rawfeature):
    print 'test'

if __name__ == '__main__':
# param 0: script name | 1 - (n-3)th: folders | (n-2)th: windowSize | (n-1)th: mergerFlag { 0:only interaction, 1:only appearance, 2:together }
    folderCnt = len(argv) - 3
    windowSize = int(argv[len(argv) - 2])
    mergerFlag = int(argv[len(argv) - 1])
    print 'Total Folder Count: ', folderCnt
    # traverse folders
    for i in range(0, folderCnt):
        print 'Folder: %i, Path: %s'%(i,argv[i + 1])
        folderPath = argv[i + 1] + '/Interaction_Data'
        folders = os.listdir((folderPath))
        for folder in folders:
            outDatasetFileName = ''
            outDataset = []
            # if only interaction, merge inteaction and label
            if mergerFlag == 0:
                outDatasetFileName = open(folderPath + '/' + folder + '/dataset_interactionWithWindowSize' + str(windowSize), 'w')
            # if only appearance, fill according to interaction and then merge appearance and label
            elif mergerFlag == 1:
                outDatasetFileName = open(folderPath + '/' + folder + '/dataset_appearance', 'w')
            # if together, fill appearance according to interaction and merge interaction, appearance and label
            elif mergerFlag == 2:
                outDatasetFileName = open(folderPath + '/' + folder + '/dataset_mergedWithWindowSize' + str(windowSize), 'w')
            #MergeFeature(folderPath + '/' + folder, windowSize)