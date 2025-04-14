namespace VitoSwimPT.Server.ViewModels
{
    public class EserciziVM
    {
        public EserciziVM(int esercizioId, int ripetizioni, int distanza, int recupero, string stile)
        {
            EsercizioId = esercizioId;
            Ripetizioni = ripetizioni;
            Distanza = distanza;
            Recupero = recupero;
            Stile = stile;
        }

        public int EsercizioId { get; set; }
        public int Ripetizioni { get; set; }

        public int Distanza { get; set; }

        public int Recupero { get; set; }

        public String Stile { get; set; }

        //public int StileId { get; set; }

        //public Stile Stile { get; set; }

        //public string? Stile { get; set; }

        //public IList<EsercizioAllenamento> EserciziAllenamenti { get; set; }
    }
}
