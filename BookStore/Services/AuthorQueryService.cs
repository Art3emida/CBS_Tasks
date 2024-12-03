namespace BookStore.Services;

using BookStore.Constants;
using BookStore.Exceptions;
using BookStore.Models;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Interfaces;

public class AuthorQueryService : IAuthorQueryService
{
    private readonly IAuthorQueryRepository _queryRepository;

    public AuthorQueryService(IAuthorQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }
    
    public async Task<Author> GetByIdAsync(int id)
    {
        Author? author = await _queryRepository.GetByIdAsync(id);

        if (author == null)
        {
            throw new NotFoundException(string.Format(
                ExceptionMessage.AuthorNotFound,
                id
            ));
        }
        
        return author;
    }

    public async Task<List<Author>> GetAllAsync()
    {
        return await _queryRepository.GetAllAsync();
    }
}
