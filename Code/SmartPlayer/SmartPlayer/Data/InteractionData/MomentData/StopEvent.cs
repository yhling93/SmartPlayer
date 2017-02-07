using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 停止播放事件
    class StopEvent : MomentEvent
    {
        public StopEvent(string sid, CustomTime happenTS) : base(sid, happenTS, MomentEventType.STOP)
        {

        }
    }
}
