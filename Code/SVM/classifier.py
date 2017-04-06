#!/usr/bin/python
#import os

#os.chdir('/home/adam/SmartPlayer/Code/SVM')

from svmutil import *

fold = 1

labelArray = ['amused', 'tired', 'despise', 'thinking', 'notetaking', 'confused', 'surprised', 'distracted', 'normal', 'unknown', 'concentrated', 'bored']

for i in range(fold):
    trainset = "./datas/trainset" + str(2)
    testset = "./datas/testset" + str(2)

    y, x = svm_read_problem(trainset)
    yt, xt = svm_read_problem(testset)


    # test set count map
    stdDict = {}
    for j in range(len(yt)):
        stdDict[yt[j]] = stdDict.get(yt[j], 0) + 1

    # predict set count map
    preDict = {}    

    # exactly match count map
    exactDict = {}

    acc_list = []
    label_list = []
    for d  in range (3, 4):
        m = svm_train(y, x, '-t 1 -h 0 -c 32768 -d ' + str(d) + ' -g ' + str(0.03125))
        svm_save_model('./models/2.model', m)
        p_label, p_acc, p_val = svm_predict(yt, xt, m)
        
        for j in range(len(yt)):
            preDict[p_label[j]] = preDict.get(p_label[j], 0) + 1
            if p_label[j] == yt[j]:
                exactDict[p_label[j]] = exactDict.get(p_label[j], 0) + 1
        
        totalCnt = 0;
        for key in stdDict.keys():
            accuracy = 0.0
            recall = 0.0
            totalCnt += exactDict.get(key, 0)
            if stdDict.get(key, 0) != 0:
                accuracy = 1.0 * exactDict.get(key, 0) / stdDict.get(key)
            if preDict.get(key, 0) != 0:
                recall = 1.0 * exactDict.get(key, 0) / preDict.get(key)
            print 'key: ', key, 'keyLabel: ', labelArray[int(key)], ' accuracy: ', accuracy, ' recall: ', recall, 'standard cnt: ', stdDict.get(key, 0), 'predict cnt: ', preDict.get(key, 0), 'exact cnt: ', exactDict.get(key, 0)
        #acc_list.append(p_acc)
        print 'Total Accuracy: ', 1.0 * totalCnt / len(yt)
        print '--------------------------------------------------'
#print acc_list

#p_label, p_acc, p_val = svm_predict(yt, xt, m)
