using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Xml;
using VitoSwimPT.Server.AllenamentiUtente;
using VitoSwimPT.Server.Users;

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

        public DbSet<User> Utenti { get; set; }

        public DbSet<EmailVerificationToken> EmailVerificationTokens { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Stile> Stili {  get; set; }
        public DbSet<Esercizio> Esercizi { get; set; }
        public DbSet<Allenamento> Allenamenti { get; set; }
        public DbSet<Piano> Piani { get; set; }

        public DbSet<EsercizioAllenamento> EserciziAllenamenti { get; set; }

        public DbSet<PianoAllenamento> PianiAllenamento { get; set; }

        public DbSet<AllenamentoUtente> AllenamentiUtente { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=FGBAL051944;Database=SwimDB;Trusted_Connection=True; TrustServerCertificate=true;");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseSqlServer(appConfig.GetConnectionString("SwimLocalDB"))
            .UseSeeding((context, _) =>
            {
                var stiliTest = context.Set<Stile>().FirstOrDefault(s => s.Sigla == "SL");
                if (stiliTest == null)
                {
                    //create entity objects
                    var sl = new Stile() { Nome = "Libero", Sigla = "SL" };
                    var dx = new Stile() { Nome = "Dorso", Sigla = "DX" };
                    var rn = new Stile() { Nome = "Rana", Sigla = "RN" };
                    var df = new Stile() { Nome = "Delfino", Sigla = "DF" };
                    var fa = new Stile() { Nome = "Farfalla", Sigla = "FA" };
                    var mx = new Stile() { Nome = "Misti", Sigla = "MX" };

                    context.Set<Stile>().AddRange(sl, dx, rn, df, fa, mx);
                    context.SaveChanges();
                }


                var esercizioTest = context.Set<Esercizio>().FirstOrDefault(b => b.Ripetizioni == 2);
                if (esercizioTest == null)
                {
                    //create entity objects
                    var eserc1 = new Esercizio()
                    {
                        Ripetizioni = 2,
                        Distanza = 200,
                        Recupero = 30,
                       StileId = Stili.FirstOrDefault().StileId
                    };
                    var eserc2 = new Esercizio()
                    {
                        Ripetizioni = 4,
                        Distanza = 100,
                        Recupero = 20,
                        StileId = Stili.FirstOrDefault().StileId
                    };

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
                    var piano1 = new Piano() { NomePiano = "Aerobico", Descrizione = "Dimagrisci subito", Note = "Nota Bene 1", Createdby = Utenti.FirstOrDefault().Id };
                    var piano2 = new Piano() { NomePiano = "Anaerobico", Descrizione = "Indurisciti", Note = "Nota Bene 2", Createdby = Utenti.FirstOrDefault().Id };

                    context.Set<Piano>().AddRange(piano1, piano2);
                    context.SaveChanges();
                }
                //var esercizioAllenamentoTest = context.Set<EsercizioAllenamento>().FirstOrDefault(e => e.Allenamento.NomeAllenamento == "Aerobico 1");
                //if (esercizioAllenamentoTest == null)
                //{
                //    var es_all1 = new EsercizioAllenamento()
                //    {
                //        Esercizio = Esercizi.Where(x => x.Ripetizioni == 2).FirstOrDefault(),   //Esercizi.Where(x => x.Stile == "Libero").FirstOrDefault(), 
                //        Allenamento = Allenamenti.Where(x => x.NomeAllenamento == "Aerobico 1").FirstOrDefault()
                //    };
                //    var es_all2 = new EsercizioAllenamento()
                //    {
                //        Esercizio = Esercizi.Where(x => x.Ripetizioni == 2).FirstOrDefault(),   //Esercizi.Where(x => x.Stile == "Libero").FirstOrDefault(), 
                //        Allenamento = Allenamenti.Where(x => x.NomeAllenamento == "Aerobico 2").FirstOrDefault()
                //    };
                //    context.AddRange(es_all1, es_all2);
                //    context.SaveChanges();
                //}

                //var pianiAllenamentoTest = context.Set<PianoAllenamento>().FirstOrDefault(e => e.Allenamento.NomeAllenamento == "Aerobico 1");

                var pianiAllenamentoTest = context.Set<PianoAllenamento>().FirstOrDefault();
                if (pianiAllenamentoTest == null)
                {
                    //var piano_all1 = new PianoAllenamento() { Piano = Piani.Where(p => p.NomePiano == "Aerobico").FirstOrDefault(), Allenamento = Allenamenti.Where(a => a.NomeAllenamento == "Aerobico 1").FirstOrDefault() };
                    int piano = Piani.FirstOrDefault().PianoId;
                    int allenamento = Allenamenti.FirstOrDefault().AllenamentoId;
                    var piano_all1 = new PianoAllenamento() { PianoId = piano, AllenamentoId = allenamento };
                    context.Add(piano_all1);
                    context.SaveChanges();
                }

                var allenamentiUtenteTest = context.Set<AllenamentoUtente>().FirstOrDefault();
                if (allenamentiUtenteTest == null)
                {
                    var allUtenteSeed01 = new AllenamentoUtente();
                    allUtenteSeed01.Allenamento = Allenamenti.FirstOrDefault();
                    allUtenteSeed01.DatePlanned = DateTime.Today;
                    allUtenteSeed01.DateDone = DateTime.Today.AddMonths(1);
                    allUtenteSeed01.Utente = Utenti.FirstOrDefault();
                    context.Add(allUtenteSeed01);
                    context.SaveChanges();

                    var allUtenteSeed02 = new AllenamentoUtente();
                    allUtenteSeed02.Allenamento = Allenamenti.OrderBy(x => x.InsertDateTime).LastOrDefault();
                    allUtenteSeed02.DatePlanned = DateTime.Today.AddMonths(1);
                    allUtenteSeed02.DateDone = DateTime.Today.AddMonths(2);
                    allUtenteSeed02.Utente = Utenti.OrderBy(x => x.Email).FirstOrDefault();
                    context.Add(allUtenteSeed02);
                    context.SaveChanges();
                }
            });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EsercizioAllenamento>().HasKey(ea => new { ea.EsercizioId, ea.AllenamentoId });
            modelBuilder.Entity<PianoAllenamento>().HasKey(pa => new { pa.PianoId, pa.AllenamentoId });
            modelBuilder.Entity<Stile>().Property(x => x.Sigla).HasMaxLength(2);

            modelBuilder.Entity<AllenamentoUtente>().Property(b => b.InsertDateTime).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<AllenamentoUtente>().Property(b => b.UpdateDateTime).HasDefaultValueSql("getdate()");

        }
    }
}
