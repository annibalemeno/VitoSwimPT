using Microsoft.AspNetCore.Mvc;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllenamentiController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Delfino", "Dorso", "Rana", "Stile"
        };

        private readonly ILogger<AllenamentiController> _logger;

        public AllenamentiController(ILogger<AllenamentiController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllenamenti")]
        public IEnumerable<Allenamenti> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Allenamenti
            {
                //Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                ripetizioni = Random.Shared.Next(1,10),
                distanza = 200,
                recupero = 30,
                stile = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
