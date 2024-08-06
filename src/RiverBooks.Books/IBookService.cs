namespace RiverBooks.Books;

public interface IBookService
{
    Task<List<BookDto>> ListBooksAsync();
    Task<BookDto?> GetBookByIdAsync(Guid id);
    Task CreateBookAsync(BookDto bookDto);
    Task UpdateBookPriceAsync(Guid id, decimal price);
    Task DeleteBookAsync(Guid id);
}
