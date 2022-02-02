using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.ViewModels
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM()
        {
            Publishers = new List<Publisher>();
            Bookstores = new List<Bookstore>();
            Authors = new List<Author>();
        }
        public List<Publisher> Publishers { get; set; }
        public List<Bookstore> Bookstores { get; set; }
        public List<Author> Authors { get; set; }
    }
}
