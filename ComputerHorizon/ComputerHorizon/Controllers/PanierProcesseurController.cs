using System.Collections.Generic;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierProcesseurController : ControllerBase
    {
        [HttpPost]
        public ComputerHorizon.Components.PanierProcesseur Post([FromBody]ComputerHorizon.Components.PanierProcesseur panierP)
        {
            return PanierProcesseurDAO.Post(panierP);
        }
        
        [HttpGet("{id}")]
        public IEnumerable<ComputerHorizon.Components.PanierProcesseur> Get(string id)
        {
            return PanierProcesseurDAO.QueryBase(id);
        }
        
        //SUPPRESSION D'UN DISQUE DUR PARTICULIER
        [HttpDelete("{nom}")]
        public ActionResult Delete(string nom)
        {
            return PanierProcesseurDAO.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
    }
}