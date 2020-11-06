using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.ViewModels;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using AppContext = DAL.AppContext;

namespace BLL.Domeins
{
    public class BookDomein : ICrud
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public BookDomein(AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookModel> Create(BookModel book)
        {
            var newBook = _mapper.Map<Book>(book);
            var genreIds = await GetGenreIdFromName(book.Genres);
            foreach (var genreId in genreIds)
                newBook.BookGenres.Add(new BookGenre {BookId = newBook.Id, GenreId = genreId});

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            newBook = await _context.Books.Include(_book => _book.BookGenres)
                .ThenInclude(_bookgenre => _bookgenre.Genre)
                .Where(_book => _book.Id == newBook.Id).AsNoTracking().FirstAsync();
            return _mapper.Map<BookModel>(newBook);
        }

        public async Task<BookModel> Change(BookModel book)
        {
            var changedBook = await _context.Books.Include(_book => _book.BookGenres)
                .ThenInclude(_bookgenre => _bookgenre.Genre)
                .Where(_book => _book.Id == book.Id).AsNoTracking().FirstAsync();
            if (changedBook == null)
                throw new InvalidDataException($"There is no book with id: {book.Id}");

            var newGenres = await GetGenreIdFromName(book.Genres);
            var oldGenres = changedBook.BookGenres.Select(_bookgenre => _bookgenre.Genre.Id).ToList();

            await using var transaction = await _context.Database.BeginTransactionAsync();
            {
                var bookGenresRemove = oldGenres.Except(newGenres)
                    .Select(gid => new BookGenre {BookId = book.Id, GenreId = gid});
                var bookGenresAdd = newGenres.Except(oldGenres)
                    .Select(gid => new BookGenre {BookId = book.Id, GenreId = gid});

                _context.BooksGenres.RemoveRange(bookGenresRemove);
                await _context.BooksGenres.AddRangeAsync(bookGenresAdd);

                changedBook = _mapper.Map(book, changedBook);
                _context.Entry(changedBook).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            await transaction.CommitAsync();

            changedBook = await _context.Books.Include(_book => _book.BookGenres)
                .ThenInclude(_bookgenre => _bookgenre.Genre)
                .Where(_book => _book.Id == changedBook.Id).AsNoTracking().FirstAsync();

            return _mapper.Map<BookModel>(changedBook);
        }

        public async Task<IEnumerable<BookModel>> Get(string genre = null)
        {
            return _mapper.Map<IEnumerable<BookModel>>(await _context.Books
                .Include(_book => _book.BookGenres)
                .ThenInclude(_bookgenre => _bookgenre.Genre)
                .Where(_book => genre == null || _book.BookGenres.Any(_bookgenre =>
                    string.Equals(_bookgenre.Genre.Name, genre, StringComparison.CurrentCultureIgnoreCase)))
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                throw new InvalidDataException($"There is no book with id: {id}");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        private async Task<IEnumerable<int>> GetGenreIdFromName(IEnumerable<string> genreNames)
        {
            var result = new List<int>(genreNames.Count());
            foreach (var genreName in genreNames)
            {
                var genre = await _context.Genres.Where(_genre => _genre.Name == genreName).AsNoTracking()
                    .FirstOrDefaultAsync();
                if (genre != null)
                    result.Add(genre.Id);
                else
                    throw new InvalidDataException($"There is no genre with name: {genreName}");
            }

            return result;
        }
    }
}