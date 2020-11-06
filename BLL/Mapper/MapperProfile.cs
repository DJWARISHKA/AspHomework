using System.Linq;
using AutoMapper;
using BLL.ViewModels;
using DAL.Entities;

namespace BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookModel>()
                .ForMember(model => model.Genres,
                    opt => opt.MapFrom(book => book.BookGenres.Select(bg => bg.Genre != null ? bg.Genre.Name : null)));
            CreateMap<BookModel, Book>()
                .ForMember(book => book.BookGenres, opt => opt.Ignore());
        }
    }
}