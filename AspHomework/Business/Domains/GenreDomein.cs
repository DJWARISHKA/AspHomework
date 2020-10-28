using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspHomework.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AspHomework.Business.Domeins
{
    internal class GenreDomein : IReadOnly
    {
        private readonly AppContext _context;

        public GenreDomein(AppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> Get()
        {
            return await _context.Genres.Select(g => g.Name).AsNoTracking().ToListAsync();
        }
    }
}