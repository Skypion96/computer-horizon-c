using System.Collections.Generic;
using ComputerHorizon.ModelsCG;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class CarteGraphiqueController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsCG.CarteGraphique> Get()
        {
            return CarteGraphiqueDao.QueryBase();
        }
        
        [HttpPost]
        public ComputerHorizon.ModelsCG.CarteGraphique Post([FromBody]ComputerHorizon.ModelsCG.CarteGraphique carteG)
        {
            return CarteGraphiqueDao.Post(carteG);
        }
        
        [HttpGet]
        public ComputerHorizon.ModelsCG.CarteGraphique GetOneElement(CarteGraphique carteG)
        {
            return CarteGraphiqueDao.Query(carteG);
        }
    }
}