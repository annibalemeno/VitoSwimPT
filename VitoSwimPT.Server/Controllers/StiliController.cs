using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[EnableCors("AllowLocal")]
    public class StiliController : ControllerBase
    {
        private readonly ILogger<StiliController> _logger;
        private readonly IStiliRepository _stiliRepo;
        public StiliController(ILogger<StiliController> logger, IStiliRepository repo)
        {
            _stiliRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }

        [HttpGet(Name = "GetStili")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _stiliRepo.GetStile());
        }

    }


}




