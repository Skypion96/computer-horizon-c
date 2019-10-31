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
            return OrdinateurDao.QueryBase();
        }
        
        [HttpPost]
        public ComputerHorizon.ModelsOrdinateur.Ordinateur Post([FromBody]ComputerHorizon.ModelsOrdinateur.Ordinateur ordi)
        {
            return OrdinateurDao.Post(ordi);
        }
        
        [HttpGet]
        public ComputerHorizon.ModelsOrdinateur.Ordinateur GetOneElement(Ordinateur ordi)
        {
            return OrdinateurDao.Query(ordi);
        }
    }
}