using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IPianiAllenamentoRepository
    {
        Task<IEnumerable<PianoAllenamento>> GetPianiAllenamento();

        Task<PianoAllenamento> AssociaAllenamentoPiano(int pianoId, int allenamentoId);

        bool DisassociaAllenamentoPiano(int pianoId, int allenamentoId);

        Task<IEnumerable<Allenamento>> getAllenamentiAssociabiliPiano(int piano);
	
    }
    public class PianiAllenamentoRepository : IPianiAllenamentoRepository
    {
        private SwimContext _dbContext;
        public PianiAllenamentoRepository(SwimContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<PianoAllenamento>> GetPianiAllenamento()
        {
            return await _dbContext.PianiAllenamento.ToListAsync();
        }

        public async Task<PianoAllenamento> AssociaAllenamentoPiano(int pianoId, int allenamentoId)
        {
            PianoAllenamento planToAdd = new PianoAllenamento() { PianoId = pianoId, AllenamentoId = allenamentoId };
            _dbContext.PianiAllenamento.Add(planToAdd);
            await _dbContext.SaveChangesAsync();
            return planToAdd;
        }

        public bool DisassociaAllenamentoPiano(int pianoId, int allenamentoId)
        {
            bool result = false;
            PianoAllenamento planToRemove = _dbContext.PianiAllenamento.Find(pianoId, allenamentoId);
            if ((planToRemove != null))
            {
                result = true;
                _dbContext.Entry(planToRemove).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            else
            {
                result = false;
            }
            return result;

        }

        public async Task<IEnumerable<Allenamento>> getAllenamentiAssociabiliPiano(int piano)
        {
           var idAllenamentiAssociati = _dbContext.PianiAllenamento.Where(x=>x.PianoId == piano).Select(a=>a.AllenamentoId);
            var allenamentiAssociabili = await _dbContext.Allenamenti.Where(a => !idAllenamentiAssociati.Contains(a.AllenamentoId)).ToListAsync();
            return allenamentiAssociabili; 
        }
    }
}
