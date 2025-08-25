namespace VitoSwimPT.Server.Models
{
    public partial class Piano
    {
        public int PianoId { get; set; }
        public string? NomePiano { get; set; }
        public string? Descrizione { get; set; }
        public string? Note { get; set; }
        public DateTime InsertDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }

        //public IList<PianoAllenamento> PianiAllenamento { get; set; }
    }
}
