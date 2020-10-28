using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspHomework.Business.Domeins
{
    public interface IReadOnly
    {
        Task<IEnumerable<string>> Get();
    }
}