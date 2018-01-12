using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice.Interfaces;
using Practice.Models;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        private iTimeProvider timeProvider;
        public HomeController(iTimeProvider _timeProvider)
        {
            timeProvider = _timeProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AddOneMonth()
        {
            timeProvider.Now = timeProvider.Now.AddMonths(1);
            ViewBag.Time = timeProvider.Now.ToString();
            return View("Index");
        }
        public IActionResult SubtractOneMonth()
        {
            timeProvider.Now = timeProvider.Now.AddMonths(-1);
            ViewBag.Time = timeProvider.Now.ToString();
            return View("Index");
        }
    }
}
