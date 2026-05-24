using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VitoSwimPT.Server.Repository
{
    public interface IEsercizioRepository
    {
        Task<PageResponse> GetEsercizi(int skip, int take);

        Task<PageResponse> GetEserciziFiltrati(FilterObjects filtri);
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

        public async Task<PageResponse> GetEserciziFiltrati(FilterObjects filters)
        {
            //List<Esercizio> listaEsercizi = await _swimDBContext.Esercizi.Skip(skip).Take(take).ToListAsync();

            var query = _swimDBContext.Esercizi.AsQueryable();
            query = ApplyFilters(query, filters);
            int count = await query.CountAsync();
            List<Esercizio> listaEsercizi = await query.Skip(filters.skip).Take(filters.take).ToListAsync();


            PageResponse ritorno = new PageResponse()
            {
                data = listaEsercizi,
                totalRecords = count
            };

            return ritorno;

            //return await _swimDBContext.Esercizi.Skip(skip).Take(take).ToListAsync();
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

public static IQueryable<T> ApplyStringFilter<T>(
    IQueryable<T> query,
    Expression<Func<T, string>> selector,
    FilterField filter)
{
    if (string.IsNullOrEmpty(filter?.value))
        return query;

    var value = filter.value;
    var mode = filter.matchMode?.ToLower();

    var parameter = selector.Parameters[0]; // es: "e"
    var member = selector.Body;             // es: e.Stile

    Expression body = mode switch
    {
        "startswith" => Expression.Call(member,
            typeof(string).GetMethod("StartsWith", new[] { typeof(string) }),
            Expression.Constant(value)),

        "contains" => Expression.Call(member,
            typeof(string).GetMethod("Contains", new[] { typeof(string) }),
            Expression.Constant(value)),

        "equals" => Expression.Equal(member, Expression.Constant(value)),

        _ => null
    };

    if (body == null)
        return query;

    var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

    return query.Where(lambda);
}


        public IQueryable<Esercizio> ApplyFilters(IQueryable<Esercizio> query, FilterObjects filters)
        {
            if (!string.IsNullOrEmpty(filters.esercizioId?.value))
                query = ApplyStringFilter(query, e => e.EsercizioId.ToString(), filters.esercizioId);

            if (!string.IsNullOrEmpty(filters.ripetizioni?.value))
                query = ApplyStringFilter(query, e => e.Ripetizioni.ToString(), filters.ripetizioni);

            if (!string.IsNullOrEmpty(filters.distanza?.value))
                query = ApplyStringFilter(query, e => e.Distanza.ToString(), filters.distanza);

            if (!string.IsNullOrEmpty(filters.recupero?.value))
                query = ApplyStringFilter(query, e => e.Recupero.ToString(), filters.recupero);

            //if (!string.IsNullOrEmpty(filters.stile?.value))
            //    query = ApplyStringFilter(query, e => e.Stile, filters.stile);

            if (!string.IsNullOrWhiteSpace(filters.globalFilter))
            {
                var gf = filters.globalFilter.ToLower();

                query = query.Where(x =>
                    x.EsercizioId.ToString().Contains(gf) ||
                    x.Ripetizioni.ToString().Contains(gf) ||
                    x.Distanza.ToString().Contains(gf) ||
                    x.Recupero.ToString().Contains(gf) 
                );
            }
            //||x.Stile.ToLower().Contains(gf)
            return query;
        }

    }
}


//var eserc2 = new Esercizio() { Ripetizioni = 4, Distanza = 100, Recupero = 20, Stile = "Libero" };

//context.Set<Esercizio>().AddRange(eserc1, eserc2);
//context.SaveChanges();