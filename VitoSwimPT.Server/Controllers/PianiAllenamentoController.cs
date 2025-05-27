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
            try
            {
                return Ok(await _plantrainRepo.GetPianiAllenamento());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Piano plan = await _planRepo.GetPianoById(id); // await
                PianiAllenamentoVM trainVM = _mapper.toViewModel(plan);      //robustezza

                return Ok(trainVM);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("Associabili/{pianoId:int}")]
        public async Task<IActionResult> GetAllenamentiAssociabiliPiano(int pianoId)
        {
            try
            {
                return Ok(await _plantrainRepo.getAllenamentiAssociabiliPiano(pianoId));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        [HttpPost("{pianoId}/{allenamentoId}")]
        public async Task<IActionResult> Post(int pianoId, int allenamentoId)
        {
            try
            {
                var result = await _plantrainRepo.AssociaAllenamentoPiano(pianoId, allenamentoId);
                if (result.AllenamentoId == 0)
                {
                    return new JsonResult(StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong"));
                }
                return new JsonResult("Added Successfully");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //multiple parameter
        [HttpDelete("{pianoId}/{allenamentoId}")]
        public JsonResult Delete(int pianoId, int allenamentoId)
        {
            try
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
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
