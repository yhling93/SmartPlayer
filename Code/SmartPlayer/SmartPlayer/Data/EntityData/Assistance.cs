using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    abstract public class Assistance
    {
        public enum AssistanceType
        {
            Text, Course, Book
        }
        public string AssistanceID { get; set; }
        public AssistanceType assistanceType { get; set; }
    }
}
