using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data
{
    /// <summary>
    /// 自定义事件
    /// </summary>
    public class CustomTime
    {
        // 世界时刻
        public DateTime absTS { set; get; }
        // 视频时刻 （单位是s）
        public int videoTS { set; get; }

    }
}
