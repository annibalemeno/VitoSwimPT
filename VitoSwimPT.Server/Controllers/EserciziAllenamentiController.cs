using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EserciziAllenamentiController:ControllerBase
    {
        //private readonly ILogger<EserciziAllenamentiController> _logger;
        private readonly Serilog.ILogger _logger;
        private readonly IEserciziAllenamentiRepository _trainingRepo;
        private readonly IAllenamentoRepository _allenamentoRepo;
        private readonly IEsercizioRepository _esercizioRepo;
        private readonly IStiliRepository _stiliRepo;
        private readonly IMapper _automapper;
        public EserciziAllenamentiController(Serilog.ILogger logger, IEserciziAllenamentiRepository trainingRepo, IAllenamentoRepository allenamentoRepo, IEsercizioRepository esercizioRepo,
            IStiliRepository stiliRepo, IMapper automapper)
        {
            _trainingRepo = trainingRepo ?? throw new ArgumentNullException(nameof(trainingRepo));
            _allenamentoRepo = allenamentoRepo ?? throw new ArgumentNullException(nameof(allenamentoRepo));
            _esercizioRepo = esercizioRepo ?? throw new ArgumentNullException(nameof(esercizioRepo));
            _stiliRepo = stiliRepo ?? throw new ArgumentNullException(nameof(stiliRepo));
            _logger = logger;
            _automapper = automapper;
        }

        [HttpGet(Name = "GetEserciziAllenamento")]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.Debug("Controller EserciziAllenamenti Get");
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

                _logger.Debug($"Controller EserciziAllenamenti Get(id) with id = {id}");

                IEnumerable<EsercizioAllenamento> training = await _trainingRepo.GetEserciziAllenamentoByID(id);
                var allenamento = await _allenamentoRepo.GetAllenamentoById(training.FirstOrDefault().AllenamentoId);
                var trainvVM = _automapper.Map<EserciziAllenamentiVM>(allenamento);

                var eserciziAssociati = new List<Esercizio>();
                var eserciziAssociatiDTO = new List<EserciziVM>();
                foreach (var item in training.Select(x => x.EsercizioId).ToList())
                {
                    var esercizio = _esercizioRepo.GetEsercizioByID(item).Result;
                    eserciziAssociati.Add(esercizio);
                }
                foreach (var item in eserciziAssociati)
                {
                    var esercizioDTO = _automapper.Map<EserciziVM>(item);
                    string nomeStile = _stiliRepo.GetStileById(item.StileId).Result.Nome;
                    esercizioDTO.Stile = nomeStile;
                    eserciziAssociatiDTO.Add(esercizioDTO);
                }

                trainvVM.EserciziAssociati = eserciziAssociatiDTO;
                //
                //var trainVM = _mapper.toViewModel(training);       //robustezza

                return Ok(trainvVM);
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
                _logger.Debug($"Controller EserciziAllenamenti GetAssociabili(id) with id = {id}");
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
                _logger.Debug($"Controller EserciziAllenamenti Post(allenamentoId, esercizioID) with allenamentoId = {allenamentoId}, esercizioId = {esercizioId}");
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
                _logger.Debug($"Controller EserciziAllenamenti Delete(allenamentoId, esercizioID) with allenamentoId = {allenamentoId}, esercizioId = {esercizioId}");
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
