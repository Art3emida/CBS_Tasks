namespace BookStore.Repositories;

using BookStore.Persistance;
using BookStore.Models;
using BookStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class AuthorQueryRepository : IAuthorQueryRepository
{
    private readonly ApplicationDbContext _db;

    public AuthorQueryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _db.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Author>> GetAllAsync()
    {
        return await _db.Authors
            .Include(a => a.Books)
            .ToListAsync();
    }
}
