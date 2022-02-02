using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data.Base;
using OnlineBookstore.Data.ViewModels;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(newBookVM data)
        {
            var newBook = new Book()
            {
                Title = data.Title,
                Description = data.Description,
                Price = data.Price,
                Premiere = data.Premiere,
                BookCoverURL = data.BookCoverURL,
                BookstoreId = data.BookstoreId,
                BookCategory = data.BookCategory,
                PublisherId = data.PublisherId,

            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            //Add Book Authors
            foreach (var authorId in data.AuthorsIds)
            {
                var newAuthorBook = new Author_Book()
                {
                    BookId = newBook.Id,
                    AuthorId = authorId
                };
                await _context.Authors_Books.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
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

        public async Task<NewBookDropdownsVM> GetNewBookDropdownValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Authors = await _context.Authors.OrderBy(n => n.FullName).ToListAsync(),
                Bookstores = await _context.Bookstores.OrderBy(n => n.Name).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.FullName).ToListAsync()
            };
    
            return response;

        }

        public async Task UpdateBookAsync(newBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);
            
            if(dbBook != null)
            {
                dbBook.Title = data.Title;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.Premiere = data.Premiere;
                dbBook.BookCoverURL = data.BookCoverURL;
                dbBook.BookstoreId = data.BookstoreId;
                dbBook.BookCategory = data.BookCategory;
                dbBook.PublisherId = data.PublisherId;
                await _context.SaveChangesAsync();
            }

            //Remove existing authors
            var existingAuthorDb = _context.Authors_Books.Where(n => n.BookId == data.Id).ToList();
            _context.Authors_Books.RemoveRange(existingAuthorDb);
            await _context.SaveChangesAsync();

            //Add Book Authors
            foreach (var authorId in data.AuthorsIds)
            {
                var newAuthorBook = new Author_Book()
                {
                    BookId = data.Id,
                    AuthorId = authorId
                };
                await _context.Authors_Books.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
        }
    }
}
