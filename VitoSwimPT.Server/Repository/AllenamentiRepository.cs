using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IAllenamentoRepository
    {
        Task<IEnumerable<Allenamento>> GetAllenamenti();
        Task<Allenamento> InsertAllenamento(Allenamento allenamento);
    }

    public class AllenamentiRepository : IAllenamentoRepository
    {
        private readonly SwimContext _swimDBContext;

        public AllenamentiRepository(SwimContext context)
        {
            _swimDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Allenamento>> GetAllenamenti()
        {
            return await _swimDBContext.Allenamenti.ToListAsync();
        }

        public async Task<Allenamento> InsertAllenamento(Allenamento train)
        {
            _swimDBContext.Allenamenti.Add(train);
            await _swimDBContext.SaveChangesAsync();
            return train;
        }
    }
}
