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
            return Ok(await _trainingRepo.GetEserciziAllenamento());
        }

        [HttpGet("{id:int}")]
        public  async Task<IActionResult> Get(int id)
        {
            //var esercizi = await _eserciziRepo.GetEsercizi();
            ////Task<IEnumerable<EserciziVM>>
            //var eserciziList = new List<EserciziVM>();
            //foreach (var item in esercizi)
            //{
            //    var stile = await _stiliRepo.GetStileById(item.StileId);
            //    var esercizio = _mapper.toViewModel(item);
            //    esercizio.Stile = stile.Nome;
            //    //eserciziList.Add(_mapper.toViewModel(item));
            //    eserciziList.Add(esercizio);
            //}
            //return Ok(eserciziList);

            //var training = _trainingRepo.GetEsercizioAllenamentoByID(id);
            //return new JsonResult(training);
            IEnumerable<EsercizioAllenamento> training = await _trainingRepo.GetEserciziAllenamentoByID(id); // await
            var trainVM = _mapper.toViewModel(training);       //robustezza
            //trainVM.nomeAllenamento = ;
            //trainVM.note = ;

            return Ok(trainVM);
        }

        [HttpGet("Associabili/{id:int}")]
        public async Task<IActionResult> GetAssociabili(int id)
        {
            return Ok(await _trainingRepo.GetEserciziAssociabiliAllenamento(id));
        }

        //multiple parameter
        [HttpPost("{allenamentoId}/{esercizioId}")]
        public async Task<IActionResult> Post(int allenamentoId, int esercizioId)
        {
            var result = await _trainingRepo.AssociaEsercizioAllenamento(allenamentoId, esercizioId);
            if (result.AllenamentoId == 0)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
                return new JsonResult(StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong"));
            }
            //return Ok("Ok");
            return new JsonResult("Added Successfully");
        }


        //multiple parameter
        [HttpDelete("{allenamentoId}/{esercizioId}")]
        public JsonResult Delete(int allenamentoId, int esercizioId)
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


    }
}
