using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspHomework.Data.Entities
{
    public class Book
    {
        public Book()
        {
            BookGenres = new List<BookGenre>();
        }

        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string Author { get; set; }

        [Required] public string Publisher { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}