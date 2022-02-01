using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class Bookstore
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Bookstore Logo")]
        public string Logo { get; set; }
        [Display(Name = "Bookstore Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
