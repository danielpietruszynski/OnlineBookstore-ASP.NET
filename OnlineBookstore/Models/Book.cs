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
    public class Book:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string BookCoverURL { get; set; }
        public DateTime Premiere { get; set; }
        public BookCategory BookCategory { get; set; }

        //Relationships
        public List<Author_Book> Authors_Books { get; set; }
        
        //Bookstore
        public int BookstoreId { get; set; }
        [ForeignKey("BookstoreId")]
        public Bookstore Bookstore { get; set; }
        
        //Publisher
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
