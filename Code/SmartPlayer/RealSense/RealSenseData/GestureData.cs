using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.RealSenseData
{
    /// <summary>
    /// 手势
    /// </summary>
    public class GestureData
    {
        // RealSense提供
        public PXCMHandData.GestureData gestureData { set; get; }
        // 发生时间
        public CustomTime happenTS { set; get; }
    }
}
