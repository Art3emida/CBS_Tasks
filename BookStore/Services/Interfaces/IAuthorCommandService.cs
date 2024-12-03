namespace BookStore.Services.Interfaces;

using BookStore.Models;

public interface IAuthorCommandService
{
    Task AddAsync(Author author);

    Task UpdateAsync(Author author);
    
    Task DeleteAsync(Author author);
}
