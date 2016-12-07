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
    public class HandData
    {
        // 手轮廓定位点
        public PXCMPointI32[] handContour { set; get; }
        // 手关节坐标
        public PXCMHandData.JointData[] handJoint { set; get; }
        // 手指弯曲和半径
        public PXCMHandData.FingerData[] handFinger { set; get; }
        // 发生时间
        public CustomTime happenTS { set; get; }
    }
}
