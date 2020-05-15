using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        [ForeignKey("Account")]
        public int DateOfReturn { get; set; }
        public int DateOfAquire { get; set; }   

        public ICollection<Book> Books { get; set; }
        //public ICollection<IdentityUser> Users { get; set; }
    }
}
