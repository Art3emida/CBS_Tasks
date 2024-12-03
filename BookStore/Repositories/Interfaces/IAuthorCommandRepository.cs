namespace BookStore.Repositories.Interfaces;

using BookStore.Models;

public interface IAuthorCommandRepository
{
    Task AddAsync(Author author);

    Task UpdateAsync(Author author);
    
    Task DeleteAsync(Author author);
}
