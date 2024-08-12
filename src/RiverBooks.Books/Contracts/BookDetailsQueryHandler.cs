using Ardalis.Result;
using MediatR;

namespace RiverBooks.Books.Contracts;

internal class BookDetailsQueryHandler(IBookService bookService)
    : IRequestHandler<BookDetailsQuery, Result<BookDetailsResponse>>
{
    private readonly IBookService _bookService = bookService;

    public async Task<Result<BookDetailsResponse>> Handle(BookDetailsQuery request, CancellationToken ct)
    {
        var book = await _bookService.GetBookByIdAsync(request.BookId, ct);
        return book is null
            ? Result.NotFound()
            : BookDetailsResponse.FromDomain(book);
    }
}