namespace RiverBooks.Books.Contracts;

public record BookDetailsResponse(
    Guid Id,
    string Title,
    string Author,
    decimal Price)
{
    public static BookDetailsResponse FromDomain(BookDto book)
    {
        return new BookDetailsResponse(
            Id: book.Id,
            Title: book.Title,
            Author: book.Author,
            Price: book.Price);
    }

    public string Description => $"{Title} by {Author}";
}
