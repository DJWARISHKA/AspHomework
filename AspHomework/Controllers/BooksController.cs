using System.Collections.Generic;
using System.Threading.Tasks;
using AspHomework.Business.ApiModels;
using AspHomework.Business.Domeins;
using AspHomework.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspHomework.Controllers
{
    [ExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ICrud bookDomein;

        public BooksController(ICrud bookDomein)
        {
            this.bookDomein = bookDomein;
        }

        [HttpGet]
        public async Task<IEnumerable<BookModel>> Get([FromQuery] string genre)
        {
            return await bookDomein.Get(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookModel book)
        {
            try
            {
                book = await bookDomein.Create(book);
                return Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookModel book)
        {
            try
            {
                book = await bookDomein.Change(book);
                return Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await bookDomein.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}