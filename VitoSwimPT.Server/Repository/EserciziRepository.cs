using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Repository
{
    public interface IEsercizioRepository
    {
        Task<IEnumerable<Esercizio>> GetEsercizi();
        //Task<Customer> InsertCustomer(Customer objDepartment);
        //Task<Customer> UpdateCustomer(Customer objDepartment);
        //bool DeleteCustomer(int ID);

        // Task<Customer> GetCustomerByID(int ID);
        // Task<Customer> GetCustomerByName(string Name);
    }

    public class EserciziRepository : IEsercizioRepository
    {
        private readonly SwimContext _swimDBContext;

        public EserciziRepository(SwimContext context)
        {
            _swimDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Esercizio>> GetEsercizi()
        {
            return await _swimDBContext.Esercizi.ToListAsync();
        }
    }
}
