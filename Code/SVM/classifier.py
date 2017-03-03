import os

os.chdir('/home/adam/SmartPlayer/Code/SVM')

from svmutil import *

y, x = svm_read_problem('train.1')

yt, xt = svm_read_problem('test.1')

m = svm_train(y, x)

p_label, p_acc, p_val = svm_predict(yt, xt, m)
