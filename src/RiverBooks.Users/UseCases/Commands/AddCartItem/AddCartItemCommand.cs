using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCases.Commands.AddCartItem;

public record AddCartItemCommand(
    string EmailAddress,
    Guid BookId,
    int Quantity) : IRequest<Result>;
