namespace VitoSwimPT.Server.Models
{
    public partial class Stile
    {
        public int StileId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public DateTime InsertDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
