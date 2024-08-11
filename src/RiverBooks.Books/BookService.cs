using RiverBooks.Books.Data;

namespace RiverBooks.Books;

public class BookService(IBookRepository bookRepository) : IBookService
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task CreateBookAsync(BookDto bookDto, CancellationToken ct = default)
    {
        var book = new Book(
            bookDto.Id,
            bookDto.Title,
            bookDto.Author,
            bookDto.Price);
        await _bookRepository.AddAsync(book, ct);
        await _bookRepository.SaveChangesAsync(ct);
    }

    public async Task DeleteBookAsync(Guid id, CancellationToken ct = default)
    {
        var book = await _bookRepository.GetByIdAsync(id, ct);
        if (book is null)
        {
            throw new InvalidOperationException($"Book with id {id} not found.");
        }

        await _bookRepository.DeleteAsync(book);
        await _bookRepository.SaveChangesAsync(ct);
    }

    public async Task<BookDto?> GetBookByIdAsync(Guid id, CancellationToken ct = default)
    {
        var book = await _bookRepository.GetByIdAsync(id, ct);
        return book is not null
            ? BookDto.FromDomain(book)
            : null;
    }

    public async Task<List<BookDto>> ListBooksAsync(CancellationToken ct = default)
    {
        var books = await _bookRepository.ListAsync(ct);
        return books.ConvertAll(BookDto.FromDomain);
    }

    public async Task UpdateBookPriceAsync(Guid id, decimal price, CancellationToken ct = default)
    {
        var book = await _bookRepository.GetByIdAsync(id, ct);
        if (book is null)
        {
            throw new InvalidOperationException($"Book with id {id} not found.");
        }

        book.UpdatePrice(price);
        await _bookRepository.SaveChangesAsync(ct);
    }
}
