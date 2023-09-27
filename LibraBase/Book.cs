using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraBase
{
    public class Book
    {
        public string Author { get; set; }
        public short Act { get; set; }
        public string age { get; set; }
        public int Count { get; set; }

        public Book(string author, short act, int year, int month, int day, int count)
        {
            Author = author;
            Act = act;
            age = new DateTime(year,month,day).ToString("dd.MM.yyyy");
            Count = count;
        }
    }
}
