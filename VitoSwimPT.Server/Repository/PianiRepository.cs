using FluentEmail.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VitoSwimPT.Server.Infrastructure;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Users;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Repository
{
    public interface IPianiRepository
    {
        Task<IEnumerable<Piano>> GetAllPiani();

        Task<PagedPiani> GetPianiByUser(FilterPiani filters);

        Task<Piano> GetPianoById(int pianoId);

        bool DeletePiano(int Id);

        Task<Piano> UpdatePiano(Piano plan, string username);

        Task<Piano> InsertPiano(Piano plan, string username);
    }


    public class PianiRepository : IPianiRepository
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

        //pianiList = await _swimDBContext.Piani.Where(p => p.Createdby == userId).ToListAsync();
        public async Task<PagedPiani> GetPianiByUser(FilterPiani filters)
        {
            var pianiList = new List<Piano>();
            User? user = await _swimDBContext.Utenti.GetByEmail(filters.usermail);

            if (user is null || !user.EmailVerified)
            {
                throw new Exception("The user was not found");
            }
            else
            {
                var userId = user.Id;
                var query = _swimDBContext.Piani.Where(p => p.Createdby == userId).AsQueryable();

                // Sorting
                query = filters.sortOrder == 1
                    ? query.OrderByDynamic(filters.sortField)
                    : query.OrderByDescendingDynamic(filters.sortField);

                query = ApplyFilters(query, filters);
                int count = await query.CountAsync();

                pianiList = await query.Skip(filters.skip).Take(filters.take).ToListAsync();
            }



            return new PagedPiani()
            {
                totalRecords = pianiList.Count,
                data = pianiList
            };
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

        public IQueryable<Piano> ApplyFilters(IQueryable<Piano> query, FilterPiani filters)
        {

            if (!string.IsNullOrEmpty(filters.pianoId?.value))
                query = ApplyStringFilter(query, e => e.PianoId.ToString(), filters.pianoId);
            if (!string.IsNullOrEmpty(filters.nomePiano?.value))
                query = ApplyStringFilter(query, e => e.NomePiano.ToString(), filters.nomePiano);
            if (!string.IsNullOrEmpty(filters.descrizione?.value))
                query = ApplyStringFilter(query, e => e.Descrizione.ToString(), filters.descrizione);
            if (!string.IsNullOrEmpty(filters.note?.value))
                query = ApplyStringFilter(query, e => e.Note.ToString(), filters.note);

            //global filters
            if (!string.IsNullOrWhiteSpace(filters.globalFilter))
            {
                var gf = filters.globalFilter.ToLower();

                query = query.Where(x =>
                x.PianoId.ToString().Contains(gf) 
                ||  (x.NomePiano != null && x.NomePiano.Contains(gf)) 
                ||  (x.Descrizione != null && x.Descrizione.Contains(gf))
                ||  (x.Note != null && x.Note.Contains(gf))
                );
            }


           return query;
        }
    }
}
