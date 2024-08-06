namespace RiverBooks.Books;

public record BookDto(Guid Id, string Title, string Author, decimal Price)
{
    public static BookDto FromDomain(Book book) => new(
        book.Id,
        book.Title,
        book.Author,
        book.Price);
}
