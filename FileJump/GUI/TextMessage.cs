using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileJump
{
    public class TextMessage
    {
        public string Message { get; set; }

        public string DateSent { get; set; }

        public int ID { get; set; }

        public TextMessage(string date, string text, int id)
        {
            DateSent = date;
            Message = text;
            ID = id;
        }
           
    }
}
