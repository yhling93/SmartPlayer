from sys import argv
from InteractionEntity import *
import os
import json
import copy

# PERIOD EVENT: FAST_FORWARD=20, REWIND, FORWARD_SKIP, REVERSE_SKIP, UNDETERMINED
# MOMENT EVENT: PLAY=10, PAUSE=11, STOP, FULL_SCREEN_ENTER, FULL_SCREEN_EXIT, PLAY_RATE_CHANGE
class MomentEventType:
    Play = 10
    Pause = 11
    Stop = 12
    FullScreenEnter = 13
    FullScreenExit = 14
    PlayRateChange = 15

class PeriodEventType:
    FastForward = 20
    Rewind = 21
    ForwardSkip = 22
    ReverseSkip = 23
    Undetermined = 24

def extractFeatureFromFile(folderPath, windowSize):
    print 'Start extracting from file ', folderPath, ' with windows size: ', windowSize
    sessionFile = open(folderPath + '/session')
    periodFile = open(folderPath + '/period')
    momentFile = open(folderPath + '/moment')

    lines = sessionFile.readlines()
    if not len(lines) == 2:
        print 'Wrong Session File!'
        return

    rawSessionJson = json.loads(lines[1])
    session = Session(rawSessionJson['SessionID'], int(rawSessionJson['StartTime']), int(rawSessionJson['EndTime']))

    timeMomentEventList = []
    timePeriodEventList = []
    timePeriodEventEndList = []
    featureList = []

    # read session
    sessionDuration = session.endTime - session.startTime + 1 # 1 - 10 totally 10 seconds not 10 - 1 = 9s, so add 1
    if sessionDuration < 120:
        print folderPath, ' Session Too Short!'
        return

    outputFilePath = '%s%s%s' % (folderPath, '/interactionFeatureWithWindowSize', str(windowSize))
    outputFile = open(outputFilePath, 'w')

    for i in range(0, sessionDuration):
        timeMomentEventList.append([])
        timePeriodEventList.append([])
        timePeriodEventEndList.append([])

    # read moment events
    rawMomentLines = momentFile.readlines()
    for line in rawMomentLines:
        rawMomentJson = json.loads(line)
        momentEvent = MomentEvent(session, int(rawMomentJson['HappenTS']['absTS']) - session.startTime,
                                  int(rawMomentJson['HappenTS']['videoTS']), int(rawMomentJson['Type']))
        if momentEvent.type == MomentEventType.PlayRateChange:
           momentEvent.rate = float(rawMomentJson['PlayRate'])
        timeMomentEventList[momentEvent.startTime].append(momentEvent)
    # read period events
    rawPeriodLines = periodFile.readlines()
    for line in rawPeriodLines:
        rawPeriodJson = json.loads(line)
        periodEvent = PeriodEvent(session, int(rawPeriodJson['StartTS']['absTS']) - session.startTime,
                                           int(rawPeriodJson['EndTS']['absTS']) - session.startTime,
                                           int(rawPeriodJson['StartTS']['videoTS']), int(rawPeriodJson['EndTS']['videoTS']),
                                           int(rawPeriodJson['Type']))
        timePeriodEventList[periodEvent.startTime].append(periodEvent)
        timePeriodEventEndList[periodEvent.endTime].append(periodEvent)
    # extract feature
    lastFeature = InteractionFeature()
    lastFeature.rate = 1.0

    # 1. Handle Raw Moment Features
    for time in range(0, sessionDuration):
        curFeature = copy.deepcopy(lastFeature)
        momentEventList = timeMomentEventList[time]
        mECnt = len(momentEventList)
        if not mECnt == 0:
            # handle moment event
            curMEvent = momentEventList[mECnt - 1]
            setRawFeatureAccordingToMomentEvent(curMEvent, curFeature)
        featureList.append(curFeature)
        lastFeature = curFeature

    # 2. Handle Raw Period Features
    for time in range(0, sessionDuration):
        periodEventList = timePeriodEventList[time]
        pECnt = len(periodEventList)
        if not pECnt == 0:
            # handle period event
            curPEvent = periodEventList[pECnt - 1]
            for subtime in range(curPEvent.startTime, curPEvent.endTime + 1):
                setRawFeatureAccordingToPeriodEvent(curPEvent, featureList[subtime])

    # 3. Handle aggregation
    for time in range(0, sessionDuration):
        start = time - windowSize + 1 if time - windowSize + 1 >= 0 else 0
        curFeature = featureList[time]
        totalRate = 0

        # for debug
        #if time == 1514:
         #   print 'debug point'

        # aggregate features
        for subtime in range(start, time + 1): # 0 - 4 0,1,2,3,4 total 5s, so add 1
            # TODO: THE RIGHT WAY TO DO FASTFLEN/REWINDLEN/FORWARDSLEN/REVERSESLEN AGGREGATION IS TO ADD JUMP TIME!!!
            curFeature.pauseLen = curFeature.pauseLen + 1 if featureList[subtime].pause == True else curFeature.pauseLen + 0
            #curFeature.fastFLen = curFeature.fastFLen + 1 if featureList[subtime].fastF == True else curFeature.fastFLen + 0
            #curFeature.rewindLen = curFeature.rewindLen + 1 if featureList[subtime].rewind == True else curFeature.rewindLen + 0
            #curFeature.forwardSLen = curFeature.forwardSLen + 1 if featureList[subtime].forwardS == True else curFeature.forwardSLen + 0
            #curFeature.reverseSLen = curFeature.reverseSLen + 1 if featureList[subtime].reverseS == True else curFeature.reverseSLen + 0
            totalRate = totalRate + featureList[subtime].rate
        curFeature.avgPlayRate = totalRate / (time - start + 1)
        # aggregate events
        for subtime in range(start, time + 1):
            curMEventList = timeMomentEventList[subtime]
            curPEventList = timePeriodEventEndList[subtime]
            if len(curMEventList) > 0:
                for mEvent in curMEventList:
                    setAggregateFeatureAccordingToMomentEvent(mEvent, curFeature)
            if len(curPEventList) > 0:
                for pEvent in curPEventList:
                    setAggregateFeatureAccordingToPeriodEvent(pEvent, curFeature)

    for feature in featureList:
        featurestr = ''
        featurestr = featurestr + '1 ' if feature.play else featurestr + '0 ' #1
        featurestr = featurestr + '1 ' if feature.pause else featurestr + '0 ' #2
        featurestr = featurestr + '1 ' if feature.fullScreen else featurestr + '0 ' #3
        featurestr = featurestr + str(feature.playTime) + ' ' #4
        featurestr = featurestr + str(feature.rate) + ' ' #5
        featurestr = featurestr + '1 ' if feature.fastF else featurestr + '0 ' #6
        featurestr = featurestr + '1 ' if feature.rewind else featurestr + '0 ' #7
        featurestr = featurestr + '1 ' if feature.forwardS else featurestr + '0 ' #8
        featurestr = featurestr + '1 ' if feature.reverseS else featurestr + '0 ' #9
        featurestr = featurestr + str(feature.pauseCnt) + ' ' #10
        featurestr = featurestr + str(feature.pauseLen) + ' ' #11
        featurestr = featurestr + str(feature.fastFCnt) + ' ' #12
        featurestr = featurestr + str(feature.fastFLen) + ' ' #13
        featurestr = featurestr + str(feature.rewindCnt) + ' ' #14
        featurestr = featurestr + str(feature.rewindLen) + ' ' #15
        featurestr = featurestr + str(feature.forwardSCnt) + ' ' #16
        featurestr = featurestr + str(feature.forwardSLen) + ' ' #17
        featurestr = featurestr + str(feature.reverseSCnt) + ' ' #18
        featurestr = featurestr + str(feature.reverseSLen) + ' ' #19
        featurestr = featurestr + str(feature.avgPlayRate) #20
        featurestr = featurestr + '\n'
        outputFile.write(featurestr)

    # session = Session()
    sessionFile.close()

    # session = Session()
    sessionFile.close()
    periodFile.close()
    momentFile.close()
    outputFile.close()

