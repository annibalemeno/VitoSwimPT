using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IStiliRepository
    {
        Task<IEnumerable<Stile>> GetStile();
        Task<Stile> GetStileByName(string name);
        Task<Stile> GetStileById(int id);
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
        public async Task<Stile> GetStileByName(string name)
        {
            return await _swimDBContext.Stili.Where(x => x.Nome.EndsWith(name)).FirstOrDefaultAsync();
        }

        public async Task<Stile> GetStileById(int id)
        {
            return await _swimDBContext.Stili.FindAsync(id);
        }


    }
}
