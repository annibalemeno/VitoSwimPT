using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.AllenamentiUtente
{
    internal sealed  class DeleteAllenamentoUtente(SwimContext dbContext)
    {
        public sealed record AllenamentoResponse(string allenamentoResponse);

        public async Task<AllenamentoResponse> Handle(int allenamentoUtenteId)
        {
            try
            {
                AllenamentoUtente trainToDelete = dbContext.AllenamentiUtente.FindAsync(allenamentoUtenteId).Result;
                if (trainToDelete != null)
                {
                    dbContext.Entry(trainToDelete).State = EntityState.Deleted;
                    await dbContext.SaveChangesAsync();
                    string msg = $"Allenamento Utente con Id {allenamentoUtenteId} cancellato!";
                    return new AllenamentoResponse(msg);
                }
                else
                {
                    return new AllenamentoResponse(String.Format($"Allenamento Utente non presente nel database!"));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
