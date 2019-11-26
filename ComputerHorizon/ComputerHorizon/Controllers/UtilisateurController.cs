using System.Collections.Generic;
using ComputerHorizon.ModelsDD;
using ComputerHorizon.ModelsUtilisateur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class UtilisateurController : ControllerBase
    {
        private UtilisateurController _userService;
        
        //AFFICHAGE DE TOUT LES UTILISATEURS
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsUtilisateur.Utilisateur> Get()
        {
            return UtilisateurDAO.QueryBase();
        }
        
        //AFFICHAGE D'UN UTILISATEUR PARTICULIER
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.ModelsUtilisateur.Utilisateur GetOneElement(Utilisateur user)
        {
            return UtilisateurDAO.Query(user);
        }

        //AJOUT D'UN NOUVEAU UTILISATEUR
        [HttpPost]
        public ComputerHorizon.ModelsUtilisateur.Utilisateur Post([FromBody]ComputerHorizon.ModelsUtilisateur.Utilisateur user)
        {
            return UtilisateurDAO.Post(user);
        }
        
        //SUPPRESSION D'UN UTILISATEUR PARTICULIER
        [HttpDelete("{id}")]
        public ActionResult Delete(string nom)
        {
            return UtilisateurDAO.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
        
        //MISE A JOUR DES INFORMATIONS D'UN UTILISATEUR
        [HttpPut]
        public ActionResult Update([FromBody]ComputerHorizon.ModelsUtilisateur.Utilisateur user)
        {
            return UtilisateurDAO.Update(user) ? (ActionResult) Ok():BadRequest();
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]ComputerHorizon.ModelsUtilisateur.Utilisateur user)
        {
            var utiliateur = _userService.Authenticate(user.Mail, user.Mdp);

            if (utiliateur == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(utiliateur);
        }

        private object Authenticate(string userMail, string userMdp)
        {
            throw new System.NotImplementedException();
        }
    }
}