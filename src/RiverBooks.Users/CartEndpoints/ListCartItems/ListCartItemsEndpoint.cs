using System.Security.Claims;
using Ardalis.Result;
using FastEndpoints;
using MediatR;
using RiverBooks.Users.UseCases.Queries.ListCartItems;

namespace RiverBooks.Users.CartEndpoints.ListCartItems;

internal class ListCartItemsEndpoint(ISender mediator)
    : EndpointWithoutRequest<CartResponse>
{
    private readonly ISender _mediator = mediator;

    public override void Configure()
    {
        Get("/api/cart");
        Claims(ClaimTypes.Email);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new ListCartItemsQuery(User.FindFirstValue(ClaimTypes.Email)!);
        var result = await _mediator.Send(query, ct);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendAsync(result.Value, cancellation: ct);
    }
}
