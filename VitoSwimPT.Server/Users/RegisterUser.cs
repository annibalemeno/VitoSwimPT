using System;
using VitoSwimPT.Server.Infrastructure;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Users
{
    internal sealed  class RegisterUser(SwimContext context, PasswordHasher passwordHasher)
    {
        public sealed record Request(string Email, string FirstName, string LastName, string Password);

        public async Task<User> Handle(Request request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = passwordHasher.Hash(request.Password)
            };
        

        context.Utenti.Add(user);

        DateTime utcNow = DateTime.UtcNow;
        var verificationToken = new EmailVerificationToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            CreatedOnUtc = utcNow,
            ExpiresOnUtc = utcNow.AddDays(1)
        };
            return user;
        }
    }
}
