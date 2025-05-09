using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IEserciziAllenamentiRepository
    {
        Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamento();       //review
        Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamentoByID(int ID);

        Task<IEnumerable<Esercizio>> GetAllEserciziAllenamento(int IdAllenamento);
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

        async Task<IEnumerable<Esercizio>> IEserciziAllenamentiRepository.GetAllEserciziAllenamento(int IdAllenamento)
        {
            List<Esercizio> esList = new List<Esercizio>();

            var idEsercizi = await _swimDBContext.EserciziAllenamenti.Where(ea => ea.AllenamentoId == IdAllenamento).Select(x=>x.EsercizioId).ToListAsync();
            foreach(int idEsercizio in idEsercizi)
            {
                var esercizio = await _swimDBContext.Esercizi.Where(es => es.EsercizioId == idEsercizio).FirstOrDefaultAsync();
                esList.Add(esercizio);
            }
            return esList;
        }
    }
}
