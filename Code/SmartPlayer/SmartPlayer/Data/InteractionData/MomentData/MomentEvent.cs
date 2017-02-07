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
        PLAY=10, PAUSE, STOP,
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

        public string SessionID { get { return mSessionID; } }
        
        public CustomTime HappenTS { get { return mHappenTS; } }

        public MomentEventType Type { get { return mType; } }

        public MomentEvent() { }

        public MomentEvent(string sid, CustomTime happenTS, MomentEventType type)
        {
            this.mSessionID = sid;
            this.mHappenTS = happenTS;
            this.mType = type;
        }

        public string toJsonString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
