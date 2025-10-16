using Microsoft.EntityFrameworkCore;
using System;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Users;
using static VitoSwimPT.Server.AllenamentiUtente.GetAllenamentoUtente;

namespace VitoSwimPT.Server.AllenamentiUtente
{
    internal sealed class GetAllenamentiUtente(SwimContext context)
    {
        public sealed record AllenamentoResponse(int allenamentoUtenteId, int allenamentoId, DateTime insertDateTime, DateTime updateDateTime, DateTime? DateDone, Guid DoneBy);

        public async Task<List<AllenamentoResponse>?> Handle(Guid owner)
        {
            //User? user = await context.Utenti.GetByEmail(email);

            var allenamenti = await context.AllenamentiUtente.Where(a => a.DoneBy == owner).Select(u => new AllenamentoResponse(
                u.AllenamentoUtenteId, u.AllenamentoId, u.InsertDateTime, u.UpdateDateTime, u.DateDone, u.DoneBy)).ToListAsync();

            return allenamenti;
        }     
    }
}
