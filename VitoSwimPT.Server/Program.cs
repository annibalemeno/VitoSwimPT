using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<SwimContext>();
//builder.Services.AddDbContext<ConfigurationContext>(options => {
//    options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEsercizioRepository, EserciziRepository>();

//builder.Services.AddDbContext<SwimContext>(options => options.UseSqlServer("Server=FGBAL051944;Database=SwimDB;Trusted_Connection=True; TrustServerCertificate=true;"));
builder.Services.AddDbContext<SwimContext>();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

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
   // creates db if not exists
    context.Database.EnsureCreated();

    //create entity objects
    //var train1 = new Esercizio() { Ripetizioni = 2, Distanza = 200, Recupero = 30, Stile = "Libero" };
    //var train2 = new Esercizio() { Ripetizioni = 4, Distanza = 100, Recupero = 20, Stile = "Libero" };

    ////add entitiy to the context
    //context.Esercizi.Add(train1);
    //context.Esercizi.Add(train2);

    ////save data to the database tables
    //context.SaveChanges();

    ////retrieve all the students from the database
    //foreach (var a in context.Esercizi)
    //{
    //    Console.WriteLine($"Ripetizioni: {a.Ripetizioni}, Distanza: {a.Distanza}, Recupero: {a.Recupero}, Stile: {a.Stile}");
    //}
}

app.Run();
