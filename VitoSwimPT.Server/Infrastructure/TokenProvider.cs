namespace VitoSwimPT.Server.Infrastructure
{
    internal sealed class TokenProvider(IConfiguration configuration)
    {
        string secretKey = configuration["Jwt:Secret"]!;

        string issuer = configuration["Jwt:Issuer"]!;
        string audience = configuration["Jwt:Audience"]!;
    }
}
