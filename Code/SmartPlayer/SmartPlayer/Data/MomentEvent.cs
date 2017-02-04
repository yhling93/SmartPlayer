using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data
{
    // 时刻行为枚举类
    public enum MomentEventType
    {
        PLAY, PAUSE, STOP,
        FULL_SCREEN_ENTER, FULL_SCREEN_EXIT,
        PLAY_RATE_CHANGE
    }

    // 某一时刻发生的行为：播放、暂停、停止、进入全屏、退出全屏、播放速度变化
    abstract class MomentEvent
    {
        // 本次会话id
        protected string mSessionID;
        // 发生时刻
        protected CustomTime mHappenTS;
        // 事件类型
        protected MomentEventType mType;

        public MomentEvent(string sid, CustomTime happenTS, MomentEventType type)
        {
            this.mSessionID = sid;
            this.mHappenTS = happenTS;
            this.mType = type;
        }
    }
}
