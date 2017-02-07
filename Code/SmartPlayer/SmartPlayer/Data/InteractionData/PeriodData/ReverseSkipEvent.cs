using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 反向跳跃事件
    class ReverseSkipEvent : PeriodEvent
    {
        public ReverseSkipEvent(string sid, CustomTime startTS, CustomTime endTS) : base(sid, startTS, endTS, PeriodEventType.REVERSE_SKIP)
        {

        }

        public ReverseSkipEvent(UndeterminedSkipEvent e)
        {
            this.mType = PeriodEventType.REVERSE_SKIP;
            this.mStartTS = e.StartTS;
            this.mSessionID = e.SessionID;
        }
    }
}
