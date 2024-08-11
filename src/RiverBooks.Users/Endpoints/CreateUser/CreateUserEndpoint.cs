using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users.Endpoints.CreateUser;

public class CreateUserEndpoint(UserManager<ApplicationUser> userManager)
    : Endpoint<CreateUserRequest>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {
        var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
        var result = await _userManager.CreateAsync(user, request.Password);
        await SendOkAsync(ct);
    }
}