using System.Collections.Generic;
using System.Threading.Tasks;
using AspHomework.Business.Domeins;
using AspHomework.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspHomework.Controllers
{
    [ExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IReadOnly _genreService;

        public GenresController(IReadOnly genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _genreService.Get();
        }
    }
}