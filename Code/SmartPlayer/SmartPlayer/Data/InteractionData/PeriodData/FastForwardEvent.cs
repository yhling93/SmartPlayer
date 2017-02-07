using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 快进事件
    class FastForwardEvent : PeriodEvent
    {
        public FastForwardEvent(string sid, CustomTime startTS, CustomTime endTS) : base(sid, startTS, endTS, PeriodEventType.FAST_FORWARD)
        {

        }
    }
}
