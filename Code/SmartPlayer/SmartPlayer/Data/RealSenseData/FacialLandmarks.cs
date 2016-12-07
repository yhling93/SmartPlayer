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
    public class FacialLandmarks
    {
        // RealSense提供
        public Dictionary<PXCMFaceData.LandmarksGroupType, PXCMFaceData.LandmarkPoint[]> landmarksData { set; get; }
        // 发生时间
        public CustomTime happenTS { set; get; }
    }
}
