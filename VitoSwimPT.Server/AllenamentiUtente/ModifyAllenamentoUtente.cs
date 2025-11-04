using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.AllenamentiUtente
{
    internal sealed class ModifyAllenamentoUtente(SwimContext dbContext)
    {
        public record Request(int allenamentoUtenteId, int allenamentoId, DateTime planned, DateTime executed, Guid doneBy);

        public async Task<JsonResult> Handle(Request request)
        {
			try
			{
                AllenamentoUtente trainToMod = dbContext.AllenamentiUtente.FindAsync(request.allenamentoUtenteId).Result!;
                trainToMod.AllenamentoId = request.allenamentoId;
                trainToMod.DatePlanned = request.planned;
                trainToMod.DateDone = request.executed;
                trainToMod.DoneBy = request.doneBy;
                trainToMod.UpdateDateTime = DateTime.Now;
                dbContext.Entry(trainToMod).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return new JsonResult(trainToMod);
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
