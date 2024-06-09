using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, Guid, BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context)
        : base(context) { }

    public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(Guid userID, int refreshTokenTTL)
    {
        List<RefreshToken> tokens = await Query()
            .AsNoTracking()
            .Where(
                r =>
                    r.UserId == userID
                    && r.Revoked == null
                    && r.Expires >= DateTime.UtcNow
                    && r.CreatedDate.AddDays(refreshTokenTTL) <= DateTime.UtcNow
            )
            .ToListAsync();

        return tokens;
    }
}