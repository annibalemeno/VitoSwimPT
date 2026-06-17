namespace VitoSwimPT.Server.ViewModels
{
    public class FilterEsercizi:FilterObjects
    {
        public FilterField? esercizioId { get; set; }
        public FilterField? ripetizioni { get; set; }
        public FilterField? distanza { get; set; }
        public FilterField? recupero { get; set; }
        public FilterField? stile { get; set; }
    }
}
