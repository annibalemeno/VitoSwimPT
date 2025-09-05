using Microsoft.EntityFrameworkCore;
using System;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Users
{
    internal sealed class VerifyEmail(SwimContext context)
    {
        public async Task<bool> Handle(Guid tokenId)
        {
            EmailVerificationToken? token = await context.EmailVerificationTokens
                .Include(e => e.Utente)
                .FirstOrDefaultAsync(e => e.Id == tokenId);

            if (token is null || token.ExpiresOnUtc < DateTime.UtcNow || token.Utente.EmailVerified)
            {
                return false;
            }

            token.Utente.EmailVerified = true;

            context.EmailVerificationTokens.Remove(token);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
