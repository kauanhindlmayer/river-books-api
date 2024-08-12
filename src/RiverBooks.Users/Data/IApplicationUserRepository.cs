namespace RiverBooks.Users.Data;

public interface IApplicationUserRepository
{
    Task<ApplicationUser?> FindUserWithCardByEmailAsync(string emailAddress, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}