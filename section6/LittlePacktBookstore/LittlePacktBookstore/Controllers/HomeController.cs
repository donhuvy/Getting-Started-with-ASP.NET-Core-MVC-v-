using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittlePacktBookstore.Models;
using LittlePacktBookstore.Services;
using LittlePacktBookstore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LittlePacktBookstore.Controllers
{
    public class HomeController : Controller
    {
		//List<Book> _book;
		IRepository<Book> _bookRepo;
		IRepository<Carousel> _CarouselRepo;
		public HomeController(IRepository<Book> book, IRepository<Carousel> carousel)
		{
			//_book = new List<Book>();
			_bookRepo = book;
			_CarouselRepo = carousel;
		}
		//The home page
		public IActionResult Index()
        {
			HomeIndexViewModel model = new HomeIndexViewModel()
			{
				Books = _bookRepo.GetAll(),
				Carousels = _CarouselRepo.GetAll()
			};
			return View(model);
        }
		[HttpGet]
		public IActionResult AddBook()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddBook(Book book)
		{
			if(ModelState.IsValid)
			{
				Book item = new Book()
				{
					Id = _bookRepo.GetAll().Max(m => m.Id) + 1,
					Title = book.Title,
					Description = book.Description,
					Author = book.Author,
					PublishDate = book.PublishDate,
					Price = book.Price,
					image = book.image
				};
				_bookRepo.Add(item);
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		//The about page
		public IActionResult About()
		{
			return View();
		}

		//The contact us page
		public IActionResult Contact()
		{
			return View();
		}
    }
}