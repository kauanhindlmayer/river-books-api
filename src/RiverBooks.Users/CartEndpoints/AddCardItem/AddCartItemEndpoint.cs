using System.Security.Claims;
using Ardalis.Result;
using FastEndpoints;
using MediatR;
using RiverBooks.Users.UseCases.Commands.AddCartItem;

namespace RiverBooks.Users.CartEndpoints.AddCardItem;

public class AddCartItemEndpoint(ISender mediator) : Endpoint<AddCardItemRequest>
{
    private readonly ISender _mediator = mediator;

    public override void Configure()
    {
        Post("/api/cart");
        Claims(ClaimTypes.Email);
    }

    public override async Task HandleAsync(AddCardItemRequest request, CancellationToken ct)
    {
        var emailAddress = User.FindFirstValue(ClaimTypes.Email)!;
        var command = new AddCartItemCommand(emailAddress, request.BookId, request.Quantity);

        var result = await _mediator.Send(command, ct);
        if (result.Status == ResultStatus.Unauthorized)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        await SendOkAsync(ct);
    }
}
