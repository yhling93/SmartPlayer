using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.RealSenseData
{
    /// <summary>
    /// 头相关数据
    /// </summary>
    public class HeadData
    {
        // RealSense提供，头的位置
        public PXCMFaceData.HeadPosition headPos { set; get; }
        // RealSense提供，头的朝向
        public PXCMFaceData.PoseEulerAngles poseEulerAngles { set; get; }
        public PXCMFaceData.PoseQuaternion outPoseQuaternion { set; get; }
        // RealSense提供，头的区域
        public PXCMRectI32[] boundingRect { set; get; }
        // 发生时间
        public CustomTime happenTS { set; get; }

    }
}
