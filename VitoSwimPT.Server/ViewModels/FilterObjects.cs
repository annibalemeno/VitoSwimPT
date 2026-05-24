namespace VitoSwimPT.Server.ViewModels
{
    public class FilterObjects
    {
        public int skip { get; set; }
        public int take { get; set; }
        public FilterField? esercizioId { get; set; }
        public FilterField? ripetizioni { get; set; }
        public FilterField? distanza { get; set; }
        public FilterField? recupero { get; set; }
        public FilterField? stile { get; set; }
    }

    public class FilterField
    {
        public string? value { get; set; }
        public string matchMode { get; set; }
    }
}
