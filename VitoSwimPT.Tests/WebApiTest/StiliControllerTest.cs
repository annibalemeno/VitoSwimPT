using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Any;
using NSubstitute;
using NSubstitute.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VitoSwimPT.Server.Controllers;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Tests.WebApiTest
{
    public class StiliControllerTest
    {
        //private readonly IConfiguration _configMock;
        private readonly SwimContext _swimContextMock;
        private readonly Serilog.ILogger _stublogger;
        private readonly StiliRepository _stubRepo;
        //private readonly StiliController _stiliController;
        public StiliControllerTest()
        {
            //instead of injection Db Context into your api controller you should inject a repository then in your unit test you mock the repository.

            //_configMock = Substitute.For<IConfiguration>();
            DbContextOptions<SwimContext> options = new DbContextOptionsBuilder<SwimContext>()
            .UseInMemoryDatabase(databaseName:"VitoSwimTest")
            .Options;
            _swimContextMock = Substitute.For<SwimContext>(options);


            //        var options = new DbContextOptionsBuilder<SwimContext>()
            //.UseInMemoryDatabase($"FakeDb{Guid.NewGuid()}")
            //.UseModel(SqlServerConventionSetBuilder.CreateModelBuilder()
            //    .Entity<EsercizioAllenamento>(e => e.HasKey(x => x.EsercizioId))
            //    .Model)
            //.Options;
            DbSet<Stile> customerDbSet = Substitute.For<DbSet<Stile>>();

            //customerDbSet.GetEnumerator().Returns(customers.GetEnumerator());

            //IRepositoryContext repositoryContext = Substitute.For<IRepositoryContext>();

            _stubRepo = Substitute.For<StiliRepository>(_swimContextMock);
            _stublogger = Substitute.For<Serilog.ILogger>();

            //IEnumerable<Stile> retStile = new List<Stile>() {};
            //_stubRepo.GetStile().Returns(Task.FromResult(retStile));
            //modelBuilder.Entity<EsercizioAllenamento>().HasKey(ea => new { ea.EsercizioId, ea.AllenamentoId });
            //modelBuilder.Entity<PianoAllenamento>().HasKey(pa => new { pa.PianoId, pa.AllenamentoId });
            //modelBuilder.Entity<Stile>().Property(x => x.Sigla).HasMaxLength(2);

            //modelBuilder.Entity<AllenamentoUtente>().Property(b => b.InsertDateTime).HasDefaultValueSql("getdate()");
            //modelBuilder.Entity<AllenamentoUtente>().Property(b => b.UpdateDateTime).HasDefaultValueSql("getdate()");

        }

        [Fact]
        public async Task GetStili_ShouldReturnValue()
        {
            //Arrange
            Stile exampleS = new Stile()
            {
                StileId = 1,
                Nome = "StileTest",
                Sigla = "TS"
            };
            //IEnumerable<Stile> retStile = new List<Stile>() {};
            //_stubRepo.GetStile().Returns(Task.FromResult(retStile));

            //_swimContextMock.Stili.Add(exampleS);
            //await _swimContextMock.SaveChangesAsync();

            StiliController slc = new StiliController(_stublogger, _stubRepo);

            //_stiliController = Substitute.For<StiliController>(_stublogger, _stubRepo);
            //var ts = _stubRepo.GetStile();

            //Act
            //var ts = await _stubController.Get();
            //Task<IActionResult> ts =  _stubController.Get();
            //await ts;
            var result = await slc.Get();
            var okResult = result as OkObjectResult;
            //Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        //[Fact]
        //public async Task<IActionResult> GetStili_ShouldReturnListOfStili()
        //{
             
        //}

    }
}
