using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 播放速率变化事件
    class PlayRateChangeEvent : MomentEvent
    {
        // 播放速率
        private double mPlayRate;

        public double PlayRate
        {
            get { return mPlayRate; }
            set { mPlayRate = value; }
        }

        public PlayRateChangeEvent(string sid, CustomTime happenTS) : base(sid, happenTS, MomentEventType.PLAY_RATE_CHANGE)
        {

        }

        public PlayRateChangeEvent(string sid, CustomTime happenTS, double playRate) : base(sid, happenTS, MomentEventType.PLAY_RATE_CHANGE)
        {
            this.mPlayRate = playRate;
        }
    }
}
