using SmartPlayer.Data.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SmartPlayer
{
    public class EmotionModel
    {
        bool stopFlag = false;
        public float[] curFeature;
        public Emotion.EmotionType curEmotion;

        public delegate void UpdateAssistance(Emotion.EmotionType type);
        public UpdateAssistance updateDelegate;

        public void initUpdateAssistance(UpdateAssistance method)
        {
            updateDelegate += new UpdateAssistance(method);
        }

        public void startDectecting()
        {
            stopFlag = false;
            while (!stopFlag)
            {
                curEmotion = predict(curFeature);
                updateDelegate.Invoke(curEmotion);
                Thread.Sleep(2000);
            }
        }

        public void stopDectecting()
        {
            stopFlag = true;
        }
        public void loadModel(string filePath) { }

        Random ra = new Random();
        public Emotion.EmotionType predict(float[] feature) {
            int num = ra.Next() % 9;
            return (Emotion.EmotionType)num;
        }
    }
}
