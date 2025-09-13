using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;

namespace VitoSwimPT.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PianiController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IPianiRepository _planRepo;
        public PianiController(Serilog.ILogger logger, IPianiRepository repo)
        {
            _planRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }

        [HttpGet(Name = "GetPiani")]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.Debug("Controller Piani Get()");
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
                _logger.Debug($"Controller Piani Post(plan) with plan = {plan}");
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
                _logger.Debug($"Controller Piani Delete(id) with id = {id}");
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
                _logger.Debug($"Controller Piani Put(plan) with plan = {plan} ");
                //get plan by id
                Piano planToUpdate = await _planRepo.GetPianoById(plan.PianoId);

                //gestisco modifiche
                planToUpdate.NomePiano = plan.NomePiano;
                planToUpdate.Descrizione = plan.Descrizione;
                planToUpdate.Note = plan.Note;
                planToUpdate.UpdateDateTime = DateTime.Now;

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
