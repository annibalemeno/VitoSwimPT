using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.AllenamentiUtente
{
    internal sealed class AssociaAllenamentoUtente(SwimContext context)
    {
        public record Request(int allenamentoId, DateTime planned, DateTime executed, Guid doneBy);

        public async Task<JsonResult> Handle(Request request)
        {
            try
            {
                AllenamentoUtente train = new AllenamentoUtente()
                {
                    AllenamentoId = request.allenamentoId,
                    DatePlanned = request.planned,
                    DateDone = request.executed,
                    DoneBy = request.doneBy
                };
                context.AllenamentiUtente.Add(train);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {

                    throw new Exception("Error Adding AllenamentoUtente",e);
                }

                return new JsonResult(train);
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }
    }
}
