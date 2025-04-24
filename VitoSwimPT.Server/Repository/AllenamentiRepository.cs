using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IAllenamentoRepository
    {
        Task<IEnumerable<Allenamento>> GetAllenamenti();

        Task<Allenamento> GetAllenamentoById(int ID);
        Task<Allenamento> InsertAllenamento(Allenamento allenamento);

        bool DeleteAllenamento(int Id);

        Task<Allenamento> UpdateAllenamento(Allenamento training);
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

        public async Task<Allenamento> GetAllenamentoById(int ID)
        {
            return await _swimDBContext.Allenamenti.FindAsync(ID); //TODO Robustezza
        }

        public async Task<Allenamento> InsertAllenamento(Allenamento train)
        {
            _swimDBContext.Allenamenti.Add(train);
            await _swimDBContext.SaveChangesAsync();
            return train;
        }

        public bool DeleteAllenamento(int Id)
        {
            bool result = false;
            var training = _swimDBContext.Allenamenti.Find(Id);
            if (training != null)
            {
                _swimDBContext.Entry(training).State = EntityState.Deleted;
                _swimDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<Allenamento> UpdateAllenamento(Allenamento training)
        {
            _swimDBContext.Entry(training).State = EntityState.Modified;
            await _swimDBContext.SaveChangesAsync();
            return training;
        }
    }
}
