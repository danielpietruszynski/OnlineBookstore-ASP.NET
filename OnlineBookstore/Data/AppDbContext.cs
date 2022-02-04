using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Book>().HasKey(ab => new
            {
                ab.AuthorId,
                ab.BookId
            });

            modelBuilder.Entity<Author_Book>().HasOne(b => b.Book).WithMany(ab => ab.Authors_Books).HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Author_Book>().HasOne(b => b.Author).WithMany(ab => ab.Authors_Books).HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_Book> Authors_Books  { get; set; }
        public DbSet<Bookstore> Bookstores { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
