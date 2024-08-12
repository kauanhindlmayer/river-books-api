using System.Security.Claims;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users.Endpoints.Login;

public class LoginEndpoint(UserManager<ApplicationUser> userManager) : Endpoint<LoginRequest>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public override void Configure()
    {
        Post("/api/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        var jwtToken = JwtBearer.CreateToken(options =>
        {
            options.SigningKey = Config["Auth:JwtSecret"]!;
            options.User.Claims.Add(new Claim(ClaimTypes.Email, user.Email!));
            options.ExpireAt = DateTime.UtcNow.AddDays(1);
        });

        await SendAsync(new
        {
            UserName = request.Email,
            Token = jwtToken
        }, cancellation: ct);
    }
}