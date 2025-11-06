using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Infrastructure;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Users
{
    internal sealed class LoginUserWithRefreshToken(SwimContext context, TokenProvider tokenProvider)
    {
        public sealed record Request(string RefreshToken);
        public sealed record Response(string AccessToken, string RefreshToken);

        public async Task<Response> Handle(Request request)
        {
            RefreshToken? refreshToken = await context.RefreshTokens.Include(r => r.User).FirstOrDefaultAsync(r => r.Token == request.RefreshToken);           

            if(refreshToken is null || refreshToken.ExpiresOnUTC < DateTime.UtcNow)
            {
                throw new Exception("The refresh token has expired");
            }
            else
            {
                RefreshToken? lastRTforUser = await context.RefreshTokens.Where(r => r.UserId == refreshToken.UserId).OrderByDescending(x => x.ExpiresOnUTC).FirstOrDefaultAsync();
                if(lastRTforUser.Id != refreshToken.Id)
                {
                    //security issue: we are not using last user refresh token
                    throw new Exception("we are not using last user refresh token: should revoke and logout");
                }
                
            }

            string accessToken = tokenProvider.Create(refreshToken.User);

            refreshToken.Token = tokenProvider.GenerateRefreshToken();
            refreshToken.ExpiresOnUTC = DateTime.UtcNow.AddDays(7);

            await context.SaveChangesAsync();

            return new Response(accessToken, refreshToken.Token);
        }
    }
}
