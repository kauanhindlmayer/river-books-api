using FastEndpoints;

namespace RiverBooks.Books.Endpoints.UpdateBookPrice;

internal class UpdateBookPriceEndpoint(IBookService bookService)
    : Endpoint<UpdateBookPriceRequest, BookDto>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Post("/api/books/{id}/price-history");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        UpdateBookPriceRequest request,
        CancellationToken ct = default)
    {
        await _bookService.UpdateBookPriceAsync(
            request.Id,
            request.Price,
            ct);

        var updatedBook = await _bookService.GetBookByIdAsync(request.Id, ct);

        await SendAsync(updatedBook!, cancellation: ct);
    }
}
