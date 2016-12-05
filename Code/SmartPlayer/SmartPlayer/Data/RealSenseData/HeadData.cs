using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.RealSenseData
{
    /// <summary>
    /// 头相关数据
    /// </summary>
    class HeadData
    {
        // RealSense提供，头的位置
        private PXCMFaceData.HeadPosition headPos;
        // RealSense提供，头的朝向
        private PXCMFaceData.PoseEulerAngles poseEulerAngles;
        private PXCMFaceData.PoseQuaternion outPoseQuaternion;
        // RealSense提供，头的区域
        private PXCMRectI32[] boundingRect;
        // 发生时间
        private CustomTime happenTS;

    }
}
