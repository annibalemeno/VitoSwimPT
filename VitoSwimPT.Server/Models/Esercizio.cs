namespace VitoSwimPT.Server.Models
{
    public partial class Esercizio
    {
        public int EsercizioId { get; set; }
        public int Ripetizioni { get; set; }

        public int Distanza { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public int Recupero { get; set; }

        //public string? Stile { get; set; }

        //public IList<EsercizioAllenamento> EserciziAllenamenti { get; set; }
    }
}
