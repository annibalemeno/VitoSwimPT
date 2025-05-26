using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PianiAllenamentoController : ControllerBase
    {
        private readonly ILogger<PianiAllenamentoController> _logger;
        private readonly IPianiAllenamentoRepository _plantrainRepo;
        private readonly IPianiRepository _planRepo;
        private ModelMap _mapper;

        public PianiAllenamentoController(ILogger<PianiAllenamentoController> logger, IPianiAllenamentoRepository planTrainRepo, IPianiRepository planRepo,
            ModelMap mapper)
        {
            _plantrainRepo = planTrainRepo ?? throw new ArgumentNullException(nameof(planTrainRepo));
            _planRepo = planRepo ?? throw new ArgumentNullException(nameof(planRepo));
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPianiAllenamento")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _plantrainRepo.GetPianiAllenamento());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Piano plan = await _planRepo.GetPianoById(id); // await
            PianiAllenamentoVM trainVM = _mapper.toViewModel(plan);      //robustezza

            return Ok(trainVM);
        }

        [HttpGet("Associabili/{pianoId:int}")]
        public async Task<IActionResult> GetAllenamentiAssociabiliPiano(int pianoId)
        {
            return Ok(await _plantrainRepo.getAllenamentiAssociabiliPiano(pianoId));
        }


        [HttpPost("{pianoId}/{allenamentoId}")]
        public async Task<IActionResult> Post(int pianoId, int allenamentoId)
        {
            var result = await _plantrainRepo.AssociaAllenamentoPiano(pianoId, allenamentoId);
            if (result.AllenamentoId == 0)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
                return new JsonResult(StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong"));
            }
            //return Ok("Ok");
            return new JsonResult("Added Successfully");
        }

        //multiple parameter
        [HttpDelete("{pianoId}/{allenamentoId}")]
        public JsonResult Delete(int pianoId, int allenamentoId)
        {
            bool res = _plantrainRepo.DisassociaAllenamentoPiano(pianoId, allenamentoId);
            if (res)
            {
                return new JsonResult("Deleted Successfully");
            }
            else
            {
                return new JsonResult("piano not found or deleting error");
            }
        }
    }
}
