using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace VitoSwimPT.Server.Models
{
    public class SwimContext: DbContext
    {

        //public SwimContext(DbContextOptions<SwimContext> options) : base(options) { }

        IConfiguration appConfig;

        public SwimContext(IConfiguration config)
        {
            appConfig = config;
        }

        //entities
        public DbSet<Esercizio> Esercizi { get; set; }
        public DbSet<Allenamento> Allenamenti { get; set; }
        public DbSet<Piano> Piani { get; set; }

        public DbSet<EsercizioAllenamento> EserciziAllenamenti { get; set; }

        public DbSet<PianoAllenamento> PianiAllenamento { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=FGBAL051944;Database=SwimDB;Trusted_Connection=True; TrustServerCertificate=true;");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseSqlServer(appConfig.GetConnectionString("SwimLocalDB"))
            .UseSeeding((context, _) =>
            {
            var esercizioTest = context.Set<Esercizio>().FirstOrDefault(b => b.Ripetizioni == 2);
            if (esercizioTest == null)
            {
                //create entity objects
                var eserc1 = new Esercizio() { Ripetizioni = 2, Distanza = 200, Recupero = 30, Stile = "Libero" };
                var eserc2 = new Esercizio() { Ripetizioni = 4, Distanza = 100, Recupero = 20, Stile = "Libero" };

                context.Set<Esercizio>().AddRange(eserc1, eserc2);
                context.SaveChanges();
            }

            var allenamentoTest = context.Set<Allenamento>().FirstOrDefault(b => b.NomeAllenamento == "Aerobico 1");
            if (allenamentoTest == null)
            {
                //create entity objects
                var train1 = new Allenamento() { NomeAllenamento = "Aerobico 1", Note = "Brucia 400 Calorie" };
                var train2 = new Allenamento() { NomeAllenamento = "Aerobico 2", Note = "Brucia 300 Calorie" };

                context.Set<Allenamento>().AddRange(train1, train2);
                context.SaveChanges();
            }

            var pianoTest = context.Set<Piano>().FirstOrDefault(e => e.NomePiano == "Aerobico");
            if (pianoTest == null)
            {
                var piano1 = new Piano() { NomePiano = "Aerobico", Descrizione = "Dimagrisci subito", Note = "Nota Bene 1" };
                var piano2 = new Piano() { NomePiano = "Anaerobico", Descrizione = "Indurisciti", Note = "Nota Bene 2" };

                context.Set<Piano>().AddRange(piano1, piano2);
                context.SaveChanges();
            }

            var esercizioAllenamentoTest = context.Set<EsercizioAllenamento>().FirstOrDefault(e => e.Allenamento.NomeAllenamento == "Aerobico 1");
            if (esercizioAllenamentoTest == null)
            {
                var es_all1 = new EsercizioAllenamento() { Esercizio = Esercizi.Where(x => x.Stile == "Libero").FirstOrDefault(), Allenamento = Allenamenti.Where(x => x.NomeAllenamento == "Aerobico 1").FirstOrDefault() };
                var es_all2 = new EsercizioAllenamento() { Esercizio = Esercizi.Where(x => x.Stile == "Libero").FirstOrDefault(), Allenamento = Allenamenti.Where(x => x.NomeAllenamento == "Aerobico 2").FirstOrDefault() };
                context.AddRange(es_all1, es_all2);
                context.SaveChanges();
            }

            var pianiAllenamentoTest = context.Set<PianoAllenamento>().FirstOrDefault(e => e.Allenamento.NomeAllenamento == "Aerobico 1");
            if (pianiAllenamentoTest == null)
            {
                var piano_all1 = new PianoAllenamento() { Piano = Piani.Where(p => p.NomePiano == "Aerobico").FirstOrDefault(), Allenamento = Allenamenti.Where(a => a.NomeAllenamento == "Aerobico 1").FirstOrDefault() };
                context.Add(piano_all1);
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var esercizioTest = context.Set<Esercizio>().FirstOrDefaultAsync(b => b.Ripetizioni == 2);
            if (esercizioTest == null)
            {
                //create entity objects
                var eserc1 = new Esercizio() { Ripetizioni = 2, Distanza = 200, Recupero = 30, Stile = "Libero" };
                var eserc2 = new Esercizio() { Ripetizioni = 4, Distanza = 100, Recupero = 20, Stile = "Libero" };

                context.Set<Esercizio>().AddRange(eserc1, eserc2);
                context.SaveChangesAsync();
            }

            var allenamentoTest = context.Set<Allenamento>().FirstOrDefaultAsync(b => b.NomeAllenamento == "Brucia 400 Calorie");
            if (allenamentoTest == null)
            {
                //create entity objects
                var train1 = new Allenamento() { NomeAllenamento = "Aerobico 1", Note = "Brucia 400 Calorie" };
                var train2 = new Allenamento() { NomeAllenamento = "Aerobico 2", Note = "Brucia 300 Calorie" };

                context.Set<Allenamento>().AddRange(train1, train2);
                context.SaveChangesAsync();
            }

            var esercizioAllenamentoTest = context.Set<EsercizioAllenamento>().FirstOrDefaultAsync(e => e.Allenamento.NomeAllenamento == "Aerobico 1");
            if (esercizioAllenamentoTest == null)
            {
                var es_all1 = new EsercizioAllenamento() { Esercizio = Esercizi.Where(x => x.Stile == "Libero").FirstOrDefault(), Allenamento = Allenamenti.Where(x => x.NomeAllenamento == "Aerobico 1").FirstOrDefault() };
                var es_all2 = new EsercizioAllenamento() { Esercizio = Esercizi.Where(x => x.Stile == "Libero").FirstOrDefault(), Allenamento = Allenamenti.Where(x => x.NomeAllenamento == "Aerobico 2").FirstOrDefault() };
                context.AddRange(es_all1, es_all2);
                context.SaveChangesAsync();
            }
        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EsercizioAllenamento>().HasKey(ea => new { ea.EsercizioId, ea.AllenamentoId });
            modelBuilder.Entity<PianoAllenamento>().HasKey(pa => new { pa.PianoId, pa.AllenamentoId });
        }
    }
}
