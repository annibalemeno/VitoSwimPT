
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.AllenamentiUtente
{
    public static class AllenamentoUtenteEndpoints
    {
        private const string Tag = "AllenamentiUtente";

        public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
        {
            builder.MapGet("allenamentiUtente", async (int id, GetAllenamentoUtente useCase) =>
            {
                GetAllenamentoUtente.AllenamentoResponse? training = await useCase.Handle(id);

                return training is not null ? Results.Ok(training) : Results.NotFound();
            })
            .WithTags(Tag)
            .RequireAuthorization();

            return builder;
        }
    }
}


