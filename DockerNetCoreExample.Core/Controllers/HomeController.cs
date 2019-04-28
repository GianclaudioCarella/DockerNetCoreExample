using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DockerNetCoreExample.Models;
using DockerNetCoreExample.Business.Services;

namespace DockerNetCoreExample.Controllers
{
    public class HomeController : Controller
    {

        private readonly QuoteService _quoteService;

        public HomeController(QuoteService quoteService)
        {
            _quoteService = quoteService;   
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Quotes()
        {
            var teste = _quoteService.Get();
            return View(teste);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
