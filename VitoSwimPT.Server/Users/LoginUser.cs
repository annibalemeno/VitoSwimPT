using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Infrastructure;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Users
{
    internal sealed class LoginUser(SwimContext context, PasswordHasher passwordHasher, TokenProvider tokenProvider)
    {
        public sealed record Request(string Email, string Password);

        public sealed record Response(string AccessToken, string RefreshToken);
        public async Task<Response> Handle(Request request)
        {
            try
            {
                User? user = await context.Utenti.GetByEmail(request.Email);

                if (user is null || !user.EmailVerified)
                {
                    throw new Exception("The user was not found");
                }


                //string hashedpassword = passwordHasher.Hash(request.Password);
                bool verified = passwordHasher.Verify(request.Password, user.PasswordHash);

                if (!verified)
                {
                    throw new Exception("The password is incorrect");
                }

                string token = tokenProvider.Create(user);

                var refreshToken = new RefreshToken
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    Token = tokenProvider.GenerateRefreshToken(),
                    ExpiresOnUTC = DateTime.UtcNow.AddDays(7)
                };

                context.RefreshTokens.Add(refreshToken);

                await context.SaveChangesAsync();

                return new Response(token, refreshToken.Token);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
