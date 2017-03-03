import re
def handle_interaction(interactionLines, target):
    for line in interactionLines:
        curfeature = line.split( )
        toStr = ""
        for i in range(len(curfeature)):
            toStr += str(i) + ':' + curfeature[i] + ' '
        target.append(toStr)
    return

def handle_face(faceLines, target, count):
    if count > len(faceLines):
        for i in range(0, count - len(faceLines)):
            faceLines.insert(0,'')
    for i in range(0, count):
        line = faceLines[i]
        curfeature=re.split('\s+', line)
        #curfeature = line.split(' ')
        #print(str(i) + ' ' + str(len(curfeature)) + '\n')
        # total 121 feature
        if len(curfeature) < 258:
            for j in range(0, 256):
                target[i] += str(j + 9) + ':0 '
        elif len(curfeature) == 258:
            for j in range(1, 257):
                target[i] += str(j + 9 - 1) + ':' + curfeature[j] + ' '
    return


labelmap={'amused':1,'tired':2,'despise':3,'thinking':4,'notetaking':5,'confused':6,'surprised':7,'distracted':8,'normal':9,'unknown':10,'concentrated':11}
def handle_label(labels, target, count):
   
    last_time=0
    line = labels[0]
    labelfeature= re.split('\s+',line);

    for ts in range(0,3):
        target[ts]='10 '+target[ts]
        print '10 '
    for ts in range(0,int(labelfeature[0])):
        target[ts+4-1]='10 '+target[ts+4-1]
        print '10 '

    for i in range(1 , len(labels) - 1):

        line=labels[i]

        labelfeature = re.split('\s+',line)
        time_period = labelfeature[0].split('-')
        st_time = int(time_period[0])
        end_time= int(time_period[1])
        cur_label=[]
        cur_label_str=''
        for key in labelmap:
            if line.find(key) > 0:
                cur_label.append(labelmap[key])
        print len(cur_label)
        for label_i in range(0,len(cur_label)-1):
            cur_label_str+=str(cur_label[label_i])+','
        if len(cur_label)>0:
            cur_label_str+=str(cur_label[len(cur_label)-1])
        for ts in range(st_time,end_time):                        
            target[ts+4-1]=cur_label_str+' '+target[ts+4-1]
            print cur_label_str

        if last_time is not 0:
            for ts in range(last_time,st_time):
                target[ts+4-1]='10'+target[ts+4-1]
                print '10 '

        last_time=end_time+1

    line=labels[len(labels)-1]
    labelfeature=re.split('\s+',line);
    for ts in range(last_time,int(labelfeature[0])):
        target[ts+4-1]='10 '+target[ts+4-1]
        print '10 '
    return
        

interactionFile = open("feature_interaction") # the idx of feature is [0,8]
faceFile = open("feature_face")  # the idx of feature is [9,264]
labelFile = open("label")

featureFile= file("feature_file","w+")
feature = []

data = []

# handle interaction
interactionLines = interactionFile.readlines()
interactionLines = interactionLines[2:] # skip the first two lines because they are session information
handle_interaction(interactionLines, data)

# get train set count
num = len(data)

# handle face
faceLines = faceFile.readlines()
handle_face(faceLines, data, num)

# handle labels
labels=labelFile.readlines()
handle_label(labels,data,num)

# convert to file
for i in range(0, num):
    data[i] += '\n'

featureFile.writelines(data)
featureFile.close()
faceFile.close()
interactionFile.close()
labelFile.close()
