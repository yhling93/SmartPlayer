using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    class VideoInteractionFeature
    {
        public int play { get; set; } // 播放
        public int pause { get; set; } // 暂停
        public int fastForward { get; set; } // 快进
        public int rewind { get; set; } // 快退
        public int forwardSkip { get; set; } // 跳跃前进
        public int reverskip { get; set; } // 跳跃后退
        public int replayTime { get; set; } // 重放次数
        public int isFullScreen { get; set; } // 是否全屏
        public double playRate { get; set; } // 播放速率
    }
}
