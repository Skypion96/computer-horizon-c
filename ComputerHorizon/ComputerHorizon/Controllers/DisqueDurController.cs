using System.Collections.Generic;
using ComputerHorizon.Components;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class DisqueDurController : ControllerBase
    {
        //AFFICHAGE DE TOUT LES DISQUES DUR / IMAGE + NOM +MARQUE
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.DisqueDur> Get()
        {
            return DisqueDurDao.QueryBase();
        }
        
        //AFFICHAGE D'UN DISQUE DUR PARTICULIER
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.Components.DisqueDur GetOneElement(DisqueDur disqued)
        {
            return DisqueDurDao.Query(disqued);
        }

        //AJOUT D'UN NOUVEAU DISQUE DUR
        [HttpPost]
        public ComputerHorizon.Components.DisqueDur Post([FromBody]ComputerHorizon.Components.DisqueDur disqueD)
        {
            return DisqueDurDao.Post(disqueD);
        }
        
        //SUPPRESSION D'UN DISQUE DUR PARTICULIER
        [HttpDelete("{nom}")]
        public ActionResult Delete(string nom)
        {
            return DisqueDurDao.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
        
        //MISE A JOUR DES INFORMATIONS D'UN DISQUE DUR
        [HttpPut]
        public ActionResult Update([FromBody]ComputerHorizon.Components.DisqueDur disqueD)
        {
            return DisqueDurDao.Update(disqueD) ? (ActionResult) Ok():BadRequest();
        }
        
        
    }
}