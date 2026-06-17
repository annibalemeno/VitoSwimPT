using Microsoft.Identity.Client;

namespace VitoSwimPT.Server.ViewModels
{
    public class FilterPiani:FilterObjects
    {
        public string usermail { get; set; } = "Name";

        public FilterField? pianoId { get; set; }

        public FilterField? nomePiano { get; set; }

        public FilterField? descrizione { get; set; }

        public FilterField? note { get; set; }

    }
}
