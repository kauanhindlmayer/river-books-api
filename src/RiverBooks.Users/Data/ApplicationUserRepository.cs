using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Users.Data;

public class ApplicationUserRepository(UsersDbContext dbContext) : IApplicationUserRepository
{
    private readonly UsersDbContext _dbContext = dbContext;

    public async Task<ApplicationUser?> FindUserWithCardByEmailAsync(
        string emailAddress,
        CancellationToken ct = default)
    {
        return await _dbContext.Users
            .Include(u => u.CartItems)
            .SingleOrDefaultAsync(u => u.Email == emailAddress, ct);
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _dbContext.SaveChangesAsync(ct);
    }
}