using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.RealSenseData
{
    /// <summary>
    /// 面部标定数据
    /// </summary>
    class FacialLandmarks
    {
        // RealSense提供
        private Dictionary<PXCMFaceData.LandmarksGroupType, PXCMFaceData.LandmarkPoint[]> landmarksData;
        // 发生时间
        private CustomTime happenTS;
    }
}
