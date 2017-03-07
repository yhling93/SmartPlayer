#import os

#os.chdir('/home/adam/SmartPlayer/Code/SVM')

from svmutil import *

filename = "feature_file"

y, x = svm_read_problem(filename)

yt, xt = svm_read_problem(filename)

#m = svm_train(y, x, '-t 3 -h 0 -c 0.0000001')
acc_list = []
for d  in range (3, 6):
    m = svm_train(y, x, '-t 1 -h 1 -c 0.001 -d ' + str(d))

    p_label, p_acc, p_val = svm_predict(yt, xt, m)

    acc_list.append(p_acc)
print acc_list

#p_label, p_acc, p_val = svm_predict(yt, xt, m)
