using OnlineBookstore.Data.Base;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Services
{
    public class BookstoresService:EntityBaseRepository<Bookstore>, IBookstoresService
    {
        public BookstoresService(AppDbContext context) : base(context)
        {

        }
    }
}
