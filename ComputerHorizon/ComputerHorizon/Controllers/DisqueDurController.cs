using System.Collections.Generic;
using ComputerHorizon.ModelsCG;
using ComputerHorizon.ModelsDD;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class DisqueDurController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsDD.DisqueDur> Get()
        {
            return DisqueDurDao.Query();
        }
        
        [HttpPost]
        public ComputerHorizon.ModelsDD.DisqueDur Post([FromBody]ComputerHorizon.ModelsDD.DisqueDur disqueD)
        {
            return DisqueDurDao.Post(disqueD);
        }
    }
}