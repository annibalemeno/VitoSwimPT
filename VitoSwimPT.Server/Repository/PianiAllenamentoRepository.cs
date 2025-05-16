using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IPianiAllenamentoRepository
    {
        Task<IEnumerable<PianoAllenamento>> GetPianiAllenamento();

        Task<PianoAllenamento> AssociaAllenamentoPiano(int idPiano, int idAllenamento);

        bool DisassociaAllenamentoPiano(int idPiano, int idAllenamento);

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

        public async Task<PianoAllenamento> AssociaAllenamentoPiano(int idPiano, int idAllenamento)
        {
            PianoAllenamento planToAdd = new PianoAllenamento() { PianoId = idPiano, AllenamentoId = idAllenamento };
            _dbContext.PianiAllenamento.Add(planToAdd);
            await _dbContext.SaveChangesAsync();
            return planToAdd;
        }

        public bool DisassociaAllenamentoPiano(int idPiano, int idAllenamento)
        {
            bool result = false;
            PianoAllenamento planToRemove = _dbContext.PianiAllenamento.Find(idPiano, idAllenamento);
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
           var idAllenamentiAssociati = _dbContext.PianiAllenamento.Where(x=>x.PianoId == piano).Select(a=>a.AllenamentoId).ToList();
            var allenamentiAssociabili = await _dbContext.Allenamenti.Where(a => !idAllenamentiAssociati.Contains(a.AllenamentoId)).ToListAsync();
            return allenamentiAssociabili; 
        }
    }
}
