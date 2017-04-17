using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wop.Models
{
    public class Sticker
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        /*public ConsoleColor Color { get; set; }*/
        public string Url { get; set; }
    }
}