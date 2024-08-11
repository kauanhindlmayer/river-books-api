using FastEndpoints;

namespace RiverBooks.Books.Endpoints.ListBooks;

internal class ListBooksEndpoint(IBookService bookService)
    : EndpointWithoutRequest<ListBooksResponse>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Get("/api/books");
        AllowAnonymous();
    }

    public override async Task<ListBooksResponse> HandleAsync(CancellationToken ct = default)
    {
        var books = await _bookService.ListBooksAsync(ct);

        await SendAsync(new ListBooksResponse()
        {
            Books = books
        }, cancellation: ct);

        return new ListBooksResponse()
        {
            Books = books
        };
    }
}
