using OnlineBookstore.Data;
using OnlineBookstore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class newBookVM
    {
        [Required(ErrorMessage = "Title is requied")]
        [Display(Name = "Book title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is requied")]
        [Display(Name = "Book description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price in $")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Book Cover is requied")]
        [Display(Name = "Book cover")]
        public string BookCoverURL { get; set; }
        [Required(ErrorMessage = "Premiere Data is requied")]
        [Display(Name = "Book Premiere Data")]
        public DateTime Premiere { get; set; }
        [Required(ErrorMessage = "Book category is required")]
        [Display(Name = "Select a category")]
        public BookCategory BookCategory { get; set; }

        //Relationships
        [Required(ErrorMessage = "Book author is requied")]
        [Display(Name = "Select Authors(s)")]
        public List<int> AuthorsIds { get; set; }
        [Required(ErrorMessage = "Book Bookstore is requied")]
        [Display(Name = "Select a Bookstore")]
        public int BookstoreId { get; set; }
        [Required(ErrorMessage = "Book publisher is requied")]
        [Display(Name = "Select a publisher")]
        public int PublisherId { get; set; }
    }
}
