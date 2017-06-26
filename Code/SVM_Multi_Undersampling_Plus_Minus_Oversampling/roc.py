#!/usr/bin/python
#import os

#os.chdir('/home/adam/SmartPlayer/Code/SVM')

from svmutil import *
import numpy as np
import matplotlib.pyplot as plt
from itertools import cycle

from sklearn import svm, datasets
from sklearn.metrics import roc_curve, auc
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import label_binarize
from sklearn.multiclass import OneVsRestClassifier
from scipy import interp

labelArray = ['amused', 'tired', 'despise', 'thinking', 'notetaking', 'confused', 'surprised', 'distracted', 'normal', 'unknown', 'concentrated', 'bored']

#m = svm_load_model('./models/data_after_boardline_smote_and_pca_with_49.scale.model')
#m = svm_load_model('./models/data_after_boardline_smote.scale.model')
#m = svm_load_model('./models/fournine_ration0.8.model')
m = svm_load_model('./models/ration0.8.model')
for i in range(1):
    print '--------------------------------------------------------'
    #print 'Start predicting Test Set No.', str(2)
    #testset = "./datas/testset" + str(2)

    #print 'Start predicting Test Set No. ration0.8'
    #testset = "./datas/fournine_testset_with_ration0.8"
    testset = "./datas/testset_with_ration0.8"
    #testset = './raw_datas/data_after_boardline_smote.scale.test_0.8' 
    yt, xt = svm_read_problem(testset)
    
    
    # test set count map
    stdDict = {}
    for j in range(len(yt)):
        stdDict[yt[j]] = stdDict.get(yt[j], 0) + 1

    # predict set count map
    preDict = {}    

    # exactly match count map
    exactDict = {}

    p_label, p_acc, p_val = svm_predict(yt, xt, m, '-b 1')
    #evl_acc, evl_mse, evl_scc = evaluations(yt, p_label)
    
    # for roc curve
    y_test = label_binarize(yt, classes=[1,4,5,6,7,8,9,10,11])
    n_classes = y_test.shape[1]
    # print p_val.shape
    y_score = np.array(p_val)
    #label_binarize(p_val, classes=[1,4,5,6,7,8,9,10,11])
    # Compute ROC curve and ROC area for each class
    fpr = dict()
    tpr = dict()
    roc_auc = dict()
    for i in range(n_classes):
        fpr[i], tpr[i], _ = roc_curve(y_test[:, i], y_score[:, i])
        roc_auc[i] = auc(fpr[i], tpr[i])
    
    # Compute micro-average ROC curve and ROC area
    fpr["micro"], tpr["micro"], _ = roc_curve(y_test.ravel(), y_score.ravel())
    roc_auc["micro"] = auc(fpr["micro"], tpr["micro"])    
    
    plt.figure()
    lw = 2
    '''
    plt.plot(fpr[0], tpr[0], color='darkorange',
         lw=lw, label='ROC curve (area = %0.2f)' % roc_auc[2])
    plt.plot([0, 1], [0, 1], color='navy', lw=lw, linestyle='--')
    plt.xlim([0.0, 1.0])
    plt.ylim([0.0, 1.05])
    plt.xlabel('False Positive Rate')
    plt.ylabel('True Positive Rate')
    plt.title('Receiver operating characteristic example')
    plt.legend(loc="lower right")
    plt.show()
    '''

    ##############################################################################
    # Plot ROC curves for the multiclass problem

    # Compute macro-average ROC curve and ROC area

    # First aggregate all false positive rates
    all_fpr = np.unique(np.concatenate([fpr[i] for i in range(n_classes)]))

    # Then interpolate all ROC curves at this points
    mean_tpr = np.zeros_like(all_fpr)
    for i in range(n_classes):
        mean_tpr += interp(all_fpr, fpr[i], tpr[i])

    # Finally average it and compute AUC
    mean_tpr /= n_classes

    fpr["macro"] = all_fpr
    tpr["macro"] = mean_tpr
    roc_auc["macro"] = auc(fpr["macro"], tpr["macro"])

    # Plot all ROC curves
    plt.figure()
    plt.plot(fpr["micro"], tpr["micro"],
             label='micro-average ROC curve (area = {0:0.2f})'
                   ''.format(roc_auc["micro"]),
             color='deeppink', linestyle=':', linewidth=4)

    plt.plot(fpr["macro"], tpr["macro"],
             label='macro-average ROC curve (area = {0:0.2f})'
                   ''.format(roc_auc["macro"]),
             color='navy', linestyle=':', linewidth=4)

    colors = cycle(['aqua', 'darkorange', 'cornflowerblue'])
    for i, color in zip(range(n_classes), colors):
        plt.plot(fpr[i], tpr[i], color=color, lw=lw,
                 label='ROC curve of class {0} (area = {1:0.2f})'
                 ''.format(i, roc_auc[i]))

    plt.plot([0, 1], [0, 1], 'k--', lw=lw)
    plt.xlim([0.0, 1.0])
    plt.ylim([0.0, 1.05])
    plt.xlabel('False Positive Rate')
    plt.ylabel('True Positive Rate')
    plt.title('Receiver operating characteristic')
    plt.legend(loc="lower right")
    plt.show()









    for j in range(len(yt)):
        preDict[p_label[j]] = preDict.get(p_label[j], 0) + 1
        if p_label[j] == yt[j]:
            exactDict[p_label[j]] = exactDict.get(p_label[j], 0) + 1
        
    totalCnt = 0
    predictTotalCnt = sum(preDict)

    for key in stdDict.keys():
        #print '########## Label: ', key, ' ##########'
        accuracy = 0.0
        recall = 0.0
        totalCnt += exactDict.get(key, 0)
        if stdDict.get(key, 0) != 0:
            recall = 1.0 * exactDict.get(key, 0) / stdDict.get(key)
        if preDict.get(key, 0) != 0:
            accuracy = 1.0 * exactDict.get(key, 0) / preDict.get(key)
        if (accuracy + recall) != 0:
            f1measure = 2.0 * accuracy * recall / (accuracy + recall)
        else:
            f1measure = 0
        print key, ' | ', stdDict.get(key,0), ' | ', preDict.get(key,0), ' | ', exactDict.get(key,0), ' | ', accuracy, ' | ', recall, ' | ', f1measure
        #print 'key: ', key, ' accuracy: ', accuracy, ' recall: ', recall, ' f1 value: ',f1measure 
        #print 'standard cnt: ', stdDict.get(key, 0), 'predict cnt: ', preDict.get(key, 0), 'exact cnt: ', exactDict.get(key, 0)
        #print '########## Label: ', key, ' ##########'
    #print 'accuracy: ', evl_acc, ' mean squared error: ', evl_mse, ' squared correlation coefficient: ', evl_scc
    #print 'Total Accuracy: ', 1.0 * totalCnt / len(yt)
    #print '-----------------------------------------------------------'
