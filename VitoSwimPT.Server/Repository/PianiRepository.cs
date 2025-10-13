using FluentEmail.Core;
using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.Repository
{
    public interface IPianiRepository
    {
        Task<IEnumerable<Piano>> GetAllPiani();

        Task<IEnumerable<Piano>> GetPianiByUser(string email);

        Task<Piano> GetPianoById(int pianoId);

        bool DeletePiano(int Id);

        Task<Piano> UpdatePiano(Piano plan, string username);

        Task<Piano> InsertPiano(Piano plan, string username);
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

        public async Task<Piano> UpdatePiano(Piano plan, string username)
        {
            User? user = await _swimDBContext.Utenti.GetByEmail(username);
            if (user is null || !user.EmailVerified)
            {
                throw new Exception("The user was not found");
            }
            else
            {
                plan.Utente = user;
                plan.UpdateDateTime = DateTime.Now;
                _swimDBContext.Entry(plan).State = EntityState.Modified;
                await _swimDBContext.SaveChangesAsync();
                return plan;
            }   
        }

        public async Task<Piano> InsertPiano(Piano plan, string username)
        {
            User? user = await _swimDBContext.Utenti.GetByEmail(username);

            if (user is null || !user.EmailVerified)
            {
                throw new Exception("The user was not found");
            }
            else
            {
                plan.Utente = user;
                plan.InsertDateTime = DateTime.Now;
                plan.UpdateDateTime = DateTime.Now;
                _swimDBContext.Piani.Add(plan);
                await _swimDBContext.SaveChangesAsync();
                return plan;
            }
        }

        public async Task<Piano> GetPianoById(int pianoId)
        {
            return await _swimDBContext.Piani.FindAsync(pianoId);
        }

        public async Task<IEnumerable<Piano>> GetPianiByUser(string email)
        {
            var pianiList = new List<Piano>();
            User? user = await _swimDBContext.Utenti.GetByEmail(email);

            if (user is null || !user.EmailVerified)
            {
                throw new Exception("The user was not found");
            }
            else
            {
                var userId = user.Id;
                pianiList = await _swimDBContext.Piani.Where(p => p.Createdby == userId).ToListAsync();
            }
            return pianiList;
        }
    }
}
