using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data;
using OnlineBookstore.Data.Services;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BooksController : Controller
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllAsync(n => n.Bookstore);
            return View(allBooks);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync(n => n.Bookstore);

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allBooks.Where(n => string.Equals(n.Title, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allBooks);
        }

        //GET: Books/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _service.GetBookByIdAsync(id);
            return View(bookDetail);
        }

        //GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var bookDropdownsData = await _service.GetNewBookDropdownValues();

            ViewBag.Bookstores = new SelectList(bookDropdownsData.Bookstores, "Id", "Name");
            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "FullName");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(newBookVM book)
        {
            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownValues();

                ViewBag.Bookstores = new SelectList(bookDropdownsData.Bookstores, "Id", "Name");
                ViewBag.Producers = new SelectList(bookDropdownsData.Publishers, "Id", "FullName");
                ViewBag.Actors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

                return View(book);
            }

            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }


        //GET: Books/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new newBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Description = bookDetails.Description,
                Price = bookDetails.Price,
                Premiere = bookDetails.Premiere,
                BookCoverURL = bookDetails.BookCoverURL,
                BookCategory = bookDetails.BookCategory,
                BookstoreId = bookDetails.BookstoreId,
                PublisherId = bookDetails.PublisherId,
                AuthorsIds = bookDetails.Authors_Books.Select(n => n.AuthorId).ToList(),
            };

            var bookDropdownsData = await _service.GetNewBookDropdownValues();
            ViewBag.Cinemas = new SelectList(bookDropdownsData.Bookstores, "Id", "Name");
            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "FullName");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, newBookVM book)
        {
            if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownValues();

                ViewBag.Bookstores = new SelectList(bookDropdownsData.Bookstores, "Id", "Name");
                ViewBag.Producers = new SelectList(bookDropdownsData.Publishers, "Id", "FullName");
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

                return View(book);
            }

            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
