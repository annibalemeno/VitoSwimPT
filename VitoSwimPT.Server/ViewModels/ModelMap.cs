using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.ViewModels
{
    public  class ModelMap
    {
        private readonly IAllenamentoRepository _allenamentoRepo;
        private readonly IEserciziAllenamentiRepository _esAllenamentoRepo;
        private readonly IStiliRepository _stiliRepo;
        private readonly IPianiRepository _pianiRepo;
        private readonly IPianiAllenamentoRepository _allenapianiRepo;



        public ModelMap(IAllenamentoRepository repo, IEserciziAllenamentiRepository esAllenamentoRepo, IStiliRepository stiliRepo, IPianiRepository pianiRepo, IPianiAllenamentoRepository allenapianirepo)
        {
            _allenamentoRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _esAllenamentoRepo = esAllenamentoRepo ?? throw new ArgumentNullException(nameof(esAllenamentoRepo)); 
            _stiliRepo = stiliRepo ?? throw new ArgumentNullException(nameof(stiliRepo));
            _pianiRepo = pianiRepo ?? throw new ArgumentNullException(nameof(pianiRepo));
            _allenapianiRepo = allenapianirepo ?? throw new ArgumentNullException(nameof(allenapianirepo));
        }

        public EserciziVM toViewModel( Esercizio esercizio)
        {
            var stile = _stiliRepo.GetStileById(esercizio.StileId);
            string nomeStile = stile.Result.Nome;

            return new EserciziVM(
                     esercizio.EsercizioId,
                     esercizio.Ripetizioni,
                     esercizio.Distanza,
                     esercizio.Recupero,
                     nomeStile
                );
        }

        public PianiAllenamentoVM toViewModel(Piano plan)
        {
            //var testata = pa.FirstOrDefault();
            //Task<Piano> plan = _pianiRepo.GetPianoById(testata.PianoId);
            PianiAllenamentoVM planview = new PianiAllenamentoVM();
            planview.piano = plan;
            planview.allenamenti = _allenapianiRepo.GetAllenamentiPiano(plan.PianoId).ToList();
            return planview;
        }

        public EserciziAllenamentiVM toViewModel(IEnumerable<EsercizioAllenamento> ea)
        {
            //qui appiattisco

            var testata = ea.FirstOrDefault();
            Task<Allenamento> datiAllenamento =   _allenamentoRepo.GetAllenamentoById(testata.AllenamentoId);
           
            EserciziAllenamentiVM dettaglio = new EserciziAllenamentiVM(
                testata.AllenamentoId,
                 datiAllenamento.Result.NomeAllenamento,
                datiAllenamento.Result.Note
                );

            var esTmp = _esAllenamentoRepo.GetAllEserciziAllenamento(testata.AllenamentoId);
            List<Esercizio> esercizi = esTmp.Result.ToList();

            //usa conversione viewmodel
            List<EserciziVM> esVmList = new List<EserciziVM>();
            foreach (Esercizio es in esercizi) {
                //esVmList.Add(new EserciziVM(es.EsercizioId, es.Ripetizioni, es.Distanza, es.Recupero, "Fake Style"));
                esVmList.Add(this.toViewModel(es));
            }
            //dettaglio.EserciziAssociati = esVmList;

            //es.Add (new EserciziVM( 1, 50, 4,100, "Trugeo"));
            //es.Add(new EserciziVM(2, 55, 6, 200, "Rana"));
            //es.Add(new EserciziVM(3, 60, 7, 210, "Delfino"));
            //dettaglio.EserciziAssociati = es;

            return dettaglio;
        }
    }
}
