using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense
{
    /// <summary>
    /// 自定义事件
    /// </summary>
    public class CustomTime
    {
        // 世界时刻（时间戳）
        public long absTS { set; get; }
        // 视频时刻 （单位是s）
        public int videoTS { set; get; }

        private static DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));

        public static long ConvertDateTimeToTimeStamp(DateTime time)
        {
            long t = (time.Ticks - startTime.Ticks) / 10000000;   //精确到秒      
            return t;
        }
    }
}
