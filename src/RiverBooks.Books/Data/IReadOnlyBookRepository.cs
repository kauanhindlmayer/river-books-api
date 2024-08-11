namespace RiverBooks.Books.Data;

public interface IReadOnlyBookRepository
{
    Task<List<Book>> ListAsync(CancellationToken ct = default);
    Task<Book?> GetByIdAsync(Guid id, CancellationToken ct = default);
}
