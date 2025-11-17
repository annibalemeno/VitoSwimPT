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

    //public class EsercizioAllenamentoConfig : BaseEntityTypeConfiguration<EsercizioAllenamento>
    //{
    //    public override void Configure(EntityTypeBuilder<EsercizioAllenamento> builder)
    //    {
    //        //modelBuilder.Entity<EsercizioAllenamento>().HasKey(ea => new { ea.EsercizioId, ea.AllenamentoId });
    //        builder.HasKey(ea => new { ea.EsercizioId, ea.AllenamentoId });
    //        base.Configure(builder);
    //    }
    //}
}
