using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.ViewModels;

namespace BLL.Domeins
{
    public interface ICrud
    {
        Task<BookModel> Create(BookModel book);
        Task<IEnumerable<BookModel>> Get(string genre = null);
        Task<BookModel> Change(BookModel book);
        Task Delete(int id);
    }
}