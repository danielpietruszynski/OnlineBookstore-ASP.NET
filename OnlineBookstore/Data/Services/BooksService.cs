using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data.Base;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Services
{
    public class BooksService:EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var BookDetails = await _context.Books
                .Include(b => b.Bookstore)
                .Include(p => p.Publisher)
                .Include(ab => ab.Authors_Books).ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);

            return BookDetails;
        }
    }
}
