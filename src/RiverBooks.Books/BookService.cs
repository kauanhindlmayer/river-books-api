

namespace RiverBooks.Books;

public class BookService(IBookRepository bookRepository) : IBookService
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task CreateBookAsync(BookDto bookDto)
    {
        var book = new Book(
            bookDto.Id,
            bookDto.Title,
            bookDto.Author,
            bookDto.Price);
        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
        {
            throw new InvalidOperationException($"Book with id {id} not found.");
        }

        await _bookRepository.DeleteAsync(id);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task<BookDto?> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        return book is not null
            ? BookDto.FromDomain(book)
            : null;
    }

    public async Task<List<BookDto>> ListBooksAsync()
    {
        var books = await _bookRepository.ListAsync();
        return books.ConvertAll(BookDto.FromDomain);
    }

    public async Task UpdateBookPriceAsync(Guid id, decimal price)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
        {
            throw new InvalidOperationException($"Book with id {id} not found.");
        }

        book.UpdatePrice(price);
        await _bookRepository.SaveChangesAsync();
    }
}
