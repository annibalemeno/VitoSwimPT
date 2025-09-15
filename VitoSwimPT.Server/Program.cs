using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Exceptions;
using System.Diagnostics;
using System.Text;
using VitoSwimPT.Server.Infrastructure;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.Users;
using VitoSwimPT.Server.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Enable CORS
builder.Services.AddCors(c =>
{   c.AddPolicy("AllowLocal", options => options.WithOrigins("http://localhost:4200", "https://localhost:4200", "http://localhost:5194", "https://localhost:5194").AllowAnyMethod().AllowAnyHeader()); 
});
//c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); undo





//Logging configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.WithExceptionDetails()
    .WriteTo.File("../Resources/VitoSwimPtLog.txt", rollingInterval: RollingInterval.Year, 
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss zzz} [{Level:u5}] {Message:lj}{NewLine}{Exception}{Properties:j}")
    .CreateLogger();

//builder.Logging.ClearProviders();

builder.Services.AddSingleton(Log.Logger);
builder.Services.AddSingleton<PasswordHasher>();
builder.Services.AddSingleton<TokenProvider>();

//builder.Services.AddLogging(loggingBuilder =>
//          loggingBuilder.Add(dispose:
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithAuth();

// Register the global exception handler
builder.Services.AddExceptionHandler<SwimExceptionHandler>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IEsercizioRepository, EserciziRepository>();
builder.Services.AddScoped<IAllenamentoRepository, AllenamentiRepository>();
builder.Services.AddScoped<IStiliRepository, StiliRepository>();
builder.Services.AddScoped<IEserciziAllenamentiRepository, EserciziAllenamentiRepository>();
builder.Services.AddScoped<IPianiRepository, PianiRepository>();
builder.Services.AddScoped<IPianiAllenamentoRepository, PianiAllenamentoRepository>();

builder.Services.AddDbContext<SwimContext>();

//// Auto Mapper Configurations
//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new MappingProfile());
//});


builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddScoped(map => mapperConfig.CreateMapper());

//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<ModelMap>();
//builder.Services.AddAutoMapper(typeof(IStartup).Assembly);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!)),
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services
    .AddFluentEmail(builder.Configuration["Email:SenderEmail"], builder.Configuration["Email:Sender"])
    .AddSmtpSender(builder.Configuration["Email:Host"], builder.Configuration.GetValue<int>("Email:Port"),
    builder.Configuration["Email:Username"], builder.Configuration["Email:Password"]);



builder.Services.AddScoped<LoginUser>();
builder.Services.AddScoped<RegisterUser>();
builder.Services.AddScoped<VerifyEmail>();
builder.Services.AddScoped<EmailVerificationLinkFactory>();
builder.Services.AddScoped <GetUser>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowLocal");
//app.UseCors("AllowAllHeaders"); ;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

UserEndpoints.Map(app);

// Use the global exception handler
app.UseExceptionHandler(_ => { });


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

using (var context = new SwimContext(configuration))
{
    //creates db if not exists
    context.Database.EnsureCreated();
}

app.Run();
