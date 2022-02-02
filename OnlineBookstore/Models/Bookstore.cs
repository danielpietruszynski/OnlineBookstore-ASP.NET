using OnlineBookstore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class Bookstore:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Bookstore Logo")]
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }
        [Display(Name = "Bookstore Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
