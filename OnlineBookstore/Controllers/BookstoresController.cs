using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data;
using OnlineBookstore.Data.Services;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BookstoresController : Controller
    {
        private readonly IBookstoresService _service;

        public BookstoresController(IBookstoresService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBookstores = await _service.GetAllAsync();
            return View(allBookstores);
        }


        //Get: Bookstores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Address")] Bookstore bookstore)
        {
            if (!ModelState.IsValid) return View(bookstore);
            await _service.AddAsync(bookstore);
            return RedirectToAction(nameof(Index));
        }

        //Get: Bookstores/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var BookstoreDetails = await _service.GetByIdAsync(id);
            if (BookstoreDetails == null) return View("NotFound");
            return View(BookstoreDetails);
        }

        //Get: Bookstores/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var bookstoreDetails = await _service.GetByIdAsync(id);
            if (bookstoreDetails == null) return View("NotFound");
            return View(bookstoreDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Address")]  Bookstore bookstore)
        {
            if (!ModelState.IsValid) return View(bookstore);
            await _service.UpdateAsync(id, bookstore);
            return RedirectToAction(nameof(Index));
        }

        //Get: Bookstores/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var bookstoreDetails = await _service.GetByIdAsync(id);
            if (bookstoreDetails == null) return View("NotFound");
            return View(bookstoreDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var bookstoreDetails = await _service.GetByIdAsync(id);
            if (bookstoreDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}