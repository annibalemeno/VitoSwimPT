using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.ViewModels
{
    public class EserciziAllenamentiVM
    {

        public EserciziAllenamentiVM() { }
        public EserciziAllenamentiVM(int allenamentoId, string nomeAllenamento, string note)
        {
            this.allenamentoId = allenamentoId;
            this.nomeAllenamento = nomeAllenamento;
            this.note = note;
        }

        public int allenamentoId { get; set; }
        public String nomeAllenamento { get; set; }

        public String note { get; set; }
        public List <EserciziVM>EserciziAssociati { get; set; } 

    }
}


