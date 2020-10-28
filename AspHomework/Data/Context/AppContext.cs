using AspHomework.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspHomework.Data.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            DbInitializer.Initialize(this);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BooksGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=asdhomework;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookGenre>()
                .HasOne(bookgenre => bookgenre.Book)
                .WithMany(book => book.BookGenres)
                .HasForeignKey(bookgenre => bookgenre.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bookgenre => bookgenre.Genre)
                .WithMany(genre => genre.GenreBooks)
                .HasForeignKey(bookgenre => bookgenre.GenreId);
            modelBuilder.Entity<BookGenre>()
                .HasKey(bookgenre => new {bookgenre.BookId, bookgenre.GenreId});

            base.OnModelCreating(modelBuilder);
        }
    }
}