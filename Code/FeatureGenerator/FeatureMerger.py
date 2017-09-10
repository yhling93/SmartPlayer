from sys import argv
import os
import re

LabelMap = {'amused':1,'tired':2,'despise':3,
        'thinking':4,'notetaking':5,'confused':6,
        'surprised':7,'distracted':8,'normal':9,
        'unknow':10,'concentrated':11, 'bored':12}

def HandleInteractionFeature(interactionLines, target):
    for line in interactionLines:
        curFeature = line.split( )
        curFeatureSet = []
        toStr = ""
        for i in range(len(curFeature)):
            curFeatureSet.append(curFeature[i])
            '''
            if not i == len(curFeature) - 1:
                toStr += str(i) + ':' + curFeature[i] + ' '
            else:
                toStr += str(i) + ':' + curFeature[i]
            featureIdx = featureIdx + 1
           '''
        #target.append(toStr)
        target.append(curFeatureSet)

def HandleAppearanceFeature(faceLines, target, count, canUse):
    if count > len(faceLines):
        for i in range(0, count - len(faceLines)):
            faceLines.insert(0,'')
    for i in range(0, count):
        curFeatureSet = []
        line = faceLines[i]
        curFeature=re.split('\s+', line)
        # total 121 feature
        if len(curFeature) < 258:
            # if feature doesn't meet requirement, set the can use flag to be false
            canUse[i] = False
            for j in range(0, 256):
                curFeatureSet.append(0)
                '''
                if not j == 255:
                    target[i] += str(featureIdx + j) + ':0 '
                elif j == 255:
                    target[i] += str(featureIdx + j) + ':0'
              '''
            target.append(curFeatureSet)
        elif len(curFeature) == 258:
            # if feature doesn't meet requirement, set the can use flag to be false
            canUse[i] = checkFaceFeature(curFeature)
            print str(i) + "can use ?" + str(canUse[i])
            for j in range(1, 257):
                curFeatureSet.append(curFeature[j])
                '''
                if not j == 256:
                    target[i] += str(featureIdx + j) + ':' + curFeature[j] + ' '
                elif j == 256:
                    target[i] += str(featureIdx + j) + ':' + curFeature[j]
              '''
            target.append(curFeatureSet)
    return

def HandleLabel(labelLines, target, count):
    print "in handling_label fun, count is",count
    last_time=0
    line = labelLines[0]
    labelFeature= re.split('\s+',line)

    for i in range(0, count):
        target.append(0)
    # get the start play time
    startPlayTime = int(labelFeature[0])
    # set the label unknown from 0 to startPlayTime
    for ts in range(0, startPlayTime + 1):
        target[i] = 10
        #target[ts] = '10 ' + target[ts]

    last_time = startPlayTime

    for i in range(1 , len(labelLines) - 1):

        # get the label line
        line = labelLines[i]

        labelFeature = re.split('\s+',line)
        time_period = labelFeature[0].split('-')

        # get start time and end time
        st_time = int(time_period[0])
        end_time = int(time_period[1])

        # get label array
        cur_label = []
        cur_label_str = ''
        for key in LabelMap:
            # if find label str, than add label the to array
            if line.find(key) >= 0:
                cur_label.append(LabelMap[key])
                break

        # construct label str like '1,2'
        for label_i in range(0,len(cur_label) - 1):
            cur_label_str += str(cur_label[label_i]) + ','
        if len(cur_label) > 0:
            cur_label_str += str(cur_label[len(cur_label) - 1])

        # handle the time period
        for ts in range(st_time, end_time + 1):
            if ts >= count:
                break;
            #target[ts] = cur_label_str + ' ' + target[ts]
            target[ts] = int(cur_label_str)
        # handle the blank time
        if last_time is not 0 and last_time < st_time:
            for ts in range(last_time + 1, st_time):
                if ts >= count:
                    break;
                #target[ts] = '9 ' + target[ts]
                target[ts] = 9

        last_time = end_time

    # handle the last str
    line = labelLines[len(labelLines) - 1]
    #labelfeature = re.split('\s+', line);
    for ts in range(last_time + 1, count):
        #target[ts]='10 ' + target[ts]
        target[ts] = 10
    return

