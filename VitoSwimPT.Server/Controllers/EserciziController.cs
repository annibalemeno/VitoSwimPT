using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    //[EnableCors("AllowLocal")]
    public class EserciziController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IEsercizioRepository _eserciziRepo;
        private readonly IStiliRepository _stiliRepo;
        private readonly IMapper _mapper;

        private static readonly string[] Stiles = new[]
        {
            "Delfino", "Dorso", "Rana", "Stile"
        };

        //private readonly ILogger<EserciziController> _logger;

        public EserciziController(Serilog.ILogger logger, IEsercizioRepository repo, IStiliRepository slrepo, IMapper mapper)   
        {
            _eserciziRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _stiliRepo = slrepo ?? throw new ArgumentNullException(nameof(slrepo));
            _logger = logger;
            _mapper = mapper;
        }

        //[HttpGet(Name = "GetAllenamenti")]
        //public IEnumerable<Allenamenti> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new Allenamenti
        //    {
        //        //Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        ripetizioni = Random.Shared.Next(1,10),
        //        distanza = 200,
        //        recupero = 30,
        //        stile = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "GetEsercizi")]
        [Authorize]
        //[AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.Debug("Controller Esercizi Get()");

                var esercizi = await _eserciziRepo.GetEsercizi();
                //Task<IEnumerable<EserciziVM>>
                var eserciziList = new List<EserciziVM>();
                foreach (var item in esercizi)
                {
                    var stile = await _stiliRepo.GetStileById(item.StileId);

                    var esercizio = _mapper.Map<EserciziVM>(item);


                    esercizio.Stile = stile.Nome;
                    eserciziList.Add(esercizio);
                }
                return Ok(eserciziList);
                //return Ok(await _eserciziRepo.GetEsercizi());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]

        [AllowAnonymous]
        //[HttpDelete("{id}")]
        //[Route("DeleteEsercizi/{Id}")]
        //[Route("/{Id}")]
        public JsonResult Get(int id)
        {
            try
            {
                _logger.Debug($"Controller Esercizi Get(id) with id = {id} ");
                var esercizio = _eserciziRepo.GetEsercizioByID(id);
                return new JsonResult(esercizio);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost(Name = "AddEsercizi")]
        public async Task<IActionResult> Post(EserciziVM es)
        {
            try
            {
                _logger.Debug($"Controller Esercizi Post(es) with es = {es} ");

                //get stile
                var stile = await _stiliRepo.GetStileByName(es.Stile);
                int stileId = stile.StileId;                //TODO robustezza eccezioni

                Esercizio esToInsert = new Esercizio()
                {
                    Ripetizioni = es.Ripetizioni,
                    Distanza = es.Distanza,
                    Recupero = es.Recupero,
                    StileId = stileId
                };


                var result = await _eserciziRepo.InsertEsercizio(esToInsert);
                if (result.EsercizioId == 0)
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
      
        //[HttpDelete]
        //[Route("DeleteEsercizi/{Id}")]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                _logger.Debug($"Controller Esercizi Delete(id) with id = {id} ");
                bool res = _eserciziRepo.DeleteEsercizio(id);
                if (res)
                {
                    return new JsonResult("Deleted Successfully");
                }
                else
                {
                    return new JsonResult("Esercizio not found or deleting error");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateEsercizi")]
        public async Task<IActionResult> Put(EserciziVM es)
        {
            try
            {
                _logger.Debug($"Controller Esercizi Put(es) with es = {es}");
                //get esercizio by id
                Esercizio esToUpdate = await _eserciziRepo.GetEsercizioByID(es.EsercizioId);
                //get stile
                var stile = await _stiliRepo.GetStileByName(es.Stile);
                int stileId = stile.StileId;                //TODO robustezza eccezioni
                                                            //gestisco modifiche
                esToUpdate.Ripetizioni = es.Ripetizioni;
                esToUpdate.Distanza = es.Distanza;
                esToUpdate.Recupero = es.Recupero;
                esToUpdate.StileId = stileId;
                esToUpdate.UpdateDateTime = DateTime.Now;

                await _eserciziRepo.UpdateEsercizio(esToUpdate);
                return new JsonResult("Updated Successfully");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
