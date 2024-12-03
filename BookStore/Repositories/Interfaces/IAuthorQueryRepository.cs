namespace BookStore.Repositories.Interfaces;

using BookStore.Models;

public interface IAuthorQueryRepository
{
    Task<Author?> GetByIdAsync(int id);

    Task<List<Author>> GetAllAsync();
}