def checkFaceFeature(curFeature):
    # if the number of zeros > half of the features, then this feature is invalid
    count = 256
    zeroCount = 0
    for i in range(1, 257):
        if curFeature[i] == 0:
            zeroCount += 1

    rate = 1.0 * zeroCount / count
    return rate < 0.5

def WriteToFile(outfile, canUse, interactionFeatureSet, appearanceFeatureSet, labelSet, useInteraction, useAppearance):
    totalSize = len(labelSet)
    for i in range(0, totalSize):
        featureIdx = 0
        if canUse[i]:
            curStr = ''
            curStr += (str(labelSet[i]) + ' ')
            if useInteraction:
                interactionSet = interactionFeatureSet[i]
                for j in range(0, len(interactionSet)):
                    curStr += str(featureIdx) + ':' + str(interactionSet[j]) + ' '
                    featureIdx = featureIdx + 1
            if useAppearance:
                appearanceSet = appearanceFeatureSet[i]
                for j in range(0, len(appearanceSet)):
                    curStr += str(featureIdx) + ':' + str(appearanceSet[j]) + ' '
                    featureIdx = featureIdx + 1
            finalStr = curStr[0:len(curStr)-1]
            finalStr += '\n'
            outfile.write(finalStr)

    '''
    for i in range(0, len(toWriteData) - 1):
        toWriteData[i] += '\n'
    outfile.writelines(toWriteData)
    '''

if __name__ == '__main__':
# param 0: script name | 1 - (n-3)th: folders | (n-2)th: windowSize | (n-1)th: mergerFlag { 0:only interaction, 1:only appearance, 2:together }
    folderCnt = len(argv) - 3
    windowSize = int(argv[len(argv) - 2])
    mergerFlag = int(argv[len(argv) - 1])
    useInteraction, useAppearance = False, False
    print 'Total Folder Count: ', folderCnt
    # traverse folders
    for i in range(0, folderCnt):
        print 'Folder: %i, Path: %s'%(i,argv[i + 1])
        folderPath = argv[i + 1] + '/Interaction_Data'
        folders = os.listdir((folderPath))
        for folder in folders:
            print 'Handling Foler: %s'%(folder)
            outDatasetFile = ''
            outDataset = []
            featureIdx = 0
            interactionFilePath = folderPath + '/' + folder + '/interactionFeatureWithWindowSize' + str(windowSize)
            faceFilePath = folderPath + '/' + folder + '/Facedata.md'
            labelFilePath = folderPath + '/' + folder + '/label.txt'
            if not os.path.exists(interactionFilePath) or not os.path.exists(faceFilePath) or not os.path.exists(labelFilePath):
                continue
            interactionFile, faceFile, labelFile = open(interactionFilePath), open(faceFilePath), open(labelFilePath)
            interactionLines, faceLines, labelLines = interactionFile.readlines(), faceFile.readlines(), labelFile.readlines()
            # if only interaction, merge interaction and label
            if mergerFlag == 0:
                outDatasetFile = open(folderPath + '/' + folder + '/dataset_interactionWithWindowSize' + str(windowSize), 'w')
                useInteraction, useAppearance = True, False
            # if only appearance, fill according to interaction and then merge appearance and label
            elif mergerFlag == 1:
                outDatasetFile = open(folderPath + '/' + folder + '/dataset_appearance', 'w')
                useAppearance, useInteraction = True, False
            # if together, fill appearance according to interaction and merge interaction, appearance and label
            elif mergerFlag == 2:
                outDatasetFile = open(folderPath + '/' + folder + '/dataset_mergedWithWindowSize' + str(windowSize), 'w')
                useInteraction, useAppearance = True, True

            interactionFeatureSet, appearanceFeatureSet, labelSet = [], [], []
            HandleInteractionFeature(interactionLines, interactionFeatureSet)
            count = len(interactionFeatureSet)
            canUse = [True] * count
            HandleAppearanceFeature(faceLines, appearanceFeatureSet, count, canUse)
            HandleLabel(labelLines, labelSet, count)

            # TODO: NEED TO ELIMINATE UNQUALIFIED DATA
            WriteToFile(outDatasetFile, canUse, interactionFeatureSet, appearanceFeatureSet, labelSet, useInteraction, useAppearance)
            outDatasetFile.close()
            interactionFile.close()
            faceFile.close()
            labelFile.close()



