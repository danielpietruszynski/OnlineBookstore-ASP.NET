using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    public class BookstoresController : Controller
    {
        private readonly AppDbContext _context;

        public BookstoresController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allBookstores = await _context.Bookstores.ToListAsync();
            return View();
        }
    }
}
