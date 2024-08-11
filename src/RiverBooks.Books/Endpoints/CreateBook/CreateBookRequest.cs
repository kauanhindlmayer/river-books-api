namespace RiverBooks.Books.Endpoints.CreateBook;

internal record CreateBookRequest(
    Guid? Id,
    string Title,
    string Author,
    decimal Price);
