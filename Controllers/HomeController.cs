using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiPrimerAppMVC.Models;

namespace MiPrimerAppMVC.Controllers
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
            ViewData["Mensaje2"] = "Este es un mensaje desde el controlador con ViewData";
            ViewBag.Mensaje1 = "Este es un mensaje desde el controlador con ViewBag";
            ViewBag.Contador = 10;
            ViewData["Contador2"] = 20;

            ViewBag.Precio= 123.45m;
            ViewData["Precio2"] = 201.45m;

            ViewBag.Fecha1= DateTime.Now;
            ViewData["Fecha2"] = DateTime.Now.AddDays(1);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult VistaDemo()
        {
            //ViewBag.Title = "Vista demo";
            return View();
        }
       
    }
}
