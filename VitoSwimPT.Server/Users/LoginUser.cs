using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Infrastructure;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Users
{
    internal sealed class LoginUser(SwimContext context, PasswordHasher passwordHasher, TokenProvider tokenProvider)
    {
        public sealed record Request(string Email, string Password);
        public async Task<JsonResult> Handle(Request request)
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

            var testUser = new User()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = "Annibale",
                LastName = "Menolascina",
                PasswordHash = request.Password,
                EmailVerified = false
            };
            string token = tokenProvider.Create(testUser);

            return new JsonResult(token);
        }
    }
}
