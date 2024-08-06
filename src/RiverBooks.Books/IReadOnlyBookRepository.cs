namespace RiverBooks.Books;

public interface IReadOnlyBookRepository
{
    Task<List<Book>> ListAsync();
    Task<Book?> GetByIdAsync(Guid id);
}
