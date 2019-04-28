using DockerNetCoreExample.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerNetCoreExample.Business.Services
{
    public class QuoteService
    {
        private readonly ApiContext _context;

        public QuoteService(ApiContext context)
        {
            _context = context;
        }

        public List<Quote> Get()
        {
            return _context.Quotes.ToList();

        }

        public void Add(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public void AddRange(List<Quote> quotes)
        {
            _context.AddRange(quotes);
            _context.SaveChanges();
        }
    }
}
