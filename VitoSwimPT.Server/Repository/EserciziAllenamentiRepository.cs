using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IEserciziAllenamentiRepository
    {
        Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamento();       //review
        Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamentoByID(int ID);
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
    }
}
