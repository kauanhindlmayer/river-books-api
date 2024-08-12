using Ardalis.Result;
using MediatR;
using RiverBooks.Users.CartEndpoints.ListCartItems;
using RiverBooks.Users.Data;

namespace RiverBooks.Users.UseCases.Queries.ListCartItems;

internal class ListCartItemsQueryHandler(IApplicationUserRepository userRepository)
    : IRequestHandler<ListCartItemsQuery, Result<CartResponse>>
{
    private readonly IApplicationUserRepository _userRepository = userRepository;

    public async Task<Result<CartResponse>> Handle(
        ListCartItemsQuery request,
        CancellationToken ct)
    {
        var user = await _userRepository.FindUserWithCardByEmailAsync(request.EmailAddress, ct);

        if (user is null)
        {
            return Result<CartResponse>.NotFound();
        }

        return Result<CartResponse>.Success(CartResponse.FromDomain([.. user.CartItems]));
    }
}