using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 快退事件
    class RewindEvent : PeriodEvent
    {
        public RewindEvent(string sid, CustomTime startTS, CustomTime endTS) : base(sid, startTS, endTS, PeriodEventType.REWIND)
        {

        }
    }
}
