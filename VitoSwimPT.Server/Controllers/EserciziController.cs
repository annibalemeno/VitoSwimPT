using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EserciziController : ControllerBase
    {
        private readonly IEsercizioRepository _eserciziRepo;

        private static readonly string[] Summaries = new[]
        {
            "Delfino", "Dorso", "Rana", "Stile"
        };

        private readonly ILogger<EserciziController> _logger;

        public EserciziController(ILogger<EserciziController> logger, IEsercizioRepository repo)
        {
            _eserciziRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }

        //[HttpGet(Name = "GetAllenamenti")]
        //public IEnumerable<Allenamenti> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new Allenamenti
        //    {
        //        //Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        ripetizioni = Random.Shared.Next(1,10),
        //        distanza = 200,
        //        recupero = 30,
        //        stile = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "GetEsercizi")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _eserciziRepo.GetEsercizi());
        }

    }
}
