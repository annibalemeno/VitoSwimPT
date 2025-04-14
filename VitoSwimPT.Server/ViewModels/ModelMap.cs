using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.ViewModels
{
    public static class ModelMap
    {

        public static EserciziVM toViewModel(this Esercizio esercizio)
        {
            return new EserciziVM(
                     esercizio.EsercizioId,
                     esercizio.Ripetizioni,
                     esercizio.Distanza,
                     esercizio.Recupero,
                     "Libero"                           //Aggiungi chiamata a repository di esercizio  TODO
                );
        }
    }
}
