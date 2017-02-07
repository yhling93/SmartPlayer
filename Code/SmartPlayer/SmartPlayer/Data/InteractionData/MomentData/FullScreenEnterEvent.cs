using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 进入全屏事件
    class FullScreenEnterEvent : MomentEvent
    {
        public FullScreenEnterEvent(string sid, CustomTime happenTS) : base(sid, happenTS, MomentEventType.FULL_SCREEN_ENTER)
        {

        }
    }
}
