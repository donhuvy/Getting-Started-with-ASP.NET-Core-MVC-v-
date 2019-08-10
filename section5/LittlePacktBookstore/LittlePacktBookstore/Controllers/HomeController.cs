using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LittlePacktBookstore.Controllers
{
    public class HomeController : Controller
    {
		//The home page
        public IActionResult Index()
        {
            return View();
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