using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[EnableCors("AllowLocal")]
    public class EserciziController : ControllerBase
    {
        private readonly IEsercizioRepository _eserciziRepo;
        private readonly IStiliRepository _stiliRepo;
        private ModelMap _mapper;

        private static readonly string[] Stiles = new[]
        {
            "Delfino", "Dorso", "Rana", "Stile"
        };

        private readonly ILogger<EserciziController> _logger;

        public EserciziController(ILogger<EserciziController> logger, IEsercizioRepository repo, IStiliRepository slrepo, ModelMap mapper)
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
        public async Task<IActionResult> Get()
        {
            var esercizi = await _eserciziRepo.GetEsercizi();
            //Task<IEnumerable<EserciziVM>>
            var eserciziList = new List<EserciziVM>();
            foreach (var item in esercizi)
            {
                var stile = await _stiliRepo.GetStileById(item.StileId);
                var esercizio = _mapper.toViewModel(item);
                esercizio.Stile = stile.Nome;
                //eserciziList.Add(_mapper.toViewModel(item));
                eserciziList.Add(esercizio);
            }
            return Ok(eserciziList);
            //return Ok(await _eserciziRepo.GetEsercizi());
        }

        [HttpGet("{id:int}")]
        //[HttpDelete("{id}")]
        //[Route("DeleteEsercizi/{Id}")]
        //[Route("/{Id}")]
        public JsonResult Get(int id)
        {
            var esercizio =  _eserciziRepo.GetEsercizioByID(id);
            return new JsonResult(esercizio);
        }

        [HttpPost(Name = "AddEsercizi")]
        public async Task<IActionResult> Post(EserciziVM es)
        {
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
                //return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
                return new JsonResult(StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong"));
            }
            //return Ok("Ok");
            return new JsonResult("Added Successfully");
        }
      
        //[HttpDelete]
        //[Route("DeleteEsercizi/{Id}")]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
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

        [HttpPut]
        [Route("UpdateEsercizi")]
        public async Task<IActionResult> Put(EserciziVM es)
        {


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

            await _eserciziRepo.UpdateEsercizio(esToUpdate);
            return new JsonResult("Updated Successfully");
        }
    }
}
