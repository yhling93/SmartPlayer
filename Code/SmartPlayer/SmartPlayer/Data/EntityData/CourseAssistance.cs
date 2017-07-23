using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    class CourseAssistance : Assistance
    {
        public CourseAssistance()
        {
            assistanceType = AssistanceType.Course;
        }
        public enum CourseLevel
        {
            HighLevel, LowLevel
        }
        public Course Course;
        public CourseLevel courseLevel;

        public CourseAssistance(Course c, CourseLevel l)
        {
            assistanceType = AssistanceType.Course;
            courseLevel = l;
            Course = c;
        }
       
    }
}
