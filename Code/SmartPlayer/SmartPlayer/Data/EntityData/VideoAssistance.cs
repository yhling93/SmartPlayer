using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPlayer.Data.EntityData;
namespace SmartPlayer.Data.EntityData
{
    public class VideoAssistance
    {
        public Video Video { get; set; }
        public Assistance Assistance { get; set; }
        public int StartVideoTime { get; set; }
        public int EndVideoTime { get; set; }
        public Emotion.EmotionType EmotionType { get; set; }

        public VideoAssistance() { }

        public VideoAssistance(Video v, Assistance a, int sv, int ev, Emotion.EmotionType t)
        {
            Video = v;
            Assistance = a;
            StartVideoTime = sv;
            EndVideoTime = ev;
            EmotionType = t;
        }
    }
}
