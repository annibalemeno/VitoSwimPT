using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Users
{
    internal sealed class RevokeRefreshTokens(SwimContext context,IHttpContextAccessor httpContextAccessor)
    {
        private Guid? GetCurrentUserId()
        {
            return Guid.TryParse(
                httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid parsed) ? parsed : null;              
        }

        public async Task<bool> Handle(Guid userId)
        {
            if(userId != GetCurrentUserId())
            {
                throw new ApplicationException("You can't do this");
            }
            await context.RefreshTokens.Where(r => r.UserId == userId).ExecuteDeleteAsync();

            return true;
        }
    }
}
