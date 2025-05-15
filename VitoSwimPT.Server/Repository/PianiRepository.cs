using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IPianiRepository
    {
        Task<IEnumerable<Piano>> GetAllPiani();
    }
    

        public class PianiRepository:IPianiRepository
    {
        private readonly SwimContext _swimDBContext;

        public PianiRepository(SwimContext context)
        {
            _swimDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<Piano>> GetAllPiani()
        {
            return null;
        }
    }
}
