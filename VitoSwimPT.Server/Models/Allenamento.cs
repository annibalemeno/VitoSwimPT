namespace VitoSwimPT.Server.Models
{
    public partial class Allenamento
    {
        public int AllenamentoId { get; set; }
        public string? NomeAllenamento { get; set; }
        public string? Note { get; set; }

        public IList<EsercizioAllenamento> EserciziAllenamenti { get; set; }
    }
}
