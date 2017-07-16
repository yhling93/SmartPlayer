using SmartPlayer.Data.EntityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer
{
    class EmotionModel
    {
        public void loadModel(string filePath) { }

        public Emotion.EmotionType predict(float[] feature) {
            return Emotion.EmotionType.Unknown;
        }
    }
}
