using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Domain.Models;
using BookList.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookListMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnityOfWork _unityOfWork;

        public BooksController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _unityOfWork.Books.GetAllAsync();

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _unityOfWork.Books.Add(book);
                var result = await _unityOfWork.CompleteAsync();

                TempData["CreateSuccess"] = $"Book {book.Name} has been created";

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _unityOfWork.Books.GetAsync(id);

            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var bookFromDatabase = await _unityOfWork.Books.GetAsync(book.Id);

                if (bookFromDatabase == null) return NotFound();

                bookFromDatabase.ISBN = book.ISBN;
                bookFromDatabase.Name = book.Name;
                bookFromDatabase.Author = book.Author;

                var result = await _unityOfWork.CompleteAsync();

                TempData["CreateSuccess"] = $"Book {book.Name} has been updated";

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }
    }
}