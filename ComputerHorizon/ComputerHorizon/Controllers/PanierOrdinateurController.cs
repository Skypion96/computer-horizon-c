using System.Collections.Generic;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierOrdinateurController : ControllerBase
    {
        [HttpPost]
        public ComputerHorizon.Components.PanierOrdinateur Post([FromBody]ComputerHorizon.Components.PanierOrdinateur panierO)
        {
            return PanierOrdinateurDAO.Post(panierO);
        }
        
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.PanierOrdinateur> Get()
        {
            return PanierOrdinateurDAO.QueryBase();
        }
        
        //SUPPRESSION D'UN DISQUE DUR PARTICULIER
        [HttpDelete("{nom}")]
        public ActionResult Delete(string nom)
        {
            return PanierOrdinateurDAO.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
    }
}