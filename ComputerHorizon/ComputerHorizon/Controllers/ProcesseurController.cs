using System.Collections.Generic;
using ComputerHorizon.ModelsCG;
using ComputerHorizon.ModelsProc;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class ProcesseurController : ControllerBase
    {
        //AFFICHAGE DE TOUT LES PROCESSEURS / IMAGE + NOM +MARQUE
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsProc.Processeur> Get()
        {
            return ProcesseurDao.QueryBase();
        }
         
        //AFFICHAGE D'UN PROCESSEURS PARTICULIER
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.ModelsProc.Processeur GetOneElement(Processeur proc)
        {
            return ProcesseurDao.Query(proc);
        }

        //AJOUT D'UN NOUVEAU PROCESSEURS
        [HttpPost]
        public ComputerHorizon.ModelsProc.Processeur Post([FromBody]ComputerHorizon.ModelsProc.Processeur proc)
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
        public ActionResult Update([FromBody]ComputerHorizon.ModelsProc.Processeur proc)
        {
            return ProcesseurDao.Update(proc) ? (ActionResult) Ok():BadRequest();
        }
    }
}