using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DockerNetCoreExample.Models;
using DockerNetCoreExample.Business.Services;
using DockerNetCoreExample.Business.Models;

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

        public List<Quote> GetQuotes()
        {
            return _quoteService.GetQuotes();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
