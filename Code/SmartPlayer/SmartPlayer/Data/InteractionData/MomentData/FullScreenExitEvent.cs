using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 退出全屏事件
    class FullScreenExitEvent : MomentEvent
    {
        public FullScreenExitEvent(string sid, CustomTime happenTS) : base(sid, happenTS, MomentEventType.FULL_SCREEN_EXIT)
        {

        }
    }
}
