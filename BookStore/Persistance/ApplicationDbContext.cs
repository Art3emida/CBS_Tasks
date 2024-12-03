namespace BookStore.Persistance;

using BookStore.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "The Great Detective",
                Genre = Genre.Detective,
                TotalPages = 300,
                AuthorId = 1
            },
            new Book
            {
                Id = 2,
                Title = "The Fantasy World",
                Genre = Genre.Fantasy,
                TotalPages = 450,
                AuthorId = 2
            }
        );

        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                Id = 1,
                LastName = "Doyle",
                FirstName = "Arthur",
                BirthDate = new DateOnly(1859, 5, 22)
            },
            new Author
            {
                Id = 2,
                LastName = "Tolkien",
                FirstName = "John",
                BirthDate = new DateOnly(1892, 1, 3)
            }
        );
    }
}
