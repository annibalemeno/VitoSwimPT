using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IEserciziAllenamentiRepository
    {
        Task<IEnumerable<EsercizioAllenamento>> GetEserciziAllenamento();
        Task<EsercizioAllenamento> GetEsercizioAllenamentoByID(int ID);
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

        public async Task<EsercizioAllenamento> GetEsercizioAllenamentoByID(int ID)
        {
            return await _swimDBContext.EserciziAllenamenti.FindAsync(ID);
        }
    }
}
