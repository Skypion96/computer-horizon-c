using System.Collections.Generic;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierCarteGraphiqueController : ControllerBase
    {
        [HttpPost]
        public ComputerHorizon.Components.PanierCarteGraphique Post([FromBody]ComputerHorizon.Components.PanierCarteGraphique panierCG)
        {
            return PanierCarteGraphiqueDAO.Post(panierCG);
        }
        
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.PanierCarteGraphique> Get()
        {
            return PanierCarteGraphiqueDAO.QueryBase();
        }
        
        [HttpDelete("{nom}")]
        public ActionResult Delete(string nom)
        {
            return PanierCarteGraphiqueDAO.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
    }
}