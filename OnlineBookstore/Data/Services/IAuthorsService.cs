using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Services
{
    public interface IAuthorsService
    {
        Task<IEnumerable<Author>> GetAll();
        Author GetById(int id);
        void Add(Author author);
        Author Update(int id, Author newAuthor);
        void Delete(int id);

    }
}
