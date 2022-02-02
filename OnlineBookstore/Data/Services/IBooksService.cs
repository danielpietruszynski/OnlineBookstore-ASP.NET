using OnlineBookstore.Data.Base;
using OnlineBookstore.Data.ViewModels;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Services
{
    public interface IBooksService:IEntityBaseRepository<Book>
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<NewBookDropdownsVM> GetNewBookDropdownValues();
        Task AddNewBookAsync(newBookVM data);
        Task UpdateBookAsync(newBookVM data);
    }
}
