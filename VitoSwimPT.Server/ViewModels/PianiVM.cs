using System.ComponentModel.DataAnnotations.Schema;
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.ViewModels
{
    public class PianiVM
    {
        public int PianoId { get; set; }
        public string? NomePiano { get; set; }
        public string? Descrizione { get; set; }
        public string? Note { get; set; }

        public string Username { get; set; }
        //public DateTime InsertDateTime { get; set; }

        //public Guid Createdby { get; set; }

        ////public DateTime UpdateDateTime { get; set; }

        //[ForeignKey("Createdby")]
        //public User Utente { get; set; }
    }
}
