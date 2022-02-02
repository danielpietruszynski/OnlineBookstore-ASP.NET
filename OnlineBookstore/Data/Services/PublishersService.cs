using OnlineBookstore.Data.Base;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Services
{
    public class PublishersService: EntityBaseRepository<Publisher>, IPublishersService
    {
        public PublishersService(AppDbContext context) : base(context)
        {
        }
    }
}
