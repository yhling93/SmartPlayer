using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 正常播放事件
    class PlayEvent : MomentEvent
    {
        public PlayEvent(string sid, CustomTime happenTS) : base(sid, happenTS, MomentEventType.PLAY)
        {

        }
    }
}
