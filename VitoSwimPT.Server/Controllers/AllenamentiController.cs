using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllenamentiController : ControllerBase
    {
        private readonly IAllenamentoRepository _allenamento;

        private static readonly string[] Summaries = new[]
        {
            "Delfino", "Dorso", "Rana", "Stile"
        };

        private readonly ILogger<AllenamentiController> _logger;

        public AllenamentiController(ILogger<AllenamentiController> logger, IAllenamentoRepository allenamento)
        {
            _allenamento = allenamento ?? throw new ArgumentNullException(nameof(allenamento));
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

        [HttpGet(Name = "GetAllenamenti")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _allenamento.GetAllenamenti());
        }

    }
}
