using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    // 暂停播放事件
    class PauseEvent : Event
    {
        public string mSessionID
        {
            get; set;
        }

        public CustomTime mHappenTS
        {
            get; set;
        }

        EventType Event.getEventType()
        {
            return EventType.PAUSE;
        }

        string Event.getJsonString()
        {
            throw new NotImplementedException();
        }
    }
}
