using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data
{
    // 时段行为枚举类
    public enum PeriodEventType
    {
        FAST_FORWARD, REWIND,
        FORWARD_SKIP, REVERSE_SKIP
    }

    // 某一时间段内发生的行为：快进、快退、跳跃前进、跳跃后退
    abstract class PeriodEvent
    {
        // 本次会话id
        protected string mSessionID;
        // 发生时刻
        protected CustomTime mStartTS;
        // 结束时刻
        protected CustomTime mEndTS;
        // 事件类型
        protected PeriodEventType mType;

        public PeriodEvent(string sid, CustomTime startTS, CustomTime endTS, PeriodEventType type)
        {
            this.mSessionID = sid;
            this.mStartTS = startTS;
            this.mEndTS = endTS;
            this.mType = type;
        }
    }
}
