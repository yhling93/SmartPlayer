using SmartPlayer.Data.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LibSVMsharp;

namespace SmartPlayer
{
    public class EmotionModel
    {
        public Dictionary<string, string> modelPathMap; // 模型路径

        public bool stopFlag = false; // 线程停止标识
        public const int featureNum = 265; // 特征数量
        public Emotion.EmotionType curEmotion; // 当前情感分类
        
        public SVMModel svmModel; // 模型
        public static SVMNode[] svmFeature = new SVMNode[featureNum]; // 特征

        // 0-8: video feature 9-242: landmark feature 243-264: expression feature
        public static int VideoFeatureStartIdx = 0;
        public static int VideoFeatureCnt = 9;
        public static int FaceLandmarkStartIdx = 9;
        public static int FaceLandmarkCnt = 234;
        public static int FaceExpressionStartIdx = 243;
        public static int FaceExpressionCnt = 22;
        public static int FaceFeatureCnt = FaceExpressionCnt + FaceLandmarkCnt;


        // public static Dictionary<int, int> indexEmotionMap = new Dictionary<int, int>();

        public delegate void UpdateAssistance(Emotion.EmotionType type, double[] pro);
        public UpdateAssistance updateDelegate;

        public EmotionModel()
        {
            
            modelPathMap = new Dictionary<string, string>(); // 模型路径信息
            modelPathMap.Add("SMOTE", Environment.CurrentDirectory + "\\models\\data_after_boardline_smote.scale.model");
            modelPathMap.Add("SMOTE and PCA", Environment.CurrentDirectory + "\\models\\data_after_boardline_smote_and_pca_with_49.scale.model");
            modelPathMap.Add("Undersampling", Environment.CurrentDirectory + "\\models\\data_after_undersampling.scale.model");
            modelPathMap.Add("Undersampling and PCA", Environment.CurrentDirectory + "\\models\\data_after_undersampling_and_pca_with_49.scale.model");
            svmModel = SVM.LoadModel(modelPathMap["SMOTE"]); // 加载默认模型
            // 初始化特征向量
            for (int i = 0; i < featureNum; i++)
                svmFeature[i] = new SVMNode(i, 0);


            //indexEmotionMap.Add(1, 1);
            //indexEmotionMap.Add(4, 2);
            //indexEmotionMap.Add(5, 3);
            //indexEmotionMap.Add(6, 4);
            //indexEmotionMap.Add(7, 5);
            //indexEmotionMap.Add(8, 6);
            //indexEmotionMap.Add(9, 7);
            //indexEmotionMap.Add(10, 8);
            //indexEmotionMap.Add(11, 9);
            
        }

        public void loadModel(string key)
        {
            svmModel = SVM.LoadModel(modelPathMap[key]);
        }

        public void initUpdateAssistance(UpdateAssistance method)
        {
            updateDelegate += new UpdateAssistance(method);
        }

        public void startDectecting()
        {
            stopFlag = false;
            // 如果未设置停止标识，不停识别
            while (!stopFlag)
            { 
                // 由于多线程操作，需要加锁同步数据
                lock (svmFeature)
                {
                    double[] pro = new double[9]; // 输出概率队列
                    int val = (int)SVM.PredictProbability(svmModel, svmFeature, out pro); // 预测分类及每个分类的概率
                    updateDelegate.Invoke((Emotion.EmotionType)val, pro); // 回调函数更新界面
                    for (int i = 0; i < featureNum; i++)
                        Console.Write(svmFeature[i].Value.ToString() + '\t');
                    Console.WriteLine("");
                }
                Thread.Sleep(1000); // 线程暂停1秒，即每秒识别一次感情
            }
        }

        public void stopDectecting()
        {
            stopFlag = true;
        }

        Random ra = new Random();
        public Emotion.EmotionType predict(float[] feature) {
            int num = ra.Next() % 9;
            return (Emotion.EmotionType)num;
        }
    }
}