def setRawFeatureAccordingToMomentEvent(momentEvent, feature):
    if momentEvent.type == MomentEventType.Play:
        feature.play = True
        feature.pause = False
    elif momentEvent.type == MomentEventType.Pause:
        feature.play = False
        feature.pause = True
    elif momentEvent.type == MomentEventType.Stop:
        feature.play = False
        feature.pause = False
        feature.stop = True
    elif momentEvent.type == MomentEventType.FullScreenEnter:
        feature.fullScreen = True
    elif momentEvent.type == MomentEventType.FullScreenExit:
        feature.fullScreen = False
    elif momentEvent.type == MomentEventType.PlayRateChange:
        feature.rate = momentEvent.rate

def setRawFeatureAccordingToPeriodEvent(periodEvent, feature):
    if periodEvent.type == PeriodEventType.FastForward:
        feature.fastF = True
    elif periodEvent.type == PeriodEventType.Rewind:
        feature.rewind = True
    elif periodEvent.type == PeriodEventType.ForwardSkip:
        feature.forwardS = True
    elif periodEvent.type == PeriodEventType.ReverseSkip:
        feature.reverseS = True

def setAggregateFeatureAccordingToMomentEvent(momentEvent, feature):
    if momentEvent.type == MomentEventType.Pause:
        feature.pauseCnt = feature.pauseCnt + 1

def setAggregateFeatureAccordingToPeriodEvent(periodEvent, feature):
    if periodEvent.type == PeriodEventType.FastForward:
        feature.fastFCnt = feature.fastFCnt + 1
        feature.fastFLen = feature.fastFLen + (periodEvent.videoEndTime - periodEvent.videoStartTime)
    elif periodEvent.type == PeriodEventType.Rewind:
        feature.rewindCnt = feature.rewindCnt + 1
        feature.rewindLen = feature.rewindLen + (periodEvent.videoStartTime - periodEvent.videoEndTime)
    elif periodEvent.type == PeriodEventType.ForwardSkip:
        feature.forwardSCnt = feature.forwardSCnt + 1
        feature.forwardSLen = feature.forwardSLen + (periodEvent.videoEndTime - periodEvent.videoStartTime)
    elif periodEvent.type == PeriodEventType.ReverseSkip:
        feature.reverseSCnt = feature.reverseSCnt + 1
        feature.reverseSLen = feature.reverseSLen + (periodEvent.videoStartTime - periodEvent.videoEndTime)

if __name__ == '__main__':
    # param 0: script name | 1 - (n-2)th: folders | (n-1)th: windowSize
    folderCnt = len(argv) - 2
    windowSize = int(argv[len(argv) - 1])
    print 'Total Folder Count: ', folderCnt
    # traverse folders
    for i in range(0, folderCnt):
        print 'Folder: %i, Path: %s'%(i,argv[i + 1])
        folderPath = argv[i + 1] + '/Interaction_Data'
        folders = os.listdir((folderPath))
        for folder in folders:
            extractFeatureFromFile(folderPath + '/' + folder, windowSize)

