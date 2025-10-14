using Microsoft.EntityFrameworkCore;
using VitoSwimPT.Server.Models;


namespace VitoSwimPT.Server.AllenamentiUtente
{
    internal sealed class GetAllenamentoUtente(SwimContext context)
    {
        public sealed record AllenamentoResponse(int allenamentoUtenteId, int allenamentoId, DateTime insertDateTime, DateTime updateDateTime, DateTime? DateDone, Guid DoneBy);

        public async Task <AllenamentoResponse?>Handle(int id)
        {
            AllenamentoResponse? allenamentoUt = await context.AllenamentiUtente.Where(a => a.AllenamentoId == id).Select(u => new AllenamentoResponse(
                u.AllenamentoUtenteId, u.AllenamentoId, u.InsertDateTime, u.UpdateDateTime, u.DateDone, u.DoneBy)).SingleOrDefaultAsync();

            return allenamentoUt;
        }
    }
}
