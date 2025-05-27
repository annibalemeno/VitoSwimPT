using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PianiController : ControllerBase
    {
        private readonly ILogger<PianiController> _logger;
        private readonly IPianiRepository _planRepo;
        public PianiController(ILogger<PianiController> logger, IPianiRepository repo)
        {
            _planRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }

        [HttpGet(Name = "GetPiani")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _planRepo.GetAllPiani());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost(Name = "AddPiano")]
        public async Task<IActionResult> Post(Piano plan)
        {
            try
            {
                var result = await _planRepo.InsertPiano(plan);
                if (result.PianoId == 0)
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

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                bool res = _planRepo.DeletePiano(id);
                if (res)
                {
                    return new JsonResult("Deleted Successfully");
                }
                else
                {
                    return new JsonResult("Piano not found or deleting error");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdatePiano")]
        public async Task<IActionResult> Put(Piano plan)
        {
            try
            {
                //get plan by id
                Piano planToUpdate = await _planRepo.GetPianoById(plan.PianoId);

                //gestisco modifiche
                planToUpdate.NomePiano = plan.NomePiano;
                planToUpdate.Descrizione = plan.Descrizione;
                planToUpdate.Note = plan.Note;

                await _planRepo.UpdatePiano(planToUpdate);
                return new JsonResult("Updated Successfully");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
