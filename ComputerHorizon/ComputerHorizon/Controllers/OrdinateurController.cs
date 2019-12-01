using System.Collections.Generic;
using ComputerHorizon.Components;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class OrdinateurController : ControllerBase
    {
        //AFFICHAGE DE TOUT LES ORDINATEURS / IMAGE + NOM +MARQUE
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.Ordinateur> Get()
        {
            return OrdinateurDao.QueryBase();
        }
        
        //AJOUT D4UN NOUVELLE ORDINATEUR
        [HttpPost]
        public ComputerHorizon.Components.Ordinateur Post([FromBody]ComputerHorizon.Components.Ordinateur ordi)
        {
            return OrdinateurDao.Post(ordi);
        }
        
        //AFFICHAGE D'UN ORDINATEUR PARTICULIER
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.Components.Ordinateur GetOneElement(Ordinateur ordi)
        {
            return OrdinateurDao.Query(ordi);
        }
        
        //SUPPRESSION D'UN ORDINATEUR PARTICULIER
        [HttpDelete("{id}")]
        public ActionResult Delete(string nom)
        {
            return OrdinateurDao.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
        
        //MISE A JOUR DES INFORMATIONS D'UN ORDINATEUR
        [HttpPut]
        public ActionResult Update([FromBody]ComputerHorizon.Components.Ordinateur ordi)
        {
            return OrdinateurDao.Update(ordi) ? (ActionResult) Ok():BadRequest();
        }
    }
}