using Microsoft.EntityFrameworkCore;

namespace VitoSwimPT.Server.Users
{
    internal static class UserDbSetExtension
    {
        public static async Task<bool> Exists(this DbSet<User> users, string email)
        {
            return await users.AnyAsync(u => u.Email == email);
        }

        public static async Task<User?> GetByEmail(this DbSet<User> users, string email)
        {
            return await users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public static async Task<User?> GetByFullname(this DbSet<User> users, string fullname)
        {
            string name = fullname.Split(' ')[0];
            string surname = fullname.Split(" ")[1];

            return await users.SingleOrDefaultAsync(u => u.FirstName == name && u.LastName == surname);
        }
    }
}
