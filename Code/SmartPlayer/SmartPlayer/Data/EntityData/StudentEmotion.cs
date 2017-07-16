using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    class StudentEmotion
    {
        public enum Judge
        {
            Correct, Wrong, Unjudged
        }
        public Student Student { get; set; }
        public Video Video { get; set; }
        public Emotion.EmotionType EmotionType { get; set; }
        public float[] AppearanceFeature { get; set; }
        public float[] InteractionFeature { get; set; }
        public Judge judge { get; set; }
    }
}
