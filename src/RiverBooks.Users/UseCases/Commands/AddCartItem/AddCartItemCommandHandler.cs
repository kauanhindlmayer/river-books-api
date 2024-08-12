using Ardalis.Result;
using MediatR;
using RiverBooks.Users.Data;

namespace RiverBooks.Users.UseCases.Commands.AddCartItem;

public class AddCartItemCommandHandler(IApplicationUserRepository userRepository)
    : IRequestHandler<AddCartItemCommand, Result>
{
    private readonly IApplicationUserRepository _userRepository = userRepository;

    public async Task<Result> Handle(AddCartItemCommand request, CancellationToken ct)
    {
        var user = await _userRepository.FindUserWithCardByEmailAsync(request.EmailAddress, ct);
        if (user is null)
        {
            return Result.Unauthorized();
        }

        // TODO: Get book details from book module
        var newCartItem = new CartItem(
            bookId: request.BookId,
            description: "Book description",
            quantity: request.Quantity,
            price: 1.00m);

        user.AddCartItem(newCartItem);
        await _userRepository.SaveChangesAsync(ct);
        return Result.Success();
    }
}
