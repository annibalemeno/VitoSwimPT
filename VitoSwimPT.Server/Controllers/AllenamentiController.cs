using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.ViewModels;

namespace VitoSwimPT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[EnableCors("AllowAllHeaders")]
    //[EnableCors("AllowLocal")] 
    public class AllenamentiController : ControllerBase
    {

        private readonly ILogger<AllenamentiController> _logger;
        private readonly IAllenamentoRepository _allenamentiRepo;
        public AllenamentiController(ILogger<AllenamentiController> logger, IAllenamentoRepository repo)
        {
            _allenamentiRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }

        [HttpGet(Name = "GetAllenamenti")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _allenamentiRepo.GetAllenamenti());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost(Name = "AddAllenamenti")]
        public async Task<IActionResult> Post(Allenamento train)
        {
            try
            {
                var result = await _allenamentiRepo.InsertAllenamento(train);
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

        //[HttpDelete]
        //[Route("DeleteAllenamenti/{Id}")]
        [HttpDelete("{id}")]
       
        public JsonResult Delete(int id)
        {
           bool res =  _allenamentiRepo.DeleteAllenamento(id);
            if (res)
            {
               return new JsonResult("Deleted Successfully");
            }
            else
            {
                return new JsonResult("Allenamento not found or deleting error");
            }
        }

        [HttpPut]
        [Route("UpdateAllenamenti")]
        public async Task<IActionResult> Put(Allenamento training)
        {
            try
            {
                //get training by id
                Allenamento trainToUpd = await _allenamentiRepo.GetAllenamentoById(training.AllenamentoId);

                //gestisco modifiche
                trainToUpd.NomeAllenamento = training.NomeAllenamento;
                trainToUpd.Note = training.Note;

                await _allenamentiRepo.UpdateAllenamento(trainToUpd);
                return new JsonResult("Updated Successfully");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
