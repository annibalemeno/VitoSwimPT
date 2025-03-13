using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace VitoSwimPT.Server.Models
{
    public class SwimContext: DbContext
    {

        //entities
        public DbSet<Allenamento> Allenamenti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FGBAL051944;Database=SwimDB;Trusted_Connection=True; TrustServerCertificate=true;");
        }
    }
}
