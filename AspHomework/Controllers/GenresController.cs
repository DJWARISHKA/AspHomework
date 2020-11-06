using System.Collections.Generic;
using System.Threading.Tasks;
using AspHomework.Filters;
using BLL.Domeins;
using Microsoft.AspNetCore.Mvc;

namespace AspHomework.Controllers
{
    [ExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IReadOnly _genreDomein;

        public GenresController(IReadOnly genreDomein)
        {
            _genreDomein = genreDomein;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _genreDomein.Get();
        }
    }
}