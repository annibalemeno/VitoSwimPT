
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.AllenamentiUtente
{
    public static class AllenamentoUtenteEndpoints
    {
        private const string Tag = "AllenamentiUtente";

        public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
        {
            builder.MapPost("associaAllenamentoUtente", async(AssociaAllenamentoUtente.Request request, AssociaAllenamentoUtente useCase) => 
                await useCase.Handle(request))          
            .WithTags(Tag)
            .RequireAuthorization();

            builder.MapPut("ModifyAllenamentoUtente", async (ModifyAllenamentoUtente.Request request, ModifyAllenamentoUtente useCase) =>
                await useCase.Handle(request))
            .WithTags(Tag)
            .RequireAuthorization();

            builder.MapGet("allenamentoUtente/{id:int}", async (int id, GetAllenamentoUtente useCase) =>
            {
                GetAllenamentoUtente.AllenamentoResponse? training = await useCase.Handle(id);

                return training is not null ? Results.Ok(training) : Results.NotFound();
            })
            .WithTags(Tag)
            .RequireAuthorization();

            builder.MapGet("allenamentiUtente/{idUtente:guid}", async (Guid idUtente, GetAllenamentiUtente useCase) =>
            {
                List<GetAllenamentiUtente.AllenamentoResponse>? trainings = await useCase.Handle(idUtente);

                return trainings is not null ? Results.Ok(trainings) : Results.NotFound();
            })
                .WithTags(Tag)
                .RequireAuthorization();

            builder.MapDelete("allenamentiUtente/{idAllenamento:int}", async (int idAllenamento, DeleteAllenamentoUtente useCase) =>
            {
                DeleteAllenamentoUtente.AllenamentoResponse response = await useCase.Handle(idAllenamento);
                return response;
            })
                .WithTags(Tag)
                .RequireAuthorization();

            return builder;
        }
    }
}


