using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PianiAllenamentoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IPianiAllenamentoRepository _plantrainRepo;
        private readonly IPianiRepository _planRepo;
        private ModelMap _mapper;

        public PianiAllenamentoController(Serilog.ILogger logger, IPianiAllenamentoRepository planTrainRepo, IPianiRepository planRepo,
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
                _logger.Debug("Controller PianiAllenamento Get()");
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
                _logger.Debug($"Controller PianiAllenamento Get(id) with id = {id} ");
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
                _logger.Debug($"Controller PianiAllenamento GetAllenamentiAssociabiliPiano(pianoId) with pianoId = {pianoId} ");
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
                _logger.Debug($"Controller PianiAllenamento Post(pianoId, allenamentoId) with pianoId = {pianoId} and allenamentoId = {allenamentoId}");
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
                _logger.Debug($"Controller PianiAllenamento Delete(pianoId, allenamentoId) with pianoId = {pianoId} and allenamentoId = {allenamentoId} ");
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
