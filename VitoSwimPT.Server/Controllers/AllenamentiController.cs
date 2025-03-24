using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllenamentiController : ControllerBase
    {

        private readonly ILogger<AllenamentiController> _logger;
        private readonly IAllenamentoRepository _allenamentiRepo;
        public AllenamentiController(ILogger<AllenamentiController> logger, IAllenamentoRepository repo)
        {
            _allenamentiRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }

        [HttpGet(Name = "GetAllenamenti")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _allenamentiRepo.GetAllenamenti());
        }
    }
}
