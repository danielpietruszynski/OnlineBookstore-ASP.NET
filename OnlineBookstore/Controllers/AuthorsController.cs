using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;
using OnlineBookstore.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _service;
        public AuthorsController(IAuthorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        
        //Get: Authors/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
