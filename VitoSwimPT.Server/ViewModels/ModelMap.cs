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

        public EserciziAllenamentiVM toViewModel(IEnumerable<EsercizioAllenamento> ea)
        {
            //qui appiattisco

            var testata = ea.FirstOrDefault();

            EserciziAllenamentiVM dettaglio = new EserciziAllenamentiVM(
                testata.AllenamentoId,
                "Fakename",
                "FakeNotes"
                );

            List<EserciziVM> es = new List<EserciziVM>();
            es.Add (new EserciziVM( 1, 50, 4,100, "Trugeo"));
            es.Add(new EserciziVM(2, 55, 6, 200, "Rana"));
            es.Add(new EserciziVM(3, 60, 7, 210, "Delfino"));
            dettaglio.EserciziAssociati = es;

            return dettaglio;
        }
    }
}
