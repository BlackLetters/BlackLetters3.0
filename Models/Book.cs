using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }

        //public ICollection<Account> Accounts { get; set; }
    }
}
