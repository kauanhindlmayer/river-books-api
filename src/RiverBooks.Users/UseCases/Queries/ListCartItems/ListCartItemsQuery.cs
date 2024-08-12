using Ardalis.Result;
using MediatR;
using RiverBooks.Users.CartEndpoints.ListCartItems;

namespace RiverBooks.Users.UseCases.Queries.ListCartItems;

public record ListCartItemsQuery(string EmailAddress) : IRequest<Result<CartResponse>>;