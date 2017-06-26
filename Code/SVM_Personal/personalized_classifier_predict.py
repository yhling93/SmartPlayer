#!/usr/bin/python
#import os

#os.chdir('/home/adam/SmartPlayer/Code/SVM')

from svmutil import *

fold = 1

labelArray = ['amused', 'tired', 'despise', 'thinking', 'notetaking', 'confused', 'surprised', 'distracted', 'normal', 'unknown', 'concentrated', 'bored']

cnt = 8

trainset = './datas/personal_train.scale'

y, x = svm_read_problem(trainset)
#m = svm_train(y, x, '-t 1 -h 0 -c 32768 -d 3 -g 0.03125')
#svm_save_model('./models/personal_train.model', m)
m = svm_load_model('./models/personal_train.model')
for i in range(cnt):
    print '--------------------------------------------------------'
    
    testset = './datas/personal_test_' + str(i) + '.scale'
    resultFile = file('./datas/personal_test_' + str(i) + '.result', "w+")

    yt, xt = svm_read_problem(testset)
    # test set count map
    stdDict = {}
    for j in range(len(yt)):
        stdDict[yt[j]] = stdDict.get(yt[j], 0) + 1

    # predict set count map
    preDict = {}    

    # exactly match count map
    exactDict = {}

    p_label, p_acc, p_val = svm_predict(yt, xt, m)
    evl_acc, evl_mse, evl_scc = evaluations(yt, p_label)
         
    for j in range(len(yt)):
        preDict[p_label[j]] = preDict.get(p_label[j], 0) + 1
        if p_label[j] == yt[j]:
            exactDict[p_label[j]] = exactDict.get(p_label[j], 0) + 1
        
    totalCnt = 0
    predictTotalCnt = sum(preDict)

    for key in stdDict.keys():
        resultFile.write('-----------------key:' + str(key) + '\n')
        #print '########## Label: ', key, ' ##########'
        accuracy = 0.0
        recall = 0.0
        totalCnt += exactDict.get(key, 0)
        if stdDict.get(key, 0) != 0:
            accuracy = 1.0 * exactDict.get(key, 0) / stdDict.get(key)
        if preDict.get(key, 0) != 0:
            recall = 1.0 * exactDict.get(key, 0) / preDict.get(key)
        if (accuracy + recall) != 0:
            f1measure = 2.0 * accuracy * recall / (accuracy + recall)
        else:
            f1measure = 0
        resultFile.write('key:' + str(key) + ' keylabel:' + str(labelArray[int(key)]) + ' accuracy:' + str(accuracy) + ' recall:' + str(recall) + ' f1value:' + str(f1measure) + '\n')
        resultFile.write('std cnt:' + str(stdDict.get(key, 0)) + ' pre cnt:' + str(preDict.get(key, 0)) + 'exa cnt:' + str(exactDict.get(key, 0)) + '\n')
        resultFile.write('-----------------key:' + str(key) + '\n')

    resultFile.write('Total Accuracy:' + str(1.0 * totalCnt / len(yt)) + ' evl_mse:' + str(evl_mse) + ' evl_scc:' + str(evl_scc) + '\n')
    resultFile.close()
        #print 'key: ', key, 'keyLabel: ', labelArray[int(key)], ' accuracy: ', accuracy, ' recall: ', recall, ' f1 value: ',f1measure 
        #print 'standard cnt: ', stdDict.get(key, 0), 'predict cnt: ', preDict.get(key, 0), 'exact cnt: ', exactDict.get(key, 0)
        #print '########## Label: ', key, ' ##########'
    #print 'accuracy: ', evl_acc, ' mean squared error: ', evl_mse, ' squared correlation coefficient: ', evl_scc
    #print 'Total Accuracy: ', 1.0 * totalCnt / len(yt)
    #print '-----------------------------------------------------------'

