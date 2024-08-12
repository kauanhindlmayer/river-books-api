using Ardalis.Result;
using MediatR;
using RiverBooks.Books.Contracts;
using RiverBooks.Users.Data;

namespace RiverBooks.Users.UseCases.Commands.AddCartItem;

public class AddCartItemCommandHandler(IApplicationUserRepository userRepository, ISender mediator)
    : IRequestHandler<AddCartItemCommand, Result>
{
    private readonly IApplicationUserRepository _userRepository = userRepository;
    private readonly ISender _mediator = mediator;

    public async Task<Result> Handle(AddCartItemCommand request, CancellationToken ct)
    {
        var user = await _userRepository.FindUserWithCardByEmailAsync(request.EmailAddress, ct);
        if (user is null)
        {
            return Result.Unauthorized();
        }

        var query = new BookDetailsQuery(request.BookId);
        var result = await _mediator.Send(query, ct);

        if (result.Status == ResultStatus.NotFound)
        {
            return Result.NotFound();
        }

        var newCartItem = new CartItem(
            bookId: request.BookId,
            description: result.Value.Description,
            quantity: request.Quantity,
            price: result.Value.Price);

        user.AddCartItem(newCartItem);
        await _userRepository.SaveChangesAsync(ct);
        return Result.Success();
    }
}
