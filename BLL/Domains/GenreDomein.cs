using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Domeins
{
    public class GenreDomein : IReadOnly
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