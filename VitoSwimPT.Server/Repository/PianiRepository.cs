using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IPianiRepository
    {
        Task<IEnumerable<Piano>> GetAllPiani();

        Task<Piano> GetPianoById(int pianoId);

        bool DeletePiano(int Id);

        Task<Piano> UpdatePiano(Piano plan);

        Task<Piano> InsertPiano(Piano plan);
    }
    

        public class PianiRepository:IPianiRepository
    {
        private readonly SwimContext _swimDBContext;

        public PianiRepository(SwimContext context)
        {
            _swimDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Piano>> GetAllPiani()
        {
            return await _swimDBContext.Piani.ToListAsync();
        }

        public bool DeletePiano(int Id)
        {
            bool result = false;
            var training = _swimDBContext.Piani.Find(Id);
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

        public async Task<Piano> UpdatePiano(Piano plan)
        {
            _swimDBContext.Entry(plan).State = EntityState.Modified;
            await _swimDBContext.SaveChangesAsync();
            return plan;
        }

        public async Task<Piano> InsertPiano(Piano plan)
        {
            _swimDBContext.Piani.Add(plan);
            await _swimDBContext.SaveChangesAsync();
            return plan;
        }

        public async Task<Piano> GetPianoById(int pianoId)
        {
            return await _swimDBContext.Piani.FindAsync(pianoId);
        }
    }
}
