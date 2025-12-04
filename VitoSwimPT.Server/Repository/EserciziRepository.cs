using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VitoSwimPT.Server.Repository
{
    public interface IEsercizioRepository
    {
        Task<PageResponse> GetEsercizi(int skip, int take);
        Task<Esercizio> InsertEsercizio(Esercizio esercizio);

        bool DeleteEsercizio(int Id);

        Task<Esercizio> UpdateEsercizio(Esercizio esercizio);

        Task<Esercizio> GetEsercizioByID(int ID);

        //Task<Customer> UpdateCustomer(Customer objDepartment);
        //bool DeleteCustomer(int ID);


        // Task<Customer> GetCustomerByName(string Name);
    }

    public class PageResponse
    {
        public List<Esercizio> data;
        public int totalRecords;
    }

    public class EserciziRepository : IEsercizioRepository
    {
        private readonly SwimContext _swimDBContext;

        public EserciziRepository(SwimContext context)
        {
            _swimDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        

        public async Task<PageResponse> GetEsercizi(int skip, int take)
        {
            int count = await _swimDBContext.Esercizi.CountAsync();
            List<Esercizio> listaEsercizi = await _swimDBContext.Esercizi.Skip(skip).Take(take).ToListAsync();

            PageResponse ritorno = new PageResponse()
            {
                data = listaEsercizi,
                totalRecords = count
            };

            return ritorno;

            //return await _swimDBContext.Esercizi.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Esercizio> GetEsercizioByID(int ID)
        {
            return await _swimDBContext.Esercizi.FindAsync(ID);     
        }

        public async Task<Esercizio> InsertEsercizio(Esercizio esercizio)
        {
            _swimDBContext.Esercizi.Add(esercizio);
            await _swimDBContext.SaveChangesAsync();
            return esercizio;
        }

        public bool DeleteEsercizio(int Id)
        {
            bool result = false;
            var esercizio = _swimDBContext.Esercizi.Find(Id);
            if (esercizio != null)
            {
                _swimDBContext.Entry(esercizio).State = EntityState.Deleted;
                _swimDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task <Esercizio> UpdateEsercizio(Esercizio esercizio)
        {
            _swimDBContext.Entry(esercizio).State = EntityState.Modified;
            await _swimDBContext.SaveChangesAsync();
            return esercizio;
        }
    }
}


//var eserc2 = new Esercizio() { Ripetizioni = 4, Distanza = 100, Recupero = 20, Stile = "Libero" };

//context.Set<Esercizio>().AddRange(eserc1, eserc2);
//context.SaveChanges();