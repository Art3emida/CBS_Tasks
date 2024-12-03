namespace BookStore.Models;

public class Author
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public DateOnly BirthDate { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();

    public void AddBooks(List<Book> list)
    {
        foreach (Book book in list)
        {
            Books.Add(book);
        }
    }

    public void RemoveBooks(List<Book> list)
    {
        foreach (Book book in list)
        {
            Books.Remove(book);
        }
    }
}
