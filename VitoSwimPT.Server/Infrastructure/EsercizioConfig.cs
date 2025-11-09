using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Numerics;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Infrastructure
{
    public class EsercizioConfig: BaseEntityTypeConfiguration<Esercizio>
    {
        public override void Configure(EntityTypeBuilder<Esercizio> builder)
        {
            base.Configure(builder);
        }
    }
}
