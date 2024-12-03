namespace BookStore.Dto;

using System.ComponentModel.DataAnnotations;
using BookStore.Models;

public class EditAuthorRequestDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(40, ErrorMessage = "Last name can't be longer than 100 characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(40, ErrorMessage = "First name can't be longer than 100 characters")]
    public string FirstName { get; set; }

    [StringLength(40, ErrorMessage = "Middle name can't be longer than 100 characters")]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Birth date is required")]
    public DateOnly BirthDate { get; set; }

    public ICollection<Book> BooksExistDetails { get; set; } = new List<Book>();

    public List<int> BooksExist { get; set; } = new List<int>();

    public List<Book> BooksNew { get; set; } = new List<Book>();
}
