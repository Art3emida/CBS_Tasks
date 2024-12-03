namespace BookStore.Models;

using System.ComponentModel.DataAnnotations;

public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title can't be longer than 200 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Genre is required")]
    public Genre Genre { get; set; }

    [Required(ErrorMessage = "Total pages is required")]
    [Range(1, 10000, ErrorMessage = "Total pages must be greater than 0")]
    public int TotalPages { get; set; }

    [Required]
    public int AuthorId { get; set; }

    public Author? Author { get; set; }
}

