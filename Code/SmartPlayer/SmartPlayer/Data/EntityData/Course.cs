using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    public class Course
    {
        public enum Difficulty{
            Hard, Medium, Easy
        };
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public Difficulty CourseDifficulty { get; set; }
        public string CourseTeacher { get; set; }
        public string CourseDesc { get; set; }
    }
}
