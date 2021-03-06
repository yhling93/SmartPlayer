﻿using SmartPlayer.Data.InteractionData;
using SmartPlayer.Data.RealSenseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.DB
{
    interface IDB
    {
        bool saveFacialExpression(FacialExpression facialExpression);

        bool saveFacialLandmarks(FacialLandmarks facialLandmarks);

        bool saveGestureData(GestureData gestureData);

        bool saveHandData(HandData handData);

        bool saveHeadData(HeadData headData);
    }
}
