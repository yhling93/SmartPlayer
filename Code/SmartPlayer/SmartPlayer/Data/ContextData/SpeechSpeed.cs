using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.ContextData
{

    /// <summary>
    /// 老师说话的语速
    /// </summary>
    public class SpeechSpeed
    {
        // 语速
        public int speedPerMin { set; get; }
        // 视频时刻
        public DateTime videoTS { set; get; }
    }
}
