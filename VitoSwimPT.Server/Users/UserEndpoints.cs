namespace VitoSwimPT.Server.Users
{
    public static class UserEndpoints
    {
        private const string Tag = "Users";

        public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
        {
            //        builder.MapPost("users/register", async (RegisterUser.Request request, RegisterUser useCase) =>
            //await useCase.Handle(request))
            //.WithTags(Tag);

            builder.MapPost("users/login", async (LoginUser.Request request, LoginUser useCase) =>
    await useCase.Handle(request))
    .WithTags(Tag);

            return builder;
        }
    }
}
