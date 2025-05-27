using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EserciziAllenamentiController:ControllerBase
    {
        private readonly ILogger<EserciziAllenamentiController> _logger;
        private readonly IEserciziAllenamentiRepository _trainingRepo;
        private ModelMap _mapper;
        public EserciziAllenamentiController(ILogger<EserciziAllenamentiController> logger, IEserciziAllenamentiRepository trainingRepo, ModelMap mapper)
        {
            _trainingRepo = trainingRepo ?? throw new ArgumentNullException(nameof(trainingRepo));
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetEserciziAllenamento")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _trainingRepo.GetEserciziAllenamento());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public  async Task<IActionResult> Get(int id)
        {
            try
            {
                IEnumerable<EsercizioAllenamento> training = await _trainingRepo.GetEserciziAllenamentoByID(id); // await
                var trainVM = _mapper.toViewModel(training);       //robustezza

                return Ok(trainVM);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("Associabili/{id:int}")]
        public async Task<IActionResult> GetAssociabili(int id)
        {
            try
            {
                return Ok(await _trainingRepo.GetEserciziAssociabiliAllenamento(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //multiple parameter
        [HttpPost("{allenamentoId}/{esercizioId}")]
        public async Task<IActionResult> Post(int allenamentoId, int esercizioId)
        {
            try
            {
                var result = await _trainingRepo.AssociaEsercizioAllenamento(allenamentoId, esercizioId);
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
        [HttpDelete("{allenamentoId}/{esercizioId}")]
        public JsonResult Delete(int allenamentoId, int esercizioId)
        {
            try
            {
                bool res = _trainingRepo.DisassociaEsercizioAllenamento(allenamentoId, esercizioId);
                if (res)
                {
                    return new JsonResult("Deleted Successfully");
                }
                else
                {
                    return new JsonResult("Allenamento not found or deleting error");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
