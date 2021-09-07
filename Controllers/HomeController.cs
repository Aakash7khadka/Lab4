using Lab4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Texas International College");
            HttpContext.Session.SetString("Address", "Mitrapark");
            return Content("Session  sucessful!");
        }

        public IActionResult DispSession()
        {
            ViewBag.name = HttpContext.Session.GetString("Name");
            ViewBag.roll = HttpContext.Session.GetString("Address");
            return View();

        }
        public IActionResult Method1()
        {
            TempData["msg"] = "Data from method1";
            return Content("message sucessfully set");
        }
        public IActionResult Method2()
        {
            ViewBag.msg = TempData["msg"];
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult QueryString(string name,string address)
        {
            return Content("Name: "+name+" Address:"+address);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
