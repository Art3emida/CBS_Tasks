namespace BookStore.Services;

using BookStore.Models;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Interfaces;

public class AuthorCommandService : IAuthorCommandService
{
    private readonly IAuthorCommandRepository _commandRepository;

    public AuthorCommandService(IAuthorCommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task AddAsync(Author author)
    {
        await _commandRepository.AddAsync(author);
    }

    public async Task UpdateAsync(Author author)
    {
        await _commandRepository.UpdateAsync(author);
    }

    public async Task DeleteAsync(Author author)
    {
        await _commandRepository.DeleteAsync(author);
    }
}
