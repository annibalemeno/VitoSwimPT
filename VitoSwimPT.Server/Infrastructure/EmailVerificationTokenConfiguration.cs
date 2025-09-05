using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.Infrastructure
{
    internal sealed class EmailVerificationTokenConfiguration : IEntityTypeConfiguration<EmailVerificationToken>
    {
        public void Configure(EntityTypeBuilder<EmailVerificationToken> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Utente).WithMany().HasForeignKey(e => e.UserId);
        }
    }
}
