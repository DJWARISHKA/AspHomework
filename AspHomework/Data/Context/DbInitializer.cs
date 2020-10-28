using System.Linq;
using AspHomework.Data.Entities;

namespace AspHomework.Data.Context
{
    public static class DbInitializer
    {
        private static bool genres;
        private static bool books;
        private static bool booksgenres;

        public static void Initialize(AppContext context)
        {
            context.Database.EnsureCreated();

            if (!genres)
                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(
                        new Genre {Id = 1, Name = "Комедия"},
                        new Genre {Id = 2, Name = "Трагедия"},
                        new Genre {Id = 3, Name = "Драмма"},
                        new Genre {Id = 4, Name = "Ужасы"},
                        new Genre {Id = 5, Name = "Лирика"},
                        new Genre {Id = 6, Name = "Приключения"},
                        new Genre {Id = 7, Name = "Исторический"},
                        new Genre {Id = 8, Name = "Фантастика"},
                        new Genre {Id = 9, Name = "Триллеры"},
                        new Genre {Id = 10, Name = "Саморазвитие"},
                        new Genre {Id = 11, Name = "Детективы"},
                        new Genre {Id = 12, Name = "Комиксы"},
                        new Genre {Id = 13, Name = "Фентези"},
                        new Genre {Id = 14, Name = "Роман"}
                    );
                    context.SaveChanges();
                    genres = true;
                }
                else
                {
                    genres = true;
                }

            if (!books)
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Id = 1,
                            Name = "Драконы осенних сумерек",
                            Author = "Уэйс Маргарет, Хикмен Трейси",
                            Year = 2004,
                            Publisher = "ИЦ «Максима»"
                        },
                        new Book
                        {
                            Id = 2,
                            Name = "Граф Монте-Кристо",
                            Author = "Дюма Александр",
                            Year = 2009,
                            Publisher = "Эксмо"
                        },
                        new Book
                        {
                            Id = 3,
                            Name = "Лабиринт Мёнина",
                            Author = "Фрай Макс",
                            Year = 2006,
                            Publisher = "Амфора"
                        }
                    );
                    context.SaveChanges();
                    books = true;
                }
                else
                {
                    books = true;
                }

            if (!booksgenres)
                if (!context.BooksGenres.Any())
                {
                    context.BooksGenres.AddRange(
                        new BookGenre {BookId = 1, GenreId = 13}, new BookGenre {BookId = 1, GenreId = 6},
                        new BookGenre {BookId = 2, GenreId = 6}, new BookGenre {BookId = 2, GenreId = 14},
                        new BookGenre {BookId = 3, GenreId = 1}, new BookGenre {BookId = 3, GenreId = 6},
                        new BookGenre {BookId = 3, GenreId = 13}
                    );
                    context.SaveChanges();
                    booksgenres = true;
                }
                else
                {
                    booksgenres = true;
                }
        }
    }
}