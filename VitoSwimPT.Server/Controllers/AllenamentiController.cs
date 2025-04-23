using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[EnableCors("AllowAllHeaders")]
    //[EnableCors("AllowLocal")] 
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

        [HttpPost(Name = "AddAllenamenti")]
        public async Task<IActionResult> Post(Allenamento train)
        {
            var result = await _allenamentiRepo.InsertAllenamento(train);
            if (result.AllenamentoId == 0)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
                return new JsonResult(StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong"));
            }
            //return Ok("Ok");
            return new JsonResult("Added Successfully");
        }



    }
}
