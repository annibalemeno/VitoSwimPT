using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.ViewModels
{
    public  class ModelMap
    {
        //TO DO

        public EserciziVM toViewModel( Esercizio esercizio)
        {

            return new EserciziVM(
                     esercizio.EsercizioId,
                     esercizio.Ripetizioni,
                     esercizio.Distanza,
                     esercizio.Recupero,
                     "Libero"
                );
        }

        public EserciziAllenamentiVM toViewModel(EsercizioAllenamento ea)
        {
            return new EserciziAllenamentiVM(
                ea.AllenamentoId,
                "Fakename",
                "FakeNotes"
                );
        }
    }
}
