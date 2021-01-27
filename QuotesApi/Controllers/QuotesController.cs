using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
       static List<Quote> _quotes = new List<Quote>()
        {
            new Quote(){
                Id = 0,
                Author = "Nelson Mandela",
                Description = "The greatest glory in living lies not in never falling, but in rising every time we fall",
                Title = "Inspiration"
            },


              new Quote(){
                Id = 1,
                Author = "Walt Disney",
                Description = "The way to get started is to quit talking and begin doing.",
                Title = "Motivation"
            },


               new Quote(){
                Id = 1,
                Author = "James Cameron",
                Description = "If you set your goals ridiculously high and it's a failure, you will fail above everyone else's success",
                Title = "Motivation"
            }
         };


        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }


        [HttpPost]
        public void Post([FromBody]Quote quote)
        {
            _quotes.Add(quote);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quote quote)
        {
            _quotes[id] = quote;
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _quotes.RemoveAt(id);
        }


    }
}
