using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPlayer.Data.ContextData;
using SmartPlayer.Data.InteractionData;
using SmartPlayer.Data.RealSenseData;

namespace SmartPlayer.DB
{
    class DBHelper : IDB
    {
        public DBHelper()
        {

        }

        public bool saveFacialExpression(FacialExpression facialExpression)
        {
            throw new NotImplementedException();
        }

        public bool saveFacialLandmarks(FacialLandmarks facialLandmarks)
        {
            throw new NotImplementedException();
        }

        public bool saveGestureData(GestureData gestureData)
        {
            throw new NotImplementedException();
        }

        public bool saveHandData(HandData handData)
        {
            throw new NotImplementedException();
        }

        public bool saveHeadData(HeadData headData)
        {
            throw new NotImplementedException();
        }

        public bool saveInteractionEvent(InteractionEvent interactionEvent)
        {
            throw new NotImplementedException();
        }

        public bool saveSpeechSpeed(SpeechSpeed speechSpeed)
        {
            throw new NotImplementedException();
        }
    }
}
