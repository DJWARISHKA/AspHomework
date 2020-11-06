using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.ViewModels
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string AuthorName { get; set; }

        [Required] public string PublisherName { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}