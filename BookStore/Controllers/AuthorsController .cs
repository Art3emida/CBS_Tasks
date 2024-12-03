namespace BookStore.Controllers;

using AutoMapper;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Services.Interfaces;

public class AuthorsController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAuthorQueryService _authorQueryService;
    private readonly IAuthorCommandService _authorCommandService;

    public AuthorsController(
        IMapper mapper,
        IAuthorQueryService authorQueryService,
        IAuthorCommandService authorCommandService
    ) {
        _mapper = mapper;
        _authorQueryService = authorQueryService;
        _authorCommandService = authorCommandService;
    }

    [Route("authors")]
    public async Task<IActionResult> Index()
    {
        List<Author> authors = await _authorQueryService.GetAllAsync();

        return View(authors);
    }

    [Route("authors/create")]
    public IActionResult Create()
    {
        ViewBag.Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("authors/create")]
    public async Task<IActionResult> Create(CreateAuthorRequestDto requestDto)
    {
        if (ModelState.IsValid)
        {
            Author author = _mapper.Map<Author>(requestDto);
            await _authorCommandService.AddAsync(author);

            if (requestDto.BooksNew.Any())
            {
                requestDto.BooksNew.ForEach(book => book.AuthorId = author.Id);
                author.Books = requestDto.BooksNew;
                await _authorCommandService.UpdateAsync(author);
            }

            return RedirectToAction(nameof(Index));
        }

        ViewBag.Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();

        return View(requestDto);
    }

    [Route("authors/edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        Author author = await _authorQueryService.GetByIdAsync(id);

        ViewBag.Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();

        return View(new EditAuthorRequestDto {
            Id = author.Id,
            LastName = author.LastName,
            MiddleName = author.MiddleName,
            FirstName = author.FirstName,
            BirthDate = author.BirthDate,
            BooksExistDetails = author.Books,
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("authors/edit/{id}")]
    public async Task<IActionResult> Edit(int id, EditAuthorRequestDto requestDto)
    {
        if (ModelState.IsValid)
        {
            Author author = await _authorQueryService.GetByIdAsync(id);
            author.BirthDate = requestDto.BirthDate;
            author.FirstName = requestDto.FirstName;
            author.MiddleName = requestDto.MiddleName;
            author.LastName = requestDto.LastName;
            List<Book> booksToRemove = author.Books.Where(b => !requestDto.BooksExist.Contains(b.Id)).ToList();
            author.RemoveBooks(booksToRemove);
            author.AddBooks(requestDto.BooksNew);
            await _authorCommandService.UpdateAsync(author);

            return RedirectToAction(nameof(Index));
        }

        ViewBag.Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();

        Author entity = await _authorQueryService.GetByIdAsync(id);
        requestDto.BooksExistDetails = entity.Books;

        return View(requestDto);
    }

    [Route("authors/delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Author author = await _authorQueryService.GetByIdAsync(id);
        await _authorCommandService.DeleteAsync(author);

        return RedirectToAction(nameof(Index));
    }
}
