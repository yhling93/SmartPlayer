using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data
{
    class Video
    {
        public string VideoID { get; set; }
        public string CourseChapter { get; set; }
        public string VideoName { get; set; }
        // 以秒为单位
        public int VideoLength { get; set; }
    }
}
