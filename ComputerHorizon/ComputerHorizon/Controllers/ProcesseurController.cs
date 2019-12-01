using System.Collections.Generic;
using ComputerHorizon.Components;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class ProcesseurController : ControllerBase
    {
        //AFFICHAGE DE TOUT LES PROCESSEURS / IMAGE + NOM +MARQUE
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.Processeur> Get()
        {
            return ProcesseurDao.QueryBase();
        }
         
        //AFFICHAGE D'UN PROCESSEURS PARTICULIER
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.Components.Processeur GetOneElement(Processeur proc)
        {
            return ProcesseurDao.Query(proc);
        }

        //AJOUT D'UN NOUVEAU PROCESSEURS
        [HttpPost]
        public ComputerHorizon.Components.Processeur Post([FromBody]ComputerHorizon.Components.Processeur proc)
        {
            return ProcesseurDao.Post(proc);
        }
       
        //SUPPRESSION D'UN PROCESSEUR PARTICULIER
        [HttpDelete("{nom}")]
        public ActionResult Delete(string nom)
        {
            return ProcesseurDao.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
        
        //MISE A JOUR DES INFORMATIONS D'UN PROCESSEUR
        [HttpPut]
        public ActionResult Update([FromBody]ComputerHorizon.Components.Processeur proc)
        {
            return ProcesseurDao.Update(proc) ? (ActionResult) Ok():BadRequest();
        }
    }
}