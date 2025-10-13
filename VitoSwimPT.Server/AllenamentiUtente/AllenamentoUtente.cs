using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.AllenamentiUtente
{
    public partial class AllenamentoUtente
    {
        public int AllenamentoUtenteId { get; set; }
        public int AllenamentoId { get; set; }
        public Allenamento Allenamento { get; set; }

        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime? DatePlanned { get; set; }
        public DateTime? DateDone { get; set; }
        public Guid DoneBy { get; set; }
        [ForeignKey("DoneBy")]
        public User Utente { get; set; }
    }
}
