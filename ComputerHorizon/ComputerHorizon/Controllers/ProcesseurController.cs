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
    }
}