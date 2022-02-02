using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data.Base;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Services
{
    public class AuthorsService : EntityBaseRepository<Author>, IAuthorsService
    {
        public AuthorsService(AppDbContext context) : base(context) { }
    }
}
