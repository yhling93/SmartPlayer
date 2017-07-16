using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    class CourseAssistance : Assistance
    {
        public enum CourseLevel
        {
            HighLevel, LowLevel
        }
        public Course Course;
        public CourseLevel courseLevel;
       
    }
}
