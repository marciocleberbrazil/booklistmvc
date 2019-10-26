using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}