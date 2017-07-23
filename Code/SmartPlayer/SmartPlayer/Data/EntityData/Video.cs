using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data
{
    public class Video
    {
        public string VideoID { get; set; }
        public string VideoName { get; set; }
        // 以秒为单位
        public int VideoLength { get; set; }
        public string VideoPath { get; set; }
    }
}
