
using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books.Data;

public class BookRepository(BooksDbContext dbContext) : IBookRepository
{
    private readonly BooksDbContext _dbContext = dbContext;

    public async Task AddAsync(Book book, CancellationToken ct = default)
    {
        await _dbContext.Books.AddAsync(book, ct);
    }

    public Task DeleteAsync(Book book)
    {
        _dbContext.Books.Remove(book);
        return Task.CompletedTask;
    }

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _dbContext.Books.FindAsync(id, ct);
    }

    public async Task<List<Book>> ListAsync(CancellationToken ct = default)
    {
        return await _dbContext.Books.ToListAsync(ct);
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _dbContext.SaveChangesAsync(ct);
    }
}
