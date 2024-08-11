using FastEndpoints;

namespace RiverBooks.Books;

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
        CancellationToken cancellationToken = default)
    {
        // TODO: Handle not found
        await _bookService.DeleteBookAsync(request.Id);

        await SendNoContentAsync(cancellation: cancellationToken);
    }
}
