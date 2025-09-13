using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Users
{
    internal sealed class  GetUser(SwimContext context)
    {
        public sealed record UserResponse(Guid Id, string FirstName, string LastName, string Email, bool EmailVerified);

        public async Task<UserResponse?> Handle(Guid userId)
        {
            UserResponse? user = await context.Utenti
                .Where(u => u.Id == userId)
                .Select(u => new UserResponse(u.Id, u.FirstName, u.LastName, u.Email, u.EmailVerified))
                .SingleOrDefaultAsync();

            return user;
        }
    }
}
