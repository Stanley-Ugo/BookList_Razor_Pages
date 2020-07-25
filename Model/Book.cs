using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList_Razor_Pages.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Availability { get; set; }
        public double Price { get; set; }
    }
}
