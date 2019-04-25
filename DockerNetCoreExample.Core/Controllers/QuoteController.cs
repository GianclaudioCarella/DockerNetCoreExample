using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DockerNetCoreExample.Models;
using DockerNetCoreExample.Business.Services;
using DockerNetCoreExample.Business.Model;

namespace DockerNetCoreExample.Controllers
{
    public class QuoteController : Controller
    {

        private readonly QuoteService _quoteService;

        public QuoteController(
                QuoteService quoteService
            )
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

        public Quote GetRandomQuote()
        {
            return _quoteService.GetRandomQuote();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
