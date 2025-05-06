using Microsoft.AspNetCore.Mvc;
using VitoSwimPT.Server.Migrations;
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
            IEnumerable<Models.EsercizioAllenamento> training = await _trainingRepo.GetEserciziAllenamentoByID(id); // await
            var trainVM = _mapper.toViewModel(training);       //robustezza
            //trainVM.nomeAllenamento = ;
            //trainVM.note = ;

            return Ok(trainVM);
        }


    }
}
