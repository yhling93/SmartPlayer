using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 暂停播放事件
    class PauseEvent : MomentEvent
    {
        public PauseEvent(string sid, CustomTime happenTS) : base(sid, happenTS, MomentEventType.PAUSE)
        {

        }
    }
}
