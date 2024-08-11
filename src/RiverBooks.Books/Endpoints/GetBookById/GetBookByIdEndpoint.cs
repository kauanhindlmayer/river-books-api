using FastEndpoints;

namespace RiverBooks.Books.Endpoints.GetBookById;

internal class GetBookByIdEndpoint(IBookService bookService) : Endpoint<GetBookByIdRequest, BookDto>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Get("/api/books/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetBookByIdRequest request,
        CancellationToken ct = default)
    {
        var book = await _bookService.GetBookByIdAsync(request.Id, ct);

        if (book is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendAsync(book, cancellation: ct);
    }
}
