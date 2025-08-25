namespace VitoSwimPT.Server.Models
{
    public partial class PianoAllenamento
    {
        public int PianoId { get; set; }

        //public Piano Piano { get; set; }
        public int AllenamentoId { get; set; }
        //public Allenamento Allenamento { get; set; }
        public DateTime InsertDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }

    }
}
