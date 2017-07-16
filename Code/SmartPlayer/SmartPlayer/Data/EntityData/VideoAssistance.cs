using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    class VideoAssistance
    {
        public Video Video { get; set; }
        public Assistance Assistance { get; set; }
        public int StartVideoTime { get; set; }
        public int EndVideoTime { get; set; }
        public Emotion.EmotionType EmotionType { get; set; }
    }
}
