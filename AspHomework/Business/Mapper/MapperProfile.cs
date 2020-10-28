using System.Linq;
using AspHomework.Business.ApiModels;
using AspHomework.Data.Entities;
using AutoMapper;

namespace AspHomework.Business.Mapper
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