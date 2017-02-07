using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 前进跳跃事件
    class ForwardSkipEvent : PeriodEvent
    {
        public ForwardSkipEvent(string sid, CustomTime startTS, CustomTime endTS) : base(sid, startTS, endTS, PeriodEventType.FORWARD_SKIP)
        {

        }

        public ForwardSkipEvent(UndeterminedSkipEvent e)
        {
            this.mType = PeriodEventType.FORWARD_SKIP;
            this.mStartTS = e.StartTS;
            this.mSessionID = e.SessionID;
        }
    }
}
