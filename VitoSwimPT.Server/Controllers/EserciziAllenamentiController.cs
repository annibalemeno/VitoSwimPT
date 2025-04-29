using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Migrations;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EserciziAllenamentiController:ControllerBase
    {
        private readonly ILogger<EserciziAllenamentiController> _logger;
        private readonly IEserciziAllenamentiRepository _trainingRepo;
        public EserciziAllenamentiController(ILogger<EserciziAllenamentiController> logger, IEserciziAllenamentiRepository trainingRepo)
        {
            _trainingRepo = trainingRepo ?? throw new ArgumentNullException(nameof(trainingRepo));
            _logger = logger;
        }

        [HttpGet(Name = "GetEserciziAllenamento")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _trainingRepo.GetEserciziAllenamento());
        }

        [HttpGet("{id:int}")]
        public JsonResult Get(int id)
        {
            var training = _trainingRepo.GetEsercizioAllenamentoByID(id);
            return new JsonResult(training);
        }


    }
}
