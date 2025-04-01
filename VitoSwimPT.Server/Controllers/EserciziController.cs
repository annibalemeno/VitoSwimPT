using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EserciziController : ControllerBase
    {
        private readonly IEsercizioRepository _eserciziRepo;

        private static readonly string[] Summaries = new[]
        {
            "Delfino", "Dorso", "Rana", "Stile"
        };

        private readonly ILogger<EserciziController> _logger;

        public EserciziController(ILogger<EserciziController> logger, IEsercizioRepository repo)
        {
            _eserciziRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
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
            return Ok(await _eserciziRepo.GetEsercizi());
        }

        [HttpPost(Name = "AddEsercizi")]
        public async Task<IActionResult> Post(Esercizio es)
        {
            var result = await _eserciziRepo.InsertEsercizio(es);
            if (result.EsercizioId == 0)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
                return new JsonResult(StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong"));
            }
            //return Ok("Ok");
            return new JsonResult("Added Successfully");
        }

        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteEsercizi/{Id}")]
        public JsonResult Delete(int id)
        {
            _eserciziRepo.DeleteEsercizio(id);
            return new JsonResult("Deleted Successfully");
        }

        [HttpPut]
        [Route("UpdateEsercizi")]
        public async Task<IActionResult> Put(Esercizio es)
        {
            await _eserciziRepo.UpdateEsercizio(es);
            return new JsonResult("Updated Successfully");
        }
    }
}
