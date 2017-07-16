using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    class CourseProgress
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public List<Video> FinishedChapter { get; set; }
        public Video LastLearnedVideo { get; set; }
    }
}
