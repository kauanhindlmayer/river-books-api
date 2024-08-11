namespace RiverBooks.Books;

public interface IBookService
{
    Task<List<BookDto>> ListBooksAsync(CancellationToken ct = default);
    Task<BookDto?> GetBookByIdAsync(Guid id, CancellationToken ct = default);
    Task CreateBookAsync(BookDto bookDto, CancellationToken ct = default);
    Task UpdateBookPriceAsync(Guid id, decimal price, CancellationToken ct = default);
    Task DeleteBookAsync(Guid id, CancellationToken ct = default);
}
