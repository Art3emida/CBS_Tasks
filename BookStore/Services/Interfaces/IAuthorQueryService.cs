namespace BookStore.Services.Interfaces;

using BookStore.Models;

public interface IAuthorQueryService
{
    Task<Author> GetByIdAsync(int id);

    Task<List<Author>> GetAllAsync();
}
