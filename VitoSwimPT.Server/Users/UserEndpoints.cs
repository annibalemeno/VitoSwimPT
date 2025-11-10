namespace VitoSwimPT.Server.Users
{
    public static class UserEndpoints
    {
        private const string Tag = "Users";
        public const string VerifyEmail = "VerifyEmail";

        public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
        {
            builder.MapPost("users/register", async (RegisterUser.Request request, RegisterUser useCase) =>
                 await useCase.Handle(request))
                 .WithTags(Tag);

            builder.MapPost("users/login", async (LoginUser.Request request, LoginUser useCase) =>
                await useCase.Handle(request))
                .WithTags(Tag);

            builder.MapPost("users/refresh-token", async (LoginUserWithRefreshToken.Request request, LoginUserWithRefreshToken useCase) =>
                await useCase.Handle(request))
            .WithTags(UserEndpoints.Tag);


            builder.MapGet("users/verify-email", async (Guid token, VerifyEmail useCase) =>
            {
                bool success = await useCase.Handle(token);

                return success ? Results.Ok() : Results.BadRequest("Verification token expired");
            })
                .WithTags(Tag)
                .WithName(VerifyEmail);


            builder.MapGet("users/{id:guid}", async (Guid id, GetUser useCase) =>
            {
                GetUser.UserResponse? user = await useCase.Handle(id);

                return user is not null ? Results.Ok(user) : Results.NotFound();
            })
            .WithTags(Tag)
            .RequireAuthorization();

            //builder.MapDelete("users/{id:guid}/refresh-tokens", async (Guid id, RevokeRefreshTokens useCase) =>
            builder.MapDelete("users/{email}", async (string email, RevokeRefreshTokens useCase) =>
            {
                bool success = await useCase.Handle(email);

                return success ? Results.NoContent() : Results.BadRequest();
            })
            .WithTags(UserEndpoints.Tag)
            .RequireAuthorization();

            return builder;
        }
    }
}
