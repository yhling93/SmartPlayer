class Session(object):
    def __init__(self, sid, st, et):
        self.sessionId = sid
        self.startTime = st
        self.endTime = et

class PeriodEvent(object):
    def __init__(self, s, st, et, vst, vet, type):
        self.session = s
        self.startTime = st
        self.endTime = et
        self.videoStartTime = vst
        self.videoEndTime = vet
        self.type = type

class MomentEvent(object):
    def __init__(self, s, st, vt, type):
        self.session = s
        self.startTime = st
        self.vt = vt
        self.rate = -1.0
        self.type = type

class InteractionFeature(object):
    def __init__(self):
        # 9 raw features
        self.play = False
        self.pause = False
        self.fullScreen = False
        self.playTime = 0
        self.rate = 0
        self.fastF = False
        self.rewind = False
        self.forwardS = False
        self.reverseS = False
        # 11 aggregated features
        self.pauseCnt = 0
        self.pauseLen = 0
        self.fastFCnt = 0
        self.fastFLen = 0
        self.rewindCnt = 0
        self.rewindLen = 0
        self.forwardSCnt = 0
        self.forwardSLen = 0
        self.reverseSCnt = 0
        self.reverseSLen = 0
        self.avgPlayRate = 0.0