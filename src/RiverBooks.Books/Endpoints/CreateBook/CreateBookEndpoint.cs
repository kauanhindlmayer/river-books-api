using FastEndpoints;
using RiverBooks.Books.Endpoints.GetBookById;

namespace RiverBooks.Books.Endpoints.CreateBook;

internal class CreateBookEndpoint(IBookService bookService)
    : Endpoint<CreateBookRequest, BookDto>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Post("/api/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        CreateBookRequest request,
        CancellationToken ct = default)
    {
        var book = new BookDto(
            Id: request.Id ?? Guid.NewGuid(),
            Title: request.Title,
            Author: request.Author,
            Price: request.Price);

        await _bookService.CreateBookAsync(book, ct);

        await SendCreatedAtAsync<GetBookByIdEndpoint>(
            new { book.Id },
            book,
            cancellation: ct);
    }
}
