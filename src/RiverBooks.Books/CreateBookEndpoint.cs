using FastEndpoints;

namespace RiverBooks.Books;

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
        CancellationToken cancellationToken = default)
    {
        var book = new BookDto(
            Id: request.Id ?? Guid.NewGuid(),
            Title: request.Title,
            Author: request.Author,
            Price: request.Price);

        await _bookService.CreateBookAsync(book);

        await SendCreatedAtAsync<GetBookByIdEndpoint>(
            new { book.Id },
            book,
            cancellation: cancellationToken);
    }
}
