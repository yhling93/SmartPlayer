using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.EntityData
{
    class BookAssistance : Assistance
    {
        public BookAssistance()
        {
            assistanceType = AssistanceType.Book;
        }
        public string BookName { get; set; }
        public string PictureUrl { get; set; }

        public BookAssistance(string bn, string pu)
        {
            BookName = bn;
            PictureUrl = pu;
            assistanceType = AssistanceType.Book;
        }
    }
}
