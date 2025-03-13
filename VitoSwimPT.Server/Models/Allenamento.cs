namespace VitoSwimPT.Server.Models
{
    public partial class Allenamento
    {
        public int AllenamentoId { get; set; }
        public int Ripetizioni { get; set; }

        public int Distanza { get; set; }

        public int Recupero { get; set; }

        public string? Stile { get; set; }
    }
}
