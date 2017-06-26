import re
import sys
import random
def handle_interaction(interactionLines, target):
    for line in interactionLines:
        curfeature = line.split( )
        toStr = ""
        for i in range(len(curfeature)):
            toStr += str(i) + ':' + curfeature[i] + ' '
        target.append(toStr)
    return

def handle_face(faceLines, target, count, canUse):
    if count > len(faceLines):
        for i in range(0, count - len(faceLines)):
            faceLines.insert(0,'')
    for i in range(0, count):
        line = faceLines[i]
        curfeature=re.split('\s+', line)
        # total 121 feature
        if len(curfeature) < 258:
            # if feature doesn't meet requirement, set the can use flag to be false
            canUse[i] = False
            for j in range(0, 256):
                if not j == 255:
                    target[i] += str(j + 9) + ':0 '
                elif j == 255:
                    target[i] += str(j + 9) + ':0'
        elif len(curfeature) == 258:
            # if feature doesn't meet requirement, set the can use flag to be false
            canUse[i] = check_face_feature(curfeature)
            #print str(i) + "can use ?" + str(canUse[i])
            for j in range(1, 257):
                if not j == 256:
                    target[i] += str(j + 9 - 1) + ':' + curfeature[j] + ' '
                elif j == 256:
                    target[i] += str(j + 9 - 1) + ':' + curfeature[j]
    return


def check_face_feature(curfeature):
    # if the number of zeros > half of the features, then this feature is invalid
    count = 256
    zeroCount = 0
    for i in range(1, 257):
        if curfeature[i] == 0:
            zeroCount += 1

    rate = 1.0 * zeroCount / count
    return rate < 0.5

labelmap={'amused':1,'tired':2,'despise':3,
        'thinking':4,'notetaking':5,'confused':6,
        'surprised':7,'distracted':8,'normal':9,
        'unknown':10,'concentrated':11, 'bored':12}

def handle_label(labels, target, count):
    #print "in handling_label fun, count is",count 
    last_time=0
    line = labels[0]
    labelfeature= re.split('\s+',line)

    # get the start play time
    startPlayTime = int(labelfeature[0])
    # set the label unknow from 0 to startPlayTime
    for ts in range(0, startPlayTime + 1):
        target[ts] = '10 ' + target[ts]

    last_time = startPlayTime
 
    for i in range(1 , len(labels) - 1):

        # get the label line
        line = labels[i]

        labelfeature = re.split('\s+',line)
        time_period = labelfeature[0].split('-')

        # get start time and end time
        st_time = int(time_period[0])
        end_time = int(time_period[1])

        # get label array
        cur_label = []
        cur_label_str = ''
        for key in labelmap:
            # if find label str, than add label the to array
            if line.find(key) >= 0:
                cur_label.append(labelmap[key])
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
            target[ts] = cur_label_str + ' ' + target[ts]

        # handle the blank time
        if last_time is not 0 and last_time < st_time:
            for ts in range(last_time + 1, st_time):
                if ts >= count:
                    break;
                target[ts] = '9 ' + target[ts]

        last_time = end_time

    # handle the last str
    line = labels[len(labels) - 1]
    labelfeature = re.split('\s+', line);
    for ts in range(last_time + 1, num):
        target[ts]='10 ' + target[ts]

    return

def check_feature_label(target, num):
    flag = True
    if not len(target) == num:
        return False

    for i in range(0, num):
        curcount = len(re.split('\s+', target[i]))
        if curcount != 266:
            #print 'curidx' + str(i) + ': curcount:' + str(curcount)
            #print '\n' + target[i]
            flag = False
    
    return flag


workDir = sys.argv[1] #get work dir
interactionFile = open(workDir + "/feature_interaction") # the idx of feature is [0,8]
faceFile = open(workDir + "/Facedata.md")  # the idx of feature is [9,264]
labelFile = open(workDir + "/label.txt")

featureFile= file(workDir + "/feature_file", "w+")
feature = []

data = []

# handle interaction
interactionLines = interactionFile.readlines()
interactionLines = interactionLines[2:] # skip the first two lines because they are session information
handle_interaction(interactionLines, data)

# get train set count
num = len(data)
canUse = [True] * num; # if there is face data, so the item can be used


# handle face
faceLines = faceFile.readlines()
handle_face(faceLines, data, num, canUse)

# handle labels
labels=labelFile.readlines()
handle_label(labels, data, num)

# check feature and label is correct
'''
if check_feature_label(data, num):
    #print '[CORRECT]'
else:
    #print '[ERROR]'
'''
# convert to file
writedata = []
for i in range(0, num):
    if canUse[i]:
        writedata.append(data[i])

for i in range(0, len(writedata)):
        writedata[i] += '\n'

random.shuffle(writedata)
print 'The size of ', workDir,'  is ', len(writedata)

featureFile.writelines(writedata)
featureFile.close()
faceFile.close()
interactionFile.close()
labelFile.close()
