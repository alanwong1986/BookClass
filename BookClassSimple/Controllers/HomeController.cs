using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookClassSimple.Models;

namespace BookClassSimple.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            string RequestId = "";
            if (HttpContext != null)
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            }

            return View(new ErrorViewModel { RequestId = RequestId });
        }
    }
}
