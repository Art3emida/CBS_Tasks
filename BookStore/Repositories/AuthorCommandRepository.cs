namespace BookStore.Repositories;

using BookStore.Persistance;
using BookStore.Models;
using BookStore.Repositories.Interfaces;

public class AuthorCommandRepository : IAuthorCommandRepository
{
    private readonly ApplicationDbContext _db;

    public AuthorCommandRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Author author)
    {
        await _db.Authors.AddAsync(author);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Author author)
    {
        _db.Authors.Update(author);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Author author)
    {
        _db.Authors.Remove(author);

        await _db.SaveChangesAsync();
    }
}
