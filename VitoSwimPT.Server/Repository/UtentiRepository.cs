using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IUtenteRepository
    {
        Task<bool> IsEmailUiniqueAsync(string email); 
    }

    public class UtentiRepository : IUtenteRepository
    {
        private readonly SwimContext _swimDBContext;

        public UtentiRepository(SwimContext swimContext)
        {
            _swimDBContext = swimContext ?? throw new ArgumentNullException(nameof(swimContext));
        }
        public async Task<bool> IsEmailUiniqueAsync(string email)
        {
            return await _swimDBContext.Utenti.AnyAsync(u => u.Email == email);
        }
    }
}
