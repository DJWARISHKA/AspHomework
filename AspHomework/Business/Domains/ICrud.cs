using System.Collections.Generic;
using System.Threading.Tasks;
using AspHomework.Business.ApiModels;

namespace AspHomework.Business.Domeins
{
    public interface ICrud
    {
        Task<BookModel> Create(BookModel book);
        Task<IEnumerable<BookModel>> Get(string genre = null);
        Task<BookModel> Change(BookModel book);
        Task Delete(int id);
    }
}