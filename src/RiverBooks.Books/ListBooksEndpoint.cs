using FastEndpoints;

namespace RiverBooks.Books;

internal class ListBooksEndpoint(IBookService bookService)
    : EndpointWithoutRequest<ListBooksResponse>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Get("/api/books");
        AllowAnonymous();
    }

    public override async Task<ListBooksResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        var books = await _bookService.ListBooksAsync();

        await SendAsync(new ListBooksResponse()
        {
            Books = books
        }, cancellation: cancellationToken);

        return new ListBooksResponse()
        {
            Books = books
        };
    }
}
