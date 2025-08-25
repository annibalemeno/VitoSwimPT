namespace VitoSwimPT.Server.Models
{
    public partial class Allenamento
    {
        public int AllenamentoId { get; set; }
        public string? NomeAllenamento { get; set; }
        public string? Note { get; set; }
        public DateTime InsertDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }

        //public IList<EsercizioAllenamento> EserciziAllenamenti { get; set; }      //TODO

        //public IList<PianoAllenamento> PianiAllenamento { get; set; }             //TODO 
    }
}
