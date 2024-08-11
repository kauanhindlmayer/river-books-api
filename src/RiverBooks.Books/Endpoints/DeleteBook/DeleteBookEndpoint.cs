using FastEndpoints;

namespace RiverBooks.Books.Endpoints.DeleteBook;

internal class DeleteBookEndpoint(IBookService bookService) : Endpoint<DeleteBookRequest>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Delete("/api/books/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        DeleteBookRequest request,
        CancellationToken ct = default)
    {
        // TODO: Handle not found
        await _bookService.DeleteBookAsync(request.Id, ct);

        await SendNoContentAsync(ct);
    }
}
