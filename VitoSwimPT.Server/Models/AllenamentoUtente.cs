namespace VitoSwimPT.Server.Models
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

    }
}
