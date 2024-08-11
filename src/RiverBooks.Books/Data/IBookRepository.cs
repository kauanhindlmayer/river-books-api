namespace RiverBooks.Books.Data;

public interface IBookRepository : IReadOnlyBookRepository
{
    Task AddAsync(Book book, CancellationToken ct = default);
    Task DeleteAsync(Book book);
    Task SaveChangesAsync(CancellationToken ct = default);
}
