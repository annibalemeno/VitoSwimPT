using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<SwimContext>();
//builder.Services.AddDbContext<ConfigurationContext>(options => {
//    options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
//});


//Enable CORS
builder.Services.AddCors(c =>
{   c.AddPolicy("AllowLocal", options => options.WithOrigins("http://localhost:4200", "https://localhost:4200", "http://localhost:5194", "https://localhost:5194").AllowAnyMethod().AllowAnyHeader()); 
}); 
//c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); undo



//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllHeaders",
//        builder =>
//        {
//            builder.AllowAnyOrigin()
//                   .AllowAnyHeader()              undo
//                   .AllowAnyMethod();
//        });
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEsercizioRepository, EserciziRepository>();
builder.Services.AddScoped<IAllenamentoRepository, AllenamentiRepository>();
builder.Services.AddScoped<IStiliRepository, StiliRepository>();
builder.Services.AddScoped<ModelMap>();

//builder.Services.AddDbContext<SwimContext>(options => options.UseSqlServer("Server=FGBAL051944;Database=SwimDB;Trusted_Connection=True; TrustServerCertificate=true;"));
builder.Services.AddDbContext<SwimContext>();

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

    //retrieve all the students from the database
    //foreach (var a in context.Esercizi)
    //{
    //    Console.WriteLine($"Ripetizioni: {a.Ripetizioni}, Distanza: {a.Distanza}, Recupero: {a.Recupero}, Stile: {a.Stile}");
    //}
}

app.Run();
