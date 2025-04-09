using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IStiliRepository
    {
        Task<IEnumerable<Stile>> GetStile();
    }

    public class StiliRepository : IStiliRepository
    {
        private readonly SwimContext _swimDBContext;

        public StiliRepository(SwimContext context)
        {
            _swimDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Stile>> GetStile()
        {
            return await _swimDBContext.Stili.ToListAsync();
        }

    }
}
