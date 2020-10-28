using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspHomework.Data.Entities
{
    public class Genre
    {
        public Genre()
        {
            GenreBooks = new List<BookGenre>();
        }

        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        public ICollection<BookGenre> GenreBooks { get; set; }
    }
}