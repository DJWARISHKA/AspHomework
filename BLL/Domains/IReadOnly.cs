using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Domeins
{
    public interface IReadOnly
    {
        Task<IEnumerable<string>> Get();
    }
}