using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IAllenamentoRepository
    {
        Task<IEnumerable<Allenamento>> GetAllenamenti();
        //Task<Customer> InsertCustomer(Customer objDepartment);
        //Task<Customer> UpdateCustomer(Customer objDepartment);
        //bool DeleteCustomer(int ID);

        // Task<Customer> GetCustomerByID(int ID);
        // Task<Customer> GetCustomerByName(string Name);
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
    }
}
