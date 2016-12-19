using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    /// <summary>
    /// 播放速度记录，主要用于记录视频播放速度事件，播放速度分为快速，常速，慢速
    /// 这个类主要描述用户从何时开始到何时结束用的是怎样的播放速度观看视频
    /// </summary>
    class PlaySpeedRecord
    {
        // 开始时间
        public CustomTime startTime { set; get; }
        // 结束时间
        public CustomTime endTime { set; get; }
        // 播放速度倍率
        public double multiple { get; }
        // 播放类似，快速/常速/慢速
        public PlayType playType { get; }

        public PlaySpeedRecord(CustomTime startTime, PlayType playType)
        {
            this.startTime = startTime;
            this.playType = playType;
            switch(playType)
            {
                case PlayType.NORMAL_PLAY:
                    multiple = 1;
                    break;
                case PlayType.FAST_PLAY:
                    multiple = 1.5;
                    break;
                case PlayType.SLOW_PLAY:
                    multiple = 0.5;
                    break;
                default:
                    multiple = 1;
                    break;
            }
        }
    }

    // 为简化研究，目前设备慢速模式播放速度倍率为0.5，快速模式播放倍率为1.5
    enum PlayType
    {
        NORMAL_PLAY, FAST_PLAY, SLOW_PLAY
    }


}
