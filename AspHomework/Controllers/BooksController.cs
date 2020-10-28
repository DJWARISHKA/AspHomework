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
        private readonly ICrud bookService;

        public BooksController(ICrud bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookModel>> Get([FromQuery] string genre)
        {
            return await bookService.Get(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookModel book)
        {
            try
            {
                book = await bookService.Create(book);
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
                book = await bookService.Change(book);
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
                await bookService.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}