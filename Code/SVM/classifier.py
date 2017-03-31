#!/usr/bin/python
#import os

#os.chdir('/home/adam/SmartPlayer/Code/SVM')

from svmutil import *

fold = 1

for i in range(fold):
    trainset = "all_feature_set"
    testset = "testset" + str(i)

#filename = "feature_file"
#testfilename = "feature_file_test"
    y, x = svm_read_problem(trainset)
    yt, xt = svm_read_problem(testset)

#m = svm_train(y, x, '-t 3 -h 0 -c 0.0000001')
    acc_list = []
    for d  in range (2, 3):
        m = svm_train(y, x, '-t 1 -h 0 -c 0.001 -d ' + str(d))

        p_label, p_acc, p_val = svm_predict(yt, xt, m)

        acc_list.append(p_acc)

print acc_list

#p_label, p_acc, p_val = svm_predict(yt, xt, m)
