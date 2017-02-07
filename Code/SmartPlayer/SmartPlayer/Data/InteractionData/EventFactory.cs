using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    class EventFactory
    {
        public static MomentEvent createMomentEvent(string sid, int videoTime, MomentEventType type)
        {
            CustomTime time = new CustomTime() { absTS = CustomTime.ConvertDateTimeToTimeStamp(DateTime.Now), videoTS = videoTime };
            MomentEvent e = null;
            switch(type)
            {
                case MomentEventType.PLAY:
                    e = new PlayEvent(sid, time);
                    break;
                case MomentEventType.PAUSE:
                    e = new PauseEvent(sid, time);
                    break;
                case MomentEventType.STOP:
                    e = new StopEvent(sid, time);
                    break;
                case MomentEventType.FULL_SCREEN_ENTER:
                    e = new FullScreenEnterEvent(sid, time);
                    break;
                case MomentEventType.FULL_SCREEN_EXIT:
                    e = new FullScreenExitEvent(sid, time);
                    break;
                case MomentEventType.PLAY_RATE_CHANGE:
                    e = new PlayRateChangeEvent(sid, time);
                    break;
                default:
                    return null;
            }
            return e;
        }

        public static PeriodEvent startPeriodEvent(string sid, int videoTime, PeriodEventType type)
        {
            CustomTime startTime = new CustomTime() { absTS = CustomTime.ConvertDateTimeToTimeStamp(DateTime.Now), videoTS = videoTime };
            PeriodEvent e = null;
            switch(type)
            {
                case PeriodEventType.FAST_FORWARD:
                    e = new FastForwardEvent(sid, startTime, null);
                    break;
                case PeriodEventType.REWIND:
                    e = new RewindEvent(sid, startTime, null);
                    break;
                case PeriodEventType.FORWARD_SKIP:
                    e = new ForwardSkipEvent(sid, startTime, null);
                    break;
                case PeriodEventType.REVERSE_SKIP:
                    e = new ReverseSkipEvent(sid, startTime, null);
                    break;
                case PeriodEventType.UNDETERMINED:
                    e = new UndeterminedSkipEvent(sid, startTime, null);
                    break;
                default:
                    return null;
            }
            return e;
        }

        public static void finishPeriodEvent(PeriodEvent e, int videoTime)
        {
            CustomTime endTime = new CustomTime() { absTS = CustomTime.ConvertDateTimeToTimeStamp(DateTime.Now), videoTS = videoTime };
            e.setFinishTime(endTime);
        }
    }

    sealed class InvalidParamException : Exception
    {
        public InvalidParamException():base() { }

        public InvalidParamException(string msg) : base(msg) { }
    }
}
