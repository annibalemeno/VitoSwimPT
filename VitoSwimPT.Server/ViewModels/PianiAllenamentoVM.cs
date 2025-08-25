using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.ViewModels
{
    public class PianiAllenamentoVM
    {
        public Piano piano {  get; set; }

        public List<Allenamento> allenamenti { get; set; }
    }
}
