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


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=FGBAL051944;Database=SwimDB;Trusted_Connection=True; TrustServerCertificate=true;");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfig.GetConnectionString("SwimLocalDB"));

            //// creates db if not exists
            //this.Database.EnsureCreated();

            //optionsBuilder.UseSqlServer("Server=FGBAL051944;Database=SwimDB;Trusted_Connection=True; TrustServerCertificate=true;");
        }
    }
}
