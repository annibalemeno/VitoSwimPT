using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using VitoSwimPT.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<SwimContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using (var context = new SwimContext())
{
    //creates db if not exists 
    context.Database.EnsureCreated();

    //create entity objects
    //var train1 = new Allenamento() { Ripetizioni = 2, Distanza = 200, Recupero = 30, Stile = "Libero" };
    //var train2 = new Allenamento() { Ripetizioni = 4, Distanza = 100, Recupero = 20, Stile = "Libero" };

    //add entitiy to the context
    //context.Allenamenti.Add(train1);
    //context.Allenamenti.Add(train2);

    //save data to the database tables
    //context.SaveChanges();

    //retrieve all the students from the database
    foreach (var a in context.Allenamenti)
    {
        Console.WriteLine($"Ripetizioni: {a.Ripetizioni}, Distanza: {a.Distanza}, Recupero: {a.Recupero}, Stile: {a.Stile}");
    }
}

app.Run();
