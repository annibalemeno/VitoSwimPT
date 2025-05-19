using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Repository
{
    public interface IEserciziAllenamentiRepository
    {
        Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamento();       //review
        Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamentoByID(int ID);

        Task<IEnumerable<Esercizio>> GetAllEserciziAllenamento(int IdAllenamento);

        Task<IEnumerable<Esercizio>> GetEserciziAssociabiliAllenamento(int idAllenamento);
        bool DisassociaEsercizioAllenamento(int allenamentoId, int esercizioId);

        Task<EsercizioAllenamento> AssociaEsercizioAllenamento(int allenamentoId, int esercizioId);
    }

    public class EserciziAllenamentiRepository : IEserciziAllenamentiRepository
    {
        private readonly SwimContext _swimDBContext;

        public EserciziAllenamentiRepository(SwimContext context)
        {
            _swimDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamento()
        {
            return await _swimDBContext.EserciziAllenamenti.ToListAsync();
        }

        public async Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamentoByID(int ID)
        {

            //var query = db.Categories.Where(c => c.Category_ID == cat_id).SelectMany(c => Articles);
            return await _swimDBContext.EserciziAllenamenti.Where(ea => ea.AllenamentoId == ID).ToListAsync();
            // return await _swimDBContext.EserciziAllenamenti.FindAsync(ID);
        }

        public async Task<IEnumerable<Esercizio>> GetAllEserciziAllenamento(int IdAllenamento)
        {
            var idEserciziAssociati = _swimDBContext.EserciziAllenamenti.Where(ea => ea.AllenamentoId == IdAllenamento).Select(x => x.EsercizioId);
            var esercizi = await _swimDBContext.Esercizi.Where(es => idEserciziAssociati.Contains(es.EsercizioId)).ToListAsync();
            return esercizi;

            //List<Esercizio> esList = new List<Esercizio>();

            //var idEsercizi = await _swimDBContext.EserciziAllenamenti.Where(ea => ea.AllenamentoId == IdAllenamento).Select(x => x.EsercizioId).ToListAsync();
            //foreach (int idEsercizio in idEsercizi)
            //{
            //    var esercizio = await _swimDBContext.Esercizi.Where(es => es.EsercizioId == idEsercizio).FirstOrDefaultAsync();
            //    esList.Add(esercizio);
            //}
            //return esList;
        }

        public async Task<IEnumerable<Esercizio>> GetEserciziAssociabiliAllenamento(int idAllenamento)
        {
            var idEserciziAssociati =  _swimDBContext.EserciziAllenamenti.Where(ea => ea.AllenamentoId == idAllenamento).Select(x => x.EsercizioId);
            var eserciziAssociabili = await _swimDBContext.Esercizi.Where(es => !idEserciziAssociati.Contains(es.EsercizioId)).ToListAsync();

           return eserciziAssociabili;
        }

        public bool DisassociaEsercizioAllenamento(int allenamentoId, int esercizioId)
        {
            bool result = false;
            var es_all = _swimDBContext.EserciziAllenamenti.Find(esercizioId, allenamentoId);
            if (es_all != null)
            {
                _swimDBContext.Entry(es_all).State = EntityState.Deleted;
                _swimDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<EsercizioAllenamento> AssociaEsercizioAllenamento(int allenamentoId, int esercizioId)
        {
            EsercizioAllenamento esallToAdd = new EsercizioAllenamento() { AllenamentoId = allenamentoId, EsercizioId = esercizioId };
            _swimDBContext.EserciziAllenamenti.Add(esallToAdd);
            await _swimDBContext.SaveChangesAsync();
            return esallToAdd;
        }
    }
}
