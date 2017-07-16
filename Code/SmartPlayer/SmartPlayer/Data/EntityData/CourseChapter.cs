using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    class CourseChapter
    {
        public Course Course { get; set; }
        public List<Video> Videos { get; set; }
    }
}
