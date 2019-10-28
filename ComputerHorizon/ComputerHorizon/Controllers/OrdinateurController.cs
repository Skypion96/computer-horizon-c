using System.Collections.Generic;
using ComputerHorizon.ModelsCG;
using ComputerHorizon.ModelsOrdinateur;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class OrdinateurController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsOrdinateur.Ordinateur> Get()
        {
            return OrdinateurDao.Query();
        }
    }
}