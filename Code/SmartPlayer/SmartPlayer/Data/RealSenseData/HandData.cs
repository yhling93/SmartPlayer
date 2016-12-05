using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.RealSenseData
{
    /// <summary>
    /// 手部标定数据
    /// </summary>
    class HandData
    {
        // 手轮廓定位点
        private PXCMPointI32[] handContour;
        // 手关节坐标
        private PXCMHandData.JointData[] handJoint;
        // 手指弯曲和半径
        private PXCMHandData.FingerData[] handFinger;
        // 发生时间
        private CustomTime happenTS;
    }
}
