using System.Collections.Generic;
using ComputerHorizon.ModelsDD;
using ComputerHorizon.ModelsUtilisateur;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class UtilisateurController : ControllerBase
    {
        //AFFICHAGE DE TOUT LES DISQUES DUR / IMAGE + NOM +MARQUE
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsUtilisateur.Utilisateur> Get()
        {
            return UtilisateurDAO.QueryBase();
        }
        
        //AFFICHAGE D'UN DISQUE DUR PARTICULIER
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.ModelsUtilisateur.Utilisateur GetOneElement(Utilisateur user)
        {
            return UtilisateurDAO.Query(user);
        }

        //AJOUT D'UN NOUVEAU DISQUE DUR
        [HttpPost]
        public ComputerHorizon.ModelsUtilisateur.Utilisateur Post([FromBody]ComputerHorizon.ModelsUtilisateur.Utilisateur user)
        {
            return UtilisateurDAO.Post(user);
        }
        
        //SUPPRESSION D'UN DISQUE DUR PARTICULIER
        [HttpDelete("{id}")]
        public ActionResult Delete(string nom)
        {
            return DisqueDurDao.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
        
        //MISE A JOUR DES INFORMATIONS D'UN DISQUE DUR
        [HttpPut]
        public ActionResult Update([FromBody]ComputerHorizon.ModelsUtilisateur.Utilisateur user)
        {
            return UtilisateurDAO.Update(user) ? (ActionResult) Ok():BadRequest();
        }
    }
}