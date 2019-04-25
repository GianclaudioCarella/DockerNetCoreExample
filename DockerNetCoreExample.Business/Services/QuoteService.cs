using DockerNetCoreExample.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNetCoreExample.Business.Services
{
    public class QuoteService
    {
        private readonly List<Quote> _quotes;

        public QuoteService()
        {
            _quotes = new List<Quote>();
        }

        public List<Quote> GetQuotes()
        {
            return _quotes;
        }

        public Quote GetRandomQuote()
        {
            return new Quote("What you do today is important because you are exchanging a day of your life for it.", "Unknown");
        }
    }
}
