using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {

            // TODO: Change to redirect to Results action
            return View();
        }

        //[HttpGet]
        //public IActionResult Results
    }
}
