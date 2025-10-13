using System.ComponentModel.DataAnnotations.Schema;
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.Models
{
    public partial class Piano
    {
        public int PianoId { get; set; }
        public string? NomePiano { get; set; }
        public string? Descrizione { get; set; }
        public string? Note { get; set; }
        public DateTime InsertDateTime { get; set; }

        public Guid Createdby { get; set; }
        public DateTime UpdateDateTime { get; set; }
        [ForeignKey("Createdby")]
        public User Utente { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //public IList<PianoAllenamento> PianiAllenamento { get; set; }
    }
}
