using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Bookstore
                if (!context.Bookstores.Any())
                {
                    context.Bookstores.AddRange(new List<Bookstore>()
                    {
                        new Bookstore()
                        {
                            Name = "Świat Książki",
                            Logo = "https://www.swiatksiazki.pl/static/version1643692394/frontend/Olesiejuk/default/pl_PL/images/logo.svg",
                            Address = "Targ Sienny 7, 80-806 Gdańsk"
                        },
                    });
                    context.SaveChanges();
                }
                //Authors
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            FullName = "John Green",
                            Bio = "Author of the book",
                            ProfilePictureURL = "https://s.lubimyczytac.pl/upload/authors/32136/153576-352x500.jpg"
                        },
                    });
                    context.SaveChanges();
                }
                //Publishers
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            FullName = "Bukowy Las",
                            Bio = "Publisher of the book",
                            Logo = "https://bukowylas.pl/assets/logo-large-a92cf9de459aead4fa4425b5480467235b8c9bfd04f070e3930d9b14c1f0bddb.svg"
                        },
                    });
                    context.SaveChanges();
                }
                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Title = "Szukając Alaski",
                            Description = "Cool book",
                            Price = 28.90,
                            BookCoverURL = "http://s.lubimyczytac.pl/upload/books/188000/188946/170383-352x500.jpg",
                            Premiere = DateTime.Now.AddDays(-100),
                            BookstoreId = 1,
                            PublisherId = 1,
                            BookCategory = BookCategory.Nonfiction
                        }
                    });
                    context.SaveChanges();
                }
                //Authors & Books
                if (!context.Authors_Books.Any())
                {
                    context.Authors_Books.AddRange(new List<Author_Book>()
                    {
                        new Author_Book()
                        {
                            AuthorId = 1,
                            BookId = 1,
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
