using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    //[EnableCors("AllowLocal")]
    public class StiliController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IStiliRepository _stiliRepo;
        public StiliController(Serilog.ILogger logger, IStiliRepository repo)
        {
            _stiliRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }

        [HttpGet(Name = "GetStili")]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.Debug("Controller Stili Get()");
                return Ok(await _stiliRepo.GetStile());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }


}




