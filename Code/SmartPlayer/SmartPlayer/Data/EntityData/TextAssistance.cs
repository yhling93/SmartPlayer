using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    class TextAssistance : Assistance
    {
        public TextAssistance()
        {
            assistanceType = AssistanceType.Text;
        }

        public TextAssistance(string t)
        {
            assistanceType = AssistanceType.Text;
            TextInfo = t;
        }
        public string TextInfo { get; set; }
    }
}
