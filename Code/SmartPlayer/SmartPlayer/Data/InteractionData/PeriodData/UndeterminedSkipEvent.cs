using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    class UndeterminedSkipEvent : PeriodEvent
    {
        public UndeterminedSkipEvent(string sid, CustomTime startTS, CustomTime endTS) : base(sid, startTS, endTS, PeriodEventType.UNDETERMINED)
        {

        }
    }
}
