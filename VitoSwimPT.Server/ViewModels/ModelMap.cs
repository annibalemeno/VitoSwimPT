using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.ViewModels
{
    public  class ModelMap
    {

        public   EserciziVM toViewModel( Esercizio esercizio)
        {

            return new EserciziVM(
                     esercizio.EsercizioId,
                     esercizio.Ripetizioni,
                     esercizio.Distanza,
                     esercizio.Recupero,
                     String.Empty
                );

            //TO DO
        }
    }
}
