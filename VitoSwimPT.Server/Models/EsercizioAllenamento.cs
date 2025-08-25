namespace VitoSwimPT.Server.Models
{
    public partial class EsercizioAllenamento
    {
        public int EsercizioId { get; set; }
        //public Esercizio Esercizio { get; set; }
        public int AllenamentoId { get; set; }
        //public Allenamento Allenamento { get; set; }
        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

    }
}
