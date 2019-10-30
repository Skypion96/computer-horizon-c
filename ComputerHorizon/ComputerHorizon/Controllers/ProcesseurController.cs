using System.Collections.Generic;
using ComputerHorizon.ModelsCG;
using ComputerHorizon.ModelsProc;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class ProcesseurController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsProc.Processeur> Get()
        {
            return ProcesseurDao.Query();
        }
        
        [HttpPost]
        public ComputerHorizon.ModelsProc.Processeur Post([FromBody]ComputerHorizon.ModelsProc.Processeur proc)
        {
            return ProcesseurDao.Post(proc);
        }
    }
}