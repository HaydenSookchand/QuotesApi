using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Data;
using QuotesApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {

        private QuotesDbContext _quotesDbContext;

        public QuotesController(QuotesDbContext quotesDbContext)
        {

            _quotesDbContext = quotesDbContext;

        }
        

        [HttpGet]
        public IActionResult Get(string sort)
        {
            IQueryable<Quote> quotes;

            switch (sort)
            {
                case  "desc" :
                  quotes =  _quotesDbContext.Quotes.OrderByDescending(q => q.CreatedAt);
                    break;
                case "asc":
                    quotes = _quotesDbContext.Quotes.OrderBy(q => q.CreatedAt);
                    break;
                default:
                    quotes = _quotesDbContext.Quotes;
                    break;
            }

            return Ok(quotes);
        }

        [HttpGet("[action]")]
        public IActionResult PagingQuote(int? pageNumber, int? pageSize) {

         var  quotes = _quotesDbContext.Quotes;
         var currentPageNumber = pageNumber ?? 1;
         var currentPageSize = pageSize ?? 2;

         return Ok(quotes.Skip((currentPageNumber - 1)* currentPageSize).Take(currentPageSize));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("No record found for this id");
            }
            else
            {
                return Ok(quote);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
            var quoteToUpdate = _quotesDbContext.Quotes.Find(id);

            if (quoteToUpdate == null)
            {
                return NotFound("No record found for this id");
            }
            else {
                quoteToUpdate.Title = quote.Title;
                quoteToUpdate.Author = quote.Author;
                quoteToUpdate.Description = quote.Description;
                quoteToUpdate.Type = quote.Type;
                quoteToUpdate.CreatedAt = quote.CreatedAt;
                _quotesDbContext.SaveChanges();

                return Ok("Record Updated Successfully");
            }
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quoteToUpdate = _quotesDbContext.Quotes.Find(id);

            if (quoteToUpdate == null)
            {
                return NotFound("No record found for this id");
            }
            else
            {
                var quoteToDelete = _quotesDbContext.Quotes.Find(id);
                _quotesDbContext.Quotes.Remove(quoteToDelete);
                _quotesDbContext.SaveChanges();
                return Ok("Deleted");
            }

        }
    }
}
